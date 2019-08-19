//----------------------------------------------------------------------------
/// <summary>
///	MassnahmenCombo.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

using Infragistics.Win.UltraWinEditors;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Massnahmen-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class QuickMeldungCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{

		private QuickMeldungManager						_manager = new QuickMeldungManager();
		private dsQuickMeldung.QuickMeldungDataTable	_dt;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public QuickMeldungCombo()
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
		public void RefreshList(Guid IDAbteilung)
		{
			RefreshList(Guid.Empty, IDAbteilung);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen und auf eine bestimmte ID setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshList(Guid IDToSet, Guid IDAbteilung)
		{
			this.Items.Clear();

			try
			{
				_dt = _manager.ReadAllAbteilung(IDAbteilung);

				foreach(dsQuickMeldung.QuickMeldungRow r in _dt)
					this.Items.Add(r.ID, r.Bezeichnung);
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
