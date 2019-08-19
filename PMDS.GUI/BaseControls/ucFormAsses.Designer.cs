namespace PMDS.GUI.BaseControls
{
    partial class ucFormAsses
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
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            this.ubMain = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            ((System.ComponentModel.ISupportInitialize)(this.ubMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ubMain
            // 
            this.ubMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Key = "VorhandeneFormulare";
            ultraExplorerBarGroup1.Text = "Vorhandene Formulare";
            this.ubMain.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ubMain.GroupSettings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ubMain.Location = new System.Drawing.Point(0, 0);
            this.ubMain.Name = "ubMain";
            this.ubMain.ShowDefaultContextMenu = false;
            this.ubMain.Size = new System.Drawing.Size(200, 194);
            this.ubMain.TabIndex = 1;
            this.ubMain.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.ubMain_ItemClick);
            // 
            // ucFormAsses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ubMain);
            this.Name = "ucFormAsses";
            this.Size = new System.Drawing.Size(200, 194);
            this.Load += new System.EventHandler(this.ucFormAsses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ubMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ubMain;

    }
}
