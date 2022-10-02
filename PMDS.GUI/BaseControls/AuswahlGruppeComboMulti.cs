using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;


namespace PMDS.GUI.BaseControls
{
    
    public partial class AuswahlGruppeComboMulti : UserControl
    {

        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public bool IsIntialized = false;

        public eTypeMulti _TypMulti;
        public enum eTypeMulti
        {
            Berufsgruppe = 0,
            Zusatzwerte = 1,
            TypePlanungseintrag = 2,
            ZeitbezugJNA = 3,
            HerkunftPlanungseintrag = 4
        }

        public int _BerufsstandGruppeJNA = -1;

        public event EventHandler AfterCheck2;

        public int _SupressLevelHierarchie = -100000;
        public bool _OnlyReihenfolgePlus = false;







        public AuswahlGruppeComboMulti()
        {
            InitializeComponent();
        }
        private void AuswahlGruppeComboMulti_Load(object sender, EventArgs e)
        {

        }

        public void initControl(eTypeMulti TypeMulti, eUITypeTermine UITypeTermine, bool IsManageQuickfilter, int BerufsstandGruppeJNA, int SupressLevelHierarchie, bool OnlyReihenfolgePlus)
        {
            try
            {
                if (!this.IsIntialized)
                {
                    if (DesignMode)                   
                        return;

                    this.TypeMulti = TypeMulti;
                    this._BerufsstandGruppeJNA = BerufsstandGruppeJNA;

                    this._SupressLevelHierarchie = SupressLevelHierarchie;
                    this._OnlyReihenfolgePlus = OnlyReihenfolgePlus;

                    this.RefreshList(UITypeTermine, IsManageQuickfilter);
                    this.dropDownGruppe.PopupItem = (Infragistics.Win.IPopupItem)this.ultraToolbarsManager1.Tools["popGruppen"];
                    this.dropDownGruppe.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

                    this.IsIntialized = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.initControl: " + e.ToString());
            }
        }
        public eTypeMulti TypeMulti
        {
            get
            {
                return this._TypMulti;
            }
            set
            {
                this._TypMulti = value;
            }
        }


        public void RefreshList(eUITypeTermine UITypeTermine, bool IsManageQuickfilter)
        {
            try
            {
                this.treeGruppe.Nodes.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (this.TypeMulti == eTypeMulti.Berufsgruppe)
                    {
                        IQueryable<PMDS.db.Entities.AuswahlListe> lstAuswahlliste = PMDSBusiness1.GetAuswahlliste(db, "BER", this._SupressLevelHierarchie, this._OnlyReihenfolgePlus);
                        foreach (PMDS.db.Entities.AuswahlListe rAuswahlliste in lstAuswahlliste)
                        {
                            if ((!rAuswahlliste.IstGruppe && this._BerufsstandGruppeJNA == 0) ||
                                (rAuswahlliste.IstGruppe && this._BerufsstandGruppeJNA == 1) ||
                                (this._BerufsstandGruppeJNA == -1))
                            {
                                Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = this.treeGruppe.Nodes.Add(rAuswahlliste.ID.ToString(), rAuswahlliste.Bezeichnung.Trim());
                            }
                        }
                    }
                    else if (this.TypeMulti == eTypeMulti.Zusatzwerte)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.ZusatzEintrag> tZusatzEintrag = null;
                        tZusatzEintrag = db.ZusatzEintrag.OrderBy(o => o.Bezeichnung);
                        foreach (PMDS.db.Entities.ZusatzEintrag rZusatzEintrag in tZusatzEintrag)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                            TreeNode = this.treeGruppe.Nodes.Add(rZusatzEintrag.ID.ToString(), rZusatzEintrag.Bezeichnung.Trim());
                        }
                    }
                    else if (this.TypeMulti == eTypeMulti.ZeitbezugJNA)
                    {
                        Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eModusTermine.MitZeitbezug).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Mit Zeitbezug"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eModusTermine.OhneZeitbezug).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Ohne Zeitbezug"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eModusTermine.MitPflegediagnoseAbzeichnen).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Mit Pflegediagnose abzeichnen"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eModusTermine.OhnePflegediagnoseAbzeichnen).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelabzeichnung"));
                    }
                    else if (this.TypeMulti == eTypeMulti.HerkunftPlanungseintrag)
                    {
                        Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.DekursAusIntervention).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus Intervention"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.DekursAusÜbergabe).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus Übergabe"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.DekursAusMitBereich).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus mitverantwortlichen Bereich"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.DekursAusMedDiagnosenPatient).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus medizinischer Diagnosen/Patient"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.MassnahmenRückmeldungAusIntervention).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahmenrückmeldung aus Intervention"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.BedarfsmedikamentationAusIntervention).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung aus Intervention"));
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.eDekursherkunft.UngeplanteMassnahmeRückmeldenAusIntervention).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungeplante Maßnahme rückmelden aus Intervention"));
                    }
                    else if (this.TypeMulti == eTypeMulti.TypePlanungseintrag)
                    {
                        this.initCboPlanungsEinträge(UITypeTermine, IsManageQuickfilter);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.RefreshList: " + e.ToString());
                //PMDS.Global.Settings.HandleException(e);
            }
        }
        public void initCboPlanungsEinträge(eUITypeTermine UITypeTermine, bool IsManageQuickfilter)
        {
            this.treeGruppe.Nodes.Clear();
            if (IsManageQuickfilter)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MASSNAHME).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.DEKURS).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.TERMIN).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.PLANUNG).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Planung"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.WUNDEN).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.UNEXP_MASSNAHME).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungepl. Maßnahme"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MEDIKAMENT).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament"));
                if (ENV.UseMediaktionVidieren)
                {
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MedikamentÄnderung).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament Änderung"));
                }
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.NOTFALL).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.EVALUIERUNG).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Klient).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Verordnungen).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnungen"));
                TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Assessment).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment"));
            }
            else
            {
                if (UITypeTermine == eUITypeTermine.Interventionen)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MASSNAHME).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.TERMIN).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin"));
                }
                else if (UITypeTermine == eUITypeTermine.Übergabe)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode TreeNode = null;
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MASSNAHME).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.DEKURS).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.TERMIN).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.PLANUNG).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Planung"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.WUNDEN).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.UNEXP_MASSNAHME).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungepl. Maßnahme"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MEDIKAMENT).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament"));
                    if (ENV.UseMediaktionVidieren)
                    {
                        TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.MedikamentÄnderung).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament Änderung"));
                    }
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.NOTFALL).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.EVALUIERUNG).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Klient).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Verordnungen).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnungen"));
                    TreeNode = this.treeGruppe.Nodes.Add(((int)PMDS.Global.PflegeEintragTyp.Assessment).ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment"));
                }
                else if (UITypeTermine == eUITypeTermine.Dekurs)
                {
                }
                else
                {
                    throw new Exception("initCboTyp: UITypeTermine '" + UITypeTermine.ToString() + "' is not allowed!");
                }
            }
        }
        public System.Collections.Generic.List<Guid> AddCC2(Guid IDPflegeEIntrag, bool IsNew, bool CopyAsDekurs, bool abzeichnenJN, Guid IDWichtig,
                            ref System.Collections.Generic.List<Guid> lstPEToCopy, bool IsNotfall, ref Guid IDGruppe)
        {
            try
            {
                //if (IsNew)
                //{
                System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();

                this.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDSBusiness1.CopyAndAddPflegeeinträgeCC(db, IDPflegeEIntrag, ref lstSelectedCC, CopyAsDekurs, true, abzeichnenJN, IDWichtig, ref lstPEToCopy, IsNotfall, ref IDGruppe);
                }

                //if (CopyAsDekurs)
                //{
                //    List<Guid> lstSelectedEmpty = new List<Guid>();
                //    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                //    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                //    {
                //        PMDS.db.Entities.PflegeEintrag peTemplate = new PMDS.db.Entities.PflegeEintrag();
                //        PMDSBusiness1.CopyAndAddPflegeeinträgeCC(db, IDPflegeEIntrag, ref lstSelectedEmpty, CopyAsDekurs, false, abzeichnenJN, IDWichtig, ref lstPatienteSelected, ref lstPEToCopy);
                //    }  
                //}
                //}

                return lstSelectedCC;
            }
            catch (Exception ex)
            {
                throw new Exception("ucPflegeEintrag.AddCC: " + ex.ToString());
            }
        }
        public void getSelected(ref System.Collections.Generic.List<Guid> lstGuidReturn, ref System.Collections.Generic.List<int> lstIntReturn,
                                    ref System.Collections.Generic.List<string> lstStringReturn)
        {
            try
            {
                foreach(Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                {
                    if (this.TypeMulti == eTypeMulti.Berufsgruppe)
                    {
                        if (treeNode.CheckedState == CheckState.Checked)
                        {
                            lstGuidReturn.Add(new System.Guid(treeNode.Key));
                        }
                    }
                    else if (this.TypeMulti == eTypeMulti.Zusatzwerte)
                    {
                        if (treeNode.CheckedState == CheckState.Checked)
                        {
                            lstStringReturn.Add(treeNode.Key.ToString());
                        }
                    }
                    else if (this.TypeMulti == eTypeMulti.TypePlanungseintrag || this.TypeMulti == eTypeMulti.ZeitbezugJNA || this.TypeMulti == eTypeMulti.HerkunftPlanungseintrag)
                    {
                        if (treeNode.CheckedState == CheckState.Checked)
                        {
                            lstIntReturn.Add(System.Convert.ToInt32(treeNode.Key.ToString()));
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.getSelected: " + e.ToString());
            }
        }
        public void setSelected(System.Collections.Generic.List<Guid> lstGuidNodesToSet,
                                System.Collections.Generic.List<int> lstIntNodesToSet,
                                System.Collections.Generic.List<string> lstStringNodesToSet)
        {
            try
            {
                this.clearSelectedNodes();
                if (this.TypeMulti == eTypeMulti.Berufsgruppe)
                {
                    foreach (Guid ID in lstGuidNodesToSet)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                        {
                            if (treeNode.Key.ToString().Trim().Equals(ID.ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                treeNode.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                }
                else if (this.TypeMulti == eTypeMulti.Zusatzwerte)
                {
                    foreach (string ID in lstStringNodesToSet)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                        {
                            if (treeNode.Key.ToString().Trim().Equals(ID.ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                treeNode.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                }
                else if (this.TypeMulti == eTypeMulti.TypePlanungseintrag)
                {
                    foreach (int ID in lstIntNodesToSet)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                        {
                            if (treeNode.Key.ToString().Trim().Equals((ID).ToString().Trim()))
                            {
                                treeNode.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                }
                else if (this.TypeMulti == eTypeMulti.ZeitbezugJNA || this.TypeMulti == eTypeMulti.HerkunftPlanungseintrag)
                {
                    foreach (int ID in lstIntNodesToSet)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                        {
                            if (treeNode.Key.ToString().Trim().Equals((ID).ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                treeNode.CheckedState = CheckState.Checked;
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("setSelected: this.TypeMulti  '" + this.TypeMulti .ToString () + "' not exists!");
                }
                this.SetText();

            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.setSelected: " + e.ToString());
            }
        }
        public void clearSelectedNodes()
        {
            try
            {
                this.dropDownGruppe.Text = "";
                System.Collections.Generic.List<Guid> lstReturn = new System.Collections.Generic.List<Guid>();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                {
                    treeNode.CheckedState = CheckState.Unchecked;
                }
            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.clearSelectedNodes: " + e.ToString());
            }
        }
        public void SetText()
        {
            try
            {
                this.dropDownGruppe.Text = "";
                System.Collections.Generic.List<Guid> lstReturn = new System.Collections.Generic.List<Guid>();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode treeNode in this.treeGruppe.Nodes)
                {
                    if (treeNode.CheckedState == CheckState.Checked)
                    {
                        this.dropDownGruppe.Text += treeNode.Text.Trim() + "-";
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("AuswahlGruppeComboMulti.clearSelectedNodes: " + e.ToString());
            }
        }
        private void treeGruppe_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            try
            {
                if (this.treeGruppe.Focused)
                {
                    this.SetText();
                    if (this.AfterCheck2 != null)
                    {
                        this.AfterCheck2(sender, e);
                    }
                  
                }           
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
