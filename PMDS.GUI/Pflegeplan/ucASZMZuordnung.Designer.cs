namespace PMDS.GUI
{
    partial class ucASZMZuordnung
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.lblTitle = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.optÜbernehmenLeereAnordnung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblFür = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbAbteilung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.optÜbernehmenLeereAnordnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 19);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "ASZM - Zuordnung";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // optÜbernehmenLeereAnordnung
            // 
            this.optÜbernehmenLeereAnordnung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "von ({0}) übernehmen";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "leere ASRZM - Zuordnung";
            this.optÜbernehmenLeereAnordnung.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.optÜbernehmenLeereAnordnung.Location = new System.Drawing.Point(3, 32);
            this.optÜbernehmenLeereAnordnung.Name = "optÜbernehmenLeereAnordnung";
            this.optÜbernehmenLeereAnordnung.Size = new System.Drawing.Size(368, 32);
            this.optÜbernehmenLeereAnordnung.TabIndex = 21;
            this.optÜbernehmenLeereAnordnung.ValueMember = "";
            // 
            // lblFür
            // 
            this.lblFür.AutoSize = true;
            this.lblFür.Location = new System.Drawing.Point(3, 70);
            this.lblFür.Name = "lblFür";
            this.lblFür.Size = new System.Drawing.Size(17, 14);
            this.lblFür.TabIndex = 22;
            this.lblFür.Text = "für";
            // 
            // cmbAbteilung
            // 
            this.cmbAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbAbteilung.Location = new System.Drawing.Point(26, 69);
            this.cmbAbteilung.Name = "cmbAbteilung";
            this.cmbAbteilung.Size = new System.Drawing.Size(232, 21);
            this.cmbAbteilung.TabIndex = 24;
            this.cmbAbteilung.ValueChanged += new System.EventHandler(this.cmbAbteilung_ValueChanged);
            // 
            // ucASZMZuordnung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbAbteilung);
            this.Controls.Add(this.lblFür);
            this.Controls.Add(this.optÜbernehmenLeereAnordnung);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucASZMZuordnung";
            this.Size = new System.Drawing.Size(389, 111);
            this.Load += new System.EventHandler(this.ucASZMZuordnung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.optÜbernehmenLeereAnordnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLableWin lblTitle;
        private QS2.Desktop.ControlManagment.BaseOptionSet optÜbernehmenLeereAnordnung;
        private QS2.Desktop.ControlManagment.BaseLabel lblFür;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbAbteilung;
    }
}
