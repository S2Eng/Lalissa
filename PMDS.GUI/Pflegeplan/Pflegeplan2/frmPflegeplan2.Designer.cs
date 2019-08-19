namespace PMDS.GUI
{
    partial class frmPflegeplan2
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPflegeplan2));
            this.ucPflegeplan21 = new PMDS.GUI.ucPflegeplan2();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnRefresh = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPflegeplan21
            // 
            this.ucPflegeplan21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegeplan21.Location = new System.Drawing.Point(0, 0);
            this.ucPflegeplan21.Name = "ucPflegeplan21";
            this.ucPflegeplan21.ReadOnly = false;
            this.ucPflegeplan21.ShowErledigteAtStartup = true;
            this.ucPflegeplan21.Size = new System.Drawing.Size(1016, 692);
            this.ucPflegeplan21.TabIndex = 0;
            this.ucPflegeplan21.ValueChanged += new System.EventHandler(this.ucPflegeplan21_ValueChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 695);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1016, 39);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = 1;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnRefresh.Appearance = appearance1;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(909, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "&Rückgängig";
            this.btnRefresh.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = 0;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSave.Appearance = appearance2;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(813, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPflegeplan2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.ucPflegeplan21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPflegeplan2";
            this.Text = "frmPflegeplan2";
            this.Load += new System.EventHandler(this.frmPflegeplan2_Load);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPflegeplan2 ucPflegeplan21;
        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private ucButton btnRefresh;
        private ucButton btnSave;
    }
}