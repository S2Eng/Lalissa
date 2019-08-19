namespace PMDS.GUI
{
    partial class ucPflegeplanTreeView
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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.tv = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
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
            appearance1.BackColor = System.Drawing.Color.Gray;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.White;
            _override1.ActiveNodeAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.Black;
            _override1.HotTrackingNodeAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.Gray;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.White;
            _override1.SelectedNodeAppearance = appearance3;
            this.tv.Override = _override1;
            this.tv.Size = new System.Drawing.Size(296, 160);
            this.tv.TabIndex = 1;
            this.tv.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.FreeForm;
            this.tv.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterCheck);
            this.tv.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterExpand);
            this.tv.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_AfterSelect);
            this.tv.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.tv_BeforeCheck);
            this.tv.BeforeSelect += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.tv_BeforeSelect);
            this.tv.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.tv_MouseEnterElement);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ucPflegeplanTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv);
            this.Name = "ucPflegeplanTreeView";
            this.Size = new System.Drawing.Size(296, 160);
            this.VisibleChanged += new System.EventHandler(this.ucPflegeplanTreeView_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.UltraWinTree.UltraTree tv;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}
