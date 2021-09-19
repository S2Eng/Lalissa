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
    public partial class ucPDXTreeView : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool _valueChangeEnabled = true;
        private UltraTreeNode _nA = new UltraTreeNode("A", ENV.String("A_RFs"));
        private UltraTreeNode _nS = new UltraTreeNode("S", ENV.String("S"));
        private UltraTreeNode _nR = new UltraTreeNode("R", ENV.String("R"));
        private UltraTreeNode _nZ = new UltraTreeNode("Z", ENV.String("Z"));
        private UltraTreeNode _nM = new UltraTreeNode("M", ENV.String("M"));
        private UltraTreeNode _nOhne;
        private ASZMSelectionArgs[] _aa;
        private ASZMSelectionArgs _arg;
        private PDxSelectionArgs[] _pdxSArgs;
        private PDxSelectionArgs _pdxArg;
        private bool _isPDX = false;
        private DateTime _minDate = new DateTime(1900, 1, 1);
        private UltraTreeNode _aktivNode;
        private bool _ExpandAll = true;
        private KatalogEditModes _ActiveKatalogEditModes = KatalogEditModes.All; //Neu nach 31.03.2008 MDA
        private bool _ArgsChange = false;

        public event Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler TreeviewBeforeNodeSelectEventArgs;
        public event Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler TreeviewAfterNodeSelectEventHandler;


        public ucPDXTreeView()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// NodeStyle des Treeviews setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NodeStyle NodeStyle
        {
            get { return tv.Override.NodeStyle; }
            set { tv.Override.NodeStyle = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ViewStyle des Treeviews setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewStyle ViewStyle
        {
            get { return tv.ViewStyle; }
            set { tv.ViewStyle = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Expand or 
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ExpandAll
        {
            get { return _ExpandAll; }
            set 
            {
                _ExpandAll = value;
                if (_ExpandAll)
                    tv.ExpandAll();
                else
                    tv.CollapseAll();
            }
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs Array auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs[] PDX_SELARGS
        {
            get { return _pdxSArgs; }
            set { _pdxSArgs = value; }
        }

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

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs[] setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMSelectionArgs[] ARGS
        {
            get { return _aa; }
            set
            {
                _aa = value;
                _ArgsChange = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Aktive Treenode zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UltraTreeNode AktivNode
        {
            get { return _aktivNode; }
            set
            {
                _aktivNode = value;
                tv.ActiveNode = value;
                tv.ActiveNode.Selected = true;
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPDx
        {
            get { return _isPDX; }
        }

        public void AddPdx()
        {
            if (PDX_SARG != null)
            {
                PDxSelectionArgs pdxArg = (PDxSelectionArgs)PDX_SARG.Clone();

                List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();

                foreach (PDxSelectionArgs pdxA in PDX_SELARGS)
                {
                    list.Add(pdxA);
                    if (pdxA.IDPDX == pdxArg.IDPDX)
                        list.Add(pdxArg);
                }

                PDX_SELARGS = list.ToArray();
                
                List<ASZMSelectionArgs> listSA = new List<ASZMSelectionArgs>();
                foreach(ASZMSelectionArgs sa in _aa)
                {
                    listSA.Add(sa);
                }

                foreach(ASZMSelectionArgs sa in pdxArg.ARGS)
                {
                    listSA.Add(sa);
                }
                _aa = listSA.ToArray();


                RefreshTree();

                tv.ActiveNode = _aktivNode;
                tv.ActiveNode.Selected = true;
                
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Zeitpunkte für die Maßnahmenserie
        /// </summary>
        //----------------------------------------------------------------------------
        private DateTime[] GetUnterttaegigPoints(Guid IDMassnahmenserien)
        {
            Massnahmenserien s = Massnahmenserien.Default();
            return s.GetPoints(IDMassnahmenserien);
        }

        public void RefreshTree()
        {
            if (_aa == null)
                return;

            if (_pdxSArgs == null || _ArgsChange)
            {
                _ArgsChange = false;
                _pdxSArgs = ASZMTransfer.GetPDxSelectionArgs(_aa);
            }

            _valueChangeEnabled = false;
            _ActiveKatalogEditModes = KatalogEditModes.All; //Neu nach 31.03.2008 MDA
            tv.BeginUpdate();
            FillTreeByPDx();
            RemoveEmptyNodes();
            ExpandAll = _ExpandAll;
            tv.ActiveNode = tv.Nodes[0];
            tv.ActiveNode.Selected = true;
            tv.Select();
            tv.EndUpdate();
            _valueChangeEnabled = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Befüllt den Treeview je nach Modus
        /// </summary>
        //----------------------------------------------------------------------------
        public void FillTree(ASZMSelectionArgs[] args)
        {
            if (args != null && args.Length > 0)
            {
                _aa = args;
                RefreshTree();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Nodes löschen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearNodes()
        {
            tv.Nodes.Clear();
            _nA.Nodes.Clear();
            _nS.Nodes.Clear();
            _nZ.Nodes.Clear();
            _nM.Nodes.Clear();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Ansicht ist PDx bezogen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillTreeByPDx()
        {
            ClearNodes();
            _nOhne = tv.Nodes.Add("OHNE", ENV.String("GUI.OHNE_ZUORDNUNG"));
            _nOhne.Nodes.Add(_nA);
            _nOhne.Nodes.Add(_nS);
            _nOhne.Nodes.Add(_nZ);
            _nOhne.Nodes.Add(_nM);

            //Alle PDX und dazu gehörenden Args in die Treenode einfügen
            InsertPDxIntoTreeNode();


            // Alle Args, die zu Kein PDx gehören, nicht abhängigen A reinhängen
            foreach (ASZMSelectionArgs a1 in _aa)
            {
                if (a1.IDADependet != Guid.Empty)
                    continue;
                if (a1.IDPDX == Guid.Empty)
                    InsertEmptyPDxTreeNode(a1);
            }

            //Args, die zu Kein PDx gehören: Alle von A abhängigen M reinhängen (nur M haben IDADependet != null)
            foreach (ASZMSelectionArgs a2 in _aa)
            {
                if (a2.IDADependet == Guid.Empty || a2.IDPDX != Guid.Empty)
                    continue;
                InsertEmptyPDxTreeNodeDependet(a2);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Args in die Treenode erste Reihe einfügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertPDxIntoTreeNode()
        {
            if (_pdxSArgs != null)
            {
                int i = 0;

                foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                {
                    UltraTreeNode tn = tv.Nodes.Add(i + "_" + pdxSA.IDPDX.ToString(), PMDS.DB.DBUtil.GetPDX(pdxSA.IDPDX).Klartext);
                    tn.Tag = pdxSA;

                    SetPDxTreeNodeImage(pdxSA, tn);
                    
                    //TreeNode 2 Reihe einfügen
                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.A))
                            break;
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.S))
                            break;
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.R))
                            break;
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.Z))
                            break;
                    }

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.M))
                            break;
                    }
                    i++;
                }

                //Alle von A abhängigen M reinhängen (nur M haben IDADependet != null)
                foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                {
                    foreach (ASZMSelectionArgs arg in pdxSA.ARGS)
                    {
                        if (arg.IDADependet == Guid.Empty)
                            continue;
                        InsertASZMIntoPDxTreeNodeDependet(pdxSA, arg);
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// TreeNode 2. und 3 Reihe einfügen
        /// </summary>
        /// //----------------------------------------------------------------------------
        private bool InsertPDxEintragGruppeIntoTreeNode(int anz, ASZMSelectionArgs aa, UltraTreeNode tn, PDxSelectionArgs pdxSA, EintragGruppe eintraggruppe)
        {
            if (aa.IDPDX != null && aa.IDPDX == pdxSA.IDPDX && aa.EintragGruppe == eintraggruppe)
            {
                if (!UltraTreeTools.ExistPDxEintragGruppe(tv, eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString()))
                {
                    UltraTreeNode n = tn.Nodes.Add(eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString(), ENV.String(eintraggruppe.ToString()));
                    n.Tag = eintraggruppe; 

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

                            SetASZMTreeNodeImage(arg, nn);
                        }
                    }

                    return true;
                }
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

            SetASZMTreeNodeImage(args, n1);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die richtige Node zue A (zu PDx nicht zugeordnet)
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTreeNode GetEmptyPDxDependedNode(Guid IDAtiologie)
        {
            return UltraTreeTools.FindPDxDependedNodeFromNode(_nOhne.Nodes, IDAtiologie, Guid.Empty);	// nur hinter dieser Node sind die Ätiologien versteckt
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM hängen, die zu keine Pdx zugeordnet
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertEmptyPDxTreeNode(ASZMSelectionArgs a1)
        {
            UltraTreeNode n = GetEmptyPDxNode(a1.EintragGruppe);

            UltraTreeNode nn = n.Nodes.Add(Guid.NewGuid().ToString(), a1.Text);
            nn.Tag = a1;

            SetASZMTreeNodeImage(a1, nn);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Abhängigen Maßnahmen zu den Ätiologien hängen, die zu keine Pdx zugeordnet
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertEmptyPDxTreeNodeDependet(ASZMSelectionArgs a)
        {
            UltraTreeNode n = GetEmptyPDxDependedNode(a.IDADependet);
            UltraTreeNode n1 = n.Nodes.Add(Guid.NewGuid().ToString(), a.Text);
            n1.Tag = a;

            SetASZMTreeNodeImage(a, n1);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Root Node der ASZM ohne PDxZuordnung
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTreeNode GetEmptyPDxNode(EintragGruppe gr)
        {
            switch (gr)
            {
                case EintragGruppe.A:
                    return _nA;
                case EintragGruppe.S:
                    return _nS;
                case EintragGruppe.R:
                    return _nR;
                case EintragGruppe.Z:
                    return _nZ;
                case EintragGruppe.M:
                    return _nM;
            }

            throw new Exception("frmAskLocalize::GetEmptyPDxNode() - EintragGruppe " + gr.ToString() + " hier nicht gültig");
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die unnötigen entfernen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RemoveEmptyNodes()
        {
            ArrayList al = new ArrayList();
            
            if (_nOhne != null)
            {
                foreach (UltraTreeNode n1 in _nOhne.Nodes)
                    if (n1.Nodes.Count == 0)
                        al.Add(n1);
            }

            foreach (UltraTreeNode n2 in al)
                n2.Remove();

            if (_nOhne != null)
                if (_nOhne.Nodes.Count == 0)
                    _nOhne.Remove();
        }

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
                    if(_aktivNode.Tag is PDxSelectionArgs && _aktivNode.Tag.Equals(_pdxArg))
                        SetPDxTreeNodeImage(_aktivNode);

                    tv.ActiveNode = n;
                    n.Selected = true;
                    n.Expanded = expend;
                    break;
                }
            }
        }

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
        /// Image eines TreeNode ändern
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateTreeNodeImage()
        {
            if (_aktivNode != null)
            {
                if (_aktivNode.Tag is PDxSelectionArgs)
                {
                    SetPDxTreeNodeImage(_aktivNode);
                }
                else if (_aktivNode.Tag is ASZMSelectionArgs)
                {
                    SetASZMTreeNodeImage(_aktivNode);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Image eines TreeNode ändern
        /// auf basis ein PDx und einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetPDxTreeNodeImage(PDxSelectionArgs pdxArg, UltraTreeNode tn)
        {
            if (pdxArg == null) return;

            if (pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Muss ||
                (pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Kann && pdxArg.LokalisierungJN)
                )
            {
                if (pdxArg.Lokalisierung == null || pdxArg.LokalisierungSeite == null || pdxArg.Lokalisierung.Trim().Length == 0 || pdxArg.LokalisierungSeite.Trim().Length == 0)
                    tn.Override.NodeAppearance.Image = 1;
                else // if(_valueChangeEnabled) Änderung nach 31.03.2008 MDA
                    tn.Override.NodeAppearance.Image = 0;
            }
            else if (_valueChangeEnabled && pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Kann && !pdxArg.LokalisierungJN)
            {
                tn.Override.NodeAppearance.Image = 0;
            }
            else if (!_valueChangeEnabled && (pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Kann || pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.KannNicht))
            {
                tn.Override.NodeAppearance.Image = 0; //Neu nach 31.03.2008 MDA
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Image eines TreeNode ändern
        /// auf basis ein bereits ausgewähte PDx und einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetPDxTreeNodeImage(UltraTreeNode tn)
        {
            SetPDxTreeNodeImage(_pdxArg, tn);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Image eines TreeNode ändern
        /// auf basis ein ASZM und einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetASZMTreeNodeImage(ASZMSelectionArgs arg, UltraTreeNode tn)
        {
            if (arg != null && arg.EintragGruppe == EintragGruppe.M)
            {
                if (ASZMTransfer.IsUntertaegig(arg))
                {
                    DateTime[] untetaegig = null;
                    EintragZusatz ez = new EintragZusatz();

                    dsEintragZusatz.EintragZusatzRow rz;
                    rz = ez.Read(arg.IDEintrag, arg.IDAbteilung);		// Den zugehörigen ZusatzEinrag lesen mit der richtigen Abteilung
                    if (rz == null)
                        rz = ez.Read(arg.IDEintrag, Guid.Empty);			// Wenn keine Abteilung gefungen wurde dann mit der default lesen gehen

                    if (rz != null && !rz.IsIDMassnahmenserienNull())
                    {
                        untetaegig = GetUnterttaegigPoints(rz.IDMassnahmenserien);				// Die einzelnen Pinkte verspeichern
                    }

                    if (untetaegig != null && untetaegig.Length > 0)
                    {
                        if (arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0)
                        {
                            tn.Override.NodeAppearance.Image = null;
                        }
                        else
                        {
                            tn.Override.NodeAppearance.Image = 1;
                        }
                    }
                    else
                    {
                        //if (_valueChangeEnabled && arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0)
                        if (arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0) //Änderungnach 31.03.2008 MDA
                        {
                            tn.Override.NodeAppearance.Image = 0;
                        }
                        else
                        {
                            tn.Override.NodeAppearance.Image = 1;
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Image eines TreeNode ändern
        /// auf basis ein bereits ausgewähte ASZM und einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetASZMTreeNodeImage(UltraTreeNode tn)
        {
            SetASZMTreeNodeImage(_arg, tn);
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

        private void SetActiveKatalogEditModes()
        {
            UltraTreeNode tn = tv.ActiveNode;

            if (tn == null)
            {
                _ActiveKatalogEditModes = KatalogEditModes.All;
                return;
            }

            if (tn.Tag is PDxSelectionArgs)
                _ActiveKatalogEditModes = KatalogEditModes.All;
            else if (tn.Tag is EintragGruppe)
                _ActiveKatalogEditModes = (KatalogEditModes)Enum.Parse(typeof(KatalogEditModes), ((EintragGruppe)tn.Tag).ToString());
            else
            {
                UltraTreeNode n = GetASZMParentNode(tn);

                if (n != null)
                    _ActiveKatalogEditModes = (KatalogEditModes)Enum.Parse(typeof(KatalogEditModes), ((EintragGruppe)n.Tag).ToString());
            }
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

        //Neu nach 31.03.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Node erste Reihe zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        private UltraTreeNode GetTopparentNode(UltraTreeNode tn)
        {
            if (tn.Parent == null)
                return tn;
            return GetTopparentNode(tn.Parent);
        }

        //Neu nach 01.04.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelles PDx zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        public PDxSelectionArgs CurrentPDX()
        {
            if(tv.ActiveNode == null) return null;
            PDxSelectionArgs pdxSelArg = null;
            UltraTreeNode tn = GetTopparentNode(tv.ActiveNode);

            if (tn.Tag is PDxSelectionArgs)
                pdxSelArg = (PDxSelectionArgs)tn.Tag;

            return pdxSelArg;
        }

        //Neu nach 23.04.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle im Checkbox ausgewählten Pflgedefinitionen
        /// </summary>
        //----------------------------------------------------------------------------
        public PDxSelectionArgs[] GetSelectedPDX()
        {
            if (NodeStyle != NodeStyle.CheckBox) return null;
            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.CheckedState == CheckState.Checked && tn.Tag != null && tn.Tag is PDxSelectionArgs)
                    list.Add((PDxSelectionArgs)tn.Tag);
            }

            return list.ToArray();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle im Checkbox ausgewählten ASZM's und keine Pflgedefinitionen
        /// </summary>
        //----------------------------------------------------------------------------
        public ASZMSelectionArgs[] GetSelectedASZM()
        {
            if (NodeStyle != NodeStyle.CheckBox) return null;
            List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.HasNodes)
                    AddASZM(ref list, tn);
                else
                {
                    if (tn.CheckedState == CheckState.Checked && tn.Tag != null && tn.Tag is ASZMSelectionArgs)
                        list.Add((ASZMSelectionArgs)tn.Tag);
                }
            }

            return list.ToArray();
        }

        private void AddASZM(ref List<ASZMSelectionArgs> list, UltraTreeNode tn)
        {
            if (tn.HasNodes)
            {
                foreach (UltraTreeNode n in tn.Nodes)
                {
                    if (n.HasNodes)
                        AddASZM(ref list, n);
                    else
                    {
                        if (n.CheckedState == CheckState.Checked && n.Tag != null && n.Tag is ASZMSelectionArgs)
                            list.Add((ASZMSelectionArgs)n.Tag);
                    }
                }
            }
            else
            {
                if (tn.CheckedState == CheckState.Checked && tn.Tag != null && tn.Tag is ASZMSelectionArgs)
                    list.Add((ASZMSelectionArgs)tn.Tag);
            }
        }

        //Neu nach 31.03.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// EintragGruppe nicht anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void HideOrShowEintragGruppe(UltraTreeNode tn, string group, bool hide)
        {
            if (tn.Key.Contains(group))
            {
                if (tv.ActiveNode != null && (tv.ActiveNode == tn || (tv.ActiveNode.Parent != null && tv.ActiveNode.Parent == tn)) && hide)
                {
                    tv.ActiveNode = GetTopparentNode(tn);
                    tv.ActiveNode.Selected = true;
                }
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

        //Neu nach 31.03.2008 MDA
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

        #region Events
        private void tv_AfterSelect(object sender, SelectEventArgs e)
        {
            UltraTree tv = (UltraTree)sender;
            _aktivNode = tv.ActiveNode;

            _pdxArg = null;
            _arg = null;

            if (_aktivNode.Tag != null)
            {
                if (_aktivNode.Tag is PDxSelectionArgs)
                {
                    _pdxArg = (PDxSelectionArgs)_aktivNode.Tag;
                    _isPDX = true;
                }
                else if (_aktivNode.Tag is ASZMSelectionArgs)
                {
                    _arg = (ASZMSelectionArgs)_aktivNode.Tag;
                    _isPDX = false;
                }
            }

            SetActiveKatalogEditModes(); //Neu nach 31.03.2008 MDA
            if (TreeviewAfterNodeSelectEventHandler != null)
                TreeviewAfterNodeSelectEventHandler(sender, e);
        }

        private void tv_BeforeSelect(object sender, BeforeSelectEventArgs e)
        {
            if (TreeviewBeforeNodeSelectEventArgs != null)
                TreeviewBeforeNodeSelectEventArgs(sender, e);

            if (_aktivNode != null && _aktivNode.Tag != null)
            {
                if (_aktivNode.Tag is PDxSelectionArgs)
                {
                    SetPDxTreeNodeImage(_aktivNode);
                }
                else
                {
                    SetASZMTreeNodeImage(_aktivNode);
                }
            }
        }

        private void tv_AfterCheck(object sender, NodeEventArgs e)
        {
            SetCheckedStateForTreeNodes(e.TreeNode);
        }

        private void tv_AfterExpand(object sender, NodeEventArgs e)
        {
            e.TreeNode.ExpandAll();
        }
        #endregion
    }
}
