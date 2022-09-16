using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    partial class frmEditLinkDokumente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditLinkDokumente));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beschreibungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dokumentDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.gruppeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erstellungsdatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aenderungsdatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDBenutzerErstelltDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iconHochladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsLinkDokumente1 = new PMDS.Global.db.Global.dsLinkDokumente();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.label1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.ucButton1 = new PMDS.GUI.ucButton(this.components);
            this.btnShow = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLinkDokumente1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.beschreibungDataGridViewTextBoxColumn,
            this.linkNameDataGridViewTextBoxColumn,
            this.dokumentDataGridViewImageColumn,
            this.gruppeDataGridViewTextBoxColumn,
            this.erstellungsdatumDataGridViewTextBoxColumn,
            this.aenderungsdatumDataGridViewTextBoxColumn,
            this.iDBenutzerErstelltDataGridViewTextBoxColumn,
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 512);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // beschreibungDataGridViewTextBoxColumn
            // 
            this.beschreibungDataGridViewTextBoxColumn.DataPropertyName = "Beschreibung";
            this.beschreibungDataGridViewTextBoxColumn.HeaderText = "Beschreibung";
            this.beschreibungDataGridViewTextBoxColumn.Name = "beschreibungDataGridViewTextBoxColumn";
            this.beschreibungDataGridViewTextBoxColumn.Width = 500;
            // 
            // linkNameDataGridViewTextBoxColumn
            // 
            this.linkNameDataGridViewTextBoxColumn.DataPropertyName = "LinkName";
            this.linkNameDataGridViewTextBoxColumn.HeaderText = "LinkName";
            this.linkNameDataGridViewTextBoxColumn.Name = "linkNameDataGridViewTextBoxColumn";
            this.linkNameDataGridViewTextBoxColumn.Width = 500;
            // 
            // dokumentDataGridViewImageColumn
            // 
            this.dokumentDataGridViewImageColumn.DataPropertyName = "Dokument";
            this.dokumentDataGridViewImageColumn.HeaderText = "Dokument";
            this.dokumentDataGridViewImageColumn.Name = "dokumentDataGridViewImageColumn";
            this.dokumentDataGridViewImageColumn.Visible = false;
            // 
            // gruppeDataGridViewTextBoxColumn
            // 
            this.gruppeDataGridViewTextBoxColumn.DataPropertyName = "Gruppe";
            this.gruppeDataGridViewTextBoxColumn.HeaderText = "Gruppe";
            this.gruppeDataGridViewTextBoxColumn.Name = "gruppeDataGridViewTextBoxColumn";
            this.gruppeDataGridViewTextBoxColumn.Visible = false;
            // 
            // erstellungsdatumDataGridViewTextBoxColumn
            // 
            this.erstellungsdatumDataGridViewTextBoxColumn.DataPropertyName = "Erstellungsdatum";
            this.erstellungsdatumDataGridViewTextBoxColumn.HeaderText = "Erstellungsdatum";
            this.erstellungsdatumDataGridViewTextBoxColumn.Name = "erstellungsdatumDataGridViewTextBoxColumn";
            this.erstellungsdatumDataGridViewTextBoxColumn.Visible = false;
            // 
            // aenderungsdatumDataGridViewTextBoxColumn
            // 
            this.aenderungsdatumDataGridViewTextBoxColumn.DataPropertyName = "Aenderungsdatum";
            this.aenderungsdatumDataGridViewTextBoxColumn.HeaderText = "Aenderungsdatum";
            this.aenderungsdatumDataGridViewTextBoxColumn.Name = "aenderungsdatumDataGridViewTextBoxColumn";
            this.aenderungsdatumDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDBenutzerErstelltDataGridViewTextBoxColumn
            // 
            this.iDBenutzerErstelltDataGridViewTextBoxColumn.DataPropertyName = "IDBenutzer_Erstellt";
            this.iDBenutzerErstelltDataGridViewTextBoxColumn.HeaderText = "IDBenutzer_Erstellt";
            this.iDBenutzerErstelltDataGridViewTextBoxColumn.Name = "iDBenutzerErstelltDataGridViewTextBoxColumn";
            this.iDBenutzerErstelltDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDBenutzerGeaendertDataGridViewTextBoxColumn
            // 
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn.DataPropertyName = "IDBenutzer_Geaendert";
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn.HeaderText = "IDBenutzer_Geaendert";
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn.Name = "iDBenutzerGeaendertDataGridViewTextBoxColumn";
            this.iDBenutzerGeaendertDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconHochladenToolStripMenuItem,
            this.iconLöschenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 48);
            // 
            // iconHochladenToolStripMenuItem
            // 
            this.iconHochladenToolStripMenuItem.Name = "iconHochladenToolStripMenuItem";
            this.iconHochladenToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.iconHochladenToolStripMenuItem.Text = "Dokument hochladen";
            this.iconHochladenToolStripMenuItem.Click += new System.EventHandler(this.iconHochladenToolStripMenuItem_Click);
            // 
            // iconLöschenToolStripMenuItem
            // 
            this.iconLöschenToolStripMenuItem.Name = "iconLöschenToolStripMenuItem";
            this.iconLöschenToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.iconLöschenToolStripMenuItem.Text = "Dokument löschen";
            this.iconLöschenToolStripMenuItem.Click += new System.EventHandler(this.iconLöschenToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "LinkDokumente";
            this.bindingSource1.DataSource = this.dsLinkDokumente1;
            // 
            // dsLinkDokumente1
            // 
            this.dsLinkDokumente1.DataSetName = "dsLinkDokumente";
            this.dsLinkDokumente1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.doc";
            this.openFileDialog1.Filter = "Dokumente (doc)|*.doc|Dokumente (docx)|*.docx|Dokumente (pdf)|*.pdf|Alle Dateien|" +
    "*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Dokument laden";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Dokument speichern";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(912, 584);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(1008, 584);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(797, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Verwalten Sie hier die Dokumente. Nutzen Sie die rechte Maustaste, um Dokumente h" +
    "ochzuladen oder geben Sie in der Spalte LinkName einen Hyperlink ein.";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(999, 38);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(25, 22);
            this.btnDel.TabIndex = 0;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ucButton1
            // 
            this.ucButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ucButton1.Appearance = appearance4;
            this.ucButton1.AutoWorkLayout = false;
            this.ucButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucButton1.DoOnClick = true;
            this.ucButton1.ImageSize = new System.Drawing.Size(12, 12);
            this.ucButton1.IsStandardControl = true;
            this.ucButton1.Location = new System.Drawing.Point(1028, 38);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(25, 22);
            this.ucButton1.TabIndex = 11;
            this.ucButton1.TabStop = false;
            this.ucButton1.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.ucButton1.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // btnShow
            // 
            this.btnShow.AutoWorkLayout = false;
            this.btnShow.IsStandardControl = false;
            this.btnShow.Location = new System.Drawing.Point(656, 584);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 32);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Anzeigen";
            this.btnShow.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(762, 584);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Als Datei speichern";
            this.btnSave.Click += new System.EventHandler(this.baseButton2_Click);
            // 
            // frmEditLinkDokumente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 624);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.ucButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditLinkDokumente";
            this.ShowInTaskbar = false;
            this.Text = "Verwaltung der Pflegerichtlinien";
            this.Load += new System.EventHandler(this.frmEditLinkDokumente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLinkDokumente1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucButton btnCancel;
        private ucButton btnOK;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iconHochladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconLöschenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beschreibungDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dokumentDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gruppeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erstellungsdatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aenderungsdatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDBenutzerErstelltDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDBenutzerGeaendertDataGridViewTextBoxColumn;
        private dsLinkDokumente dsLinkDokumente1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private QS2.Desktop.ControlManagment.BaseLabel label1;
        private ucButton btnDel;
        private ucButton ucButton1;
        private QS2.Desktop.ControlManagment.BaseButton btnShow;
        private QS2.Desktop.ControlManagment.BaseButton btnSave;
    }
}