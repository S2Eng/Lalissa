namespace PMDS.Calc.UI.Admin
{
    partial class frmJahresAb
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJahresAb));
            this.ultraGridBagLayoutPanelAll = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkNurAbgerech = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnApport = new QS2.Desktop.ControlManagment.BaseButton();
            this.dtBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblDurchführenBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.butStart = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).BeginInit();
            this.ultraGridBagLayoutPanelAll.SuspendLayout();
            this.panelAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAbgerech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridBagLayoutPanelAll
            // 
            this.ultraGridBagLayoutPanelAll.BackColor = System.Drawing.Color.Gainsboro;
            this.ultraGridBagLayoutPanelAll.Controls.Add(this.panelAll);
            this.ultraGridBagLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanelAll.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanelAll.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanelAll.Name = "ultraGridBagLayoutPanelAll";
            this.ultraGridBagLayoutPanelAll.Size = new System.Drawing.Size(397, 99);
            this.ultraGridBagLayoutPanelAll.TabIndex = 0;
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAll.Controls.Add(this.chkNurAbgerech);
            this.panelAll.Controls.Add(this.btnApport);
            this.panelAll.Controls.Add(this.dtBis);
            this.panelAll.Controls.Add(this.lblDurchführenBis);
            this.panelAll.Controls.Add(this.butStart);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanelAll.SetGridBagConstraint(this.panelAll, gridBagConstraint1);
            this.panelAll.Location = new System.Drawing.Point(5, 5);
            this.panelAll.Name = "panelAll";
            this.ultraGridBagLayoutPanelAll.SetPreferredSize(this.panelAll, new System.Drawing.Size(200, 100));
            this.panelAll.Size = new System.Drawing.Size(387, 89);
            this.panelAll.TabIndex = 0;
            // 
            // chkNurAbgerech
            // 
            this.chkNurAbgerech.Checked = true;
            this.chkNurAbgerech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNurAbgerech.Location = new System.Drawing.Point(215, 16);
            this.chkNurAbgerech.Name = "chkNurAbgerech";
            this.chkNurAbgerech.Size = new System.Drawing.Size(168, 27);
            this.chkNurAbgerech.TabIndex = 158;
            this.chkNurAbgerech.Text = "Nur abgerechnete Zahlungen";
            this.chkNurAbgerech.Visible = false;
            // 
            // btnApport
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnApport.Appearance = appearance1;
            this.btnApport.AutoWorkLayout = false;
            this.btnApport.IsStandardControl = false;
            this.btnApport.Location = new System.Drawing.Point(211, 52);
            this.btnApport.Name = "btnApport";
            this.btnApport.Size = new System.Drawing.Size(68, 26);
            this.btnApport.TabIndex = 157;
            this.btnApport.Text = "Abbruch";
            this.btnApport.Click += new System.EventHandler(this.btnApport_Click);
            // 
            // dtBis
            // 
            this.dtBis.DateTime = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBis.FormatString = "";
            this.dtBis.Location = new System.Drawing.Point(113, 19);
            this.dtBis.MaskInput = "";
            this.dtBis.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBis.Name = "dtBis";
            this.dtBis.Size = new System.Drawing.Size(97, 21);
            this.dtBis.TabIndex = 155;
            this.dtBis.Value = null;
            // 
            // lblDurchführenBis
            // 
            this.lblDurchführenBis.AutoSize = true;
            this.lblDurchführenBis.Location = new System.Drawing.Point(24, 23);
            this.lblDurchführenBis.Name = "lblDurchführenBis";
            this.lblDurchführenBis.Size = new System.Drawing.Size(84, 14);
            this.lblDurchführenBis.TabIndex = 156;
            this.lblDurchführenBis.Text = "Durchführen bis";
            // 
            // butStart
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.butStart.Appearance = appearance2;
            this.butStart.AutoWorkLayout = false;
            this.butStart.IsStandardControl = false;
            this.butStart.Location = new System.Drawing.Point(113, 52);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(97, 26);
            this.butStart.TabIndex = 154;
            this.butStart.Text = "Durchführen";
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // frmJahresAb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(397, 99);
            this.Controls.Add(this.ultraGridBagLayoutPanelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJahresAb";
            this.Text = "Jahreabschluß";
            this.Load += new System.EventHandler(this.frmJahresAb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanelAll)).EndInit();
            this.ultraGridBagLayoutPanelAll.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurAbgerech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanelAll;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BaseLabel lblDurchführenBis;
        private QS2.Desktop.ControlManagment.BaseButton butStart;
        private QS2.Desktop.ControlManagment.BaseButton btnApport;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtBis;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkNurAbgerech;
    }
}