namespace PMDS.GUI
{
    partial class ucASZMSelectorTreeView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucASZMSelectorTreeView2));
            this.tv = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.ImageList = this.imageList1;
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
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            appearance3.BackColor = System.Drawing.Color.Gray;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.White;
            _override1.SelectedNodeAppearance = appearance3;
            this.tv.Override = _override1;
            this.tv.Size = new System.Drawing.Size(296, 160);
            this.tv.TabIndex = 16;
            this.tv.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterCheck);
            this.tv.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterExpand);
            this.tv.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_AfterSelect);
            this.tv.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.tv_BeforeCheck);
            this.tv.BeforeExpand += new Infragistics.Win.UltraWinTree.BeforeNodeChangedEventHandler(this.tv_BeforeExpand);
            this.tv.BeforeSelect += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.tv_BeforeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "haken.jpg");
            // 
            // ucASZMSelectorTreeView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv);
            this.Name = "ucASZMSelectorTreeView2";
            this.Size = new System.Drawing.Size(296, 160);
            this.VisibleChanged += new System.EventHandler(this.ucASZMSelectorTreeView_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTree.UltraTree tv;
        private System.Windows.Forms.ImageList imageList1;
    }
}
