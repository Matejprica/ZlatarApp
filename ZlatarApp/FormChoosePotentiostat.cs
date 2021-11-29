using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Utils;

namespace ZlatarApp
{
    public partial class FormChoosePotentiostat : Form
    {
        public FormChoosePotentiostat()
        {
            InitializeComponent();
        }

        private void btnGamry_Click(object sender, EventArgs e)
        {
            FormSfc form = new FormSfc();
            form.ShowDialog();
            this.Close();
        }

        private void btnBioLogic_Click(object sender, EventArgs e)
        {
            FormSfcBioLogic form = new FormSfcBioLogic();
            form.ShowDialog();
            this.Close();
        }
    }
}
