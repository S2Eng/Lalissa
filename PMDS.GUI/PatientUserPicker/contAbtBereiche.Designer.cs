namespace PMDS.GUI.PatientUserPicker
{
    partial class contAbtBereiche
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
            this.contSelectPatientenBenutzer1 = new PMDS.GUI.VB.contSelectPatientenBenutzer();
            this.cbKlinik = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelPicker = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelPicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // contSelectPatientenBenutzer1
            // 
            this.contSelectPatientenBenutzer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contSelectPatientenBenutzer1.BackColor = System.Drawing.Color.Gainsboro;
            this.contSelectPatientenBenutzer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contSelectPatientenBenutzer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.contSelectPatientenBenutzer1.Location = new System.Drawing.Point(3, 3);
            this.contSelectPatientenBenutzer1.Name = "contSelectPatientenBenutzer1";
            this.contSelectPatientenBenutzer1.Size = new System.Drawing.Size(324, 385);
            this.contSelectPatientenBenutzer1.TabIndex = 2;
            // 
            // cbKlinik
            // 
            this.cbKlinik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKlinik.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbKlinik.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKlinik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbKlinik.Location = new System.Drawing.Point(4, 3);
            this.cbKlinik.Name = "cbKlinik";
            this.cbKlinik.Size = new System.Drawing.Size(323, 24);
            this.cbKlinik.TabIndex = 118;
            this.cbKlinik.TabStop = false;
            this.cbKlinik.ValueChanged += new System.EventHandler(this.cbKlinik_ValueChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.cbKlinik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(330, 30);
            this.panelTop.TabIndex = 119;
            // 
            // panelPicker
            // 
            this.panelPicker.BackColor = System.Drawing.Color.Transparent;
            this.panelPicker.Controls.Add(this.contSelectPatientenBenutzer1);
            this.panelPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicker.Location = new System.Drawing.Point(0, 30);
            this.panelPicker.Name = "panelPicker";
            this.panelPicker.Size = new System.Drawing.Size(330, 391);
            this.panelPicker.TabIndex = 120;
            // 
            // contAbtBereiche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelPicker);
            this.Controls.Add(this.panelTop);
            this.Name = "contAbtBereiche";
            this.Size = new System.Drawing.Size(330, 421);
            this.Load += new System.EventHandler(this.contAbtBereiche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelPicker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1;
        public QS2.Desktop.ControlManagment.BaseComboEditor cbKlinik;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelPicker;
    }
}
