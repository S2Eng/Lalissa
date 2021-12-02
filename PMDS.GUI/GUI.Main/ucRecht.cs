//----------------------------------------------------------------------------
/// <summary>
///	ucRecht.cs
/// Erstellt am:	14.10.2004
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
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation eines GruppenRecht
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucRecht : QS2.Desktop.ControlManagment.BaseControl,  IReadOnly
	{
		public event EventHandler ValueChanged;

		public bool ReadOnly { get; set; }
		private dsINTListe.INTListeDataTable _rechte;
        private Gruppe _Gruppe;
        private Infragistics.Win.UltraWinTree.UltraTree treeRecht;
		private System.ComponentModel.Container components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucRecht()
		{
            //_markers = new GuiMarkers(this);

			InitializeComponent();
			InitRechte();
			//_binit = false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Rechte-Listen befüllen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void InitRechte()
		{
			try
			{
				_rechte = Gruppe.AlleRechte();

				this.treeRecht.Nodes.Clear(); 
                dsINTListe.INTListeRow[] arrREchte = (dsINTListe.INTListeRow[])_rechte.Select("", "TEXT asc");
                foreach (dsINTListe.INTListeRow r in arrREchte)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode itm = this.treeRecht.Nodes.Add(System.Guid.NewGuid().ToString(), r.TEXT.Trim());
                    itm.Tag = r;
                }					
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
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
                if (_rechte != null) _rechte.Dispose();
                if (treeRecht != null) treeRecht.Dispose();

                if (components != null)
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
            this.treeRecht = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.treeRecht)).BeginInit();
            this.SuspendLayout();
            // 
            // treeRecht
            // 
            this.treeRecht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRecht.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeRecht.Location = new System.Drawing.Point(0, 0);
            this.treeRecht.Name = "treeRecht";
            _override1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            this.treeRecht.Override = _override1;
            this.treeRecht.Scrollable = Infragistics.Win.UltraWinTree.Scrollbar.Show;
            this.treeRecht.Size = new System.Drawing.Size(352, 248);
            this.treeRecht.TabIndex = 1;
            this.treeRecht.BeforeCheck += new Infragistics.Win.UltraWinTree.BeforeCheckEventHandler(this.ultraTree1_BeforeCheck);
            // 
            // ucRecht
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.treeRecht);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucRecht";
            this.Size = new System.Drawing.Size(352, 248);
            ((System.ComponentModel.ISupportInitialize)(this.treeRecht)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

 

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppen Rechte -> GUI
		/// </summary>
		//----------------------------------------------------------------------------
		public void SetGruppe(Gruppe grp, bool ClearChecked)
		{
            //_binit = true;

            if (ClearChecked)
                this.clearCheckBoxes();

			_Gruppe = grp;
            foreach (dsGruppenRecht.GruppenRechtRow rGruppeRecht in this._Gruppe.GruppenRechte)
            {
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm  in this.treeRecht.Nodes)
                {
                    dsINTListe.INTListeRow r = (dsINTListe.INTListeRow )itm.Tag;
                    if (rGruppeRecht.IDRecht.Equals(r.ID))
                    {
                        itm.CheckedState = CheckState.Checked ;
                    }
                }
            }
			//_binit = false;
		}
        public void clearCheckBoxes()
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm in this.treeRecht.Nodes)
            {
                itm.CheckedState = CheckState.Unchecked;
            }
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI -> Gruppen Rechte 
		/// </summary>
		//----------------------------------------------------------------------------
		public void GetGruppe(Gruppe grp)
		{
			_Gruppe = grp;
            //_markers.GetMarkers();

            ArrayList lstToAdd = new ArrayList();
            ArrayList lstToDelete = new ArrayList();
           
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode itm in this.treeRecht.Nodes)
            {
                dsINTListe.INTListeRow rFound = (dsINTListe.INTListeRow)itm.Tag;
                if (itm.CheckedState == CheckState.Checked)
                {
                    bool bFoundInTable = false;
                    dsGruppenRecht.GruppenRechtRow[] arrExists = (dsGruppenRecht.GruppenRechtRow[])this._Gruppe.GruppenRechte.Select("IDRecht='" + rFound.ID.ToString() + "'", "");
                    if (arrExists.Length == 1)
                    {
                        bFoundInTable = true;
                    }
                    if (arrExists.Length > 1)
                    {
                        throw new Exception("GetGruppe: (arrExists.Length == 0) for IDRecht'" + rFound.ID.ToString() + "'");
                    }

                    bool bFoundInList = false;
                    foreach (int IDRechtInList in lstToAdd)
                    {
                        if (IDRechtInList.Equals(rFound.ID))
                        {
                            bFoundInList = true;
                        }
                    }
                    if (!bFoundInList && !bFoundInTable)
                    {
                        lstToAdd.Add(rFound.ID);
                    }
                }
                else if (itm.CheckedState == CheckState.Unchecked)
                {
                    dsGruppenRecht.GruppenRechtRow[] arrExists = (dsGruppenRecht.GruppenRechtRow[])this._Gruppe.GruppenRechte.Select("IDRecht='" + rFound.ID.ToString() + "'", "");
                    if (arrExists.Length == 1)
                    {
                        dsGruppenRecht.GruppenRechtRow rGruppeRecht = arrExists[0];
                        lstToDelete.Add(rGruppeRecht);
                    }
                    if (arrExists.Length > 1)
                    {
                        throw new Exception("GetGruppe: (arrExists.Length == 0) for IDRecht'" + rFound.ID.ToString() + "'");
                    }
                }
            }
            foreach (int IDRecht in lstToAdd)
            {
               dsGruppenRecht.GruppenRechtRow rNewGruppeRecht = (dsGruppenRecht.GruppenRechtRow)this._Gruppe.GruppenRechte.NewRow();
                rNewGruppeRecht.IDRecht = IDRecht;
                rNewGruppeRecht.IDGruppe = grp.ID;
                this._Gruppe.GruppenRechte.Rows.Add(rNewGruppeRecht);
            }
            foreach (dsGruppenRecht.GruppenRechtRow rGruppeRecht in lstToDelete)
            {
                rGruppeRecht.Delete();
            }
            //this._Gruppe.GruppenRechte.AcceptChanges();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);
		}

		#region IMarker Members

 
		//----------------------------------------------------------------------------
		/// <summary>
		/// Marker Daten
		/// </summary>
		//----------------------------------------------------------------------------
		public DataTable DATA
		{
			get	{	return _rechte;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Element ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public DataRow Find(DataRow r)
		{
			if (_Gruppe == null)
				return null;

			dsINTListe.INTListeRow r2 = (dsINTListe.INTListeRow)r;
			return _Gruppe.GruppenRechte.FindByIDGruppeIDRecht(_Gruppe.ID, r2.ID);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element erzeugen
		/// </summary>
		//----------------------------------------------------------------------------
		public void NewItem(DataRow r)
		{
			dsINTListe.INTListeRow r2 = (dsINTListe.INTListeRow)r;
			_Gruppe.AddRecht(r2.ID);
		}

		#endregion

        private void ultraTree1_BeforeCheck(object sender, Infragistics.Win.UltraWinTree.BeforeCheckEventArgs e)
        {
            if (treeRecht.Focused)
            {
                if (this.ReadOnly)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.OnValueChanged(sender, e);
                } 
            }
        }
	}
}
