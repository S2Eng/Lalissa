namespace PMDS.GUI.BaseControls
{
    partial class frmShowBerichtParameter
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.lvMain = new System.Windows.Forms.ListView();
            this.col0 = new System.Windows.Forms.ColumnHeader();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.SuspendLayout();
            // 
            // lvMain
            // 
            this.lvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col0,
            this.col1});
            this.lvMain.GridLines = true;
            this.lvMain.LabelEdit = true;
            this.lvMain.Location = new System.Drawing.Point(0, 0);
            this.lvMain.MultiSelect = false;
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(788, 457);
            this.lvMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvMain.TabIndex = 7;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // col0
            // 
            this.col0.Text = "Feldname";
            this.col0.Width = 177;
            // 
            // col1
            // 
            this.col1.Text = "Wert";
            this.col1.Width = 577;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = 4;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOK.Appearance = appearance1;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(727, 463);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmShowBerichtParameter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(787, 507);
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.btnOK);
            this.MinimizeBox = false;
            this.Name = "frmShowBerichtParameter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anzeige der aktuellen Berichtsparameter";
            this.ResumeLayout(false);

        }

        #endregion

        private ucButton btnOK;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.ColumnHeader col1;
    }
}