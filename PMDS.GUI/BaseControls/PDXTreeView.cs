//----------------------------------------------------------------------------
/// <summary>
///	PDXTreeView.cs - Darstellung der Pflegedefinitionan als Tree auf Basis
///	eines ASZMSelectionArgs[]
/// Erstellt am:	3.8.2005
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
 using PMDS.Data.Global;
using PMDS.Global;
using Infragistics.Shared;
using Infragistics.Win.UltraWinTree;
using PMDS.BusinessLogic;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// 
	/// </summary>
	//----------------------------------------------------------------------------
	public class PDXTreeView : QS2.Desktop.ControlManagment.BaseControl
	{

		public enum Groupby { ASZM = 0, PDx };

		private UltraTreeNode _nA = new UltraTreeNode("A", ENV.String("A_RFs"));
		private UltraTreeNode _nS = new UltraTreeNode("S", ENV.String("S"));
        private UltraTreeNode _nR = new UltraTreeNode("R", ENV.String("R"));
        private UltraTreeNode _nZ = new UltraTreeNode("Z", ENV.String("Z"));
		private UltraTreeNode _nM = new UltraTreeNode("M", ENV.String("M"));
		private UltraTreeNode _nOhne;
		private ASZMSelectionArgs[] _aa;

		private Infragistics.Win.UltraWinTree.UltraTree tv;
		private System.ComponentModel.Container components = null;

		public PDXTreeView()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Befüllt den Treeview je nach Modus
		/// </summary>
		//----------------------------------------------------------------------------
		public void FillTree(ASZMSelectionArgs[] args, Groupby groupby) 
		{
			_aa = args;
			if(groupby == Groupby.ASZM)
				FillTreeByASZM();
			else
				FillTreeByPDx();

			RemoveEmptyNodes();
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
			_nOhne =  tv.Nodes.Add("OHNE", ENV.String("GUI.OHNE_ZUORDNUNG"));
			_nOhne.Nodes.Add(_nA);
			_nOhne.Nodes.Add(_nS);
			_nOhne.Nodes.Add(_nZ);
			_nOhne.Nodes.Add(_nM);

			// Struktur der PDx aufbauen
			foreach(ASZMSelectionArgs a in _aa) 
			{
				if(a.IDPDX.ToString() == Guid.Empty.ToString())
					continue;
				InsertPDxIntoTreeNode(a);
			}

			// Alle nicht abhängigen A reinhängen
			foreach(ASZMSelectionArgs a1 in _aa) 
			{
				if(a1.IDADependet != Guid.Empty)
					continue;
				InsertASZMIntoPDxTreeNode(a1);
			}

			// Alle von A abhängigen M reinhängen (nur M haben IDADependet != null)
			foreach(ASZMSelectionArgs a2 in _aa) 
			{
				if(a2.IDADependet == Guid.Empty)
					continue;
				InsertASZMIntoPDxTreeNodeDependet(a2);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Abhängigen Maßnahmen zu den Ätiologien hängen
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertASZMIntoPDxTreeNodeDependet(ASZMSelectionArgs args)
		{
			UltraTreeNode n = GetPDxDependedNode(args.IDADependet, args.IDPDX);
			n.Nodes.Add(Guid.NewGuid().ToString(), args.EintragGruppe.ToString() + " - " + args.Text);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die richtige Node zue A/PDx kombination egal ob PDx zugeordnet oder nicht
		/// </summary>
		//----------------------------------------------------------------------------
		private UltraTreeNode GetPDxDependedNode(Guid IDAtiologie, Guid IDPDx) 
		{
			if(IDPDx != Guid.Empty)													// Zugeordnete durchsuchen
				return FindPDxDependedNodeFromNode(tv.Nodes, IDAtiologie, IDPDx);
			else																	// nicht zugeordnete durchsuchen
				return FindPDxDependedNodeFromNode(_nOhne.Nodes, IDAtiologie, IDPDx);	// nur hinter dieser Node sind die Ätiologien versteckt
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die richtige Node zue A/PDx kombination egal ob PDx zugeordnet oder nicht
		/// auf basis einer Root Node
		/// </summary>
		//----------------------------------------------------------------------------
		private UltraTreeNode FindPDxDependedNodeFromNode(Infragistics.Win.UltraWinTree.TreeNodesCollection rootnodes, Guid IDAtiologie, Guid IDPDx) 
		{
			ASZMSelectionArgs a = null;
			foreach(UltraTreeNode n in rootnodes)						// oberste Ebene
			{
				foreach(UltraTreeNode n1 in n.Nodes)					// Zweite ebene - hier sind die A verspeichert
				{
					if(n1.Tag == null)
						continue;
					a = (ASZMSelectionArgs) n1.Tag;
					if(a.IDPDX == IDPDx && a.IDEintrag == IDAtiologie)	// gefunden 
					{
						return n1;
					}
				}
			}
			throw new Exception("frmAskLocalize::FindPDxDependedNodeFromNode() - Programmierinkonsistenz: Eine PDxNode konnte nicht gefunden werden");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Fügt die ASZM in den Tree ein
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertASZMIntoPDxTreeNode(ASZMSelectionArgs a1)
		{
			UltraTreeNode n = null;
			string sBevore = "";
			if(a1.IDPDX == Guid.Empty) 
			{
				n = GetEmptyPDxNode(a1.EintragGruppe);
			}
			else
			{
				sBevore = a1.EintragGruppe.ToString() + " - ";
				n = GetPDxNode(a1.IDPDX);
			}
			UltraTreeNode nn = n.Nodes.Add(Guid.NewGuid().ToString(), sBevore + a1.Text);
			nn.Tag = a1;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Root Node der PDx
		/// </summary>
		//----------------------------------------------------------------------------
		private UltraTreeNode GetPDxNode(Guid IDPDx) 
		{
			foreach(UltraTreeNode n in tv.Nodes) 
			{
				if(n.Key == IDPDx.ToString())
					return n;
			}
			throw new Exception("frmAskLocalize::GetPDxNode() - Programmierinkonsistenz: Eine PDxNode konnte nicht gefunden werden");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Root Node der ASZM ohne PDxZuordnung
		/// </summary>
		//----------------------------------------------------------------------------
		private UltraTreeNode GetEmptyPDxNode(EintragGruppe gr) 
		{
			switch(gr)
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
		/// Die Args in die Treenode erste Reihe einfügen
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertPDxIntoTreeNode(ASZMSelectionArgs arg)
		{
			if(!ExistPDx(arg.IDPDX))
                tv.Nodes.Add(arg.IDPDX.ToString(), PMDS.DB.DBUtil.GetPDX(arg.IDPDX).Klartext);
		}
        
		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert true wenn im Tree die PDXID bereits existiert
		/// </summary>
		//----------------------------------------------------------------------------
		private bool ExistPDx(Guid IDPdx) 
		{
			foreach(UltraTreeNode n in tv.Nodes) 
			{
				if(n.Key == IDPdx.ToString())
					return true;
			}
			return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die unnötigen entfernen
		/// </summary>
		//----------------------------------------------------------------------------
		private void RemoveEmptyNodes() 
		{
			ArrayList al = new ArrayList();
			foreach(UltraTreeNode n in tv.Nodes)
				if(n.Nodes.Count == 0)
					al.Add(n);

			if(_nOhne != null)
			{
				foreach(UltraTreeNode n1 in _nOhne.Nodes)
					if(n1.Nodes.Count == 0)
						al.Add(n1);
			}

			foreach(UltraTreeNode n2 in al)
				n2.Remove();

			if(_nOhne != null)
				if(_nOhne.Nodes.Count == 0)
					_nOhne.Remove();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Ansicht ist ASZM bezogen
		/// </summary>
		//----------------------------------------------------------------------------
		private void FillTreeByASZM()
		{
			ClearNodes();
			tv.Nodes.Add(_nA);
			tv.Nodes.Add(_nS);
			tv.Nodes.Add(_nZ);
			tv.Nodes.Add(_nM);

			// Alle einfügen welche keine Äbhängigkeit zu einer Ä haben
			foreach(ASZMSelectionArgs a in _aa) 
			{
				if(a.IDADependet != Guid.Empty)
					continue;
				InsertIntoTreeNode(a);
			}

			// Alle zu einer Ä abhängigen M zur jeweiligen A hängen
			foreach(ASZMSelectionArgs a1 in _aa) 
			{
				if(a1.IDADependet == Guid.Empty)
					continue;
				InsertIntoTreeNodeDependet(a1);
			}

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Args in die Treenode erste Reihe einfügen
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertIntoTreeNodeDependet(ASZMSelectionArgs arg)
		{
			UltraTreeNode nn = null;

			// Den Ätiologie Tree durchsuchen
			foreach(UltraTreeNode n in _nA.Nodes) 
			{
				if(n.Key == arg.IDADependet.ToString())
				{
					nn = n;
					break;
				}
			}

			if(nn == null) 
				throw new Exception("frmAskLocalize::InsertIntoTreeNodeDependet() - Programmierinkonsistenz: Eine Ätiologie konnte nicht gefunden werden");

            nn.Nodes.Add(Guid.NewGuid().ToString(), arg.Text + " (" + PMDS.DB.DBUtil.GetPDX(arg.IDPDX).Klartext + ")");		// Die abhängige einfügen
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die Args in die Treenode erste Reihe einfügen
		/// </summary>
		//----------------------------------------------------------------------------
		private void InsertIntoTreeNode(ASZMSelectionArgs arg)
		{
			UltraTreeNode n=null;
			switch(arg.EintragGruppe) 
			{
				case EintragGruppe.A:
					n = _nA;
					break;
				case EintragGruppe.S:
					n = _nS;
					break;
				case EintragGruppe.R:
					n = _nR;
					break;
				case EintragGruppe.Z:
					n = _nZ;
					break;
				case EintragGruppe.M:
					n = _nM;
					break;
			}
			try 
			{
                n.Nodes.Add(arg.IDEintrag.ToString(), arg.Text + " (" + PMDS.DB.DBUtil.GetPDX(arg.IDPDX).Klartext + ")");
			}
			catch{}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            this.tv = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(296, 160);
            this.tv.TabIndex = 17;
            // 
            // PDXTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tv);
            this.Name = "PDXTreeView";
            this.Size = new System.Drawing.Size(296, 160);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
