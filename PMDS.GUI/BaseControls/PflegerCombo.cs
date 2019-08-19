using System;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;
using PMDS.GUI.Engines;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using PMDS.DB;
using System.Linq;


namespace PMDS.GUI.BaseControls
{

	public class PflegerCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{

        private bool _cboIsDropDownStyle = false;
        public bool lstUseresAktivJNInitialized = false;
        public System.Collections.Generic.Dictionary<Guid, bool> lstUsersAktivJN = new System.Collections.Generic.Dictionary<Guid, bool>();




        public PflegerCombo(bool cboIsDropDownStyleTmp)
		{
            if (!DesignMode && ENV.AppRunning)
            {
                this._cboIsDropDownStyle = cboIsDropDownStyleTmp;
                RefreshList();
            }         
		}

        public void initComboUsersAktivJN()
        {
            try
            {
                if (!this.lstUseresAktivJNInitialized)
                {
                    lstUsersAktivJN.Clear();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        db.Configuration.LazyLoadingEnabled = false;
                        
                        var tBenutzer = (from b in db.Benutzer
                                            select new
                                            {
                                                ID = b.ID,
                                                AktivJN = b.AktivJN
                                            });

                        foreach (var rBenutzer in tBenutzer)
                        {
                            if (rBenutzer.AktivJN != null)
                                lstUsersAktivJN.Add(rBenutzer.ID, rBenutzer.AktivJN.Value);
                            else
                                lstUsersAktivJN.Add(rBenutzer.ID, false);
                        }
                    }
                    this.lstUseresAktivJNInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PflegerCombo.initComboUsersAktivJN: " + ex.ToString());
            }
        }

        public override void RefreshList()
		{
			try
			{
                //this.Items.Clear();
                //foreach (dsGUIDListe.IDListeRow r in Benutzer.AllPfleger())
                //this.Items.Add(r.ID, r.TEXT);

                this.Items.Clear();
                PMDS.DB.DBBenutzer DBBenutzer1 = new DB.DBBenutzer();
                dsGUIDListe dsUsr = new dsGUIDListe();

                DBBenutzer1.getAllBenutzerOrderByAktiv(dsUsr);
                foreach (dsGUIDListe.IDListeRow rUsr in dsUsr.IDListe.Rows)
                {
                    this.Items.Add(rUsr.ID, rUsr.TEXT.Trim());
                }

                //this.Items.Clear();
                //_verwaltung = new EngineVerwaltung(this, null, null, null, null, null);
                this.initComboUsersAktivJN();

                foreach (Infragistics.Win.ValueListItem valList in this.Items)
                {

                    if (valList.DataValue.Equals(ENV.USERID))
                    {
                        Benutzer ben = new Benutzer(ENV.USERID);
                        this.SelectedItem = valList;
                        //this.Benutzer = ben;
                    }
                    bool bAktivJN = false;
                    this.lstUsersAktivJN.TryGetValue((Guid)valList.DataValue, out bAktivJN);

                    if (bAktivJN)
                    {
                        valList.Appearance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        valList.Appearance.ForeColor = Color.DarkRed;
                    }
                }

                if (this._cboIsDropDownStyle)
                {
                    this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
                    this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                    this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
                }
                else
                {
                    this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                    this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Default;
                    this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Default;
                }

            }
			catch(Exception ex)
			{
                throw new Exception("PflegerCombo.RefreshList: " + ex.ToString());
			}
		}


        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PflegerCombo
            // 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }

}
