namespace PMDS.GUI
{
    partial class ucSiteMapPflegePlan2
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
            this.pnlNoRights = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblPflegeplanungNichtEinsehen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.ucPflegeplan21 = new PMDS.GUI.ucPflegeplan2();
            this.pnlNoRights.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNoRights
            // 
            this.pnlNoRights.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNoRights.Controls.Add(this.lblPflegeplanungNichtEinsehen);
            this.pnlNoRights.Location = new System.Drawing.Point(88, 128);
            this.pnlNoRights.Name = "pnlNoRights";
            this.pnlNoRights.Size = new System.Drawing.Size(518, 60);
            this.pnlNoRights.TabIndex = 14;
            this.pnlNoRights.Visible = false;
            // 
            // lblPflegeplanungNichtEinsehen
            // 
            this.lblPflegeplanungNichtEinsehen.AutoSize = true;
            this.lblPflegeplanungNichtEinsehen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPflegeplanungNichtEinsehen.Location = new System.Drawing.Point(51, 21);
            this.lblPflegeplanungNichtEinsehen.Name = "lblPflegeplanungNichtEinsehen";
            this.lblPflegeplanungNichtEinsehen.Size = new System.Drawing.Size(388, 24);
            this.lblPflegeplanungNichtEinsehen.TabIndex = 0;
            this.lblPflegeplanungNichtEinsehen.Text = "Sie dürfen die Pflegeplanung nicht einsehen.";
            // 
            // ucPflegeplan21
            // 
            this.ucPflegeplan21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPflegeplan21.Location = new System.Drawing.Point(0, 0);
            this.ucPflegeplan21.Name = "ucPflegeplan21";
            this.ucPflegeplan21.ReadOnly = false;
            this.ucPflegeplan21.ShowErledigteAtStartup = true;
            this.ucPflegeplan21.Size = new System.Drawing.Size(726, 445);
            this.ucPflegeplan21.TabIndex = 0;
            this.ucPflegeplan21.planungÄndern += new PMDS.Global.evPlanungÄndern(this.ucPflegeplan21_planungÄndern);
            this.ucPflegeplan21.ValueChanged += new System.EventHandler(this.ucPflegeplan21_ValueChanged);
            this.ucPflegeplan21.Load += new System.EventHandler(this.ucPflegeplan21_Load);
            // 
            // ucSiteMapPflegePlan2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNoRights);
            this.Controls.Add(this.ucPflegeplan21);
            this.Name = "ucSiteMapPflegePlan2";
            this.Size = new System.Drawing.Size(726, 445);
            this.VisibleChanged += new System.EventHandler(this.ucSiteMapPflegePlan2_VisibleChanged);
            this.pnlNoRights.ResumeLayout(false);
            this.pnlNoRights.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucPflegeplan2 ucPflegeplan21;
        private QS2.Desktop.ControlManagment.BasePanel pnlNoRights;
        private QS2.Desktop.ControlManagment.BaseLableWin lblPflegeplanungNichtEinsehen;
    }
}
