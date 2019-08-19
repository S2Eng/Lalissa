namespace PMDS.GUI
{
    partial class ucAnamnesePDXBase
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lvPDX = new Infragistics.Win.UltraWinListView.UltraListView();
            ((System.ComponentModel.ISupportInitialize)(this.lvPDX)).BeginInit();
            this.SuspendLayout();
            // 
            // lvPDX
            // 
            this.lvPDX.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lvPDX.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance1.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPDX.ItemSettings.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPDX.ItemSettings.SelectedAppearance = appearance2;
            this.lvPDX.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvPDX.Location = new System.Drawing.Point(0, 0);
            this.lvPDX.Name = "lvPDX";
            this.lvPDX.Size = new System.Drawing.Size(385, 245);
            this.lvPDX.TabIndex = 2;
            this.lvPDX.Text = "ultraListView1";
            this.lvPDX.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvPDX.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvPDX.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvPDX.ViewSettingsList.MultiColumn = false;
            this.lvPDX.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.lvPDX_ItemCheckStateChanged);
            this.lvPDX.ItemCheckStateChanging += new Infragistics.Win.UltraWinListView.ItemCheckStateChangingEventHandler(this.lvPDX_ItemCheckStateChanging);
            // 
            // ucAnamnesePDXBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPDX);
            this.Name = "ucAnamnesePDXBase";
            this.Size = new System.Drawing.Size(385, 245);
            ((System.ComponentModel.ISupportInitialize)(this.lvPDX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Infragistics.Win.UltraWinListView.UltraListView lvPDX;




    }
}
