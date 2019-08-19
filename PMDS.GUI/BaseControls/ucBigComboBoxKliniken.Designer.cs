using PMDS.Global.db.Patient;
namespace PMDS.GUI.BaseControls
{
    partial class ucBigComboBoxKliniken
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("v");
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("s");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBigComboBoxKliniken));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.cbMain = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsKlinik1 = new PMDS.Global.db.Patient.dsKlinik();
            this.panelCombo = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelCbo = new QS2.Desktop.ControlManagment.BasePanel();
            this.labelKliniken = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleKlinikenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFocus = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).BeginInit();
            this.panelCombo.SuspendLayout();
            this.panelCbo.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMain
            // 
            appearance1.BorderColor = System.Drawing.Color.LightGray;
            this.cbMain.Appearance = appearance1;
            this.cbMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BackColor2 = System.Drawing.Color.DarkGray;
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.cbMain.ButtonAppearance = appearance2;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton1.Key = "v";
            editorButton1.Text = "v";
            editorButton1.Width = 50;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            editorButton2.Appearance = appearance3;
            editorButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton2.Key = "s";
            editorButton2.Width = 50;
            this.cbMain.ButtonsRight.Add(editorButton1);
            this.cbMain.ButtonsRight.Add(editorButton2);
            this.cbMain.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.cbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMain.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cbMain.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance4.FontData.SizeInPoints = 20F;
            this.cbMain.ItemAppearance = appearance4;
            this.cbMain.Location = new System.Drawing.Point(0, 0);
            this.cbMain.MaxDropDownItems = 80;
            this.cbMain.MaxLength = 120;
            this.cbMain.Name = "cbMain";
            this.cbMain.Size = new System.Drawing.Size(228, 29);
            this.cbMain.TabIndex = 3;
            this.cbMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cbMain.SelectionChanged += new System.EventHandler(this.cbMain_SelectionChanged);
            this.cbMain.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cbMain_BeforeDropDown);
            this.cbMain.AfterDropDown += new System.EventHandler(this.cbMain_AfterDropDown);
            this.cbMain.AfterCloseUp += new System.EventHandler(this.cbMain_AfterCloseUp);
            this.cbMain.ValueChanged += new System.EventHandler(this.cbMain_ValueChanged);
            this.cbMain.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cbMain_EditorButtonClick);
            this.cbMain.AfterEditorButtonCloseUp += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.cbMain_AfterEditorButtonCloseUp);
            this.cbMain.TextChanged += new System.EventHandler(this.cbMain_TextChanged);
            // 
            // dsKlinik1
            // 
            this.dsKlinik1.DataSetName = "dsKlinik";
            this.dsKlinik1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsKlinik1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelCombo
            // 
            this.panelCombo.BackColor = System.Drawing.Color.Transparent;
            this.panelCombo.Controls.Add(this.panelCbo);
            this.panelCombo.Controls.Add(this.labelKliniken);
            this.panelCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCombo.Location = new System.Drawing.Point(0, 0);
            this.panelCombo.Name = "panelCombo";
            this.panelCombo.Size = new System.Drawing.Size(282, 35);
            this.panelCombo.TabIndex = 5;
            // 
            // panelCbo
            // 
            this.panelCbo.BackColor = System.Drawing.Color.Transparent;
            this.panelCbo.Controls.Add(this.cbMain);
            this.panelCbo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCbo.Location = new System.Drawing.Point(54, 0);
            this.panelCbo.Name = "panelCbo";
            this.panelCbo.Size = new System.Drawing.Size(228, 35);
            this.panelCbo.TabIndex = 6;
            // 
            // labelKliniken
            // 
            this.labelKliniken.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelKliniken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKliniken.Location = new System.Drawing.Point(0, 0);
            this.labelKliniken.Name = "labelKliniken";
            this.labelKliniken.Size = new System.Drawing.Size(54, 35);
            this.labelKliniken.TabIndex = 5;
            this.labelKliniken.Text = "Kliniken";
            this.labelKliniken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem,
            this.alleKlinikenLadenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(358, 48);
            // 
            // klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem
            // 
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Image")));
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Name = "klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem";
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(357, 22);
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Text = "Einrichtungen des angemeldeten Benutzers neu laden";
            this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem_Click);
            // 
            // alleKlinikenLadenToolStripMenuItem
            // 
            this.alleKlinikenLadenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alleKlinikenLadenToolStripMenuItem.Image")));
            this.alleKlinikenLadenToolStripMenuItem.Name = "alleKlinikenLadenToolStripMenuItem";
            this.alleKlinikenLadenToolStripMenuItem.Size = new System.Drawing.Size(357, 22);
            this.alleKlinikenLadenToolStripMenuItem.Text = "Alle Einrichtungen neu laden";
            this.alleKlinikenLadenToolStripMenuItem.Click += new System.EventHandler(this.alleKlinikenLadenToolStripMenuItem_Click);
            // 
            // btnFocus
            // 
            this.btnFocus.AutoWorkLayout = false;
            this.btnFocus.IsStandardControl = false;
            this.btnFocus.Location = new System.Drawing.Point(17, 8);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(17, 20);
            this.btnFocus.TabIndex = 6;
            this.btnFocus.Text = "ultraButton1";
            // 
            // ucBigComboBoxKliniken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panelCombo);
            this.Controls.Add(this.btnFocus);
            this.Name = "ucBigComboBoxKliniken";
            this.Size = new System.Drawing.Size(282, 35);
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinik1)).EndInit();
            this.panelCombo.ResumeLayout(false);
            this.panelCbo.ResumeLayout(false);
            this.panelCbo.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private  dsKlinik dsKlinik1;
        private QS2.Desktop.ControlManagment.BasePanel panelCombo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem klinikenFürAngemeldetenBenutzerNeuLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleKlinikenLadenToolStripMenuItem;
        private QS2.Desktop.ControlManagment.BaseButton btnFocus;
        private QS2.Desktop.ControlManagment.BasePanel panelCbo;
        private QS2.Desktop.ControlManagment.BaseLableWin labelKliniken;
        public QS2.Desktop.ControlManagment.BaseComboEditor cbMain;
    }
}
