namespace qs2.sitemap.workflowAssist
{
    partial class contListAssistent
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelButtons = new Infragistics.Win.Misc.UltraPanel();
            this.sqlAdmin1 = new qs2.core.vb.sqlAdmin(this.components);
            this.dsAdmin1 = new qs2.core.vb.dsAdmin();
            this.ultraTabControlList = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.ultraTabPageControl1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlList)).BeginInit();
            this.ultraTabControlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.panelButtons);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(349, 170);
            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(349, 170);
            this.panelButtons.TabIndex = 32;
            // 
            // dsAdmin1
            // 
            this.dsAdmin1.DataSetName = "dsAdmin";
            this.dsAdmin1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultraTabControlList
            // 
            this.ultraTabControlList.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControlList.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControlList.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControlList.Name = "ultraTabControlList";
            this.ultraTabControlList.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControlList.Size = new System.Drawing.Size(349, 170);
            this.ultraTabControlList.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.ultraTabControlList.TabIndex = 4;
            ultraTab1.Key = "List";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "tab1";
            this.ultraTabControlList.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(349, 170);
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // contListAssistent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraTabControlList);
            this.DoubleBuffered = true;
            this.Name = "contListAssistent";
            this.Size = new System.Drawing.Size(349, 170);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsAdmin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControlList)).EndInit();
            this.ultraTabControlList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private qs2.core.vb.sqlAdmin sqlAdmin1;
        private qs2.core.vb.dsAdmin dsAdmin1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControlList;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        public Infragistics.Win.Misc.UltraPanel panelButtons;
    }
}
