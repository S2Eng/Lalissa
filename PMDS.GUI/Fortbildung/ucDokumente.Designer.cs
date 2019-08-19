namespace PMDS.GUI.Fortbildung
{
    partial class ucDokumente
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ausgewähltes Dokument löschen", Infragistics.Win.ToolTipImage.Default, "Löschen", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Dokument hinzufügen", Infragistics.Win.ToolTipImage.Default, "Hinzufügen", Infragistics.Win.DefaultableBoolean.Default);
            this.lvDokumente = new Infragistics.Win.UltraWinListView.UltraListView();
            this.btnDel = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lvDokumente)).BeginInit();
            this.SuspendLayout();
            // 
            // lvDokumente
            // 
            this.lvDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.FontData.SizeInPoints = 10F;
            this.lvDokumente.Appearance = appearance1;
            this.lvDokumente.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvDokumente.ItemSettings.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvDokumente.ItemSettings.SelectedAppearance = appearance3;
            this.lvDokumente.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvDokumente.Location = new System.Drawing.Point(4, 34);
            this.lvDokumente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvDokumente.Name = "lvDokumente";
            this.lvDokumente.Size = new System.Drawing.Size(548, 74);
            this.lvDokumente.TabIndex = 6;
            this.lvDokumente.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvDokumente.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvDokumente.Click += new System.EventHandler(this.lvDokumente_Click);
            this.lvDokumente.DoubleClick += new System.EventHandler(this.lvDokumente_DoubleClick);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance4;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.IsStandardControl = false;
            this.btnDel.Location = new System.Drawing.Point(517, 0);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(36, 32);
            this.btnDel.TabIndex = 9;
            this.btnDel.Tag = "";
            ultraToolTipInfo2.ToolTipText = "Ausgewähltes Dokument löschen";
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
            this.btnAdd.Location = new System.Drawing.Point(481, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 32);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Tag = "";
            ultraToolTipInfo1.ToolTipText = "Dokument hinzufügen";
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
            // ucDokumente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvDokumente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucDokumente";
            this.Size = new System.Drawing.Size(556, 110);
            this.Load += new System.EventHandler(this.ucDokumente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvDokumente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Infragistics.Win.UltraWinListView.UltraListView lvDokumente;
        public QS2.Desktop.ControlManagment.BaseButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnAdd;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
