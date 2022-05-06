namespace PMDS.GUI.BaseControls
{
    partial class ucPDXTreeView
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
            this.tv = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            //appearance1.BackColor = System.Drawing.Color.SkyBlue;
            //appearance1.ForeColor = System.Drawing.Color.White;
            _override1.ActiveNodeAppearance = appearance1;
            this.tv.Override = _override1;
            this.tv.Size = new System.Drawing.Size(296, 160);
            this.tv.TabIndex = 1;
            this.tv.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tv.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.FreeForm;
            this.tv.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterCheck);
            this.tv.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tv_AfterExpand);
            this.tv.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tv_AfterSelect);
            this.tv.BeforeSelect += new Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler(this.tv_BeforeSelect);
            // 
            // ucPDXTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv);
            this.Name = "ucPDXTreeView";
            this.Size = new System.Drawing.Size(296, 160);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinTree.UltraTree tv;
    }
}
