using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Utils;
using static System.Windows.Forms.ListView;

namespace ZlatarApp
{
    public partial class FormIcpMs : Form
    {
        public FormIcpMs()
        {
            InitializeComponent();
        }

        private void lvMacroList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvMacroList_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;

            if (lvMacroList.Columns.Count != 1)
            {
                ColumnHeader header = new ColumnHeader();
                header.Text = "Macro lists:";
                header.Width = lvMacroList.Width - 5;

                lvMacroList.Columns.Add(header);
            }

            if (data.ContainsFileDropList())
            {
                string[] allFiles = (string[])e.Data.GetData(DataFormats.FileDrop);               

                if (allFiles != null)
                {
                    btnMlTreatment.Visible = true;
                    btnRemoveSelected.Visible = true;
                    List<string> macroLists = FilterMacroLists(allFiles);

                    foreach (string filePath in macroLists)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Name = Path.GetFileName(filePath); //Contains Key method needs Name for key
                        item.Text = Path.GetFileName(filePath);
                        item.Tag = filePath;

                        if (lvMacroList.Items.ContainsKey(item.Name))
                            continue;
                        else
                            lvMacroList.Items.Add(item);
                    }                    
                }
            }
        }

        private List<string> FilterMacroLists(string[] allFiles)
        {
            List<string> macroLists = new List<string>();

            foreach (string filePath in allFiles)
            {
                if (Path.GetFileName(filePath).ToLower().Contains("-ml") && Path.GetExtension(filePath) == ".xl")
                {
                    macroLists.Add(filePath);
                }
            }

            return macroLists.OrderBy(ml => int.Parse(Path.GetFileName(ml).Split('L').Last().Split('.').First())).ToList();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMacroList.SelectedItems)
            {
                lvMacroList.Items.Remove(item);
            }

            if(lvMacroList.Items.Count == 0)
            {
                btnRemoveSelected.Visible = false;
                btnMlTreatment.Visible = false;
                lvMacroList.Columns.Clear();
            }
        }

        internal ListViewItemCollection GetListViewItems()
        {
            return lvMacroList.Items;
        }
    }
}
