namespace qs2.design.auto.multiControl
{
    partial class ownMultiControl
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.infragLabelLeft = new Infragistics.Win.Misc.UltraLabel();
            this.infragLabelRight = new Infragistics.Win.Misc.UltraLabel();
            this.panelButtonsOnOff = new Infragistics.Win.Misc.UltraPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.msPanelControls3 = new Infragistics.Win.Misc.UltraPanel();
            this.panelButtonsOnOff.ClientArea.SuspendLayout();
            this.panelButtonsOnOff.SuspendLayout();
            this.msPanelControls3.SuspendLayout();
            this.SuspendLayout();
            // 
            // infragLabelLeft
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.TextVAlignAsString = "Middle";
            this.infragLabelLeft.Appearance = appearance1;
            this.infragLabelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.infragLabelLeft.ImageTransparentColor = System.Drawing.Color.Empty;
            this.infragLabelLeft.Location = new System.Drawing.Point(0, 0);
            this.infragLabelLeft.Name = "infragLabelLeft";
            this.infragLabelLeft.Size = new System.Drawing.Size(115, 25);
            this.infragLabelLeft.TabIndex = 202;
            this.infragLabelLeft.Text = "[No Res defined]";
            // 
            // infragLabelRight
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.infragLabelRight.Appearance = appearance2;
            this.infragLabelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.infragLabelRight.Location = new System.Drawing.Point(254, 0);
            this.infragLabelRight.Name = "infragLabelRight";
            this.infragLabelRight.Size = new System.Drawing.Size(84, 25);
            this.infragLabelRight.TabIndex = 203;
            this.infragLabelRight.Text = "[No Res defined]";
            this.infragLabelRight.Visible = false;
            // 
            // panelButtonsOnOff
            // 
            // 
            // panelButtonsOnOff.ClientArea
            // 
            this.panelButtonsOnOff.ClientArea.Controls.Add(this.panelButtons);
            this.panelButtonsOnOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtonsOnOff.Location = new System.Drawing.Point(234, 0);
            this.panelButtonsOnOff.Name = "panelButtonsOnOff";
            this.panelButtonsOnOff.Size = new System.Drawing.Size(20, 25);
            this.panelButtonsOnOff.TabIndex = 222;
            this.panelButtonsOnOff.Visible = false;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(20, 25);
            this.panelButtons.TabIndex = 222;
            this.panelButtons.Visible = false;
            // 
            // msPanelControls3
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.msPanelControls3.Appearance = appearance3;
            this.msPanelControls3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msPanelControls3.Location = new System.Drawing.Point(115, 0);
            this.msPanelControls3.Name = "msPanelControls3";
            this.msPanelControls3.Size = new System.Drawing.Size(119, 25);
            this.msPanelControls3.TabIndex = 225;
            this.msPanelControls3.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.msPanelControls3_MouseEnterElement);
            this.msPanelControls3.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.msPanelControls3_MouseLeaveElement);
            // 
            // ownMultiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.msPanelControls3);
            this.Controls.Add(this.panelButtonsOnOff);
            this.Controls.Add(this.infragLabelRight);
            this.Controls.Add(this.infragLabelLeft);
            this.DoubleBuffered = true;
            this.Name = "ownMultiControl";
            this.Size = new System.Drawing.Size(338, 25);
            this.SizeChanged += new System.EventHandler(this.ownMultiControl_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ownMultiControl_VisibleChanged);
            this.panelButtonsOnOff.ClientArea.ResumeLayout(false);
            this.panelButtonsOnOff.ResumeLayout(false);
            this.msPanelControls3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.Misc.UltraLabel infragLabelLeft;
        public Infragistics.Win.Misc.UltraLabel infragLabelRight;
        internal Infragistics.Win.Misc.UltraPanel panelButtonsOnOff;
        public System.Windows.Forms.Panel panelButtons;
        internal Infragistics.Win.Misc.UltraPanel msPanelControls3;
    }
}
