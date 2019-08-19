using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.DB;

using System.Linq;
using System.Collections.Generic;

namespace PMDS.GUI
{


	public class ucBenutzerBezug : QS2.Desktop.ControlManagment.BaseControl
	{

        public Guid _IDPatient;

        private VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1;
        private System.ComponentModel.Container components = null;

        public bool IsInitialized = false;

        public frmPatientBezug mainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();
        public System.Collections.Generic.List<Guid> lstIDAufenthaltVerlaufForPatient = new List<Guid>();








        public ucBenutzerBezug()
		{
			InitializeComponent();
		}


        public void initControl(Guid IDPatient)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._IDPatient = IDPatient;

                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1._SingleSelect = false;
                    this.contSelectPatientenBenutzer1.setSelectededTxt_Name = false;
                    //this.contSelectPatientenBenutzer1.SendEventPatientUsersWhenSelectChanged = SendEventPatientUsersWhenSelectChanged;
                    //this.contSelectPatienten.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient");
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Users, false, isTxtTemplate, null);
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                    this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = false;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    this.contSelectPatientenBenutzer1.PanelBottom.Visible = false;

                    bool IDFoundInTree2 = false;
                    this.contSelectPatientenBenutzer1.utreeAbtBereiche.Enabled = true;
                    this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(PMDS.Global.ENV.CurrentIDAbteilung, PMDS.Global.ENV.IDBereich, false, null, true, VB.contPlanungData.eTypeUI.PlansAll, ref IDFoundInTree2);

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var rPatient = (from p in db.Patient
                                        where p.ID == this._IDPatient
                                        select new
                                        {
                                            ID = p.ID,
                                            Nachname = p.Nachname,
                                            Vorname = p.Vorname,
                                        }).First();

                        this.mainWindow.labInfo.Text = string.Format(this.mainWindow.labInfo.Text, rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim());
                    }

                    this.loadData();


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerBezug.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.lstIDAufenthaltVerlaufForPatient.Clear();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Aufenthalt rAufenthaltAct = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);
                    
                    var tBenutzerBezug = (from bb in db.BenutzerBezug
                               join av in db.AufenthaltVerlauf on bb.IDAufenthaltVerlauf equals av.ID
                               join a in db.Aufenthalt on av.IDAufenthalt equals a.ID
                               where a.IDPatient == this._IDPatient
                               select new
                               {
                                   IDBenutzerBezug = bb.ID,
                                   IDAufenthaltVerlauf = av.ID,
                                   IDBenutzer = bb.IDBenutzer,
                                   IDAufenthalt = a.ID,
                               });

                    string lstUsers = "";
                    if (tBenutzerBezug.Count() > 0)
                    {
                        foreach (var rBenutzerBezug in tBenutzerBezug)
                        {
                            lstUsers += rBenutzerBezug.IDBenutzer.ToString() + ";";
                            this.lstIDAufenthaltVerlaufForPatient.Add(rBenutzerBezug.IDAufenthaltVerlauf);
                        }

                        this.contSelectPatientenBenutzer1.loadDataColl(ref lstUsers);
                    }

                    this.contSelectPatientenBenutzer1.setLabelCount2();

                    //System.Linq.IQueryable<PMDS.db.Entities.AufenthaltVerlauf> tAufenthaltVerlauf = db.AufenthaltVerlauf.Where(a => a.ID == rAufenthaltAct.IDAufenthaltVerlauf);
                    //PMDS.db.Entities.AufenthaltVerlauf rAufenthaltVerlauf = tAufenthaltVerlauf.First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerBezug.loadData: " + ex.ToString());
            }
        }


        public bool saveData()
        {
            try
            {
                List<Guid> lstUsers = this.contSelectPatientenBenutzer1.getList();
                string sWhereDelete = "";
                foreach (var IDAufenthaltVerlauf in this.lstIDAufenthaltVerlaufForPatient)
                {
                    sWhereDelete += (sWhereDelete.Trim() == "" ? "" : " or ") + " IDAufenthaltVerlauf='" + IDAufenthaltVerlauf.ToString() + "' ";
                }

                if (sWhereDelete.Trim() != "")
                {
                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                    if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                        RBU.DataBase.CONNECTION.Open();
                    cmd.Connection = RBU.DataBase.CONNECTION;
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = "delete from BenutzerBezug where " + sWhereDelete;
                    cmd.ExecuteNonQuery();
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (Guid IDUser in lstUsers)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthaltAct = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);

                        PMDS.db.Entities.BenutzerBezug rNewBenutzerBezug = new db.Entities.BenutzerBezug();
                        rNewBenutzerBezug.ID = System.Guid.NewGuid();
                        rNewBenutzerBezug.IDBenutzer = IDUser;
                        rNewBenutzerBezug.IDAufenthaltVerlauf = rAufenthaltAct.IDAufenthaltVerlauf.Value;
                        db.BenutzerBezug.Add(rNewBenutzerBezug);
                        db.SaveChanges();
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerBezug.saveData: " + ex.ToString());
            }
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
            this.contSelectPatientenBenutzer1 = new PMDS.GUI.VB.contSelectPatientenBenutzer();
            this.SuspendLayout();
            // 
            // contSelectPatientenBenutzer1
            // 
            this.contSelectPatientenBenutzer1.BackColor = System.Drawing.Color.Gainsboro;
            this.contSelectPatientenBenutzer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contSelectPatientenBenutzer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.contSelectPatientenBenutzer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contSelectPatientenBenutzer1.Location = new System.Drawing.Point(0, 0);
            this.contSelectPatientenBenutzer1.Name = "contSelectPatientenBenutzer1";
            this.contSelectPatientenBenutzer1.Size = new System.Drawing.Size(889, 600);
            this.contSelectPatientenBenutzer1.TabIndex = 9;
            // 
            // ucBenutzerBezug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.contSelectPatientenBenutzer1);
            this.Name = "ucBenutzerBezug";
            this.Size = new System.Drawing.Size(889, 600);
            this.ResumeLayout(false);

		}
		#endregion
        

	}

}

