namespace PMDS.GUI
{
    partial class ucDatenErhebung
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.pnlErhebung = new QS2.Desktop.ControlManagment.BasePanel();
            this.cmbErhebung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlPflegeAnamnese = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlAnamnesePOP = new System.Windows.Forms.Panel();
            this.pnlAnamneseKrohwinkel = new System.Windows.Forms.Panel();
            this.pnlAnamneseOrem = new System.Windows.Forms.Panel();
            this.ucAnamneseBiografie1 = new PMDS.GUI.ucAnamneseBiografie();
            this.panelKeinRecht = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraLabel2 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.pnlErhebung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErhebung)).BeginInit();
            this.pnlPflegeAnamnese.SuspendLayout();
            this.panelKeinRecht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlErhebung
            // 
            this.pnlErhebung.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlErhebung.Controls.Add(this.cmbErhebung);
            this.pnlErhebung.Controls.Add(this.ultraLabel1);
            this.pnlErhebung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlErhebung.Location = new System.Drawing.Point(0, 0);
            this.pnlErhebung.Name = "pnlErhebung";
            this.pnlErhebung.Size = new System.Drawing.Size(1020, 29);
            this.pnlErhebung.TabIndex = 0;
            this.pnlErhebung.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlErhebung_Paint);
            // 
            // cmbErhebung
            // 
            this.cmbErhebung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbErhebung.Location = new System.Drawing.Point(160, 4);
            this.cmbErhebung.Name = "cmbErhebung";
            this.cmbErhebung.Size = new System.Drawing.Size(261, 21);
            this.cmbErhebung.TabIndex = 74;
            this.cmbErhebung.ValueChanged += new System.EventHandler(this.cmbErhebung_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(3, 7);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Erhebung";
            // 
            // pnlPflegeAnamnese
            // 
            this.pnlPflegeAnamnese.AutoScroll = true;
            this.pnlPflegeAnamnese.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPflegeAnamnese.Controls.Add(this.pnlAnamnesePOP);
            this.pnlPflegeAnamnese.Controls.Add(this.pnlAnamneseKrohwinkel);
            this.pnlPflegeAnamnese.Controls.Add(this.pnlAnamneseOrem);
            this.pnlPflegeAnamnese.Controls.Add(this.ucAnamneseBiografie1);
            this.pnlPflegeAnamnese.Controls.Add(this.panelKeinRecht);
            this.pnlPflegeAnamnese.Dock = System.Windows.Forms.DockStyle.Fill;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.pnlPflegeAnamnese, gridBagConstraint1);
            this.pnlPflegeAnamnese.Location = new System.Drawing.Point(0, 0);
            this.pnlPflegeAnamnese.Name = "pnlPflegeAnamnese";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.pnlPflegeAnamnese, new System.Drawing.Size(1020, 535));
            this.pnlPflegeAnamnese.Size = new System.Drawing.Size(1020, 536);
            this.pnlPflegeAnamnese.TabIndex = 1;
            this.pnlPflegeAnamnese.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPflegeAnamnese_Paint);
            // 
            // pnlAnamnesePOP
            // 
            this.pnlAnamnesePOP.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnamnesePOP.Location = new System.Drawing.Point(766, 170);
            this.pnlAnamnesePOP.Name = "pnlAnamnesePOP";
            this.pnlAnamnesePOP.Size = new System.Drawing.Size(158, 91);
            this.pnlAnamnesePOP.TabIndex = 111;
            this.pnlAnamnesePOP.Tag = "POP";
            // 
            // pnlAnamneseKrohwinkel
            // 
            this.pnlAnamneseKrohwinkel.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnamneseKrohwinkel.Location = new System.Drawing.Point(602, 170);
            this.pnlAnamneseKrohwinkel.Name = "pnlAnamneseKrohwinkel";
            this.pnlAnamneseKrohwinkel.Size = new System.Drawing.Size(158, 91);
            this.pnlAnamneseKrohwinkel.TabIndex = 111;
            this.pnlAnamneseKrohwinkel.Tag = "Krohwinkel";
            // 
            // pnlAnamneseOrem
            // 
            this.pnlAnamneseOrem.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnamneseOrem.Location = new System.Drawing.Point(438, 170);
            this.pnlAnamneseOrem.Name = "pnlAnamneseOrem";
            this.pnlAnamneseOrem.Size = new System.Drawing.Size(158, 91);
            this.pnlAnamneseOrem.TabIndex = 110;
            this.pnlAnamneseOrem.Tag = "OREM";
            // 
            // ucAnamneseBiografie1
            // 
            this.ucAnamneseBiografie1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucAnamneseBiografie1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAnamneseBiografie1.ISTOSAVE = false;
            this.ucAnamneseBiografie1.Location = new System.Drawing.Point(474, 23);
            this.ucAnamneseBiografie1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAnamneseBiografie1.Modell = PMDS.Global.PflegeModelle.Biografie;
            this.ucAnamneseBiografie1.Name = "ucAnamneseBiografie1";
            this.ucAnamneseBiografie1.ReadOnly = false;
            this.ucAnamneseBiografie1.Size = new System.Drawing.Size(300, 141);
            this.ucAnamneseBiografie1.TabIndex = 106;
            this.ucAnamneseBiografie1.Visible = false;
            this.ucAnamneseBiografie1.DataChanged += new PMDS.GUI.DataChangedDelegate(this.ucAnamneseBiografie1_DataChanged);
            // 
            // panelKeinRecht
            // 
            this.panelKeinRecht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKeinRecht.BackColor = System.Drawing.Color.Transparent;
            this.panelKeinRecht.Controls.Add(this.ultraLabel2);
            this.panelKeinRecht.Location = new System.Drawing.Point(474, 350);
            this.panelKeinRecht.Name = "panelKeinRecht";
            this.panelKeinRecht.Size = new System.Drawing.Size(312, 133);
            this.panelKeinRecht.TabIndex = 105;
            this.panelKeinRecht.Visible = false;
            // 
            // ultraLabel2
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance1;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(13, 12);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(265, 17);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Text = "Sie dürfen keine Datenerhebung ansehen.";
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGridBagLayoutPanel1.Controls.Add(this.pnlPflegeAnamnese);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(1020, 536);
            this.ultraGridBagLayoutPanel1.TabIndex = 2;
            // 
            // ucDatenErhebung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.pnlErhebung);
            this.Name = "ucDatenErhebung";
            this.Size = new System.Drawing.Size(1020, 565);
            this.VisibleChanged += new System.EventHandler(this.ucDatenErhebung_VisibleChanged);
            this.Resize += new System.EventHandler(this.ucDatenErhebung_Resize);
            this.pnlErhebung.ResumeLayout(false);
            this.pnlErhebung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErhebung)).EndInit();
            this.pnlPflegeAnamnese.ResumeLayout(false);
            this.panelKeinRecht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlErhebung;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BasePanel pnlPflegeAnamnese;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbErhebung;
        private QS2.Desktop.ControlManagment.BasePanel panelKeinRecht;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel2;
        private ucAnamneseBiografie ucAnamneseBiografie1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private System.Windows.Forms.Panel pnlAnamnesePOP;
        private System.Windows.Forms.Panel pnlAnamneseKrohwinkel;
        private System.Windows.Forms.Panel pnlAnamneseOrem;
    }
}
