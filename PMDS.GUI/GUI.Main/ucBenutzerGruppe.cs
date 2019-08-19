//----------------------------------------------------------------------------
/// <summary>
///	ucBenutzerGruppe.cs
/// Erstellt am:	15.10.2004
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

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Manipulation eines BenutzerGruppe
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBenutzerGruppe : QS2.Desktop.ControlManagment.BaseControl, IUCBase, IMarker
	{
		private Benutzer _benutzer;
		private bool _valueChangeEnabled = true;
		private GuiMarkers	_markers;
		public event EventHandler ValueChanged;
		private dsGUIDListe.IDListeDataTable _gruppen;
        private Gruppe[] _grpObj;
        private IContainer components;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpResultierendeRechte;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBenutzerGruppen;
		private System.Windows.Forms.CheckedListBox chkGruppe;
        private ucRecht ucRechteGruppe;
        private System.Windows.Forms.ErrorProvider errorProvider1;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucBenutzerGruppe()
		{
			_markers = new GuiMarkers(this);

			InitializeComponent();
			InitGruppen();
			New();
			RequiredFields();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppen-Listen befüllen.
		/// </summary>
		//----------------------------------------------------------------------------
		public void InitGruppen()
		{
			try
			{
				_grpObj = new Gruppe[0];
				_gruppen = Gruppe.All();

				ArrayList al = new ArrayList();
				chkGruppe.Items.Clear();
				foreach(dsGUIDListe.IDListeRow r in _gruppen)
				{
					chkGruppe.Items.Add(r.TEXT);
					al.Add(new Gruppe(r.ID));
				}
				_grpObj = (Gruppe[])al.ToArray(typeof(Gruppe));
			}
			catch(Exception ex)
			{
				_gruppen = null;
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
            this.grpResultierendeRechte = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucRechteGruppe = new PMDS.GUI.ucRecht();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBenutzerGruppen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.chkGruppe = new System.Windows.Forms.CheckedListBox();
            this.grpResultierendeRechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpBenutzerGruppen.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResultierendeRechte
            // 
            this.grpResultierendeRechte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResultierendeRechte.Controls.Add(this.ucRechteGruppe);
            this.grpResultierendeRechte.Location = new System.Drawing.Point(381, 9);
            this.grpResultierendeRechte.Name = "grpResultierendeRechte";
            this.grpResultierendeRechte.Size = new System.Drawing.Size(317, 490);
            this.grpResultierendeRechte.TabIndex = 1;
            this.grpResultierendeRechte.TabStop = false;
            this.grpResultierendeRechte.Text = "Resultierende Rechte";
            // 
            // ucRechteGruppe
            // 
            this.ucRechteGruppe.AutoScroll = true;
            this.ucRechteGruppe.AutoSize = true;
            this.ucRechteGruppe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRechteGruppe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucRechteGruppe.ForeColor = System.Drawing.Color.Gray;
            this.ucRechteGruppe.Location = new System.Drawing.Point(3, 19);
            this.ucRechteGruppe.Margin = new System.Windows.Forms.Padding(5);
            this.ucRechteGruppe.Name = "ucRechteGruppe";
            this.ucRechteGruppe.ReadOnly = true;
            this.ucRechteGruppe.Size = new System.Drawing.Size(311, 468);
            this.ucRechteGruppe.TabIndex = 208;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpBenutzerGruppen
            // 
            this.grpBenutzerGruppen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBenutzerGruppen.Controls.Add(this.chkGruppe);
            this.grpBenutzerGruppen.Location = new System.Drawing.Point(8, 8);
            this.grpBenutzerGruppen.Name = "grpBenutzerGruppen";
            this.grpBenutzerGruppen.Size = new System.Drawing.Size(367, 490);
            this.grpBenutzerGruppen.TabIndex = 0;
            this.grpBenutzerGruppen.TabStop = false;
            this.grpBenutzerGruppen.Text = "Benutzer-Gruppen";
            // 
            // chkGruppe
            // 
            this.chkGruppe.CheckOnClick = true;
            this.chkGruppe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGruppe.IntegralHeight = false;
            this.chkGruppe.Location = new System.Drawing.Point(3, 19);
            this.chkGruppe.Name = "chkGruppe";
            this.chkGruppe.Size = new System.Drawing.Size(361, 468);
            this.chkGruppe.TabIndex = 0;
            this.chkGruppe.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkGruppe_ItemCheck);
            // 
            // ucBenutzerGruppe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.grpResultierendeRechte);
            this.Controls.Add(this.grpBenutzerGruppen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ucBenutzerGruppe";
            this.Size = new System.Drawing.Size(710, 506);
            this.grpResultierendeRechte.ResumeLayout(false);
            this.grpResultierendeRechte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpBenutzerGruppen.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppe setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
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
				UpdateGUI();
				_valueChangeEnabled = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Rechte GUI aktualisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void UpdateRechte()
		{
            this.ucRechteGruppe.ReadOnly = true;
            this.ucRechteGruppe.clearCheckBoxes();
			for(int i=0; i<chkGruppe.Items.Count; i++)
			{
				if (chkGruppe.GetItemChecked(i))
                    this.ucRechteGruppe.SetGruppe(_grpObj[i], false);
			}
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateGUI()
		{
			_markers.ClearMarkers();
			_markers.SetMarkers();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			_markers.GetMarkersxy();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element
		/// </summary>
		//----------------------------------------------------------------------------
		public bool New()
		{
			Benutzer = new Benutzer();
			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(object id)
		{
			Benutzer obj = new Benutzer((Guid)id);
			Benutzer = obj;
            //this.ucresdf.IDPatient = id;

        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read()
		{
			Benutzer.Read();
			Benutzer = Benutzer;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten schreiben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
			Benutzer.Write();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten löschen
		/// </summary>
		//----------------------------------------------------------------------------
		public void Delete()
		{
			Benutzer.Delete();
			New();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (_valueChangeEnabled && (ValueChanged != null))
				ValueChanged(sender, args);
		}
        public void clearCheckBoxes()
        {
            int iCounter = 0;
            foreach (string itm in this.chkGruppe.Items)
            {
                this.chkGruppe.SetItemCheckState(iCounter, CheckState.Unchecked);
                iCounter += 1;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs im Grid signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private bool _bItemCheck = false;
		private void chkGruppe_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			// WORKAROUND START
			// neuen Status setzten
			if (_bItemCheck)
				return;
			_bItemCheck = true;
			chkGruppe.SetItemCheckState(e.Index, e.NewValue);
			_bItemCheck = false;
			// WORKAROUND END
			
			OnValueChanged(sender, EventArgs.Empty);
			UpdateRechte();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			// KEINE Felder benötigt
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			// KEINE Felder zum validieren
			return true;
		}

		#region IUCBase Members

		DataTable IUCBase.All()
		{
			return Benutzer.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return Benutzer;					}
			set	{	Benutzer = (Benutzer)value;	}
		}

		#endregion

		#region IMarker Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// Marker Control
		/// </summary>
		//----------------------------------------------------------------------------
		public CheckedListBox Control
		{
			get	{	return chkGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Marker Daten
		/// </summary>
		//----------------------------------------------------------------------------
		public DataTable DATA
		{
			get	{	return _gruppen;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Element ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public DataRow Find(DataRow r)
		{
			if (Benutzer == null)
				return null;

			dsGUIDListe.IDListeRow r2 = (dsGUIDListe.IDListeRow)r;
			return Benutzer.BenutzerGruppe.FindByIDBenutzerIDGruppe(Benutzer.ID, r2.ID);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neues Element erzeugen
		/// </summary>
		//----------------------------------------------------------------------------
		public void NewItem(DataRow r)
		{
			dsGUIDListe.IDListeRow r2 = (dsGUIDListe.IDListeRow)r;
			Benutzer.AddGruppe(r2.ID);
		}

		#endregion
	}
}

