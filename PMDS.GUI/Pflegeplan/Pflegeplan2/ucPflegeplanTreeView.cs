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

namespace PMDS.GUI
{
    public partial class ucPflegeplanTreeView : QS2.Desktop.ControlManagment.BaseControl, ITreeview
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
        //private bool _ArgsChange = false;
        private PMDS.BusinessLogic.PflegePlan _PflegePlan;
        private bool _ErledigteAnzeigenJN = false;
        private bool _sendSignal = true;
        private List<ExpededTreeNode> _ExpededTreeNodes = new List<ExpededTreeNode>();

        public event Infragistics.Win.UltraWinTree.BeforeNodeSelectEventHandler TreeviewBeforeNodeSelectEventArgs;
        public event Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler TreeviewAfterNodeSelectEventHandler;
        public event Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler TreeviewAfterCheckEventHandler;

        //Neu nach 16.09.2008 MDA
        private PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;
        //Neu nach 23.09.2008 MDA 
        private PDxSelectionArgs _ActivPDX = null;

        public Image ImageWarningInTree = null;    //lthxy -> ordentliches Icon

        public PMDS.GUI.ucPflegeplan2 mainWindow = null;














        public ucPflegeplanTreeView()
        {
            InitializeComponent();
            this.ImageWarningInTree =  QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, QS2.Resources.getRes.ePicTyp.ico);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das Aktuelle selektierte PDX
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxSelectionArgs ActivPDX
        {
            get { return _ActivPDX; }
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
        /// ASZMSelectionArgs[] setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMSelectionArgs[] ARGS
        {
            get { return _aa; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegePlan setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.BusinessLogic.PflegePlan PFLEGEPLAN
        {
            get { return _PflegePlan; }
            set
            {
                _PflegePlan = value;
                _pdxSArgs = PflegePlanTools.GetPDXSelArgsFromPflegePlan(_PflegePlan, _ErledigteAnzeigenJN);
                RefreshASZMArgs();
                RefreshTree();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Erledigte anzeigen setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ErledigteAnzeigenJN
        {
            get { return _ErledigteAnzeigenJN; }
            set { _ErledigteAnzeigenJN = value; }
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

        //Neu nach 16.09.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set
            {
                _PflegePlanModus = value;
                RefreshTree();
            }
        }

        private void RefreshASZMArgs()
        {
            List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();
            foreach (PDxSelectionArgs pdxArg in PDX_SELARGS)
            {
                if (pdxArg.ARGS == null) continue;
                foreach (ASZMSelectionArgs a in pdxArg.ARGS)
                    list.Add(a);
            }

            _aa = list.ToArray();
        }

        private UltraTreeNode GetTreeNode(PDxSelectionArgs pdxArg)
        {
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if(tn.Tag != null && tn.Tag is PDxSelectionArgs && tn.Tag.Equals(pdxArg))
                    return tn;
            }

            return null;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine neue Lokalisierung für die gerade ausgewählte Pflegedefinition ermöglichen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddLokalisierungFromActualPDx(string Lokalisierung, string LokasierungSeite)
        {
            if (PDX_SARG != null)
            {
                PDxSelectionArgs pdxArg = (PDxSelectionArgs)PDX_SARG.Clone();
                pdxArg.IDAufenthaltPDX = Guid.Empty;
                //Beendete Einträge entfernen
                List<ASZMSelectionArgs> listArgs = new List<ASZMSelectionArgs>();
                foreach (ASZMSelectionArgs sa in pdxArg.ARGS)
                {
                    if (!sa.ErledigtJN)
                    {
                        sa.IDPflegePlan = Guid.Empty; //Neue Einträge
                        sa.IDAufenthaltPDX = Guid.Empty;
                        sa.IDUntertaegigGruppe = Guid.Empty;
                        listArgs.Add(sa);
                    }
                }

                pdxArg.ARGS = listArgs.ToArray();
                
                
                pdxArg.Lokalisierung = Lokalisierung;
                pdxArg.LokalisierungSeite = LokasierungSeite;

                List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();

                bool added = false;
                foreach (PDxSelectionArgs pdxA in PDX_SELARGS)
                {
                    list.Add(pdxA);
                    if (!added && pdxA.IDPDX == pdxArg.IDPDX)
                    {
                        added = true;
                        list.Add(pdxArg);
                    }
                }

                PDX_SELARGS = list.ToArray();

                List<ASZMSelectionArgs> listSA = new List<ASZMSelectionArgs>();
                foreach (ASZMSelectionArgs sa in _aa)
                {
                    listSA.Add(sa);
                }

                foreach (ASZMSelectionArgs sa in pdxArg.ARGS)
                {
                    listSA.Add(sa);
                }
                _aa = listSA.ToArray();


                RefreshTree();
                UltraTreeNode tn = GetTreeNode(pdxArg);
                if (tn != null)
                {
                    tv.ActiveNode = tn;
                    tv.ActiveNode.Selected = true;
                    tn.ExpandAll();
                }
            }
        }

        private void AddPdxToList(PDxSelectionArgs PDxArg)
        {
            PDxSelectionArgs pdxArg = (PDxSelectionArgs)PDxArg.Clone();

            if (_ActivPDX == null)
                _ActivPDX = pdxArg;

            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();

            foreach (PDxSelectionArgs pdxA in PDX_SELARGS)
                list.Add(pdxA);
            
            list.Add(pdxArg);
            PDX_SELARGS = list.ToArray();

            List<ASZMSelectionArgs> listSA = new List<ASZMSelectionArgs>();
            foreach (ASZMSelectionArgs sa in _aa)
            {
                //sa.IsNew = true;
                listSA.Add(sa);
            }

            foreach (ASZMSelectionArgs sa in pdxArg.ARGS)
            {
                sa.IsNew = true;
                listSA.Add(sa);
            }
            _aa = listSA.ToArray();
        }

        public void AddPDxArgs(PDxSelectionArgs[] pdxArgs)
        {
            if (pdxArgs == null) return;
            _ActivPDX = null;
            foreach (PDxSelectionArgs pdxArg in pdxArgs)
                AddPdxToList(pdxArg);

            PDxSelectionArgs pdx = _ActivPDX;
            RefreshTree();

            if (pdxArgs.Length > 0 && pdx != null)
            {
                bool expend;
                foreach (UltraTreeNode n in tv.Nodes)
                {
                    expend = n.Expanded;
                    if (n.Tag is PDxSelectionArgs && n.Tag.Equals(pdx))
                    {
                        if (_aktivNode.Tag is PDxSelectionArgs && _aktivNode.Tag.Equals(pdx))
                            SetPDxTreeNodeImage(_aktivNode);

                        tv.ActiveNode = n;
                        n.Selected = true;
                        n.Expanded = expend;
                        break;
                    }

                    //if (n.Tag is PDxSelectionArgs)
                    //{
                    //    PDxSelectionArgs tnPDx = (PDxSelectionArgs)n.Tag;


                    //    if (_aktivNode.Tag is PDxSelectionArgs && _aktivNode.Tag.Equals(pdx))
                    //        SetPDxTreeNodeImage(_aktivNode);

                    //    tv.ActiveNode = n;
                    //    n.Selected = true;
                    //    n.Expanded = expend;
                    //    break;
                    //}
                }
            }
            else
            {
                UltraTreeNode tn = _aktivNode;
                SelectTreeNode(tn);
            }
        }

        private void SelectTreeNode(UltraTreeNode tn)
        {
            SelectTreeNode(tn, null);
        }

        private void SelectTreeNode(UltraTreeNode tn, PDxSelectionArgs pdx)
        {
            if (tn == null) return;

            PDxSelectionArgs pdxSa = null;
            ASZMSelectionArgs arg = null;

            if (tn.Tag != null && tn.Tag is PDxSelectionArgs)
                pdxSa = (PDxSelectionArgs)tn.Tag;
            else if (tn.Tag != null && tn.Tag is ASZMSelectionArgs)
                arg = (ASZMSelectionArgs)tn.Tag;
            
            bool gefunden = false;
            foreach (UltraTreeNode n in tv.Nodes)
            {
                //PDX Ebene
                if (pdxSa != null)
                {
                    if(n.Tag is PDxSelectionArgs)
                    {
                        if (((PDxSelectionArgs)n.Tag).IDAufenthaltPDX == pdxSa.IDAufenthaltPDX)
                        {
                            tv.ActiveNode = n;
                            n.Selected = true;
                            break;
                        }
                    }
                }
                else if (arg != null)
                {
                    if (n.Nodes.Count > 0)
                    {
                        foreach (UltraTreeNode nn in n.Nodes)
                        {
                            gefunden = false;
                            if (nn.Nodes.Count > 0)
                            {
                                foreach (UltraTreeNode n1 in nn.Nodes)
                                {
                                    if (n1.Tag is ASZMSelectionArgs && ((ASZMSelectionArgs)n1.Tag).IDAufenthaltPDX == arg.IDAufenthaltPDX &&
                                        ((ASZMSelectionArgs)n1.Tag).IDPDX == arg.IDPDX &&
                                        ((ASZMSelectionArgs)n1.Tag).Text.Trim() == arg.Text.Trim() &&
                                        ((ASZMSelectionArgs)n1.Tag).Lokalisierung.Trim() == arg.Lokalisierung.Trim() &&
                                        ((ASZMSelectionArgs)n1.Tag).LokalisierungSeite.Trim() == arg.LokalisierungSeite.Trim() &&
                                        ((ASZMSelectionArgs)n1.Tag).IDUntertaegigGruppe == arg.IDUntertaegigGruppe
                                    )
                                    {
                                        tv.ActiveNode = n1;
                                        n1.Selected = true;
                                        gefunden = true;
                                        break;
                                    }
                                }
                            }

                            if (gefunden)
                                break;
                        }
                    }
                    
                }
                else if (pdx != null)
                {
                    if (n.Tag is PDxSelectionArgs)
                    {
                        if (((PDxSelectionArgs)n.Tag).IDAufenthaltPDX == pdx.IDAufenthaltPDX)
                        {
                            foreach (UltraTreeNode nn in n.Nodes)
                            {
                                if (nn.Text == tn.Text)
                                {
                                    tv.ActiveNode = nn;
                                    nn.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM's zu Bereits im Treeview selektierte Pflegedefinition hinzufügen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddASZMToCurrentPDx(PDxSelectionArgs[] pdxArgs)
        {
            PDxSelectionArgs currentPDX = GetCurrentPDX();

            List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();

            if (currentPDX.ARGS != null)
            {
                foreach (ASZMSelectionArgs arg in currentPDX.ARGS)
                    list.Add(arg);
            }

            ASZMSelectionArgs FirstArg = null;
            bool gefunden;
            foreach (PDxSelectionArgs pdxArg in pdxArgs)
            {
                if (pdxArg.ARGS == null || pdxArg.IDPDX != currentPDX.IDPDX) continue;
                
                foreach (ASZMSelectionArgs arg in pdxArg.ARGS)
                {
                    gefunden = false;
                    foreach (ASZMSelectionArgs a in list)
                    {
                        if (a.Text == arg.Text && a.ErledigtJN == arg.ErledigtJN)
                        {
                            gefunden = true;
                            break;
                        }

                    }
                    if (!gefunden)
                    {
                        arg.LokalisierungJN = currentPDX.LokalisierungJN;
                        arg.Lokalisierung = currentPDX.Lokalisierung;
                        arg.LokalisierungSeite = currentPDX.LokalisierungSeite;
                        arg.ISPDX = true;

                        list.Add(arg);
                        List<ASZMSelectionArgs> lASZM = new List<ASZMSelectionArgs>();
                        foreach (ASZMSelectionArgs a in _aa)
                            lASZM.Add(a);

                        if (FirstArg == null)
                            FirstArg = arg;
                        lASZM.Add(arg);
                        _aa = lASZM.ToArray();
                    }
                }
            }

            currentPDX.ARGS = list.ToArray();
            UltraTreeNode tn = _aktivNode;
            RefreshTree();

            if (FirstArg == null)
                SelectTreeNode(tn);
            else
            {
                UltraTreeNode node;

                if (_aktivNode.HasNodes)
                    node = _aktivNode;
                else if (_aktivNode.Parent != null)
                    node = _aktivNode.Parent;
                else
                    node = _aktivNode;


                foreach (UltraTreeNode n in node.Nodes)
                {
                    if (n.HasNodes)
                    {
                        foreach (UltraTreeNode n1 in n.Nodes)
                        {
                            if (((ASZMSelectionArgs)n1.Tag).Equals(FirstArg))
                            {
                                tv.ActiveNode = n1;
                                n1.Selected = true;
                                n.Expanded = true;
                                break;
                            }
                        }
                    }
                    else if(n.Tag != null && n.Tag is ASZMSelectionArgs)
                    {
                        if (((ASZMSelectionArgs)n.Tag).Equals(FirstArg))
                        {
                            tv.ActiveNode = n;
                            n.Selected = true;
                            n.Expanded = true;
                            break;
                        }
                    }
                }
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
            _pdxArg = null;
            _isPDX = false;

            if (_pdxSArgs == null)
            {
                ClearNodes();
                _aktivNode = null;
                return;
            }

            UltraTreeNode tn = _aktivNode;
            PDxSelectionArgs pdx = _ActivPDX;

            RefreshExpededTreeNodes();
            _valueChangeEnabled = false;
            _ActiveKatalogEditModes = KatalogEditModes.All; //Neu nach 31.03.2008 MDA
            tv.BeginUpdate();
            FillTreeByPDx();
            RemoveEmptyNodes();
            ExpandAll = _ExpandAll;

            if (tv.Nodes.Count > 0)
            {
                tv.ActiveNode = tv.Nodes[0];
                tv.ActiveNode.Selected = true;
            }

            foreach (UltraTreeNode tn1 in tv.Nodes)
            {
                if (tn1.ToString().ToUpper().Contains("RISIKO"))
                {
                    // Äthiologie in Risikofaktoren umbenennen
                    foreach (UltraTreeNode n in tn1.Nodes)
                    {
                        if (n.Tag.ToString() == "S")
                        {
                            n.Visible = false;
                            //HideOrShowEintragGruppe(n, group, false);
                        }
                        else if (n.Tag.ToString() == "A")
                        {
                            n.Text = ENV.String("RFs"); //Risikofaktoren
                                                        //HideOrShowEintragGruppe(n, group, true);
                        }
                    }
                }
            }



            tv.Select();
            tv.EndUpdate();
            ExpedTreeNodes();

            //Vorher Selektierte TreeNode wieder slektieren.
            if (tn != null)
                SelectTreeNode(tn, pdx);
            _valueChangeEnabled = true;
        }

        private void RefreshExpededTreeNodes()
        {
            _ExpededTreeNodes.Clear();

            foreach (UltraTreeNode tn in tv.Nodes)
            {
                _ExpededTreeNodes.Add(new ExpededTreeNode(tn, tn.Expanded));
            }
        }

        private void ExpedTreeNodes()
        {
            PDxSelectionArgs pdxSel, EXpPdxSel;
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                pdxSel = (PDxSelectionArgs)tn.Tag;
                foreach (ExpededTreeNode eTn in _ExpededTreeNodes)
                {
                    EXpPdxSel = (PDxSelectionArgs)eTn._tn.Tag;
                    if (pdxSel.IDPDX == EXpPdxSel.IDPDX && pdxSel.Lokalisierung.Trim() == EXpPdxSel.Lokalisierung.Trim() &&
                        pdxSel.LokalisierungSeite.Trim() == EXpPdxSel.LokalisierungSeite.Trim())
                    {
                        tn.Expanded = eTn._expeded;

                        if (tn.Expanded)
                            ExpedTreeNodes(tn, eTn);
                        break;
                    }
                }
            }
        }

        private void ExpedTreeNodes(UltraTreeNode tn, ExpededTreeNode eTn)
        {
            foreach (UltraTreeNode n in tn.Nodes)
            {
                foreach (UltraTreeNode en in eTn._tn.Nodes)
                {
                    if (n.Key == en.Key)
                    {
                        n.Expanded = en.Expanded;
                        break;
                    }
                }
            }
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
            _nR.Nodes.Clear();   
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
            _sendSignal = false;
            ClearNodes();
            _sendSignal = true;
            _nOhne = tv.Nodes.Add("OHNE", ENV.String("GUI.OHNE_ZUORDNUNG"));
            //Neu nach 16.09.2008 MDA
            
            _nOhne.Nodes.Add(_nA);

            if (_PflegePlanModus == PflegePlanModus.Normal)
            {
                _nOhne.Nodes.Add(_nS);
                _nOhne.Nodes.Add(_nR);
            }
            _nOhne.Nodes.Add(_nZ);
            _nOhne.Nodes.Add(_nM);

            //Alle PDX und dazu gehörenden Args in die Treenode einfügen
            InsertPDxIntoTreeNode();

            if (_aa == null) return;

            // Alle Args, die zu Kein PDx gehören, nicht abhängigen A reinhängen
            foreach (ASZMSelectionArgs a1 in _aa)
            {
                if (a1.IDADependet != Guid.Empty) continue;
                //Ab 16.2.2011, os
                //Bei Wunden Symptome nicht anzeigen
                if (_PflegePlanModus == PflegePlanModus.Wunde && a1.EintragGruppe == EintragGruppe.S) continue;
                if (a1.IDPDX == Guid.Empty) InsertEmptyPDxTreeNode(a1);
            }

            //Args, die zu Kein PDx gehören: Alle von A abhängigen M reinhängen (nur M haben IDADependet != null)
            foreach (ASZMSelectionArgs a2 in _aa)
            {
                if (a2.IDADependet == Guid.Empty || a2.IDPDX != Guid.Empty) continue;

                //Ab 16.2.2011
                //Bei Wunden Symptome nicht anzeigen
                if (_PflegePlanModus == PflegePlanModus.Wunde && a2.EintragGruppe == EintragGruppe.S) continue;

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
                //this.tv.UseAppStyling = false;

                int i = 0;
                PDx pdx;
                string lokalisierung;
                StringBuilder sb;
                foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                {
                    pdx = new PDx();
                    sb = new StringBuilder();
                    lokalisierung = "";
                    if (pdxSA.Lokalisierung.Trim() != "")
                        sb.Append(pdxSA.Lokalisierung.Trim());

                    if (pdxSA.LokalisierungSeite.Trim() != "")
                        sb.Append(" " + pdxSA.LokalisierungSeite.Trim());

                    if (sb.Length > 0)
                        lokalisierung = " (" + sb.ToString() + ")";
                    UltraTreeNode tn = tv.Nodes.Add(i + "_" + pdxSA.IDPDX.ToString(), pdx.ReadOne(pdxSA.IDPDX).Klartext.Trim() + lokalisierung);
                    tn.Tag = pdxSA;
                    tn.Override.NodeAppearance.ForeColor = pdxSA.ErledigtJN ? ENVCOLOR.EINTRAG_ENDED_FORE_COLOR : ENVCOLOR.EINTRAG_CURRENT_FORE_COLOR;

                    SetPDxTreeNodeImage(pdxSA, tn);

                    //ASZM Ebene ausfüllen
                    FillASZMEitraege(tn, i, pdxSA);

                    if (pdxSA.ARGS == null)
                    {
                        i++;
                        continue;
                    }
                    //TreeNode 2 Reihe einfügen

                    foreach (ASZMSelectionArgs aa in pdxSA.ARGS)
                    {
                        if (InsertPDxEintragGruppeIntoTreeNode(i, aa, tn, pdxSA, EintragGruppe.A))
                            break;
                    }

                    //Neu ab 16.2.2011, os
                    //Bei Wunden Symptome und Ressourcen nicht anzeigen
                    if (_PflegePlanModus == PflegePlanModus.Normal)
                    {
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
                //Neu nach 16.09.2008 MDA
                //Bei Wunden nur Ziele und Maßnahmen anzeigen
                if (_PflegePlanModus == PflegePlanModus.Normal)
                {
                    foreach (PDxSelectionArgs pdxSA in _pdxSArgs)
                    {
                        if (pdxSA.ARGS == null) continue;
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

        private void FillASZMEitraege(UltraTreeNode tn, int anz, PDxSelectionArgs pdxSA)
        {
            string[] names = Enum.GetNames(typeof(EintragGruppe));

            tv.BeginUpdate();
            UltraTreeNode n;
            EintragGruppe eintraggruppe;
            foreach (string name in names)
            {
                if (name == "T" || name == "X") continue;
                //Neu nach 16.09.2008 MDA
                //Bei Wunden nur Beeinflussende Faktoren, Ziele und Maßnahmen anzeigen               
                //Ab 16.2.2011, os
                //Symptome und Ressourcen unterdrücken

                if (_PflegePlanModus == PflegePlanModus.Wunde && (name == "S" || name == "R")) continue;

                if (!UltraTreeTools.ExistPDxEintragGruppe(tv, name + "_" + anz + "_" + pdxSA.IDPDX.ToString()))
                {
                    if (_PflegePlanModus == PflegePlanModus.Wunde && name == "A")
                    {
                        // Ätiologie in Beeinflussende Faktoren umbenennen
                        n = tn.Nodes.Add(name + "_" + anz + "_" + pdxSA.IDPDX.ToString(), ENV.String("B"));
                    }
                    else
                    {
                        n = tn.Nodes.Add(name + "_" + anz + "_" + pdxSA.IDPDX.ToString(), ENV.String(name));
                    }
                    eintraggruppe = (EintragGruppe)Enum.Parse(typeof(EintragGruppe), name);
                    n.Tag = eintraggruppe;
                }
            }

            tv.EndUpdate();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// TreeNode 2. und 3 Reihe einfügen
        /// </summary>
        /// //----------------------------------------------------------------------------
        private bool InsertPDxEintragGruppeIntoTreeNode(int anz, ASZMSelectionArgs aa, UltraTreeNode tn, PDxSelectionArgs pdxSA, EintragGruppe eintraggruppe)
        {
            //Neu nach 25.06.2007 MDA: TreeNodes A, S, Z und M immer anzeigen auch wenn keine Einträge vorhanden sind.
            UltraTreeNode n;

            if (!UltraTreeTools.ExistPDxEintragGruppe(tv, eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString()))
            {
// Eintragen der Nodes ASZM        
                if (_PflegePlanModus == PflegePlanModus.Wunde && eintraggruppe == EintragGruppe.A)
                {
                    // Ätiologie in Beeinflussende faktoren umbenennen
                    n = tn.Nodes.Add(eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString(), ENV.String("B"));
                }
                else
                {
                    n = tn.Nodes.Add(eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString(), ENV.String(eintraggruppe.ToString()));
                }
                n.Tag = eintraggruppe;
           }
            else
                n = UltraTreeTools.FindNodeKey(tv.Nodes, eintraggruppe.ToString() + "_" + anz + "_" + pdxSA.IDPDX.ToString());


            if (aa.IDPDX != null && aa.IDPDX == pdxSA.IDPDX && aa.EintragGruppe == eintraggruppe)
            {
                UltraTreeNode nn;
                foreach (ASZMSelectionArgs arg in pdxSA.ARGS)
                {
                    if (arg.IDADependet != Guid.Empty)
                        continue;
                     //&& aa.LokalisierungJN == pdxSA.LokalisierungJN &&
                     //   aa.Lokalisierung == pdxSA.Lokalisierung && aa.LokalisierungSeite == pdxSA.LokalisierungSeite
                    if (arg.EintragGruppe == eintraggruppe)
                    {
                        //TreeNode 3 Reihe einfügen
                        nn = n.Nodes.Add(Guid.NewGuid().ToString(), arg.Text.Trim());
                        nn.Tag = arg;
                        //nn.Override.NodeAppearance.ForeColor = arg.ErledigtJN ? ENVCOLOR.EINTRAG_ENDED_FORE_COLOR : ENVCOLOR.EINTRAG_CURRENT_FORE_COLOR;
                        UpdateASZMTextForeColor(nn);
                        SetASZMTreeNodeImage(arg, nn);
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Wenn der Text einer ASZM geändert wurde, dann die Änderung im TreeNode übernehmen.
        /// Wenn Text vom Original geändert, dann rot markieren. Wenn beendet Grün markieren.
        /// </summary>
        /// <param name="tn"></param>
        private void UpdateASZMTextForeColor(UltraTreeNode tn)
        {
            if (tn != null && tn.Tag != null && tn.Tag is ASZMSelectionArgs)
            {
                ASZMSelectionArgs arg = (ASZMSelectionArgs)tn.Tag;

                //Wenn der Text geändert wurde, dann die Änderung im TreeNode übernehmen
                if (tn.Text.Trim() != arg.Text.Trim())
                    tn.Text = arg.Text.Trim();

                //Wenn Text vom Original geändert, dann rot markieren
                string sOriginal = Eintrag.GetText(arg.IDEintrag);
                if (!arg.Text.Trim().ToLower().Equals(sOriginal.Trim().ToLower()))
                {
                    tn.Override.NodeAppearance.ForeColor = ENVCOLOR.EINTRAG_CURRENT_NOT_ORIGINAL_FORE_COLOR;
                }
                else
                {
                    tn.Override.NodeAppearance.ForeColor = arg.ErledigtJN ? ENVCOLOR.EINTRAG_ENDED_FORE_COLOR : ENVCOLOR.EINTRAG_CURRENT_FORE_COLOR;
                }
            }
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
            //n1.Override.NodeAppearance.ForeColor = args.ErledigtJN ? ENVCOLOR.EINTRAG_ENDED_FORE_COLOR : ENVCOLOR.EINTRAG_CURRENT_FORE_COLOR;
            UpdateASZMTextForeColor(n1);
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
                case EintragGruppe.Z:
                    return _nZ;
                case EintragGruppe.R:
                    return _nR;
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
                {
                    tn.Override.NodeAppearance.Image = this.ImageWarningInTree; 
                }
                else
                {
                    tn.Override.NodeAppearance.Image = null; 
                }
            }
            else if (_valueChangeEnabled && pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Kann && !pdxArg.LokalisierungJN)
            {
                tn.Override.NodeAppearance.Image = null; 
            }
            else if (!_valueChangeEnabled && (pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.Kann || pdxArg.LokalisierungsTyp == PDxLokalisierungsTypen.KannNicht))
            {
                tn.Override.NodeAppearance.Image = null; 
            }

            AddLokalisierungToText(pdxArg, tn);
        }

        //Neu nach 03.09.2008 MDA
        /// <summary>
        /// Nach jede Änderung der Lokalisierung und Lokalisierungseite, Text acktualisieren
        /// </summary>
        /// <param name="pdxArg"></param>
        /// <param name="tn"></param>
        private void AddLokalisierungToText(PDxSelectionArgs pdxArg, UltraTreeNode tn)
        {
            StringBuilder sb = new StringBuilder();
            PDx pdx = new PDx();
            string lokalisierung = "";
            if (pdxArg.Lokalisierung.Trim() != "")
                sb.Append(pdxArg.Lokalisierung.Trim());

            if (pdxArg.LokalisierungSeite.Trim() != "")
                sb.Append(" " + pdxArg.LokalisierungSeite.Trim());

            if (sb.Length > 0)
                lokalisierung = " (" + sb.ToString() + ")";
            tn.Text = pdx.ReadOne(pdxArg.IDPDX).Klartext.Trim() + lokalisierung;
                    
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
                if (arg.OhneZeitBezug)
                    tn.Override.NodeAppearance.Image = null;
                else if (ASZMTransfer.IsUntertaegig(arg))
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
                        if ((arg.ZEITBEREICH != null && arg.ZEITBEREICH.Length > 0) || (arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0))
                        {
                            tn.Override.NodeAppearance.Image = null;
                        }
                        else
                        {
                            tn.Override.NodeAppearance.Image = this.ImageWarningInTree; 
                        }
                    }
                    else
                    {
                        //if (_valueChangeEnabled && arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0)
                        if ((arg.ZEITBEREICH != null && arg.ZEITBEREICH.Length > 0) || (arg.UNTERTAEGIG != null && arg.UNTERTAEGIG.Length > 0)) //Änderungnach 31.03.2008 MDA
                        {
                            tn.Override.NodeAppearance.Image = null;
                        }
                        else
                        {
                            tn.Override.NodeAppearance.Image = this.ImageWarningInTree; 
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
        private PDxSelectionArgs GetCurrentPDX()
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
                if (tn.CheckedState == CheckState.Checked && tn.Tag != null && tn.Tag is PDxSelectionArgs)
                    continue;

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

            //os 20.9.2018 Risiko-PDX haben keine Ätiologie, sondern Risikofaktoren und keine Symptome
            if (tn.ToString().ToUpper().Contains("RISIKO"))
                foreach (UltraTreeNode n in tn.Nodes)
                {
                    if (n.Tag.ToString() == "S")
                    {
                        n.Visible = false;
                        //HideOrShowEintragGruppe(n, group, false);
                    }
                    else if (n.Tag.ToString() == "A")
                    {
                        n.Text = ENV.String("RFs"); //Risikofaktoren
                        //HideOrShowEintragGruppe(n, group, true);
                    }
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
            _aktivNode = tv.ActiveNode;

            _pdxArg = null;
            _arg = null;

            if (Visible && _sendSignal && _aktivNode.Tag != null)
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

            _ActivPDX = GetCurrentPDX();

            SetActiveKatalogEditModes(); //Neu nach 31.03.2008 MDA
            if (Visible && _sendSignal && TreeviewAfterNodeSelectEventHandler != null)
                TreeviewAfterNodeSelectEventHandler(this, e);
        }

        private void tv_BeforeSelect(object sender, BeforeSelectEventArgs e)
        {
            if (Visible && _sendSignal && TreeviewBeforeNodeSelectEventArgs != null)
                TreeviewBeforeNodeSelectEventArgs(this, e);

            if (Visible && _sendSignal && _aktivNode != null && _aktivNode.Tag != null)
            {
                if (_aktivNode.Tag is PDxSelectionArgs)
                {
                    SetPDxTreeNodeImage(_aktivNode);
                }
                else
                {
                    SetASZMTreeNodeImage(_aktivNode);

                    //Rot färben wenn Text geändert wurde
                    UpdateASZMTextForeColor(_aktivNode);
                }

                //this.mainWindow.setUIPanelVOMedikamete();
                //if (this.mainWindow.ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count == 1)
                //{
                //    dsWunde.WundeKopfRow rWundeKopf = (dsWunde.WundeKopfRow)mainWindow.ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows[0];
                //    string IDStr = rWundeKopf.ID.ToString();
                //}
            }
        }

        private void tv_AfterCheck(object sender, NodeEventArgs e)
        {
            SetCheckedStateForTreeNodes(e.TreeNode);
            if (TreeviewAfterCheckEventHandler != null)
                TreeviewAfterCheckEventHandler(this, e);
        }

        private void tv_AfterExpand(object sender, NodeEventArgs e)
        {
            e.TreeNode.ExpandAll();
        }
        #endregion

        private void ucPflegeplanTreeView_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && tv.ActiveNode != null)
                tv.ActiveNode.Selected = true;
        }

        private class ExpededTreeNode
        {
            public UltraTreeNode _tn;
            public bool _expeded;
            public ExpededTreeNode(UltraTreeNode tn, bool expeded)
            {
                _tn = tn;
                _expeded = expeded;
            }
        }

        private void tv_BeforeCheck(object sender, BeforeCheckEventArgs e)
        {
            if (e.TreeNode.Tag != null)
            {
                if (e.TreeNode.Tag is PDxSelectionArgs)
                {
                    PDxSelectionArgs pdxArg = (PDxSelectionArgs)e.TreeNode.Tag;
                    if (pdxArg.ErledigtJN)
                        e.Cancel = true;
                }
                else if (e.TreeNode.Tag is ASZMSelectionArgs)
                {
                    ASZMSelectionArgs arg = (ASZMSelectionArgs)e.TreeNode.Tag;
                    if(arg.ErledigtJN)
                        e.Cancel = true;
                }
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            if (bOn)
            {
                this.tv.Override.NodeStyle = NodeStyle.Standard;
            }
            else
            {
                this.tv.Override.NodeStyle = NodeStyle.CheckBox;
            }
        }

        private void tv_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            try
            {
                //if (e.Element is Infragistics.Win.UltraWinTree.NodeTextUIElement)
                //{
                //    Point pt = new Point(e.Element.Rect.X, e.Element.Rect.Y);
                //    Infragistics.Win.UltraWinTree.UltraTreeNode node = this.tv.GetNodeFromPoint(pt);
                //    if (node != null)
                //    {
                //        if (node.Tag.GetType() == typeof(PMDS.Global.ASZMSelectionArgs))
                //        {
                //            PMDS.Global.ASZMSelectionArgs tgAszm = (PMDS.Global.ASZMSelectionArgs)node.Tag;
                //            string txtOrig = Eintrag.GetText(tgAszm.IDEintrag).Trim();
                //            if (!tgAszm.Text.Trim().ToLower().Equals(txtOrig.Trim().ToLower()))
                //            {
                //                ////Infragistics.Win.UltraWinToolTip.UltraToolTipInfo tipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(txtOrig, Infragistics.Win.ToolTipImage.Default, "", Infragistics.Win.DefaultableBoolean.True);
                //                ////this.ultraToolTipManager1.SetUltraToolTip(this.tv, tipInfo);
                //                ////this.ultraToolTipManager1.ShowToolTip(this.tv);

                //                //this.ultraToolTipManager1.SetUltraToolTip(this.tv, null);
                //                //this.ultraToolTipManager1.HideToolTip();
                //            }
                //            else
                //            {
                //                this.ultraToolTipManager1.SetUltraToolTip(this.tv, null);
                //                this.ultraToolTipManager1.HideToolTip();
                //            }
                //        }
                //        else
                //        {
                //            this.ultraToolTipManager1.SetUltraToolTip(this.tv, null);
                //            this.ultraToolTipManager1.HideToolTip();
                //        }
                //    }
                //}
                //else
                //{
                //    this.ultraToolTipManager1.SetUltraToolTip(this.tv, null);
                //    this.ultraToolTipManager1.HideToolTip();
                //}

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
