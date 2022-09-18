namespace qs2.design.auto.print
{
    partial class frmAllQueriesEditSmall
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.contSelListQueries = new qs2.ui.print.contSelListQueries();
            this.lblListQueries = new Infragistics.Win.Misc.UltraLabel();
            this.btnClose = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.SuspendLayout();
            // 
            // contSelListQueries
            // 
            this.contSelListQueries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contSelListQueries.BackColor = System.Drawing.Color.Transparent;
            this.contSelListQueries.Location = new System.Drawing.Point(15, 27);
            this.contSelListQueries.Name = "contSelListQueries";
            this.contSelListQueries.Size = new System.Drawing.Size(536, 28);
            this.contSelListQueries.TabIndex = 36;
            // 
            // lblListQueries
            // 
            this.lblListQueries.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListQueries.Location = new System.Drawing.Point(15, 12);
            this.lblListQueries.Name = "lblListQueries";
            this.lblListQueries.Size = new System.Drawing.Size(195, 14);
            this.lblListQueries.TabIndex = 37;
            this.lblListQueries.Text = "List Queries";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance1;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(468, 75);
            this.btnClose.Name = "btnClose";
            this.btnClose.OwnAutoTextYN = false;
            this.btnClose.OwnPicture = QS2.Resources.getRes.ePicture.none;
            this.btnClose.OwnPictureTxt = "";
            this.btnClose.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnClose.OwnTooltipText = "";
            this.btnClose.OwnTooltipTitle = null;
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 38;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAllQueriesEditSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 101);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblListQueries);
            this.Controls.Add(this.contSelListQueries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllQueriesEditSmall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit all Queris";
            this.Load += new System.EventHandler(this.frmAllQueriesEditSmall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public qs2.ui.print.contSelListQueries contSelListQueries;
        private Infragistics.Win.Misc.UltraLabel lblListQueries;
        private sitemap.ownControls.inherit_Infrag.InfragButton btnClose;
    }
}