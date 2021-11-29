using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Model;

namespace ZlatarApp.Utils
{
    public partial class FormSfc : Form
    {
        public int Merged { get; set; }

        public FormSfc()
        {
            InitializeComponent();
            Merged = 0;

            Helpers.MachineDelayInSeconds = Helpers.ParseStrToDouble(txtBoxMachineDelay.Text);
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
                txtBoxMachineDelay.Visible = true;
            }
        }

        private async void btnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                Helpers.MachineDelayInSeconds = Helpers.ParseStrToDouble(txtBoxMachineDelay.Text);
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

            StringBuilder sbMergedFile = Helpers.MergeFilesInFolder(dir);
            string date = Helpers.GetDateFromSfcFiles(dir);
            string electrolyte = Helpers.GetElectrolyteFromSfcFiles(dir);
            
            if (date != "")
            {
                string measurementDateFolder = Path.Combine(Helpers.AppFolderPath, date);
                string sfcFolder = Path.Combine(measurementDateFolder, Helpers.SFC_DIR);
                string sfcMergedFileFolder = Path.Combine(sfcFolder, Helpers.SFC_MERGED_DIR);
                Directory.CreateDirectory(sfcMergedFileFolder);
                string mergedFilePath = Path.Combine(sfcMergedFileFolder, date + "_" + dir.Split('\\').Last() + "_MergedFile.txt");

                if (await SaveMergedFile(sbMergedFile, electrolyte, mergedFilePath))
                    Merged++;
            }
        }

        private async Task<bool> SaveMergedFile(StringBuilder sbMergedFile, string electrolyte, string mergedFilePath)
        {
            List<double> timeInSec = new List<double>();
            List<double> vf = new List<double>();
            List<double> im = new List<double>();
            List<double> overloads = new List<double>();

            string[] lines = sbMergedFile.ToString().Split('\n');
            foreach (var line in lines)
            {
                if (line == "")
                    break;
                string[] values = line.Split('\t');
                timeInSec.Add(Helpers.ParseStrToDouble(values[0]));
                vf.Add(Helpers.ParseStrToDouble(values[1]));
                im.Add(Helpers.ParseStrToDouble(values[2]));
                overloads.Add(Helpers.ParseStrToDouble(values[3]));
            }

            SfcMergedFile sfcMergedFile = new SfcMergedFile(timeInSec, vf, im, overloads);
            if (await sfcMergedFile.Save(electrolyte, mergedFilePath))
                return true;
            else
                return false;
        }
    }
}
