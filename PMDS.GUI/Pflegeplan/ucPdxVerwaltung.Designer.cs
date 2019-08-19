namespace PMDS.GUI
{
    partial class ucPdxVerwaltung
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPdxVerwaltung));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelASZM = new PMDS.GUI.ucButton(this.components);
            this.btnAddASZM = new PMDS.GUI.ucButton(this.components);
            this.ucPdxVerwaltungTreeView1 = new PMDS.GUI.ucPdxVerwaltungTreeView();
            this.ucAdditionalASZMToPDx1 = new PMDS.GUI.ucAdditionalASZMToPDx();
            this.pnlM = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucMassnahmeDetails1 = new PMDS.GUI.ucMassnahmeDetails();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.grpMain = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDelASZM);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddASZM);
            this.splitContainer1.Panel1.Controls.Add(this.ucPdxVerwaltungTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.ucAdditionalASZMToPDx1);
            this.splitContainer1.Panel2.Controls.Add(this.pnlM);
            this.splitContainer1.Panel2.Controls.Add(this.ucMassnahmeDetails1);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 565);
            this.splitContainer1.SplitterDistance = 534;
            this.splitContainer1.TabIndex = 27;
            // 
            // btnDelASZM
            // 
            this.btnDelASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelASZM.Appearance = appearance1;
            this.btnDelASZM.AutoWorkLayout = false;
            this.btnDelASZM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelASZM.DoOnClick = true;
            this.btnDelASZM.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelASZM.IsStandardControl = true;
            this.btnDelASZM.Location = new System.Drawing.Point(482, 3);
            this.btnDelASZM.Name = "btnDelASZM";
            this.btnDelASZM.Size = new System.Drawing.Size(26, 22);
            this.btnDelASZM.TabIndex = 36;
            this.btnDelASZM.TabStop = false;
            this.btnDelASZM.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelASZM.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelASZM.Visible = false;
            this.btnDelASZM.Click += new System.EventHandler(this.btnDelASZM_Click);
            // 
            // btnAddASZM
            // 
            this.btnAddASZM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAddASZM.Appearance = appearance2;
            this.btnAddASZM.AutoWorkLayout = false;
            this.btnAddASZM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddASZM.DoOnClick = true;
            this.btnAddASZM.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAddASZM.IsStandardControl = true;
            this.btnAddASZM.Location = new System.Drawing.Point(507, 3);
            this.btnAddASZM.Name = "btnAddASZM";
            this.btnAddASZM.Size = new System.Drawing.Size(26, 22);
            this.btnAddASZM.TabIndex = 35;
            this.btnAddASZM.TabStop = false;
            this.btnAddASZM.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAddASZM.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAddASZM.Click += new System.EventHandler(this.btnAddASZM_Click);
            // 
            // ucPdxVerwaltungTreeView1
            // 
            this.ucPdxVerwaltungTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPdxVerwaltungTreeView1.BackColor = System.Drawing.Color.Transparent;
            this.ucPdxVerwaltungTreeView1.Location = new System.Drawing.Point(1, 25);
            this.ucPdxVerwaltungTreeView1.Name = "ucPdxVerwaltungTreeView1";
            this.ucPdxVerwaltungTreeView1.Size = new System.Drawing.Size(533, 533);
            this.ucPdxVerwaltungTreeView1.TabIndex = 26;
            this.ucPdxVerwaltungTreeView1.AfterNodeSelect += new PMDS.GUI.ucPdxVerwaltungTreeView.TreeviewAfterNodeSelectDelegate(this.ucPdxVerwaltungTreeView1_AfterNodeSelect);
            this.ucPdxVerwaltungTreeView1.BeforeNodeSelect += new PMDS.GUI.ucPdxVerwaltungTreeView.TreeviewBeforeNodeSelectDelegate(this.ucPdxVerwaltungTreeView1_BeforeNodeSelect);
            this.ucPdxVerwaltungTreeView1.AfterNodeCheck += new PMDS.GUI.ucPdxVerwaltungTreeView.TreeviewAfterCheckDelegate(this.ucPdxVerwaltungTreeView1_AfterNodeCheck);
            this.ucPdxVerwaltungTreeView1.BeforeNodeCheck += new PMDS.GUI.ucPdxVerwaltungTreeView.TreeviewBeforeCheckDelegate(this.ucPdxVerwaltungTreeView1_BeforeNodeCheck);
            // 
            // ucAdditionalASZMToPDx1
            // 
            this.ucAdditionalASZMToPDx1.BackColor = System.Drawing.Color.Transparent;
            this.ucAdditionalASZMToPDx1.CbPflegeplanVisible = true;
            this.ucAdditionalASZMToPDx1.Location = new System.Drawing.Point(17, 64);
            this.ucAdditionalASZMToPDx1.Name = "ucAdditionalASZMToPDx1";
            this.ucAdditionalASZMToPDx1.Size = new System.Drawing.Size(369, 418);
            this.ucAdditionalASZMToPDx1.TabIndex = 124;
            this.ucAdditionalASZMToPDx1.Visible = false;
            this.ucAdditionalASZMToPDx1.ASZMtoPDx += new PMDS.Global.ASZMtoPDxDelegate(this.ucAdditionalASZMToPDx1_ASZMtoPDx);
            // 
            // pnlM
            // 
            this.pnlM.Location = new System.Drawing.Point(4, 3);
            this.pnlM.Name = "pnlM";
            this.pnlM.Size = new System.Drawing.Size(260, 55);
            this.pnlM.TabIndex = 123;
            this.pnlM.Visible = false;
            // 
            // ucMassnahmeDetails1
            // 
            this.ucMassnahmeDetails1.BackColor = System.Drawing.Color.Transparent;
            this.ucMassnahmeDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMassnahmeDetails1.Location = new System.Drawing.Point(0, 0);
            this.ucMassnahmeDetails1.MinimumSize = new System.Drawing.Size(468, 495);
            this.ucMassnahmeDetails1.Name = "ucMassnahmeDetails1";
            this.ucMassnahmeDetails1.ReadOnly = false;
            this.ucMassnahmeDetails1.Size = new System.Drawing.Size(468, 565);
            this.ucMassnahmeDetails1.TabIndex = 0;
            this.ucMassnahmeDetails1.ValueChanged += new System.EventHandler(this.ucMassnahmeDetails1_ValueChanged);
            // 
            // lblInfo
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblInfo.Appearance = appearance3;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblInfo.Location = new System.Drawing.Point(13, 19);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(191, 14);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Keine Maßnahme wurde ausgewählt.";
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.splitContainer1);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.grpMain, gridBagConstraint1);
            this.grpMain.Location = new System.Drawing.Point(5, 5);
            this.grpMain.Name = "grpMain";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.grpMain, new System.Drawing.Size(1014, 587));
            this.grpMain.Size = new System.Drawing.Size(1014, 587);
            this.grpMain.TabIndex = 35;
            this.grpMain.Text = "Zur Pflegediagnose zugeordnete Ätiologien, Symptome, Ziele, Ressourcen und Maßnah" +
    "men";
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.grpMain);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(1024, 597);
            this.ultraGridBagLayoutPanel1.TabIndex = 36;
            // 
            // ucPdxVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucPdxVerwaltung";
            this.Size = new System.Drawing.Size(1024, 597);
            this.Load += new System.EventHandler(this.ucPdxVerwaltung_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucPdxVerwaltungTreeView ucPdxVerwaltungTreeView1;
        private ucMassnahmeDetails ucMassnahmeDetails1;
        private QS2.Desktop.ControlManagment.BaseGroupBox grpMain;
        private QS2.Desktop.ControlManagment.BaseLabel lblInfo;
        private ucAdditionalASZMToPDx ucAdditionalASZMToPDx1;
        private ucButton btnDelASZM;
        private ucButton btnAddASZM;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        protected QS2.Desktop.ControlManagment.BasePanel pnlM;
    }
}
