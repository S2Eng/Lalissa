namespace PMDS.GUI.BaseControls
{
    partial class ucBigComboBox
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("v");
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("s");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBigComboBox));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.cbMain = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).BeginInit();
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
            this.cbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance4.FontData.SizeInPoints = 20F;
            this.cbMain.ItemAppearance = appearance4;
            this.cbMain.Location = new System.Drawing.Point(0, 0);
            this.cbMain.MaxDropDownItems = 80;
            this.cbMain.MaxLength = 120;
            this.cbMain.MinimumSize = new System.Drawing.Size(0, 50);
            this.cbMain.Name = "cbMain";
            this.cbMain.Size = new System.Drawing.Size(270, 29);
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
            // ucBigComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbMain);
            this.Name = "ucBigComboBox";
            this.Size = new System.Drawing.Size(270, 51);
            ((System.ComponentModel.ISupportInitialize)(this.cbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseComboEditor cbMain;
    }
}
