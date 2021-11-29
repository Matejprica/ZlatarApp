namespace ZlatarApp.Utils
{
    partial class FormSfc
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
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lvFolderContent = new System.Windows.Forms.ListView();
            this.txtBoxFolderPath = new System.Windows.Forms.TextBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBoxMachineDelay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(59, 38);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lvFolderContent
            // 
            this.lvFolderContent.AllowDrop = true;
            this.lvFolderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFolderContent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFolderContent.HideSelection = false;
            this.lvFolderContent.Location = new System.Drawing.Point(12, 56);
            this.lvFolderContent.MultiSelect = false;
            this.lvFolderContent.Name = "lvFolderContent";
            this.lvFolderContent.Size = new System.Drawing.Size(420, 313);
            this.lvFolderContent.TabIndex = 11;
            this.lvFolderContent.UseCompatibleStateImageBehavior = false;
            this.lvFolderContent.View = System.Windows.Forms.View.Details;
            // 
            // txtBoxFolderPath
            // 
            this.txtBoxFolderPath.Location = new System.Drawing.Point(77, 22);
            this.txtBoxFolderPath.Name = "txtBoxFolderPath";
            this.txtBoxFolderPath.ReadOnly = true;
            this.txtBoxFolderPath.Size = new System.Drawing.Size(355, 20);
            this.txtBoxFolderPath.TabIndex = 12;
            // 
            // btnMerge
            // 
            this.btnMerge.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMerge.Location = new System.Drawing.Point(161, 375);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(120, 54);
            this.btnMerge.TabIndex = 14;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Visible = false;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // txtBoxMachineDelay
            // 
            this.txtBoxMachineDelay.Location = new System.Drawing.Point(385, 375);
            this.txtBoxMachineDelay.Name = "txtBoxMachineDelay";
            this.txtBoxMachineDelay.Size = new System.Drawing.Size(47, 20);
            this.txtBoxMachineDelay.TabIndex = 15;
            this.txtBoxMachineDelay.Text = "0,3";
            // 
            // FormSfc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 441);
            this.Controls.Add(this.txtBoxMachineDelay);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.txtBoxFolderPath);
            this.Controls.Add(this.lvFolderContent);
            this.Controls.Add(this.btnSelectFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSfc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.ListView lvFolderContent;
        private System.Windows.Forms.TextBox txtBoxFolderPath;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtBoxMachineDelay;
    }
}