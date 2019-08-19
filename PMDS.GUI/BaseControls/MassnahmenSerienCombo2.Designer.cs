namespace PMDS.GUI.BaseControls
{
    partial class MassnahmenSerienCombo2
    {
        
        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Add");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            
            // 
            // MassnahmenSerienCombo2
            // 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            editorButton1.Appearance = appearance1;
            editorButton1.Key = "Add";
            editorButton1.Text = "+";
            this.ButtonsRight.Add(editorButton1);
            this.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.MassnahmenCombo_EditorButtonClick);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
