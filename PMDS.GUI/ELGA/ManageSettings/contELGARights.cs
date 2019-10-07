using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.DB;
using PMDS.Global.db.ERSystem;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;

namespace PMDS.GUI.ELGA.ManageSettings
{

    public partial class contELGARights : UserControl
    {

        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;

        public PMDSBusiness b = new PMDSBusiness();

        public Nullable<Guid> _IDUser = System.Guid.Empty;
        public bool _IsNew = false;
        public bool _Editable = false;

        public string colSelect = "Select";

        public UIGlobal UIGlobal1 = new UIGlobal();
        public ucBenutzer mainWindowBenutzer = null;

        public bool AnyChange = false;





        public contELGARights()
        {
            InitializeComponent();
        }

        private void ContELGARights_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.sqlManange1.initControl();
                    this.clearUI();

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.contELGARights: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this._IDUser = null;
                this._IsNew = false;

                this.dsKlientenliste1.Clear();
                this.gridRights.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("contELGARights.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDUser, bool isNew, bool editable)
        {
            try
            {
                this._IDUser = IDUser;
                this._IsNew = isNew;
                this._Editable = editable;

                this.dsKlientenliste1.Clear();
                this.sqlManange1.getRecht(this.dsKlientenliste1, this._IDUser.Value, Global.db.ERSystem.sqlManange.eTypeRecht.AllForUser);
                this.gridRights.Refresh();

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var tUsrRights = db.BenutzerRechte.Where(o => o.IDBenutzer == this._IDUser.Value);
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridRights.Rows)
                    {
                        DataRowView v = (DataRowView)rGrid.ListObject;
                        dsKlientenliste.RechtRow rRecht = (dsKlientenliste.RechtRow)v.Row;
                        foreach (PMDS.db.Entities.BenutzerRechte rUsrRights in tUsrRights)
                        {
                            if (rUsrRights.IDRecht.Equals(rRecht.ID))
                            {
                                rGrid.Cells["Select"].Value = true;
                            }
                        }
                    }
                }

                this.AnyChange = false;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGARights.loadData: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGARights.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    string sProtDetail = "";
                    var tUsrRights = (from br in db.BenutzerRechte
                                         join r in db.Recht on br.IDRecht equals r.ID
                               where br.IDBenutzer == this._IDUser.Value && r.ELGA == true
                                         select new
                               {
                                    IDBenutzerRecht = br.ID,
                                    Bezeichnung = r.Bezeichnung
                               });

                    if (tUsrRights.Count() > 0)
                    {
                        foreach (var r in tUsrRights)
                        {
                            var rUsrRights = db.BenutzerRechte.Where(o => o.ID == r.IDBenutzerRecht).First();
                            db.BenutzerRechte.Remove(rUsrRights);
                            sProtDetail += "Recht " + r.Bezeichnung.Trim() + " wurde gelöscht" + "\r\n";
                        }
                        db.SaveChanges();
                    }
                    bool anyChangesSave = false;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridRights.Rows)
                    {
                        DataRowView v = (DataRowView)rGrid.ListObject;
                        dsKlientenliste.RechtRow rRecht = (dsKlientenliste.RechtRow)v.Row;

                        if ((bool)rGrid.Cells[this.colSelect.Trim()].Value == true)
                        {
                            PMDS.db.Entities.BenutzerRechte rNewBenRecht = new db.Entities.BenutzerRechte();
                            rNewBenRecht.ID = System.Guid.NewGuid();
                            rNewBenRecht.IDBenutzer = this._IDUser.Value;
                            rNewBenRecht.IDRecht = rRecht.ID;
                            db.BenutzerRechte.Add(rNewBenRecht);

                            sProtDetail += "Recht " + rRecht.Bezeichnung.Trim() + " wurde hinzugefügt" + "\r\n";
                            anyChangesSave = true;
                        }
                    }
                    if (anyChangesSave)
                    {
                        db.SaveChanges();
                    }
                    
                    if (this.AnyChange && anyChangesSave)
                    {
                        ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Rechte wurden geändert"), null,
                                                        ELGABusiness.eTypeProt.UserRightsChanged, ELGABusiness.eELGAFunctions.none, "Benutzer", "", this._IDUser, null, null, sProtDetail);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGARights.saveData: " + ex.ToString());
            }
        }





        private void GridRights_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRights))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRights))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void GridRights_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                this.mainWindowBenutzer.OnValueChanged(sender, e);
                this.AnyChange = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}
