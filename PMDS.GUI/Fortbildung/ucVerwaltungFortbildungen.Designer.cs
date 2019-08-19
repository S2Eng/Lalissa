namespace PMDS.GUI.Fortbildung
{
    partial class ucVerwaltungFortbildungen
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
            this.ucVeranstalter1 = new PMDS.GUI.Fortbildung.ucVeranstalter();
            this.ucFortbildungenList1 = new PMDS.GUI.Fortbildung.ucFortbildungenList();
            this.ucFortbildungenMain1 = new PMDS.GUI.Fortbildung.ucFortbildungenMain();
            this.SuspendLayout();
            // 
            // ucVeranstalter1
            // 
            this.ucVeranstalter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVeranstalter1.BackColor = System.Drawing.Color.Transparent;
            this.ucVeranstalter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucVeranstalter1.Location = new System.Drawing.Point(0, 0);
            this.ucVeranstalter1.Margin = new System.Windows.Forms.Padding(4);
            this.ucVeranstalter1.Name = "ucVeranstalter1";
            this.ucVeranstalter1.Size = new System.Drawing.Size(1193, 48);
            this.ucVeranstalter1.TabIndex = 0;
            // 
            // ucFortbildungenList1
            // 
            this.ucFortbildungenList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ucFortbildungenList1.BackColor = System.Drawing.Color.Transparent;
            this.ucFortbildungenList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFortbildungenList1.Location = new System.Drawing.Point(0, 48);
            this.ucFortbildungenList1.Margin = new System.Windows.Forms.Padding(4);
            this.ucFortbildungenList1.Name = "ucFortbildungenList1";
            this.ucFortbildungenList1.Size = new System.Drawing.Size(336, 676);
            this.ucFortbildungenList1.TabIndex = 1;
            // 
            // ucFortbildungenMain1
            // 
            this.ucFortbildungenMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFortbildungenMain1.BackColor = System.Drawing.Color.Transparent;
            this.ucFortbildungenMain1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFortbildungenMain1.Location = new System.Drawing.Point(336, 48);
            this.ucFortbildungenMain1.Margin = new System.Windows.Forms.Padding(4);
            this.ucFortbildungenMain1.Name = "ucFortbildungenMain1";
            this.ucFortbildungenMain1.Size = new System.Drawing.Size(857, 676);
            this.ucFortbildungenMain1.TabIndex = 2;
            // 
            // ucVerwaltungFortbildungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucFortbildungenMain1);
            this.Controls.Add(this.ucFortbildungenList1);
            this.Controls.Add(this.ucVeranstalter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucVerwaltungFortbildungen";
            this.Size = new System.Drawing.Size(1193, 724);
            this.Load += new System.EventHandler(this.ucVerwaltungFortbildungen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public ucFortbildungenMain ucFortbildungenMain1;
        public ucFortbildungenList ucFortbildungenList1;
        public ucVeranstalter ucVeranstalter1;
    }
}
