//----------------------------------------------------------------------------
/// <summary>
///	EngineVerwaltung.cs
/// Erstellt am:	04.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

using PMDS.GUI;
using PMDS.Global;

namespace PMDS.GUI.Engines
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Engine für generelle Verwaltungsoperation
	/// </summary>
	//----------------------------------------------------------------------------
	public class EngineVerwaltung
	{
		public event EventHandler AfterNew;

		private bool				_dirty		= false;

		private EngineSelector		_select		= null;
		public IUCBase				_details	= null;
		private ucButton			_add		= null;
		private ucButton			_del		= null;
		private ucButton			_undo		= null;
		private ucButton			_save		= null;
		private UserControl			_ctrl		= null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineVerwaltung(Control sel, UserControl details,
			ucButton add, ucButton del, ucButton undo, ucButton save)
		{
			if (details == null)
				throw new ArgumentNullException("details");

			_select = EngineType.EngineFor(sel);
			_ctrl	= details;
			_details= (IUCBase)details;
			_add	= add;
			_del	= del;
			_undo	= undo;
			_save	= save;

			InitEngine();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Engine initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void InitEngine()
		{
			// INIT Buttons
			if (_add != null) _add.Click += new System.EventHandler(btnAdd_Click);
			if (_del != null) _del.Click += new System.EventHandler(btnDel_Click);
			if (_undo!= null) _undo.Click += new System.EventHandler(btnUndo_Click);
			if (_save!= null) _save.Click += new System.EventHandler(btnSave_Click);

			// INIT Selektor
			_select.InitSelector();
			_select.ValueChanged += new System.EventHandler(Selector_ValueChanged);

			// INIT Details
			_details.ValueChanged += new System.EventHandler(ucDetails_ValueChanged);
			LoadWith(null);
			IsEntryDirty = false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Alle Einträge lesen und Eintrag wählen
		/// </summary>
		//----------------------------------------------------------------------------
		public  void LoadWith(object id)
		{
			_select.DataSource = _details.All();
			_select.Value = id;

			SetCurrent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Buttons en-/disable je nachdem Daten geändert wurde.
		/// </summary>
		//----------------------------------------------------------------------------
		public bool IsEntryDirty
		{
			get	{	return _dirty;	}

			set
			{
				_dirty = value;

				if (_add != null)	_add.Enabled	= !value;
				if (_save != null)	_save.Enabled	= value;

				bool bItems = (_select.Count > 0);
				_select.Enabled = !value && bItems;

				if (_undo != null)	_undo.Enabled	= value; // && bItems;
				if (_del != null)	_del.Enabled	= !value && bItems;

				// sollte nur ReadOnly sein (wenn keine Buttons sind)
				bool bButtons = false;
				bButtons |= ((_add  != null) && _add.Visible);
				bButtons |= ((_save != null) && _save.Visible);
				bButtons |= ((_undo != null) && _undo.Visible);
				bButtons |= ((_del  != null) && _del.Visible);

				_ctrl.Enabled = (value || bItems);
							
				// sollt nur ReadOnly sein
				if (_ctrl is IReadOnly)
					((IReadOnly)_ctrl).ReadOnly = !bButtons;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählten Element im Detail darstellen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void Selector_ValueChanged(object sender, System.EventArgs e)
		{
			SetCurrent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählten Eintrag neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public void SetCurrent()
		{
			if (_select.Value != null)
				_details.Read(_select.Value);

			IsEntryDirty = false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (_details.New())
			{
				OnAfterNew(_details, null);
				IsEntryDirty = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnAfterNew(object sender, EventArgs args)
		{
			if (AfterNew != null)
				AfterNew(sender, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählten Eintrag lesen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnUndo_Click(object sender, System.EventArgs e)
		{
			SetCurrent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählten Eintrag speichern.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (SaveDetails())
				LoadWith(_details.Object.ROW["ID"]);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Eintrag speichern.
		/// </summary>
		//----------------------------------------------------------------------------
		private bool SaveDetails()
		{
			// Felder vorher überprüfen
			if (!_details.ValidateFields())
				return false;

			_details.UpdateDATA();
            _details.Write();

            if (this._save != null && this._save.TYPE == ucButton.ButtonType.saveBenutzerverwaltung)
            {
                PMDS.Global.ENV.evBenutzerSMTPDatenSpeichern((System.Guid )_details.Object.ROW["ID"]);
            }

			return true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// gewählten Eintrag löschen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnDel_Click(object sender, System.EventArgs e)
		{
            if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_DELETE", _select.Text), 
				ENV.String("VERWALTUNG.DIALOGTITLE_DELETE"), 
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Question, true) == DialogResult.Yes)
			{
            _details.Delete();
			LoadWith(null);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// bei Änderung eines Wertes GUI aktualisieren (Buttons)
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucDetails_ValueChanged(object sender, System.EventArgs e)
		{
			IsEntryDirty = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Beendigung möglich
		/// </summary>
		//----------------------------------------------------------------------------
		public bool CanClose
		{
			get	
			{	
				bool bClose = true;
				if (IsEntryDirty)
				{
					DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), 
						                                                                    ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), 
						                                                                    MessageBoxButtons.YesNoCancel, 
						                                                                    MessageBoxIcon.Question, true);       

                    switch (res)
					{
						case DialogResult.Yes:
							if (!SaveDetails())
								bClose = false;
							break;

						case DialogResult.No:
							break;

						case DialogResult.Cancel:
							bClose = false;
							break;
					}
				}

				return bClose;	
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selector Liste erneuern
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshSelector()
		{
			LoadWith(null);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// verwendeter Selector
		/// </summary>
		//----------------------------------------------------------------------------
		public EngineSelector Selector
		{
			get	{	return _select;	}
		}
	}
}
