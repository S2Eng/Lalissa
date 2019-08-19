using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global.db.Patient;



namespace PMDS.GUI.BaseControls
{

	public class DienstZeitenCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{

		private DienstZeitenManager						_manager = new DienstZeitenManager();
		private dsDienstZeiten.DienstzeitenDataTable	_dt;




		public DienstZeitenCombo()
		{
			if (ENV.AppRunning)
			{
				InitializeComponent();
			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("search");
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MassnahmenCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// MassnahmenCombo
			// 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
			appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
			editorButton1.Appearance = appearance1;
			editorButton1.Key = "search";
			this.ButtonsRight.Add(editorButton1);
			this.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.MassnahmenCombo_EditorButtonClick);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshList(Guid IDAbteilung, bool bAbteilungOnly, bool doVerwendenIn)
		{
			RefreshList(Guid.Empty, IDAbteilung, bAbteilungOnly, doVerwendenIn);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen und auf eine bestimmte ID setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshList(Guid IDToSet, Guid IDAbteilung, bool bAbteilungOnly, bool doVerwendenIn)
		{
			this.Items.Clear();

			try
			{
				if(bAbteilungOnly)
					_dt = _manager.ReadAllAbteilung(IDAbteilung);
				else
					_dt = _manager.ReadAll(IDAbteilung);

				foreach(dsDienstZeiten.DienstzeitenRow r in _dt)
				{
                    if (doVerwendenIn)
                    {
                        if (r.VerwendenIn.Trim() != "NA" && (r.VerwendenIn.Trim().Equals(("")) || r.VerwendenIn.Trim().ToLower().Equals(("I").Trim().ToLower()) || r.VerwendenIn.Trim().ToLower().Equals(("IM").Trim().ToLower())))
                        {
                            ValueListItem item = this.Items.Add(r.ID, r.Bezeichnung);
                            item.Tag = r;
                        }
                    }
                    else
                    {
                        ValueListItem item = this.Items.Add(r.ID, r.Bezeichnung);
                        item.Tag = r;
                    }

				}

				if(IDToSet != Guid.Empty)
					ID = IDToSet;
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert von der Dienstzeit (ACHTUNG: nur die Zeit auswerten)
		/// </summary>
		//----------------------------------------------------------------------------
		public DateTime VON 
		{
			get 
			{
				if(this.Value == null || this.SelectedItem == null)
					return new DateTime(1900,1,1,8,0,0);

				dsDienstZeiten.DienstzeitenRow r = (dsDienstZeiten.DienstzeitenRow)SelectedItem.Tag;
				return r.Von;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert bis der Dienstzeit (ACHTUNG: nur die Zeit auswerten)
		/// </summary>
		//----------------------------------------------------------------------------
		public DateTime BIS
		{
			get 
			{
				if(this.Value == null || this.SelectedItem == null)
					return new DateTime(1900,1,1,8,0,0);

				dsDienstZeiten.DienstzeitenRow r = (dsDienstZeiten.DienstzeitenRow)SelectedItem.Tag;
				return r.Bis;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ResourceString für Anzeigetext
		/// </summary>
		//----------------------------------------------------------------------------
		public string DISPLAY_TEXT 
		{
			set {_DisplayText = value;}
			get {return _DisplayText;}
		}
		private string _DisplayText = "";

		//----------------------------------------------------------------------------
		/// <summary>
		/// ID ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid ID
		{
			get	
			{
				if (Value == null)
					return Guid.Empty;
				else
					return (Guid)Value;
			}
			set	
			{
				if (value == Guid.Empty)
					Value = null;
				else
					Value = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// search Fenster öffnen
		/// </summary>
		//----------------------------------------------------------------------------
		private void MassnahmenCombo_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
			if (e.Button.Key == "search")
			{
				frmPicker picker = new frmPicker(_dt, "Bezeichnung", "ID", -1, false);
				picker.Text = DISPLAY_TEXT;
				if (picker.ShowDialog() == DialogResult.OK)
					ID = (Guid)picker.Value;
			}
		}
	}
}
