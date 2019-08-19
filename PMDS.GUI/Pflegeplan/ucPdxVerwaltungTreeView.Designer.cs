namespace PMDS.GUI
{
    partial class ucPdxVerwaltungTreeView
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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.tv = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            appearance1.BackColor = System.Drawing.SystemColors.Highlight;
            _override1.ActiveNodeAppearance = appearance1;
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            _override1.SelectedNodeAppearance = appearance2;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Single;
            this.tv.Override = _override1;
            this.tv.Size = new System.Drawing.Size(336, 150);
            this.tv.TabIndex = 17;
            this.tv.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterCheck);
            this.tv.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_AfterSelect);
            this.tv.BeforeActivate += new Infragistics.Win.UltraWinTree.BeforeNodeChangedEventHandler(this.tv_BeforeActivate);
            this.tv.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.tv_BeforeCheck);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // ucPdxVerwaltungTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv);
            this.Name = "ucPdxVerwaltungTreeView";
            this.Size = new System.Drawing.Size(336, 150);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTree.UltraTree tv;
    }
}
