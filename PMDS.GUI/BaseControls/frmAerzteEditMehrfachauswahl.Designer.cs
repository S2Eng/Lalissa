namespace PMDS.GUI.BaseControls
{
    partial class frmAerzteEditMehrfachauswahl
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.chkHausarztJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkZuweiserJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkAufnahmearztJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkBehandelnderFAJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.dteVon = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblBis = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chkHausarztJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZuweiserJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufnahmearztJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBehandelnderFAJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteVon)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHausarztJN
            // 
            this.chkHausarztJN.Location = new System.Drawing.Point(100, 18);
            this.chkHausarztJN.Name = "chkHausarztJN";
            this.chkHausarztJN.Size = new System.Drawing.Size(130, 19);
            this.chkHausarztJN.TabIndex = 0;
            this.chkHausarztJN.Text = "Hausarzt";
            // 
            // chkZuweiserJN
            // 
            this.chkZuweiserJN.Location = new System.Drawing.Point(100, 39);
            this.chkZuweiserJN.Name = "chkZuweiserJN";
            this.chkZuweiserJN.Size = new System.Drawing.Size(130, 19);
            this.chkZuweiserJN.TabIndex = 1;
            this.chkZuweiserJN.Text = "Zuweiser";
            // 
            // chkAufnahmearztJN
            // 
            this.chkAufnahmearztJN.Location = new System.Drawing.Point(100, 62);
            this.chkAufnahmearztJN.Name = "chkAufnahmearztJN";
            this.chkAufnahmearztJN.Size = new System.Drawing.Size(130, 19);
            this.chkAufnahmearztJN.TabIndex = 2;
            this.chkAufnahmearztJN.Text = "Aufnahmearzt ";
            // 
            // chkBehandelnderFAJN
            // 
            this.chkBehandelnderFAJN.Location = new System.Drawing.Point(100, 84);
            this.chkBehandelnderFAJN.Name = "chkBehandelnderFAJN";
            this.chkBehandelnderFAJN.Size = new System.Drawing.Size(130, 19);
            this.chkBehandelnderFAJN.TabIndex = 3;
            this.chkBehandelnderFAJN.Text = "Facharzt";
            // 
            // btnOK
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(151, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 27);
            this.btnOK.TabIndex = 11;
            this.btnOK.Tag = "ResID.OK";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(73, 162);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(78, 27);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // dteVon
            // 
            this.dteVon.Location = new System.Drawing.Point(99, 116);
            this.dteVon.Name = "dteVon";
            this.dteVon.Size = new System.Drawing.Size(95, 21);
            this.dteVon.TabIndex = 13;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(71, 119);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(36, 14);
            this.lblBis.TabIndex = 14;
            this.lblBis.Text = "Von";
            // 
            // frmAerzteEditMehrfachauswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 194);
            this.Controls.Add(this.dteVon);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkBehandelnderFAJN);
            this.Controls.Add(this.chkAufnahmearztJN);
            this.Controls.Add(this.chkZuweiserJN);
            this.Controls.Add(this.chkHausarztJN);
            this.Name = "frmAerzteEditMehrfachauswahl";
            this.Text = "Auswahl Ärzte Zuordnung";
            this.Load += new System.EventHandler(this.frmAerzteEditMehrfachauswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkHausarztJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZuweiserJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAufnahmearztJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBehandelnderFAJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteVon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkHausarztJN;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkZuweiserJN;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAufnahmearztJN;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBehandelnderFAJN;
        public Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dteVon;
        private Infragistics.Win.Misc.UltraLabel lblBis;
    }
}