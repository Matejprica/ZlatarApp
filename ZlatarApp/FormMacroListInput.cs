using System;
using System.Windows.Forms;

namespace ZlatarApp
{
    public enum PurposeFlagEnum
    {
        Normalization,
        FinalTreatment
    }

    public partial class FormMacroListInput : Form
    {
        public double Shift { get; set; }
        public double Flowrate { get; set; }
        public double Surface { get; set; }

        public FormMacroListInput(string Ml, string ph, string surface, string m1, string m2, string time, PurposeFlagEnum purposeFlag)
        {
            InitializeComponent();

            label1.Text = Ml;
            label1.Visible = true;
            txtBoxPh.Text = ph;
            txtBoxSurface.Text = surface;
            txtBoxM1.Text = m1;
            txtBoxM2.Text = m2;
            txtBoxT.Text = time;

            if (purposeFlag == PurposeFlagEnum.Normalization)
            {
                label5.Visible = false;
                txtBoxM2.Visible = false;
                label6.Visible = false;
                txtBoxT.Visible = false;

                label4.Text = "Mass ( μg ):";

                if (ph != "" && surface != "" && m1 != "")
                {
                    txtBoxM1.Select();
                    txtBoxM1.Text = (double.Parse(m1) * 1000000).ToString();
                }
            }
            else
            {
                if (txtBoxPh.Text != "" && txtBoxSurface.Text != "" && txtBoxM1.Text != "" && txtBoxM2.Text != "" && txtBoxT.Text != "")
                    txtBoxSurface.Select();
                else if (txtBoxPh.Text == "")
                    txtBoxPh.Select();
                else
                    btnOk.Select();
            }
        }

        private void CalculateShift()
        {
            Shift = Utils.Helpers.ParseStrToDouble(txtBoxPh.Text) * 0.0591 + 0.21;           
        }

        private void CalculateFlowrate()
        {
            double massDiff = (Utils.Helpers.ParseStrToDouble(txtBoxM1.Text) - Utils.Helpers.ParseStrToDouble(txtBoxM2.Text)) * 1000;
            double time = Utils.Helpers.ParseStrToDouble(txtBoxT.Text) / 60;

            Flowrate = massDiff / time;
        }

        private void CalculateSurface()
        {
            double value = Utils.Helpers.ParseStrToDouble(txtBoxSurface.Text);
            if (radioButtonRadius.Checked == true)
            {
                Surface = Math.Pow(value * 10000, 2) * Math.PI;
            }
            else
                Surface = value;
        }

        public double GetShift()
        {
            return Shift;
        }

        public double GetSurface()
        {
            return Surface;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CalculateSurface();
            CalculateShift();
            CalculateFlowrate();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMacroListInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();
        }

        internal string GetPh()
        {
            return txtBoxPh.Text;
        }

        internal string GetM1()
        {
            return txtBoxM1.Text;
        }

        internal string GetM2()
        {
            return txtBoxM2.Text;
        }
    }
}
