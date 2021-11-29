using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ZlatarApp
{
    public partial class FormChart : Form
    {
        LiveCharts.WinForms.CartesianChart chart;

        public FormChart(List<LiveCharts.WinForms.CartesianChart> cartesianCharts)
        {
            InitializeComponent();

            this.CenterToScreen();
            if (cartesianCharts[0].Name.ToLower() == "icpmssfc")
            {
                DrawChartIcpMsSfc(cartesianCharts);
            }
            else
            {
                DrawChart(cartesianCharts);
            }
        }

        private void DrawChart(List<LiveCharts.WinForms.CartesianChart> cartesianCharts)
        {
            FormsPlot formsPlot = new FormsPlot();

            foreach (var cartesianChart in cartesianCharts)
            {
                for (int i = 0; i < cartesianChart.Series.Count; i++)
                {
                    LineSeries cartChartLineSeries = new LineSeries();
                    cartChartLineSeries = (LineSeries)cartesianChart.Series[i];

                    var points = cartChartLineSeries.ChartPoints;
                    List<double> xs = new List<double>();
                    List<double> ys = new List<double>();
                    foreach (var point in points)
                    {                        
                        xs.Add(point.X);
                        ys.Add(point.Y);
                    }
                    
                    formsPlot.plt.PlotSignalXYConst(xs.ToArray(), ys.ToArray()).Label = cartChartLineSeries.Title;                   
                    formsPlot.plt.Legend(location: Alignment.UpperRight);
                }
            }

            formsPlot.plt.XLabel(cartesianCharts[0].AxisX[0].Title);
            formsPlot.plt.YLabel(cartesianCharts[0].AxisY[0].Title);
            formsPlot.Refresh();
            formsPlot.Dock = DockStyle.Fill;
            this.Controls.Add(formsPlot);
        }

        private void DrawChartIcpMsSfc(List<LiveCharts.WinForms.CartesianChart> cartesianCharts)
        {
            FormsPlot formsPlot = new FormsPlot();

            foreach (var cartesianChart in cartesianCharts)
            {
                for (int i = 0; i < cartesianChart.Series.Count; i++)
                {
                    //LineSeries cartChartLineSeries = new LineSeries();
                    LineSeries cartChartLineSeries = (LineSeries)cartesianChart.Series[i];

                    var points = cartChartLineSeries.ChartPoints;
                    List<double> xs = new List<double>();
                    List<double> ys = new List<double>();
                    foreach (var point in points)
                    {
                        xs.Add(point.X);
                        ys.Add(point.Y);
                    }

                    if (cartChartLineSeries.Title == "Potential")
                    {
                        formsPlot.plt.YAxis2.Label(cartesianChart.AxisY[1].Title);
                        formsPlot.plt.YAxis2.Ticks(true);
                        formsPlot.plt.AddSignalXYConst(xs.ToArray(), ys.ToArray()).Label=cartChartLineSeries.Title;
                    }
                    else
                    {
                        formsPlot.plt.YAxis.Label(cartesianChart.AxisY[0].Title);
                        formsPlot.plt.YAxis.Ticks(true);
                        formsPlot.plt.AddSignalXYConst(xs.ToArray(), ys.ToArray()).Label=cartChartLineSeries.Title;
                    }
                }
            }
            formsPlot.plt.AxisAuto();
            formsPlot.plt.Legend(location: Alignment.UpperRight);
            formsPlot.plt.XLabel(cartesianCharts[0].AxisX[0].Title);
            formsPlot.Dock = DockStyle.Fill;
            formsPlot.Refresh();
            this.Controls.Add(formsPlot);
        }

        private void printToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += PrintDoc_PrintPage;           
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            e.Graphics.DrawImage(bitmap, e.MarginBounds);
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Bitmap bitmap = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.DefaultExt = ".png";
            saveFileDialog.FileName = "Chart";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }            
        }        
    }
}
