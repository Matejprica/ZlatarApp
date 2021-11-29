
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZlatarApp.Model;
using ZlatarApp.Utils;
using static System.Windows.Forms.ListViewItem;

namespace ZlatarApp
{
    public partial class FormCalibration : Form
    {
        public List<IcpMsCalibration> CalibrationFiles { get; set; }
        public Calibration Calibration { get; set; }

        public FormCalibration()
        {
            InitializeComponent();

            CalibrationFiles = new List<IcpMsCalibration>();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            foreach (TextBox textBox in pnlTopContainer.Controls.OfType<TextBox>())
            {
                if (textBox.Name == button.Tag.ToString())
                {
                    textBox.Text = "";
                    textBox.Tag = null;
                    listView.Items.Clear();
                    listView.Columns.Clear();
                    lblDate.Text = "";
                    lblDate.Visible = false;
                    lblMeasurementDate.Visible = false;
                    btnSave.Visible = false;
                }
            }
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            if (txtBoxBlank1.Text != "" && txtBoxS1.Text != "" && txtBoxS2.Text != "" && txtBoxS3.Text != "")
            {
                if(Helpers.IcpMsFilesSameDate(new List<string> { txtBoxBlank1.Text, txtBoxBlank2.Text, txtBoxS1.Text, txtBoxS2.Text, txtBoxS3.Text }))
                {
                    listView.Items.Clear();
                    listView.Columns.Clear();
                    Calibrate();
                    btnSave.Visible = true;
                    btnSave.Focus();

                    lblMeasurementDate.Visible = true;
                    lblDate.Visible = true;
                    lblDate.Text = Utils.Helpers.GetDateFromFileName(Path.GetFileName(CalibrationFiles.First().FullPath)).ToString("yyyy_MM_dd");
                }
                else
                {
                    MessageBox.Show(this, "Your input files are not from the same date!", "Error", MessageBoxButtons.OK);
                    lblMeasurementDate.Visible = false;
                    lblDate.Visible = false;
                    lblDate.Text = "";
                }
            }
            else
            {
                MessageBox.Show(this, "You are missing input files!", "Error", MessageBoxButtons.OK);
                lblMeasurementDate.Visible = false;
                lblDate.Visible = false;
                lblDate.Text = "";
            }
        }

        private void Calibrate()
        {
            InitializeInputDataFiles();
            InitializeCalibration();
            ListViewOutput();
        }

        private void InitializeInputDataFiles()
        {
            CalibrationFiles.Add(new IcpMsCalibration(txtBoxBlank1.Tag.ToString()));
            if (txtBoxBlank2.Tag != null && txtBoxBlank2.Tag.ToString() != "")
                CalibrationFiles.Add(new IcpMsCalibration(txtBoxBlank2.Tag.ToString()));
            CalibrationFiles.Add(new IcpMsCalibration(txtBoxS1.Tag.ToString()));
            CalibrationFiles.Add(new IcpMsCalibration(txtBoxS2.Tag.ToString()));
            CalibrationFiles.Add(new IcpMsCalibration(txtBoxS3.Tag.ToString()));
        }

        private void InitializeCalibration()
        {
            List<Element> blank1 = CalibrationFiles[0].ElementsAndIs;
            List<Element> blank2 = CalibrationFiles.Count == 5 ? CalibrationFiles[1].ElementsAndIs : null;
            List<Element> s1 = CalibrationFiles[CalibrationFiles.Count - 3].ElementsAndIs;
            List<Element> s2 = CalibrationFiles[CalibrationFiles.Count - 2].ElementsAndIs;
            List<Element> s3 = CalibrationFiles[CalibrationFiles.Count - 1].ElementsAndIs;
            DateTime date = Helpers.GetDateFromFileName(Path.GetFileName(CalibrationFiles[0].FullPath));

            Calibration = new Calibration(blank1, blank2, s1, s2, s3, date.ToString("yyyy_MM_dd"));
        }

        private void ListViewOutput()
        {                    
            ColumnHeader columnFileName = new ColumnHeader();
            columnFileName.Text = "File Name";  
            columnFileName.Width = 75;            

            ColumnHeader columnElement = new ColumnHeader();
            columnElement.Text = "Element";
            columnElement.Width = 60;

            ColumnHeader columnAverageValue = new ColumnHeader();
            columnAverageValue.Text = "Average Value";
            columnAverageValue.Width = 130;

            ColumnHeader columnStDev = new ColumnHeader();
            columnStDev.Text = "SD";
            columnStDev.Width = 130;

            ColumnHeader columnRelStDev = new ColumnHeader();
            columnRelStDev.Text = "RSD";
            columnRelStDev.Width = 60;

            listView.Columns.AddRange(new ColumnHeader[] { columnFileName, columnElement, columnAverageValue, columnStDev, columnRelStDev});
            CalibrationFiles.ForEach(f => ListViewFileOutput(f));
        }

        private void ListViewFileOutput(IcpMsCalibration icpMsCalibration)
        {
            foreach (Element element in icpMsCalibration.ElementsAndIs)
            {
                ListViewItem item = new ListViewItem();
                item.Text = Helpers.GetFileNameWithoutDate(Path.GetFileName(icpMsCalibration.FullPath));
                item.SubItems.Add(element.Name);
                item.SubItems.Add(element.AverageValue.ToString("0.########e+00"));
                item.SubItems.Add(element.StandardDeviation.ToString("0.########e+00"));
                item.SubItems.Add(Math.Round(element.RelativeStDeviation, 2) + "%");

                item.UseItemStyleForSubItems = false;
                item.SubItems[4].ForeColor = GetListBoxItemColor(element);

                listView.Items.Add(item);
            }
        }

        private Color GetListBoxItemColor(Element element)
        {
            if (Calibration.ElementRSquared[element.Name] >= 0.95)
            {
                return element.RelativeStDeviation < 4 ? Color.Green : Color.Red; //element
            }
            else
            {
                return element.RelativeStDeviation < 2 ? Color.Green : Color.Red; //internal standard
            }
        }                   

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {

            DataObject data = (DataObject)e.Data;

            if (data.ContainsFileDropList())
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<string> incorrectFileNames = new List<string>();
                List<string> importedFiles = new List<string>();

                if (filePaths != null)
                {
                    foreach (string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);

                        if (fileName.ToLower().Contains("blank.xl") || fileName.ToLower().Contains("blank1.xl"))
                        {
                            if (Helpers.IcpMsCorrectFileNameFormat(fileName))
                            {
                                listView.Items.Clear();
                                listView.Columns.Clear();
                                txtBoxBlank1.Text = Path.GetFileName(filePath);
                                txtBoxBlank1.Tag = filePath;
                                importedFiles.Add(fileName);
                            }
                            else
                                incorrectFileNames.Add(fileName);
                        }
                        if (fileName.ToLower().Contains("blank2.xl"))
                        {
                            if (Helpers.IcpMsCorrectFileNameFormat(fileName))
                            {
                                listView.Items.Clear();
                                listView.Columns.Clear();
                                txtBoxBlank2.Text = Path.GetFileName(filePath);
                                txtBoxBlank2.Tag = filePath;
                                importedFiles.Add(fileName);
                            }
                            else
                                incorrectFileNames.Add(fileName);
                        }
                        if (fileName.ToLower().Contains("s1.xl"))
                        {
                            if (Helpers.IcpMsCorrectFileNameFormat(fileName))
                            {
                                listView.Items.Clear();
                                listView.Columns.Clear();
                                txtBoxS1.Text = Path.GetFileName(filePath);
                                txtBoxS1.Tag = filePath;
                                importedFiles.Add(fileName);
                            }
                            else
                                incorrectFileNames.Add(fileName);
                        }
                        if (fileName.ToLower().Contains("s2.xl"))
                        {
                            if (Helpers.IcpMsCorrectFileNameFormat(fileName))
                            {
                                listView.Items.Clear();
                                listView.Columns.Clear();
                                txtBoxS2.Text = Path.GetFileName(filePath);
                                txtBoxS2.Tag = filePath;
                                importedFiles.Add(fileName);
                            }
                            else
                                incorrectFileNames.Add(fileName);
                        }
                        if (Path.GetFileName(filePath).ToLower().Contains("s3.xl"))
                        {
                            if (Helpers.IcpMsCorrectFileNameFormat(fileName))
                            {
                                listView.Items.Clear();
                                listView.Columns.Clear();
                                txtBoxS3.Text = Path.GetFileName(filePath);
                                txtBoxS3.Tag = filePath;
                                importedFiles.Add(fileName);
                            }
                            else
                                incorrectFileNames.Add(fileName);
                        }
                    }                   
                }
                if (incorrectFileNames.Count != 0)
                {
                    string incFileNamesOutput = "";
                    incorrectFileNames.ForEach(name => incFileNamesOutput += name.ToString() + '\n');
                    MessageBox.Show(this, "Incorrect file name:\n" + incFileNamesOutput, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void FormCalibration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter && btnSave.Visible == true)
                btnSave.PerformClick();
        }

        private void btnSave_ClickAsync(object sender, EventArgs e)
        {
            Calibration.Save();
        }

        public Calibration GetCalibration()
        {
            return Calibration;
        }
    }
}
