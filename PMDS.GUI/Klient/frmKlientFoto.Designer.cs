namespace PMDS.GUI.Klient
{
    partial class frmKlientFoto
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto vergrößern", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKlientFoto));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto nach rechts drehen.", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto löschen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto speichern nach ...", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Klientenfoto hinzufügen", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.btnMagnify = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtonsBild = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnPicRotateRight = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicClear = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicLoad = new QS2.Desktop.ControlManagment.BaseButton();
            this.foto3 = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelButtonsBild.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMagnify
            // 
            this.btnMagnify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = global::PMDS.GUI.Properties.Resources.ico_Vergrößern;
            appearance1.TextHAlignAsString = "Left";
            this.btnMagnify.Appearance = appearance1;
            this.btnMagnify.AutoWorkLayout = false;
            this.btnMagnify.IsStandardControl = false;
            this.btnMagnify.Location = new System.Drawing.Point(163, 127);
            this.btnMagnify.Name = "btnMagnify";
            this.btnMagnify.Size = new System.Drawing.Size(25, 25);
            this.btnMagnify.TabIndex = 14;
            ultraToolTipInfo5.ToolTipText = "Klientenfoto vergrößern";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnMagnify, ultraToolTipInfo5);
            this.btnMagnify.Visible = false;
            this.btnMagnify.Click += new System.EventHandler(this.btnMagnify_Click);
            // 
            // panelButtonsBild
            // 
            this.panelButtonsBild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtonsBild.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonsBild.Controls.Add(this.btnPicRotateRight);
            this.panelButtonsBild.Controls.Add(this.btnPicClear);
            this.panelButtonsBild.Controls.Add(this.btnPicSave);
            this.panelButtonsBild.Controls.Add(this.btnPicLoad);
            this.panelButtonsBild.Location = new System.Drawing.Point(162, 14);
            this.panelButtonsBild.Name = "panelButtonsBild";
            this.panelButtonsBild.Size = new System.Drawing.Size(26, 107);
            this.panelButtonsBild.TabIndex = 13;
            this.panelButtonsBild.Visible = false;
            // 
            // btnPicRotateRight
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.TextHAlignAsString = "Left";
            this.btnPicRotateRight.Appearance = appearance2;
            this.btnPicRotateRight.AutoWorkLayout = false;
            this.btnPicRotateRight.IsStandardControl = false;
            this.btnPicRotateRight.Location = new System.Drawing.Point(1, 77);
            this.btnPicRotateRight.Name = "btnPicRotateRight";
            this.btnPicRotateRight.Size = new System.Drawing.Size(25, 25);
            this.btnPicRotateRight.TabIndex = 19;
            ultraToolTipInfo1.ToolTipText = "Klientenfoto nach rechts drehen.";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicRotateRight, ultraToolTipInfo1);
            this.btnPicRotateRight.Click += new System.EventHandler(this.btnPicRotateRight_Click);
            // 
            // btnPicClear
            // 
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.TextHAlignAsString = "Left";
            this.btnPicClear.Appearance = appearance3;
            this.btnPicClear.AutoWorkLayout = false;
            this.btnPicClear.IsStandardControl = false;
            this.btnPicClear.Location = new System.Drawing.Point(0, 0);
            this.btnPicClear.Name = "btnPicClear";
            this.btnPicClear.Size = new System.Drawing.Size(25, 25);
            this.btnPicClear.TabIndex = 16;
            ultraToolTipInfo2.ToolTipText = "Klientenfoto löschen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicClear, ultraToolTipInfo2);
            this.btnPicClear.Click += new System.EventHandler(this.btnPicClear_Click);
            // 
            // btnPicSave
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.TextHAlignAsString = "Left";
            this.btnPicSave.Appearance = appearance4;
            this.btnPicSave.AutoWorkLayout = false;
            this.btnPicSave.IsStandardControl = false;
            this.btnPicSave.Location = new System.Drawing.Point(0, 51);
            this.btnPicSave.Name = "btnPicSave";
            this.btnPicSave.Size = new System.Drawing.Size(25, 25);
            this.btnPicSave.TabIndex = 18;
            ultraToolTipInfo3.ToolTipText = "Klientenfoto speichern nach ...";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicSave, ultraToolTipInfo3);
            this.btnPicSave.Click += new System.EventHandler(this.btnPicSave_Click);
            // 
            // btnPicLoad
            // 
            appearance5.Image = global::PMDS.GUI.Properties.Resources.ico_Aufnahme;
            appearance5.TextHAlignAsString = "Left";
            this.btnPicLoad.Appearance = appearance5;
            this.btnPicLoad.AutoWorkLayout = false;
            this.btnPicLoad.IsStandardControl = false;
            this.btnPicLoad.Location = new System.Drawing.Point(0, 26);
            this.btnPicLoad.Name = "btnPicLoad";
            this.btnPicLoad.Size = new System.Drawing.Size(25, 25);
            this.btnPicLoad.TabIndex = 17;
            ultraToolTipInfo4.ToolTipText = "Klientenfoto hinzufügen";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPicLoad, ultraToolTipInfo4);
            this.btnPicLoad.Click += new System.EventHandler(this.btnPicLoad_Click);
            // 
            // foto3
            // 
            this.foto3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BorderColor = System.Drawing.Color.LightGray;
            this.foto3.Appearance = appearance6;
            this.foto3.BackColor = System.Drawing.Color.White;
            this.foto3.BorderShadowColor = System.Drawing.Color.Empty;
            this.foto3.BorderShadowDepth = ((byte)(2));
            this.foto3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.foto3.Location = new System.Drawing.Point(12, 12);
            this.foto3.Name = "foto3";
            this.foto3.Size = new System.Drawing.Size(137, 145);
            this.foto3.TabIndex = 12;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = resources.GetString("saveFileDialog1.Filter");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = resources.GetString("openFileDialog1.Filter");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // frmKlientFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 170);
            this.Controls.Add(this.btnMagnify);
            this.Controls.Add(this.panelButtonsBild);
            this.Controls.Add(this.foto3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKlientFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Foto";
            this.Load += new System.EventHandler(this.frmKlientFoto_Load);
            this.panelButtonsBild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseButton btnMagnify;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsBild;
        private QS2.Desktop.ControlManagment.BaseButton btnPicRotateRight;
        private QS2.Desktop.ControlManagment.BaseButton btnPicClear;
        private QS2.Desktop.ControlManagment.BaseButton btnPicSave;
        private QS2.Desktop.ControlManagment.BaseButton btnPicLoad;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox foto3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}