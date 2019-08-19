using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;

using Infragistics.Win.UltraWinTree;
using Infragistics.Win;

using PMDS.BusinessLogic;
using PMDS.Global;



namespace PMDS.GUI
{


	public class UltraTreeTools
	{
		public UltraTreeTools()
		{
			
		}



		//----------------------------------------------------------------------------
		/// <summary>
		/// Key der aktiven Node ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static string ActiveNodeKey(UltraTree tree)
		{
			if (tree.ActiveNode == null)
				return "";

			return tree.ActiveNode.Key;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Node mit Key ermitteln und als aktiv setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool ActivateNodeKey(UltraTree tree, string key)
		{
			UltraTreeNode keyNode = UltraTreeTools.FindNodeKey(tree.Nodes, key);
			if (keyNode == null)
				return false;

			tree.ActiveNode = keyNode;
			keyNode.Selected = true;

			if (tree.Enabled)
				tree.PerformAction(UltraTreeAction.SelectActiveNode, false, false);

			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Node mit Key ermitteln und als aktiv setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public static void ActivateNodeKeyOrFirst(UltraTree tree, string key)
		{
			if (tree.Nodes.Count > 0)
			{
				if (UltraTreeTools.ActivateNodeKey(tree, key))
					return;

				// wenn nicht gefunden 1'te Node selektieren
				//tree.PerformAction(UltraTreeAction.ClearAllSelectedNodes, false, false);
				tree.ActiveNode = tree.Nodes[0];
				tree.PerformAction(UltraTreeAction.SelectActiveNode, false, false);
			}
			else
				tree.ActiveNode = null;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Node mit Key ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static UltraTreeNode FindNodeKey(TreeNodesCollection nodes, string key)
		{
			foreach(UltraTreeNode node in nodes)
			{
				if (node.Key == key)
					return node;

				// nächste Stufe hinabsteigen
				UltraTreeNode child = UltraTreeTools.FindNodeKey(node.Nodes, key);
				if (child != null)
					return child;
			}

			return null;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn im Tree die Eintraggruppe bereits existiert
        /// Rekursiv
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ExistPDxEintragGruppe(UltraTreeNode tn, string key)
        {
            if (tn.Key == key)
                return true;

            if (tn.HasNodes)
            {
                foreach (UltraTreeNode n in tn.Nodes)
                {
                    if (n.Key == key)
                        return true;

                    if (ExistPDxEintragGruppe(n, key))
                        return true;
                }
            }

            return false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// mda: Liefert true wenn im Tree die Eintraggruppe bereits existiert
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ExistPDxEintragGruppe(UltraTree tv, string key)
        {
            foreach (UltraTreeNode tn in tv.Nodes)
            {
                if (tn.Key == key)
                    return true;

                if (ExistPDxEintragGruppe(tn, key))
                    return true;
            }
            return false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// mda: Liefert die richtige Node zue A/PDx kombination egal ob PDx zugeordnet oder nicht
        /// auf basis einer Root Node
        /// </summary>
        //----------------------------------------------------------------------------
        public static UltraTreeNode FindPDxDependedNodeFromNode(Infragistics.Win.UltraWinTree.TreeNodesCollection rootnodes, Guid IDAtiologie, Guid IDPDx)
        {
            ASZMSelectionArgs a = null;
            foreach (UltraTreeNode n in rootnodes)						// oberste Ebene
            {
                if (n.HasNodes)
                {
                    return FindPDxDependedNodeFromNode(n.Nodes, IDAtiologie, IDPDx);
                }
                else
                {
                    if (n.Tag == null)
                        continue;
                    a = (ASZMSelectionArgs)n.Tag;
                    if (a.IDPDX == IDPDx && a.IDEintrag == IDAtiologie)	// gefunden 
                    {
                        return n;
                    }
                }
            }
            throw new Exception("frmSearchASZM2::FindPDxDependedNodeFromNode() - Programmierinkonsistenz: Eine PDxNode konnte nicht gefunden werden");
        }
	}
}
