using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.Editor;
using QS2.Desktop.Txteditor;
using System.IO;
using qs2.core.vb;

namespace qs2.design.auto.print
{
    public partial class contRTFViewer : UserControl
    {
        private TXTextControl.ServerTextControl editor = new TXTextControl.ServerTextControl();
        private byte[] BytesToLoad;
        private List<byte[]> ListOfDocuments = new List<byte[]>();
        private TXTextControl.LoadSettings settings;
        const string UserPrefix = "User_";

        public contRTFViewer()
        {
            InitializeComponent();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            this.Text = qs2.core.language.sqlLanguage.getRes("Documents");
            settings = new TXTextControl.LoadSettings();
            ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
            ContTxtEditor1.LinealeOnOff(false);
            ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
            ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
            ContTxtEditor1.CreateControl();
            ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
            ContTxtEditor1.textControl1.InitializeLifetimeService();
        }

        public bool LoadDocument(in string Filename, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport)
        {
            string TableName = qs2.core.dbBase.tableNameQueries + InfoQuery.rSelListQry.IDRessource;
            using (DataTable dt = InfoQuery.dsQryResult.Tables[TableName])
            {
                if (LoadRTF(Filename))
                {
                    ultraProgressBar1.Maximum = dt.Rows.Count;
                    ultraPanel2.Visible = true;
                    ultraProgressBar1.Value = 0;
                    for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
                    {
                        //Felder ersetzen
                        SetRTFValuesFromActiveUser();
                        SetRTFValuesFromQueryRow(dt.Rows[RowCount]);
                        SetDocumentAutomatisation(dt.Rows[RowCount]);
                        editor.Save(out BytesToLoad, TXTextControl.BinaryStreamType.InternalFormat);
                        ListOfDocuments.Add(BytesToLoad);
                        ultraProgressBar1.Value = RowCount;
                        Application.DoEvents();
                    }
                    ultraPanel2.Visible = false;
                    Application.DoEvents();


                    QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                    QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                    frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                    frmEditor.ContTxtEditor1.LinealeOnOff(false);
                    frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                    frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                    frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                    frmEditor.Show();
                    frmEditor.Text = System.IO.Path.GetFileNameWithoutExtension(Filename);

                    frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                    //frmEditor.ContTxtEditor1.textControl1.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);

                    foreach (byte[] Document in ListOfDocuments)
                    {
                        /*ContTxtEditor2._textControl.Append(Document, TXTextControl.BinaryStreamType.InternalFormat, TXTextControl.AppendSettings.StartWithNewSection);*/

                        frmEditor.ContTxtEditor1.textControl1.Append(Document, TXTextControl.BinaryStreamType.InternalFormat, TXTextControl.AppendSettings.StartWithNewSection);
                    }
                    
                    Application.DoEvents();
                }
                else
                    return false;
            }
            return true;
        }

        private bool LoadRTF(string Filename)
        {
            try
            {
                if (File.Exists(Filename) && System.IO.Path.GetExtension(Filename).Equals(".RTF", StringComparison.OrdinalIgnoreCase))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                    editor.Create();
                    editor.InitializeLifetimeService();
                    TXTextControl.LoadSettings settings = new TXTextControl.LoadSettings();
                    editor.Load(Filename, TXTextControl.StreamType.RichTextFormat, settings);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contPDFViewer, OpenPDF: " + ex.ToString());
            }
        }

        private void SetRTFValuesFromUserClassification(string Classification)
        {
            //string Classification = qs2.core.vb.actUsr.rUsr.Classification;
            if (!string.IsNullOrWhiteSpace(Classification))
            {
                string[] AddEntries = Classification.Replace("\n", "").Replace("\r", "").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string AddEntry in AddEntries)
                {
                    string[] KeyPairs = AddEntry.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (KeyPairs.Length == 2)
                        SetTextField(UserPrefix + KeyPairs[0].Trim(), KeyPairs[1].Trim());
                }
            }
        }

        private void SetRTFValuesFromActiveUser()
        {
            dsObjects.tblObjectRow actUser = qs2.core.vb.actUsr.rUsr;
            foreach (DataColumn c in actUser.Table.Columns)
            {
                if (c.ColumnName.Equals("Classification", StringComparison.OrdinalIgnoreCase))
                {
                    SetRTFValuesFromUserClassification((string)actUser[c.ColumnName]);
                }
                else 
                {
                    SetTextField(UserPrefix + c.ColumnName, actUser[c.ColumnName].ToString());
                }
            }
        }

        private void SetRTFValuesFromQueryRow(DataRow dataRow)
        {
            foreach (DataColumn c in dataRow.Table.Columns)
            {
                SetTextField(c.ColumnName, dataRow[c.ColumnName].ToString());
            }
        }

        private void SetDocumentAutomatisation(DataRow dataRow)
        {
            SetTextField("#DateNow#", DateTime.Now.ToShortDateString());

            //Adressblock
            string Title = "";
            string FirstName = "<" + qs2.core.generic.TranslateEx("FirstName") + ">";
            string LastName = "<" + qs2.core.generic.TranslateEx("LastName") + ">"; ;
            string Gender = "";
            string Street = "<" + qs2.core.generic.TranslateEx("PatStreet") + ">";
            string ZIP = "<" + qs2.core.generic.TranslateEx("PatZIP") + ">";
            string City = "<" + qs2.core.generic.TranslateEx("PatCity") + ">";
            string Country = "";
            string CountryID = "";

            string AdressSalutation = "";
            string AdressBlock = "";
            string LetterSalutation = "";

            string AdressSalutationEnglish = "";
            string AdressBlockEnglish = "";
            string LetterSalutationEnglish = "";

            foreach (DataColumn c in dataRow.Table.Columns)
            {
                if (c.ColumnName.Equals("Title", StringComparison.OrdinalIgnoreCase))
                    Title = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                    FirstName = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                    LastName = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("Gender", StringComparison.OrdinalIgnoreCase))
                    Gender = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatStreet", StringComparison.OrdinalIgnoreCase))
                    Street = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatZIP", StringComparison.OrdinalIgnoreCase))
                    ZIP = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatCity", StringComparison.OrdinalIgnoreCase))
                    City = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("AutoColTrans_PatCountryID", StringComparison.OrdinalIgnoreCase))
                    Country = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatCountryID", StringComparison.OrdinalIgnoreCase))
                    CountryID = dataRow[c.ColumnName].ToString();
            }

            //Adress-Anrede
            if (Gender == "1")
            {
                AdressSalutation += qs2.core.generic.TranslateEx("Herrn");
                AdressSalutationEnglish += qs2.core.generic.TranslateEx("Mr.");
            }
            else if (Gender == "2")
            {
                AdressSalutation += qs2.core.generic.TranslateEx("Frau");
                AdressSalutationEnglish += qs2.core.generic.TranslateEx("Mrs.");
            }
            else
                AdressSalutation += "";

            SetTextField("#AdressSalutation#", AdressSalutation);
            SetTextField("#AdressSalutation#", AdressSalutationEnglish);

            AdressBlock += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            AdressBlock += FirstName + " " + LastName + "\n\r";
            AdressBlock += Street + "\n\r";
            AdressBlock += ZIP + " " + City + "\n\r";
            AdressBlock += CountryID != "-1" && !CountryID.StartsWith("43") ? Country : "";         // Für Österreich und unbekannt kein Land andrucken

            SetTextField("#FullAdress#", AdressBlock);
            SetTextField("#FullAdress#", AdressBlock);

            //Briefanrede
            if (Gender == "1")
            {
                LetterSalutation += qs2.core.generic.TranslateEx("Sehr geehrter Herr") + " ";
                LetterSalutationEnglish += qs2.core.generic.TranslateEx("Dear Mister") + " ";
            }
            else if (Gender == "2")
            {
                LetterSalutation += qs2.core.generic.TranslateEx("Sehr geehrte Frau") + " ";
                LetterSalutationEnglish += qs2.core.generic.TranslateEx("Dear Mrs.") + " ";
            }
            else
            {
                LetterSalutation += qs2.core.generic.TranslateEx("Sehr geehrt*") + " ";
                LetterSalutationEnglish += qs2.core.generic.TranslateEx("Dear") + " ";
            }

            LetterSalutation += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            LetterSalutation += LastName;
            SetTextField("#Salutation#", LetterSalutation);

            LetterSalutationEnglish += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            LetterSalutationEnglish += LastName;
            SetTextField("#SalutationEnglish#", LetterSalutationEnglish);
        }
        
        private void SetTextField(string sKey, string Txt)
        {
            try
            {
                foreach (TXTextControl.TextFrame txtFrame in editor.TextFrames)
                {
                    txtFrame.Selection.Start = 0;
                    txtFrame.Selection.Length = 100;

                    string selTxt = txtFrame.Selection.Text.Trim();
                    if (selTxt.Equals(sKey, StringComparison.OrdinalIgnoreCase))
                    {                        
                        txtFrame.Selection.Text = Txt;           
                    }
                    txtFrame.BorderWidth = 0;
                    txtFrame.Transparency = 100;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contRTFViewer.SetTextField:" + ex.ToString());
            }
        }
    }
}
