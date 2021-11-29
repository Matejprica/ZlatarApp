
namespace ZlatarApp
{
    partial class FormChoosePotentiostat
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
            this.btnGamry = new System.Windows.Forms.Button();
            this.btnBioLogic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGamry
            // 
            this.btnGamry.Location = new System.Drawing.Point(65, 115);
            this.btnGamry.Name = "btnGamry";
            this.btnGamry.Size = new System.Drawing.Size(88, 52);
            this.btnGamry.TabIndex = 0;
            this.btnGamry.Text = "Gamry";
            this.btnGamry.UseVisualStyleBackColor = true;
            this.btnGamry.Click += new System.EventHandler(this.btnGamry_Click);
            // 
            // btnBioLogic
            // 
            this.btnBioLogic.Location = new System.Drawing.Point(251, 115);
            this.btnBioLogic.Name = "btnBioLogic";
            this.btnBioLogic.Size = new System.Drawing.Size(88, 52);
            this.btnBioLogic.TabIndex = 1;
            this.btnBioLogic.Text = "BioLogic";
            this.btnBioLogic.UseVisualStyleBackColor = true;
            this.btnBioLogic.Click += new System.EventHandler(this.btnBioLogic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(86, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose your potentiostat";
            // 
            // FormChoosePotentiostat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBioLogic);
            this.Controls.Add(this.btnGamry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChoosePotentiostat";
            this.Text = "Potentiostat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGamry;
        private System.Windows.Forms.Button btnBioLogic;
        private System.Windows.Forms.Label label1;
    }
}