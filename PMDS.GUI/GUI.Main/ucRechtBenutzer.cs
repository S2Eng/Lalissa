using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using System.Linq;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{

	public class ucRechtBenutzer : QS2.Desktop.ControlManagment.BaseControl,  IReadOnly
	{
        public Guid IDBenutzer;
        private bool							_readonly = false;
		public event EventHandler ValueChanged;
		private dsINTListe.INTListeDataTable	_rechte;

        private Infragistics.Win.UltraWinTree.UltraTree treeRechtBenutzer;
		private System.ComponentModel.Container components = null;

        public PMDS.db.Entities.ERModellPMDSEntities db = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

        public bool IsInitialized = false;
        







        public ucRechtBenutzer()
		{
            //_markers = new GuiMarkers(this);

			InitializeComponent();
		}




        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.db = PMDS.DB.PMDSBusiness.getDBContext();
                    InitRechte();

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRechtBenutzer.initControl: " + ex.ToString());
            }
        }
        private void InitRechte()
		{
			try
			{
                _rechte = Gruppe.AlleRechte();

                this.treeRechtBenutzer.Nodes.Clear();
                dsINTListe.INTListeRow[] arrREchte = (dsINTListe.INTListeRow[])_rechte.Select("", "TEXT asc");
                foreach (dsINTListe.INTListeRow r in arrREchte)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode itm = this.treeRechtBenutzer.Nodes.Add(System.Guid.NewGuid().ToString(), r.TEXT.Trim());
                    itm.Tag = r;
                }
              
            }
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            this.treeRechtBenutzer = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.treeRechtBenutzer)).BeginInit();
            this.SuspendLayout();
            // 
            // treeRechtBenutzer
            // 
            this.treeRechtBenutzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRechtBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeRechtBenutzer.Location = new System.Drawing.Point(0, 0);
            this.treeRechtBenutzer.Name = "treeRechtBenutzer";
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            this.treeRechtBenutzer.Override = _override1;
            this.treeRechtBenutzer.Scrollable = Infragistics.Win.UltraWinTree.Scrollbar.Show;
            this.treeRechtBenutzer.Size = new System.Drawing.Size(352, 248);
            this.treeRechtBenutzer.TabIndex = 1;
            this.treeRechtBenutzer.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.ultraTree1_BeforeCheck);
            // 
            // ucRechtBenutzer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.treeRechtBenutzer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucRechtBenutzer";
            this.Size = new System.Drawing.Size(352, 248);
            ((System.ComponentModel.ISupportInitialize)(this.treeRechtBenutzer)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



		public void loadData()
		{
            this.clearCheckBoxes();
            IQueryable<PMDS.db.Entities.BenutzerRechte> tBenutzerRechte = this.PMDSBusiness1.getBenutzerRechte(this.db, this.IDBenutzer);
            foreach (PMDS.db.Entities.BenutzerRechte rBenutzerRechte in tBenutzerRechte)
            {
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm  in this.treeRechtBenutzer.Nodes)
                {
                    dsINTListe.INTListeRow r = (dsINTListe.INTListeRow )itm.Tag;
                    if (rBenutzerRechte.IDRecht.Equals(r.ID))
                    {
                        itm.CheckedState = CheckState.Checked ;
                    }
                }
            }

		}
        public void clearCheckBoxes()
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm in this.treeRechtBenutzer.Nodes)
            {
                itm.CheckedState = CheckState.Unchecked;
            }
        }

		public void saveData()
		{
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm in this.treeRechtBenutzer.Nodes)
            {
                dsINTListe.INTListeRow r = (dsINTListe.INTListeRow)itm.Tag;
                PMDS.db.Entities.BenutzerRechte rBenutzerRechteExists = this.PMDSBusiness1.getBenutzerRecht(this.db, this.IDBenutzer, r.ID);
                if (itm.CheckedState == CheckState.Checked)
                {
                    if (rBenutzerRechteExists == null)
                    {
                        PMDS.db.Entities.BenutzerRechte rNewBenutzerRechte = new PMDS.db.Entities.BenutzerRechte();
                        rNewBenutzerRechte.ID = System.Guid.NewGuid();
                        rNewBenutzerRechte.IDRecht = r.ID;
                        rNewBenutzerRechte.IDBenutzer = this.IDBenutzer;

                        this.db.BenutzerRechte.Add(rNewBenutzerRechte);
                        this.db.SaveChanges();
                    }
                }
                else
                {
                    if (rBenutzerRechteExists != null)
                    {
                        db.BenutzerRechte.Remove(rBenutzerRechteExists);
                        this.db.SaveChanges();
                    }
                }
            }
            
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);
		}

		#region IMarker Members

		public DataTable DATA
		{
			get	{	return _rechte;	}
		}
        
		#endregion

		#region IReadOnly Members

		public bool ReadOnly
		{
			get
			{
				return _readonly;
			}
			set
			{
				_readonly = value;

			}
		}

		#endregion

        private void ultraTree1_BeforeCheck(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
        {
            if (treeRechtBenutzer.Focused)
            {
                this.OnValueChanged(sender, e);
            }

        }

	}

}
