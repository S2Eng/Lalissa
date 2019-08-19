namespace PMDS.GUI
{
    partial class ucSiteMapEvaluierung1
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
            this.lblEvaluierungNichtEinsehen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.ucZielEvaluierung1 = new PMDS.GUI.ucZielEvaluierung();
            this.pnlNoRights.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNoRights
            // 
            this.pnlNoRights.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNoRights.Controls.Add(this.lblEvaluierungNichtEinsehen);
            this.pnlNoRights.Location = new System.Drawing.Point(217, 365);
            this.pnlNoRights.Name = "pnlNoRights";
            this.pnlNoRights.Size = new System.Drawing.Size(518, 60);
            this.pnlNoRights.TabIndex = 14;
            this.pnlNoRights.Visible = false;
            // 
            // lblEvaluierungNichtEinsehen
            // 
            this.lblEvaluierungNichtEinsehen.AutoSize = true;
            this.lblEvaluierungNichtEinsehen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvaluierungNichtEinsehen.Location = new System.Drawing.Point(51, 21);
            this.lblEvaluierungNichtEinsehen.Name = "lblEvaluierungNichtEinsehen";
            this.lblEvaluierungNichtEinsehen.Size = new System.Drawing.Size(367, 24);
            this.lblEvaluierungNichtEinsehen.TabIndex = 0;
            this.lblEvaluierungNichtEinsehen.Text = "Sie dürfen die Evaluierung nicht einsehen.";
            // 
            // ucZielEvaluierung1
            // 
            this.ucZielEvaluierung1.BackColor = System.Drawing.Color.Transparent;
            this.ucZielEvaluierung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucZielEvaluierung1.Location = new System.Drawing.Point(0, 0);
            this.ucZielEvaluierung1.Name = "ucZielEvaluierung1";
            this.ucZielEvaluierung1.Size = new System.Drawing.Size(738, 467);
            this.ucZielEvaluierung1.TabIndex = 15;
            this.ucZielEvaluierung1.Wundejn = false;
            this.ucZielEvaluierung1.Load += new System.EventHandler(this.ucZielEvaluierung1_Load);
            // 
            // ucSiteMapEvaluierung1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pnlNoRights);
            this.Controls.Add(this.ucZielEvaluierung1);
            this.Name = "ucSiteMapEvaluierung1";
            this.Size = new System.Drawing.Size(738, 467);
            this.VisibleChanged += new System.EventHandler(this.ucSiteMapEvaluierung1_VisibleChanged);
            this.pnlNoRights.ResumeLayout(false);
            this.pnlNoRights.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlNoRights;
        private QS2.Desktop.ControlManagment.BaseLableWin lblEvaluierungNichtEinsehen;
        private ucZielEvaluierung ucZielEvaluierung1;


    }
}
