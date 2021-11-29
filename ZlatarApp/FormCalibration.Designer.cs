namespace ZlatarApp
{
    partial class FormCalibration
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
            this.btnS3Clear = new System.Windows.Forms.Button();
            this.btnS2Clear = new System.Windows.Forms.Button();
            this.btnS1Clear = new System.Windows.Forms.Button();
            this.btnBlank2Clear = new System.Windows.Forms.Button();
            this.btnBlank1Clear = new System.Windows.Forms.Button();
            this.txtBoxS3 = new System.Windows.Forms.TextBox();
            this.txtBoxS2 = new System.Windows.Forms.TextBox();
            this.txtBoxS1 = new System.Windows.Forms.TextBox();
            this.txtBoxBlank2 = new System.Windows.Forms.TextBox();
            this.txtBoxBlank1 = new System.Windows.Forms.TextBox();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listView = new System.Windows.Forms.ListView();
            this.pnlTopContainer = new System.Windows.Forms.Panel();
            this.lblMeasurementDate = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlTopContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnS3Clear
            // 
            this.btnS3Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnS3Clear.Location = new System.Drawing.Point(297, 142);
            this.btnS3Clear.Name = "btnS3Clear";
            this.btnS3Clear.Size = new System.Drawing.Size(24, 17);
            this.btnS3Clear.TabIndex = 37;
            this.btnS3Clear.Tag = "txtBoxS3";
            this.btnS3Clear.UseVisualStyleBackColor = true;
            this.btnS3Clear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnS2Clear
            // 
            this.btnS2Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnS2Clear.Location = new System.Drawing.Point(297, 111);
            this.btnS2Clear.Name = "btnS2Clear";
            this.btnS2Clear.Size = new System.Drawing.Size(24, 17);
            this.btnS2Clear.TabIndex = 36;
            this.btnS2Clear.Tag = "txtBoxS2";
            this.btnS2Clear.UseVisualStyleBackColor = true;
            this.btnS2Clear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnS1Clear
            // 
            this.btnS1Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnS1Clear.Location = new System.Drawing.Point(297, 82);
            this.btnS1Clear.Name = "btnS1Clear";
            this.btnS1Clear.Size = new System.Drawing.Size(24, 17);
            this.btnS1Clear.TabIndex = 35;
            this.btnS1Clear.Tag = "txtBoxS1";
            this.btnS1Clear.UseVisualStyleBackColor = true;
            this.btnS1Clear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBlank2Clear
            // 
            this.btnBlank2Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBlank2Clear.Location = new System.Drawing.Point(297, 53);
            this.btnBlank2Clear.Name = "btnBlank2Clear";
            this.btnBlank2Clear.Size = new System.Drawing.Size(24, 17);
            this.btnBlank2Clear.TabIndex = 34;
            this.btnBlank2Clear.Tag = "txtBoxBlank2";
            this.btnBlank2Clear.UseVisualStyleBackColor = true;
            this.btnBlank2Clear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBlank1Clear
            // 
            this.btnBlank1Clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBlank1Clear.Location = new System.Drawing.Point(297, 24);
            this.btnBlank1Clear.Name = "btnBlank1Clear";
            this.btnBlank1Clear.Size = new System.Drawing.Size(24, 17);
            this.btnBlank1Clear.TabIndex = 33;
            this.btnBlank1Clear.Tag = "txtBoxBlank1";
            this.btnBlank1Clear.UseVisualStyleBackColor = true;
            this.btnBlank1Clear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBoxS3
            // 
            this.txtBoxS3.AllowDrop = true;
            this.txtBoxS3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxS3.Location = new System.Drawing.Point(126, 139);
            this.txtBoxS3.Name = "txtBoxS3";
            this.txtBoxS3.ReadOnly = true;
            this.txtBoxS3.Size = new System.Drawing.Size(165, 20);
            this.txtBoxS3.TabIndex = 32;
            // 
            // txtBoxS2
            // 
            this.txtBoxS2.AllowDrop = true;
            this.txtBoxS2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxS2.Location = new System.Drawing.Point(125, 110);
            this.txtBoxS2.Name = "txtBoxS2";
            this.txtBoxS2.ReadOnly = true;
            this.txtBoxS2.Size = new System.Drawing.Size(165, 20);
            this.txtBoxS2.TabIndex = 31;
            // 
            // txtBoxS1
            // 
            this.txtBoxS1.AllowDrop = true;
            this.txtBoxS1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxS1.Location = new System.Drawing.Point(126, 81);
            this.txtBoxS1.Name = "txtBoxS1";
            this.txtBoxS1.ReadOnly = true;
            this.txtBoxS1.Size = new System.Drawing.Size(165, 20);
            this.txtBoxS1.TabIndex = 30;
            // 
            // txtBoxBlank2
            // 
            this.txtBoxBlank2.AllowDrop = true;
            this.txtBoxBlank2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxBlank2.Location = new System.Drawing.Point(125, 52);
            this.txtBoxBlank2.Name = "txtBoxBlank2";
            this.txtBoxBlank2.ReadOnly = true;
            this.txtBoxBlank2.Size = new System.Drawing.Size(165, 20);
            this.txtBoxBlank2.TabIndex = 29;
            // 
            // txtBoxBlank1
            // 
            this.txtBoxBlank1.AllowDrop = true;
            this.txtBoxBlank1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxBlank1.Location = new System.Drawing.Point(126, 23);
            this.txtBoxBlank1.Name = "txtBoxBlank1";
            this.txtBoxBlank1.ReadOnly = true;
            this.txtBoxBlank1.Size = new System.Drawing.Size(165, 20);
            this.txtBoxBlank1.TabIndex = 28;
            // 
            // btnCalibration
            // 
            this.btnCalibration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalibration.Location = new System.Drawing.Point(348, 23);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(96, 33);
            this.btnCalibration.TabIndex = 27;
            this.btnCalibration.Text = "Calibrate";
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.btnCalibration_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "S3";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "S2";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "S1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Blank2";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Blank1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(222, 421);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 42);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 195);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(528, 220);
            this.listView.TabIndex = 40;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.lblMeasurementDate);
            this.pnlTopContainer.Controls.Add(this.lblDate);
            this.pnlTopContainer.Controls.Add(this.btnCalibration);
            this.pnlTopContainer.Controls.Add(this.label1);
            this.pnlTopContainer.Controls.Add(this.label2);
            this.pnlTopContainer.Controls.Add(this.btnS3Clear);
            this.pnlTopContainer.Controls.Add(this.txtBoxBlank1);
            this.pnlTopContainer.Controls.Add(this.btnS2Clear);
            this.pnlTopContainer.Controls.Add(this.txtBoxBlank2);
            this.pnlTopContainer.Controls.Add(this.txtBoxS3);
            this.pnlTopContainer.Controls.Add(this.btnS1Clear);
            this.pnlTopContainer.Controls.Add(this.txtBoxS2);
            this.pnlTopContainer.Controls.Add(this.label5);
            this.pnlTopContainer.Controls.Add(this.txtBoxS1);
            this.pnlTopContainer.Controls.Add(this.label4);
            this.pnlTopContainer.Controls.Add(this.btnBlank2Clear);
            this.pnlTopContainer.Controls.Add(this.label3);
            this.pnlTopContainer.Controls.Add(this.btnBlank1Clear);
            this.pnlTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(552, 189);
            this.pnlTopContainer.TabIndex = 41;
            // 
            // lblMeasurementDate
            // 
            this.lblMeasurementDate.AutoSize = true;
            this.lblMeasurementDate.Font = new System.Drawing.Font("Neo Sans", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeasurementDate.Location = new System.Drawing.Point(339, 85);
            this.lblMeasurementDate.Name = "lblMeasurementDate";
            this.lblMeasurementDate.Size = new System.Drawing.Size(118, 16);
            this.lblMeasurementDate.TabIndex = 39;
            this.lblMeasurementDate.Text = "Measurement date:";
            this.lblMeasurementDate.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Neo Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(337, 115);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 26);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "label6";
            this.lblDate.Visible = false;
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 487);
            this.Controls.Add(this.pnlTopContainer);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.Name = "FormCalibration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calibration";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCalibration_KeyDown);
            this.pnlTopContainer.ResumeLayout(false);
            this.pnlTopContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnS3Clear;
        private System.Windows.Forms.Button btnS2Clear;
        private System.Windows.Forms.Button btnS1Clear;
        private System.Windows.Forms.Button btnBlank2Clear;
        private System.Windows.Forms.Button btnBlank1Clear;
        private System.Windows.Forms.TextBox txtBoxS3;
        private System.Windows.Forms.TextBox txtBoxS2;
        private System.Windows.Forms.TextBox txtBoxS1;
        private System.Windows.Forms.TextBox txtBoxBlank2;
        private System.Windows.Forms.TextBox txtBoxBlank1;
        private System.Windows.Forms.Button btnCalibration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Panel pnlTopContainer;
        private System.Windows.Forms.Label lblMeasurementDate;
        private System.Windows.Forms.Label lblDate;
    }
}