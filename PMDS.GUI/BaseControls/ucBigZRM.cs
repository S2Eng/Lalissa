//----------------------------------------------------------------------------------------------
//	ucBigZRM.cs
//  Klasse zum darstellen der Zusatzwerte
//  Erstellt am:	21.5.2008
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigZRM : QS2.Desktop.ControlManagment.BaseControl
    {
        private dsZusatzwerteForEintrag.ZusatzEintragRow _row;
        public ucBigZRM()
        {
            InitializeComponent();
            nbMain.PromptChar = '_';
        }

        public void AddToZusatzWertTable(dsZusatzWert.ZusatzWertDataTable dt, Guid IDPflegeEintrag)
        {
            if (tbMain.Visible )
            {
                if (tbMain.Text.ToString().Trim() == "")               // Empty wird nicht in die DB geschrieben
                    return;
            }
            else if (nbMain.Visible )
            {
                if (nbMain.Value.ToString().Trim() == "") 
                    return;
            }
            else if (cbMain.Visible )
            {
                if (cbMain.Text.ToString().Trim() == "") 
                    return;
            }

            string sWert            = "";
            int iZahlenWert         = 0;
            double dblZahlenWert    = 0;
            ZusatzEintragTyp typ = (ZusatzEintragTyp)_row.Typ;
            switch (typ)
            {
                case ZusatzEintragTyp.TEXT  :
                    if (tbMain.Visible)
                        sWert = tbMain.Text;
                    else if (cbMain.Visible)
                        sWert = cbMain.Text;
                    break;
                case ZusatzEintragTyp.BIG_TEXT:
                    if (tbMain.Visible)
                        sWert = tbMain.Text;
                    else if (cbMain.Visible)
                        sWert = cbMain.Text;
                    break;

                case ZusatzEintragTyp.INT:
                    if (nbMain.Visible)
                        iZahlenWert = Convert.ToInt32(nbMain.Value);
                    else if (cbMain.Visible)
                        sWert = Convert.ToString (cbMain.Text );
                    break;
                   
                case ZusatzEintragTyp.FLOAT:
                    dblZahlenWert = Convert.ToDouble(nbMain.Value);
                    break;

                default:
                    break;
            }

            dt.AddZusatzWertRow(Guid.NewGuid(), _row.IDZusatzGruppeEintrag, IDPflegeEintrag, sWert, iZahlenWert, new byte[0], dblZahlenWert);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Initialisierung / Vorbelegung / Größenbestimmung
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitControl(dsZusatzwerteForEintrag.ZusatzEintragRow row)
        {
            _row = row;

            SetColor();

            lblMain.Text = row.Bezeichnung;
            ZusatzEintragTyp typ = (ZusatzEintragTyp)row.Typ;
            BigNumberSelectorTypes bigtyp = BigNumberSelectorTypes.Int;
            switch (typ)
            {
                case ZusatzEintragTyp.TEXT:
                case ZusatzEintragTyp.BIG_TEXT:
                    tbMain.Mulitline = typ == ZusatzEintragTyp.BIG_TEXT;
                    nbMain.Visible = false;
                    cbMain.Visible = false;
                    if (IsListe)
                    {
                        tbMain.Visible = false;
                        cbMain.Visible = true;
                        cbMain.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                        InitListEintraege();
                    }
                    break;

                case ZusatzEintragTyp.INT:
                case ZusatzEintragTyp.FLOAT:
                    cbMain.Visible = false;
                    tbMain.Visible = false;
                    if (IsListe)
                    {
                        nbMain.Visible = false;
                        cbMain.Visible = true;
                        cbMain.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                        InitListEintraege();
                    }
                    else
                    {
                        string sMask;
                        double von, bis, step;
                        if (_row.MaxValue == 0)
                        {
                            von = 0; bis = 100;
                        }
                        else
                        {
                            von = _row.MinValue; bis = _row.MaxValue;
                        }

                        if (typ == ZusatzEintragTyp.INT)
                        {
                            step = (int)((bis - von) / 100);
                            if (step == 0)
                                step = 1;
                            sMask = "nnnnnnnnn";
                        }
                        else
                        {
                            bigtyp = BigNumberSelectorTypes.Float;
                            step = (bis * 10.0 - von * 10.0) / 100.0;
                            step /= 10.0;
                            step = Math.Round(step, 1, MidpointRounding.AwayFromZero);
                            if (step == 0)
                                step = 0.1;
                            sMask = "nnnnnnnnn.nn";
                        }

                        nbMain.InitControl(bigtyp, sMask, "", von, bis, step, 15, null, null);
                    }
                    
                    break;
                case ZusatzEintragTyp.LABEL:
                case ZusatzEintragTyp.IMAGE:
                    throw new Exception("ucBigZRM::InitControl() - Typ Label oder Image nicht unterstützt ");
                
                default:
                    break;
            } // Switch
            ResizeControl();
        }


        private Color BackColorField { get {return _row.OptionalJN ? Color.White : Color.LightYellow;} }
        //----------------------------------------------------------------------------
        /// <summary>
        ///	Muss Felder müssen Gelb sein
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetColor()
        {
            nbMain.BackColor = BackColorField;
            cbMain.BackColor = BackColorField;
            tbMain.BackColor = BackColorField;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Auf die richtige größe bringen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ResizeControl()
        {
            int iHeight = 50;
            if (_row.Typ == (int)ZusatzEintragTyp.BIG_TEXT)
            {
                tbMain.Height = 100;
                iHeight = 105;
            }

            this.Height = iHeight;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Combobox mit Leben füllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitListEintraege()
        {
            string[] sa = _row.ListenEintraege.Split('\n');
            foreach (string s in sa)
                cbMain.Items.Add(Guid.NewGuid().ToString(), s);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert true wenn es sich um Listeneinträge handelt
        /// </summary>
        //----------------------------------------------------------------------------
        private bool IsListe
        {
            get
            {
                if(_row == null)
                    return false;

                if (_row.IsListenEintraegeNull() || _row.ListenEintraege.Trim().Length == 0)          // Keine Liste ==> keine Combo
                    return false;

                return true;
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert true wenn die Validierung erfolgreich war
        /// </summary>
        //----------------------------------------------------------------------------
        public new bool Validate()
        {
            if (_row.OptionalJN)
                return true;

            if (nbMain.Visible)
            {
                if (nbMain.tbNumber.Text.Trim() == "")
                {
                    string sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), _row.Bezeichnung);
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "Eingabe fehlt", MessageBoxButtons.OK, this, false);
                    return false;
                }
                if(_row.MaxValue != 0 && _row.MinValue != 0)
                {
                    if (Convert.ToDouble(nbMain.Value) > _row.MaxValue || Convert.ToDouble(nbMain.Value) < _row.MinValue)
                    {
                        string sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wert des Feldes {0} muss zwischen {1} und {2} liegen"), _row.Bezeichnung, _row.MinValue, _row.MaxValue);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Falscher Wertebereich"), MessageBoxButtons.OK, true);
                        //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "Falscher Wertebereich", MessageBoxButtons.OK, this, false);
                        return false;
                    }
                }
            }

            if (tbMain.Visible)
            {
                if (tbMain.Text.Trim() == "")
                {
                    string sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), _row.Bezeichnung );
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "Eingabe fehlt", MessageBoxButtons.OK, this, false);
                    return false;
                }
            }

            if (cbMain.Visible)
            {
                if (cbMain.Text.Trim() == "")
                {
                    string sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), _row.Bezeichnung);
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "Eingabe fehlt", MessageBoxButtons.OK, this, false);
                    return false;
                }
            }

            return true;
        }

        private void nbMain_Load(object sender, EventArgs e)
        {

        }
    }
}
