// mda
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win.UltraWinTree;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI.BaseControls
{
    public partial class ucASZMSelectorTreeView : QS2.Desktop.ControlManagment.BaseControl, ITreeview
    {
        private PDxSelectionArgs[] _pdxSArgs;
        private List<Guid> _listIDPDX;
        private PflegePlan _PflegePlan; //Neu nach 07.05.2007 MDA

        //Neu nach 15.05.2007 MDA
        private PDxSelectionArgs _ActivePDx;
        private KatalogEditModes _ActiveKatalogEditModes = KatalogEditModes.All;
        public event Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler TreeviewAfterNodeSelectEventHandler;
        public event Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler TreeviewBeforeNodeSelectEventArgs;
        private ASZMSelectionArgs _arg;
        private PDxSelectionArgs _pdxArg;
        private bool _isPDX = false;
        private bool _sendSignal = true;

        //Neu nach 16.09.2008 MDA
        PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;
        
        public ucASZMSelectorTreeView()
        {
            InitializeComponent();
        }

        //Neu nach 07.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegePlan auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlan PflegePlan
        {
            get { return _PflegePlan; }
            set { _PflegePlan = value; }
        }

        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs PDX_SARG
        {
            get { return _pdxArg; }
            set
            {
                _pdxArg = value;
                SelectPDXSelectionArgs();
            }
        }
        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMSelectionArgs ARG
        {
            get { return _arg; }
            set
            {
                _arg = value;
                SelectASZMSelectionArgs();
            }
        }

        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle selektierte TreeNode ist ein PDx oder nein
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPDx
        {
            get { return _isPDX; }
        }

        //Neu nach 27.06.2008
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle PDxSelectionArgs surückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs CurrentPDX
        {
            get { return GetCurrentPDX(); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPDX Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Guid> ListIDPDX
        {
            get { return _listIDPDX; }
            set{_listIDPDX = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen/setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs[] PDX_SELARGS
        {
            get { return _pdxSArgs; }
            set 
            {
                _pdxSArgs = value;
                //Änderung nach 18.05.2007 MDA: Akluelle PDx und KatalogEditModes aktualisieren
                _ActivePDx = null;
                _ActiveKatalogEditModes = KatalogEditModes.All;
                if (_pdxSArgs == null)
                {
                    _pdxArg = null;
                    _arg = null;
                    _isPDX = false;
                }
                FillTree();
            }
        }

        //Neu nach 15.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle PDxSelectionArgs auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs ActivePDx
        {
            get { return _ActivePDx; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle KatalogEditModes auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KatalogEditModes ActiveKatalogEditModes
        {
            get { return _ActiveKatalogEditModes; }
        }

        //Neu nach 16.09.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set
            {
                _PflegePlanModus = value;
                if (_pdxSArgs != null)
                    FillTree();
            }
        }

        //Neu nach 27.06.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelles PDx zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        private PDxSelectionArgs GetCurrentPDX()
        {
            if (tv.ActiveNode == null) return null;
            PDxSelectionArgs pdxSelArg = null;
            UltraTreeNode tn = GetPDxParentNode(tv.ActiveNode);

            if (tn.Tag is PDxSelectionArgs)
                pdxSelArg = (PDxSelectionArgs)tn.Tag;

            return pdxSelArg;
        }

        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein PDx TreeNode selektieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void SelectPDXSelectionArgs()
        {
            bool expend;
            foreach (UltraTreeNode n in tv.Nodes)
            {
                expend = n.Expanded;
                if (n.Tag is PDxSelectionArgs && n.Tag.Equals(_pdxArg))
                {
                    tv.ActiveNode = n;
                    n.Selected = true;
                    n.Expanded = expend;
                    break;
                }
            }
        }
        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein ASZM TreeNode selektieren
        /// auf basis einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        private bool SelectASZMSelectionArgs(UltraTreeNode tn)
        {
            foreach (UltraTreeNode n in tn.Nodes)
            {
                if (n.Nodes.Count > 0)
                {
                    if (SelectASZMSelectionArgs(n))
                        return true;
                }
                else
                {
                    if (n.Tag != null && n.Tag.Equals(_arg))
                    {
                        tv.ActiveNode = n;
                        n.Selected = true;
                        return true;
                    }
                }
            }

            return false;
        }

        //Neu nach 08.05.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein ASZM TreeNode selektieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void SelectASZMSelectionArgs()
        {
            bool expend;
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                expend = tn.Expanded;
                if (tn.Nodes.Count > 0)
                {
                    if (SelectASZMSelectionArgs(tn))
                        break;
                }
                else
                {
                    if (tn.Tag != null && tn.Tag.Equals(_arg))
                    {
                        tv.ActiveNode = tn;
                        tn.Selected = true;
                        tn.Expanded = expend;
                        break;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle ausgewählte ASZM's im ArrayList speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void AddASZMSelectionArgs(int Rekursionstiefe , UltraTreeNode tn, ArrayList list)
        {
            if (Rekursionstiefe == 1000)
                throw new Exception("ucASZMSelectorTreeView::AddASZMSelectionArgs() - Programmierinkonsistenz: Eine ASZMNode konnte nicht gefunden werden");
            if (tn.Tag != null && tn.Tag is ASZMSelectionArgs && tn.CheckedState == CheckState.Checked)
                list.Add((ASZMSelectionArgs)tn.Tag);

            if (tn.HasNodes)
            {
                Rekursionstiefe++;
                foreach (UltraTreeNode n in tn.Nodes)
                {
                    AddASZMSelectionArgs(Rekursionstiefe, n, list);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs[] auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public ASZMSelectionArgs[] GetASZMSelectionArgs()
        {
            ArrayList list = new ArrayList();

            try
            {
                foreach (UltraTreeNode tn in tv.Nodes)
                {
                    AddASZMSelectionArgs(0, tn, list);
                }

                return (ASZMSelectionArgs[])list.ToArray(typeof(ASZMSelectionArgs));
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return (ASZMSelectionArgs[])list.ToArray(typeof(ASZMSelectionArgs));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegedefinitionen mit ausgewählten ASZM's zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public PDxSelectionArgs[] GetSelectedPDxSelectionArgs()
        {
            List<PDxSelectionArgs> listPDx = new List<PDxSelectionArgs>();
            ArrayList listASZM;
            PDxSelectionArgs pdx;

            try
            {
                foreach (UltraTreeNode tn in tv.Nodes)
                {
                    if (tn.Tag is PDxSelectionArgs)
                    {
                        listASZM = new ArrayList();
                        AddASZMSelectionArgs(0, tn, listASZM);
                        if (listASZM.Count > 0)
                        {
                            pdx = (PDxSelectionArgs)tn.Tag;
                            pdx.ARGS = (ASZMSelectionArgs[])listASZM.ToArray(typeof(ASZMSelectionArgs));
                            listPDx.Add(pdx);
                        }
                    }
                }

                return listPDx.ToArray();
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return listPDx.ToArray();
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Checked state setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void SelectAllTreeNodes(bool checkedJN)
        {
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.Tag is PDxSelectionArgs)
                {
                    tn.CheckedState = checkedJN ? CheckState.Checked : CheckState.Unchecked;
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Nodes welche keine ASZM enthalten entfernen (PDX können alleine nicht eingefügt werden)
        /// </summary>
        //----------------------------------------------------------------------------
        private void RemoveEmptyNodes()
        {
            List<UltraTreeNode> nl = new List<UltraTreeNode>();
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.Nodes.Count == 0)
                    nl.Add(tn);
            }

            foreach (UltraTreeNode n in nl)
                tv.Nodes.Remove(n);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle TreeNodes öffnen
        /// </summary>
        //----------------------------------------------------------------------------
        public void ExpendAllTreeNodes()
        {
            tv.ExpandAll();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// EintragGruppe nicht anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void HideOrShowEintragGruppe(UltraTreeNode tn, string group, bool hide)
        {
            if (tn.Key.Contains(group))
            {
                tn.Visible = !hide;
            }

            if (tn.HasNodes)
            {
                foreach (UltraTreeNode n in tn.Nodes)
                {
                    HideOrShowEintragGruppe(n, group, hide);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// EintragGruppe nicht anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public void HideOrShowEintragGruppe(string group, bool hide)
        {
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                HideOrShowEintragGruppe(tn, group, hide);
            }
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Befüllt den Treeview je nach Modus
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillTree()
        {
            tv.BeginUpdate();
            tv.ActiveNode = null;
            tv.SelectedNodes.Clear();
            FillTreeByPDx();
            RemoveEmptyNodes();
            SetPDxTreeNodesImage(); // Neu nach 07.05.2007
            tv.EndUpdate();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn sich im TV Nodes befinden false sonst
        /// </summary>
        //----------------------------------------------------------------------------
        public bool HASNODES
        {
            get
            {
                return (tv.Nodes.Count > 0);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Ansicht ist PDx bezogen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillTreeByPDx()
        {
            _sendSignal = false;
            tv.Nodes.Clear();
            _sendSignal = true;

            //Alle PDX und dazu gehörenden Args in die Treenode einfügen
            if (_pdxSArgs != null)
            {
                UltraTreeNode tn;
                bool insertTree;
                foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                {
                    if (ListIDPDX != null)
                    {
                        insertTree = false;
                        foreach (Guid id in ListIDPDX)
                        {
                            if (id == pdxSA.IDPDX)
                            {
                                insertTree = true;
                                break;
                            }
                        }
                    }
                    else
                        insertTree = true;

                    if (!insertTree)
                        continue;

                    tn = tv.Nodes.Add(pdxSA.IDPDX.ToString(), PMDS.DB.DBUtil.GetPDX(pdxSA.IDPDX).Klartext);
                    tn.Tag = pdxSA;
                    
                    //TreeNode 2 Reihe einfügen

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(aa, tn, pdxSA, EintragGruppe.A))
                            break;
                    }

                    if (_PflegePlanModus == PflegePlanModus.Normal)
                    {

                        //Ändrung nach 16.09.2008 MDA
                        //Bei Wunden nur Symptome und Ressourcen unterdrücken

                        foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                        {
                            if (InsertPDxEintragGruppeIntoTreeNode(aa, tn, pdxSA, EintragGruppe.S))
                                break;
                        }

                        foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                        {
                            if (InsertPDxEintragGruppeIntoTreeNode(aa, tn, pdxSA, EintragGruppe.R))
                                break;
                        }
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(aa, tn, pdxSA, EintragGruppe.Z))
                            break;
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(aa, tn, pdxSA, EintragGruppe.M))
                            break;
                    }
                }

                //Alle von A abhängigen M reinhängen (nur M haben IDADependet != null)
                //Ändrung nach 16.09.2008 MDA
                //Bei Wunden nur Ziele und Maßnahmen anzeigen
                if (_PflegePlanModus == PflegePlanModus.Normal)
                {
                    foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                    {
                        if (ListIDPDX != null)
                        {
                            insertTree = false;
                            foreach (Guid id in ListIDPDX)
                            {
                                if (id == pdxSA.IDPDX)
                                {
                                    insertTree = true;
                                    break;
                                }
                            }
                        }
                        else
                            insertTree = true;

                        if (!insertTree)
                            continue;

                        foreach (ASZMSelectionArgs arg in pdxSA.ARGS)
                        {
                            if (arg.IDADependet == Guid.Empty)
                                continue;
                            InsertASZMIntoPDxTreeNodeDependet(pdxSA, arg);
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// TreeNode 2. und 3 Reihe einfügen
        /// </summary>
        /// //----------------------------------------------------------------------------
        private bool InsertPDxEintragGruppeIntoTreeNode(ASZMSelectionArgs aa, UltraTreeNode tn, PDxSelectionArgs pdxSA, EintragGruppe eintraggruppe)
        {
            //Neu nach 25.06.2007 MDA: TreeNodes A, S, Z und M immer anzeigen auch wenn keine Einträge vorhanden sind.
            UltraTreeNode n = new UltraTreeNode();

            if (!UltraTreeTools.ExistPDxEintragGruppe(tv, eintraggruppe.ToString() + "_" + pdxSA.IDPDX.ToString()))
            {
                if (pdxSA.PDXGruppe != 3)
                {
                    n = tn.Nodes.Add(eintraggruppe.ToString() + "_" + pdxSA.IDPDX.ToString(), ENV.String(eintraggruppe.ToString()));
                    n.Tag = eintraggruppe; //Änderung nach 15.05.2007 MDA
                }
            }
            else
                n = UltraTreeTools.FindNodeKey(tv.Nodes, eintraggruppe.ToString() + "_" + pdxSA.IDPDX.ToString());


            if (aa.IDPDX != null && aa.IDPDX == pdxSA.IDPDX && aa.EintragGruppe == eintraggruppe)
            {
                UltraTreeNode nn;
                foreach (ASZMSelectionArgs arg in pdxSA.ARGS)
                {
                    if (arg.IDADependet != Guid.Empty)
                        continue;
                    if (arg.EintragGruppe == eintraggruppe)
                    {
                        //TreeNode 3 Reihe einfügen
                        nn = n.Nodes.Add(Guid.NewGuid().ToString(), arg.Text);
                        nn.Tag = arg;
                    }
                }

                return true;
            }

            return false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Abhängigen Maßnahmen zu den Ätiologien hängen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertASZMIntoPDxTreeNodeDependet(PDxSelectionArgs pdxSA, ASZMSelectionArgs args)
        {
            UltraTreeNode n = GetPDxDependedNode(pdxSA, args.IDADependet);
            UltraTreeNode n1 = n.Nodes.Add(Guid.NewGuid().ToString(), args.Text);
            n1.Tag = args;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die richtige Node zue A/PDx kombination
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTreeNode GetPDxDependedNode(PDxSelectionArgs pdxSA, Guid IDAtiologie)
        {
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.Tag != null && tn.Tag.Equals(pdxSA))
                {
                    return UltraTreeTools.FindPDxDependedNodeFromNode(tn.Nodes, IDAtiologie, pdxSA.IDPDX);
                }
            }

            return null;
        }

        private void ExpendTreeNode(UltraTreeNode tn)
        {
            tn.ExpandAll();
        }

        private void SetCheckedStateForTreeNodes(UltraTreeNode tn)
        {

            if (!tn.HasNodes)
            {
                if (tn.Tag != null && tn.Tag is ASZMSelectionArgs)
                {
                    ASZMSelectionArgs arg = (ASZMSelectionArgs)tn.Tag;

                    if (arg.IDADependet != Guid.Empty && tn.CheckedState == CheckState.Checked)
                    {
                        tn.Parent.CheckedState = tn.CheckedState;
                    }
                }
            }
            else
            {
                foreach (UltraTreeNode nn in tn.Nodes)
                {
                    nn.CheckedState = tn.CheckedState;
                    if (nn.HasNodes)
                        SetCheckedStateForTreeNodes(nn);
                }
            }
        }

        public int GetTreeNodesCount()
        {
            return tv.Nodes.Count;
        }

        //Neu nach 07.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Haken für Bereits im Pflegeplan enthaltene ASZM's setzen 
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetASZMTreeNodesImage(UltraTreeNode tn, Guid IDPflegePlan, Guid IDPDX)
        {
            if (tn.Tag != null && tn.Tag is ASZMSelectionArgs)
            {
                ASZMSelectionArgs arg = (ASZMSelectionArgs)tn.Tag;

                foreach (dsPflegePlan.PflegePlanRow r in _PflegePlan.PFLEGEPLAN_EINTRAEGE.Select("ID='" + IDPflegePlan.ToString() + "'"))
                {
                    //Nur aktive Einträge, keine Termine und keine Spenderabgaben.
                    if (r.ErledigtJN)
                        continue;

                    if (r.EintragGruppe != "T" && r.EintragGruppe != "X" && r.PDXJN)
                    {
                        if (arg.IDPDX == IDPDX && arg.IDEintrag != null && r.IDEintrag != null && arg.IDEintrag == r.IDEintrag)
                            tn.Override.NodeAppearance.Image = 0;
                    }
                }
            }

            if(tn.HasNodes)
            {
                foreach (UltraTreeNode n in tn.Nodes)
                    SetASZMTreeNodesImage(n, IDPflegePlan, IDPDX);
            }

        }

        //Neu nach 07.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Haken für Bereits im Pflegeplan enthaltene Pflegedefinitionen setzen 
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetPDxTreeNodesImage()
        {
            if (_PflegePlan != null)
            {
                UltraTreeNode PDXTn;

                foreach (dsPflegePlanPDx.PflegePlanPDxRow rp in _PflegePlan.PFLEGEPLANPDX.Rows)
                {
                    if (rp.ErledigtJN)
                        continue;

                    PDXTn = UltraTreeTools.FindNodeKey(tv.Nodes, rp.IDPDX.ToString());

                    if (PDXTn != null)
                    {
                        PDXTn.Override.NodeAppearance.Image = 0;
                        SetASZMTreeNodesImage(PDXTn, rp.IDPflegePlan, rp.IDPDX);
                    }
                }
            }
        }

        //Neu nach 15.05.2007 MDA
        private void SetActivePDx()
        {
            UltraTreeNode tn = tv.ActiveNode;

            if (tn == null)
            {
                _ActivePDx = null;
                return;
            }

            if (tn.Tag is PDxSelectionArgs)
                _ActivePDx = (PDxSelectionArgs)tn.Tag;
            else
            {
                UltraTreeNode n = GetPDxParentNode(tn);

                if (n != null)
                    _ActivePDx = (PDxSelectionArgs)n.Tag;
            }
        }

        private void SetActiveKatalogEditModes()
        {
            UltraTreeNode tn = tv.ActiveNode;

            if (tn == null)
            {
                _ActiveKatalogEditModes = KatalogEditModes.All;
                return;
            }

            if(tn.Tag is PDxSelectionArgs)
                _ActiveKatalogEditModes = KatalogEditModes.All;
            else if (tn.Tag is EintragGruppe)
                _ActiveKatalogEditModes = (KatalogEditModes)Enum.Parse(typeof(KatalogEditModes), ((EintragGruppe)tn.Tag).ToString());
            else
            {
                UltraTreeNode n = GetASZMParentNode(tn);

                if(n != null)
                    _ActiveKatalogEditModes = (KatalogEditModes)Enum.Parse(typeof(KatalogEditModes), ((EintragGruppe)n.Tag).ToString());
            }
        }

        private UltraTreeNode GetPDxParentNode(UltraTreeNode tn)
        {
            if (tn.Tag is PDxSelectionArgs)
                return tn;

            if (tn.Parent == null)
                return null;

            if (tn.Parent.Tag is PDxSelectionArgs)
                return tn.Parent;

            return GetPDxParentNode(tn.Parent);
        }

        private UltraTreeNode GetASZMParentNode(UltraTreeNode tn)
        {
            if (tn.Tag is EintragGruppe)
                return tn;

            if (tn.Parent == null)
                return null;

            if (tn.Parent.Tag is EintragGruppe)
                return tn.Parent;

            return GetASZMParentNode(tn.Parent);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Addiert ein UltraTreeNode zur Selektierten Eintrag und setzt die CheckedState auf Checked oder Unchecked
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddNodeToCurrentASZMTreeNode(ASZMSelectionArgs arg, bool Checked)
        {
            UltraTreeNode tn = GetASZMParentNode(tv.ActiveNode);

            if (tn != null)
            {
                UltraTreeNode n = tn.Nodes.Add(Guid.NewGuid().ToString(), arg.Text);
                n.Tag = arg;
                n.CheckedState = Checked ? CheckState.Checked : CheckState.Unchecked;

                UltraTreeNode pdxNode = GetPDxParentNode(tn);

                if (pdxNode != null)
                {
                    PDxSelectionArgs pdxArg = (PDxSelectionArgs)pdxNode.Tag;
                    List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();

                    foreach (ASZMSelectionArgs args in pdxArg.ARGS)
                        list.Add(args);

                    list.Add(arg);

                    pdxArg.ARGS = list.ToArray();
                }
                
                SetPDxTreeNodesImage();
            }
        }

        //Neu nach 16.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// TreeNodesCollection alle Pflegedefinitionen zurükgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public TreeNodesCollection GetPDxNodes()
        {
            return tv.Nodes;
        }

        //Neu nach 16.05.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Bestimmte TreeNodes von Pflegedefinitionen entfernen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RemovePDxNodes(TreeNodesCollection PDxNodesCollection)
        {
            foreach (UltraTreeNode tn in PDxNodesCollection)
            {
                foreach (UltraTreeNode n in tv.Nodes)
                {
                    if (n.Key == tn.Key)
                        tv.Nodes.Remove(n);
                }
            }
        }

        private void tv_AfterCheck(object sender, NodeEventArgs e)
        {
            SetCheckedStateForTreeNodes(e.TreeNode);
        }

        private void tv_AfterExpand(object sender, NodeEventArgs e)
        {
            ExpendTreeNode(e.TreeNode);
        }

        //Neu nach 15.05.2007 MDA
        private void tv_AfterSelect(object sender, SelectEventArgs e)
        {
            //Neu nach 08.05.2008 MDA
            _pdxArg = null;
            _arg = null;

            if (Visible && _sendSignal && tv.ActiveNode.Tag != null)
            {
                if (tv.ActiveNode.Tag is PDxSelectionArgs)
                {
                    _pdxArg = (PDxSelectionArgs)tv.ActiveNode.Tag;
                    _isPDX = true;
                }
                else if (tv.ActiveNode.Tag is ASZMSelectionArgs)
                {
                    _arg = (ASZMSelectionArgs)tv.ActiveNode.Tag;
                    _isPDX = false;
                }
            }

            SetActivePDx();
            SetActiveKatalogEditModes();
            if (Visible && _sendSignal && TreeviewAfterNodeSelectEventHandler != null)
                TreeviewAfterNodeSelectEventHandler(sender, e);
        }

        private void tv_BeforeSelect(object sender, BeforeSelectEventArgs e)
        {
            if (Visible && _sendSignal && TreeviewBeforeNodeSelectEventArgs != null)
                TreeviewBeforeNodeSelectEventArgs(sender, e);
        }

        private void ucASZMSelectorTreeView_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && tv.ActiveNode != null)// Neu nach 08.05.2008
                tv.ActiveNode.Selected = true;
        }
    }
}
