namespace PMDS.GUI.BaseControls
{
    partial class ucKlientenElement
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlientenElement));
            this.picButtSingle = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.btnClick = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraButton1 = new QS2.Desktop.ControlManagment.BaseButton();
            this.uGridLayKlient = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.historischeDatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.uGridLayKlient)).BeginInit();
            this.uGridLayKlient.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picButtSingle
            // 
            this.picButtSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(4)))));
            this.picButtSingle.Appearance = appearance1;
            this.picButtSingle.BackColor = System.Drawing.Color.Transparent;
            this.picButtSingle.BorderShadowColor = System.Drawing.Color.Empty;
            this.picButtSingle.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Bottom = 2;
            gridBagConstraint2.Insets.Left = 2;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 2;
            gridBagConstraint2.OriginX = 1;
            gridBagConstraint2.OriginY = 0;
            this.uGridLayKlient.SetGridBagConstraint(this.picButtSingle, gridBagConstraint2);
            this.picButtSingle.Location = new System.Drawing.Point(110, 2);
            this.picButtSingle.Name = "picButtSingle";
            this.uGridLayKlient.SetPreferredSize(this.picButtSingle, new System.Drawing.Size(21, 33));
            this.picButtSingle.Size = new System.Drawing.Size(20, 23);
            this.picButtSingle.TabIndex = 38;
            this.picButtSingle.Tag = "";
            this.picButtSingle.UseAppStyling = false;
            this.picButtSingle.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.picButtSingle.Visible = false;
            this.picButtSingle.Click += new System.EventHandler(this.picButtSingle_Click);
            // 
            // btnClick
            // 
            appearance2.TextHAlignAsString = "Left";
            this.btnClick.Appearance = appearance2;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 2;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Top = 2;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.uGridLayKlient.SetGridBagConstraint(this.btnClick, gridBagConstraint1);
            this.btnClick.Location = new System.Drawing.Point(5, 2);
            this.btnClick.Name = "btnClick";
            this.uGridLayKlient.SetPreferredSize(this.btnClick, new System.Drawing.Size(105, 36));
            this.btnClick.ShowFocusRect = false;
            this.btnClick.ShowOutline = false;
            this.btnClick.Size = new System.Drawing.Size(103, 23);
            this.btnClick.TabIndex = 34;
            this.btnClick.TabStop = false;
            this.btnClick.Text = "ultraButton1";
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            this.btnClick.MouseEnter += new System.EventHandler(this.btnClick_MouseEnter);
            // 
            // ultraButton1
            // 
            appearance3.TextHAlignAsString = "Left";
            this.ultraButton1.Appearance = appearance3;
            this.ultraButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraButton1.Location = new System.Drawing.Point(0, 0);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.ShowFocusRect = false;
            this.ultraButton1.ShowOutline = false;
            this.ultraButton1.Size = new System.Drawing.Size(109, 31);
            this.ultraButton1.TabIndex = 34;
            this.ultraButton1.TabStop = false;
            this.ultraButton1.Text = "ultraButton1";
            this.ultraButton1.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // uGridLayKlient
            // 
            this.uGridLayKlient.Controls.Add(this.picButtSingle);
            this.uGridLayKlient.Controls.Add(this.btnClick);
            this.uGridLayKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridLayKlient.ExpandToFitHeight = true;
            this.uGridLayKlient.ExpandToFitWidth = true;
            this.uGridLayKlient.Location = new System.Drawing.Point(0, 0);
            this.uGridLayKlient.Name = "uGridLayKlient";
            this.uGridLayKlient.Size = new System.Drawing.Size(135, 27);
            this.uGridLayKlient.TabIndex = 40;
            this.uGridLayKlient.MouseEnter += new System.EventHandler(this.uGridLayKlient_MouseEnter);
            this.uGridLayKlient.MouseLeave += new System.EventHandler(this.mouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historischeDatenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 26);
            // 
            // historischeDatenToolStripMenuItem
            // 
            this.historischeDatenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("historischeDatenToolStripMenuItem.Image")));
            this.historischeDatenToolStripMenuItem.Name = "historischeDatenToolStripMenuItem";
            this.historischeDatenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.historischeDatenToolStripMenuItem.Text = "Historische Daten zu Klient";
            this.historischeDatenToolStripMenuItem.Click += new System.EventHandler(this.historischeDatenToolStripMenuItem_Click);
            // 
            // ucKlientenElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.uGridLayKlient);
            this.Name = "ucKlientenElement";
            this.Size = new System.Drawing.Size(135, 27);
            this.Tag = "";
            this.MouseEnter += new System.EventHandler(this.ucKlientenElement_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucKlientenElement_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.uGridLayKlient)).EndInit();
            this.uGridLayKlient.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnClick;
        public Infragistics.Win.UltraWinEditors.UltraPictureBox picButtSingle;
        public QS2.Desktop.ControlManagment.BaseButton ultraButton1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridLayKlient;
        private System.Windows.Forms.ToolStripMenuItem historischeDatenToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

    }
}
