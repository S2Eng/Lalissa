using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PMDS.DB;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{

	public class ucZusatzWert : QS2.Desktop.ControlManagment.BaseControl, IReadOnly, IWizardPage
	{
		private bool _init = false;
		private IZusatz _iZusatz;
		private ZusatzWert _zwDefault;
		private ZusatzWert _zwENVAbt;
		private Hashtable _hash = new Hashtable();

		private bool _bIgnoreNotOptional = false;

		private bool _valueChangeEnabled = true;
		public event EventHandler ValueChanged;
		private QS2.Desktop.ControlManagment.BasePanel panelItems;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.ComponentModel.IContainer components = null;

        public Guid IDAufenthalt = System.Guid.Empty;

        public ArrayList listControlsEF = new ArrayList();
        public PMDSBusiness PMDSBusiness1 = new PMDSBusiness();









        public ucZusatzWert()
		{
			InitializeComponent();

			_zwDefault = new ZusatzWert();
			_zwENVAbt = new ZusatzWert();
		}

		public bool IgnoreNotOptional 
		{
			get {return _bIgnoreNotOptional;} set {_bIgnoreNotOptional = value;}
		}

		public bool HAS_ADDITIONAL_VALUES 
		{
			get 
			{
				if(_zwDefault.ZusatzWerte.Count > 0 || _zwENVAbt.ZusatzWerte.Count > 0)
					return true;
				else
					return false;
			}
		}
        public int ADDITIONAL_VALUES_COUNT
        {
            get { return _zwDefault.ZusatzWerte.Count + _zwENVAbt.ZusatzWerte.Count; }
        }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panelItems = new QS2.Desktop.ControlManagment.BasePanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelItems
            // 
            this.panelItems.AutoScroll = true;
            this.panelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelItems.Location = new System.Drawing.Point(0, 0);
            this.panelItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(587, 423);
            this.panelItems.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucZusatzWert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.panelItems);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucZusatzWert";
            this.Size = new System.Drawing.Size(587, 423);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public IZusatz IZusatz
		{
			get	{	return _iZusatz;	}
			set	
			{	
				_valueChangeEnabled = false;
				_iZusatz = value;
                UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

		public void UpdateGUI()
		{
			// kein Interface vorhanden
			if (IZusatz == null)
				return;

			try
			{
				ZusatzWert.AllZusatzWerte(IZusatz, out _zwDefault, out _zwENVAbt);

				// reinitialiserung notwendig
				if (ReInit())
					_init = false;

				// wenn notwendig elemente erzeugen
				if (!_init)
				{
					// alte Elemente entfernen
					panelItems.SuspendLayout();
					panelItems.Controls.Clear();
					_hash.Clear();

					CreateItems(ENV.String("INFO_ALL_ABTEILUNG"),_zwDefault);
					CreateItems(ENV.String("INFO_CUR_ABTEILUNG"),_zwENVAbt);
					_init = true;

					panelItems.ResumeLayout();
				}

				// mit Daten füllen
                UpdateItems(_zwDefault, this.IDAufenthalt);
                UpdateItems(_zwENVAbt, this.IDAufenthalt);
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
        public void showZusatzwerteEF(Guid IDEintrag, Guid IDPE, PMDS.db.Entities.ERModellPMDSEntities db, frmPflegeEintragSmall mainWindowEditEintragÜbergabe, Guid IDAufenthalt)
        {
            try
            {
                _hash.Clear();
                string Delimter = "\n";
                this.listControlsEF = new ArrayList();

                IQueryable<db.Entities.ZusatzGruppeEintrag> tZusatzGruppeEintrag = db.ZusatzGruppeEintrag.Where(b => b.IDFilter == IDEintrag).Where(b => b.AktivJN == true).OrderBy(a => a.Reihenfolge);
                foreach (db.Entities.ZusatzGruppeEintrag rZusatzGruppeEintrag in tZusatzGruppeEintrag)
                {
                    IQueryable<db.Entities.ZusatzEintrag> tZusatzEintrag = db.ZusatzEintrag.Where(b => b.ID == rZusatzGruppeEintrag.IDZusatzEintrag);
                    if (tZusatzEintrag.Count() == 1)
                    {
                        db.Entities.ZusatzEintrag rZusatzEintrag  = tZusatzEintrag.First();

                        IQueryable<db.Entities.ZusatzWert> tZusatzWert = db.ZusatzWert.Where(b => b.IDZusatzGruppeEintrag == rZusatzGruppeEintrag.ID && b.IDObjekt == IDPE);
                        foreach (db.Entities.ZusatzWert rZusatzWert in tZusatzWert)
                        {
                            ZusatzWertPara ZusatzWertPara1 = new ZusatzWertPara(rZusatzGruppeEintrag.ID);
                            if (rZusatzGruppeEintrag.OptionalJN != null)
                                ZusatzWertPara1.IsOptional = rZusatzGruppeEintrag.OptionalJN.Value;
                            if (rZusatzGruppeEintrag.DruckenJN != null)
                                ZusatzWertPara1.IsPrintable = rZusatzGruppeEintrag.DruckenJN.Value;
                            ZusatzWertPara1.Bezeichnung = rZusatzEintrag.Bezeichnung;
                            if (rZusatzEintrag.Typ != null)
                                ZusatzWertPara1.Type = (ZusatzEintragTyp)rZusatzEintrag.Typ;

                            if (rZusatzEintrag.MinValue != null)
                                ZusatzWertPara1.MinValue = rZusatzEintrag.MinValue;
                            if (rZusatzEintrag.MaxValue != null)
                                ZusatzWertPara1.MaxValue = rZusatzEintrag.MaxValue;
                            
                            dsINTListe dsINTListe1 = new dsINTListe();
                            foreach (string str in rZusatzEintrag.ListenEintraege.Split(Delimter.ToCharArray()))
                            {
                                if (str != "")
                                    dsINTListe1.INTListe.AddINTListeRow(dsINTListe1.INTListe.Rows.Count, str);
                            }
                            ZusatzWertPara1.Liste = dsINTListe1.INTListe;
                            ZusatzWertPara1.Value = rZusatzWert.Wert;
                            ZusatzWertPara1.IDZusatzwert = rZusatzWert.ID;
                            
                            this.listControlsEF.Add(ZusatzWertPara1);
                        }
                    }
                }

                dsZusatzWert dsZusatzWertCtrl = new dsZusatzWert();
                PMDS.DB.DBZusatzWert DBZusatzWert1 = new DB.DBZusatzWert(); 
                panelItems.Controls.Clear();
                ZusatzWertPara[] lstPars = (ZusatzWertPara[])this.listControlsEF.ToArray(typeof(ZusatzWertPara));
                foreach (ZusatzWertPara ZusatzWertPara1 in lstPars)
                {
                    ucZusatzWertCtrl ctrl = new ucZusatzWertCtrl(ZusatzWertPara1);
                    ctrl.mainWindowEditEintragÜbergabe = mainWindowEditEintragÜbergabe;
                    //ZusatzWertPara1.ctrl = ctrl;
                    ctrl.Dock = DockStyle.Top;
                    ctrl.ValueChanged += new EventHandler(OnValueChanged);
                    ctrl.IDAufenthalt = IDAufenthalt;

                    panelItems.Controls.Add(ctrl);
                    panelItems.Controls.SetChildIndex(ctrl, 0);

                    //if (ZusatzWertPara1.ID != Guid.Empty)
                    //{
                        if (!_hash.ContainsKey(ZusatzWertPara1.ID))
                        {
                            _hash.Add(ZusatzWertPara1.ID, ctrl);
                        }
                    //}

                    if (ZusatzWertPara1.IDZusatzwert != null)
                        DBZusatzWert1.readByID(ZusatzWertPara1.IDZusatzwert.Value);

                    dsZusatzWert.ZusatzWertRow rZusatzWert = (dsZusatzWert.ZusatzWertRow)DBZusatzWert1.dsZusatzWert1.ZusatzWert.Rows[0];

                    dsZusatzWert.ZusatzWertRow rNewZusatzEintragCtrl = (dsZusatzWert.ZusatzWertRow)dsZusatzWertCtrl.ZusatzWert.NewRow();
                    rNewZusatzEintragCtrl.ItemArray = rZusatzWert.ItemArray;
                    dsZusatzWertCtrl.ZusatzWert.Rows.Add(rNewZusatzEintragCtrl);

                    ctrl.IDAufenthalt = IDAufenthalt;
                    ctrl.Value = rNewZusatzEintragCtrl;
                }




                //foreach (dsZusatzWert.ZusatzWertRow r in zw.ZusatzWerte)
                //{
                //    ucZusatzWertCtrl ctrl = (ucZusatzWertCtrl)_hash[r.IDZusatzGruppeEintrag];
                //    if (ctrl != null)
                //    {
                //        ctrl.IDAufenthalt = IDAufenthalt;
                //        ctrl.Value = r;
                //    }
                //}

                //IQueryable<db.Entities.ZusatzWert> tZusatzWert = db.ZusatzWert.Where(b => b.IDZusatzGruppeEintrag == rZusatzGruppeEintrag.ID);
                //foreach (db.Entities.ZusatzWert rZusatzWert in tZusatzWert)
                //{
                //    ZusatzWertPara ZusatzWertPara1 = new ZusatzWertPara(rZusatzGruppeEintrag.ID);
                //    ZusatzWertPara1.IsOptional = rZusatzGruppeEintrag.OptionalJN.Value;
                //    ZusatzWertPara1.IsPrintable = rZusatzGruppeEintrag.DruckenJN.Value;
                //    ZusatzWertPara1.Bezeichnung = rZusatzEintrag.Bezeichnung;
                //    ZusatzWertPara1.Type = (ZusatzEintragTyp)rZusatzEintrag.Typ;

                //    ZusatzWertPara1.MinValue = rZusatzEintrag.MinValue;
                //    ZusatzWertPara1.MaxValue = rZusatzEintrag.MaxValue;

                //    dsINTListe dsINTListe1 = new dsINTListe();
                //    foreach (string str in rZusatzEintrag.ListenEintraege.Split(Delimter.ToCharArray()))
                //    {
                //        if (str != "")
                //            dsINTListe1.INTListe.AddINTListeRow(dsINTListe1.INTListe.Rows.Count, str);
                //    }
                //    ZusatzWertPara1.Liste = dsINTListe1.INTListe;
                //    ZusatzWertPara1.Value = rZusatzWert.Wert;

                //    al.Add(ZusatzWertPara1);
                //}
                //ucZusatzWertCtrl ctrl;
                //foreach (dsZusatzWert.ZusatzWertRow r in zw.ZusatzWerte)
                //{
                //    ctrl = (ucZusatzWertCtrl)_hash[r.IDZusatzGruppeEintrag];
                //    if (ctrl != null)
                //    {
                //        ctrl.IDAufenthalt = IDAufenthalt;
                //        ctrl.Value = r;
                //    }
                //}

                //UpdateItems(_zwDefault, this.IDAufenthalt);
                //UpdateItems(_zwENVAbt, this.IDAufenthalt);

            }
            catch (Exception ex)
            {
                throw new Exception("ucZusatzWert.showZusatzwerteEF: " + ex.ToString());
            }
        }

        public void saveZusatzwerteEF(Guid IDPflegeeintrag, PMDS.db.Entities.ERModellPMDSEntities dbxy)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    string sDekursTxt = "";
                    db.Entities.PflegeEintrag rPflegeEintrag = db.PflegeEintrag.Where(b => b.ID == IDPflegeeintrag).First();

                    foreach (ucZusatzWertCtrl ctrl in this.panelItems.Controls)
                    {
                        bool bAnyChanges = false;
                        ZusatzWertPara ZusatzWertPara1 = ctrl.ZusatzWertPara1;
                 
                        IQueryable<db.Entities.ZusatzWert> tZusatzWert = db.ZusatzWert.Where(b => b.ID == ZusatzWertPara1.IDZusatzwert);
                        db.Entities.ZusatzWert rZusatzWert = tZusatzWert.First();

                        if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.LABEL)
                        {
                            string sValueForEdit = rZusatzWert.Wert.Trim();
                            ctrl.UpdateDATA();
                            string sValue = ctrl._ctrl.GetControlText();
                            if (!sValueForEdit.Trim().Equals(sValue.Trim()))
                            {
                                rZusatzWert.Wert = sValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + sValueForEdit.Trim() + " -> " + rZusatzWert.Wert.Trim() + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.TEXT)
                        {
                            string sValueForEdit = rZusatzWert.Wert.Trim();
                            ctrl.UpdateDATA();
                            string sValue = ctrl._ctrl.GetControlText();
                            if (!sValueForEdit.Trim().Equals(sValue.Trim()))
                            {
                                rZusatzWert.Wert = sValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + sValueForEdit.Trim() + " -> " + rZusatzWert.Wert.Trim() + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.INT)
                        {
                            Nullable<int> iValueForEdit = rZusatzWert.ZahlenWert;
                            ctrl.UpdateDATA();
                            int iValue = ctrl.Value.ZahlenWert;
                            if (iValueForEdit != null && iValueForEdit != iValue)
                            {
                                rZusatzWert.ZahlenWert = iValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + iValueForEdit.Value.ToString() + " -> " + rZusatzWert.ZahlenWert.ToString() + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.BIG_TEXT)
                        {
                            string sValueForEdit = rZusatzWert.Wert.Trim();
                            ctrl.UpdateDATA();
                            string sValue = ctrl._ctrl.GetControlText();
                            if (!sValueForEdit.Trim().Equals(sValue.Trim()))
                            {
                                rZusatzWert.Wert = sValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + sValueForEdit.Trim() + " -> " + rZusatzWert.Wert.Trim() + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.IMAGE)
                        {
                            byte[] bValueForEdit = rZusatzWert.RawFormat;
                            ctrl.UpdateDATA();
                            byte[] bValue = ctrl.Value.RawFormat;
                            if (bValueForEdit != null && bValue != null && bValueForEdit.Length != bValue.Length)
                            {
                                rZusatzWert.RawFormat = bValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + "Image has changed" + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else if (ctrl.ZusatzWertPara1.Type == ZusatzEintragTyp.FLOAT)
                        {
                            Nullable<double> dValueForEdit = rZusatzWert.ZahlenWertFloat;
                            ctrl.UpdateDATA();
                            double dValue = ctrl.Value.ZahlenWertFloat;
                            if (dValueForEdit != null && dValueForEdit != dValue)
                            {
                                rZusatzWert.ZahlenWertFloat = dValue;
                                sDekursTxt += ctrl.labelInfo.Text.Trim() + ": " + dValueForEdit.Value.ToString() + " -> " + rZusatzWert.ZahlenWertFloat.ToString() + "\r\n";
                                bAnyChanges = true;
                            }
                        }
                        else
                        {
                            throw new Exception("ctrl.ZusatzWertPara1.Type '" + ctrl.ZusatzWertPara1.Type.ToString() + "' not allowed!");
                        }

                        if (bAnyChanges)
                        {
                            db.SaveChanges();
                        }
                    }

                    if (sDekursTxt.Trim() != "")
                    {
                        PflegeEintragTyp PflegeEintragTypWriteDekurs = PflegeEintragTyp.MASSNAHME;
                        string sTitleDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung Maßnahme Zusatzwerte");

                        if (rPflegeEintrag.EintragsTyp == (int)PflegeEintragTyp.DEKURS)
                        {
                            PflegeEintragTypWriteDekurs = PflegeEintragTyp.DEKURS;
                            sTitleDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung Zusatzwerte Dekurs");
                        }
                        else if (rPflegeEintrag.EintragsTyp == (int)PflegeEintragTyp.MASSNAHME)
                        {
                            PflegeEintragTypWriteDekurs = PflegeEintragTyp.MASSNAHME;
                            sTitleDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung Maßnahme Zusatzwerte");
                        }
                        else if (rPflegeEintrag.EintragsTyp == (int)PflegeEintragTyp.UNEXP_MASSNAHME)
                        {
                            PflegeEintragTypWriteDekurs = PflegeEintragTyp.UNEXP_MASSNAHME;
                            sTitleDekurs = QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung ungeplante Maßnahme Zusatzwerte");
                        }

                        this.PMDSBusiness1.writeDekurs(sTitleDekurs, sDekursTxt.Trim(), false, PMDS.Global.ENV.CurrentIDPatient, PflegeEintragTypWriteDekurs);
                    }
                }

                //ZusatzWertPara[] lstPars = (ZusatzWertPara[])this.listControlsEF.ToArray(typeof(ZusatzWertPara));
                //foreach (ZusatzWertPara ZusatzWertPara1 in lstPars)
                //{
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucZusatzWert.showZusatzwerteEF: " + ex.ToString());
            }
        }
        public void setEditOnOff(bool bEdit)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (ucZusatzWertCtrl ctrl in this.panelItems.Controls)
                    {
                        ZusatzWertPara ZusatzWertPara1 = ctrl.ZusatzWertPara1;
                        ctrl.ReadOnly = !bEdit;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucZusatzWert.setEditOnOff: " + ex.ToString());
            }
        }

        public void UpdateDATA()
		{
			// mit Daten füllen
			UpdateData(_zwDefault);
			UpdateData(_zwENVAbt);
		}

        public List<string> GetWertBezeichnung()
        {
            List<string> al = new List<string>();

            foreach (ucZusatzWertCtrl c in panelItems.Controls)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(c.GetLabelText());
                sb.Append(": ");
                sb.Append(c.GetValueText());
                al.Add(sb.ToString());
            }
    

            return al;
        }

		public void Write()
		{
			_zwDefault.Write();
			_zwENVAbt.Write();
		}

		public void Delete()
		{
			_zwDefault.Delete();
			_zwENVAbt.Delete();
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

		private void CreateItems(string label, ZusatzWert zw)
		{
			// Label erzeugen
//			ZusatzWertPara par = new ZusatzWertPara(Guid.Empty);		// Rausgenommen weil enz die Bezeichnungen hier nicht haben will
//			par.Bezeichnung = label;
//			par.Type		= ZusatzEintragTyp.LABEL;
//			AddItem(par);

			// neue Elemente einhängen
			foreach(ZusatzWertPara para in zw.ParameterListe())
				AddItem(para);

			// leere Zeile erzeugen                                     // 8.1.2007 RBU rausgenommen weil in ZW oben und unten eine leere Zeile war.....
            //ZusatzWertPara par2 = new ZusatzWertPara(Guid.Empty);
            //par2.Type		= ZusatzEintragTyp.LABEL;
            //AddItem(par2);
		}

		private void AddItem(ZusatzWertPara para)
		{
			ucZusatzWertCtrl ctrl = new ucZusatzWertCtrl(para);
			ctrl.Dock = DockStyle.Top;
			ctrl.ValueChanged += new EventHandler(OnValueChanged);

			panelItems.Controls.Add(ctrl);
			panelItems.Controls.SetChildIndex(ctrl, 0);

			if (para.ID != Guid.Empty)
				_hash.Add(para.ID, ctrl);
		}

        public int ITEMCount
        {
            get
            {
                return _hash.Count;
            }
        }

		private bool ReInit()
		{
			int nDef = _zwDefault.ZusatzWerte.Count;
			int nENV = _zwENVAbt.ZusatzWerte.Count;
			int nHash= _hash.Count;

			// Anzahl Elemente ist verschieden
			if ((nDef + nENV) != nHash)
				return true;

			if (ReInit(_zwDefault) || ReInit(_zwENVAbt))
				return true;

			return false;
		}

		private bool ReInit(ZusatzWert zw)
		{
			foreach(dsZusatzWert.ZusatzWertRow r in zw.ZusatzWerte)
			{
				if (_hash[r.IDZusatzGruppeEintrag] == null)
					return true;
			}

			return false;
		}

		private void UpdateItems(ZusatzWert zw, Guid IDAufenthalt)
		{
			ucZusatzWertCtrl ctrl;
			foreach(dsZusatzWert.ZusatzWertRow r in zw.ZusatzWerte)
			{
				ctrl = (ucZusatzWertCtrl)_hash[r.IDZusatzGruppeEintrag];
                if (ctrl != null)
                {
                    ctrl.IDAufenthalt = IDAufenthalt;
                    ctrl.Value = r;
                }
			}
		}

		private void UpdateData(ZusatzWert zw)
		{
			ucZusatzWertCtrl ctrl;
			foreach(dsZusatzWert.ZusatzWertRow r in zw.ZusatzWerte)
			{
				ctrl = (ucZusatzWertCtrl)_hash[r.IDZusatzGruppeEintrag];
				if (ctrl != null)
					ctrl.UpdateDATA();
			}
		}

		public bool ValidateFields()
		{
			bool bError = false;

			if(!_bIgnoreNotOptional) 
			{
				foreach(ucZusatzWertCtrl ctrl in panelItems.Controls)
					ctrl.ValidateFields(errorProvider1, ref bError);
			}

			return !bError;
		}

		public bool HasData
		{
			get	{	return (_hash.Count != 0);	}
		}

		#region IReadOnly Members

		private bool _ReadOnly = false;
		public bool ReadOnly
		{
			get
			{
				return _ReadOnly;
			}
			set
			{
				_ReadOnly = value;

				foreach(ucZusatzWertCtrl ctrl in panelItems.Controls)
					ctrl.ReadOnly = value;
			}
		}

		#endregion
	}

}

