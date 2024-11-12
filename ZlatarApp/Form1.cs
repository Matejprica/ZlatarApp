using Accord;
using Accord.IO;
using Accord.Math.Geometry;
using Accord.Statistics.Kernels;
using Accord.Statistics.Models.Regression.Linear;
using LiveCharts;
using LiveCharts.Charts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts.Helpers;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Model;
using ZlatarApp.Utils;
using static System.Windows.Forms.ListView;
using Point = System.Windows.Point;

namespace ZlatarApp
{
    public partial class Form1 : Form
    {
        private const int FLP_ML_W = 220;
        private const int FLP_ML_H = 160;
        private const int FLP_C_W = 300;
        private const int FLP_C_H = 180;

        public Random Random { get; set; }
        public Calibration Calibration { get; set; }
        public List<FlowLayoutPanel> SelectedIcpMsMlFlpCharts { get; set; }
        public List<FlowLayoutPanel> SelectedIcpMsSfcFlpCharts { get; set; }
        public IcpMsSfc IcpMsSfc { get; set; }
        public Point PeakSfc { get; set; }
        public Point PeakIcpMs { get; set; }
        public string PhNorm { get; set; }
        public string MassNorm { get; set; }
        public string SurfaceNorm { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Size = new Size(1080, 650);
            this.MinimumSize = new Size(1027,570);

            ColumnHeader headerSfc = new ColumnHeader();
            headerSfc.Width = 150;
            headerSfc.Text = "";
            headerSfc.Name = "colSfc";
            lvSfc.Columns.Add(headerSfc);
            lvSfc.HeaderStyle = ColumnHeaderStyle.None;

            ColumnHeader headerIcpMs = new ColumnHeader();
            headerIcpMs.Width = 150;
            headerIcpMs.Text = "";
            headerIcpMs.Name = "colIcpMs";
            lvIcpMs.Columns.Add(headerIcpMs);
            lvIcpMs.HeaderStyle = ColumnHeaderStyle.None;

            ColumnHeader headerSfcNormalization = new ColumnHeader();
            headerSfcNormalization.Width = 150;
            headerSfcNormalization.Text = "";
            headerSfcNormalization.Name = "colSfcNormalization";
            lvSfcNormalization.Columns.Add(headerSfcNormalization);
            lvSfcNormalization.HeaderStyle = ColumnHeaderStyle.None;

            SelectedIcpMsMlFlpCharts = new List<FlowLayoutPanel>();
            SelectedIcpMsSfcFlpCharts = new List<FlowLayoutPanel>();
            Random = new Random();
            Helpers.InitAppFolder();           
        }

        //ICP MS - CALIBRATION
        private async Task SetControlsCalibrationFalse()
        {
            flpCalibration.Controls.Clear();
            btnCalibrationInfo.Enabled = false;
            btnDeleteCalibration.Enabled = false;
            btnMacroListTreatment.Enabled = false;
            btnDeleteTreatedMacroLists.Enabled = false;

            lblMeasureDatePane1.Visible = false;
            lblMeasureDatePane2.Visible = false;
            lblMeasureDatePane5.Visible = false;
            lblMeasureDatePane1.Text = lblMeasureDatePane2.Text = lblMeasureDatePane5.Text = "";

            SetControlsFlpIcpMsFalse();
        }

        private async Task SetControlsCalibrationTrue()
        {
            btnCalibrationInfo.Enabled = true;
            btnDeleteCalibration.Enabled = true;
            btnMacroListTreatment.Enabled = true;       
            btnDeleteTreatedMacroLists.Enabled = false;         

            lblMeasureDatePane1.Visible = true;
            lblMeasureDatePane2.Visible = true;
            lblMeasureDatePane5.Visible = true;
            lblMeasureDatePane1.Text = lblMeasureDatePane2.Text = lblMeasureDatePane5.Text = "Calibration date: " + Calibration.CalibrationDate;

            await CreateCalibrationPanels();

            flpIcpMs.Controls.Clear();
            SetControlsFlpIcpMsFalse();
        }

        private async Task SetControlsFlpIcpMsTrue()
        {
            btnDeleteTreatedMacroLists.Enabled = true;
        }

        private async Task SetControlsFlpIcpMsFalse()
        {
            flpIcpMs.Controls.Clear();
            btnDeleteTreatedMacroLists.Enabled = false;
        }

        private async void btnCalibrationInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Calibration.CalibrationPath);

            /*
            FormCalibrationInfo formCalibrationInfo = new FormCalibrationInfo();
            formCalibrationInfo.Show();
            */
        }

        private async void btnDeleteCalibration_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure u want to delete calibration?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Calibration = null;
                await SetControlsCalibrationFalse();                          
            }           
        }      

        private async void btnNewCalibration_Click(object sender, EventArgs e)
        {
            FormCalibration formCalibration = new FormCalibration();

            if (formCalibration.ShowDialog() == DialogResult.OK)
            {
                Calibration = formCalibration.GetCalibration();
                await SetControlsCalibrationTrue();                                              
            }
        }

        private async void btnLoadCalibration_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Helpers.AppFolderPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK && Path.GetFileName(openFileDialog.FileName).ToLower().Contains("calibration"))
            {
                await LoadCalibrationAsync(openFileDialog.FileName);
                await SetControlsCalibrationTrue();
            }
        }

        private async Task LoadCalibrationAsync(string filePath)
        {
            List<Element> blank1 = new List<Element>();
            List<Element> blank2 = new List<Element>();
            List<Element> s1 = new List<Element>();
            List<Element> s2 = new List<Element>();
            List<Element> s3 = new List<Element>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    await Helpers.DropRowsUntilValuesCalibrationFile(reader);

                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split('\t');

                        if (line[0] == "")
                            break;

                        Element element = new Element { Name = line[1], AverageValue = Double.Parse(line[2]), StandardDeviation = Double.Parse(line[3]), RelativeStDeviation = Double.Parse(line[4].Remove(line[4].Count() - 1)) };

                        string fileName = line[0].ToLower();

                        if (fileName.Contains("blank.xl") || fileName.Contains("blank1.xl"))
                        {
                            blank1.Add(element);
                        }
                        if (fileName.Contains("blank2.xl"))
                        {
                            blank2.Add(element);
                        }
                        if (fileName.Contains("s1.xl"))
                        {
                            s1.Add(element);
                        }
                        if (fileName.Contains("s2.xl"))
                        {
                            s2.Add(element);
                        }
                        if (fileName.Contains("s3.xl"))
                        {
                            s3.Add(element);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (blank2.Count == 0)
                blank2 = null;

            DateTime date = Helpers.GetDateFromFileName(filePath.Split('\\')[filePath.Split('\\').Count() - 3]);
            Calibration = new Calibration(blank1, blank2, s1, s2, s3, date.ToString("yyyy_MM_dd"))
            {
                CalibrationPath = filePath
            };
        }

        private async Task CreateCalibrationPanels()
        {
            flpCalibration.Controls.Clear();

            foreach (string elementName in Calibration.Elements)
            {
                flpCalibration.Controls.Add(await CreateCalibrationPanel(elementName));
            }
        }            

        private async Task<FlowLayoutPanel> CreateCalibrationPanel(string elementName)
        {
            FlowLayoutPanel flp = await CreateFlp("flpCalibration");

            Label lblElementName = new Label
            {
                Text = elementName,
                AutoSize = true
            };
            lblElementName.MouseDoubleClick += FlpChild_MouseDoubleClick;

            Label lblLinearEquation = new Label
            {
                Text = "y = " + Calibration.ElementLinearEquation[elementName],
                AutoSize = true
            };
            lblLinearEquation.MouseDoubleClick += FlpChild_MouseDoubleClick;

            Label lblRsquared = new Label
            {
                Text = "R^2 = " + Calibration.ElementRSquared[elementName].ToString("F12", CultureInfo.InvariantCulture),
                AutoSize = true
            };
            lblRsquared.MouseDoubleClick += FlpChild_MouseDoubleClick;

            List<Point> chartPoints = Calibration.GetPoints(elementName);

            List<ObservablePoint> observablePoints = new List<ObservablePoint>();
            chartPoints.ForEach(p => observablePoints.Add(new ObservablePoint(p.X, p.Y)));

            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart
            {
                Series = new SeriesCollection {
                new LiveCharts.Wpf.LineSeries{
                    Title = elementName,
                    Values = observablePoints.AsChartValues(),
                    Fill = System.Windows.Media.Brushes.Transparent,
                }
            },
                AxisX = new LiveCharts.Wpf.AxesCollection {
                new LiveCharts.Wpf.Axis{
                    Separator = new LiveCharts.Wpf.Separator
                    {
                        Step = 2
                    },
                    MaxValue = 6
                }
            },
                Tag = "Counts",
                BackColor = Color.Black,
                DisableAnimations = true,
                Size = new System.Drawing.Size(flp.Width - 25, 100)
            };

            flp.Controls.AddRange(new Control[] { lblElementName, lblLinearEquation, lblRsquared, chart});          

            return flp;
        }       

        private async Task<FlowLayoutPanel> CreateFlp(string flpName)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Name = flpName,
                FlowDirection = FlowDirection.TopDown,
                ContextMenuStrip = cmsFlpChart,
                Size = flpName == "flpCalibration" ? new System.Drawing.Size(FLP_C_W, FLP_C_H) : new System.Drawing.Size(FLP_ML_W, FLP_ML_H)
            };
            flp.MouseDoubleClick += Flp_MouseDoubleClick;
            flp.MouseClick += Flp_MouseClick;
            flp.BackColor = Color.LightGray;

            return flp;
        }

        private void FlpChild_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            Flp_MouseDoubleClick(ctrl.Parent, e);
        }

        private void FlpChild_MouseClick(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            Flp_MouseClick(ctrl.Parent, e);
        }

        private async void randomColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ContextMenuStrip cms = (ContextMenuStrip)item.GetCurrentParent();
            FlowLayoutPanel flp = (FlowLayoutPanel)cms.SourceControl;
           
            flp.BackColor = await GetRandomColor();
            if(flp.Name == "flpCalibration")
                flp.Controls[3].BackColor = Color.Black;
            else
                flp.Controls[2].BackColor = Color.Black;
        }

        private async Task<Color> GetRandomColor()
        {
            return Color.FromArgb(Random.Next(255), Random.Next(255), Random.Next(255));
        }

        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ContextMenuStrip cms = (ContextMenuStrip)item.GetCurrentParent();
            FlowLayoutPanel flp = (FlowLayoutPanel)cms.SourceControl;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                flp.BackColor = colorDialog.Color;
                flp.Controls[2].BackColor = Color.Black;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ContextMenuStrip cms = (ContextMenuStrip)item.GetCurrentParent();
            FlowLayoutPanel flp = (FlowLayoutPanel)cms.SourceControl;
            FlowLayoutPanel parent = (FlowLayoutPanel)flp.Parent;

            parent.Controls.Remove(flp);

            if (flpIcpMs.Controls.Count == 0)
            {
                cbICpMsElements.Text = string.Empty;
                cbICpMsElements.Items.Clear();
                cbICpMsElements.Items.Add("");
            }
            else
                FillCbIcpMS();
        }



        //ICP MS - Macro Lists

        private async void btnMacroListTreatment_Click(object sender, EventArgs e)
        {
            FormIcpMs form = new FormIcpMs();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await SetControlsFlpIcpMsTrue();                              

                flpIcpMs.Controls.Clear();
                ListViewItemCollection items = form.GetListViewItems();
                foreach (ListViewItem item in items)
                {
                    await IcpMsMacroListTreatment(item);                   
                }
            }
            FillCbIcpMS();
        }

        private void FillCbIcpMS()
        {
            cbICpMsElements.Items.Clear();
            List<string> elements = new List<string>();
            if (flpIcpMs.Controls.Count != 0)
            {
                foreach (Panel panel in flpIcpMs.Controls)
                {
                    string element = panel.Controls[1].Text;
                    if (!elements.Contains(element))
                    {
                        elements.Add(element);
                    }
                }
                cbICpMsElements.Items.Add("All");
                foreach (string el in elements)
                {
                    cbICpMsElements.Items.Add(el);
                }
                cbICpMsElements.SelectedItem = cbICpMsElements.Items[0];
            }
        }

        private void cbICpMsElements_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedElement = cbICpMsElements.SelectedItem.ToString();
            EnableAllIcpMsPanels();
            if(selectedElement != "All")
            {
                foreach (Panel panel in flpIcpMs.Controls)
                {
                    if (panel.Controls[1].Text != selectedElement)
                    {
                        panel.Visible = false;
                    }
                }
            }
        }

        private void EnableAllIcpMsPanels()
        {
            foreach (Panel panel in flpIcpMs.Controls)
            {
                panel.Visible = true;
            }
        }

        private async Task IcpMsMacroListTreatment(ListViewItem item)
        {
            IcpMsMacroList icpMsMacroList = new IcpMsMacroList(item.Tag.ToString());
            await icpMsMacroList.CalibrationTreatment(Calibration);
            await icpMsMacroList.SaveTreated();
            await DrawPanelsML(icpMsMacroList);                        
        }

        private async Task DrawPanelsML(IcpMsMacroList treatedList)
        {
            for (int i = 0; i < treatedList.ElementNames.Count; i++)
            {
                List<Point> points = new List<Point>();
                for (int j = 0; j < treatedList.AllPoints.Count; j++)
                {
                    if (j % treatedList.ElementNames.Count == i)
                        points.Add(new Point(treatedList.AllPoints[j].X, treatedList.AllPoints[j].Y));
                }

                FlowLayoutPanel pnl = await CreateFlpMacroList(Path.GetFileName(treatedList.FullPath).Split('.').First(), treatedList.ElementNames[i], points);
                flpIcpMs.Controls.Add(pnl);
            }
        }

        private async Task<FlowLayoutPanel> CreateFlpMacroList(string fileName, string elementName, List<Point> points)
        {
            FlowLayoutPanel flp = await CreateFlp("flpMacroList");

            Label lblFileName = new Label
            {
                Text = fileName.Split('-')[0] + "-" + fileName.Split('-')[1] + "-" + fileName.Split('-')[2] + "-" + fileName.Split('-')[3],
                AutoSize = true
            };
            lblFileName.MouseClick += FlpChild_MouseClick;
            lblFileName.MouseDoubleClick += FlpChild_MouseDoubleClick;

            Label lblElementName = new Label
            {
                Text = elementName,
                AutoSize = true
            };
            lblElementName.MouseDoubleClick += FlpChild_MouseDoubleClick;

            List<ObservablePoint> observablePoints = new List<ObservablePoint>();
            points.ForEach(p => observablePoints.Add(new ObservablePoint(p.X, p.Y)));

            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart
            {
                Series = new SeriesCollection {
                new LiveCharts.Wpf.LineSeries{
                    Title = lblFileName.Text + " " + elementName,
                    Values = observablePoints.AsChartValues(),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometry = null
                }
            }
            };
            AxesCollection axesX = new AxesCollection
            {
                new Axis
                {
                    Title = "Time in seconds",
                    Foreground = System.Windows.Media.Brushes.Black
                }
            };

            AxesCollection axesY = new AxesCollection
            {
                new Axis
                {
                    Title = fileName.Split('-').Length == 5 && fileName.Split('-')[4].Contains("Final") ? "ng cm^-2 s^-1" : "Counts",
                    Foreground = System.Windows.Media.Brushes.Black
                }
            };

            chart.AxisX = axesX;
            chart.AxisY = axesY;
            chart.BackColor = Color.Black;
            //performance opt
            chart.DisableAnimations = true;
            chart.Hoverable = false;
            chart.DataTooltip = null;
            flp.Controls.AddRange(new Control[] { lblFileName, lblElementName, chart });

            return flp;
        }

        private void Flp_MouseClick(object sender, MouseEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;

            if(flp.Parent.Name == "flpIcpMs" || flp.Parent.Name == "flpLoadE" || flp.Parent.Name == "flpLoadJ")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (flp.BackColor == Color.LightGreen)
                    {
                        flp.BackColor = Color.LightGray;
                        if (flp.Parent.Name == "flpLoadE" || flp.Parent.Name == "flpLoadJ")
                        {
                            SelectedIcpMsSfcFlpCharts.Remove(flp);
                            SelectedIcpMsMlFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                            SelectedIcpMsMlFlpCharts.Clear();
                        }
                        else
                        {
                            SelectedIcpMsMlFlpCharts.Remove(flp);
                            SelectedIcpMsSfcFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                            SelectedIcpMsSfcFlpCharts.Clear();                        
                        }
                    }
                    else
                    {
                        flp.BackColor = Color.LightGreen;
                        if (flp.Parent.Name == "flpLoadE" || flp.Parent.Name == "flpLoadJ")
                        {
                            SelectedIcpMsSfcFlpCharts.Add(flp);                      
                            SelectedIcpMsMlFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                            SelectedIcpMsMlFlpCharts.Clear();
                        }
                        else
                        {
                            SelectedIcpMsMlFlpCharts.Add(flp);
                            SelectedIcpMsSfcFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                            SelectedIcpMsSfcFlpCharts.Clear();
                        }
                    }
                }            
            }           
        }

        private void Flp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            FormChart formChart;
            List<LiveCharts.WinForms.CartesianChart> charts = new List<LiveCharts.WinForms.CartesianChart>();

            if (flp.Parent.Name == "flpIcpMs")
            {
                if (SelectedIcpMsMlFlpCharts.Count != 0)
                {
                    if (!SelectedIcpMsMlFlpCharts.Contains(flp))
                        SelectedIcpMsMlFlpCharts.Add(flp);
                    SelectedIcpMsMlFlpCharts.ForEach(p => charts.Add((LiveCharts.WinForms.CartesianChart)p.Controls[2]));
                }                   
                else
                    charts.Add((LiveCharts.WinForms.CartesianChart)flp.Controls[2]);

                SelectedIcpMsMlFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                SelectedIcpMsMlFlpCharts.Clear();
            }
            else if(flp.Parent.Name == "flpLoadE" || flp.Parent.Name == "flpLoadJ")
            {
                if (SelectedIcpMsSfcFlpCharts.Count != 0)
                {
                    if (!SelectedIcpMsSfcFlpCharts.Contains(flp))
                        SelectedIcpMsSfcFlpCharts.Add(flp);
                    SelectedIcpMsSfcFlpCharts.ForEach(p => charts.Add((LiveCharts.WinForms.CartesianChart)p.Controls[2]));
                }
                else
                    charts.Add((LiveCharts.WinForms.CartesianChart)flp.Controls[2]);

                SelectedIcpMsSfcFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
                SelectedIcpMsSfcFlpCharts.Clear();
            }
            else if (flp.Parent.Name == "flpCalibration")
            {
                charts.Add((LiveCharts.WinForms.CartesianChart)flp.Controls[3]);
            }

            formChart = new FormChart(charts);
            formChart.Show();

            SelectedIcpMsMlFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
            SelectedIcpMsMlFlpCharts.Clear();
            SelectedIcpMsSfcFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
            SelectedIcpMsSfcFlpCharts.Clear();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings form = new FormSettings();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Helpers.InitAppFolder();
            }               
        }      

        private async void btnLoadTreatedML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Helpers.AppFolderPath,
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    await LoadTreatedML(file);                   
                }
                await SetControlsFlpIcpMsTrue();
            }
            FillCbIcpMS();
        }

        private async Task LoadTreatedML(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string dir = Path.GetDirectoryName(filePath).Split('\\').Last();

            if (fileName.ToLower().Contains("-treated.xl") && dir == Helpers.ICP_MS_FIRST_DIR)
            {
                IcpMsMacroList treatedList = new IcpMsMacroList(filePath);
                await DrawPanelsML(treatedList);                                         
            }
        }

        private async void btnDeleteTreatedMacroLists_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure u want to delete Macro Lists?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await SetControlsFlpIcpMsFalse();
            }
            if (flpIcpMs.Controls.Count == 0)
            {
                cbICpMsElements.Text = string.Empty;
                cbICpMsElements.Items.Clear();
                cbICpMsElements.Items.Add("");
            }                
            else
                FillCbIcpMS();
        }

        private void flpIcpMs_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedIcpMsMlFlpCharts.ForEach(g => g.BackColor = Color.LightGray);
            SelectedIcpMsMlFlpCharts.Clear();
        }

        //SFC

        private void btnAddSingleFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetFileName(openFileDialog.FileName).Contains("ML"))
                    foreach (var file in openFileDialog.FileNames)
                    {
                        lvSingleFiles.Items.Add(CreateFileLvItem(file));                      
                    }                 
            }
        }

        private ListViewItem CreateFileLvItem(string filePath)
        {
            ListViewItem item = new ListViewItem
            {
                Text = Path.GetFileName(filePath),
                Tag = filePath,
            };

            return item;
        }

        private void btnDeleteSelectedSingleFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSingleFiles.SelectedItems)
            {
                lvSingleFiles.Items.Remove(item);
            }
        }

        private async void lvSingleFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSingleFiles.SelectedItems.Count > 1)
            {
                MessageBox.Show(this, "Please select only one item!", "Message", MessageBoxButtons.OK);
                return;
            }

            ListViewItem item = lvSingleFiles.SelectedItems[0];
            item.BackColor = Color.LightSkyBlue;

            bool removedPlot = false;
            IPlottable plot = null;
            foreach (TabPage page in tabControlSfc.TabPages)
            {
                Panel pnl = (Panel)page.Controls[0];
                if (pnl.Controls.Count == 0) //Dok neam V vs I
                    break;

                FormsPlot formsPlot = (FormsPlot)pnl.Controls[0];
                foreach (IPlottable pl in formsPlot.plt.GetPlottables())
                {
                    string label = pl.ToString().Split('(')[1].Split(')')[0];
                    if (label == item.Text)
                    {
                        plot = pl;
                        item.BackColor = Color.White;
                        break;
                    }
                }

                if(plot != null)
                {
                    formsPlot.plt.Remove(plot);
                    formsPlot.plt.AxisAuto();                   
                    page.Controls.Clear();
                    formsPlot.Refresh();
                    pnl.Controls.Add(formsPlot);
                    page.Controls.Add(pnl);
                    removedPlot = true;
                }
                if (formsPlot.plt.GetPlottables().Length == 0)
                {
                    btnClearAllCharts.PerformClick();
                }               
            }

            if (removedPlot)
                return;

            
            try
            {
                SfcGamry sfcGamry = null;
                SfcBioLogic sfcBioLogic = null;

                //disgusting solution, fix this
                if (item.Tag.ToString().ToLower().Contains("merged") 
                    || item.Tag.ToString().ToLower().Contains("_cyc0")
                    || item.Tag.ToString().ToLower().Contains("_cyc1")
                    || item.Tag.ToString().ToLower().Contains("_cyc2")
                    || item.Tag.ToString().ToLower().Contains("_cyc3")
                    || item.Tag.ToString().ToLower().Contains("_cyc4")
                    || item.Tag.ToString().ToLower().Contains("_cyc5")
                    || item.Tag.ToString().ToLower().Contains("_cyc6")
                    || item.Tag.ToString().ToLower().Contains("_cyc7")
                    || item.Tag.ToString().ToLower().Contains("_cyc8")
                    || item.Tag.ToString().ToLower().Contains("_cyc9"))
                {
                    sfcGamry = new SfcGamry(item.Tag.ToString());
                    await AddToChartIvsT(sfcGamry.TimeInSec, sfcGamry.Im, item.Text);
                    await AddToChartVvsT(sfcGamry.TimeInSec, sfcGamry.Vf, item.Text);
                    await AddToChartIvsV(sfcGamry.Vf, sfcGamry.Im, item.Text);
                }
                else
                {
                    sfcBioLogic = new SfcBioLogic(item.Tag.ToString());
                    await AddToChartIvsT(sfcBioLogic.TimeInSec, sfcBioLogic.I, item.Text);
                    await AddToChartVvsT(sfcBioLogic.TimeInSec, sfcBioLogic.Ewe, item.Text);
                    await AddToChartIvsV(sfcBioLogic.Ewe, sfcBioLogic.I, item.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private async Task AddToChartIvsT(List<double> xs, List<double> ys, string name)
        {
            if (pnlSfcIvsT.Controls.Count != 0)
            {
                FormsPlot formsPlot = (FormsPlot)pnlSfcIvsT.Controls[0];
                formsPlot.plt.PlotSignalXYConst(xs.ToArray(), ys.ToArray()).Label = name;
                formsPlot.plt.Legend(location: Alignment.UpperRight);
                formsPlot.plt.AxisAuto();
                formsPlot.Refresh();
                pnlSfcIvsT.Controls.Clear();
                pnlSfcIvsT.Controls.Add(formsPlot);
            }
            else
            {
                pnlSfcIvsT.Controls.Add(CreateSingleFilesChart(xs, ys, name));
            }
        }

        private async Task AddToChartVvsT(List<double> xs, List<double> ys, string name)
        {
            if (pnlSfcVvsT.Controls.Count != 0)
            {
                FormsPlot formsPlot = (FormsPlot)pnlSfcVvsT.Controls[0];
                formsPlot.plt.PlotSignalXYConst(xs.ToArray(), ys.ToArray()).Label = name;
                formsPlot.plt.Legend(location: Alignment.UpperRight);
                formsPlot.plt.AxisAuto();
                formsPlot.Refresh();
                pnlSfcVvsT.Controls.Clear();
                pnlSfcVvsT.Controls.Add(formsPlot);
            }
            else
            {
                pnlSfcVvsT.Controls.Add(CreateSingleFilesChart(xs, ys, name));
            }
        }
        
        private async Task AddToChartIvsV(List<double> xs, List<double> ys, string name)
        {   
            if (pnlSfcIvsV.Controls.Count != 0)
            {
                FormsPlot formsPlot = (FormsPlot)pnlSfcIvsV.Controls[0];
                formsPlot.plt.PlotScatter(xs.ToArray(), ys.ToArray()).Label = name;
                formsPlot.plt.Legend(location: Alignment.UpperRight);
                formsPlot.plt.AxisAuto();
                formsPlot.Refresh();
                pnlSfcIvsV.Controls.Clear();
                pnlSfcIvsV.Controls.Add(formsPlot);
            }
            else
            {
                FormsPlot formsPlot = new FormsPlot();

                formsPlot.plt.PlotScatter(xs.ToArray(), ys.ToArray()).Label = name;
                formsPlot.plt.Legend(location: Alignment.UpperRight);
                formsPlot.Dock = DockStyle.Fill;
                formsPlot.Refresh();

                pnlSfcIvsV.Controls.Add(formsPlot);
            }
        }
        
        FormsPlot CreateSingleFilesChart(List<double> xs,List<double> ys,string name)
        { 
            FormsPlot formsPlot = new FormsPlot();

            formsPlot.plt.PlotSignalXYConst(xs.ToArray(), ys.ToArray()).Label = name;
            formsPlot.plt.Legend(location: Alignment.UpperRight);
            formsPlot.Refresh();

            formsPlot.Dock = DockStyle.Fill;

            return formsPlot;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            FormChoosePotentiostat formChoosePotentiostat = new FormChoosePotentiostat();
            formChoosePotentiostat.ShowDialog();
        }     

        private void btnRemoveLastChart_Click(object sender, EventArgs e)
        {
            lvSingleFiles.Clear();
            ClearAllCharts();
        }

        private void btnClearAllCharts_Click(object sender, EventArgs e)
        {
            ClearAllCharts();
        }

        private void ClearAllCharts()
        {
            pnlSfcIvsT.Controls.Clear();
            pnlSfcVvsT.Controls.Clear();
            pnlSfcIvsV.Controls.Clear();

            foreach (ListViewItem item in lvSingleFiles.Items)
            {
                item.BackColor = Color.White;
            }
        }

        private void lvSingleFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvSingleFiles_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;

            if (data.ContainsFileDropList())
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null)
                {
                    foreach (string filePath in filePaths)
                    {
                        if(filePath.Contains("ML"))
                        {
                            lvSingleFiles.Items.Add(CreateFileLvItem(filePath));
                        }                          
                    }
                }
            }
        }

        //SFC - ICP - MS
        private void lvIcpMs_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvIcpMs_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;

            if (Calibration == null)
            {
                MessageBox.Show("Calibration missing!", "Error", MessageBoxButtons.OK);
                return;
            }

            if (data.ContainsFileDropList())
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null)
                {
                    foreach (string filePath in filePaths)
                    {
                        string date = Path.GetFileName(filePath).Split('-')[0] + "_" + Path.GetFileName(filePath).Split('-')[1] + "_" + Path.GetFileName(filePath).Split('-')[2];
                        if (filePath.Contains("ML") &&
                            Path.GetFileName(filePath).ToLower().Contains("treated") && 
                            date == Calibration.CalibrationDate)
                        {
                            lvIcpMs.Items.Add(CreateFileLvItem(filePath));
                        }
                    }
                }
            }
            RemoveUnpairedMl();
        }

        private void lvSfc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvSfc_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;

            if (Calibration == null)
            {
                MessageBox.Show("Calibration missing!", "Error", MessageBoxButtons.OK);
                return;
            }

            if (data.ContainsFileDropList())
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null)
                {

                    foreach (string filePath in filePaths)
                    {
                        string date = Path.GetFileName(filePath).Split('_')[0] + "_" + Path.GetFileName(filePath).Split('_')[1] + "_" + Path.GetFileName(filePath).Split('_')[2];
                        if (filePath.Contains("ML") &&
                            Path.GetFileName(filePath).ToLower().Contains("mergedfile") && 
                            date == Calibration.CalibrationDate)
                        {
                            lvSfc.Items.Add(CreateFileLvItem(filePath));
                        }
                    }
                }
            }
            RemoveUnpairedMl();
        }

        private void RemoveUnpairedMl()
        {
            if (lvSfc.Items.Count == 0 || lvIcpMs.Items.Count == 0)
            {
                btnFindPeaks.Visible = false;
                btnTreatment.Visible = false;
                txtBoxDelay.Enabled = false;
                txtBoxSurface.Enabled = false;
                cbSurfaceFinalTreatment.Visible = false;
                ClearDelayAndSurfaceArea();
            }

            //find pairs, clear lists and add them again
            if (lvIcpMs.Items.Count != 0 && lvSfc.Items.Count != 0)
            {
                EnableDelaySurfaceTextBoxes();
                List<string> pathsIcpMs = new List<string>();
                List<string> pathsSfc = new List<string>();
                foreach (ListViewItem icpMsItem in lvIcpMs.Items)
                {
                    string icpMsMl = icpMsItem.Text.Split('-')[3];
                    foreach (ListViewItem sfcItem in lvSfc.Items)
                    {
                        string sfcMl = sfcItem.Text.Split('_')[3];
                        if(icpMsMl == sfcMl)
                        {
                            pathsIcpMs.Add(icpMsItem.Tag.ToString());
                            pathsSfc.Add(sfcItem.Tag.ToString());
                            break;
                        }
                    }
                }

                lvIcpMs.Items.Clear();
                lvSfc.Items.Clear();
                txtBoxDelayML.Clear();
                txtBoxSurfaceML.Clear();
                foreach (var item in pathsIcpMs)
                {
                    lvIcpMs.Items.Add(CreateFileLvItem(item));                   
                }
                foreach (var item in pathsSfc)
                {
                    lvSfc.Items.Add(CreateFileLvItem(item));
                }

                StringBuilder sb = new StringBuilder();
                foreach(var item in pathsIcpMs)
                {
                    string ml = Path.GetFileName(item).Split('-')[3] + ":";

                    sb.AppendLine(ml);
                }

                txtBoxDelayML.Text = sb.ToString();
                txtBoxSurfaceML.Text = sb.ToString();
                //btnFindPeaks.Visible = true;
                btnTreatment.Visible = true;
            }
        }

        private void ClearDelayAndSurfaceArea()
        {
            txtBoxConstantSurface.Clear();
            txtBoxDelay.Clear();
            txtBoxDelayML.Clear();
            txtBoxSurface.Clear();
            txtBoxSurfaceML.Clear();
        }

        private void btnFindPeaks_Click(object sender, EventArgs e)
        {
            txtBoxDelay.Clear();

            for (int i = 0; i < lvIcpMs.Items.Count; i++)
            {
                //CalculatePeaks(lvIcpMs.Items[i].Tag.ToString(), lvSfc.Items[i].Tag.ToString());
            }
        }

        private void EnableDelaySurfaceTextBoxes()
        {
            txtBoxSurface.Enabled = true;
            cbSurfaceFinalTreatment.Visible = true;
            txtBoxDelay.Enabled = true;
        }

        private void btnClearDelay_Click(object sender, EventArgs e)
        {
            txtBoxDelay.Clear();
        }

        private void btnClearSurface_Click(object sender, EventArgs e)
        {
            txtBoxSurface.Clear();
        }

        private void cbSurface_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSurfaceFinalTreatment.Checked == false)
            {
                txtBoxConstantSurface.Visible = false;
                txtBoxConstantSurface.Text = "";
                lblConstSurface.Visible = false;
                if (lvIcpMs.Items.Count != 0 && lvSfc.Items.Count != 0)
                    txtBoxSurface.Enabled = true;
            }
            else
            {
                txtBoxConstantSurface.Visible = true;
                txtBoxSurface.Clear();
                txtBoxSurface.Enabled = false;
                lblConstSurface.Visible = true;
            }
        }

        private async void btnTreatment_Click(object sender, EventArgs e)
        {
            if (Calibration != null)
            {
                if (txtBoxDelay.Text.Trim() != "" && txtBoxPh.Text != "" && txtBoxM1.Text != "" && txtBoxM2.Text != "" && txtBoxTime.Text != "" && (txtBoxSurface.Text.Trim() != "" || txtBoxConstantSurface.Text != ""))
                {
                    double shift = Utils.Helpers.ParseStrToDouble(txtBoxPh.Text) * 0.0591 + 0.21;
                    double massDiff = (Utils.Helpers.ParseStrToDouble(txtBoxM1.Text) - Utils.Helpers.ParseStrToDouble(txtBoxM2.Text)) * 1000;
                    double time = Utils.Helpers.ParseStrToDouble(txtBoxTime.Text) / 60;
                    double flowrate = massDiff / time;

                    await SetControlsIcpMsSfcTrue(flowrate, shift);

                    foreach (ListViewItem itemSfc in lvSfc.Items)
                    {
                        string dateSfc = itemSfc.Text.Substring(0, 10);
                        dateSfc = dateSfc.Split('_')[0] + "-" + dateSfc.Split('_')[1] + "-" + dateSfc.Split('_')[2];
                        string mlSfc = itemSfc.Text.Substring(11, 4);

                        foreach (ListViewItem itemIcpMs in lvIcpMs.Items)
                        {
                            string dateIcpMs = itemIcpMs.Text.Substring(0, 10);
                            string mlIcpMs = itemIcpMs.Text.Substring(11, 4);

                            if (dateSfc == dateIcpMs && mlSfc == mlIcpMs)
                            {
                                IcpMsSfc = new IcpMsSfc(new IcpMsMacroList(itemIcpMs.Tag.ToString()), new SfcMergedFile(itemSfc.Tag.ToString()));
                                double delay = Helpers.ParseStrToDouble(txtBoxDelay.Lines[0].Substring(0));
                                double surface = 0;

                                if (cbSurfaceFinalTreatment.Checked)
                                    surface = Helpers.ParseStrToDouble(txtBoxConstantSurface.Text);
                                else
                                    surface = Helpers.ParseStrToDouble(txtBoxSurface.Lines[0].Substring(0));

                                await FinalTreatment(delay, surface);

                                lvSfc.Items.Remove(itemSfc);
                                lvIcpMs.Items.Remove(itemIcpMs);

                                RemoveTextBoxLinesFinalTreatment(txtBoxDelayML.Name);
                                RemoveTextBoxLinesFinalTreatment(txtBoxDelay.Name);
                                RemoveTextBoxLinesFinalTreatment(txtBoxSurfaceML.Name);
                               
                                if(!cbSurfaceFinalTreatment.Checked)
                                    RemoveTextBoxLinesFinalTreatment(txtBoxSurface.Name);
                                lblLastTreatedML.Text = "Last treated Macro List: " + mlIcpMs;
                                lblLastTreatedML.Visible = true;

                                if (lvSfc.Items.Count == 0)
                                    MessageBox.Show("Treatment successful!", "Message", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Missing data!\nCant continue with final treatment", "Message", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(this, "Missing calibration!", "Message", MessageBoxButtons.OK);
            }
        }

        private void RemoveTextBoxLinesFinalTreatment(string txtBoxName)
        {
            foreach (Control ctrl in tabContainer.TabPages[4].Controls)
            {
                if(ctrl.Name == txtBoxName)
                {
                    var lines = (ctrl as TextBox).Lines.ToList();
                    lines.RemoveAt(0);
                    (ctrl as TextBox).Clear();
                    (ctrl as TextBox).Lines = lines.ToArray();
                }
            }
            if(lvIcpMs.Items.Count == 0 && lvSfc.Items.Count == 0)
            {
                btnFindPeaks.Visible = false;
                btnTreatment.Visible = false;
            }
        }

        private async Task FinalTreatment(double delay, double surface)
        {
            flpIcpMsSfcE.Controls.Clear();
            flpIcpMsSfcJ.Controls.Clear();

            try
            {
                await IcpMsSfc.SfcMergedTreated.Treatment(Helpers.ParseStrToDouble(lblShift.Text), surface);
                await IcpMsSfc.IcpMsMLTreated.FinalTreatment(delay, Helpers.ParseStrToDouble(lblFlowrateSec.Text), surface);
                await IcpMsSfc.SaveFiles(lblFlowrateSec.Text, lblShift.Text, surface.ToString(), delay.ToString());
            }
            catch 
            {
                MessageBox.Show("Treatment error!", "Error", MessageBoxButtons.OK);
            }               
        }          

        //ICP-MS-SFC Charts
        private async Task SetControlsIcpMsSfcTrue(double flowrate, double shift)
        {
            labelFlowrateMin.Visible = true;
            lblFlowrateMin.Visible = true;
            lblFlowrateMin.Text = flowrate.ToString(CultureInfo.InvariantCulture);

            labelFlowrateSec.Visible = true;
            lblFlowrateSec.Visible = true;
            lblFlowrateSec.Text = (flowrate / 60).ToString(CultureInfo.InvariantCulture);

            labelShift.Visible = true;
            lblShift.Visible = true;
            lblShift.Text = shift.ToString(CultureInfo.InvariantCulture);
        }

        private void Pnl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            LiveCharts.WinForms.CartesianChart chart = (LiveCharts.WinForms.CartesianChart)flp.Controls[1];

            FormChart form = new FormChart(new List<LiveCharts.WinForms.CartesianChart> { chart });
            form.Show();
        }

        private void btnClearIcpMsSfc_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            foreach (ListView lv in tpSfcIcpMs.Controls.OfType<ListView>())
            {
                if (lv.Name == button.Tag.ToString() && lv.SelectedItems.Count != 0)
                {
                    foreach (ListViewItem item in lv.SelectedItems)
                    {
                        lv.Items.Remove(item);
                    }
                }else if(lv.Name == button.Tag.ToString())
                {
                    lv.Items.Clear();
                }
            }

            RemoveUnpairedMl();
            IcpMsSfc = null;
        }

        private async void btnLoadSingleFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Helpers.AppFolderPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Path.GetFileName(openFileDialog.FileName).ToLower().Contains("finaltreatment-"))
                    {
                        IcpMsMacroList icpMsMacroList = new IcpMsMacroList(openFileDialog.FileName);

                        await AddLoadPanelsIcpMs(icpMsMacroList);
                    }
                    if (Path.GetFileName(openFileDialog.FileName).ToLower().Contains("mergedfile-treated"))
                    {
                        SfcMergedFile mergedFile = new SfcMergedFile(openFileDialog.FileName);

                        await AddLoadPanelsSfc(mergedFile, Path.GetFileName(openFileDialog.FileName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private async Task AddLoadPanelsIcpMs(IcpMsMacroList icpMsMacroList)
        {
            FlowLayoutPanel flpE = await CreateFlpMacroList(Path.GetFileName(icpMsMacroList.FullPath), icpMsMacroList.ElementNames[0], icpMsMacroList.AllPoints);
            FlowLayoutPanel flpJ = await CreateFlpMacroList(Path.GetFileName(icpMsMacroList.FullPath), icpMsMacroList.ElementNames[0], icpMsMacroList.AllPoints);

            flpLoadE.Controls.Add(flpE);
            flpLoadJ.Controls.Add(flpJ);
        }

        private async Task AddLoadPanelsSfc(SfcMergedFile mergedFile, string fileName)
        {          
            List<Point> allPointsE = new List<Point>();
            List<Point> allPointsJ = new List<Point>();

            for (int i = 0; i < mergedFile.TimeInSec.Count; i++)
            {
                allPointsE.Add(new Point(mergedFile.TimeInSec[i], mergedFile.Vf[i]));
                allPointsJ.Add(new Point(mergedFile.TimeInSec[i], mergedFile.Im[i]));
            }

            FlowLayoutPanel flpE = await CreateFlpSfc(fileName, 'V', allPointsE);          
            FlowLayoutPanel flpJ = await CreateFlpSfc(fileName, 'J', allPointsJ);

            flpLoadE.Controls.Add(flpE);
            flpLoadJ.Controls.Add(flpJ);
        }

        private async Task<FlowLayoutPanel> CreateFlpSfc(string fileName, char marker, List<Point> points)
        {
            FlowLayoutPanel flp = await CreateFlp("flpSfc");

            Label lblDate = new Label
            {
                Text = fileName.Split('_')[0] + "_" + fileName.Split('_')[1] + "_" + fileName.Split('_')[2],
                AutoSize = true
            };
            lblDate.MouseClick += FlpChild_MouseClick;
            lblDate.MouseDoubleClick += FlpChild_MouseDoubleClick;

            Label lblMl = new Label
            {
                Text = fileName.Split('_')[3],
                AutoSize = true
            };
            lblMl.MouseClick += FlpChild_MouseClick;
            lblMl.MouseDoubleClick += FlpChild_MouseDoubleClick;

            List<ObservablePoint> observablePoints = new List<ObservablePoint>();
            points.ForEach(p => observablePoints.Add(new ObservablePoint(p.X, p.Y)));

            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart
            {
                Series = new SeriesCollection {
                new LiveCharts.Wpf.LineSeries{
                    Title = fileName.Split('.').First(),
                    Values = observablePoints.AsChartValues(),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometry = null
                    }
                }
            };
            AxesCollection axesX = new AxesCollection
            {
                new Axis
                {
                    Title = "Time in seconds",
                    Foreground = System.Windows.Media.Brushes.Black
                }
            };

            AxesCollection axesY = new AxesCollection
            {
                new Axis
                {
                    Title = marker == 'V' ? "V vs. RHE" : "J vs. RHE",
                    Foreground = System.Windows.Media.Brushes.Black
                }
            };

            chart.AxisX = axesX;
            chart.AxisY = axesY;
            chart.BackColor = Color.Black;
            //performance opt
            chart.DisableAnimations = true;
            chart.Hoverable = false;
            chart.DataTooltip = null;
            flp.Controls.AddRange(new Control[] { lblDate, lblMl, chart });

            return flp;
        }     

        private async void btnLoadIcpMsSf_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Helpers.AppFolderPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetFileName(openFileDialog.FileName).ToLower().Contains("icp-ms_sfc"))
                {
                    List<Point> pointsSfcVf = new List<Point>();
                    List<Point> pointsSfcJ = new List<Point>();
                    List<Point> allPointsIcpMs = new List<Point>();
                    List<string> elements = new List<string>();

                    string path = openFileDialog.FileName;
          
                    using (StreamReader reader = new StreamReader(path))
                    {
                        do
                        {
                            string[] str = reader.ReadLine().Split(',');
                            if (str[0].ToLower().Contains("timesfc") && str[1].ToLower().Contains("vf"))
                            {
                                for (int i = 4; i < str.Length; i++)
                                {
                                    elements.Add(str[i]);
                                }
                                break;
                            }
                        } while (!reader.EndOfStream);

                        while (!reader.EndOfStream)
                        {
                            string[] line = reader.ReadLine().Split(',');
                            pointsSfcVf.Add(new Point(Helpers.ParseStrToDouble(line[0]), Helpers.ParseStrToDouble(line[1])));
                            pointsSfcJ.Add(new Point(Helpers.ParseStrToDouble(line[0]), Helpers.ParseStrToDouble(line[2])));

                            if(line.Length > 3)
                            {
                                for (int i = 4; i < line.Length; i++)
                                {
                                    allPointsIcpMs.Add(new Point(Helpers.ParseStrToDouble(line[3]), Helpers.ParseStrToDouble(line[i])));
                                }
                            }                          
                        }
                    }

                    await CreateAllTogetherChart(pointsSfcVf, allPointsIcpMs, elements, 'V');
                    await CreateAllTogetherChart(pointsSfcJ, allPointsIcpMs, elements, 'J');
                }
            }
        }

        private async Task CreateAllTogetherChart(List<Point> pointsSfc, List<Point> allPointsIcpMs, List<string> elements, char sfcValue)
        {
            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart();
            List<ObservablePoint> observablePointsSfc = new List<ObservablePoint>();
            pointsSfc.ForEach(p => observablePointsSfc.Add(new ObservablePoint(p.X, p.Y)));

            chart.Series.Add(new LineSeries
            {
                Values = observablePointsSfc.AsGearedValues().WithQuality(Quality.Highest),
                Title = sfcValue == 'V' ? "Potential" : "Current",
                PointGeometry = null,
                Fill = System.Windows.Media.Brushes.Transparent
            });

            for (int i = 0; i < elements.Count; i++)
            {
                List<Point> pointsIcpMs = new List<Point>();
                for(int j = i; j < allPointsIcpMs.Count; j+=elements.Count)
                {
                    pointsIcpMs.Add(allPointsIcpMs[j]);
                }
                List<ObservablePoint> observablePointsIcpMs = new List<ObservablePoint>();
                pointsIcpMs.ForEach(p => observablePointsIcpMs.Add(new ObservablePoint(p.X, p.Y)));
                chart.Series.Add(new LineSeries
                {
                    Values = observablePointsIcpMs.AsGearedValues().WithQuality(Quality.Highest),                   
                    Title = elements[i],
                    PointGeometry = null,
                    Fill = System.Windows.Media.Brushes.Transparent
                });
            }

            chart.AxisX = new LiveCharts.Wpf.AxesCollection {
                {
                    new Axis
                    {
                        Title = "Time in Seconds"
                    }
                }
                };
            AxesCollection axesY = new AxesCollection();
            Axis axisYRight = new Axis
            {
                Title = sfcValue + " vs. RHE",
                Position = AxisPosition.RightTop
            };
            axesY.Add(axisYRight);

            Axis axisYLeft = new Axis
            {
                Title = "ng cm^-2 s^-1",
                Position = AxisPosition.LeftBottom
            };
            axesY.Add(axisYLeft);
            chart.Name = "IcpMsSfc";
            chart.AxisY = axesY;
            chart.Hoverable = false;
            chart.DataTooltip = null;
            chart.BackColor = Color.Black;

            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Width = FLP_ML_W,
                Height = FLP_ML_H,
                BackColor = Color.LightGray
            };

            Label lblElement = new Label();
            elements.ForEach(e => lblElement.Text += e + " ");
            lblElement.AutoSize = true;

            flp.ContextMenuStrip = cmsFlpChart;
            flp.Controls.AddRange(new Control[] { lblElement, chart });
            flp.MouseDoubleClick += Pnl_MouseDoubleClick;

            if (sfcValue == 'V')
                flpIcpMsSfcE.Controls.Add(flp);
            else
                flpIcpMsSfcJ.Controls.Add(flp);
        }

        private void bntClearIcpMsSfcCharts_Click(object sender, EventArgs e)
        {
            flpIcpMsSfcE.Controls.Clear();
            flpLoadE.Controls.Clear();
            flpIcpMsSfcJ.Controls.Clear();
            flpLoadJ.Controls.Clear();
        }

        //SFC Normalization

        private void lvSfcNormalization_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvSfcNormalization_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;

            if (data.ContainsFileDropList())
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null)
                {

                    foreach (string filePath in filePaths)
                    {
                        if (Path.GetFileName(filePath).Contains("ML"))
                        {
                            lvSfcNormalization.Items.Add(CreateFileLvItem(filePath));
                        }
                    }
                }
            }
            if (lvSfcNormalization.Items.Count != 0)
            {
                ShowNormalizationControls();
                AddSfcNormalizationTxtBoxML();
            }             
        }

        private void AddSfcNormalizationTxtBoxML()
        {
            txtBoxSurfaceNormML.Clear();
            txtBoxMassNormML.Clear();

            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem item in lvSfcNormalization.Items)
            {
                string[] splitText = item.Text.Split('.');
                sb.Append(splitText[0] + Environment.NewLine);            
            }

            txtBoxSurfaceNormML.Text = sb.ToString();
            txtBoxMassNormML.Text = sb.ToString();
        }

        private void ShowNormalizationControls()
        {
            cbConstantMass.Visible = true;
            cbConstantSurface.Visible = true;
            txtBoxMassNormalization.Enabled = true;
            txtBoxSurfaceNormalization.Enabled = true;
            lblPhNorm.Visible = true;
            txtBoxPhNormalization.Visible = true;
            btnNormalization.Visible = true;
        }

        private void cbConstantMass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConstantMass.Checked == false)
            {
                txtBoxConstantMassNorm.Visible = false;
                txtBoxConstantMassNorm.Text = "";
                lblConstMassNorm.Visible = false;
                if (lvSfcNormalization.Items.Count != 0)
                    txtBoxMassNormalization.Enabled = true;
            }
            else
            {
                txtBoxConstantMassNorm.Visible = true;
                txtBoxMassNormalization.Clear();
                txtBoxMassNormalization.Enabled = false;
                lblConstMassNorm.Visible = true;
            }
        }

        private void cbConstantSurface_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConstantSurface.Checked == false)
            {
                txtBoxConstantSurfaceNorm.Visible = false;
                txtBoxConstantSurfaceNorm.Text = "";
                lblConstSurfaceNorm.Visible = false;
                if (lvSfcNormalization.Items.Count != 0)
                    txtBoxSurfaceNormalization.Enabled = true;
            }
            else
            {
                txtBoxConstantSurfaceNorm.Visible = true;
                txtBoxSurfaceNormalization.Clear();
                txtBoxSurfaceNormalization.Enabled = false;
                lblConstSurfaceNorm.Visible = true;
            }
        }

        private async void btnNormalization_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSfcNormalization.Items)
            {
                string mass = "";
                string surface = "";               

                if (cbConstantMass.Checked)
                    mass = txtBoxConstantMassNorm.Text;
                else if(txtBoxMassNormalization.Lines.Length != 0)
                    mass = txtBoxMassNormalization.Lines[0].Substring(0);

                if (cbConstantSurface.Checked)
                    surface = txtBoxConstantSurfaceNorm.Text;
                else if(txtBoxSurfaceNormalization.Lines.Length != 0)
                    surface = txtBoxSurfaceNormalization.Lines[0].Substring(0);

                if (string.IsNullOrEmpty(txtBoxPhNormalization.Text))
                    return;

                if (string.IsNullOrEmpty(mass) && string.IsNullOrEmpty(surface))
                    return;

                double shift = Utils.Helpers.ParseStrToDouble(txtBoxPhNormalization.Text) * 0.0591 + 0.21;

                try
                {
                    SfcFile file = null;

                    //disgusting solution, fix this!
                    if (item.Tag.ToString().Contains("merged") 
                        || item.Tag.ToString().Contains("_Cyc0")
                        || item.Tag.ToString().Contains("_Cyc1")
                        || item.Tag.ToString().Contains("_Cyc2")
                        || item.Tag.ToString().Contains("_Cyc3")
                        || item.Tag.ToString().Contains("_Cyc4")
                        || item.Tag.ToString().Contains("_Cyc5")
                        || item.Tag.ToString().Contains("_Cyc6")
                        || item.Tag.ToString().Contains("_Cyc7")
                        || item.Tag.ToString().Contains("_Cyc8")
                        || item.Tag.ToString().Contains("_Cyc9"))
                        file = new SfcGamry(item.Tag.ToString());
                    else
                        file = new SfcBioLogic(item.Tag.ToString());

                    if (!string.IsNullOrEmpty(mass) && string.IsNullOrEmpty(surface)) 
                    {
                        await file.MassNormalization(shift, Helpers.ParseStrToDouble(mass));
                    }
                    else if (string.IsNullOrEmpty(mass) && !string.IsNullOrEmpty(surface))
                    {
                        await file.GeometricNormalization(shift, Helpers.ParseStrToDouble(surface));
                    }
                    else
                    {
                        await file.GeometricNormalization(shift, Helpers.ParseStrToDouble(surface));
                        await file.MassNormalization(shift, Helpers.ParseStrToDouble(mass));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
                    return;
                }

                lvSfcNormalization.Items.Remove(item);

                RemoveTextBoxLinesNormalization(txtBoxMassNormML.Name);
                RemoveTextBoxLinesNormalization(txtBoxSurfaceNormML.Name);

                if (!cbConstantMass.Checked && txtBoxMassNormalization.Lines.Length != 0)
                    RemoveTextBoxLinesNormalization(txtBoxMassNormalization.Name);

                if (!cbConstantSurface.Checked && txtBoxSurfaceNormalization.Lines.Length != 0)
                    RemoveTextBoxLinesNormalization(txtBoxSurfaceNormalization.Name);

                if (lvSfcNormalization.Items.Count == 0)
                {
                    txtBoxConstantMassNorm.Text = "";
                    txtBoxConstantSurfaceNorm.Text = "";
                    txtBoxPhNormalization.Text = "";

                    txtBoxMassNormalization.Enabled = false;
                    txtBoxSurfaceNormalization.Enabled = false;

                    cbConstantMass.Checked = false;
                    cbConstantSurface.Checked = false;
                }
            }
        }

        private void RemoveTextBoxLinesNormalization(string txtBoxName)
        {
            foreach (Control ctrl in tabContainer.TabPages[3].Controls)
            {
                if (ctrl.Name == txtBoxName)
                {
                    var lines = (ctrl as TextBox).Lines.ToList();
                    lines.RemoveAt(0);
                    (ctrl as TextBox).Clear();
                    (ctrl as TextBox).Lines = lines.ToArray();
                }
            }
        }

        private void btnClearSfcNorm_Click(object sender, EventArgs e)
        {
            List<string> normMLs = txtBoxMassNormML.Text.Split('\n').ToList();
            Dictionary<int, string> normMassValues = new Dictionary<int, string>();
            List<string> massVal = txtBoxMassNormalization.Text.Split('\n').ToList();
            
            //Removing last value which is empty str
            normMLs.RemoveAt(normMLs.Count - 1);
            
            for (int i = 0; i < normMLs.Count; i++)
            {
                if(massVal.ElementAtOrDefault(i) == null || massVal.ElementAtOrDefault(i) =="\r")
                    normMassValues[i] = " ";
                else
                    normMassValues[i] = massVal[i];

            }

            Dictionary<int, string> normSurfaceValues = new Dictionary<int, string>();
            List<string> surfaceVal = txtBoxSurfaceNormalization.Text.Split('\n').ToList();
            for (int i = 0; i < normMLs.Count; i++)
            {
                if (surfaceVal.ElementAtOrDefault(i) == null || surfaceVal.ElementAtOrDefault(i) == "\r")
                    normSurfaceValues[i] = " ";
                else
                    normSurfaceValues[i] = surfaceVal[i];
            }


            if (lvSfcNormalization.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in lvSfcNormalization.SelectedItems)
                {
                    int index = item.Index;
                    lvSfcNormalization.Items.Remove(item);
                    normMLs.RemoveAt(index);

                    normMassValues[index]=" ";
                    normSurfaceValues[index]=" ";
                }
            }
            else
            {
                lvSfcNormalization.Items.Clear();
                normMLs.Clear();
                normMassValues.Clear();
                normSurfaceValues.Clear();
            }

            RenderNewMLs(normMLs, normMassValues, normSurfaceValues);         
        }

        private void RenderNewMLs(List<string> normMLs, Dictionary<int, string> normMassValues, Dictionary<int, string> normSurfaceValues)
        {
            if (normMLs.Count == 0)
            {
                txtBoxConstantSurfaceNorm.Clear();
                txtBoxConstantMassNorm.Clear();
                txtBoxSurfaceNormML.Clear();
                txtBoxMassNormML.Clear();
                txtBoxSurfaceNormalization.Clear();
                txtBoxMassNormalization.Clear();
                txtBoxPhNormalization.Clear();

                txtBoxMassNormalization.Enabled = false;
                txtBoxSurfaceNormalization.Enabled = false;
                cbConstantMass.Visible = false;
                cbConstantMass.Checked = false;
                cbConstantSurface.Visible = false;
                cbConstantSurface.Checked = false;
                lblPhNorm.Visible = false;
                txtBoxPhNormalization.Visible = false;
                btnNormalization.Visible = false;
                txtBoxConstantSurfaceNorm.Visible = false;
                lblConstSurfaceNorm.Visible = false;
                txtBoxConstantMassNorm.Visible = false;
                lblConstMassNorm.Visible = false;
            }
            else
            {
                StringBuilder sbML = new StringBuilder();
                StringBuilder sbMassVal = new StringBuilder();
                StringBuilder sbSurfaceVal = new StringBuilder();

                for (int i = 0; i < normMLs.Count; i++)
                {
                    sbML.Append(normMLs[i] + "\n");

                    
                    if(normMassValues.Count != 0)
                        sbMassVal.Append(normMassValues[i] + "\n");
                    if(normSurfaceValues.Count != 0)
                        sbSurfaceVal.Append(normSurfaceValues[i] + "\n");
                    
                }

                txtBoxMassNormML.Text = sbML.ToString();
                txtBoxSurfaceNormML.Text = sbML.ToString();
                txtBoxMassNormalization.Text = sbMassVal.ToString();
                txtBoxSurfaceNormalization.Text = sbSurfaceVal.ToString();
            }
        }

        private void btnClearMassNorm_Click(object sender, EventArgs e)
        {
            txtBoxMassNormalization.Clear();
        }

        private void btnClearSurfaceNorm_Click(object sender, EventArgs e)
        {
            txtBoxSurfaceNormalization.Clear();
        }
    }
}
