namespace TMU_Terminal
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.dlgPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.docPrint = new System.Drawing.Printing.PrintDocument();
            this.dlgPageSetup = new System.Windows.Forms.PageSetupDialog();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFilePageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.chkSig1 = new System.Windows.Forms.CheckBox();
            this.chkSig3 = new System.Windows.Forms.CheckBox();
            this.chkSig2 = new System.Windows.Forms.CheckBox();
            this.chkSig4 = new System.Windows.Forms.CheckBox();
            this.chkSig5 = new System.Windows.Forms.CheckBox();
            this.txtSig1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSig5 = new System.Windows.Forms.TextBox();
            this.txtSig4 = new System.Windows.Forms.TextBox();
            this.txtSig3 = new System.Windows.Forms.TextBox();
            this.txtSig2 = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOnline = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWeapon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.comport = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Timers.Timer();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 26);
            this.label1.TabIndex = 46;
            this.label1.Text = "T I M E   M E A S U R I N G   U N I T   I N T E R F A C E";
            // 
            // dlgPrintPreview
            // 
            this.dlgPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgPrintPreview.Document = this.docPrint;
            this.dlgPrintPreview.Enabled = true;
            this.dlgPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPrintPreview.Icon")));
            this.dlgPrintPreview.Name = "dlgPrintPreview";
            this.dlgPrintPreview.Visible = false;
            // 
            // docPrint
            // 
            this.docPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.docPrint_PrintPage);
            // 
            // dlgPageSetup
            // 
            this.dlgPageSetup.Document = this.docPrint;
            // 
            // dlgPrint
            // 
            this.dlgPrint.Document = this.docPrint;
            this.dlgPrint.UseEXDialog = true;
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "krno";
            this.dlgSave.Filter = "Chrono Files (*.tmu)|*.tmu|All Files|";
            this.dlgSave.Title = "Save TMU Files";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewFile,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.toolStripSeparator1,
            this.mnuFilePageSetup,
            this.mnuFilePrint,
            this.toolStripSeparator2,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewFile
            // 
            this.mnuNewFile.Name = "mnuNewFile";
            this.mnuNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewFile.Size = new System.Drawing.Size(168, 22);
            this.mnuNewFile.Text = "&New Test";
            this.mnuNewFile.ToolTipText = "Reset the whole experiment as new";
            this.mnuNewFile.Click += new System.EventHandler(this.mnuNewFile_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(168, 22);
            this.mnuFileOpen.Text = "&Open File";
            this.mnuFileOpen.ToolTipText = "Open an old *.krno file (if already saved)";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(168, 22);
            this.mnuFileSave.Text = "&Save File";
            this.mnuFileSave.ToolTipText = "Save experiment as *.krno file";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuFilePageSetup
            // 
            this.mnuFilePageSetup.Name = "mnuFilePageSetup";
            this.mnuFilePageSetup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuFilePageSetup.Size = new System.Drawing.Size(168, 22);
            this.mnuFilePageSetup.Text = "Pa&ge Setup";
            this.mnuFilePageSetup.ToolTipText = "Set page setup for printing";
            this.mnuFilePageSetup.Click += new System.EventHandler(this.mnuFilePageSetup_Click);
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(168, 22);
            this.mnuFilePrint.Text = "&Print";
            this.mnuFilePrint.ToolTipText = "Send print to a particular printer";
            this.mnuFilePrint.Click += new System.EventHandler(this.mnuFilePrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileExit.Size = new System.Drawing.Size(168, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.ToolTipText = "Close the application";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuAbout.Size = new System.Drawing.Size(154, 22);
            this.mnuAbout.Text = "About...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "rpr";
            this.dlgOpen.FileName = "openFileDialog1";
            this.dlgOpen.Filter = "TMU Files (*.tmu)|*.tmu|All Files|";
            this.dlgOpen.Title = "Open Existing TMU Files";
            // 
            // chkSig1
            // 
            this.chkSig1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSig1.AutoSize = true;
            this.chkSig1.Checked = true;
            this.chkSig1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSig1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSig1.Location = new System.Drawing.Point(14, 20);
            this.chkSig1.Name = "chkSig1";
            this.chkSig1.Size = new System.Drawing.Size(33, 17);
            this.chkSig1.TabIndex = 33;
            this.chkSig1.Text = "1";
            this.chkSig1.UseVisualStyleBackColor = true;
            // 
            // chkSig3
            // 
            this.chkSig3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSig3.AutoSize = true;
            this.chkSig3.Checked = true;
            this.chkSig3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSig3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSig3.Location = new System.Drawing.Point(14, 108);
            this.chkSig3.Name = "chkSig3";
            this.chkSig3.Size = new System.Drawing.Size(33, 17);
            this.chkSig3.TabIndex = 34;
            this.chkSig3.Text = "3";
            this.chkSig3.UseVisualStyleBackColor = true;
            // 
            // chkSig2
            // 
            this.chkSig2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSig2.AutoSize = true;
            this.chkSig2.Checked = true;
            this.chkSig2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSig2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSig2.Location = new System.Drawing.Point(14, 64);
            this.chkSig2.Name = "chkSig2";
            this.chkSig2.Size = new System.Drawing.Size(33, 17);
            this.chkSig2.TabIndex = 35;
            this.chkSig2.Text = "2";
            this.chkSig2.UseVisualStyleBackColor = true;
            // 
            // chkSig4
            // 
            this.chkSig4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSig4.AutoSize = true;
            this.chkSig4.Checked = true;
            this.chkSig4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSig4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSig4.Location = new System.Drawing.Point(14, 152);
            this.chkSig4.Name = "chkSig4";
            this.chkSig4.Size = new System.Drawing.Size(33, 17);
            this.chkSig4.TabIndex = 36;
            this.chkSig4.Text = "4";
            this.chkSig4.UseVisualStyleBackColor = true;
            // 
            // chkSig5
            // 
            this.chkSig5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSig5.AutoSize = true;
            this.chkSig5.Checked = true;
            this.chkSig5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkSig5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSig5.Location = new System.Drawing.Point(14, 196);
            this.chkSig5.Name = "chkSig5";
            this.chkSig5.Size = new System.Drawing.Size(33, 17);
            this.chkSig5.TabIndex = 37;
            this.chkSig5.Text = "5";
            this.chkSig5.UseVisualStyleBackColor = true;
            // 
            // txtSig1
            // 
            this.txtSig1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSig1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSig1.Location = new System.Drawing.Point(60, 18);
            this.txtSig1.MaxLength = 22;
            this.txtSig1.Name = "txtSig1";
            this.txtSig1.Size = new System.Drawing.Size(162, 20);
            this.txtSig1.TabIndex = 7;
            this.txtSig1.Text = "Observer No. 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtSig5);
            this.groupBox2.Controls.Add(this.txtSig4);
            this.groupBox2.Controls.Add(this.txtSig3);
            this.groupBox2.Controls.Add(this.txtSig2);
            this.groupBox2.Controls.Add(this.txtSig1);
            this.groupBox2.Controls.Add(this.chkSig5);
            this.groupBox2.Controls.Add(this.chkSig4);
            this.groupBox2.Controls.Add(this.chkSig2);
            this.groupBox2.Controls.Add(this.chkSig3);
            this.groupBox2.Controls.Add(this.chkSig1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 223);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Signatures";
            // 
            // txtSig5
            // 
            this.txtSig5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSig5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSig5.Location = new System.Drawing.Point(60, 194);
            this.txtSig5.MaxLength = 22;
            this.txtSig5.Name = "txtSig5";
            this.txtSig5.Size = new System.Drawing.Size(162, 20);
            this.txtSig5.TabIndex = 11;
            this.txtSig5.Text = "Option Observer";
            // 
            // txtSig4
            // 
            this.txtSig4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSig4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSig4.Location = new System.Drawing.Point(60, 150);
            this.txtSig4.MaxLength = 22;
            this.txtSig4.Name = "txtSig4";
            this.txtSig4.Size = new System.Drawing.Size(162, 20);
            this.txtSig4.TabIndex = 10;
            this.txtSig4.Text = "Observer No. 4";
            // 
            // txtSig3
            // 
            this.txtSig3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSig3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSig3.Location = new System.Drawing.Point(60, 106);
            this.txtSig3.MaxLength = 22;
            this.txtSig3.Name = "txtSig3";
            this.txtSig3.Size = new System.Drawing.Size(162, 20);
            this.txtSig3.TabIndex = 9;
            this.txtSig3.Text = "Observer No. 3";
            // 
            // txtSig2
            // 
            this.txtSig2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSig2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSig2.Location = new System.Drawing.Point(60, 62);
            this.txtSig2.MaxLength = 22;
            this.txtSig2.Name = "txtSig2";
            this.txtSig2.Size = new System.Drawing.Size(162, 20);
            this.txtSig2.TabIndex = 8;
            this.txtSig2.Text = "Observer No. 2";
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtResult.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(6, 15);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(469, 231);
            this.txtResult.TabIndex = 44;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(252, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(484, 252);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " S#      Time            Ch#1          Ch#2          Ch#3         Ch#4         Ji" +
                "tter";
            // 
            // txtOnline
            // 
            this.txtOnline.AcceptsReturn = true;
            this.txtOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOnline.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtOnline.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnline.Location = new System.Drawing.Point(6, 16);
            this.txtOnline.Multiline = true;
            this.txtOnline.Name = "txtOnline";
            this.txtOnline.ReadOnly = true;
            this.txtOnline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOnline.Size = new System.Drawing.Size(469, 96);
            this.txtOnline.TabIndex = 45;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtOnline);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(252, 371);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(484, 119);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Online Terminal";
            // 
            // cmbPortName
            // 
            this.cmbPortName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(76, 23);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(146, 21);
            this.cmbPortName.TabIndex = 1;
            // 
            // txtTestName
            // 
            this.txtTestName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestName.Location = new System.Drawing.Point(76, 61);
            this.txtTestName.MaxLength = 10;
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(146, 20);
            this.txtTestName.TabIndex = 4;
            this.txtTestName.Text = "NIL";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Com Port";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Test Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtWeapon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtComments);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTestName);
            this.groupBox1.Controls.Add(this.cmbPortName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 179);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Experiment Settings";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Weapon#";
            // 
            // txtWeapon
            // 
            this.txtWeapon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeapon.Location = new System.Drawing.Point(76, 99);
            this.txtWeapon.MaxLength = 10;
            this.txtWeapon.Name = "txtWeapon";
            this.txtWeapon.Size = new System.Drawing.Size(144, 20);
            this.txtWeapon.TabIndex = 34;
            this.txtWeapon.Text = "WP-01";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(76, 138);
            this.txtComments.MaxLength = 50;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(144, 20);
            this.txtComments.TabIndex = 32;
            this.txtComments.Text = "Results are satisfactory";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(410, 334);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(197, 26);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "&Ready";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // comport
            // 
            this.comport.Handshake = System.IO.Ports.Handshake.RequestToSend;
            this.comport.StopBits = System.IO.Ports.StopBits.Two;
            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comport_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 506);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "TMU-01";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Evaluation_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintPreviewDialog dlgPrintPreview;
        private System.Drawing.Printing.PrintDocument docPrint;
        private System.Windows.Forms.PageSetupDialog dlgPageSetup;
        private System.Windows.Forms.PrintDialog dlgPrint;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePageSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox chkSig1;
        private System.Windows.Forms.CheckBox chkSig3;
        private System.Windows.Forms.CheckBox chkSig2;
        private System.Windows.Forms.CheckBox chkSig4;
        private System.Windows.Forms.CheckBox chkSig5;
        private System.Windows.Forms.TextBox txtSig1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSig5;
        private System.Windows.Forms.TextBox txtSig4;
        private System.Windows.Forms.TextBox txtSig3;
        private System.Windows.Forms.TextBox txtSig2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtOnline;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort comport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComments;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWeapon;
    }
}

