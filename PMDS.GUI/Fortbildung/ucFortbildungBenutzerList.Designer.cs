namespace PMDS.GUI.Fortbildung
{
    partial class ucFortbildungBenutzerList
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewählte Fortbildung für Benutzer löschen", Infragistics.Win.ToolTipImage.Default, "Löschen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Fortbildung für Benutzer hinzufügen", Infragistics.Win.ToolTipImage.Default, "Hinzufügen", Infragistics.Win.DefaultableBoolean.Default);
            this.lvBenutzer = new Infragistics.Win.UltraWinListView.UltraListView();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lvBenutzer)).BeginInit();
            this.SuspendLayout();
            // 
            // lvBenutzer
            // 
            this.lvBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.FontData.SizeInPoints = 10F;
            this.lvBenutzer.Appearance = appearance1;
            this.lvBenutzer.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvBenutzer.ItemSettings.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvBenutzer.ItemSettings.SelectedAppearance = appearance3;
            this.lvBenutzer.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvBenutzer.Location = new System.Drawing.Point(4, 34);
            this.lvBenutzer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvBenutzer.Name = "lvBenutzer";
            this.lvBenutzer.Size = new System.Drawing.Size(245, 481);
            this.lvBenutzer.TabIndex = 5;
            this.lvBenutzer.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvBenutzer.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvBenutzer.Click += new System.EventHandler(this.lvBenutzer_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance4;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(212, 0);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(36, 32);
            this.btnDel.TabIndex = 7;
            this.btnDel.Tag = "";
            ultraToolTipInfo2.ToolTipText = "Ausgewählte Fortbildung für Benutzer löschen";
            ultraToolTipInfo2.ToolTipTitle = "Löschen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnDel, ultraToolTipInfo2);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance5;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.IsStandardControl = false;
            this.btnAdd.Location = new System.Drawing.Point(176, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Tag = "";
            ultraToolTipInfo1.ToolTipText = "Fortbildung für Benutzer hinzufügen";
            ultraToolTipInfo1.ToolTipTitle = "Hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnAdd, ultraToolTipInfo1);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucFortbildungBenutzerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvBenutzer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucFortbildungBenutzerList";
            this.Size = new System.Drawing.Size(253, 518);
            this.Load += new System.EventHandler(this.ucFortbildungBenutzerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvBenutzer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Infragistics.Win.UltraWinListView.UltraListView lvBenutzer;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
