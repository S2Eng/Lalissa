namespace PMDS.Calc.UI.Admin
{
    partial class ucLeistungenKlient
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            this.grpRegelmLeistungen = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucLeistungszuordKlient1 = new PMDS.Calc.UI.Admin.ucLeistungszuordKlient();
            this.grpSonderleistungen = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ucSonderleistungenKlient1 = new PMDS.Calc.UI.Admin.ucSonderleistungenKlient();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grpRegelmLeistungen)).BeginInit();
            this.grpRegelmLeistungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSonderleistungen)).BeginInit();
            this.grpSonderleistungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRegelmLeistungen
            // 
            this.grpRegelmLeistungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRegelmLeistungen.Controls.Add(this.ucLeistungszuordKlient1);
            this.grpRegelmLeistungen.Location = new System.Drawing.Point(2, 3);
            this.grpRegelmLeistungen.Name = "grpRegelmLeistungen";
            this.grpRegelmLeistungen.Size = new System.Drawing.Size(915, 298);
            this.grpRegelmLeistungen.TabIndex = 7;
            this.grpRegelmLeistungen.Text = "Regelmäßige Leistungen";
            // 
            // ucLeistungszuordKlient1
            // 
            this.ucLeistungszuordKlient1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLeistungszuordKlient1.BackColor = System.Drawing.Color.Transparent;
            this.ucLeistungszuordKlient1.IDPatient = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucLeistungszuordKlient1.Location = new System.Drawing.Point(9, 16);
            this.ucLeistungszuordKlient1.Name = "ucLeistungszuordKlient1";
            this.ucLeistungszuordKlient1.Size = new System.Drawing.Size(900, 282);
            this.ucLeistungszuordKlient1.TabIndex = 5;
            this.ucLeistungszuordKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            // 
            // grpSonderleistungen
            // 
            this.grpSonderleistungen.Controls.Add(this.ucSonderleistungenKlient1);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.grpSonderleistungen, gridBagConstraint1);
            this.grpSonderleistungen.Location = new System.Drawing.Point(5, 5);
            this.grpSonderleistungen.Name = "grpSonderleistungen";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.grpSonderleistungen, new System.Drawing.Size(917, 186));
            this.grpSonderleistungen.Size = new System.Drawing.Size(917, 215);
            this.grpSonderleistungen.TabIndex = 8;
            this.grpSonderleistungen.Text = "Sonderleistungen";
            // 
            // ucSonderleistungenKlient1
            // 
            this.ucSonderleistungenKlient1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSonderleistungenKlient1.BackColor = System.Drawing.Color.Transparent;
            this.ucSonderleistungenKlient1.Location = new System.Drawing.Point(6, 14);
            this.ucSonderleistungenKlient1.Name = "ucSonderleistungenKlient1";
            this.ucSonderleistungenKlient1.Size = new System.Drawing.Size(905, 195);
            this.ucSonderleistungenKlient1.TabIndex = 6;
            this.ucSonderleistungenKlient1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.panel1);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(927, 307);
            this.ultraGridBagLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpRegelmLeistungen);
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            gridBagConstraint2.OriginX = 0;
            gridBagConstraint2.OriginY = 0;
            gridBagConstraint2.SpanY = 2;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.panel1, gridBagConstraint2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.panel1, new System.Drawing.Size(200, 100));
            this.panel1.Size = new System.Drawing.Size(917, 302);
            this.panel1.TabIndex = 0;
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Controls.Add(this.grpSonderleistungen);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 307);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(927, 225);
            this.ultraGridBagLayoutPanel2.TabIndex = 9;
            // 
            // ucLeistungenKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucLeistungenKlient";
            this.Size = new System.Drawing.Size(927, 532);
            ((System.ComponentModel.ISupportInitialize)(this.grpRegelmLeistungen)).EndInit();
            this.grpRegelmLeistungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSonderleistungen)).EndInit();
            this.grpSonderleistungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucLeistungszuordKlient ucLeistungszuordKlient1;
        private ucSonderleistungenKlient ucSonderleistungenKlient1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpRegelmLeistungen;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpSonderleistungen;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
    }
}
