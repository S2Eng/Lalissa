using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using System.IO;
using System.Drawing.Imaging;
using PMDS.Global;
using PMDS.Global.db.Global;
using Infragistics.Win.UltraWinToolTip;
using PMDS.DB;
using System.Linq;


namespace PMDS.GUI.BaseControls
{


    public partial class ucMedizinData : QS2.Desktop.ControlManagment.BaseControl
    {

        private Guid                _IDpatient          = Guid.Empty;
        private Guid                _IDAufenthalt       = Guid.Empty;
        public int                 _MedizinischerTyp   = -1;
        public bool IsExternControl = false;
        public Image imgIco = null;
        public Image imgIcoOff = null;

        private Image               _ON;
        private Image               _OFF;

        private bool                _NotfallIcon        = false;
        private bool                _NotStandardIcon    = false;

        private bool                _Sachwalter         = false;
        private bool        _freiheitsbeschränkt = false;
        
        private MedizinischeTypen   _typen              = new MedizinischeTypen();
        private MedizinischeDaten   _daten              = new MedizinischeDaten();

        private bool                _bON                = false;

        private bool                _HandleMouseKlicks = false;
        private string[]            _ColumnsToDisplay = { };

        public event MedizinischeDatenStateChangedDelegate   StateChanged;     
        public event NotfallSelectedDelegate                 NotfallSelected;  

        private string                                  _Bezeichnung = "";
        private string                                  _Beschreibung = "";
        private dsMedizinischeDaten.MedizinischeDatenDataTable  _dt;       








        public ucMedizinData()
        {
            InitializeComponent();
            timer2.Interval = 60000;
        }

        public string[] ColumnsToDisplay
        {
            get { return _ColumnsToDisplay; }
            set { _ColumnsToDisplay = value; }
        }

        public bool HandleMouseKlicks
        {
            get { return _HandleMouseKlicks; }
            set { _HandleMouseKlicks = value; }
        }

        public bool NotfallIcon
        {
            get { return _NotfallIcon; }
            set { _NotfallIcon = value; }
        }

        public bool NotStandardIcon
        {
            get { return _NotStandardIcon; }
            set { _NotStandardIcon = value; }
        }


        public bool ON
        {
            get { return _bON; }
            set { _bON = value; }
        }

        public void Init(int MedizinischerTyp)
        {
            _MedizinischerTyp = MedizinischerTyp;
            RefreshImage();
        }

        public void InitAsSachwalter()
        {
            _NotStandardIcon = true;
            _Sachwalter = true;
            ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);
        }

        public void InitAsFreiheitsbeschränkt()
        {
            _NotStandardIcon = true;
            _freiheitsbeschränkt = true;
            ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Rechte, 32, 32);
        }

        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPATIENT
        {
            set
            {
                _IDpatient = value;

                if (_Sachwalter)                                                
                {
                    string sText = Patient.SachwalterIconText(_IDpatient);
                    this.Visible = true;
                    if (sText == "")
                    {
                        UltraToolTipInfo infoEmpty = new UltraToolTipInfo();
                        infoEmpty.ToolTipText = "";
                        infoEmpty.ToolTipTitle = ""; 
                        this.ultraToolTipManager1.SetUltraToolTip(this.ultraPictureBox1, infoEmpty);
                        this.ultraToolTipManager1.SetUltraToolTip(this.lblTxt, infoEmpty);

                        this.ultraPictureBox1.Visible = true;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Visible = true;
                        this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                        this.ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);

                        return;
                    }
                     this.Visible = true;
                    //toolTip1.SetToolTip(pbMain, sText);

                    UltraToolTipInfo info = new UltraToolTipInfo();
                    info.ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter");
                    info.ToolTipText = sText.Trim();
                    this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);
                    this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    this.ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);
                    this.ultraPictureBox1.Visible = true;

                    return;
                }

                if (_freiheitsbeschränkt)                                                   
                {
                    PMDS.Global.retFkt ret; ;
                    ret=   Patient.freiheitsbeschränkungJN(_IDAufenthalt);
                    this.Visible = true;
                    if (ret.txt1  == "")
                    {
                        UltraToolTipInfo infoEmpty = new UltraToolTipInfo();
                        infoEmpty.ToolTipText = "";
                        infoEmpty.ToolTipTitle = "";
                        this.ultraToolTipManager1.SetUltraToolTip(this.ultraPictureBox1, infoEmpty);
                        this.ultraToolTipManager1.SetUltraToolTip(this.lblTxt, infoEmpty);

                        this.ultraPictureBox1.Visible = true;
                        this.BackColor = System.Drawing.Color.Transparent;
                        this.Visible = true;
                        this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                        this.ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);

                        return;
                    }
                    this.Visible = true;
                    //toolTip1.ToolTipTitle = ret.title ;
                    //toolTip1.SetToolTip(pbMain, ret.txt1 );
                    //toolTip1.ToolTipIcon = ToolTipIcon.Info;

                    UltraToolTipInfo info = new UltraToolTipInfo();
                    info.ToolTipTitle = ret.title;
                    info.ToolTipText = ret.txt1.Trim();
                    this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);
                    this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    this.ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Rechte, 32, 32);
                    this.ultraPictureBox1.Visible = true;

                    return;
                }

                if(_NotfallIcon)
                    SetIDAufenthalt();

                if (_IDpatient == Guid.Empty)
                {
                    ultraPictureBox1.Visible = false;
                }
                else
                {
                    ultraPictureBox1.Visible = true;
                    RefreshState();
                }
            }
        }

        private void SetIDAufenthalt()
        {
            if (_IDpatient == Guid.Empty)
            {
                _IDAufenthalt = Guid.Empty;
                return;
            }

            Patient pat = new Patient(_IDpatient);
            _IDAufenthalt = pat.Aufenthalt.ID;
        }

        public DateTime CURRENT_START
        {
            get
            {
                if (_dt.Count == 0)
                    return new DateTime(1900, 1, 1);

                dsMedizinischeDaten.MedizinischeDatenRow r = _dt[0];
                return r.Von;
            }
        }

        private void RefreshState()
        {
            try
            {
                if (_NotStandardIcon)
                    return;

                if (_NotfallIcon)
                    RefreshStateNotfall();
                else
                    RefreshStateNormal();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void RefreshStateNotfall()
        {
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                timer2.Enabled = false;




                ultraPictureBox1.ContextMenu = null;
                this.ContextMenu = null;
                Color maxNotfallColor = Color.Transparent;
                string txtTitle = "";
                StringBuilder sb1 = new StringBuilder();
                UltraToolTipInfo info = new UltraToolTipInfo();

                var tvHasSP = (from sp1 in db.SP
                                        join auf in db.Aufenthalt on sp1.IDAufenthalt equals auf.ID
                                        where auf.ID == _IDAufenthalt && sp1.offenJN == true
                                        select
                                            auf.IDPatient
                                        ).Count();

                if (tvHasSP > 0)
                {
                    ContextMenu menu = new ContextMenu();
                    var rS2_GetKlientenliste = (from kl in db.s2_GetKlientenliste(PMDS.Global.ENV.USERID.ToString(), (PMDS.Global.historie.HistorieOn == true ? 1 : 0), System.Guid.Empty.ToString())
                                                where kl.IDKlient == this._IDpatient
                                                select new
                                                {
                                                    IDKlient = kl.IDKlient,
                                                    kl.Notfall
                                                }).First();

                    if (rS2_GetKlientenliste.Notfall == "Nein")
                    {
                        maxNotfallColor = Color.White;
                    }
                    else if (rS2_GetKlientenliste.Notfall == "Ja, kein Termin offen")
                    {
                        maxNotfallColor = Color.Green;
                    }
                    else if (rS2_GetKlientenliste.Notfall == "Ja, Termin(e) offen")
                    {
                        maxNotfallColor = Color.Yellow;
                    }
                    else if (rS2_GetKlientenliste.Notfall == "Ja, Termin(e) überfällig")
                    {
                        maxNotfallColor = Color.Red;
                    }
                    else if (rS2_GetKlientenliste.Notfall == "Ja, Standardprozedur offen")
                    {
                        maxNotfallColor = Color.Orange;
                    }
                    else
                    {
                        throw new Exception("RefreshStateNotfall: rS2_GetKlientenliste.Notfall  '" + rS2_GetKlientenliste.Notfall.Trim() + "' not allowed!");
                    }

                    SP sp = new SP();
                    dsSP.SPDataTable dt = sp.AllOpen(_IDAufenthalt);
                    foreach (dsSP.SPRow r in dt.Rows)
                    {
                        //maxNotfallColor = Color.Orange;
                        //if (txtTitle.Trim() == "")
                        //{
                        //    txtTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Standardprozedur offen");
                        //}
                        bool IsNotfall = SP.NotfallJN(r);
                        if (IsNotfall)
                        {
                            //maxNotfallColor = Color.Green;
                            txtTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfälle");
                        }

                        StringBuilder sb = new StringBuilder();
                        sb.Append(SP.ToStringFromRow(r));
                        AddContextmenu(menu, r.ID, sb.ToString());
                        AddOpenPosTextAndSetColor(r.ID, sb, ref maxNotfallColor);               // offen Prozeduren listen und die Blinkfarbe vermerken
                        sb.Append("-----------------------------------------------\n\r");
                        sb1.Append(sb.ToString());
                        sb1.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzen Sie die rechte Maustaste, um den Vorfall zu öffnen."));

                        timer2.Enabled = true;
                        ultraPictureBox1.ContextMenu = menu;
                        this.ContextMenu = menu;
                    }
                }

                this.BackColor = maxNotfallColor;
                this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);
                //toolTip1.SetToolTip(pbMain, sb1.ToString());
                info.ToolTipTitle = txtTitle;
                info.ToolTipText = sb1.ToString();
            }
        }

        private void AddOpenPosTextAndSetColor(Guid IDSP, StringBuilder sb, ref Color maxNotfallColor)
        {
            List<SPNextHelper> al = SP.AllOpenSPPos(IDSP);
            foreach (SPNextHelper n in al)
            {
                maxNotfallColor = Color.Yellow;
                if (n._next < DateTime.Now)                             // Wenn Zeitpunkt abgelaufen, dann rot
                    maxNotfallColor = Color.Red;
                sb.Append(Environment.NewLine);
                sb.Append(n.ToString());
            }
        }

       
        private void AddContextmenu(ContextMenu menu, Guid guid, string s)
        {
            MenuItem item = menu.MenuItems.Add(s);
            item.Click += new EventHandler(item_Click);
            item.Tag = guid;
        }

        void item_Click(object sender, EventArgs e)
        {
            if (NotfallSelected == null)
                return;

            MenuItem item = (MenuItem)sender;
            NotfallSelected((Guid)item.Tag);
        }

        private void RefreshStateNormal()
        {
            _dt = _daten.GetOpenFromTyp(_IDpatient, _MedizinischerTyp);
            if (_dt.Count > 0)
            {
                ultraPictureBox1.Image = _ON;
                this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.ultraPictureBox1.BringToFront();
            }
            else
            {
                ultraPictureBox1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Transparent, 32, 32);
                this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                if (this._OFF != null)
                {
                    ultraPictureBox1.Image = this._OFF;
                    this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    this.ultraPictureBox1.BringToFront();
                }
            }

            //this.ultraPictureBox1.BackColor = System.Drawing.Color.Black;
            ultraPictureBox1.Refresh();

            _bON = (_dt.Count > 0);

            if (_bON)
            {
                SetToolTipFromOpenValues();
            } 
            else
            {
                //toolTip1.SetToolTip(pbMain, " ");
                UltraToolTipInfo info = new UltraToolTipInfo();
                info.ToolTipTitle = "";
                info.ToolTipText = "";
                this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);
            }
            
            //toolTip1.Active = _bON;
            RefreshBorder();
            Application.DoEvents();
        }

        private void SetToolTipFromOpenValues()
        {
            StringBuilder sb = new StringBuilder();
            foreach (dsMedizinischeDaten.MedizinischeDatenRow r in _dt.Rows)
            {

                string s = String.Format("Beginn: {0}", r.Von.ToShortDateString());
                sb.Append(s);
                

                foreach (string sc in ColumnsToDisplay)
                {
                    if (r.IsNull(sc))
                        continue;
                    string sadd = r[sc].ToString().Trim();
                    if (sadd.Length == 0)
                        continue;
                    sb.Append(Environment.NewLine);
                    sb.Append(sc);
                    sb.Append(":");
                    sb.Append(sadd);
                }
                sb.Append("\r\n-----------------------------------------------------------\r\n");
            }

            //toolTip1.SetToolTip(pbMain, sb.ToString());
            UltraToolTipInfo info = new UltraToolTipInfo();
            if (this._Bezeichnung.Trim() == "")
            {
                bool bNotTitle = true;
            }
            info.ToolTipTitle = this._Bezeichnung.Trim();
            if (sb.Length == 0)
            {
                sb.Append(" ");
            }
            info.ToolTipText = sb.ToString();
            this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);
        }

        private void RefreshBorder()
        {
            //pbMain.Appearance.BorderColor = _bON ?  Color.Black : Color.Transparent ;
            //pbMain.Appearance.BackColor = _bON ? Color.White : Color.Transparent;
        }

        private void RefreshImage()
        {
            dsMedizinischeTypen.MedizinischeTypenRow r = _typen.GetFromTyp(_MedizinischerTyp);

            _Bezeichnung = r.Beschreibung;
            //toolTip1.ToolTipTitle = _Bezeichnung;
            UltraToolTipInfo info = new UltraToolTipInfo();
            info.ToolTipTitle = _Bezeichnung;
            info.ToolTipText = " ";
            this.ultraToolTipManager1.SetUltraToolTip(ultraPictureBox1, info);

            if (!r.IsIconNull())
            {
                using (MemoryStream ms = new MemoryStream(r.Icon))
                {
                    _ON = Image.FromStream(ms);
                    ms.Close();
                }
            }

            if (!r.IsIconOFFNull())
            {
                using (MemoryStream ms = new MemoryStream(r.IconOFF))
                {
                    _OFF = Image.FromStream(ms);
                    ms.Close();
                }
            }

            ultraPictureBox1.Image = _OFF;
            this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
        }

        private void pbMain_Click(object sender, EventArgs e)
        {
            
            if(!HandleMouseKlicks)
                return;

            if (_bON)
                Ausschalten();
            else
                Einschalten();
        }

        private void Ausschalten()
        {
            dsMedizinischeDaten.MedizinischeDatenDataTable table =  _daten.GetOpenFromTyp(_IDpatient, _MedizinischerTyp);
            if (table.Rows.Count > 0)
            {
                foreach (dsMedizinischeDaten.MedizinischeDatenRow row in table)
                {
                    if (row.IsBisNull() && !row.IsBeschreibungNull())
                        _Beschreibung = row.Beschreibung;
                }
            }
            frmAskMedizinData2 frm = new frmAskMedizinData2(false, _Bezeichnung, _Beschreibung);
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            _daten.CloseOpenType(_IDpatient, _MedizinischerTyp, frm.TEXT, frm.DESCRIPTION, frm.DATE);
            RefreshState();
            SignalStateChange();
        }

        private void SignalStateChange()
        {
            if (StateChanged != null)
                StateChanged(_MedizinischerTyp);
        }

        private void Einschalten()
        {
            _Beschreibung = "";
            frmAskMedizinData2 frm = new frmAskMedizinData2(true, _Bezeichnung, _Beschreibung);
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;
            _daten.AddNewOpen(_dt, _IDpatient, ENV.USERID, _MedizinischerTyp, frm.TEXT, frm.DESCRIPTION, frm.DATE);
            RefreshState();
            SignalStateChange();
        }

        public override string ToString()
        {
            if (_NotfallIcon || _NotStandardIcon)
                return "";
            else 
                return string.Format("{0,-30}\t{1}", _Bezeichnung, CURRENT_START.ToShortDateString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible || _NotStandardIcon)
                return;
            ToogleIcon();
        }

        private void ToogleIcon()
        {
            _bON = !_bON;

            if (_ON != null && _OFF != null)
            {
                ultraPictureBox1.Image = _bON ? _ON : _OFF;
                this.ultraPictureBox1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!this.Visible || _NotStandardIcon)
                return;

            RefreshState();
        }

        private void ultraPictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

    }

}

