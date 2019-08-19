//----------------------------------------------------------------------------
/// <summary>
/// Klassen um Dynamische Forms vor dem Druck eines Dynreports zu verarbeiten
/// Schnittstellendefinition für die Datenquellenverarbeitung
/// 
/// Über Strg+Shift+Alt+Return kann eine .Config Datei erzeugt werden
/// 
/// Erstellt am: 26.6.2007 von RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.BusinessLogic;

using RBU;
using Infragistics.Win.UltraWinEditors;
using System.Data;

namespace PMDS.GUI.BaseControls
{

    public interface IDynReportsDataSource
    {
        DataSet GetDataSource(List<PMDS.Print.CR.BerichtParameter> berichtpara);
    }

    public interface IDynReportsForm
    {
        List<PMDS.Print.CR.BerichtParameter> BERICHTPARAMETER { get; }
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// In der Config der Dynreports kann eine Form angegeben werden welche vor dem
    /// eigentlichen Drucken aufgerufen wird. Diese Form muss von DynReportsForm abgeleitet
    /// sein um verarbeitet werden zu können.
    /// 
    /// Die Form verarbeitet das sezten von Werten aufgrund SQL Statements und liefert
    /// die Werte als Berichtparameter zurück.
    /// 
    /// Der Ableiter muss lediglich die Funktion InitValues aufrufen.
    /// </summary>
    //----------------------------------------------------------------------------
    public class DynReportsForm : QS2.Desktop.ControlManagment.baseForm , IDynReportsForm
    {
        protected DynReportDefinition      _def = new DynReportDefinition("");

        public List<PMDS.Print.CR.BerichtParameter> BERICHTPARAMETER
        {
            get
            {
                List<PMDS.Print.CR.BerichtParameter> list = new List<PMDS.Print.CR.BerichtParameter>();
                GenerateParameterToList(list, this.Controls);
                return list;
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichert alle benutzaren Controls als Berichtsparameter in die Liste
        /// </summary>
        //----------------------------------------------------------------------------
        private void GenerateParameterToList(List<PMDS.Print.CR.BerichtParameter> list, Control.ControlCollection cc)
        {

            foreach (Control c in cc)
            {
                if (c.Name != "")
                {
                    if (c is CheckBox || c is UltraCheckEditor)
                    {
                        PMDS.Print.CR.BerichtParameter p = new PMDS.Print.CR.BerichtParameter(c.Name, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean, c.Name, "Select ...");
                        p.Value = c is CheckBox ? ((CheckBox)c).Checked : ((UltraCheckEditor)c).Checked;
                        list.Add(p);
                    }
                    else
                    {
                        if (c is TextBox || c is UltraTextEditor)
                        {
                            PMDS.Print.CR.BerichtParameter p = new PMDS.Print.CR.BerichtParameter(c.Name, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, c.Name, "Select ...");
                            p.Value = c is TextBox ? ((TextBox)c).Text.Trim() : ((UltraTextEditor)c).Text.Trim();
                            list.Add(p);
                        }
                        else
                            if (c is ComboBox || c is UltraComboEditor)
                            {
                                PMDS.Print.CR.BerichtParameter p = new PMDS.Print.CR.BerichtParameter(c.Name, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, c.Name, "Select ...");
                                p.Value = c is ComboBox ? ((ComboBox)c).Text.Trim() : ((UltraComboEditor)c).Text.Trim();
                                list.Add(p);
                            }
                    }
                }
                GenerateParameterToList(list, c.Controls);


            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Lesen der Konfiguration und setzten der Werte auf basis der in der
        /// Config Datei verspeicherten SQL Statements.
        /// Zugelassen sind zur Zeit Text für Textboxen und Boolean für Checkboxen.
        /// </summary>
        //----------------------------------------------------------------------------
        protected void InitValues(string sConfigFile)
        {
            _def.LoadFromConfig(sConfigFile);

            // für jeden Parameter schauen ob es ein äquivalent in der Form gibt und wenn ja das SQL Statement das in Default steht ausführen

            foreach (PMDS.Print.CR.BerichtParameter p in _def.PARAMTERS)
            {
                if (!(p.Typ == PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean || p.Typ == PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text))      // alles was nicht Text und Boolen ist einmal ignorieren
                    continue;

                Control c = GetFormControl(this.Controls, p.Name, p.Typ);

                if (c == null)                                                                       // Prüfen ob sich das gewünschte Control in der Form befindet
                    continue;

                bool bOk = true;
                string sSql = ParameterHelper.ReplacePlaceHolder(p.Default, out bOk);
                if (bOk)
                {
                    switch (p.Typ)                                                                       // Je nach Typ SQL ausführen und Control entsprechend besetzten
                    {
                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean:
                            bool bResult = DatabaseHelper.BooleanFromSQL(sSql);
                            if (c is CheckBox)
                                ((CheckBox)c).Checked = bResult;
                            else if (c is UltraCheckEditor)
                                ((UltraCheckEditor)c).Checked = bResult;
                            break;

                        case PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text:                    // Textbox, Ultratextbox, ComboBox und Ultracombo sind zugelassen
                            string sResult = DatabaseHelper.TextFromSQL(sSql);
                            if (c is TextBox)
                                ((TextBox)c).Text = sResult;
                            else if (c is UltraTextEditor)
                                ((UltraTextEditor)c).Text = sResult;
                            else if (c is ComboBox)
                                ((ComboBox)c).Text = sResult;
                            else if (c is UltraComboEditor)
                                ((UltraComboEditor)c).Text = sResult;
                            break;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüfen ob der Name vorhanden ist und ob der Typ stimmt
        /// Rekursiv
        /// </summary>
        //----------------------------------------------------------------------------
        private Control GetFormControl(Control.ControlCollection cc, string sName, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp typ)
        {
            foreach (Control c in cc)
            {
                if (c.Name == sName)
                {
                    if (typ == PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean)
                    {
                        if (c is CheckBox || c is UltraCheckEditor)
                            return c;
                        else
                            return null;
                    }
                    if (typ == PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text)
                    {
                        if (c is TextBox || c is UltraTextEditor)
                            return c;
                        else
                            return null;
                    }
                }

                Control c1 = GetFormControl(c.Controls, sName, typ);
                if (c1 != null)
                    return c1;
            }
            return null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Rohdaten generieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void GenerateConfigFile()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Config Files|*.config";
                dlg.Title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfigurationsdatei speichern");
                dlg.RestoreDirectory = true;
                dlg.InitialDirectory = Application.ExecutablePath;
                dlg.AddExtension = true;
                dlg.CheckFileExists = false;
                dlg.OverwritePrompt = true;
                DialogResult res = dlg.ShowDialog();
                if (res != DialogResult.OK)
                    return;
                _def.PARAMTERS.Clear();
                FillParamterFromForm(this.Controls);            // Berichtparameter füllen
                _def.Reportinfo = "Dynreportsform for " + this.Name;
                _def.WriteToConfigFile(dlg.FileName);           // Wie bei den Dynreports schreiben
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichert alle benutzaren Controls als Berichtsparameter in die Liste
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillParamterFromForm(Control.ControlCollection cc)
        {
            
            foreach (Control c in cc)
            {
                if (c.Name == "")
                    continue;

                if (c is CheckBox || c is UltraCheckEditor)
                    _def.PARAMTERS.Add(new PMDS.Print.CR.BerichtParameter(c.Name, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Boolean, c.Name, "Select ..."));
                if (c is TextBox || c is UltraTextEditor)
                    _def.PARAMTERS.Add(new PMDS.Print.CR.BerichtParameter(c.Name, PMDS.Print.CR.BerichtParameter.BerichtParameterTyp.Text, c.Name, "Select ..."));
                FillParamterFromForm(c.Controls);

                
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Alt && e.Shift && e.Control && e.KeyCode == Keys.Return)
                GenerateConfigFile();
            else
                if (e.Alt && e.Control && e.KeyCode == Keys.Return)
                    ShowParameters();
            else
                base.OnKeyDown(e);
        }

        private void ShowParameters()
        {
            frmShowBerichtParameter frm = new frmShowBerichtParameter(BERICHTPARAMETER);
            frm.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DynReportsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DynReportsForm";
            this.ResumeLayout(false);

        }
    }
}
