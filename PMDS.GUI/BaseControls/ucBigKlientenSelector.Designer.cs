namespace PMDS.GUI.BaseControls
{
    partial class ucBigKlientenSelector
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
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlKlienten = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnKlient = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.Klient = new QS2.Desktop.ControlManagment.BaseLableWin();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlKlienten;
            this.ultraPopupControlContainer1.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer1_Opening);
            this.ultraPopupControlContainer1.Closed += new System.EventHandler(this.ultraPopupControlContainer1_Closed);
            // 
            // pnlKlienten
            // 
            this.pnlKlienten.AutoScroll = true;
            this.pnlKlienten.Location = new System.Drawing.Point(25, 59);
            this.pnlKlienten.Name = "pnlKlienten";
            this.pnlKlienten.Size = new System.Drawing.Size(619, 438);
            this.pnlKlienten.TabIndex = 2;
            this.pnlKlienten.Visible = false;
            this.pnlKlienten.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKlienten_Paint);
            // 
            // btnKlient
            // 
            appearance1.ForeColor = System.Drawing.Color.Blue;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.btnKlient.Appearance = appearance1;
            this.btnKlient.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKlient.ImageSize = new System.Drawing.Size(70, 70);
            this.btnKlient.Location = new System.Drawing.Point(0, 0);
            this.btnKlient.Name = "btnKlient";
            this.btnKlient.PopupItemKey = "pnlKlienten";
            this.btnKlient.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnKlient.ShowFocusRect = false;
            this.btnKlient.Size = new System.Drawing.Size(231, 82);
            this.btnKlient.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnKlient.TabIndex = 1;
            this.btnKlient.Text = "*********";
            this.btnKlient.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnKlient.Click += new System.EventHandler(this.btnKlient_Click);
            // 
            // ultraFlowLayoutManager1
            // 
            this.ultraFlowLayoutManager1.ContainerControl = this.pnlKlienten;
            // 
            // Klient
            // 
            this.Klient.AutoSize = true;
            this.Klient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Klient.Location = new System.Drawing.Point(4, 4);
            this.Klient.Name = "Klient";
            this.Klient.Size = new System.Drawing.Size(40, 16);
            this.Klient.TabIndex = 3;
            this.Klient.Text = "Klient";
            // 
            // ucBigKlientenSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlKlienten);
            this.Controls.Add(this.Klient);
            this.Controls.Add(this.btnKlient);
            this.Name = "ucBigKlientenSelector";
            this.Size = new System.Drawing.Size(231, 82);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private Infragistics.Win.Misc.UltraDropDownButton btnKlient;
        private QS2.Desktop.ControlManagment.BasePanel pnlKlienten;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
        private QS2.Desktop.ControlManagment.BaseLableWin Klient;
    }
}
