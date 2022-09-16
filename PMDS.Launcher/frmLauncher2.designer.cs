namespace Launcher
{
    partial class frmLauncher2
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher2));
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wiederherstellenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btn_RemovePMDS = new System.Windows.Forms.Button();
            this.btn_OF = new System.Windows.Forms.Button();
            this.btn_Peps = new System.Windows.Forms.Button();
            this.btn_QM = new System.Windows.Forms.Button();
            this.btn_Abrechnung = new System.Windows.Forms.Button();
            this.btn_PMDS = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbPasswort = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotify.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Benutzer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Passwort";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.mnuNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PMDS Starter";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // mnuNotify
            // 
            this.mnuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wiederherstellenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beendenToolStripMenuItem1,
            this.toTopToolStripMenuItem});
            this.mnuNotify.Name = "mnuNotify";
            this.mnuNotify.Size = new System.Drawing.Size(182, 76);
            this.mnuNotify.DoubleClick += new System.EventHandler(this.mnuNotify_DoubleClick);
            // 
            // wiederherstellenToolStripMenuItem
            // 
            this.wiederherstellenToolStripMenuItem.Name = "wiederherstellenToolStripMenuItem";
            this.wiederherstellenToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.wiederherstellenToolStripMenuItem.Text = "PMDS Starter öffnen";
            this.wiederherstellenToolStripMenuItem.Click += new System.EventHandler(this.wiederherstellenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // beendenToolStripMenuItem1
            // 
            this.beendenToolStripMenuItem1.Name = "beendenToolStripMenuItem1";
            this.beendenToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.beendenToolStripMenuItem1.Text = "Beenden";
            this.beendenToolStripMenuItem1.Click += new System.EventHandler(this.beendenToolStripMenuItem1_Click);
            // 
            // toTopToolStripMenuItem
            // 
            this.toTopToolStripMenuItem.Name = "toTopToolStripMenuItem";
            this.toTopToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.toTopToolStripMenuItem.Text = "toTop";
            this.toTopToolStripMenuItem.Click += new System.EventHandler(this.toTopToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 401);
            this.panel4.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelButtons);
            this.panel3.Location = new System.Drawing.Point(16, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 275);
            this.panel3.TabIndex = 12;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btn_RemovePMDS);
            this.panelButtons.Controls.Add(this.btn_OF);
            this.panelButtons.Controls.Add(this.btn_Peps);
            this.panelButtons.Controls.Add(this.btn_QM);
            this.panelButtons.Controls.Add(this.btn_Abrechnung);
            this.panelButtons.Controls.Add(this.btn_PMDS);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(247, 275);
            this.panelButtons.TabIndex = 11;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtons_Paint);
            // 
            // btn_RemovePMDS
            // 
            this.btn_RemovePMDS.BackColor = System.Drawing.Color.Transparent;
            this.btn_RemovePMDS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_RemovePMDS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemovePMDS.ForeColor = System.Drawing.Color.Red;
            this.btn_RemovePMDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RemovePMDS.Location = new System.Drawing.Point(0, 225);
            this.btn_RemovePMDS.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RemovePMDS.Name = "btn_RemovePMDS";
            this.btn_RemovePMDS.Size = new System.Drawing.Size(247, 45);
            this.btn_RemovePMDS.TabIndex = 11;
            this.btn_RemovePMDS.Tag = "BUTTON_PMDS_REMOVE";
            this.btn_RemovePMDS.Text = "PMDS entfernen";
            this.btn_RemovePMDS.UseVisualStyleBackColor = false;
            this.btn_RemovePMDS.Visible = false;
            this.btn_RemovePMDS.Click += new System.EventHandler(this.buttClick);
            // 
            // btn_OF
            // 
            this.btn_OF.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_OF.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OF.Location = new System.Drawing.Point(0, 180);
            this.btn_OF.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OF.Name = "btn_OF";
            this.btn_OF.Size = new System.Drawing.Size(247, 45);
            this.btn_OF.TabIndex = 10;
            this.btn_OF.Tag = "BUTTON_FORMS";
            this.btn_OF.Text = "Online-Formulare";
            this.btn_OF.UseVisualStyleBackColor = true;
            this.btn_OF.Visible = false;
            this.btn_OF.Click += new System.EventHandler(this.buttClick);
            // 
            // btn_Peps
            // 
            this.btn_Peps.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Peps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Peps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Peps.Location = new System.Drawing.Point(0, 135);
            this.btn_Peps.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Peps.Name = "btn_Peps";
            this.btn_Peps.Size = new System.Drawing.Size(247, 45);
            this.btn_Peps.TabIndex = 9;
            this.btn_Peps.Tag = "BUTTON_PEPS";
            this.btn_Peps.Text = "PEPS";
            this.btn_Peps.UseVisualStyleBackColor = true;
            this.btn_Peps.Visible = false;
            this.btn_Peps.Click += new System.EventHandler(this.buttClick);
            // 
            // btn_QM
            // 
            this.btn_QM.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_QM.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QM.Location = new System.Drawing.Point(0, 90);
            this.btn_QM.Margin = new System.Windows.Forms.Padding(4);
            this.btn_QM.Name = "btn_QM";
            this.btn_QM.Size = new System.Drawing.Size(247, 45);
            this.btn_QM.TabIndex = 8;
            this.btn_QM.Tag = "BUTTON_TOUCHDOKU";
            this.btn_QM.Text = "Touchdoku";
            this.btn_QM.UseVisualStyleBackColor = true;
            this.btn_QM.Visible = false;
            this.btn_QM.Click += new System.EventHandler(this.buttClick);
            // 
            // btn_Abrechnung
            // 
            this.btn_Abrechnung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Abrechnung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Abrechnung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Abrechnung.Location = new System.Drawing.Point(0, 45);
            this.btn_Abrechnung.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Abrechnung.Name = "btn_Abrechnung";
            this.btn_Abrechnung.Size = new System.Drawing.Size(247, 45);
            this.btn_Abrechnung.TabIndex = 5;
            this.btn_Abrechnung.Tag = "BUTTON_ABRECHNUNG";
            this.btn_Abrechnung.Text = "Abrechnung";
            this.btn_Abrechnung.UseVisualStyleBackColor = true;
            this.btn_Abrechnung.Visible = false;
            this.btn_Abrechnung.Click += new System.EventHandler(this.buttClick);
            // 
            // btn_PMDS
            // 
            this.btn_PMDS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_PMDS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PMDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PMDS.Location = new System.Drawing.Point(0, 0);
            this.btn_PMDS.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PMDS.Name = "btn_PMDS";
            this.btn_PMDS.Size = new System.Drawing.Size(247, 45);
            this.btn_PMDS.TabIndex = 4;
            this.btn_PMDS.Tag = "BUTTON_PMDS";
            this.btn_PMDS.Text = "PMDS starten";
            this.btn_PMDS.UseVisualStyleBackColor = true;
            this.btn_PMDS.Visible = false;
            this.btn_PMDS.Click += new System.EventHandler(this.buttClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tbPasswort);
            this.panel2.Controls.Add(this.tbUser);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 97);
            this.panel2.TabIndex = 0;
            // 
            // tbPasswort
            // 
            this.tbPasswort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPasswort.Location = new System.Drawing.Point(106, 61);
            this.tbPasswort.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswort.Name = "tbPasswort";
            this.tbPasswort.Size = new System.Drawing.Size(158, 24);
            this.tbPasswort.TabIndex = 1;
            this.tbPasswort.UseSystemPasswordChar = true;
            this.tbPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPasswort_KeyDown);
            // 
            // tbUser
            // 
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbUser.Location = new System.Drawing.Point(106, 25);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(158, 24);
            this.tbUser.TabIndex = 0;
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewerToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.beendenToolStripMenuItem3});
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem1.Text = "Datei";
            // 
            // logViewerToolStripMenuItem1
            // 
            this.logViewerToolStripMenuItem1.Name = "logViewerToolStripMenuItem1";
            this.logViewerToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.logViewerToolStripMenuItem1.Text = "Log-Viewer";
            this.logViewerToolStripMenuItem1.Click += new System.EventHandler(this.logViewerToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 6);
            // 
            // beendenToolStripMenuItem3
            // 
            this.beendenToolStripMenuItem3.Name = "beendenToolStripMenuItem3";
            this.beendenToolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
            this.beendenToolStripMenuItem3.Text = "Beenden";
            // 
            // frmLauncher2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(278, 402);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmLauncher2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMDS Starter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.launcher_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.launcher_SizeChanged);
            this.mnuNotify.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip mnuNotify;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wiederherstellenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_QM;
        private System.Windows.Forms.Button btn_Abrechnung;
        private System.Windows.Forms.Button btn_PMDS;
        private System.Windows.Forms.Button btn_OF;
        private System.Windows.Forms.Button btn_Peps;
        private System.Windows.Forms.TextBox tbPasswort;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem toTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logViewerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem3;
        private System.Windows.Forms.Button btn_RemovePMDS;
    }
}

