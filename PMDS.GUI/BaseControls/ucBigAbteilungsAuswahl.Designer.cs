namespace PMDS.GUI.BaseControls
{
    partial class ucBigAbteilungsAuswahl
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
            this.btnAbteilung = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlAbtListeGesamt = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlAbtList = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlKliniken = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucBigComboBoxKliniken1 = new PMDS.GUI.BaseControls.ucBigComboBoxKliniken();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelAbteilungBereich = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.pnlAbtListeGesamt.SuspendLayout();
            this.pnlKliniken.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbteilung
            // 
            appearance1.ForeColor = System.Drawing.Color.Blue;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.btnAbteilung.Appearance = appearance1;
            this.btnAbteilung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnAbteilung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbteilung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbteilung.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAbteilung.Location = new System.Drawing.Point(0, 0);
            this.btnAbteilung.Name = "btnAbteilung";
            this.btnAbteilung.PopupItemKey = "pnlAbtList";
            this.btnAbteilung.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnAbteilung.ShowFocusRect = false;
            this.btnAbteilung.Size = new System.Drawing.Size(196, 94);
            this.btnAbteilung.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnAbteilung.TabIndex = 0;
            this.btnAbteilung.Text = "*********";
            this.btnAbteilung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAbteilung.Click += new System.EventHandler(this.btnAbteilung_Click);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlAbtListeGesamt;
            this.ultraPopupControlContainer1.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer1_Opening);
            this.ultraPopupControlContainer1.Closed += new System.EventHandler(this.ultraPopupControlContainer1_Closed);
            // 
            // pnlAbtListeGesamt
            // 
            this.pnlAbtListeGesamt.Controls.Add(this.pnlAbtList);
            this.pnlAbtListeGesamt.Controls.Add(this.pnlKliniken);
            this.pnlAbtListeGesamt.Location = new System.Drawing.Point(7, 100);
            this.pnlAbtListeGesamt.Name = "pnlAbtListeGesamt";
            this.pnlAbtListeGesamt.Size = new System.Drawing.Size(406, 166);
            this.pnlAbtListeGesamt.TabIndex = 5;
            this.pnlAbtListeGesamt.Visible = false;
            // 
            // pnlAbtList
            // 
            this.pnlAbtList.AutoScroll = true;
            this.pnlAbtList.AutoSize = true;
            this.pnlAbtList.BackColor = System.Drawing.Color.Transparent;
            this.pnlAbtList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAbtList.ContextMenuStrip = this.contextMenuStrip1;
            this.pnlAbtList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAbtList.Location = new System.Drawing.Point(0, 35);
            this.pnlAbtList.Name = "pnlAbtList";
            this.pnlAbtList.Size = new System.Drawing.Size(406, 131);
            this.pnlAbtList.TabIndex = 5;
            this.pnlAbtList.Visible = false;
            // 
            // pnlKliniken
            // 
            this.pnlKliniken.ContextMenuStrip = this.contextMenuStrip1;
            this.pnlKliniken.Controls.Add(this.ucBigComboBoxKliniken1);
            this.pnlKliniken.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKliniken.Location = new System.Drawing.Point(0, 0);
            this.pnlKliniken.Name = "pnlKliniken";
            this.pnlKliniken.Size = new System.Drawing.Size(406, 35);
            this.pnlKliniken.TabIndex = 3;
            this.pnlKliniken.Visible = false;
            // 
            // ucBigComboBoxKliniken1
            // 
            this.ucBigComboBoxKliniken1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBigComboBoxKliniken1.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucBigComboBoxKliniken1.Location = new System.Drawing.Point(0, 0);
            this.ucBigComboBoxKliniken1.Name = "ucBigComboBoxKliniken1";
            this.ucBigComboBoxKliniken1.PlayClickSound = true;
            this.ucBigComboBoxKliniken1.SelectedItem = null;
            this.ucBigComboBoxKliniken1.Size = new System.Drawing.Size(406, 35);
            this.ucBigComboBoxKliniken1.TabIndex = 0;
            this.ucBigComboBoxKliniken1.SelectionChanged += new System.EventHandler(this.ucBigComboBoxKliniken1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuLadenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // neuLadenToolStripMenuItem
            // 
            this.neuLadenToolStripMenuItem.Name = "neuLadenToolStripMenuItem";
            this.neuLadenToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.neuLadenToolStripMenuItem.Text = "Neu laden";
            this.neuLadenToolStripMenuItem.Click += new System.EventHandler(this.neuLadenToolStripMenuItem_Click);
            // 
            // labelAbteilungBereich
            // 
            this.labelAbteilungBereich.AutoSize = true;
            this.labelAbteilungBereich.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbteilungBereich.Location = new System.Drawing.Point(4, 4);
            this.labelAbteilungBereich.Name = "labelAbteilungBereich";
            this.labelAbteilungBereich.Size = new System.Drawing.Size(120, 16);
            this.labelAbteilungBereich.TabIndex = 2;
            this.labelAbteilungBereich.Text = "Abteilung / Bereich";
            // 
            // ucBigAbteilungsAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.labelAbteilungBereich);
            this.Controls.Add(this.btnAbteilung);
            this.Controls.Add(this.pnlAbtListeGesamt);
            this.Name = "ucBigAbteilungsAuswahl";
            this.Size = new System.Drawing.Size(196, 729);
            this.pnlAbtListeGesamt.ResumeLayout(false);
            this.pnlAbtListeGesamt.PerformLayout();
            this.pnlKliniken.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton btnAbteilung;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem neuLadenToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseLableWin labelAbteilungBereich;
        private QS2.Desktop.ControlManagment.BasePanel pnlKliniken;
        private QS2.Desktop.ControlManagment.BasePanel pnlAbtListeGesamt;
        private QS2.Desktop.ControlManagment.BasePanel pnlAbtList;
        public ucBigComboBoxKliniken ucBigComboBoxKliniken1;
    }
}
