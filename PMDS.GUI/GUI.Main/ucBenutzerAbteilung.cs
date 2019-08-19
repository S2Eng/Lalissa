//----------------------------------------------------------------------------
/// <summary>
///	ucBenutzerAbteilung.cs
/// Erstellt am:	19.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation einer BenutzerAbteilung
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBenutzerAbteilung : QS2.Desktop.ControlManagment.BaseControl 
	{
		private Benutzer _benutzer;
		private bool _valueChangeEnabled = true;
        public dsBenutzerAbteilung dsBenutzerAbteilungUpdate = new dsBenutzerAbteilung();
        public PMDS.DB.DBBenutzer DBBenutzerUpdate = new PMDS.DB.DBBenutzer();

        public bool isLoaded = false;

		public event EventHandler ValueChanged;
        private IContainer components;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBenutzerAbteilungen;
        private Infragistics.Win.UltraWinTree.UltraTree treeAbteilungen;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        
        public  PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();








		public ucBenutzerAbteilung()
		{
			InitializeComponent();
		}
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBenutzerAbteilungen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.treeAbteilungen = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpBenutzerAbteilungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeAbteilungen)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpBenutzerAbteilungen
            // 
            this.grpBenutzerAbteilungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBenutzerAbteilungen.Controls.Add(this.treeAbteilungen);
            this.grpBenutzerAbteilungen.Location = new System.Drawing.Point(8, 8);
            this.grpBenutzerAbteilungen.Name = "grpBenutzerAbteilungen";
            this.grpBenutzerAbteilungen.Size = new System.Drawing.Size(410, 335);
            this.grpBenutzerAbteilungen.TabIndex = 1;
            this.grpBenutzerAbteilungen.TabStop = false;
            this.grpBenutzerAbteilungen.Text = "Benutzer-Abteilungen";
            // 
            // treeAbteilungen
            // 
            this.treeAbteilungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAbteilungen.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treeAbteilungen.Location = new System.Drawing.Point(3, 16);
            this.treeAbteilungen.Name = "treeAbteilungen";
            this.treeAbteilungen.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.treeAbteilungen.Scrollable = Infragistics.Win.UltraWinTree.Scrollbar.Show;
            this.treeAbteilungen.Size = new System.Drawing.Size(404, 316);
            this.treeAbteilungen.TabIndex = 10;
            this.treeAbteilungen.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.treeAbteilungen_AfterCheck);
            this.treeAbteilungen.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.treeAbteilungen_BeforeCheck);
            this.treeAbteilungen.AfterCellActivate += new System.EventHandler(this.treeAbteilungen_AfterCellActivate);
            this.treeAbteilungen.CellValueChanged += new Infragistics.Win.UltraWinTree.CellValueChangedEventHandler(this.treeAbteilungen_CellValueChanged);
            this.treeAbteilungen.Click += new System.EventHandler(this.treeAbteilungen_Click);
            // 
            // ucBenutzerAbteilung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.grpBenutzerAbteilungen);
            this.Name = "ucBenutzerAbteilung";
            this.Size = new System.Drawing.Size(426, 351);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpBenutzerAbteilungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeAbteilungen)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        


		private void InitControl()
		{
			try
			{
                if (this.isLoaded)
                    return;

                this.isLoaded = true;
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}
        public void loadTree()
        {
            this.dsBenutzerAbteilungUpdate.Clear();
            this.treeAbteilungen.Nodes.Clear();
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();

            System.Collections.Generic.List<System.Guid> lstIDKlinikDistinct = new System.Collections.Generic.List<System.Guid>();
            dsBenutzerEinrichtung dsBenutzerEinrichtung1 = new dsBenutzerEinrichtung();
            PMDS.DB.Patient.DBBenutzerEinrichtung DBBenutzerEinrichtung1 = new PMDS.DB.Patient.DBBenutzerEinrichtung();
            DBBenutzerEinrichtung1.initControl();
            DBBenutzerEinrichtung1.getBenutzerEinrichtung(Benutzer.ID, dsBenutzerEinrichtung1, PMDS.DB.Patient.DBBenutzerEinrichtung.eTypSelBenEinrichtung.IDBenutzer);
            foreach (dsBenutzerEinrichtung.BenutzerEinrichtungRow rBenEinr in dsBenutzerEinrichtung1.BenutzerEinrichtung)
            {
                bool IDKlinikExists = false;
                foreach (System.Guid IDKlinik in lstIDKlinikDistinct)
                {
                    if (IDKlinik.Equals(rBenEinr.IDEinrichtung))
                        IDKlinikExists = true;
                }
                if (!IDKlinikExists)
                    lstIDKlinikDistinct.Add(rBenEinr.IDEinrichtung);
            }

            foreach (System.Guid IDKlinik in lstIDKlinikDistinct)
            {
                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(IDKlinik, true);
                Infragistics.Win.UltraWinTree.UltraTreeNode nodTreeKlink = this.treeAbteilungen.Nodes.Add(System.Guid.NewGuid().ToString(), rKlinik.Bezeichnung);
                nodTreeKlink.Tag = rKlinik;
                nodTreeKlink.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Default;
              
                dsAbteilung dsAbteilung1 = new dsAbteilung();
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode nodTreeAbt = nodTreeKlink.Nodes.Add(System.Guid.NewGuid().ToString(), rAbt.Bezeichnung);
                    nodTreeAbt.Tag = rAbt;
                    nodTreeAbt.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                    nodTreeAbt.CheckedState = CheckState.Unchecked;
                    
                    this.DBBenutzerUpdate.getAbteilungByUser(this.dsBenutzerAbteilungUpdate, Benutzer.ID);
                    foreach (dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr in this.dsBenutzerAbteilungUpdate.BenutzerAbteilung)
                    {
                        if (rAbtUsr.IDAbteilung.Equals(rAbt.ID))
                        {
                            nodTreeAbt.CheckedState = CheckState.Checked;
                        }
                    }
                    nodTreeAbt.ExpandAll();
        
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Bereich> tBereichForAbteilung = null;
                        this.PMDSBusiness1.getAllBereichForAbteilung(rAbt.ID, ref tBereichForAbteilung, db);
                        foreach (PMDS.db.Entities.Bereich rBereich in tBereichForAbteilung)
                        {
                            Infragistics.Win.UltraWinTree.UltraTreeNode nodTreeBereich = nodTreeAbt.Nodes.Add(System.Guid.NewGuid().ToString(), rBereich.Bezeichnung);
                            nodTreeBereich.Tag = rBereich;
                            nodTreeBereich.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            nodTreeBereich.CheckedState = CheckState.Unchecked;

                            System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = null;
                            this.PMDSBusiness1.getRechtBereichUserForAbteilung(rBereich.ID, this.Benutzer.ID ,  ref tBereichBenutzer, db);
                            foreach (PMDS.db.Entities.BereichBenutzer rBereichBenutzer in tBereichBenutzer) 
                            {
                                if (rBereichBenutzer.IDBereich.Equals(rBereich.ID) && nodTreeAbt.CheckedState == CheckState.Checked)
                                {
                                    nodTreeBereich.CheckedState = CheckState.Checked;
                                }
                                else
                                {
                                    nodTreeBereich.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                    }
                }
                nodTreeKlink.ExpandAll();
            }
        }
        
		public Benutzer Benutzer
		{
			get	
			{	
				return _benutzer;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Benutzer");

				_valueChangeEnabled = false;
				_benutzer = value;
                this.InitControl();
                this.loadTree();
				_valueChangeEnabled = true;
			}
		}

		public void saveData()
		{
            PMDS.DB.DBBenutzer DBBenutzer1 = new PMDS.DB.DBBenutzer();
            dsAbteilung dsAbteilung1 = new dsAbteilung();
            DBBenutzer1.getAbteilungByUser(this.dsBenutzerAbteilungUpdate, Benutzer.ID);

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodKlinik in this.treeAbteilungen.Nodes)
            {
                dsKlinik.KlinikRow rKlinik = (dsKlinik.KlinikRow)nodKlinik.Tag;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodAbt in nodKlinik.Nodes)
                {
                    dsAbteilung.AbteilungRow rAbt = (dsAbteilung.AbteilungRow)nodAbt.Tag;
                    if (nodAbt.CheckedState == CheckState.Checked)
                    {
                        bool bExists = false;
                        this.checkIfAbtExistsInDsForSave(rAbt.ID, ref bExists);
                        if (!bExists)
                        {
                            dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr = (dsBenutzerAbteilung.BenutzerAbteilungRow)this.dsBenutzerAbteilungUpdate.BenutzerAbteilung.NewRow();
                            rAbtUsr.IDBenutzer = Benutzer.ID;
                            rAbtUsr.IDAbteilung = rAbt.ID;
                            this.dsBenutzerAbteilungUpdate.BenutzerAbteilung.Rows.Add(rAbtUsr);
                            nodAbt.CheckedState = CheckState.Checked;
                        }
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodBereich in nodAbt.Nodes)
                        {
                            PMDS.db.Entities.Bereich rBereich = (PMDS.db.Entities.Bereich)nodBereich.Tag;
                            if (nodBereich.CheckedState == CheckState.Checked)
                            {
                                this.PMDSBusiness1.SaveBereicheZuAbteilung(rBereich.ID, Benutzer.ID);
                            }
                            else if (nodBereich.CheckedState == CheckState.Unchecked)
                            {
                                this.PMDSBusiness1.deleteZuordnungBereich(rBereich.ID, Benutzer.ID);
                            }
                            else
                                throw new Exception("Error ucBenutzerAbteilung.UpdateDATA: nodBereich.CheckedState=Indeterminate not allowed!");
                        }
                    }
                    else if (nodAbt.CheckedState == CheckState.Unchecked)
                    {
                        bool bExists = false;
                        dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr = this.checkIfAbtExistsInDsForSave(rAbt.ID, ref bExists);
                        if (bExists)
                        {
                            rAbtUsr.Delete();
                            nodAbt.CheckedState = CheckState.Unchecked;
                        }
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodBereich in nodAbt.Nodes)
                        {
                            PMDS.db.Entities.Bereich rBereich = (PMDS.db.Entities.Bereich)nodBereich.Tag;
                            this.PMDSBusiness1.deleteZuordnungBereich(rBereich.ID, Benutzer.ID);
                        }
                    }
                    else
                        throw new Exception("Error ucBenutzerAbteilung.UpdateDATA: nodAbt.CheckedState=Indeterminate not allowed!");

                }
            }

            this.DBBenutzerUpdate.daBenutzerAbteilungByBenutzer.Update(this.dsBenutzerAbteilungUpdate.BenutzerAbteilung);
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}

        private void treeAbteilungen_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            try
            {
                if (this.treeAbteilungen.Focused)
                {
                    this.SelectSubNode(e.TreeNode);
                    OnValueChanged(sender, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void treeAbteilungen_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void treeAbteilungen_CellValueChanged(object sender, Infragistics.Win.UltraWinTree.CellValueChangedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        private void treeAbteilungen_AfterCellActivate(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void treeAbteilungen_BeforeCheck(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
        {
            try
            {
                //if (!this.treeAbteilungen.Focused)
                //    return;

                //if (e.TreeNode.Index == 1)
                //{
                //    PMDS.Data.Patient.dsAbteilung.AbteilungRow rAbt = (PMDS.Data.Patient.dsAbteilung.AbteilungRow)e.TreeNode.Tag;
                //    if (e.TreeNode.CheckedState == CheckState.Checked)
                //    {
                //        bool bExists = false;
                //        this.checkIfAbtExistsInDsForSave(rAbt.ID, ref bExists);
                //        if (!bExists)
                //        {
                //            PMDS.Data.Global.dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr = (PMDS.Data.Global.dsBenutzerAbteilung.BenutzerAbteilungRow)this.dsBenutzerAbteilungUpdate.BenutzerAbteilung.NewRow();
                       

                //            this.dsBenutzerAbteilungUpdate.BenutzerAbteilung.Rows.Add(rAbtUsr);
                //        }
                //    }
                //    else if (e.TreeNode.CheckedState == CheckState.Unchecked)
                //    {
                //        bool bExists = false;
                //        PMDS.Data.Global.dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr =  this.checkIfAbtExistsInDsForSave(rAbt.ID, ref bExists);
                //        if (bExists)
                //        {
                //            rAbtUsr.Delete();
                //            //e.TreeNode.Remove();
                //        }
                //    }
                //    else
                //        throw new Exception("Error ucBenutzerAbteilung.treeAbteilungen_BeforeCheck: nodAbt.CheckedState=Indeterminate not allowed!");
                //}
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        public dsBenutzerAbteilung.BenutzerAbteilungRow checkIfAbtExistsInDsForSave(System.Guid IDAbteilung, ref bool bExists)
        {
            try
            {
                foreach (dsBenutzerAbteilung.BenutzerAbteilungRow rAbtUsr in this.dsBenutzerAbteilungUpdate.BenutzerAbteilung)
                {
                    if (rAbtUsr.RowState != DataRowState.Deleted)
                    {
                        if (rAbtUsr.IDAbteilung.Equals(IDAbteilung))
                        {
                            bExists = true;
                            return rAbtUsr;
                        }
                        else
                        {
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return null;
            }
        }

        public void SelectSubNode(Infragistics.Win.UltraWinTree.UltraTreeNode  nodMain)
        {
            try
            {
                if (nodMain != null)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nod in nodMain.Nodes)
                    {
                        nod.CheckedState = nodMain.CheckedState;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerAbteilung.SelectSubNode: " + ex.ToString());
            }
        }


	}
}
