//----------------------------------------------------------------------------
/// <summary>
///	ucPatientGroup.cs
/// Erstellt am:	09.12.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Data.Patient;

using PMDS.BusinessLogic;
using PMDS.Global;

using Infragistics.Win.UltraWinTree;
using PMDS.Global.db.Patient;
using PMDS.Global.db.ERSystem;
using PMDS.DB;
using PMDS.Global.db.Global;
using System.Linq;

namespace PMDS.GUI
{
    public delegate void GroupDelegate(object sender, PatientGroupSelection args);
    public delegate void klinikChanged(dsKlinik.KlinikRow rKlinik);
    

	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Auswahl der Patienten-Gruppe
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucPatientGroup : QS2.Desktop.ControlManagment.BaseControl
	{
		private bool _bENVAbteilung = false;
        private bool _TreeRefreshed = false;
		
		public event GroupDelegate SelectionChanged;

        private Infragistics.Win.UltraWinTree.UltraTree tree;
        private IContainer components;

        public dsKlinik.KlinikDataTable tKlinikenUser = new dsKlinik.KlinikDataTable();
        public QS2.Desktop.ControlManagment.BaseComboEditor cbKlinik;
        private QS2.Desktop.ControlManagment.BasePanel panelTop;
        private QS2.Desktop.ControlManagment.BasePanel panelTree;
        private ContextMenuStrip contextMenuStripCboKlinik;
        private ToolStripMenuItem klinikenNeuLadenToolStripMenuItem;

        public bool lstKlinikenLoaded = false;
        public bool _allKliniken = false;
        private ToolStripMenuItem alleKlinikenLadenToolStripMenuItem;
        public bool _onlyKlinikenUsr = false;
        public bool _adminModusAlleKliniken = false;

        public bool _lockSelectedKlinik = false;

        public event klinikChanged klinikHasChanged;
        public bool _IsMainHeaderPicker = false;


        private eTypUI _typUI = eTypUI.none;
        public enum eTypUI
        {
            main = 0,
            sub = 1,

            none = 10
        }
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();

        public ucMain mainWindow = null;








		public ucPatientGroup()
		{
			InitializeComponent();
		}

		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPatientGroup));
            this.tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.contextMenuStripCboKlinik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klinikenNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleKlinikenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbKlinik = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.panelTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelTree = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            this.contextMenuStripCboKlinik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            this.tree.Appearance = appearance1;
            this.tree.ContextMenuStrip = this.contextMenuStripCboKlinik;
            this.tree.FullRowSelect = true;
            this.tree.HideSelection = false;
            this.tree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tree.Location = new System.Drawing.Point(4, 3);
            this.tree.Name = "tree";
            this.tree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            _override1.NodeDoubleClickAction = Infragistics.Win.UltraWinTree.NodeDoubleClickAction.None;
            this.tree.Override = _override1;
            this.tree.Size = new System.Drawing.Size(160, 211);
            this.tree.TabIndex = 0;
            this.tree.AfterSelect += new Infragistics.Win.UltraWinTree.AfterNodeSelectEventHandler(this.tree_AfterSelect);
            this.tree.Click += new System.EventHandler(this.tree_Click);
            this.tree.DoubleClick += new System.EventHandler(this.tree_DoubleClick);
            this.tree.Enter += new System.EventHandler(this.tree_Enter);
            this.tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_KeyDown);
            // 
            // contextMenuStripCboKlinik
            // 
            this.contextMenuStripCboKlinik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klinikenNeuLadenToolStripMenuItem,
            this.alleKlinikenLadenToolStripMenuItem});
            this.contextMenuStripCboKlinik.Name = "contextMenuStrip1";
            this.contextMenuStripCboKlinik.Size = new System.Drawing.Size(358, 48);
            // 
            // klinikenNeuLadenToolStripMenuItem
            // 
            this.klinikenNeuLadenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("klinikenNeuLadenToolStripMenuItem.Image")));
            this.klinikenNeuLadenToolStripMenuItem.Name = "klinikenNeuLadenToolStripMenuItem";
            this.klinikenNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(357, 22);
            this.klinikenNeuLadenToolStripMenuItem.Text = "Einrichtungen des angemeldeten Benutzers neu laden";
            this.klinikenNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.klinikenNeuLadenToolStripMenuItem_Click);
            // 
            // alleKlinikenLadenToolStripMenuItem
            // 
            this.alleKlinikenLadenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alleKlinikenLadenToolStripMenuItem.Image")));
            this.alleKlinikenLadenToolStripMenuItem.Name = "alleKlinikenLadenToolStripMenuItem";
            this.alleKlinikenLadenToolStripMenuItem.Size = new System.Drawing.Size(357, 22);
            this.alleKlinikenLadenToolStripMenuItem.Text = "Alle Einrichtungen neu laden";
            this.alleKlinikenLadenToolStripMenuItem.Click += new System.EventHandler(this.alleKlinikenLadenToolStripMenuItem_Click);
            // 
            // cbKlinik
            // 
            this.cbKlinik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKlinik.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbKlinik.ContextMenuStrip = this.contextMenuStripCboKlinik;
            this.cbKlinik.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKlinik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbKlinik.Location = new System.Drawing.Point(4, 3);
            this.cbKlinik.Name = "cbKlinik";
            this.cbKlinik.Size = new System.Drawing.Size(159, 24);
            this.cbKlinik.TabIndex = 117;
            this.cbKlinik.TabStop = false;
            this.cbKlinik.ValueChanged += new System.EventHandler(this.cbKlinik_ValueChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.cbKlinik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(168, 30);
            this.panelTop.TabIndex = 119;
            // 
            // panelTree
            // 
            this.panelTree.BackColor = System.Drawing.Color.White;
            this.panelTree.Controls.Add(this.tree);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree.Location = new System.Drawing.Point(0, 30);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(168, 218);
            this.panelTree.TabIndex = 120;
            // 
            // ucPatientGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelTree);
            this.Controls.Add(this.panelTop);
            this.Name = "ucPatientGroup";
            this.Size = new System.Drawing.Size(168, 248);
            this.Load += new System.EventHandler(this.ucPatientGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            this.contextMenuStripCboKlinik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTree.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Settings Abteilung
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ENVAbteilung
		{
			get	{	return _bENVAbteilung;	}
			set	{	_bENVAbteilung = value;	}
		}

        public bool IsRootSelected
        {
            get
            {                
                if(tree.ActiveNode == null)
                    return false;
                if (tree.ActiveNode.Parent == null)
                    return false;             
                return true;
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI initialisieren und ZusatzGruppen-Listen bef?llen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucPatientGroup_Load(object sender, System.EventArgs e)
		{
			if (DesignMode)
				return;

            if (ENV.adminSecure)
            {
                this.klinikenNeuLadenToolStripMenuItem.Visible = true;
            }
            else
            {
                this.klinikenNeuLadenToolStripMenuItem.Visible = true;
            }

            if (ENV.HasRight(UserRights.AlleEinrichtungen))
            {
                this.alleKlinikenLadenToolStripMenuItem.Visible = true;
            }
            else
            {
                this.alleKlinikenLadenToolStripMenuItem.Visible = false;
            }

            if (!_TreeRefreshed)
                RefreshGUI(ENV.CurrentUserAbteilungen, this.allKliniken, this.onlyKlinikenUsr, true, this._adminModusAlleKliniken);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auswahl neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
        public void RefreshGUI(bool allKliniken, bool onlyKlinikenUsr, bool loadComboKliniken, bool adminModusAlleKliniken)
		{
            RefreshTree(new List<Guid>(), allKliniken, onlyKlinikenUsr, loadComboKliniken, adminModusAlleKliniken);      // leere liste ==> kein Filter
		}

        public void RefreshGUI(List<Guid> Abteilungsfilter, bool allKliniken, bool onlyKlinikenUsr, bool loadComboKliniken, bool adminModusAlleKliniken)
        {
            RefreshTree(Abteilungsfilter, allKliniken, onlyKlinikenUsr, loadComboKliniken, adminModusAlleKliniken);      // mit Filter aufrufen
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auswahl Tree aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
        private void RefreshTree(List<Guid> aIDAbteilungenFilter, bool allKliniken, bool onlyKlinikenUsr, bool loadComboKliniken,
                                    bool adminModusAlleKliniken)         //<20120202>
		{
            this._lockSelectedKlinik = true;
                         
            this._allKliniken = allKliniken;
            this._onlyKlinikenUsr = onlyKlinikenUsr;
            this._adminModusAlleKliniken = adminModusAlleKliniken;

            this.tree.ActiveNode = null;
            this.tree.SelectedNodes.Clear();
			TreeNodesCollection nodes = tree.Nodes;

			string key = UltraTreeTools.ActiveNodeKey(tree);

            if (adminModusAlleKliniken)
            {
                this.panelTop.Visible = false;
            }
            else
            {
                this.panelTop.Visible = true;
            }

            if (this.klinikHasChanged != null)
                this.klinikHasChanged.Invoke(null);

            try
            {
                tree.BeginUpdate();
                tree.Nodes.Clear();

                if (!allKliniken && !onlyKlinikenUsr && !adminModusAlleKliniken)
                {
                    if (loadComboKliniken)
                        this.loadComboKlinikenUsr();

                if (this._IsMainHeaderPicker)
                {
                    foreach (Infragistics.Win.ValueListItem Itm in this.cbKlinik.Items)
                    {
                        if (Itm.DataValue.Equals(ENV.IDKlinik))
                        {
                            this.cbKlinik.SelectedItem = Itm;
                        }
                    }
                }

                dsKlinik.KlinikRow rSelectKlinik = this.getSelKlinik(false);
                if (rSelectKlinik != null)
                    {
                        this.loadKlinik(rSelectKlinik, tree.Nodes, true);
                    }
                }

                else if ((allKliniken && !onlyKlinikenUsr) || adminModusAlleKliniken)
                {
                    if (loadComboKliniken)
                        this.loadComboAllKliniken();

                    using (dsKlinik dsKlinik1 = new dsKlinik())
                    {
                        using (PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik())
                        {
                            DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);
                            foreach (dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
                            {
                                this.loadKlinik(rKlinik, tree.Nodes, false);
                            }
                        }
                    }
                }
                else if (!allKliniken && onlyKlinikenUsr && !adminModusAlleKliniken)
                {
                    if (loadComboKliniken)
                        this.loadComboKlinikenUsr();

                    //this.panelTop.Visible = false;
                    using (PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik())
                    {
                        System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow> lstrBenutzerKlinikDistinct = new System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow>();
                        using (dsBenutzerEinrichtung dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung())
                        {
                            PMDS.DB.Patient.DBBenutzerEinrichtung DBBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung();
                            DBBenutzerEinrichtung1.initControl();

                            // IDKlinik default auslesen
                            DBBenutzerEinrichtung1.getBenutzerEinrichtung(ENV.USERID, dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
                            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in dsBenutzerEinrichtung1.BenutzerEinrichtung)
                            {
                                bool IDKlinikExists = false;
                                foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenutzerKlinik in lstrBenutzerKlinikDistinct)
                                {
                                    if (rBenutzerKlinik.IDEinrichtung.Equals(rBenEinr.IDEinrichtung))
                                        IDKlinikExists = true;
                                }
                                if (!IDKlinikExists)
                                    lstrBenutzerKlinikDistinct.Add(rBenEinr);
                            }

                            // Cbo Heime bef?llen
                            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in lstrBenutzerKlinikDistinct)
                            {
                                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(rBenEinr.IDEinrichtung, true);
                                this.loadKlinik(rKlinik, tree.Nodes, false);
                            }
                        }                            
                    }                        
                }
                    
                if (this.tree.ActiveNode != null)
                {
                    PatientGroupSelection CurrentSelectionFound = (PatientGroupSelection)tree.ActiveNode.Tag;
                    if (this.typUI == eTypUI.main)
                    {
                        ENV.IDKlinik = CurrentSelectionFound.IDKlinik;
                        ENV.setIDBereich = CurrentSelectionFound.Bereich;
                    PMDSBusinessRAM bRAM = new PMDSBusinessRAM();
                    bRAM.loadDataStart(true, true, true, true);
                }
                if (this.klinikHasChanged != null)
                        this.klinikHasChanged.Invoke(this.getSelKlinikRow());
                    this.OnSelectionChanged(this.cbKlinik, CurrentSelectionFound);
                }                  
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                this._lockSelectedKlinik = false;
            }
            finally
            {
                tree.EndUpdate();
                UltraTreeTools.ActivateNodeKeyOrFirst(tree, key);
                this._lockSelectedKlinik = false;
                this. _TreeRefreshed = true;
            }
		}

        private void loadKlinik( dsKlinik.KlinikRow rSelectKlinik, TreeNodesCollection nodes, bool expandNode)         //<20120202>
        {
            try
            {
                List<string> lstSupressChildsOf = new List<string>();

                UltraTreeNode node;
                TreeNodesCollection nodesA;
                node = nodes.Add(rSelectKlinik.ID.ToString(), rSelectKlinik.Bezeichnung.Trim());
                node.Tag = new PatientGroupSelection(rSelectKlinik.Bezeichnung, true, System.Guid.Empty, "", rSelectKlinik.ID, rSelectKlinik.Bezeichnung.Trim(), "", true);
                //node.Override.NodeAppearance.Image = this.imageList1.Images[0];
                node.Override.NodeAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                nodes = node.Nodes;

                using (dsAbteilung dsAbteilung1 = new dsAbteilung())
                {
                    using (PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung())
                    {
                        DBAbteilung1.getAbteilungenByKlinik(rSelectKlinik.ID, dsAbteilung1);
                    }

                    foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                    {
                        if (!rAbt.ID.Equals(System.Guid.Empty))
                        {
                            using (PMDS.DB.DBBenutzer DBBenutzerWork = new PMDS.DB.DBBenutzer())
                            {
                                using (dsBenutzerAbteilung dsBenutzerAbteilungWork = new dsBenutzerAbteilung()) 
                                {
                                    DBBenutzerWork.getAbteilungByUser(dsBenutzerAbteilungWork, ENV.USERID);

                                    if (dsBenutzerAbteilungWork.BenutzerAbteilung.Any(r => r.IDAbteilung == rAbt.ID))
                                    {
                                        node = nodes.Add(System.Guid.NewGuid().ToString(), rAbt.Bezeichnung);      //rAbt.ID.ToString()
                                                                                                                   ////node.Override.NodeAppearance.Image = this.imageList1.Images[1];
                                        node.Tag = new PatientGroupSelection(rAbt.Bezeichnung, true, rAbt.ID, rAbt.Bezeichnung, rSelectKlinik.ID, rSelectKlinik.Bezeichnung.Trim(), "", false);
                                        nodesA = node.Nodes;
                                        if (!rAbt.IsReihenfolgeNull() && rAbt.Reihenfolge > 100 && rAbt.Reihenfolge.ToString().Substring(rAbt.Reihenfolge.ToString().Length - 1) == "1")
                                        {
                                            lstSupressChildsOf.Add(node.FullPath);
                                        }

                                        // Bereiche einh?ngen
                                        foreach (dsBereich.BereichRow br in KlinikBereiche.ByAbteilung(rAbt.ID))
                                        {
                                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                                            {
                                                System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = null;
                                                this.PMDSBusiness1.getRechtBereichUserForAbteilung(br.ID, ENV.USERID, ref tBereichBenutzer, db);

                                                if (tBereichBenutzer.Any(r => r.IDBereich == br.ID))
                                                {
                                                    node = nodesA.Add(System.Guid.NewGuid().ToString(), br.Bezeichnung);
                                                    node.Tag = new PatientGroupSelection(br.Bezeichnung, true, rAbt.ID, br.ID, rAbt.Bezeichnung, br.Bezeichnung, rSelectKlinik.ID, rSelectKlinik.Bezeichnung.Trim(), "", false);
                                                    //node.Override.NodeAppearance.Image = this.imageList1.Images[2];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (expandNode)
                {
                    tree.ExpandAll();                    
                    foreach (UltraTreeNode nodeEinrichtung in tree.Nodes)
                    {
                        foreach (UltraTreeNode nodeAbteilung in nodeEinrichtung.Nodes)
                        {
                            if (lstSupressChildsOf.Where(c => c.Contains(nodeAbteilung.FullPath)).Count() == 1)
                            {
                                nodeAbteilung.CollapseAll();
                            }
                        }
                    }
                }
                else
                    node.CollapseAll();

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
            finally
            {
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn die ID nich in der Liste vorkommt
        /// </summary>
        //----------------------------------------------------------------------------
        private bool IsNotInList(Guid IDAbteilung, List<Guid> aIDAbteilungen)
        {
            if (aIDAbteilungen.Count == 0)
            {
                return false;       //offensichtlich f?r den Klinik-Eintrag
            }

            foreach (Guid g in aIDAbteilungen)
            {
                if (g == IDAbteilung && g != System.Guid.Empty)
                {
                    return false;
                }
            }
            return true;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-?nderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnSelectionChanged(object sender, PatientGroupSelection args)
		{
            if (SelectionChanged != null)
            {
                if (this.typUI == eTypUI.main)
                {
                    ENV.setCurrentIDAbteilung = args.Abteilung;
                    ENV.setCurrentIDBereich = args.Bereich;
                }

                SelectionChanged(sender, args);
            }
				
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue Selektion mitteilen
		/// </summary>
		//----------------------------------------------------------------------------
		private void tree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
		{
            if (tree.Focused)
            {
                PatientGroupSelection CurrentSelectionFound = (PatientGroupSelection)tree.ActiveNode.Tag;
                //if (CurrentSelectionFound.IsKlinik)
                //{
                //    if (!this.PMDSBusiness1.UserHasRechtAufGesamteshaus(Settings.USERID))
                //    {
                //        return;
                //    }
                //}

                if (this.typUI == eTypUI.main)
                {
                    ENV.IDKlinik = CurrentSelectionFound.IDKlinik;
                    ENV.setIDBereich = CurrentSelectionFound.Bereich; 
                }

                if (this.klinikHasChanged != null)
                    this.klinikHasChanged.Invoke(this.getSelKlinikRow());
                OnSelectionChanged(sender, CurrentSelection);
            }
		}

		private void tree_Enter(object sender, System.EventArgs e)
		{
			//OnSelectionChanged(sender, CurrentSelection);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Click event durchschleifen
		/// </summary>
		//----------------------------------------------------------------------------
		private void tree_Click(object sender, System.EventArgs e)
		{
            if (tree.Focused)
            {
                OnClick(e);
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktuelle Selektion mitteilen
		/// </summary>
		//----------------------------------------------------------------------------
		public PatientGroupSelection CurrentSelection
		{
			get	
			{
				if (tree.ActiveNode == null)
					return new PatientGroupSelection("", true, ENV.IDKlinikNoKlinikSelected, "No Institution selected", "", false);

				return (PatientGroupSelection)tree.ActiveNode.Tag;
			}
		}
        public eTypUI typUI
        {
            get
            {
                return this._typUI;
            }
            set
            {
                this._typUI = value;
            }

        }
        public void SetAbteilungBereich(Guid IDAbteilung, Guid IDBereich)
        {
            foreach (UltraTreeNode n in tree.Nodes)
                if (SetAbteilungBereich(n, IDAbteilung, IDBereich))
                    return;
        }

        private bool SetAbteilungBereich(UltraTreeNode node, Guid IDAbteilung, Guid IDBereich)
        {
            PatientGroupSelection sel = (PatientGroupSelection)node.Tag;
            if (sel.Abteilung == IDAbteilung && sel.Bereich == IDBereich)
            {
                tree.ActiveNode = node;
                tree.ActiveNode.Selected = true; //Neu nach 07.03.2008 MDA: ActiveNode markieren
                return true;
            }
            foreach (UltraTreeNode n in node.Nodes)
                if (SetAbteilungBereich(n, IDAbteilung, IDBereich))
                    return true;
            return false;
        }

        public void SetCurrentToRoot()
        {
            if (tree.Nodes.Count > 0)
            {
                tree.ActiveNode = tree.Nodes[0];               
                tree.Nodes[0].Selected = true;             
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abteilung und Bereich setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public void ActivateAbteilungBereich(Guid abteilung, Guid bereich)
		{
            RefreshTree(new List<Guid>(), this._allKliniken, this._onlyKlinikenUsr, true, this._adminModusAlleKliniken);

			// Patient ganz ohne Abteilung?
			if (abteilung == null || abteilung == Guid.Empty)
			{
				if (tree.Nodes.Count > 0)
					tree.ActiveNode = tree.Nodes[0];
				return;
			}

			// Patient nur mit Abteilung, kein Bereich?
			if (bereich == null || bereich == Guid.Empty)
			{
				foreach (UltraTreeNode node in tree.Nodes)
				{
					if ( ((PatientGroupSelection) node.Tag).Abteilung == abteilung )
					{
						tree.ActiveNode = node;
					}
				}
				return;
			}

			// Abteilung und Bereich gegeben
			foreach (UltraTreeNode node in tree.Nodes)
			{
				if (((PatientGroupSelection) node.Tag).Abteilung == abteilung && 
					((PatientGroupSelection) node.Tag).Bereich == bereich         )
				{
					tree.ActiveNode = node;
				}
			}
		}

        private void tree_DoubleClick(object sender, EventArgs e) //Gernot%%
        {

            if (tree.UIElement.LastElementEntered != null) 
            {
                if (tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                    tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    if (tree.Focused)
                    {
                        if ( !PMDS.Global .historie .HistorieOn )
                        OnDoubleClick(e);
                    }
            }             
        }

        private void tree_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        public void loadComboKlinikenUsr()     //<20120202>
        {
            //if (this.lstKlinikenLoaded)
            //    return;

            this.cbKlinik.Items.Clear();
            this.tKlinikenUser.Clear();

            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow> lstrBenutzerKlinikDistinct = new System.Collections.Generic.List<dsBenutzerEinrichtung.BenutzerEinrichtungRow>();
            dsBenutzerEinrichtung dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung();
            PMDS.DB.Patient.DBBenutzerEinrichtung DBBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung();
            DBBenutzerEinrichtung1.initControl();

            // IDKlinik default auslesen
            DBBenutzerEinrichtung1.getBenutzerEinrichtung(ENV.USERID, dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in dsBenutzerEinrichtung1.BenutzerEinrichtung)
            {
                bool IDKlinikExists = false;
                foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenutzerKlinik in lstrBenutzerKlinikDistinct)
                {
                    if (rBenutzerKlinik.IDEinrichtung.Equals(rBenEinr.IDEinrichtung))
                        IDKlinikExists = true;
                }
                if (!IDKlinikExists)
                    lstrBenutzerKlinikDistinct.Add(rBenEinr);
            }

            // Cbo Heime bef?llen
            bool bKlinikSelected = false;
            Infragistics.Win.ValueListItem firstKlinik = null;
            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in lstrBenutzerKlinikDistinct)
            {
                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(rBenEinr.IDEinrichtung, true);
                Infragistics.Win.ValueListItem itemKlinik = this.cbKlinik.Items.Add(rKlinik.ID, rKlinik.Bezeichnung);
                itemKlinik.Tag = rKlinik;

                dsKlinik.KlinikRow rKlinikNew = (dsKlinik.KlinikRow)this.tKlinikenUser.NewRow();
                rKlinikNew.ItemArray = rKlinik.ItemArray;
                this.tKlinikenUser.Rows.Add(rKlinikNew);

                if (rBenEinr.Default)
                {
                    this.cbKlinik.SelectedItem = itemKlinik;
                    //lth klinik changed
                    bKlinikSelected = true;
                }
                if (firstKlinik == null)
                {
                    firstKlinik = itemKlinik;
                }
            }
            if (!bKlinikSelected)
            {
                if (firstKlinik != null)
                {
                    this.cbKlinik.SelectedItem = firstKlinik;
                }
            }

            this.lstKlinikenLoaded = true;
        }
        public  dsKlinik.KlinikRow loadComboAllKliniken()
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                return b.loadComboAllKliniken(this.cbKlinik, this.tKlinikenUser, ref lstKlinikenLoaded, true);
            }
            catch (Exception ex)
            {
                throw new Exception("loadComboAllKliniken: " + ex.ToString ());
            }
        }

        private void cbKlinik_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbKlinik.Focused)
                {
                    if (!this._lockSelectedKlinik)
                    {
                        dsKlinik.KlinikRow rKlinik = this.getSelKlinik(false);
                        if (rKlinik != null)
                        {
                            //if (this.mainWindow != null && this._IsMainPicker)    'lthxy
                            //{
                            //    ((frmMain)this.mainWindow.FRAMEWORK.HEADER).ucHeader1.ucPatientGroupPicker1.ucPatientGroup1.cbKlinik.Value = Settings.IDKlinik;
                            //}
                            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                            {
                                this.RefreshGUI(this._allKliniken, this._onlyKlinikenUsr, false, this._adminModusAlleKliniken);
                                PMDS.DB.PMDSBusinessComm.newCommAsyncToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll, db);
                                ucHeader.bKlinikChanged = true;
                            }
                        }
                    }
                    else
                    {
                        string xy = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public  dsKlinik.KlinikRow getSelKlinik(bool withMsgBox)
        {
            try
            {
                //<20120202>
                if (this.cbKlinik.SelectedItem != null)
                {
                    Infragistics.Win.ValueListItem item = this.cbKlinik.SelectedItem;

                    if (ELGABusiness.ELGALogInInitializedAtStart != null && ELGABusiness.ELGALogInInitializedAtStart.Value)
                    {
                        if (this.mainWindow != null && this.mainWindow.mainWindow != null)
                        {
                            ELGABusiness bELGA = new ELGABusiness();
                            bELGA.LogOutELGA(this.mainWindow.mainWindow.ultraStatusBar1, this.mainWindow.mainWindow.ultraStatusBar1.Panels["statELGA"], true, true, false);
                        }
                    }
                    return ( dsKlinik.KlinikRow)item.Tag;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgew?hlt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return null;
            }
        }
        public  dsKlinik.KlinikRow getSelKlinikRow()
        {
            try
            {
                //<20120202>
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(ENV.IDKlinik, true);
                return rKlinik;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return null;
            }
        }
        private void klinikenNeuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.RefreshGUI(false, false, true, false);
                //this.loadEinrichtungen();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public bool allKliniken
        {
            get
            {
                return this._allKliniken;
            }
            set
            {
                this._allKliniken = value;
            }
        }
        public bool onlyKlinikenUsr
        {
            get
            {
                return this._onlyKlinikenUsr;
            }
            set
            {
                this._onlyKlinikenUsr = value;
            }
        }

        private void alleKlinikenLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.RefreshGUI(true, false, false, true);
                //this.loadEinrichtungen();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public bool IsMainHeaderPicker
        {
            get
            {
                return this._IsMainHeaderPicker;
            }
            set
            {
                this._IsMainHeaderPicker = value;
            }
        }
        public string getText()
        {
            try
            {
                string sSelectedTxt = "";

                sSelectedTxt += this.CurrentSelection.sKlinik.Trim();
                if (this.CurrentSelection.Abteilung != Guid.Empty)
                {
                    sSelectedTxt += "-> ";
                    sSelectedTxt += this.CurrentSelection.SAbteilung.Trim();
                    if (this.CurrentSelection.Bereich != Guid.Empty)
                    {
                        sSelectedTxt += "-> ";
                        sSelectedTxt += this.CurrentSelection.SBereich.Trim();
                    }
                }
                return sSelectedTxt;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
                return "";
            }
        }

	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Parameter f?r Event
	/// </summary>
	//----------------------------------------------------------------------------
	public class PatientGroupSelection
	{
        public PatientGroupSelection(string text, bool bKlinik, Guid IDKlinik, string sKlinik, string xy, bool IsKlinik)
            : this(text, bKlinik, Guid.Empty, "", IDKlinik, sKlinik, xy, IsKlinik)
		{
		}

        public PatientGroupSelection(string text, bool bKlinik, Guid idAbt, string sAbteilung, Guid IDKlinik, string sKlinik, string xy, bool IsKlinik)
            : this(text, bKlinik, idAbt, Guid.Empty, sAbteilung, "", IDKlinik, sKlinik, xy, IsKlinik)
		{
		}

        public PatientGroupSelection(string text, bool bKlinik, Guid idAbt, Guid idBereich, string sAbteilung, string sBereich, Guid IDKlinik, string sKlinik, string xy, bool IsKlinik)
		{
            this._IsKlinik = IsKlinik;
            _Text = text.Trim();
			_Klinik		= bKlinik;
			_Abteilung	= idAbt;
            _Bereich = idBereich;
            _sAbteilung = sAbteilung.Trim();
            _sBereich = sBereich.Trim();
            _IDKlinik = IDKlinik;
            _sKlinik = sKlinik.Trim();
		}

		private string _Text	= "";
		private bool _Klinik	= false;
		private Guid _Abteilung	= Guid.Empty;
		private Guid _Bereich	= Guid.Empty;
        private string _sAbteilung = "";
        private string _sBereich = "";
        private string _sKlinik = "";
        private Guid _IDKlinik = ENV.IDKlinikNoKlinikSelected;
        private bool _IsKlinik = false;





        public bool IsKlinik
        {
            get { return this._IsKlinik; }
            set { this._IsKlinik = value; }
        }
        public string SAbteilung
        {
            get { return _sAbteilung.Trim(); }
            set { _sAbteilung = value.Trim(); }
        }
        public string SBereich
        {
            get { return _sBereich.Trim(); }
            set { _sBereich = value.Trim(); }
        }

		public string Text
		{
            get { return _Text.Trim(); }
		}

		public bool Klinik
		{
			get	{	return _Klinik;	}
            set { _Klinik = value; }
		}

		public Guid Abteilung
		{
			get	{	return _Abteilung;	}
            set { _Abteilung = value; }
		}

		public Guid Bereich
		{
			get	{	return _Bereich;	}
            set { _Bereich = value; }
		}

        public Guid IDKlinik
        {
            //<20120202-2>
            get { return _IDKlinik; }
            set { _IDKlinik = value; }
        }

        public string sKlinik
        {
            get { return this._sKlinik.Trim(); }
            set { _sKlinik = value.Trim(); }
        }

	}
}
