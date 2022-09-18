using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using QS2.Desktop.Txteditor;
using System.IO;
using qs2.core.vb;

namespace qs2.design.auto.print
{
    class cRTFDocuments
    {
        private TXTextControl.ServerTextControl editor = new TXTextControl.ServerTextControl();
        private QS2.Desktop.Txteditor.doBookmarks doBookmarks = new QS2.Desktop.Txteditor.doBookmarks();
        private byte[] BytesToLoad;
        private List<byte[]> ListOfDocuments = new List<byte[]>();
        private TXTextControl.LoadSettings settings;
        const string UserPrefix = "User_";
        const string sDate = ".Date";
        const string sTime = ".Time";
        const string sCheck = ".Check";
        const string sAutoColTrans = "autoColTrans_";
        const string sText = ".Text"; 

        public List<byte[]> CreateDocuments(string Filename, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport, bool ShowProgressBar)
        {
            try
            {
                string TableName = qs2.core.dbBase.tableNameQueries + InfoQuery.rSelListQry.IDRessource;
                using (DataTable dt = InfoQuery.dsQryResult.Tables[TableName])
                {
                    if (ShowProgressBar)
                        qs2.core.generic.FrmProgressInit(0, dt.Rows.Count, "Init ...");

                    if (LoadRTF(Filename))
                    {
                        for (int RowCount = 0; RowCount < dt.Rows.Count; RowCount++)
                        {
                            //Felder ersetzen
                            SetRTFValuesFromActiveUser();
                            SetRTFValuesFromQueryRow(dt.Rows[RowCount]);
                            SetDocumentAutomatisation(dt.Rows[RowCount]);
                            editor.Save(out BytesToLoad, TXTextControl.BinaryStreamType.InternalFormat);
                            ListOfDocuments.Add(BytesToLoad);
                            qs2.core.generic.FrmProgressUpdate(RowCount, (RowCount +  1).ToString() + " / " + dt.Rows.Count.ToString());
                            Application.DoEvents();
                        }
                    }
                    qs2.core.generic.FrmProgressClose();
                }
                return ListOfDocuments;
            }
            catch (Exception ex)
            {
                throw new Exception("cRTFDocuments.CreateDocuments: " + ex.ToString()); ;
            }
            finally
            {
                qs2.core.generic.FrmProgressClose();
            }
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
                    {
                        SetTextFrame(UserPrefix + KeyPairs[0].Trim(), KeyPairs[1].Trim());
                        SetTextField(UserPrefix + KeyPairs[0].Trim(), KeyPairs[1].Trim());
                    }
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
                    SetTextFrame(UserPrefix + c.ColumnName, actUser[c.ColumnName].ToString());
                    SetTextField(UserPrefix + c.ColumnName, actUser[c.ColumnName].ToString());
                }
            }
        }

        private void SetRTFValuesFromQueryRow(DataRow dataRow)
        {
            foreach (DataColumn c in dataRow.Table.Columns)
            {
                SetTextFrame(c.ColumnName, dataRow[c.ColumnName].ToString());
                SetTextField(c.ColumnName, dataRow[c.ColumnName].ToString());
            }
        }

        public List<KeyValuePair<string,string>> PrepareDocumentValues (DataRow dataRow)
        {
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();

            ret.Add(new KeyValuePair<string, string>("#DateNow#", DateTime.Now.ToShortDateString()));


            //Adressblock
            string Title = "";
            string FirstName = "<" + qs2.core.generic.TranslateEx("FirstName") + ">";
            string LastName = "<" + qs2.core.generic.TranslateEx("LastName") + ">"; ;
            string Gender = "";

            string PatStreet = "<" + qs2.core.generic.TranslateEx("PatStreet") + ">";
            string PatZIP = "<" + qs2.core.generic.TranslateEx("PatZIP") + ">";
            string PatCity = "<" + qs2.core.generic.TranslateEx("PatCity") + ">";
            string PatCountry = "";
            string PatCountryID = "";

            string Street = "<" + qs2.core.generic.TranslateEx("Street") + ">";
            string ZIP = "<" + qs2.core.generic.TranslateEx("ZIP") + ">";
            string City = "<" + qs2.core.generic.TranslateEx("City") + ">";
            string Country = "";
            string CountryID = "";

            string AdressSalutation = "";
            string AdressBlock = "";
            string AdressBlockAdmission = "";
            string LetterSalutation = "";

            string AdressSalutationEnglish = "";
            //string AdressBlockEnglish = "";
            //string AdressBlockAdmissionEnglish = "";
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
                    PatStreet = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatZIP", StringComparison.OrdinalIgnoreCase))
                    PatZIP = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatCity", StringComparison.OrdinalIgnoreCase))
                    PatCity = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("AutoColTrans_PatCountryID", StringComparison.OrdinalIgnoreCase))
                    PatCountry = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("PatCountryID", StringComparison.OrdinalIgnoreCase))
                    PatCountryID = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("Street", StringComparison.OrdinalIgnoreCase))
                    Street = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("ZIP", StringComparison.OrdinalIgnoreCase))
                    ZIP = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("City", StringComparison.OrdinalIgnoreCase))
                    City = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("AutoColTrans_CountryID", StringComparison.OrdinalIgnoreCase))
                    Country = dataRow[c.ColumnName].ToString();

                if (c.ColumnName.Equals("CountryID", StringComparison.OrdinalIgnoreCase))
                    CountryID = dataRow[c.ColumnName].ToString();

            }

            //------------ Adress-Anrede ---------------
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
            
            ret.Add(new KeyValuePair<string, string>("#AdressSalutation#", AdressSalutation));
            ret.Add(new KeyValuePair<string, string>("#AdressSalutationEnglish#", AdressSalutationEnglish));

            //----------------- Adress-Block (aus Patientendaten) --------------------
            AdressBlock += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            AdressBlock += FirstName + " " + LastName + "\n";
            AdressBlock += PatStreet + "\n";
            AdressBlock += PatZIP + " " + PatCity + "\n";
            AdressBlock += PatCountryID != "-1" && !PatCountryID.StartsWith("43") ? PatCountry : "";         // Für Österreich und unbekannt kein Land andrucken
            ret.Add(new KeyValuePair<string, string>("#FullAdress#", AdressBlock));
            ret.Add(new KeyValuePair<string, string>("#FullAdressEnglish#", AdressBlock));

            //----------------- Adress-Block (aus Aufenthaltsdaten) --------------------
            AdressBlockAdmission += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            AdressBlockAdmission += FirstName + " " + LastName + "\n";
            AdressBlockAdmission += Street + "\n";
            AdressBlockAdmission += ZIP + " " + City + "\n";
            AdressBlockAdmission += CountryID != "-1" && !CountryID.StartsWith("43") ? Country : "";         // Für Österreich und unbekannt kein Land andrucken
            ret.Add(new KeyValuePair<string, string>("#FullAdressAdmission#", AdressBlockAdmission));
            ret.Add(new KeyValuePair<string, string>("#FullAdressAdmissionEnglish#", AdressBlockAdmission));

            //-------------- Briefanrede -------------------
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
            ret.Add(new KeyValuePair<string, string>("#Salutation#", LetterSalutation));


            LetterSalutationEnglish += !String.IsNullOrWhiteSpace(Title) ? Title + " " : "";
            LetterSalutationEnglish += LastName;
            ret.Add(new KeyValuePair<string, string>("#SalutationEnglish#", LetterSalutationEnglish));

            return ret;
        }

        private void SetDocumentAutomatisation(DataRow dataRow)
        {
            foreach (KeyValuePair<string, string> kpv in PrepareDocumentValues(dataRow))
            {
                SetTextFrame(kpv.Key, kpv.Value);
                SetTextField(kpv.Key, kpv.Value);
            }
        }

        private void SetTextField(string sKey, string Txt)
        {
            try
            {
                foreach (TXTextControl.TextField txtField in editor.TextFields)
                {
                    //Set TextFieldName at first appearance
                    if (txtField.Text.Equals("[" + sKey + "]", StringComparison.OrdinalIgnoreCase))
                        txtField.Name = sKey;

                    if (txtField.Name.Equals(sKey, StringComparison.OrdinalIgnoreCase))
                    {
                        txtField.Text = Txt;
                    }

                    //--Text für Auswahllisten (mit Feldname + Erweiterung .Text) = Alternative zu autoColTrans_fieldname
                    if (txtField.Text.Equals("[" + sKey.Replace(sAutoColTrans,"") + sText + "]", StringComparison.OrdinalIgnoreCase))
                        txtField.Name = sKey.Replace(sAutoColTrans, "") + sText;

                    if (txtField.Name.Equals(sKey.Replace(sAutoColTrans, "") + sText, StringComparison.OrdinalIgnoreCase))
                    {
                        txtField.Text = Txt;
                    }

                    //--DatePart
                    if (txtField.Text.Equals("[" + sKey + sDate + "]", StringComparison.OrdinalIgnoreCase))
                        txtField.Name = sKey + sDate;

                    if (txtField.Name.Equals(sKey + sDate, StringComparison.OrdinalIgnoreCase))
                    {
                        char[] Sep = new char[] { ' ' };
                        string[] TimeParts = Txt.Split(Sep, StringSplitOptions.None);
                        txtField.Text = TimeParts[0];
                    }

                    //--Timepart
                    if (txtField.Text.Equals("[" + sKey + sTime + "]", StringComparison.OrdinalIgnoreCase))
                        txtField.Name = sKey + sTime;

                    if (txtField.Name.Equals(sKey + sTime, StringComparison.OrdinalIgnoreCase))
                    {
                        char[] Sep = new char[] { ' ' };
                        string[] TimeParts = Txt.Split(Sep, StringSplitOptions.None);
                        if (TimeParts.Length == 2)
                            txtField.Text = TimeParts[1];
                        else
                            txtField.Text = "";
                    }
                    //Checkbox
                    if (txtField.Text.Equals("[" + sKey + sCheck + "]", StringComparison.OrdinalIgnoreCase))
                            txtField.Name = sKey + sCheck;

                    if (txtField.Name.Equals(sKey + sCheck, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Txt == "1")
                        {
                            txtField.Text = ((char)253).ToString();
                        }
                        else if (Txt == "0")
                            txtField.Text = ((char)168).ToString();
                        else
                            txtField.Text = "";
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contRTFViewer.SetTextField:" + ex.ToString());
            }
        }


        private void SetTextFrame(string sKey, string Txt)
        {
            try
            {
                foreach (TXTextControl.TextFrame txtFrame in editor.TextFrames)
                {

                    txtFrame.Selection.Start = 0;
                    txtFrame.Selection.Length = 100;

                    if (txtFrame.Selection.Text.Equals(sKey, StringComparison.OrdinalIgnoreCase))
                        txtFrame.Name = sKey;

                    string selTxt = txtFrame.Selection.Text.Trim();
                    if (txtFrame.Name.Equals(sKey, StringComparison.OrdinalIgnoreCase))
                    {
                        txtFrame.Selection.Text = Txt;
                    }


                    //--Text für Auswahllisten (mit Feldname + Erweiterung .Text) = Alternative zu autoColTrans_fieldname
                    if (txtFrame.Selection.Text.Equals("[" + sKey.Replace(sAutoColTrans, "") + sText + "]", StringComparison.OrdinalIgnoreCase))
                        txtFrame.Name = sKey.Replace(sAutoColTrans, "") + sText;

                    if (txtFrame.Name.Equals(sKey.Replace(sAutoColTrans, "") + sText, StringComparison.OrdinalIgnoreCase))
                    {
                        txtFrame.Selection.Text = Txt;
                    }

                    //--DatePart
                    if (txtFrame.Selection.Text.Equals(sKey + sDate, StringComparison.OrdinalIgnoreCase))
                        txtFrame.Name = sKey + sDate;

                    selTxt = txtFrame.Selection.Text.Trim();
                    if (txtFrame.Name.Equals(sKey + sDate, StringComparison.OrdinalIgnoreCase))
                    {
                        char[] Sep = new char[] { ' ' };
                        string[] TimeParts = Txt.Split(Sep, StringSplitOptions.None);
                        txtFrame.Selection.Text = TimeParts[0];
                    }

                    //--TimePart
                    if (txtFrame.Selection.Text.Equals(sKey + sDate, StringComparison.OrdinalIgnoreCase))
                        txtFrame.Name = sKey + sTime;

                    selTxt = txtFrame.Selection.Text.Trim();
                    if (txtFrame.Name.Equals(sKey + sTime, StringComparison.OrdinalIgnoreCase))
                    {
                        char[] Sep = new char[] { ' ' };
                        string[] TimeParts = Txt.Split(Sep, StringSplitOptions.None);
                        if (TimeParts.Length == 2)
                            txtFrame.Selection.Text = TimeParts[0];
                        else
                            txtFrame.Selection.Text = "";
                    }

                    //Checkbox
                    if (txtFrame.Selection.Text.Equals("[" + sKey + sCheck + "]", StringComparison.OrdinalIgnoreCase))
                        txtFrame.Name = sKey + sCheck;

                    if (txtFrame.Name.Equals(sKey + sCheck, StringComparison.OrdinalIgnoreCase))
                    {
                        if (Txt == "1")
                        {
                            txtFrame.Selection.Text = ((char)253).ToString();
                        }
                        else if (Txt == "0")
                            txtFrame.Selection.Text = ((char)168).ToString();
                        else
                            txtFrame.Selection.Text = "";
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
