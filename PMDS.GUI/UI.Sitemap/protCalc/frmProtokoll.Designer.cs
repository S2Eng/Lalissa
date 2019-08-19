namespace PMDS.Global
{
    partial class frmProtokoll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProtokoll));
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ucProtokoll1 = new PMDS.Global.ucProtokoll();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.ucProtokoll1);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(887, 466);
            this.ultraGridBagLayoutPanelAll.TabIndex = 0;
            // 
            // ucProtokoll1
            // 
            this.ucProtokoll1.BackColor = System.Drawing.Color.Silver;
            this.ucProtokoll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.ucProtokoll1, gridBagConstraint1);
            this.ucProtokoll1.Location = new System.Drawing.Point(5, 5);
            this.ucProtokoll1.Name = "ucProtokoll1";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.ucProtokoll1, new System.Drawing.Size(422, 258));
            this.ucProtokoll1.Size = new System.Drawing.Size(877, 456);
            this.ucProtokoll1.TabIndex = 0;
            // 
            // frmProtokoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(887, 466);
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProtokoll";
            this.Text = "PMDS- Abrechnen";
            this.Load += new System.EventHandler(this.frmProtokoll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        public ucProtokoll ucProtokoll1;
    }
}