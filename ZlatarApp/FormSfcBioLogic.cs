using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Model;
using ZlatarApp.Utils;

namespace ZlatarApp
{
    public partial class FormSfcBioLogic : Form
    {
        public int Merged { get; set; }
        public char DELIMITER = '\t';

        public FormSfcBioLogic()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (txtBoxFolderPath.Text != "")
                folderBrowserDialog.SelectedPath = txtBoxFolderPath.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                lvFolderContent.Items.Clear();
                lvFolderContent.Columns.Clear();
                txtBoxFolderPath.Text = folderBrowserDialog.SelectedPath;

                ColumnHeader header = new ColumnHeader();
                header.Width = lvFolderContent.Width - 25;
                lvFolderContent.Columns.Add(header);

                foreach (string path in Directory.GetFileSystemEntries(txtBoxFolderPath.Text))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Path.GetFileName(path);
                    item.Tag = path;
                    lvFolderContent.Items.Add(item);
                }

                btnMerge.Visible = true;
            }
        }

        private async void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                await MergeFiles(txtBoxFolderPath.Text);

                if (Merged > 0)
                    MessageBox.Show(this, "Merge successful!", "Message", MessageBoxButtons.OK);
                else
                    MessageBox.Show(this, "Merge failed!", "Message", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private async Task MergeFiles(string dir)
        {
            if (Directory.GetDirectories(dir).Length != 0)
            {
                foreach (string dirPath in Directory.GetDirectories(dir))
                {
                    await MergeFiles(dirPath);
                }
            }

            StringBuilder sbMergedFile = MergeFilesInFolder(dir);

            string[] pom = dir.Split('\\');
            string date = pom[pom.Length - 2];

            if (date != "" && pom[pom.Length - 1].Contains("ML"))
            {
                string measurementDateFolder = Path.Combine(Helpers.AppFolderPath, date);
                string sfcFolder = Path.Combine(measurementDateFolder, Helpers.SFC_DIR);
                string sfcMergedFileFolder = Path.Combine(sfcFolder, Helpers.SFC_MERGED_DIR);
                Directory.CreateDirectory(sfcMergedFileFolder);

                string mergedFilePath = Path.Combine(sfcMergedFileFolder, date + "_" + dir.Split('\\').Last() + "_MergedFile.txt");

                if (await SaveMergedFile(sbMergedFile, mergedFilePath))
                    Merged++;
            }
        }

        public static StringBuilder MergeFilesInFolder(string folderPath)
        {
            List<string> allFiles = Directory.GetFiles(folderPath).ToList();
            List<string> filesForMerge = new List<string>();

            foreach (string file in allFiles)
            {
                if (Path.GetFileName(file).Contains("ML") && Path.GetFileName(file).Split('.').Last() == "csv")
                {
                    filesForMerge.Add(file);
                }
            }

            StringBuilder stringBuilderMergedFile = new StringBuilder();
            ReadAllFilesAsync(filesForMerge, stringBuilderMergedFile);
            return stringBuilderMergedFile;
        }

        private static async Task ReadAllFilesAsync(List<string> filesForMerge, StringBuilder stringBuilderMergedFile)
        {
            List<FileInfo> fInfo = new List<FileInfo>();
            filesForMerge.ForEach(f => fInfo.Add(new FileInfo(f)));

            var listByTime = fInfo.OrderBy(f => f.LastWriteTime).ToList();

            foreach (var fileInfo in listByTime)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileInfo.FullName))
                    {
                        await Helpers.DropRowsUntilValuesSfcBioLogic(reader); 

                        while (!reader.EndOfStream)
                        {
                            string[] line = reader.ReadLine().Split(';');

                            //While merging bioLogic files, convert current from mA to A by dividing with 1000
                            //then merged gamry and merged BioLogic are same measurement units and are basicly same file
                            stringBuilderMergedFile.AppendLine(
                                Double.Parse(line[0], CultureInfo.InvariantCulture).ToString("F12", CultureInfo.InvariantCulture) +
                                "\t" + Helpers.ParseStrToDouble(line[1]).ToString("F12", CultureInfo.InvariantCulture) +
                                "\t" + (Helpers.ParseStrToDouble(line[2]) / 1000).ToString("F12", CultureInfo.InvariantCulture));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private async Task<bool> SaveMergedFile(StringBuilder sbMergedFile, string mergedFilePath)
        {
            List<double> timeInSec = new List<double>();
            List<double> vf = new List<double>();
            List<double> im = new List<double>();

            string[] lines = sbMergedFile.ToString().Split('\n');
            foreach (var line in lines)
            {
                if (line == "")
                    break;
                string[] values = line.Split('\t');
                timeInSec.Add(Helpers.ParseStrToDouble(values[0]));
                vf.Add(Helpers.ParseStrToDouble(values[1]));
                im.Add(Helpers.ParseStrToDouble(values[2]));
            }

            if (await Save(mergedFilePath, timeInSec, vf, im))
                return true;
            else
                return false;
        }

        public async Task<bool> Save(string path, List<double> TimeInSec, List<double> Vf, List<double> Im)
        {
            if (TimeInSec.Count == 0)
                return false;

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var date = DateTime.Now;
                    writer.WriteLine("Date: " + date.ToShortDateString() +
                        "\tTime: " + date.ToShortTimeString());
                    writer.WriteLine($"t/s{DELIMITER}Ewe/V{DELIMITER}I/mA");

                    for (int i = 0; i < TimeInSec.Count; i++)
                    {
                        writer.Write(TimeInSec[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(Vf[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.WriteLine(Im[i].ToString("F12", CultureInfo.InvariantCulture));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
