//----------------------------------------------------------------------------------------------
//  Erstellt am:	24.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;
using S2Extensions;

namespace PMDS.GUI
{
    public partial class ucPdxVerwaltungTreeView : QS2.Desktop.ControlManagment.BaseControl
    {
        public delegate void TreeviewAfterNodeSelectDelegate(object Tag);
        public delegate void TreeviewBeforeNodeSelectDelegate(object Tag, CancelableNodeEventArgs e);
        public delegate void TreeviewAfterCheckDelegate(UltraTreeNode[] CheckedTreeNodes);
        public delegate void TreeviewBeforeCheckDelegate(BeforeCheckEventArgs e);
        public event TreeviewAfterNodeSelectDelegate AfterNodeSelect;
        public event TreeviewBeforeNodeSelectDelegate BeforeNodeSelect;
        public event TreeviewAfterCheckDelegate AfterNodeCheck;
        public event TreeviewBeforeCheckDelegate BeforeNodeCheck;
        private PDXDef _def = null;
        private dsPDxEintrag.PDXEintragDataTable _pdxEintrag = null;
        private bool _ExpendAll = true;
        private UltraTreeNode _CurrentNode = null;

        public ucPdxVerwaltungTreeView()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ExpendAll
        {
            get { return _ExpendAll; }
            set
            {
                _ExpendAll = value;

                if( _ExpendAll)
                    tv.ExpandAll();
                else
                    tv.CollapseAll();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDXDef Def
        {
            get { return _def; }
            set
            {
                _def = value;
                FillPDx();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPDxEintrag.PDXEintragDataTable PDXEintrag
        {
            get { return _pdxEintrag; }
            set
            {
                _pdxEintrag = value;
                FillASZMEitraege();
            }
        }

        //PDX Ebene
        private void FillPDx()
        {
            tv.Nodes.Clear();

            if (Def == null)
                return;

            tv.BeginUpdate();
            UltraTreeNode tn = tv.Nodes.Add(Def.ID.ToString(), Def.Klartext);
            tn.Tag = Def;
            tn.Selected = true;
            if(_CurrentNode == null || _CurrentNode.Tag is PDXDef)
                tv.ActiveNode = tn;

            if (_ExpendAll)
                tv.ExpandAll();

            tv.EndUpdate();
        }

        //ASZM Ebene
        private void FillASZMEitraege()
        {
            if (Def == null || PDXEintrag == null)
                return;

            string[] names = Enum.GetNames(typeof(EintragGruppe));

            tv.BeginUpdate();

            //Änderung nach 25.09.2008 MDA
            //Bei Wunden nur ZM's Einträgen zulassen
            // Ab 16.2.2011, os
            // Bei Wunden Symptome unterdrücken
            foreach (string name in names)
            {
                if (name == "T" || name == "X") continue;
                if (Def.WundeJN && name == "S") continue;
                AddASZMEintraege(tv.Nodes[0], name);
            }

            if (_ExpendAll)
                tv.ExpandAll();

            tv.EndUpdate();
        }

        //ASZM Pro EintragGruppe
        private void AddASZMEintraege(UltraTreeNode PDxTreeNode, string name)
        {
            UltraTreeNode n = new UltraTreeNode();

            bool bIsAdded = false;

            //Bei Wunden
            if (Def.WundeJN)
            {
                if (name == "S")
                {
                    n = PDxTreeNode.Nodes.Add(Def.ID + "_" + name, ENV.String("B"));
                    n.Visible = false;                              //Symptome ausblenden
                    bIsAdded = true;
                }
                else if (name == "A")
                {
                    n = PDxTreeNode.Nodes.Add(Def.ID + "_" + name, ENV.String("B"));    // Ätiologien in Beeinflussende Faktoren umbenennen
                    bIsAdded = true;
                }
            }
            else
            {
                if (PDxTreeNode.Tag.GetType() == typeof(PMDS.Global.PDXDef))
                {
                    PMDS.Global.PDXDef t = (PMDS.Global.PDXDef)PDxTreeNode.Tag;
                    if (name == "A" && (t.PDXGruppe == PMDS.Global.ePDXGruppe.Risikodiagnose || PDxTreeNode.sContains("RISIKO")))
                    {
                        n = PDxTreeNode.Nodes.Add(Def.ID + "_" + name, ENV.String("RFs"));  // Ätiologien in Risikofaktoren umbenennen
                        bIsAdded = true;
                    }
                    else if (name == "S" && (t.PDXGruppe == PMDS.Global.ePDXGruppe.Risikodiagnose || PDxTreeNode.sContains("RISIKO")))
                    {
                        n = PDxTreeNode.Nodes.Add(Def.ID + "_" + name, ENV.String("S"));
                        n.Visible = false;                              //Symptome ausblenden
                        bIsAdded = true;
                    }
                }
            }

            if (!bIsAdded)
            {
                n = PDxTreeNode.Nodes.Add(Def.ID + "_" + name, ENV.String(name));                
            }
            n.Tag = Def.ID.ToString() + "_" + name;
            
            if (_CurrentNode != null && _CurrentNode.Tag.ToString() == Def.ID.ToString() + "_" + name)
                tv.ActiveNode = n;

            UltraTreeNode nn;

            foreach (dsPDxEintrag.PDXEintragRow r in PDXEintrag)
            {
                if (r.RowState == DataRowState.Deleted)
                    continue;
                if (r.IDPDX == Def.ID && r.EintragGruppe == name)
                {
                    nn = n.Nodes.Add(r.IDEintrag.ToString(), r.Text);
                    nn.Tag = r;

                    if (_CurrentNode != null && _CurrentNode.Tag is dsPDxEintrag.PDXEintragRow &&
                        ((dsPDxEintrag.PDXEintragRow)_CurrentNode.Tag).ID == r.ID
                       )
                    {
                        tv.ActiveNode = nn;
                    }
                }

            }
            //n.Dispose();
        }

        public UltraTreeNode[] GetCheckedASZMTreeNodes()
        {
            List<UltraTreeNode> list = new List<UltraTreeNode>();
            
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.CheckedState == CheckState.Checked && tn.Tag is dsPDxEintrag.PDXEintragRow)
                    list.Add(tn);
                if(tn.HasNodes)
                    GetCheckedASZMTreeNodes(tn.Nodes, list);
            }

            return list.ToArray();
        }

        private void GetCheckedASZMTreeNodes(TreeNodesCollection Collection, List<UltraTreeNode> list)
        {
            foreach (UltraTreeNode n in Collection)
            {
                if (n.CheckedState == CheckState.Checked && n.Tag is dsPDxEintrag.PDXEintragRow)
                    list.Add(n);
                if (n.HasNodes)
                    GetCheckedASZMTreeNodes(n.Nodes, list);
            }
            
        }

        private UltraTreeNode GetTreeNode(TreeNodesCollection Collection, MouseEventArgs e)
        {
            UltraTreeNode n = null;

            foreach (UltraTreeNode tn in Collection)
            {

                if (e.X >= tn.Bounds.X && e.X <= (tn.Bounds.X + tn.Bounds.Width) && e.Y >= tn.Bounds.Y && e.Y <= (tn.Bounds.Y + tn.Bounds.Height))
                {
                    n = tn;
                    break;
                }

                if(n == null)
                    n = GetTreeNode(tn.Nodes, e);
            }

            return n;
        }

        private void SetCheckedStateForTreeNodes(UltraTreeNode tn)
        {
            foreach (UltraTreeNode nn in tn.Nodes)
            {
                nn.CheckedState = tn.CheckedState;
                if (nn.HasNodes)
                    SetCheckedStateForTreeNodes(nn);
            }
        }

        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            UltraTreeNode tn = GetTreeNode(tv.Nodes, e);

            if (tn != null)
            {
                tv.SelectedNodes.Clear();
                tn.Selected = true;
                tv.ActiveNode = tn;
                _CurrentNode = tv.ActiveNode;
            }
        }

        private void tv_AfterSelect(object sender, SelectEventArgs e)
        {
            if (e.NewSelections.Count > 0)
            {
                tv.ActiveNode = e.NewSelections[0];
                _CurrentNode = tv.ActiveNode;

                if (AfterNodeSelect != null && tv.ActiveNode != null)
                    AfterNodeSelect(tv.ActiveNode.Tag);
            }
        }

        private void tv_AfterCheck(object sender, NodeEventArgs e)
        {
            SetCheckedStateForTreeNodes(e.TreeNode);
            if (AfterNodeCheck != null)
                AfterNodeCheck(GetCheckedASZMTreeNodes());
        }

        private void tv_BeforeActivate(object sender, CancelableNodeEventArgs e)
        {
            if (BeforeNodeSelect != null && tv.ActiveNode != null)
                BeforeNodeSelect(tv.ActiveNode.Tag, e);
        }

        private void tv_BeforeCheck(object sender, BeforeCheckEventArgs e)
        {
            if (BeforeNodeCheck != null)
                BeforeNodeCheck(e);
        }
   }
}
