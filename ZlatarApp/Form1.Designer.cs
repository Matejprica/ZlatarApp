namespace ZlatarApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsFlpChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tpCalibration = new System.Windows.Forms.TabPage();
            this.btnCalibrationInfo = new System.Windows.Forms.Button();
            this.lblMeasureDatePane1 = new System.Windows.Forms.Label();
            this.btnDeleteCalibration = new System.Windows.Forms.Button();
            this.flpCalibration = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadCalibration = new System.Windows.Forms.Button();
            this.btnNewCalibration = new System.Windows.Forms.Button();
            this.tpIcpMs = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbICpMsElements = new System.Windows.Forms.ComboBox();
            this.lblMeasureDatePane2 = new System.Windows.Forms.Label();
            this.btnDeleteTreatedMacroLists = new System.Windows.Forms.Button();
            this.flpIcpMs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadTreatedML = new System.Windows.Forms.Button();
            this.btnMacroListTreatment = new System.Windows.Forms.Button();
            this.tpSfc = new System.Windows.Forms.TabPage();
            this.pnlSfcBtnContainer = new System.Windows.Forms.Panel();
            this.btnClearAllFiles = new System.Windows.Forms.Button();
            this.btnClearAllCharts = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnDeleteSelectedFiles = new System.Windows.Forms.Button();
            this.btnAddSingleFiles = new System.Windows.Forms.Button();
            this.tabControlSfc = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnlSfcIvsT = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pnlSfcVvsT = new System.Windows.Forms.Panel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.pnlSfcIvsV = new System.Windows.Forms.Panel();
            this.lvSingleFiles = new System.Windows.Forms.ListView();
            this.tpSfcNorm = new System.Windows.Forms.TabPage();
            this.lblPhNorm = new System.Windows.Forms.Label();
            this.txtBoxPhNormalization = new System.Windows.Forms.TextBox();
            this.lblConstSurfaceNorm = new System.Windows.Forms.Label();
            this.txtBoxConstantSurfaceNorm = new System.Windows.Forms.TextBox();
            this.cbConstantSurface = new System.Windows.Forms.CheckBox();
            this.lblConstMassNorm = new System.Windows.Forms.Label();
            this.txtBoxSurfaceNormML = new System.Windows.Forms.TextBox();
            this.txtBoxMassNormML = new System.Windows.Forms.TextBox();
            this.txtBoxSurfaceNormalization = new System.Windows.Forms.TextBox();
            this.txtBoxMassNormalization = new System.Windows.Forms.TextBox();
            this.txtBoxConstantMassNorm = new System.Windows.Forms.TextBox();
            this.cbConstantMass = new System.Windows.Forms.CheckBox();
            this.btnClearSurfaceNorm = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClearMassNorm = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lvSfcNormalization = new System.Windows.Forms.ListView();
            this.btnNormalization = new System.Windows.Forms.Button();
            this.btnClearSfcNorm = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.tpSfcIcpMs = new System.Windows.Forms.TabPage();
            this.btnFindPeaks = new System.Windows.Forms.Button();
            this.lblConstSurface = new System.Windows.Forms.Label();
            this.txtBoxSurfaceML = new System.Windows.Forms.TextBox();
            this.txtBoxDelayML = new System.Windows.Forms.TextBox();
            this.txtBoxSurface = new System.Windows.Forms.TextBox();
            this.txtBoxDelay = new System.Windows.Forms.TextBox();
            this.txtBoxConstantSurface = new System.Windows.Forms.TextBox();
            this.cbSurfaceFinalTreatment = new System.Windows.Forms.CheckBox();
            this.btnClearSurface = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClearDelay = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxTime = new System.Windows.Forms.TextBox();
            this.txtBoxM2 = new System.Windows.Forms.TextBox();
            this.txtBoxM1 = new System.Windows.Forms.TextBox();
            this.txtBoxPh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvSfc = new System.Windows.Forms.ListView();
            this.lvIcpMs = new System.Windows.Forms.ListView();
            this.lblLastTreatedML = new System.Windows.Forms.Label();
            this.btnTreatment = new System.Windows.Forms.Button();
            this.btnLoadIcpMsSfc = new System.Windows.Forms.Button();
            this.lblMeasureDatePane5 = new System.Windows.Forms.Label();
            this.btnClearSfc = new System.Windows.Forms.Button();
            this.btnClearIcpMs = new System.Windows.Forms.Button();
            this.lblShift = new System.Windows.Forms.Label();
            this.labelShift = new System.Windows.Forms.Label();
            this.lblFlowrateSec = new System.Windows.Forms.Label();
            this.labelFlowrateSec = new System.Windows.Forms.Label();
            this.lblFlowrateMin = new System.Windows.Forms.Label();
            this.labelFlowrateMin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpSfcIcpMsChart = new System.Windows.Forms.TabPage();
            this.bntClearIcpMsSfcCharts = new System.Windows.Forms.Button();
            this.btnLoadSingle = new System.Windows.Forms.Button();
            this.btnLoadIcpMsSf = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.flpLoadE = new System.Windows.Forms.FlowLayoutPanel();
            this.splitterE = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flpIcpMsSfcE = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.flpLoadJ = new System.Windows.Forms.FlowLayoutPanel();
            this.splitterJ = new System.Windows.Forms.Splitter();
            this.flpIcpMsSfcJ = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.cmsFlpChart.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.tpCalibration.SuspendLayout();
            this.tpIcpMs.SuspendLayout();
            this.tpSfc.SuspendLayout();
            this.pnlSfcBtnContainer.SuspendLayout();
            this.tabControlSfc.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tpSfcNorm.SuspendLayout();
            this.tpSfcIcpMs.SuspendLayout();
            this.tpSfcIcpMsChart.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // cmsFlpChart
            // 
            this.cmsFlpChart.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFlpChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseColorToolStripMenuItem,
            this.randomColorToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsFlpChart.Name = "flpGraphCms";
            this.cmsFlpChart.Size = new System.Drawing.Size(150, 70);
            // 
            // chooseColorToolStripMenuItem
            // 
            this.chooseColorToolStripMenuItem.Name = "chooseColorToolStripMenuItem";
            this.chooseColorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.chooseColorToolStripMenuItem.Text = "Choose color";
            this.chooseColorToolStripMenuItem.Click += new System.EventHandler(this.chooseColorToolStripMenuItem_Click);
            // 
            // randomColorToolStripMenuItem
            // 
            this.randomColorToolStripMenuItem.Name = "randomColorToolStripMenuItem";
            this.randomColorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.randomColorToolStripMenuItem.Text = "Random color";
            this.randomColorToolStripMenuItem.Click += new System.EventHandler(this.randomColorToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tpCalibration);
            this.tabContainer.Controls.Add(this.tpIcpMs);
            this.tabContainer.Controls.Add(this.tpSfc);
            this.tabContainer.Controls.Add(this.tpSfcNorm);
            this.tabContainer.Controls.Add(this.tpSfcIcpMs);
            this.tabContainer.Controls.Add(this.tpSfcIcpMsChart);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContainer.Location = new System.Drawing.Point(0, 24);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1011, 507);
            this.tabContainer.TabIndex = 26;
            this.tabContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSfcNormalization_DragDrop);
            this.tabContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSfcNormalization_DragEnter);
            // 
            // tpCalibration
            // 
            this.tpCalibration.Controls.Add(this.btnCalibrationInfo);
            this.tpCalibration.Controls.Add(this.lblMeasureDatePane1);
            this.tpCalibration.Controls.Add(this.btnDeleteCalibration);
            this.tpCalibration.Controls.Add(this.flpCalibration);
            this.tpCalibration.Controls.Add(this.btnLoadCalibration);
            this.tpCalibration.Controls.Add(this.btnNewCalibration);
            this.tpCalibration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCalibration.Location = new System.Drawing.Point(4, 27);
            this.tpCalibration.Name = "tpCalibration";
            this.tpCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tpCalibration.Size = new System.Drawing.Size(1003, 476);
            this.tpCalibration.TabIndex = 0;
            this.tpCalibration.Text = "Calibration";
            // 
            // btnCalibrationInfo
            // 
            this.btnCalibrationInfo.Enabled = false;
            this.btnCalibrationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrationInfo.Location = new System.Drawing.Point(15, 187);
            this.btnCalibrationInfo.Name = "btnCalibrationInfo";
            this.btnCalibrationInfo.Size = new System.Drawing.Size(120, 60);
            this.btnCalibrationInfo.TabIndex = 6;
            this.btnCalibrationInfo.Text = "Calibration Info";
            this.btnCalibrationInfo.UseVisualStyleBackColor = true;
            this.btnCalibrationInfo.Click += new System.EventHandler(this.btnCalibrationInfo_Click);
            // 
            // lblMeasureDatePane1
            // 
            this.lblMeasureDatePane1.AutoSize = true;
            this.lblMeasureDatePane1.Location = new System.Drawing.Point(15, 18);
            this.lblMeasureDatePane1.Name = "lblMeasureDatePane1";
            this.lblMeasureDatePane1.Size = new System.Drawing.Size(46, 18);
            this.lblMeasureDatePane1.TabIndex = 5;
            this.lblMeasureDatePane1.Text = "label3";
            this.lblMeasureDatePane1.Visible = false;
            // 
            // btnDeleteCalibration
            // 
            this.btnDeleteCalibration.Enabled = false;
            this.btnDeleteCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCalibration.Location = new System.Drawing.Point(15, 253);
            this.btnDeleteCalibration.Name = "btnDeleteCalibration";
            this.btnDeleteCalibration.Size = new System.Drawing.Size(120, 60);
            this.btnDeleteCalibration.TabIndex = 4;
            this.btnDeleteCalibration.Text = "Delete Calibration";
            this.btnDeleteCalibration.UseVisualStyleBackColor = true;
            this.btnDeleteCalibration.Click += new System.EventHandler(this.btnDeleteCalibration_Click);
            // 
            // flpCalibration
            // 
            this.flpCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCalibration.AutoScroll = true;
            this.flpCalibration.Location = new System.Drawing.Point(141, 55);
            this.flpCalibration.Name = "flpCalibration";
            this.flpCalibration.Size = new System.Drawing.Size(854, 408);
            this.flpCalibration.TabIndex = 3;
            // 
            // btnLoadCalibration
            // 
            this.btnLoadCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCalibration.Location = new System.Drawing.Point(15, 121);
            this.btnLoadCalibration.Name = "btnLoadCalibration";
            this.btnLoadCalibration.Size = new System.Drawing.Size(120, 60);
            this.btnLoadCalibration.TabIndex = 1;
            this.btnLoadCalibration.Text = "Load Calibration";
            this.btnLoadCalibration.UseVisualStyleBackColor = true;
            this.btnLoadCalibration.Click += new System.EventHandler(this.btnLoadCalibration_Click);
            // 
            // btnNewCalibration
            // 
            this.btnNewCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCalibration.Location = new System.Drawing.Point(15, 55);
            this.btnNewCalibration.Name = "btnNewCalibration";
            this.btnNewCalibration.Size = new System.Drawing.Size(120, 60);
            this.btnNewCalibration.TabIndex = 0;
            this.btnNewCalibration.Text = "New Calibration";
            this.btnNewCalibration.UseVisualStyleBackColor = true;
            this.btnNewCalibration.Click += new System.EventHandler(this.btnNewCalibration_Click);
            // 
            // tpIcpMs
            // 
            this.tpIcpMs.Controls.Add(this.label3);
            this.tpIcpMs.Controls.Add(this.cbICpMsElements);
            this.tpIcpMs.Controls.Add(this.lblMeasureDatePane2);
            this.tpIcpMs.Controls.Add(this.btnDeleteTreatedMacroLists);
            this.tpIcpMs.Controls.Add(this.flpIcpMs);
            this.tpIcpMs.Controls.Add(this.btnLoadTreatedML);
            this.tpIcpMs.Controls.Add(this.btnMacroListTreatment);
            this.tpIcpMs.Location = new System.Drawing.Point(4, 27);
            this.tpIcpMs.Name = "tpIcpMs";
            this.tpIcpMs.Padding = new System.Windows.Forms.Padding(3);
            this.tpIcpMs.Size = new System.Drawing.Size(1003, 476);
            this.tpIcpMs.TabIndex = 1;
            this.tpIcpMs.Text = "ICP-MS";
            this.tpIcpMs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flpIcpMs_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filter:";
            // 
            // cbICpMsElements
            // 
            this.cbICpMsElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbICpMsElements.FormattingEnabled = true;
            this.cbICpMsElements.Location = new System.Drawing.Point(15, 304);
            this.cbICpMsElements.Name = "cbICpMsElements";
            this.cbICpMsElements.Size = new System.Drawing.Size(120, 26);
            this.cbICpMsElements.TabIndex = 0;
            this.cbICpMsElements.SelectedValueChanged += new System.EventHandler(this.cbICpMsElements_SelectedValueChanged);
            // 
            // lblMeasureDatePane2
            // 
            this.lblMeasureDatePane2.AutoSize = true;
            this.lblMeasureDatePane2.Location = new System.Drawing.Point(15, 18);
            this.lblMeasureDatePane2.Name = "lblMeasureDatePane2";
            this.lblMeasureDatePane2.Size = new System.Drawing.Size(46, 18);
            this.lblMeasureDatePane2.TabIndex = 25;
            this.lblMeasureDatePane2.Text = "label3";
            this.lblMeasureDatePane2.Visible = false;
            this.lblMeasureDatePane2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flpIcpMs_MouseClick);
            // 
            // btnDeleteTreatedMacroLists
            // 
            this.btnDeleteTreatedMacroLists.Enabled = false;
            this.btnDeleteTreatedMacroLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTreatedMacroLists.Location = new System.Drawing.Point(15, 187);
            this.btnDeleteTreatedMacroLists.Name = "btnDeleteTreatedMacroLists";
            this.btnDeleteTreatedMacroLists.Size = new System.Drawing.Size(120, 60);
            this.btnDeleteTreatedMacroLists.TabIndex = 24;
            this.btnDeleteTreatedMacroLists.Text = "Delete Treated Macro Lists";
            this.btnDeleteTreatedMacroLists.UseVisualStyleBackColor = true;
            this.btnDeleteTreatedMacroLists.Click += new System.EventHandler(this.btnDeleteTreatedMacroLists_Click);
            // 
            // flpIcpMs
            // 
            this.flpIcpMs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpIcpMs.AutoScroll = true;
            this.flpIcpMs.Location = new System.Drawing.Point(141, 55);
            this.flpIcpMs.Name = "flpIcpMs";
            this.flpIcpMs.Size = new System.Drawing.Size(854, 413);
            this.flpIcpMs.TabIndex = 23;
            this.flpIcpMs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flpIcpMs_MouseClick);
            // 
            // btnLoadTreatedML
            // 
            this.btnLoadTreatedML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTreatedML.Location = new System.Drawing.Point(15, 121);
            this.btnLoadTreatedML.Name = "btnLoadTreatedML";
            this.btnLoadTreatedML.Size = new System.Drawing.Size(120, 60);
            this.btnLoadTreatedML.TabIndex = 3;
            this.btnLoadTreatedML.Text = "Load Treated Macro List";
            this.btnLoadTreatedML.UseVisualStyleBackColor = true;
            this.btnLoadTreatedML.Click += new System.EventHandler(this.btnLoadTreatedML_Click);
            // 
            // btnMacroListTreatment
            // 
            this.btnMacroListTreatment.Enabled = false;
            this.btnMacroListTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMacroListTreatment.Location = new System.Drawing.Point(15, 55);
            this.btnMacroListTreatment.Name = "btnMacroListTreatment";
            this.btnMacroListTreatment.Size = new System.Drawing.Size(120, 60);
            this.btnMacroListTreatment.TabIndex = 2;
            this.btnMacroListTreatment.Text = "Macro List Treatment";
            this.btnMacroListTreatment.UseVisualStyleBackColor = true;
            this.btnMacroListTreatment.Click += new System.EventHandler(this.btnMacroListTreatment_Click);
            // 
            // tpSfc
            // 
            this.tpSfc.Controls.Add(this.pnlSfcBtnContainer);
            this.tpSfc.Controls.Add(this.tabControlSfc);
            this.tpSfc.Controls.Add(this.lvSingleFiles);
            this.tpSfc.Location = new System.Drawing.Point(4, 27);
            this.tpSfc.Name = "tpSfc";
            this.tpSfc.Padding = new System.Windows.Forms.Padding(3);
            this.tpSfc.Size = new System.Drawing.Size(1003, 476);
            this.tpSfc.TabIndex = 2;
            this.tpSfc.Text = "SFC";
            // 
            // pnlSfcBtnContainer
            // 
            this.pnlSfcBtnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSfcBtnContainer.Controls.Add(this.btnClearAllFiles);
            this.pnlSfcBtnContainer.Controls.Add(this.btnClearAllCharts);
            this.pnlSfcBtnContainer.Controls.Add(this.btnMerge);
            this.pnlSfcBtnContainer.Controls.Add(this.btnDeleteSelectedFiles);
            this.pnlSfcBtnContainer.Controls.Add(this.btnAddSingleFiles);
            this.pnlSfcBtnContainer.Location = new System.Drawing.Point(190, 6);
            this.pnlSfcBtnContainer.Name = "pnlSfcBtnContainer";
            this.pnlSfcBtnContainer.Size = new System.Drawing.Size(102, 462);
            this.pnlSfcBtnContainer.TabIndex = 4;
            // 
            // btnClearAllFiles
            // 
            this.btnClearAllFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearAllFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAllFiles.Location = new System.Drawing.Point(0, 352);
            this.btnClearAllFiles.Name = "btnClearAllFiles";
            this.btnClearAllFiles.Size = new System.Drawing.Size(102, 55);
            this.btnClearAllFiles.TabIndex = 8;
            this.btnClearAllFiles.Text = "Clear All Files";
            this.btnClearAllFiles.UseVisualStyleBackColor = true;
            this.btnClearAllFiles.Click += new System.EventHandler(this.btnRemoveLastChart_Click);
            // 
            // btnClearAllCharts
            // 
            this.btnClearAllCharts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearAllCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAllCharts.Location = new System.Drawing.Point(0, 407);
            this.btnClearAllCharts.Name = "btnClearAllCharts";
            this.btnClearAllCharts.Size = new System.Drawing.Size(102, 55);
            this.btnClearAllCharts.TabIndex = 8;
            this.btnClearAllCharts.Text = "Clear All Charts";
            this.btnClearAllCharts.UseVisualStyleBackColor = true;
            this.btnClearAllCharts.Click += new System.EventHandler(this.btnClearAllCharts_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(0, 110);
            this.btnMerge.Margin = new System.Windows.Forms.Padding(0);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(102, 55);
            this.btnMerge.TabIndex = 8;
            this.btnMerge.Text = "Merge Macro List";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnDeleteSelectedFiles
            // 
            this.btnDeleteSelectedFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteSelectedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelectedFiles.Location = new System.Drawing.Point(0, 55);
            this.btnDeleteSelectedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteSelectedFiles.Name = "btnDeleteSelectedFiles";
            this.btnDeleteSelectedFiles.Size = new System.Drawing.Size(102, 55);
            this.btnDeleteSelectedFiles.TabIndex = 8;
            this.btnDeleteSelectedFiles.Text = "Delete Selected Files";
            this.btnDeleteSelectedFiles.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedFiles.Click += new System.EventHandler(this.btnDeleteSelectedSingleFiles_Click);
            // 
            // btnAddSingleFiles
            // 
            this.btnAddSingleFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddSingleFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSingleFiles.Location = new System.Drawing.Point(0, 0);
            this.btnAddSingleFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddSingleFiles.Name = "btnAddSingleFiles";
            this.btnAddSingleFiles.Size = new System.Drawing.Size(102, 55);
            this.btnAddSingleFiles.TabIndex = 8;
            this.btnAddSingleFiles.Text = "Add Single Files";
            this.btnAddSingleFiles.UseVisualStyleBackColor = true;
            this.btnAddSingleFiles.Click += new System.EventHandler(this.btnAddSingleFiles_Click);
            // 
            // tabControlSfc
            // 
            this.tabControlSfc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSfc.Controls.Add(this.tabPage5);
            this.tabControlSfc.Controls.Add(this.tabPage6);
            this.tabControlSfc.Controls.Add(this.tabPage7);
            this.tabControlSfc.Location = new System.Drawing.Point(298, 6);
            this.tabControlSfc.Name = "tabControlSfc";
            this.tabControlSfc.SelectedIndex = 0;
            this.tabControlSfc.Size = new System.Drawing.Size(697, 462);
            this.tabControlSfc.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pnlSfcIvsT);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(689, 431);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "I vs. t";
            // 
            // pnlSfcIvsT
            // 
            this.pnlSfcIvsT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSfcIvsT.Location = new System.Drawing.Point(3, 3);
            this.pnlSfcIvsT.Name = "pnlSfcIvsT";
            this.pnlSfcIvsT.Size = new System.Drawing.Size(683, 425);
            this.pnlSfcIvsT.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pnlSfcVvsT);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(689, 431);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "V vs. t";
            // 
            // pnlSfcVvsT
            // 
            this.pnlSfcVvsT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSfcVvsT.Location = new System.Drawing.Point(3, 3);
            this.pnlSfcVvsT.Name = "pnlSfcVvsT";
            this.pnlSfcVvsT.Size = new System.Drawing.Size(683, 425);
            this.pnlSfcVvsT.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.pnlSfcIvsV);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(689, 431);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "I vs. V";
            // 
            // pnlSfcIvsV
            // 
            this.pnlSfcIvsV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSfcIvsV.Location = new System.Drawing.Point(3, 3);
            this.pnlSfcIvsV.Name = "pnlSfcIvsV";
            this.pnlSfcIvsV.Size = new System.Drawing.Size(683, 425);
            this.pnlSfcIvsV.TabIndex = 0;
            // 
            // lvSingleFiles
            // 
            this.lvSingleFiles.AllowDrop = true;
            this.lvSingleFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSingleFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSingleFiles.HideSelection = false;
            this.lvSingleFiles.Location = new System.Drawing.Point(6, 6);
            this.lvSingleFiles.Name = "lvSingleFiles";
            this.lvSingleFiles.Size = new System.Drawing.Size(178, 462);
            this.lvSingleFiles.TabIndex = 0;
            this.lvSingleFiles.UseCompatibleStateImageBehavior = false;
            this.lvSingleFiles.View = System.Windows.Forms.View.List;
            this.lvSingleFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSingleFiles_DragDrop);
            this.lvSingleFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSingleFiles_DragEnter);
            this.lvSingleFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSingleFiles_MouseDoubleClick);
            // 
            // tpSfcNorm
            // 
            this.tpSfcNorm.BackColor = System.Drawing.SystemColors.Control;
            this.tpSfcNorm.Controls.Add(this.lblPhNorm);
            this.tpSfcNorm.Controls.Add(this.txtBoxPhNormalization);
            this.tpSfcNorm.Controls.Add(this.lblConstSurfaceNorm);
            this.tpSfcNorm.Controls.Add(this.txtBoxConstantSurfaceNorm);
            this.tpSfcNorm.Controls.Add(this.cbConstantSurface);
            this.tpSfcNorm.Controls.Add(this.lblConstMassNorm);
            this.tpSfcNorm.Controls.Add(this.txtBoxSurfaceNormML);
            this.tpSfcNorm.Controls.Add(this.txtBoxMassNormML);
            this.tpSfcNorm.Controls.Add(this.txtBoxSurfaceNormalization);
            this.tpSfcNorm.Controls.Add(this.txtBoxMassNormalization);
            this.tpSfcNorm.Controls.Add(this.txtBoxConstantMassNorm);
            this.tpSfcNorm.Controls.Add(this.cbConstantMass);
            this.tpSfcNorm.Controls.Add(this.btnClearSurfaceNorm);
            this.tpSfcNorm.Controls.Add(this.label11);
            this.tpSfcNorm.Controls.Add(this.btnClearMassNorm);
            this.tpSfcNorm.Controls.Add(this.label12);
            this.tpSfcNorm.Controls.Add(this.lvSfcNormalization);
            this.tpSfcNorm.Controls.Add(this.btnNormalization);
            this.tpSfcNorm.Controls.Add(this.btnClearSfcNorm);
            this.tpSfcNorm.Controls.Add(this.label25);
            this.tpSfcNorm.Location = new System.Drawing.Point(4, 27);
            this.tpSfcNorm.Name = "tpSfcNorm";
            this.tpSfcNorm.Size = new System.Drawing.Size(1003, 476);
            this.tpSfcNorm.TabIndex = 5;
            this.tpSfcNorm.Text = "SFC Normalization";
            // 
            // lblPhNorm
            // 
            this.lblPhNorm.AutoSize = true;
            this.lblPhNorm.Location = new System.Drawing.Point(624, 28);
            this.lblPhNorm.Name = "lblPhNorm";
            this.lblPhNorm.Size = new System.Drawing.Size(27, 18);
            this.lblPhNorm.TabIndex = 94;
            this.lblPhNorm.Text = "pH";
            this.lblPhNorm.Visible = false;
            // 
            // txtBoxPhNormalization
            // 
            this.txtBoxPhNormalization.Location = new System.Drawing.Point(627, 49);
            this.txtBoxPhNormalization.Name = "txtBoxPhNormalization";
            this.txtBoxPhNormalization.Size = new System.Drawing.Size(77, 24);
            this.txtBoxPhNormalization.TabIndex = 93;
            this.txtBoxPhNormalization.Visible = false;
            // 
            // lblConstSurfaceNorm
            // 
            this.lblConstSurfaceNorm.AutoSize = true;
            this.lblConstSurfaceNorm.Location = new System.Drawing.Point(710, 125);
            this.lblConstSurfaceNorm.Name = "lblConstSurfaceNorm";
            this.lblConstSurfaceNorm.Size = new System.Drawing.Size(44, 18);
            this.lblConstSurfaceNorm.TabIndex = 92;
            this.lblConstSurfaceNorm.Text = "cm^2";
            this.lblConstSurfaceNorm.Visible = false;
            // 
            // txtBoxConstantSurfaceNorm
            // 
            this.txtBoxConstantSurfaceNorm.Location = new System.Drawing.Point(627, 122);
            this.txtBoxConstantSurfaceNorm.Name = "txtBoxConstantSurfaceNorm";
            this.txtBoxConstantSurfaceNorm.Size = new System.Drawing.Size(77, 24);
            this.txtBoxConstantSurfaceNorm.TabIndex = 91;
            this.txtBoxConstantSurfaceNorm.Visible = false;
            // 
            // cbConstantSurface
            // 
            this.cbConstantSurface.AutoSize = true;
            this.cbConstantSurface.Location = new System.Drawing.Point(627, 94);
            this.cbConstantSurface.Name = "cbConstantSurface";
            this.cbConstantSurface.Size = new System.Drawing.Size(176, 22);
            this.cbConstantSurface.TabIndex = 90;
            this.cbConstantSurface.Text = "Constant Surface Area";
            this.cbConstantSurface.UseVisualStyleBackColor = true;
            this.cbConstantSurface.Visible = false;
            this.cbConstantSurface.CheckedChanged += new System.EventHandler(this.cbConstantSurface_CheckedChanged);
            // 
            // lblConstMassNorm
            // 
            this.lblConstMassNorm.AutoSize = true;
            this.lblConstMassNorm.Location = new System.Drawing.Point(310, 125);
            this.lblConstMassNorm.Name = "lblConstMassNorm";
            this.lblConstMassNorm.Size = new System.Drawing.Size(24, 18);
            this.lblConstMassNorm.TabIndex = 89;
            this.lblConstMassNorm.Text = "μg";
            this.lblConstMassNorm.Visible = false;
            // 
            // txtBoxSurfaceNormML
            // 
            this.txtBoxSurfaceNormML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxSurfaceNormML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurfaceNormML.Location = new System.Drawing.Point(627, 208);
            this.txtBoxSurfaceNormML.Multiline = true;
            this.txtBoxSurfaceNormML.Name = "txtBoxSurfaceNormML";
            this.txtBoxSurfaceNormML.ReadOnly = true;
            this.txtBoxSurfaceNormML.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBoxSurfaceNormML.Size = new System.Drawing.Size(242, 260);
            this.txtBoxSurfaceNormML.TabIndex = 88;
            // 
            // txtBoxMassNormML
            // 
            this.txtBoxMassNormML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxMassNormML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxMassNormML.Location = new System.Drawing.Point(227, 208);
            this.txtBoxMassNormML.Multiline = true;
            this.txtBoxMassNormML.Name = "txtBoxMassNormML";
            this.txtBoxMassNormML.ReadOnly = true;
            this.txtBoxMassNormML.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBoxMassNormML.Size = new System.Drawing.Size(242, 260);
            this.txtBoxMassNormML.TabIndex = 87;
            // 
            // txtBoxSurfaceNormalization
            // 
            this.txtBoxSurfaceNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxSurfaceNormalization.Enabled = false;
            this.txtBoxSurfaceNormalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurfaceNormalization.Location = new System.Drawing.Point(870, 208);
            this.txtBoxSurfaceNormalization.Multiline = true;
            this.txtBoxSurfaceNormalization.Name = "txtBoxSurfaceNormalization";
            this.txtBoxSurfaceNormalization.Size = new System.Drawing.Size(130, 260);
            this.txtBoxSurfaceNormalization.TabIndex = 86;
            // 
            // txtBoxMassNormalization
            // 
            this.txtBoxMassNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxMassNormalization.Enabled = false;
            this.txtBoxMassNormalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMassNormalization.Location = new System.Drawing.Point(470, 208);
            this.txtBoxMassNormalization.Multiline = true;
            this.txtBoxMassNormalization.Name = "txtBoxMassNormalization";
            this.txtBoxMassNormalization.Size = new System.Drawing.Size(130, 260);
            this.txtBoxMassNormalization.TabIndex = 85;
            // 
            // txtBoxConstantMassNorm
            // 
            this.txtBoxConstantMassNorm.Location = new System.Drawing.Point(227, 122);
            this.txtBoxConstantMassNorm.Name = "txtBoxConstantMassNorm";
            this.txtBoxConstantMassNorm.Size = new System.Drawing.Size(77, 24);
            this.txtBoxConstantMassNorm.TabIndex = 84;
            this.txtBoxConstantMassNorm.Visible = false;
            // 
            // cbConstantMass
            // 
            this.cbConstantMass.AutoSize = true;
            this.cbConstantMass.Location = new System.Drawing.Point(227, 94);
            this.cbConstantMass.Name = "cbConstantMass";
            this.cbConstantMass.Size = new System.Drawing.Size(128, 22);
            this.cbConstantMass.TabIndex = 83;
            this.cbConstantMass.Text = "Constant Mass";
            this.cbConstantMass.UseVisualStyleBackColor = true;
            this.cbConstantMass.Visible = false;
            this.cbConstantMass.CheckedChanged += new System.EventHandler(this.cbConstantMass_CheckedChanged);
            // 
            // btnClearSurfaceNorm
            // 
            this.btnClearSurfaceNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearSurfaceNorm.Location = new System.Drawing.Point(870, 168);
            this.btnClearSurfaceNorm.Name = "btnClearSurfaceNorm";
            this.btnClearSurfaceNorm.Size = new System.Drawing.Size(60, 29);
            this.btnClearSurfaceNorm.TabIndex = 82;
            this.btnClearSurfaceNorm.Tag = "txtBosSurfaceNormalization";
            this.btnClearSurfaceNorm.Text = "Clear";
            this.btnClearSurfaceNorm.UseVisualStyleBackColor = true;
            this.btnClearSurfaceNorm.Click += new System.EventHandler(this.btnClearSurfaceNorm_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(624, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 18);
            this.label11.TabIndex = 81;
            this.label11.Text = "Surface Area (cm^2)";
            // 
            // btnClearMassNorm
            // 
            this.btnClearMassNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearMassNorm.Location = new System.Drawing.Point(470, 168);
            this.btnClearMassNorm.Name = "btnClearMassNorm";
            this.btnClearMassNorm.Size = new System.Drawing.Size(60, 29);
            this.btnClearMassNorm.TabIndex = 80;
            this.btnClearMassNorm.Tag = "txtBoxMassNormalization";
            this.btnClearMassNorm.Text = "Clear";
            this.btnClearMassNorm.UseVisualStyleBackColor = true;
            this.btnClearMassNorm.Click += new System.EventHandler(this.btnClearMassNorm_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 18);
            this.label12.TabIndex = 79;
            this.label12.Text = "Mass (μg)";
            // 
            // lvSfcNormalization
            // 
            this.lvSfcNormalization.AllowDrop = true;
            this.lvSfcNormalization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSfcNormalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvSfcNormalization.HideSelection = false;
            this.lvSfcNormalization.Location = new System.Drawing.Point(18, 210);
            this.lvSfcNormalization.Name = "lvSfcNormalization";
            this.lvSfcNormalization.Size = new System.Drawing.Size(185, 260);
            this.lvSfcNormalization.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSfcNormalization.TabIndex = 69;
            this.lvSfcNormalization.UseCompatibleStateImageBehavior = false;
            this.lvSfcNormalization.View = System.Windows.Forms.View.Details;
            this.lvSfcNormalization.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSfcNormalization_DragDrop);
            this.lvSfcNormalization.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSfcNormalization_DragEnter);
            // 
            // btnNormalization
            // 
            this.btnNormalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNormalization.Location = new System.Drawing.Point(834, 28);
            this.btnNormalization.Name = "btnNormalization";
            this.btnNormalization.Size = new System.Drawing.Size(114, 52);
            this.btnNormalization.TabIndex = 67;
            this.btnNormalization.Text = "Normalization";
            this.btnNormalization.UseVisualStyleBackColor = true;
            this.btnNormalization.Visible = false;
            this.btnNormalization.Click += new System.EventHandler(this.btnNormalization_Click);
            // 
            // btnClearSfcNorm
            // 
            this.btnClearSfcNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearSfcNorm.Location = new System.Drawing.Point(143, 170);
            this.btnClearSfcNorm.Name = "btnClearSfcNorm";
            this.btnClearSfcNorm.Size = new System.Drawing.Size(60, 27);
            this.btnClearSfcNorm.TabIndex = 64;
            this.btnClearSfcNorm.Tag = "lvSfcNormalization";
            this.btnClearSfcNorm.Text = "Clear";
            this.btnClearSfcNorm.UseVisualStyleBackColor = true;
            this.btnClearSfcNorm.Click += new System.EventHandler(this.btnClearSfcNorm_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(18, 176);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 18);
            this.label25.TabIndex = 57;
            this.label25.Text = "SFC";
            // 
            // tpSfcIcpMs
            // 
            this.tpSfcIcpMs.Controls.Add(this.btnFindPeaks);
            this.tpSfcIcpMs.Controls.Add(this.lblConstSurface);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxSurfaceML);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxDelayML);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxSurface);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxDelay);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxConstantSurface);
            this.tpSfcIcpMs.Controls.Add(this.cbSurfaceFinalTreatment);
            this.tpSfcIcpMs.Controls.Add(this.btnClearSurface);
            this.tpSfcIcpMs.Controls.Add(this.label9);
            this.tpSfcIcpMs.Controls.Add(this.btnClearDelay);
            this.tpSfcIcpMs.Controls.Add(this.label8);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxTime);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxM2);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxM1);
            this.tpSfcIcpMs.Controls.Add(this.txtBoxPh);
            this.tpSfcIcpMs.Controls.Add(this.label7);
            this.tpSfcIcpMs.Controls.Add(this.label6);
            this.tpSfcIcpMs.Controls.Add(this.label5);
            this.tpSfcIcpMs.Controls.Add(this.label4);
            this.tpSfcIcpMs.Controls.Add(this.lvSfc);
            this.tpSfcIcpMs.Controls.Add(this.lvIcpMs);
            this.tpSfcIcpMs.Controls.Add(this.lblLastTreatedML);
            this.tpSfcIcpMs.Controls.Add(this.btnTreatment);
            this.tpSfcIcpMs.Controls.Add(this.btnLoadIcpMsSfc);
            this.tpSfcIcpMs.Controls.Add(this.lblMeasureDatePane5);
            this.tpSfcIcpMs.Controls.Add(this.btnClearSfc);
            this.tpSfcIcpMs.Controls.Add(this.btnClearIcpMs);
            this.tpSfcIcpMs.Controls.Add(this.lblShift);
            this.tpSfcIcpMs.Controls.Add(this.labelShift);
            this.tpSfcIcpMs.Controls.Add(this.lblFlowrateSec);
            this.tpSfcIcpMs.Controls.Add(this.labelFlowrateSec);
            this.tpSfcIcpMs.Controls.Add(this.lblFlowrateMin);
            this.tpSfcIcpMs.Controls.Add(this.labelFlowrateMin);
            this.tpSfcIcpMs.Controls.Add(this.label2);
            this.tpSfcIcpMs.Controls.Add(this.label1);
            this.tpSfcIcpMs.Location = new System.Drawing.Point(4, 27);
            this.tpSfcIcpMs.Name = "tpSfcIcpMs";
            this.tpSfcIcpMs.Padding = new System.Windows.Forms.Padding(3);
            this.tpSfcIcpMs.Size = new System.Drawing.Size(1003, 476);
            this.tpSfcIcpMs.TabIndex = 3;
            this.tpSfcIcpMs.Text = "SFC-ICP-MS";
            // 
            // btnFindPeaks
            // 
            this.btnFindPeaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFindPeaks.Location = new System.Drawing.Point(370, 76);
            this.btnFindPeaks.Name = "btnFindPeaks";
            this.btnFindPeaks.Size = new System.Drawing.Size(114, 52);
            this.btnFindPeaks.TabIndex = 55;
            this.btnFindPeaks.Text = "Find Peaks";
            this.btnFindPeaks.UseVisualStyleBackColor = true;
            this.btnFindPeaks.Visible = false;
            this.btnFindPeaks.Click += new System.EventHandler(this.btnFindPeaks_Click);
            // 
            // lblConstSurface
            // 
            this.lblConstSurface.AutoSize = true;
            this.lblConstSurface.Location = new System.Drawing.Point(904, 241);
            this.lblConstSurface.Name = "lblConstSurface";
            this.lblConstSurface.Size = new System.Drawing.Size(44, 18);
            this.lblConstSurface.TabIndex = 54;
            this.lblConstSurface.Text = "cm^2";
            this.lblConstSurface.Visible = false;
            // 
            // txtBoxSurfaceML
            // 
            this.txtBoxSurfaceML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxSurfaceML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurfaceML.Location = new System.Drawing.Point(624, 210);
            this.txtBoxSurfaceML.Multiline = true;
            this.txtBoxSurfaceML.Name = "txtBoxSurfaceML";
            this.txtBoxSurfaceML.ReadOnly = true;
            this.txtBoxSurfaceML.Size = new System.Drawing.Size(42, 260);
            this.txtBoxSurfaceML.TabIndex = 53;
            // 
            // txtBoxDelayML
            // 
            this.txtBoxDelayML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxDelayML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxDelayML.Location = new System.Drawing.Point(422, 210);
            this.txtBoxDelayML.Multiline = true;
            this.txtBoxDelayML.Name = "txtBoxDelayML";
            this.txtBoxDelayML.ReadOnly = true;
            this.txtBoxDelayML.Size = new System.Drawing.Size(42, 260);
            this.txtBoxDelayML.TabIndex = 52;
            // 
            // txtBoxSurface
            // 
            this.txtBoxSurface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxSurface.Enabled = false;
            this.txtBoxSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurface.Location = new System.Drawing.Point(666, 210);
            this.txtBoxSurface.Multiline = true;
            this.txtBoxSurface.Name = "txtBoxSurface";
            this.txtBoxSurface.Size = new System.Drawing.Size(143, 260);
            this.txtBoxSurface.TabIndex = 51;
            // 
            // txtBoxDelay
            // 
            this.txtBoxDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxDelay.Enabled = false;
            this.txtBoxDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDelay.Location = new System.Drawing.Point(464, 210);
            this.txtBoxDelay.Multiline = true;
            this.txtBoxDelay.Name = "txtBoxDelay";
            this.txtBoxDelay.Size = new System.Drawing.Size(143, 260);
            this.txtBoxDelay.TabIndex = 50;
            // 
            // txtBoxConstantSurface
            // 
            this.txtBoxConstantSurface.Location = new System.Drawing.Point(821, 238);
            this.txtBoxConstantSurface.Name = "txtBoxConstantSurface";
            this.txtBoxConstantSurface.Size = new System.Drawing.Size(77, 24);
            this.txtBoxConstantSurface.TabIndex = 49;
            this.txtBoxConstantSurface.Visible = false;
            // 
            // cbSurfaceFinalTreatment
            // 
            this.cbSurfaceFinalTreatment.AutoSize = true;
            this.cbSurfaceFinalTreatment.Location = new System.Drawing.Point(821, 210);
            this.cbSurfaceFinalTreatment.Name = "cbSurfaceFinalTreatment";
            this.cbSurfaceFinalTreatment.Size = new System.Drawing.Size(176, 22);
            this.cbSurfaceFinalTreatment.TabIndex = 48;
            this.cbSurfaceFinalTreatment.Text = "Constant Surface Area";
            this.cbSurfaceFinalTreatment.UseVisualStyleBackColor = true;
            this.cbSurfaceFinalTreatment.Visible = false;
            this.cbSurfaceFinalTreatment.CheckedChanged += new System.EventHandler(this.cbSurface_CheckedChanged);
            // 
            // btnClearSurface
            // 
            this.btnClearSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearSurface.Location = new System.Drawing.Point(770, 165);
            this.btnClearSurface.Name = "btnClearSurface";
            this.btnClearSurface.Size = new System.Drawing.Size(60, 29);
            this.btnClearSurface.TabIndex = 46;
            this.btnClearSurface.Tag = "lvSurface";
            this.btnClearSurface.Text = "Clear";
            this.btnClearSurface.UseVisualStyleBackColor = true;
            this.btnClearSurface.Click += new System.EventHandler(this.btnClearSurface_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(621, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Surface Area (cm^2)";
            // 
            // btnClearDelay
            // 
            this.btnClearDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearDelay.Location = new System.Drawing.Point(547, 165);
            this.btnClearDelay.Name = "btnClearDelay";
            this.btnClearDelay.Size = new System.Drawing.Size(60, 29);
            this.btnClearDelay.TabIndex = 43;
            this.btnClearDelay.Tag = "lvDelay";
            this.btnClearDelay.Text = "Clear";
            this.btnClearDelay.UseVisualStyleBackColor = true;
            this.btnClearDelay.Click += new System.EventHandler(this.btnClearDelay_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Delay (s)";
            // 
            // txtBoxTime
            // 
            this.txtBoxTime.Location = new System.Drawing.Point(609, 110);
            this.txtBoxTime.Name = "txtBoxTime";
            this.txtBoxTime.Size = new System.Drawing.Size(75, 24);
            this.txtBoxTime.TabIndex = 41;
            // 
            // txtBoxM2
            // 
            this.txtBoxM2.Location = new System.Drawing.Point(609, 80);
            this.txtBoxM2.Name = "txtBoxM2";
            this.txtBoxM2.Size = new System.Drawing.Size(75, 24);
            this.txtBoxM2.TabIndex = 40;
            // 
            // txtBoxM1
            // 
            this.txtBoxM1.Location = new System.Drawing.Point(609, 50);
            this.txtBoxM1.Name = "txtBoxM1";
            this.txtBoxM1.Size = new System.Drawing.Size(75, 24);
            this.txtBoxM1.TabIndex = 39;
            // 
            // txtBoxPh
            // 
            this.txtBoxPh.Location = new System.Drawing.Point(609, 18);
            this.txtBoxPh.Name = "txtBoxPh";
            this.txtBoxPh.Size = new System.Drawing.Size(75, 24);
            this.txtBoxPh.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Time ( s):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(534, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "m2 ( g):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "m1 ( g):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "pH:";
            // 
            // lvSfc
            // 
            this.lvSfc.AllowDrop = true;
            this.lvSfc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvSfc.HideSelection = false;
            this.lvSfc.Location = new System.Drawing.Point(220, 210);
            this.lvSfc.Name = "lvSfc";
            this.lvSfc.Size = new System.Drawing.Size(185, 260);
            this.lvSfc.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSfc.TabIndex = 33;
            this.lvSfc.UseCompatibleStateImageBehavior = false;
            this.lvSfc.View = System.Windows.Forms.View.Details;
            this.lvSfc.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSfc_DragDrop);
            this.lvSfc.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSfc_DragEnter);
            // 
            // lvIcpMs
            // 
            this.lvIcpMs.AllowDrop = true;
            this.lvIcpMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvIcpMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvIcpMs.HideSelection = false;
            this.lvIcpMs.Location = new System.Drawing.Point(18, 210);
            this.lvIcpMs.Name = "lvIcpMs";
            this.lvIcpMs.Size = new System.Drawing.Size(185, 260);
            this.lvIcpMs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvIcpMs.TabIndex = 32;
            this.lvIcpMs.UseCompatibleStateImageBehavior = false;
            this.lvIcpMs.View = System.Windows.Forms.View.Details;
            this.lvIcpMs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvIcpMs_DragDrop);
            this.lvIcpMs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvIcpMs_DragEnter);
            // 
            // lblLastTreatedML
            // 
            this.lblLastTreatedML.AutoSize = true;
            this.lblLastTreatedML.Location = new System.Drawing.Point(15, 65);
            this.lblLastTreatedML.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastTreatedML.Name = "lblLastTreatedML";
            this.lblLastTreatedML.Size = new System.Drawing.Size(163, 18);
            this.lblLastTreatedML.TabIndex = 31;
            this.lblLastTreatedML.Text = "Last treated Macro List:";
            this.lblLastTreatedML.Visible = false;
            // 
            // btnTreatment
            // 
            this.btnTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTreatment.Location = new System.Drawing.Point(370, 18);
            this.btnTreatment.Name = "btnTreatment";
            this.btnTreatment.Size = new System.Drawing.Size(114, 52);
            this.btnTreatment.TabIndex = 25;
            this.btnTreatment.Text = "Treatment";
            this.btnTreatment.UseVisualStyleBackColor = true;
            this.btnTreatment.Visible = false;
            this.btnTreatment.Click += new System.EventHandler(this.btnTreatment_Click);
            // 
            // btnLoadIcpMsSfc
            // 
            this.btnLoadIcpMsSfc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadIcpMsSfc.Location = new System.Drawing.Point(295, 477);
            this.btnLoadIcpMsSfc.Name = "btnLoadIcpMsSfc";
            this.btnLoadIcpMsSfc.Size = new System.Drawing.Size(114, 52);
            this.btnLoadIcpMsSfc.TabIndex = 0;
            this.btnLoadIcpMsSfc.Text = "Load Single Element";
            this.btnLoadIcpMsSfc.UseVisualStyleBackColor = true;
            this.btnLoadIcpMsSfc.Click += new System.EventHandler(this.btnLoadSingleFile);
            // 
            // lblMeasureDatePane5
            // 
            this.lblMeasureDatePane5.AutoSize = true;
            this.lblMeasureDatePane5.Location = new System.Drawing.Point(15, 18);
            this.lblMeasureDatePane5.Name = "lblMeasureDatePane5";
            this.lblMeasureDatePane5.Size = new System.Drawing.Size(46, 18);
            this.lblMeasureDatePane5.TabIndex = 21;
            this.lblMeasureDatePane5.Text = "label3";
            this.lblMeasureDatePane5.Visible = false;
            // 
            // btnClearSfc
            // 
            this.btnClearSfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearSfc.Location = new System.Drawing.Point(345, 165);
            this.btnClearSfc.Name = "btnClearSfc";
            this.btnClearSfc.Size = new System.Drawing.Size(60, 29);
            this.btnClearSfc.TabIndex = 17;
            this.btnClearSfc.Tag = "lvSfc";
            this.btnClearSfc.Text = "Clear";
            this.btnClearSfc.UseVisualStyleBackColor = true;
            this.btnClearSfc.Click += new System.EventHandler(this.btnClearIcpMsSfc_Click);
            // 
            // btnClearIcpMs
            // 
            this.btnClearIcpMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClearIcpMs.Location = new System.Drawing.Point(143, 165);
            this.btnClearIcpMs.Name = "btnClearIcpMs";
            this.btnClearIcpMs.Size = new System.Drawing.Size(60, 27);
            this.btnClearIcpMs.TabIndex = 16;
            this.btnClearIcpMs.Tag = "lvIcpMs";
            this.btnClearIcpMs.Text = "Clear";
            this.btnClearIcpMs.UseVisualStyleBackColor = true;
            this.btnClearIcpMs.Click += new System.EventHandler(this.btnClearIcpMsSfc_Click);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(846, 78);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(46, 18);
            this.lblShift.TabIndex = 10;
            this.lblShift.Text = "label8";
            this.lblShift.Visible = false;
            // 
            // labelShift
            // 
            this.labelShift.AutoSize = true;
            this.labelShift.Location = new System.Drawing.Point(714, 79);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(102, 18);
            this.labelShift.TabIndex = 9;
            this.labelShift.Text = "Potential Shift:";
            this.labelShift.Visible = false;
            // 
            // lblFlowrateSec
            // 
            this.lblFlowrateSec.AutoSize = true;
            this.lblFlowrateSec.Location = new System.Drawing.Point(846, 49);
            this.lblFlowrateSec.Name = "lblFlowrateSec";
            this.lblFlowrateSec.Size = new System.Drawing.Size(46, 18);
            this.lblFlowrateSec.TabIndex = 8;
            this.lblFlowrateSec.Text = "label6";
            this.lblFlowrateSec.Visible = false;
            // 
            // labelFlowrateSec
            // 
            this.labelFlowrateSec.AutoSize = true;
            this.labelFlowrateSec.Location = new System.Drawing.Point(714, 47);
            this.labelFlowrateSec.Name = "labelFlowrateSec";
            this.labelFlowrateSec.Size = new System.Drawing.Size(110, 18);
            this.labelFlowrateSec.TabIndex = 7;
            this.labelFlowrateSec.Text = "Flowrate ( μl/s):";
            this.labelFlowrateSec.Visible = false;
            // 
            // lblFlowrateMin
            // 
            this.lblFlowrateMin.AutoSize = true;
            this.lblFlowrateMin.Location = new System.Drawing.Point(846, 16);
            this.lblFlowrateMin.Name = "lblFlowrateMin";
            this.lblFlowrateMin.Size = new System.Drawing.Size(46, 18);
            this.lblFlowrateMin.TabIndex = 6;
            this.lblFlowrateMin.Text = "label4";
            this.lblFlowrateMin.Visible = false;
            // 
            // labelFlowrateMin
            // 
            this.labelFlowrateMin.AutoSize = true;
            this.labelFlowrateMin.Location = new System.Drawing.Point(714, 16);
            this.labelFlowrateMin.Name = "labelFlowrateMin";
            this.labelFlowrateMin.Size = new System.Drawing.Size(126, 18);
            this.labelFlowrateMin.TabIndex = 5;
            this.labelFlowrateMin.Text = "Flowrate ( μl/min):";
            this.labelFlowrateMin.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ICP-MS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "SFC";
            // 
            // tpSfcIcpMsChart
            // 
            this.tpSfcIcpMsChart.BackColor = System.Drawing.SystemColors.Control;
            this.tpSfcIcpMsChart.Controls.Add(this.bntClearIcpMsSfcCharts);
            this.tpSfcIcpMsChart.Controls.Add(this.btnLoadSingle);
            this.tpSfcIcpMsChart.Controls.Add(this.btnLoadIcpMsSf);
            this.tpSfcIcpMsChart.Controls.Add(this.tabControl2);
            this.tpSfcIcpMsChart.Location = new System.Drawing.Point(4, 27);
            this.tpSfcIcpMsChart.Name = "tpSfcIcpMsChart";
            this.tpSfcIcpMsChart.Padding = new System.Windows.Forms.Padding(3);
            this.tpSfcIcpMsChart.Size = new System.Drawing.Size(1003, 476);
            this.tpSfcIcpMsChart.TabIndex = 4;
            this.tpSfcIcpMsChart.Text = "SFC-ICP-MS Chart";
            // 
            // bntClearIcpMsSfcCharts
            // 
            this.bntClearIcpMsSfcCharts.Location = new System.Drawing.Point(3, 148);
            this.bntClearIcpMsSfcCharts.Name = "bntClearIcpMsSfcCharts";
            this.bntClearIcpMsSfcCharts.Size = new System.Drawing.Size(111, 50);
            this.bntClearIcpMsSfcCharts.TabIndex = 28;
            this.bntClearIcpMsSfcCharts.Text = "Clear Charts";
            this.bntClearIcpMsSfcCharts.UseVisualStyleBackColor = true;
            this.bntClearIcpMsSfcCharts.Click += new System.EventHandler(this.bntClearIcpMsSfcCharts_Click);
            // 
            // btnLoadSingle
            // 
            this.btnLoadSingle.Location = new System.Drawing.Point(3, 92);
            this.btnLoadSingle.Name = "btnLoadSingle";
            this.btnLoadSingle.Size = new System.Drawing.Size(111, 50);
            this.btnLoadSingle.TabIndex = 27;
            this.btnLoadSingle.Text = "Load Single File";
            this.btnLoadSingle.UseVisualStyleBackColor = true;
            this.btnLoadSingle.Click += new System.EventHandler(this.btnLoadSingleFile);
            // 
            // btnLoadIcpMsSf
            // 
            this.btnLoadIcpMsSf.Location = new System.Drawing.Point(3, 36);
            this.btnLoadIcpMsSf.Name = "btnLoadIcpMsSf";
            this.btnLoadIcpMsSf.Size = new System.Drawing.Size(111, 50);
            this.btnLoadIcpMsSf.TabIndex = 26;
            this.btnLoadIcpMsSf.Text = "Load SFC-ICP-MS";
            this.btnLoadIcpMsSf.UseVisualStyleBackColor = true;
            this.btnLoadIcpMsSf.Click += new System.EventHandler(this.btnLoadIcpMsSf_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Location = new System.Drawing.Point(120, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(877, 464);
            this.tabControl2.TabIndex = 25;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.flpLoadE);
            this.tabPage8.Controls.Add(this.splitterE);
            this.tabPage8.Controls.Add(this.panel4);
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(869, 433);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "vs. E";
            // 
            // flpLoadE
            // 
            this.flpLoadE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLoadE.Location = new System.Drawing.Point(3, 215);
            this.flpLoadE.Name = "flpLoadE";
            this.flpLoadE.Size = new System.Drawing.Size(863, 215);
            this.flpLoadE.TabIndex = 2;
            // 
            // splitterE
            // 
            this.splitterE.BackColor = System.Drawing.Color.Black;
            this.splitterE.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterE.Location = new System.Drawing.Point(3, 207);
            this.splitterE.Name = "splitterE";
            this.splitterE.Size = new System.Drawing.Size(863, 8);
            this.splitterE.TabIndex = 1;
            this.splitterE.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flpIcpMsSfcE);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(863, 204);
            this.panel4.TabIndex = 0;
            // 
            // flpIcpMsSfcE
            // 
            this.flpIcpMsSfcE.AutoScroll = true;
            this.flpIcpMsSfcE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpIcpMsSfcE.Location = new System.Drawing.Point(0, 0);
            this.flpIcpMsSfcE.Name = "flpIcpMsSfcE";
            this.flpIcpMsSfcE.Size = new System.Drawing.Size(863, 204);
            this.flpIcpMsSfcE.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.flpLoadJ);
            this.tabPage9.Controls.Add(this.splitterJ);
            this.tabPage9.Controls.Add(this.flpIcpMsSfcJ);
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(869, 433);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "vs. j";
            // 
            // flpLoadJ
            // 
            this.flpLoadJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLoadJ.Location = new System.Drawing.Point(3, 206);
            this.flpLoadJ.Name = "flpLoadJ";
            this.flpLoadJ.Size = new System.Drawing.Size(863, 224);
            this.flpLoadJ.TabIndex = 2;
            // 
            // splitterJ
            // 
            this.splitterJ.BackColor = System.Drawing.Color.Black;
            this.splitterJ.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterJ.Location = new System.Drawing.Point(3, 198);
            this.splitterJ.Name = "splitterJ";
            this.splitterJ.Size = new System.Drawing.Size(863, 8);
            this.splitterJ.TabIndex = 1;
            this.splitterJ.TabStop = false;
            // 
            // flpIcpMsSfcJ
            // 
            this.flpIcpMsSfcJ.AutoScroll = true;
            this.flpIcpMsSfcJ.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpIcpMsSfcJ.Location = new System.Drawing.Point(3, 3);
            this.flpIcpMsSfcJ.Name = "flpIcpMsSfcJ";
            this.flpIcpMsSfcJ.Size = new System.Drawing.Size(863, 195);
            this.flpIcpMsSfcJ.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 531);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Data Treatment 9000";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.cmsFlpChart.ResumeLayout(false);
            this.tabContainer.ResumeLayout(false);
            this.tpCalibration.ResumeLayout(false);
            this.tpCalibration.PerformLayout();
            this.tpIcpMs.ResumeLayout(false);
            this.tpIcpMs.PerformLayout();
            this.tpSfc.ResumeLayout(false);
            this.pnlSfcBtnContainer.ResumeLayout(false);
            this.tabControlSfc.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tpSfcNorm.ResumeLayout(false);
            this.tpSfcNorm.PerformLayout();
            this.tpSfcIcpMs.ResumeLayout(false);
            this.tpSfcIcpMs.PerformLayout();
            this.tpSfcIcpMsChart.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip cmsFlpChart;
        private System.Windows.Forms.ToolStripMenuItem chooseColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tpCalibration;
        private System.Windows.Forms.TabPage tpIcpMs;
        private System.Windows.Forms.TabPage tpSfc;
        private System.Windows.Forms.Button btnLoadCalibration;
        private System.Windows.Forms.Button btnNewCalibration;
        private System.Windows.Forms.FlowLayoutPanel flpCalibration;
        private System.Windows.Forms.Button btnMacroListTreatment;
        private System.Windows.Forms.Button btnLoadTreatedML;
        private System.Windows.Forms.FlowLayoutPanel flpIcpMs;
        private System.Windows.Forms.TabPage tpSfcIcpMs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label labelShift;
        private System.Windows.Forms.Label lblFlowrateSec;
        private System.Windows.Forms.Label labelFlowrateSec;
        private System.Windows.Forms.Label lblFlowrateMin;
        private System.Windows.Forms.Label labelFlowrateMin;
        private System.Windows.Forms.Button btnClearSfc;
        private System.Windows.Forms.Button btnClearIcpMs;
        private System.Windows.Forms.Button btnDeleteCalibration;
        private System.Windows.Forms.Button btnDeleteTreatedMacroLists;
        private System.Windows.Forms.Label lblMeasureDatePane1;
        private System.Windows.Forms.Label lblMeasureDatePane2;
        private System.Windows.Forms.Label lblMeasureDatePane5;
        private System.Windows.Forms.TabControl tabControlSfc;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListView lvSingleFiles;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnLoadIcpMsSfc;
        private System.Windows.Forms.Button btnTreatment;
        private System.Windows.Forms.Panel pnlSfcIvsT;
        private System.Windows.Forms.Panel pnlSfcVvsT;
        private System.Windows.Forms.Panel pnlSfcIvsV;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lblLastTreatedML;
        private System.Windows.Forms.Button btnCalibrationInfo;
        private System.Windows.Forms.Panel pnlSfcBtnContainer;
        private System.Windows.Forms.Button btnClearAllFiles;
        private System.Windows.Forms.Button btnClearAllCharts;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnDeleteSelectedFiles;
        private System.Windows.Forms.Button btnAddSingleFiles;
        private System.Windows.Forms.ListView lvSfc;
        private System.Windows.Forms.ListView lvIcpMs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbICpMsElements;
        private System.Windows.Forms.TabPage tpSfcIcpMsChart;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.FlowLayoutPanel flpLoadE;
        private System.Windows.Forms.Splitter splitterE;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flpIcpMsSfcE;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.FlowLayoutPanel flpLoadJ;
        private System.Windows.Forms.Splitter splitterJ;
        private System.Windows.Forms.FlowLayoutPanel flpIcpMsSfcJ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbSurfaceFinalTreatment;
        private System.Windows.Forms.Button btnClearSurface;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxTime;
        private System.Windows.Forms.TextBox txtBoxM2;
        private System.Windows.Forms.TextBox txtBoxM1;
        private System.Windows.Forms.TextBox txtBoxPh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxConstantSurface;
        private System.Windows.Forms.TextBox txtBoxSurface;
        private System.Windows.Forms.TextBox txtBoxDelay;
        private System.Windows.Forms.TextBox txtBoxSurfaceML;
        private System.Windows.Forms.TextBox txtBoxDelayML;
        private System.Windows.Forms.Button btnLoadSingle;
        private System.Windows.Forms.Button btnLoadIcpMsSf;
        private System.Windows.Forms.Label lblConstSurface;
        private System.Windows.Forms.Button bntClearIcpMsSfcCharts;
        private System.Windows.Forms.Button btnFindPeaks;
        private System.Windows.Forms.TabPage tpSfcNorm;
        private System.Windows.Forms.Label lblConstMassNorm;
        private System.Windows.Forms.TextBox txtBoxSurfaceNormML;
        private System.Windows.Forms.TextBox txtBoxMassNormML;
        private System.Windows.Forms.TextBox txtBoxSurfaceNormalization;
        private System.Windows.Forms.TextBox txtBoxMassNormalization;
        private System.Windows.Forms.TextBox txtBoxConstantMassNorm;
        private System.Windows.Forms.CheckBox cbConstantMass;
        private System.Windows.Forms.Button btnClearSurfaceNorm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClearMassNorm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView lvSfcNormalization;
        private System.Windows.Forms.Button btnNormalization;
        private System.Windows.Forms.Button btnClearSfcNorm;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblConstSurfaceNorm;
        private System.Windows.Forms.TextBox txtBoxConstantSurfaceNorm;
        private System.Windows.Forms.CheckBox cbConstantSurface;
        private System.Windows.Forms.Label lblPhNorm;
        private System.Windows.Forms.TextBox txtBoxPhNormalization;
    }
}

