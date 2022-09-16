namespace PMDS.Calc.UI
{
    partial class ucDaylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDaylist));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Tagsatzliste erstellen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.dtMonat = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.btnTimes = new Infragistics.Win.Misc.UltraDropDownButton();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelDaylist = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucbill1 = new PMDS.Calc.Logic.ucprint();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.panelDaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.dtMonat);
            this.panelOben.Controls.Add(this.btnTimes);
            this.panelOben.Controls.Add(this.lblVon);
            this.panelOben.Controls.Add(this.btnErstellen);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(790, 38);
            this.panelOben.TabIndex = 0;
            // 
            // dtMonat
            // 
            this.dtMonat.Location = new System.Drawing.Point(60, 10);
            this.dtMonat.MaskInput = "{LOC}mm.yyyy";
            this.dtMonat.Name = "dtMonat";
            this.dtMonat.ownFormat = "";
            this.dtMonat.ownMaskInput = "";
            this.dtMonat.Size = new System.Drawing.Size(71, 21);
            this.dtMonat.TabIndex = 0;
            // 
            // btnTimes
            // 
            this.btnTimes.Location = new System.Drawing.Point(137, 8);
            this.btnTimes.Name = "btnTimes";
            this.btnTimes.ShowFocusRect = false;
            this.btnTimes.Size = new System.Drawing.Size(21, 27);
            this.btnTimes.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnTimes.TabIndex = 100;
            this.btnTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTimes_MouseUp);
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(10, 14);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(48, 15);
            this.lblVon.TabIndex = 3;
            this.lblVon.Text = "Monat";
            // 
            // btnErstellen
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnErstellen.Appearance = appearance1;
            this.btnErstellen.AutoWorkLayout = false;
            this.btnErstellen.IsStandardControl = false;
            this.btnErstellen.Location = new System.Drawing.Point(177, 8);
            this.btnErstellen.Name = "btnErstellen";
            this.btnErstellen.Size = new System.Drawing.Size(86, 27);
            this.btnErstellen.TabIndex = 2;
            this.btnErstellen.Text = "Erstellen";
            ultraToolTipInfo1.ToolTipText = "Tagsatzliste erstellen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnErstellen, ultraToolTipInfo1);
            this.btnErstellen.Click += new System.EventHandler(this.btnErstellen_Click);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panelDaylist);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(790, 403);
            this.ultraGridBagLayoutPanel1.TabIndex = 1;
            // 
            // panelDaylist
            // 
            this.panelDaylist.Controls.Add(this.ucbill1);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panelDaylist, gridBagConstraint1);
            this.panelDaylist.Location = new System.Drawing.Point(5, 5);
            this.panelDaylist.Name = "panelDaylist";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panelDaylist, new System.Drawing.Size(121, 64));
            this.panelDaylist.Size = new System.Drawing.Size(780, 393);
            this.panelDaylist.TabIndex = 101;
            // 
            // ucbill1
            // 
            this.ucbill1.BackColor = System.Drawing.Color.White;
            this.ucbill1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucbill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucbill1.Location = new System.Drawing.Point(0, 0);
            this.ucbill1.Name = "ucbill1";
            this.ucbill1.Size = new System.Drawing.Size(780, 393);
            this.ucbill1.TabIndex = 0;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucDaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Controls.Add(this.panelOben);
            this.Name = "ucDaylist";
            this.Size = new System.Drawing.Size(790, 441);
            this.Load += new System.EventHandler(this.ucDaylist_Load);
            this.Resize += new System.EventHandler(this.ucDaylist_Resize);
            this.panelOben.ResumeLayout(false);
            this.panelOben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.panelDaylist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private PMDS.Calc.Logic.ucprint ucbill1;
        private Infragistics.Win.Misc.UltraDropDownButton btnTimes;
        private QS2.Desktop.ControlManagment.BaseLabel lblVon;
        private QS2.Desktop.ControlManagment.BaseButton btnErstellen;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelDaylist;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtMonat;
    }
}
