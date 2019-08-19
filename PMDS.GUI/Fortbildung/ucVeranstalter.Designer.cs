namespace PMDS.GUI.Fortbildung
{
    partial class ucVeranstalter
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVeranstalter));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.cboVeranstalter = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblVeranstalter = new QS2.Desktop.ControlManagment.BaseLabel();
            this.optErfolg = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.panelVeranstalter = new System.Windows.Forms.Panel();
            this.btnEdit = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboUsers = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.grpAuflistenNach = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboVeranstalter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optErfolg)).BeginInit();
            this.panelVeranstalter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAuflistenNach)).BeginInit();
            this.grpAuflistenNach.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboVeranstalter
            // 
            this.cboVeranstalter.AutoSize = false;
            this.cboVeranstalter.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance1.FontData.SizeInPoints = 10F;
            this.cboVeranstalter.ItemAppearance = appearance1;
            this.cboVeranstalter.Location = new System.Drawing.Point(113, 9);
            this.cboVeranstalter.Margin = new System.Windows.Forms.Padding(4);
            this.cboVeranstalter.Name = "cboVeranstalter";
            this.cboVeranstalter.Size = new System.Drawing.Size(507, 31);
            this.cboVeranstalter.TabIndex = 0;
            this.cboVeranstalter.ValueChanged += new System.EventHandler(this.cboVeranstalter_ValueChanged);
            // 
            // lblVeranstalter
            // 
            this.lblVeranstalter.AutoSize = true;
            this.lblVeranstalter.Location = new System.Drawing.Point(11, 15);
            this.lblVeranstalter.Margin = new System.Windows.Forms.Padding(5);
            this.lblVeranstalter.Name = "lblVeranstalter";
            this.lblVeranstalter.Size = new System.Drawing.Size(79, 17);
            this.lblVeranstalter.TabIndex = 120;
            this.lblVeranstalter.Text = "Veranstalter";
            // 
            // optErfolg
            // 
            this.optErfolg.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.optErfolg.CheckedIndex = 0;
            valueListItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Veranstalter";
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Fortbildungen";
            valueListItem1.DataValue = 2;
            valueListItem1.DisplayText = "Benutzer";
            this.optErfolg.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2,
            valueListItem3,
            valueListItem1});
            this.optErfolg.Location = new System.Drawing.Point(13, 21);
            this.optErfolg.Margin = new System.Windows.Forms.Padding(4);
            this.optErfolg.Name = "optErfolg";
            this.optErfolg.Size = new System.Drawing.Size(319, 18);
            this.optErfolg.TabIndex = 0;
            this.optErfolg.Text = "Veranstalter";
            this.optErfolg.ValueChanged += new System.EventHandler(this.optErfolg_ValueChanged);
            // 
            // panelVeranstalter
            // 
            this.panelVeranstalter.BackColor = System.Drawing.Color.Transparent;
            this.panelVeranstalter.Controls.Add(this.btnEdit);
            this.panelVeranstalter.Controls.Add(this.btnAdd);
            this.panelVeranstalter.Controls.Add(this.btnDelete);
            this.panelVeranstalter.Controls.Add(this.lblVeranstalter);
            this.panelVeranstalter.Controls.Add(this.cboVeranstalter);
            this.panelVeranstalter.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVeranstalter.Location = new System.Drawing.Point(0, 0);
            this.panelVeranstalter.Margin = new System.Windows.Forms.Padding(4);
            this.panelVeranstalter.Name = "panelVeranstalter";
            this.panelVeranstalter.Size = new System.Drawing.Size(754, 48);
            this.panelVeranstalter.TabIndex = 0;
            // 
            // btnEdit
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance2.TextVAlignAsString = "Middle";
            this.btnEdit.Appearance = appearance2;
            this.btnEdit.AutoWorkLayout = false;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.DoOnClick = true;
            this.btnEdit.ImageSize = new System.Drawing.Size(12, 12);
            this.btnEdit.IsStandardControl = true;
            this.btnEdit.Location = new System.Drawing.Point(663, 7);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 33);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.TabStop = false;
            this.btnEdit.TYPE = PMDS.GUI.ucButton.ButtonType.edit;
            this.btnEdit.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextVAlignAsString = "Middle";
            this.btnAdd.Appearance = appearance3;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(623, 7);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 33);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance4.TextVAlignAsString = "Middle";
            this.btnDelete.Appearance = appearance4;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(703, 7);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 33);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.TabStop = false;
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(13, 16);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(60, 17);
            this.lblBenutzer.TabIndex = 130;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // cboUsers
            // 
            this.cboUsers.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboUsers.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cboUsers.Location = new System.Drawing.Point(104, 12);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(338, 24);
            this.cboUsers.TabIndex = 131;
            this.cboUsers.ValueChanged += new System.EventHandler(this.cboUsers_ValueChanged);
            // 
            // grpAuflistenNach
            // 
            this.grpAuflistenNach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAuflistenNach.Controls.Add(this.optErfolg);
            this.grpAuflistenNach.Location = new System.Drawing.Point(853, -1);
            this.grpAuflistenNach.Margin = new System.Windows.Forms.Padding(4);
            this.grpAuflistenNach.Name = "grpAuflistenNach";
            this.grpAuflistenNach.Size = new System.Drawing.Size(299, 46);
            this.grpAuflistenNach.TabIndex = 1;
            this.grpAuflistenNach.Text = "Auflisten nach";
            // 
            // ucVeranstalter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblBenutzer);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.grpAuflistenNach);
            this.Controls.Add(this.panelVeranstalter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucVeranstalter";
            this.Size = new System.Drawing.Size(1161, 48);
            this.Load += new System.EventHandler(this.ucVeranstalter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboVeranstalter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optErfolg)).EndInit();
            this.panelVeranstalter.ResumeLayout(false);
            this.panelVeranstalter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAuflistenNach)).EndInit();
            this.grpAuflistenNach.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboVeranstalter;
        public QS2.Desktop.ControlManagment.BaseLabel lblVeranstalter;
        public ucButton btnAdd;
        public ucButton btnDelete;
        public ucButton btnEdit;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet optErfolg;
        private System.Windows.Forms.Panel panelVeranstalter;
        private Infragistics.Win.Misc.UltraGroupBox grpAuflistenNach;
        private QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboUsers;
    }
}
