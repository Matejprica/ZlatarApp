namespace ZlatarApp
{
    partial class FormSettings
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
            this.btnSetAppFolder = new System.Windows.Forms.Button();
            this.txtBoxAppFolder = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetAppFolder
            // 
            this.btnSetAppFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSetAppFolder.Name = "btnSetAppFolder";
            this.btnSetAppFolder.Size = new System.Drawing.Size(64, 44);
            this.btnSetAppFolder.TabIndex = 0;
            this.btnSetAppFolder.Text = "Set App Folder";
            this.btnSetAppFolder.UseVisualStyleBackColor = true;
            this.btnSetAppFolder.Click += new System.EventHandler(this.btnSetAppFolder_Click);
            // 
            // txtBoxAppFolder
            // 
            this.txtBoxAppFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxAppFolder.Location = new System.Drawing.Point(82, 25);
            this.txtBoxAppFolder.Name = "txtBoxAppFolder";
            this.txtBoxAppFolder.ReadOnly = true;
            this.txtBoxAppFolder.Size = new System.Drawing.Size(234, 20);
            this.txtBoxAppFolder.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(82, 237);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(66, 44);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 293);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtBoxAppFolder);
            this.Controls.Add(this.btnSetAppFolder);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetAppFolder;
        private System.Windows.Forms.TextBox txtBoxAppFolder;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}