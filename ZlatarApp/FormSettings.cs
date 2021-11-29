using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Utils;

namespace ZlatarApp
{
    public partial class FormSettings : Form
    {

        public FormSettings()
        {
            InitializeComponent();

            txtBoxAppFolder.Text = Utils.Helpers.AppFolderPath;
        }    

        private void btnSetAppFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                btnApply.Enabled = true;
                Utils.Helpers.AppFolderPath = folderBrowserDialog.SelectedPath;
                txtBoxAppFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["AppFolderPath"] = txtBoxAppFolder.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show(this, "Settings saved", "Message", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
                throw;
            }           
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetRootFolder()
        {
            return Path.Combine(txtBoxAppFolder.Text);
        }
    }
}
