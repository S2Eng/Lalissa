//----------------------------------------------------------------------------------------------
//  Erstellt am:	24.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucPdxVerwaltung : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler ValueChanged;
        public event ASZMtoPDxDelegate ASZMtoPDx;
        public event ZuordnungUpdateDelegate ZuordnungChanged;
        private PDXDef _Def;
        private Guid _IDAbteilung = Guid.Empty;
        private PDx _PDx;
        private Katalog _Katalog;
        private dsPDxEintrag.PDXEintragDataTable _PDXEintrag;
        private bool _ReadPDXEintrag = true;
        private string _EintragGruppe = "";
        private List<EintragZusatzHelp> _ListEintragZusatz = new List<EintragZusatzHelp>();
        //Neu nach 28.08.2008 MDA
        private bool _ValueChaned = false;
        private bool _ShowMassnahmeDetailsControl = false;
        
        public ucPdxVerwaltung()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
            ucAdditionalASZMToPDx1.Top = ucMassnahmeDetails1.Top;
            ucAdditionalASZMToPDx1.Left = ucMassnahmeDetails1.Left;
            ucAdditionalASZMToPDx1.Size = ucMassnahmeDetails1.Size;
            ucAdditionalASZMToPDx1.Dock = DockStyle.Fill;
            //ucAdditionalASZMToPDx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            _PDx = new PDx();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAbteilung
        {
            get { return _IDAbteilung; }
            set
            {
                _IDAbteilung = value;
                InitGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDXDef Def
        {
            get { return _Def; }
            set 
            {
                _Def = value;
                InitGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPDxEintrag.PDXEintragDataTable PDXEintrag
        {
            get { return _PDXEintrag; }
            set
            {
                _PDXEintrag = value;
                _ReadPDXEintrag = false;
                InitGUI();
                _ReadPDXEintrag = true;
            }
        }

         [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Katalog KATALOG
        {
            get
            {
                return _Katalog;
            }
            set
            {
                if (value == null)
                    return;
                _Katalog = value;
            }
        }

        private void InitGUI()
        {
            _ValueChaned = false;
            ucPdxVerwaltungTreeView1.Def = Def;
            _ListEintragZusatz.Clear();

            if (Def != null)
            {
                if(_ReadPDXEintrag)
                    _PDXEintrag = _PDx.GetZuordnungen(Def.ID, _IDAbteilung, false);

                EintragZusatz eintragZusatz;
                foreach (dsPDxEintrag.PDXEintragRow r in _PDXEintrag)
                {
                    if (r.EintragGruppe == EintragGruppe.M.ToString())
                    {
                        eintragZusatz = new EintragZusatz();
                        eintragZusatz.Read(r.IDEintrag);
                        _ListEintragZusatz.Add(new EintragZusatzHelp(r.IDEintrag, eintragZusatz));
                    }
                }
                ucPdxVerwaltungTreeView1.PDXEintrag = _PDXEintrag;
            }
        }

        private EintragZusatz FindEintragZusatz(Guid IDEintrag)
        {
            foreach (EintragZusatzHelp eintzus in _ListEintragZusatz)
            {
                if (eintzus.IDEintrag == IDEintrag)
                        return eintzus.EITRAGZUSTZ;
            }

            return null;
        }

        //Neu nach 27.08.2008 MDA
        public bool ValidateFields()
        {
            if (!ucMassnahmeDetails1.Visible)
                return true;
            return ucMassnahmeDetails1.ValidateFields();
        }

        public void AcceptChanges()
        {
            ucMassnahmeDetails1.AcceptChanges();
        }

        public void RefreshGUI()
        {
            ucMassnahmeDetails1.RefreshControl();
        }

        /// <summary>
        /// Speichert die Änderungen in der DB
        /// </summary>
        public void Save()
        {
            if (!_ValueChaned) return;
            _ValueChaned = false;
            AcceptChanges();
            _Katalog.Write();
            //_Katalog.writeQuery(_Katalog.EINTRAEGE);
            foreach (EintragZusatzHelp eintzus in _ListEintragZusatz)
            {
                eintzus.EITRAGZUSTZ.Save();
            }
        }

        private void ShowPDXEintragDetails(dsPDxEintrag.PDXEintragRow r)
        {
            if (r.EintragGruppe == EintragGruppe.M.ToString())
            {
                if (r.IsIDEintragNull())
                    return;
                EintragZusatz eintragZusatz = FindEintragZusatz(r.IDEintrag);

                if (eintragZusatz == null)
                {
                    eintragZusatz = new EintragZusatz();
                    eintragZusatz.Read(r.IDEintrag);
                    _ListEintragZusatz.Add(new EintragZusatzHelp(r.IDEintrag, eintragZusatz));
                }

                ucMassnahmeDetails1.EINTRAGROW = KATALOG.EINTRAEGE.FindByID(r.IDEintrag);

                dsEintragZusatz.EintragZusatzRow row = eintragZusatz.EINTRAGZUSATZ.FindByIDEintragIDAbteilung(r.IDEintrag, IDAbteilung);
                if (row == null)
                {
                    eintragZusatz.AddNew(IDAbteilung);
                    row = eintragZusatz.EINTRAGZUSATZ.FindByIDEintragIDAbteilung(r.IDEintrag, IDAbteilung);

                }
                ucMassnahmeDetails1.EITRAGZUSATZROW = row;

                ucMassnahmeDetails1.Visible = true;
            }
            else
                ucMassnahmeDetails1.Visible = false;
 //           pnlM.Visible = (r.EintragGruppe == EintragGruppe.M.ToString()) ? false : true;
            _EintragGruppe = r.EintragGruppe;
            //btnAddASZM.Text = r.EintragGruppe + "+";
            btnAddASZM.Visible = true;
        }

        private void ucPdxVerwaltungTreeView1_BeforeNodeSelect(object Tag, CancelableNodeEventArgs e)
        {
            if (ucAdditionalASZMToPDx1.Visible)
            {
                e.Cancel = true;
                return;
            }
            //Änderungen übernehmen.
            if (Tag is dsPDxEintrag.PDXEintragRow && ((dsPDxEintrag.PDXEintragRow)Tag).EintragGruppe == EintragGruppe.M.ToString())
            {
                if(ucMassnahmeDetails1.ValidateFields())
                    AcceptChanges();
                else
                    e.Cancel = true;
            }
        }

        private void ucPdxVerwaltungTreeView1_AfterNodeSelect(object Tag)
        {
            ucMassnahmeDetails1.Visible = false;
//            pnlM.Visible = true;

            if (Tag is PDXDef)
            {
                btnAddASZM.Visible = false;
                _EintragGruppe = "";
            }
            else if (Tag is dsPDxEintrag.PDXEintragRow)
            {
                ShowPDXEintragDetails((dsPDxEintrag.PDXEintragRow)Tag);
            }
            else
            {
                string text = Tag.ToString();
                string[] names = Enum.GetNames(typeof(EintragGruppe));

                foreach (string name in names)
                {
                    if(text.Contains("_" + name))
                    {
                        _EintragGruppe = name;
                        //btnAddASZM.Text = name + "+";
                        btnAddASZM.Visible = true;
                        break;
                    }
                }
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// </summary>
        //----------------------------------------------------------------------------
        void frm_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            if (IDAbteilungen == null)
                return;
            List<Guid> list = new List<Guid>();
            bool found = false;
            foreach (Guid id in IDAbteilungen)
            {
                if (id != IDAbteilung)
                    list.Add(id);
                else
                    found = true;
            }

            if (found)
                AddASZMtoPDx(IDPdx, IDEintrag);
            if (ASZMtoPDx != null)
                ASZMtoPDx(IDPdx, IDEintrag, gruppe, demStandardHinzufuegen, list.ToArray());
        }

        public void AddASZMtoPDx(Guid IDPdx, Guid IDEintrag)
        {
            bool bfound = false;

            foreach (dsPDxEintrag.PDXEintragRow r in PDXEintrag)
            {
                if (IDEintrag == r.IDEintrag)
                {
                    bfound = true;
                    break;
                }
            }
            dsEintrag.EintragDataTable t1 = new Eintrag().Read(IDEintrag);

            dsPDxEintrag.PDXEintragDataTable table = PDXEintrag;
            if (bfound == false && t1.Rows.Count > 0)										// Nicht gefunden also einfügen
            {
                dsEintrag.EintragRow r = t1[0];
                dsPDxEintrag.PDXEintragRow row = table.NewPDXEintragRow();
                row.ID = Guid.NewGuid();
                row.IDEintrag = IDEintrag;
                row.IDPDX = Def.ID;
                row.IDAbteilung = IDAbteilung;
                row.Sicht = r.Sicht;
                row.Warnhinweis = r.Warnhinweis;
                row.EintragGruppe = r.EintragGruppe;
                row.Text = r.Text;
                row.Klartext = Def.Klartext;

                table.AddPDXEintragRow(row);
                PDXEintrag = table;

                if (ZuordnungChanged != null)
                    ZuordnungChanged();
            }
        }

        private void ucMassnahmeDetails1_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                _ValueChaned = true;
                ValueChanged(this, null);
            }
        }

        private class EintragZusatzHelp
        {
            private Guid _IDEintrag;
            private EintragZusatz _EintragZusatz;
            public EintragZusatzHelp(Guid IDEintrag, EintragZusatz eintragZusatz)
            {
                _IDEintrag = IDEintrag;
                _EintragZusatz = eintragZusatz;
            }

            public Guid IDEintrag
            {
                get { return _IDEintrag; }
            }

            public EintragZusatz EITRAGZUSTZ
            {
                get { return _EintragZusatz; }
            }
        }

        private void ucPdxVerwaltungTreeView1_AfterNodeCheck(UltraTreeNode[] CheckedTreeNodes)
        {
            btnDelASZM.Visible = CheckedTreeNodes.Length > 0;
        }

        private void ucAdditionalASZMToPDx1_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            ucAdditionalASZMToPDx1.Visible = false;
            ucMassnahmeDetails1.Visible = _ShowMassnahmeDetailsControl;
//            pnlM.Visible = !_ShowMassnahmeDetailsControl;
            btnDelASZM.Enabled = true;

            if (IDEintrag == Guid.Empty) return;
            if (IDAbteilungen == null) return;
            List<Guid> list = new List<Guid>();
            bool found = false;
            foreach (Guid id in IDAbteilungen)
            {
                if (id != IDAbteilung)
                    list.Add(id);
                else
                    found = true;
            }

            if (found)
                AddASZMtoPDx(IDPdx, IDEintrag);
            if (ASZMtoPDx != null)
                ASZMtoPDx(IDPdx, IDEintrag, gruppe, demStandardHinzufuegen, list.ToArray());
            
        }

        private void ucPdxVerwaltungTreeView1_BeforeNodeCheck(BeforeCheckEventArgs e)
        {
            e.Cancel = ucAdditionalASZMToPDx1.Visible;
        }

        private void btnDelASZM_Click(object sender, EventArgs e)
        {
            UltraTreeNode[] nodes = ucPdxVerwaltungTreeView1.GetCheckedASZMTreeNodes();

            if (nodes != null && nodes.Length > 0)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie wirklich die ausgewählten ASZM Einträge löschen?", "ASZM löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                    return;

                EintragZusatzHelp eintrzus = null;
                dsPDxEintrag.PDXEintragRow r;
                foreach (UltraTreeNode tn in nodes)
                {
                    r = (dsPDxEintrag.PDXEintragRow)tn.Tag;

                    foreach (EintragZusatzHelp eintr in _ListEintragZusatz)
                    {
                        if (eintr.IDEintrag == r.IDEintrag)
                        {
                            eintrzus = eintr;
                            break;
                        }
                    }

                    if (eintrzus != null)
                        _ListEintragZusatz.Remove(eintrzus);

                    PDXEintrag.RemovePDXEintragRow(r);
                }

                PDXEintrag = PDXEintrag;

                if (ZuordnungChanged != null)
                    ZuordnungChanged();
            }
            else
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine ASZM Einträge ausgewählt.", "Löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddASZM_Click(object sender, EventArgs e)
        {
            if (Def == null)
                return;
            KatalogEditModes editMode = (KatalogEditModes)Enum.Parse(typeof(KatalogEditModes), _EintragGruppe);
            //frmAdditionalASZMtoPDx frm = new frmAdditionalASZMtoPDx(editMode, Def.ID);
            //frm.CbPflegeplanVisible = false;
            //frm.ASZMtoPDx += new ASZMtoPDxDelegate(frm_ASZMtoPDx);
            //frm.ShowDialog();

            ucAdditionalASZMToPDx1.SetPDxAndMode(Def.ID, editMode);
            ucAdditionalASZMToPDx1.CbPflegeplanVisible = false;
            ucAdditionalASZMToPDx1.Visible = true;
            //            pnlM.Visible = false;
            _ShowMassnahmeDetailsControl = ucMassnahmeDetails1.Visible;
            ucMassnahmeDetails1.Visible = false;
            btnDelASZM.Enabled = false;
        }

        private void ucPdxVerwaltung_Load(object sender, EventArgs e)
        {

        }
    }
}
