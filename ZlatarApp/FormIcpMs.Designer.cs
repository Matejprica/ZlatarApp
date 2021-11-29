namespace ZlatarApp
{
    partial class FormIcpMs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvMacroList = new System.Windows.Forms.ListView();
            this.btnMlTreatment = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMacroList
            // 
            this.lvMacroList.AllowDrop = true;
            this.lvMacroList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMacroList.HideSelection = false;
            this.lvMacroList.Location = new System.Drawing.Point(12, 12);
            this.lvMacroList.Name = "lvMacroList";
            this.lvMacroList.Size = new System.Drawing.Size(378, 252);
            this.lvMacroList.TabIndex = 10;
            this.lvMacroList.UseCompatibleStateImageBehavior = false;
            this.lvMacroList.View = System.Windows.Forms.View.Details;
            this.lvMacroList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMacroList_DragDrop);
            this.lvMacroList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMacroList_DragEnter);
            // 
            // btnMlTreatment
            // 
            this.btnMlTreatment.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMlTreatment.Location = new System.Drawing.Point(279, 270);
            this.btnMlTreatment.Name = "btnMlTreatment";
            this.btnMlTreatment.Size = new System.Drawing.Size(111, 49);
            this.btnMlTreatment.TabIndex = 11;
            this.btnMlTreatment.Text = "Macro List Treatment";
            this.btnMlTreatment.UseVisualStyleBackColor = true;
            this.btnMlTreatment.Visible = false;
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Location = new System.Drawing.Point(12, 270);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(111, 49);
            this.btnRemoveSelected.TabIndex = 12;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Visible = false;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // FormIcpMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 344);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnMlTreatment);
            this.Controls.Add(this.lvMacroList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormIcpMs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ICP-MS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMacroList;
        private System.Windows.Forms.Button btnMlTreatment;
        private System.Windows.Forms.Button btnRemoveSelected;
    }
}