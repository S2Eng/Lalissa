//----------------------------------------------------------------------------
/// <summary>
///	GuiUtil.cs
/// Erstellt am:	22.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinTabControl;
using System.Diagnostics;
using System.IO;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Binding Informationen
	/// </summary>
	//----------------------------------------------------------------------------
	public class BindCtrl
	{
		private Control _control;
		private string	_property;
		private object	_data; 
		private string	_dataMember;

		public BindCtrl(Control c, string property, object data, string dataMember)
		{
			_control	= c;
			_property	= property;
			_data		= data;
			_dataMember	= dataMember;
		}

		#region PROPERTIES
		public Control Control
		{
			get	{	return _control;	}
		}
		public string Property
		{
			get	{	return _property;	}
		}
		public object Data
		{
			get	{	return _data;	}
		}
		public string DataMember
		{
			get	{	return _dataMember;	}
		}
		#endregion
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Nützliche Utilities für die GUI
	/// </summary>
	//----------------------------------------------------------------------------
	public class GuiUtil
	{
		

		static GuiUtil()
		{
		}

        public static dsPatientStation.PatientDataTable GetKlientenforCurrentSelectionAbrech(bool entlassene, System.Guid IDKlinik)
        {
            dsPatientStation.PatientDataTable t;
            List<Guid> ag = new List<Guid>();
            ag.Add(System.Guid.Empty);
            t = Patient.ByFilter("", false, ag.ToArray(), System.Guid.Empty, entlassene, IDKlinik);
            return t;
        }

        public static dsPatientStation.PatientDataTable GetKlientenforCurrentSelection(bool entlassene, System.Guid IDKlinik)
        {
            dsPatientStation.PatientDataTable t;
            List<Guid> ag = new List<Guid>();
            //if (ENV.CurrentAnsichtinfo.IDAbteilung != Guid.Empty)
            //{
            //    ag.Add(ENV.CurrentAnsichtinfo.IDAbteilung);
            //    t = Patient.ByFilter("", false, ag.ToArray(), ENV.CurrentAnsichtinfo.IDBereich, entlassene, ENV.IDKlinik);
            //}
            //else
            //{
            //    t = Patient.ByFilter("", false, ENV.CurrentUserAbteilungen.ToArray(), ENV.CurrentAnsichtinfo.IDBereich, false, ENV.IDKlinik);
            //}

            //<20120202-2>
            ag.Add(ENV.CurrentAnsichtinfo.IDAbteilung);
            t = Patient.ByFilter("", false, ag.ToArray(), ENV.CurrentAnsichtinfo.IDBereich, entlassene, ENV.CurrentIDBezugsPfleger, IDKlinik);
            
            return t;
        }

        public static List<Guid> GetIDAbteilungenforCurrentSelection(bool entlassene, bool currIDAbteilung, System.Guid IDKlinik)
        {
            dsPatientStation.PatientDataTable t = GetKlientenforCurrentSelection(entlassene, IDKlinik);
            Patient p = new Patient();
            List<Guid> aIDAufenthalt = new List<Guid>();
            foreach (dsPatientStation.PatientRow r in t)
            {
                p.Read(r.ID);
                aIDAufenthalt.Add(p.Aufenthalt.ID);
            }

            return aIDAufenthalt;
        }
        
        public static void ShowLinkDokument(Guid IDlinkDokument)
        {
            try
            {
                if (IDlinkDokument == Guid.Empty)
                    return;
                LinkDokumente d = new LinkDokumente();
                dsLinkDokumente.LinkDokumenteDataTable dt = d.GetByID(IDlinkDokument);

                if (dt.Count == 0)
                    return;

                dsLinkDokumente.LinkDokumenteRow r = dt[0];                    

                if (r.LinkName.StartsWith("http", StringComparison.OrdinalIgnoreCase))                      // HTTP anzeigen
                {
                    Process.Start(r.LinkName);
                }
                else                                                                                        // alle anderen Dokumente anzeigen
                {
                    if (r.IsDokumentNull())
                            return;

                    string sExt = Path.GetExtension(r.LinkName).ToLower();
                    byte[] bFile = r.Dokument;
                    ShowDocumentFromByteStream(bFile, sExt);             
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        public static void ShowDocumentFromByteStream(byte[] bFile, string sExt) 
        {
            //Alte Dokumente von der Platte löschen, wenn sie nicht gerade verwendet werden.
            foreach (FileInfo f in new DirectoryInfo(System.IO.Path.GetTempPath()).GetFiles("tmp_*" + sExt))
            {
                if (!PMDS.Global.Tools.IsFileLocked(f))
                    f.Delete();
            }

            string DefaultApp = PMDS.Global.Tools.AssocQueryString(PMDS.Global.Tools.AssocStr.ASSOCSTR_EXECUTABLE, sExt);
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = DefaultApp;

            string tmpFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "tmp_" + System.Guid.NewGuid().ToString("N") + sExt);
            myProcess.StartInfo.Arguments = tmpFile;
            File.WriteAllBytes(tmpFile, bFile);
            myProcess.Start();

        }

        public static void SetAllEmbeddedControlsReadonly(UltraTabControl tabcont, bool bReadonly, Color cback, Color cFore)
        {
            foreach (UltraTab t in tabcont.Tabs)
            {
                foreach (Control c in t.TabPage.Controls)
                {
                    if (c is UltraLabel)
                        continue;
                    c.Enabled = !bReadonly;
                    c.BackColor = cback;
                    c.ForeColor = cFore;
                    if (c is UltraTextEditor)
                    {
                        ((UltraTextEditor)c).Appearance.BackColorDisabled = cback;
                        ((UltraTextEditor)c).Appearance.ForeColorDisabled = cFore;
                    }
                    else
                    {
                        if (c is UltraComboEditor)
                        {
                            ((UltraComboEditor)c).Appearance.BackColorDisabled = cback;
                            ((UltraComboEditor)c).Appearance.ForeColorDisabled = cFore;
                        }
                    }

                    
                    
                }
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Verknüpfung Controls/Daten erzeugen
		/// </summary>
		//----------------------------------------------------------------------------
		public static void Bind(BindCtrl[] bindings)
		{
			foreach(BindCtrl b in bindings)
				b.Control.DataBindings.Add(b.Property, b.Data, b.DataMember);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Verknüpfung Controls/Daten lösen
		/// </summary>
		//----------------------------------------------------------------------------
		public static void UnBind(BindCtrl[] bindings)
		{
			foreach(BindCtrl b in bindings)
				b.Control.DataBindings.Remove(b.Control.DataBindings[b.Property]);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control als benötigte markieren
		/// </summary>
		//----------------------------------------------------------------------------
		public static void ValidateRequired(UltraTextEditor edit)
		{
			edit.Appearance.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		public static void ValidateRequired(UltraCombo edit)
		{
			edit.Appearance.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		public static void ValidateRequired(UltraMaskedEdit edit)
		{
			edit.Appearance.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		public static void ValidateRequired(UltraDateTimeEditor edit)
		{
			edit.Appearance.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		public static void ValidateRequired(UltraComboEditor edit)
		{
			edit.Appearance.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		public static void ValidateRequired(UserControl edit)
		{
			edit.BackColor = ENVCOLOR.COLOR_REQUIRED;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Grid validieren
		/// </summary>
		//----------------------------------------------------------------------------

       
		public static void ValidateField(UltraGrid g, UltraGridRow r, UltraGridCell c, bool condition, 
										string sError, ref bool bError, bool showError, bool doTxtInVar = false)
		{
			if (condition) 
			{
				//c.Appearance.ResetBackColor2();
				//c.Appearance.ResetBackGradientStyle();
			}
			else
			{
				if (showError)
				{
					//c.Appearance.BackColor2 = ENVCOLOR.ERROR_BACK_COLOR; 
					//c.Appearance.BackGradientStyle = GradientStyle.Elliptical;
				}

				if (!bError)
				{
                    if (!doTxtInVar)
                    {
                        g.ActiveCell = c;
                        g.Focus();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError, true);
                    }
                    else
                    {
                        ucMed1VerschreibenDetail.msgBoxText += sError + "\r\n";
                        //System.Windows.Forms.MessageBox.Show(sError);
                    }
				}

				bError = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public static void ValidateField(Control edit, bool condition, 
										string sError, ref bool bError, 
										bool showError, ErrorProvider error, ref bool isWrong)
		{
			if (condition) 
			{
                if (error != null)
                {
                    error.SetError(edit, "");
                }
                isWrong = false;
            }
			else
			{
                if (showError && (error != null))
                {
                    error.SetError(edit, sError);
                }
				if (!bError)
				{
					// Control sichtbar machen
					Control ctrl = edit.Parent;
					while (ctrl != null)
					{
						if (ctrl is UltraTabPageControl)
						{
							UltraTabControl tc = (UltraTabControl)ctrl.Parent;
							tc.SelectedTab = ((UltraTabPageControl)ctrl).Tab;
						}

						ctrl = ctrl.Parent;
					}

                    setColor(edit);  
                    edit.Focus();
					QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
				}
                isWrong = true;
                setColor(edit);
                bError = true;
			}
		}


        public static void setColor(Control edit)
        {
            if (edit is UltraComboEditor)
            {
                setColorCbo((UltraComboEditor)edit);
            }
            else if (edit is UltraTextEditor)
            {
                setColorTxt((UltraTextEditor)edit);
            }
            else if (edit is QS2.Desktop.ControlManagment.BaseMaskEdit)
            {
                setColorTxt2((QS2.Desktop.ControlManagment.BaseMaskEdit)edit);
            }
            else if (edit is UltraDateTimeEditor)
            {
                setColorDat((UltraDateTimeEditor)edit);
            }
            else
                throw new Exception("setColor: edit has wrong type for function! (Type='" + edit.GetType().ToString() + "')");
        }

        public static void setColorCbo(UltraComboEditor cbo)
        {
            cbo.Appearance.BackColor = Color.Yellow;
        }
        public static void setColorTxt(UltraTextEditor txt)
        {
            txt.Appearance.BackColor = Color.Yellow;
        }
        public static void setColorTxt2(QS2.Desktop.ControlManagment.BaseMaskEdit txt)
        {
            txt.Appearance.BackColor = Color.Yellow;
        }
        public static void setColorDat(UltraDateTimeEditor dat)
        {
            dat.Appearance.BackColor = Color.Yellow;
        }



        public static void resetColor2(Control edit)
        {
            if (edit is UltraComboEditor)
            {
                resetColorCbo((UltraComboEditor)edit);
            }
            else if (edit is UltraTextEditor)
            {
                resetColorTxt((UltraTextEditor)edit);
            }
            else if (edit is QS2.Desktop.ControlManagment.BaseMaskEdit)
            {
                resetColorTxt2((QS2.Desktop.ControlManagment.BaseMaskEdit)edit);
            }
            else if (edit is UltraDateTimeEditor)
            {
                resetColorDat((UltraDateTimeEditor)edit);
            }
            else
                throw new Exception("resetColor2: edit has wrong type for function! (Type='" + edit.GetType().ToString() + "')");
        }

        public static void resetColorCbo(UltraComboEditor cbo)
        {
			cbo.Appearance.Reset();
        }
        public static void resetColorTxt(UltraTextEditor txt)
        {
			txt.Appearance.Reset();
		}
		public static void resetColorTxt2(QS2.Desktop.ControlManagment.BaseMaskEdit txt)
        {
			txt.Appearance.Reset();
        }
        public static void resetColorDat(UltraDateTimeEditor dat)
        {
			dat.Appearance.Reset();
        }

        public static void ValidateField(Control edit, bool condition,
                                string sError, ref bool bError,
                                bool showError, ErrorProvider error)
        {
            if (condition)
            {
                if (error != null)
                    error.SetError(edit, "");
            }
            else
            {
                if (showError && (error != null))
                    error.SetError(edit, sError);

                if (!bError)
                {
                    // Control sichtbar machen
                    Control ctrl = edit.Parent;
                    while (ctrl != null)
                    {
                        if (ctrl is UltraTabPageControl)
                        {
                            UltraTabControl tc = (UltraTabControl)ctrl.Parent;
                            tc.SelectedTab = ((UltraTabPageControl)ctrl).Tab;
                        }

                        ctrl = ctrl.Parent;
                    }

                    edit.Focus();
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
                }

                bError = true;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Fehlerhafte Zeilen makieren
        /// </summary>
        //----------------------------------------------------------------------------
        public static void MarkErrorRows(UltraGrid grid)
		{
			DataRowView drv;
			foreach(UltraGridRow ur in grid.Rows)
			{
				drv = (DataRowView)ur.ListObject;

				if (drv.Row.HasErrors)
					grid.ActiveRow = ur;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// aktuelle Abteilungs im klarText
		/// </summary>
		//----------------------------------------------------------------------------
		public static string Abteilung()
		{
            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                PMDS.db.Entities.Abteilung abt = b.getAbteilung(PMDS.Global.ENV.ABTEILUNG, db);
                if (abt != null)
                {
                    return abt.Bezeichnung.Trim();
                }
                else
                {
                    return "";
                }
            }

            //string sAbt = "";
            //dsAbteilung.AbteilungRow ar = AbteilungRow();
            //if (ar != null)
            //	sAbt = ar.Bezeichnung;
            //return sAbt;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// aktuelle AbteilungsRow
		/// </summary>
		//----------------------------------------------------------------------------
		public static dsAbteilung.AbteilungRow AbteilungRowxy()
		{
            return Klinik.Default().Abteilungen.Abteilungen.FindByID(ENV.ABTEILUNG);
            //xyhlxyxy
            //return null;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// LikeFilter für DataView.RowFilter korrigieren
		/// </summary>
		//----------------------------------------------------------------------------
		public static string LikeFilter(string filter)
		{
			filter = filter.Replace("[", "[[]");
			filter = filter.Replace("%", "[%]");
			filter = filter.Replace("*", "[*]");
			filter = filter.Replace("'", "");
			return filter;
		}

	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Liste mit selektionen behandeln
	/// </summary>
	//----------------------------------------------------------------------------
	public class GuiMarkers
	{
		private IMarker _marker;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public GuiMarkers(IMarker marker)
		{
			_marker = marker;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Schnittstelle ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		private IMarker Marker
		{
			get	{	return _marker;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Marker löschen setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public void ClearMarkers()
		{
			for(int i=0; i<Marker.Control.Items.Count; i++)
				Marker.Control.SetItemChecked(i, false);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DATA -> GUI
		/// </summary>
		//----------------------------------------------------------------------------
		public void SetMarkers()
		{
			DataTable table = Marker.DATA;

			if (table == null)
				return;

			// set checkMarkers
			int i=0;
			foreach(DataRow r in table.Rows)
			{
				if (Marker.Find(r) != null)
					Marker.Control.SetItemChecked(i, true);
				i++;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI -> DATA
		/// </summary>
		//----------------------------------------------------------------------------
		public void GetMarkersxy()
		{
			DataTable table = Marker.DATA;

			if (table == null)
				return;

			// get checkMarkers
			int i=0;
			foreach(DataRow r in table.Rows)
			{
				bool bMarked = Marker.Control.GetItemChecked(i);
				DataRow dr = Marker.Find(r);

				// delete old
				if (!bMarked && (dr != null))
					dr.Delete();

				// create new
				if (bMarked && (dr == null))
					Marker.NewItem(r);

				i++;
			}
		}

	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Objekt zum Einfärben der Fenster mit allen darunterliegenden GUI objekten
	/// </summary>
	//----------------------------------------------------------------------------
	public class LayoutColor
	{
		static public void Fill(Form f, Color back)
		{
			f.BackColor = back;
			foreach(Control c in f.Controls)
				Fill(c, back);
		}

		static private void Fill(Control ctrl, Color back)
		{
			if (ctrl is UltraButton)
			{
				UltraButton btn = (UltraButton)ctrl;
				btn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
				btn.UseFlatMode = DefaultableBoolean.True;
			}

			ctrl.BackColor = back;
			foreach(Control c in ctrl.Controls)
				Fill(c, back);
		}
        
	}

    
}
