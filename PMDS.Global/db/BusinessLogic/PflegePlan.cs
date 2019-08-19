using System;
using PMDS.DB;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using RBU;
using PMDS.Global;
using System.Text;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{



	public class PflegePlan : IPflegePlanAction
	{
		private DBPflegePlan				_DBPflegePlan;
		private DBPflegePlanPDx				_DBPflegePlanPDx;
		private DBAufenthaltPDx				_DBAufenthaltPDx;
		private Guid						_IDAufenthalt = Guid.Empty;
		private bool						_bReaded = false;




		public PflegePlan(bool bUseZusatzEintraegeOnly)
		{
			_DBPflegePlan		= new DBPflegePlan();
		}

		public PflegePlan(Guid IDAufenthalt)
		{
			_IDAufenthalt		= IDAufenthalt;
			_bReaded			= false;
			_DBPflegePlan		= new DBPflegePlan();
			_DBPflegePlanPDx	= new DBPflegePlanPDx();
			_DBAufenthaltPDx	= new DBAufenthaltPDx();
		}

        // Liefert alle IDAufenthaltPDx zu einem zugeh�rigen Eintrag, zB: Liefere mir alle Eintr�ge im Aufenthalt (PDX lokalisiert zum Ziel Y)
        public List<Guid> GetAllIDAufenthaltPDxFromIDPflegePlan(List<Guid> aIDPflegePlan)
        {
            List<Guid> alIDAufenthaltPDx = new List<Guid>();

            foreach (dsPflegePlanPDx.PflegePlanPDxRow r in PFLEGEPLANPDX.Rows)
            {
                foreach (Guid g in aIDPflegePlan)
                {
                    if (g == r.IDPflegePlan)
                        if (!r.IsIDAufenthaltPDxNull())
                            alIDAufenthaltPDx.Add(r.IDAufenthaltPDx);
                }
            }

            return alIDAufenthaltPDx;
        }


		// Liefert alle in den Eintr�gen vorkommenden Eintr�ge einer bestimmten Massnahme
		public dsPflegePlan.PflegePlanRow[] GetAllOpenEntriesFromIDEintrag(Guid IDEintrag)
		{
			if(!_bReaded)
				Read();
			ArrayList al = new ArrayList();
			foreach(dsPflegePlan.PflegePlanRow r in _DBPflegePlan.PFLEGEPLAN_EINTRAEGE)
			{
				if(r.IsIDEintragNull())
					continue;

				if(r.ErledigtJN || r.GeloeschtJN)
					continue;

				if(r.IDEintrag == IDEintrag)
					al.Add(r);
			}

			return (dsPflegePlan.PflegePlanRow[])al.ToArray(typeof(dsPflegePlan.PflegePlanRow));
		}

		// Lesen s�mtlicher Daten zum Pflegeplan
		public void Read() 
		{
			_DBPflegePlan.Read(_IDAufenthalt);
			_DBPflegePlanPDx.Read(_IDAufenthalt);
			_DBAufenthaltPDx.Read(_IDAufenthalt);
			_bReaded = true;
		}

        // Lesen s�mtlicher Daten zum Pflegeplan
        // Alle nur Normale Pflegediagnosen oder nur Wunden je nach modus werden gelesen
        public void Read(PflegePlanModus modus)
        {
            _DBPflegePlan.Read(_IDAufenthalt, modus);
            _DBPflegePlanPDx.Read(_IDAufenthalt, modus);
            _DBAufenthaltPDx.Read(_IDAufenthalt, modus);
            _bReaded = true;
        }

		/// Liest s�mtliche verspeicherten Eintr�ge des Pflegeplanes (Exception wenn nicht genau ein gelesener Datensatz)
		public dsPflegePlan.PflegePlanRow ReadOnce(Guid IDPflegePlan)
		{
			_DBPflegePlan.ReadOnce(IDPflegePlan);
			return _DBPflegePlan.PFLEGEPLAN_EINTRAEGE[0];
		}


		// Einen Termin einf�gen
		// Ein Termin ist ein Eintrag im Pflegeplan ohne Bezug zu einen "Eintrag" und
		// ohne Bezug zu einer PDx - Ein Termin kann einmalig oder n-malig sein
		// die eingef�gte Row wird f�r die Bearbeitung zur�ckgeliefert
		public dsPflegePlan.PflegePlanRow InsertTermin(ASZMSelectionArgs args, Guid IDUser) 
		{
			dsPflegePlan.PflegePlanRow r = null;

			if(!_bReaded)	
				Read();
			
            args.EintragGruppe = EintragGruppe.T;						// Spezieller Marker f�r Termin
			Guid IDNew = _DBPflegePlan.InsertPPEntry(args, IDUser);
			
			r = _DBPflegePlan.FindPflegePlanRowByID(IDNew);
			
			return r;
		}

		public dsPflegePlan.PflegePlanRow GetRowByID(Guid IDPflegePlan) 
		{
			if(!_bReaded)
				Read();
			
			return _DBPflegePlan.FindPflegePlanRowByID(IDPflegePlan);
		}

		public void EndPflegePlanID(Guid IDPflegePlan) 
		{
			if(!_bReaded)	
				Read();
			dsPflegePlan.PflegePlanRow r = null;
			r = _DBPflegePlan.FindPflegePlanRowByID(IDPflegePlan);
			r.ErledigtJN = true;
		}
		public void Write(Guid IDUser, bool bUseTransaction, bool bWriteHistory) 
		{
                this.Writexy(IDUser, bWriteHistory);
		}

        private void Writexy(Guid IDUser, bool bWriteHistory)
		{
            _DBPflegePlan.Write(IDUser, true, bWriteHistory);
            _DBAufenthaltPDx.Write();
            _DBPflegePlanPDx.Write();
			
		}

		///	Liefert die Lokalisirungsinformation zu einer IDAufenthaltPDx
		private void GetLokalisierung(Guid IDAufenthaltPdx, out string sLokalisierung, out string sLokalisierungSeite)
		{
			sLokalisierung = "";
			sLokalisierungSeite = "";
			dsAufenthaltPDx.AufenthaltPDxRow[] ra = (dsAufenthaltPDx.AufenthaltPDxRow[])_DBAufenthaltPDx.AUFENTHALTPDX.Select("ID = '" + IDAufenthaltPdx.ToString() + "'");
			if(ra.Length == 0)
				throw new Exception("PflegePlan::GetLokalisierung -> AufenthaltPDx konte nicht gefunden werden");

			if(ra.Length > 1)
				throw new Exception("PflegePlan::GetLokalisierung -> AufenthaltPDx wurde mehrfach gefunden");
			
			sLokalisierung		= ra[0].Lokalisierung.Trim();
			sLokalisierungSeite = ra[0].LokalisierungSeite.Trim();
		}

		///	Liefert alle zu den PDxen geh�renden Eintr�geIDs
		///	Pr�ft ob der Eintrag noch bei irgendeiner anderen PDx als den �bergebenen 
		///	vorkommt, wenn JA dann wird dieser Eintrag nicht herausgel�scht.
		///	Ermittelt also alle Eintr�ge die im Pflegeplan erledigt werden k�nnen wenn PDx
		///	beendet wird.
		public ASZMLokalisiert[] GetAllIDPflegePlanFromPDxArray(PDxLokalisiert[] aIDPDx)
		{
			ArrayList alEintrag = new ArrayList();
			string sLokalisierung = "";
			string sLokalisierungSeite = "";

			// Alle ASZM auf IDEintrag Ebene sammeln welche f�r die PDx mit der lokalisierung gefunden wurden
			foreach(dsPflegePlanPDx.PflegePlanPDxRow r in  _DBPflegePlanPDx.PFLEGEPLANPDX.Rows) 
			{
				if(r.ErledigtJN)
					continue;

				GetLokalisierung(r.IDAufenthaltPDx, out sLokalisierung, out sLokalisierungSeite);

				foreach(PDxLokalisiert pdxl in aIDPDx)
				{
					if(r.IDPDX == pdxl._IDPDx && sLokalisierung.Trim() == pdxl._Lokalisierung.Trim() && sLokalisierungSeite.Trim() == pdxl._LokalisierungSeite.Trim()) 
					{
						ASZMLokalisiert l = new ASZMLokalisiert(r.IDEintrag, sLokalisierung.Trim(), sLokalisierungSeite.Trim(), r.ID, true, r.IDPflegePlan, r.IDPDX, ""); // Vorbelegund dass entfernt werden soll wird im n�chsten Algorythmus u.U ver�ndert
						alEintrag.Add(l);
					}
				}
			}

			// In al Eintrag stehen nun alle ASZMs die zu den �bergebenen PDX mit Lokalisierung geh�ren
			// Weiters ist hier vermerkt welche IDPflegeplanPDx es betrifft und ob der Eintrag aus dem PP entfernt werden soll
			// f�r jeden Eintrag herausfinden ob noch andere PDx mit der selben lokalisierung existieren
			// Wenn ja dann darf der Eintrag nicht als erledigt markiert werden sondern nur die PflegeplanPDx

			foreach(dsPflegePlanPDx.PflegePlanPDxRow r in  _DBPflegePlanPDx.PFLEGEPLANPDX.Rows) 
			{
				if(r.ErledigtJN)						// Erledigte ignorieren
					continue;

				GetLokalisierung(r.IDAufenthaltPDx, out sLokalisierung, out sLokalisierungSeite);

				foreach(ASZMLokalisiert l in alEintrag)
				{
					if(l._IDEintrag == r.IDEintrag && l._Lokalisierung.Trim() == sLokalisierung.Trim() && l._LokalisierungSeite.Trim() == sLokalisierungSeite.Trim() && l._IDPDx != r.IDPDX)
					{
						bool bFound  = false;
						foreach(PDxLokalisiert pdxl in aIDPDx)	// Wenn die ungleiche PDx auch nicht in allen zu beendenden PDx vorkommt dann darf der Eintrag nicht beendet werden
						{
							if(pdxl._IDPDx == r.IDPDX && pdxl._Lokalisierung.Trim() == sLokalisierung.Trim() && pdxl._LokalisierungSeite.Trim() == sLokalisierungSeite.Trim())
								bFound = true;
						}
						if(!bFound)
							l._bCanPPFinished = false;
					}
				}
			}

			ASZMLokalisiert[] raszm = (ASZMLokalisiert[])alEintrag.ToArray(typeof(ASZMLokalisiert));
			ObtainTextInformation(raszm);			// Texte erg�nzen

			return (raszm);
		}

		// Liefert eine Liste mit s�mtlichen zugeh�rigen PflegePlanPDx verkn�pfungen nicht PDx verkn�pfte werden 1:1 eingetragen
		public ASZMLokalisiert[] GetAllIDPflegePlanFromPflegePlanRows(dsPflegePlan.PflegePlanRow[] ar)
		{
			ArrayList al = new ArrayList();
			string sLokalisierung = "";
			string sLokalisierungSeite = "";
			
			foreach(dsPflegePlan.PflegePlanRow r in ar) 
			{
				ASZMLokalisiert aszml = null;
				if(r.PDXJN) 
				{
					foreach(dsPflegePlanPDx.PflegePlanPDxRow rp in _DBPflegePlanPDx.PFLEGEPLANPDX)
					{
						if(rp.ErledigtJN)
							continue;

						GetLokalisierung(rp.IDAufenthaltPDx, out sLokalisierung, out sLokalisierungSeite);
						if(r.IDEintrag == rp.IDEintrag && r.Lokalisierung.Trim() == sLokalisierung.Trim() && r.LokalisierungSeite.Trim() == sLokalisierungSeite.Trim()) // entsprechendne Eintrag gefunden
						{
							bool bInsert = true;
							if(r.UntertaegigeJN)		// Bei untert�gigen schauen ob Eintrag schon in Liste ist wenn Ja dann nicht in Liste aufnehmen
							{
								foreach(ASZMLokalisiert ll in al)
									if(ll._IDUntertaegigGruppe == r.IDUntertaegigeGruppe && ll._IDPDx == rp.IDPDX) 
									{
										bInsert = false;
										break;
									}
							}
							if(bInsert) 
							{
								al.Add(aszml = new ASZMLokalisiert(r.IDEintrag, sLokalisierung.Trim(), sLokalisierungSeite.Trim(), rp.ID, false, r.ID, rp.IDPDX, ""));
								if(r.UntertaegigeJN)
									aszml._IDUntertaegigGruppe = r.IDUntertaegigeGruppe;
							}
						}
					}
				}
				else
				{
					al.Add(aszml = new ASZMLokalisiert(r.IDEintrag, r.Lokalisierung.Trim(), r.LokalisierungSeite.Trim(), Guid.Empty, false, r.ID, Guid.Empty, ""));
					if(r.UntertaegigeJN)
						aszml._IDUntertaegigGruppe = r.IDUntertaegigeGruppe;
				}
				
			}
			ASZMLokalisiert[] aret = (ASZMLokalisiert[])al.ToArray(typeof(ASZMLokalisiert));
			ObtainTextInformation(aret);
			return aret;
		}

		// Belegt die Gruppe(ASZM), die Untert�gigeGruppe (wenn vorhanden) und den Text f�r sp�tere Verwendung
		private void ObtainTextInformation(ASZMLokalisiert[] raszm)
		{
			foreach(ASZMLokalisiert l in raszm)
			{
				
				l._PDXText = DBUtil.GetPDX(l._IDPDx).Klartext;
				foreach(dsPflegePlan.PflegePlanRow r in _DBPflegePlan.PFLEGEPLAN_EINTRAEGE.Rows)
				{
					if(l._IDPflegePlan == r.ID)
					{
						string sText;
						if(r.UntertaegigeJN)			// Untert�gige Info aufbereiten
						{
							sText = "(" + GetUntertaegigeTimes(r.IDUntertaegigeGruppe) + ") " + r.Text;
							l._IDUntertaegigGruppe = r.IDUntertaegigeGruppe;
						}
						else 
						{
							sText = r.Text;
						}
						l._Gruppe	= r.EintragGruppe;
						l._Text		= sText;
						break;
					}
				}
			}
		}

		// Liefert alle Zeiten durch , getrennt f�r eine Untert�gigeGruppe
		private string GetUntertaegigeTimes(Guid IDUntertaegigeGruppe) 
		{
			bool bFirst = true;
			StringBuilder sb = new StringBuilder();
			dsPflegePlan.PflegePlanRow[] ra = (dsPflegePlan.PflegePlanRow[])_DBPflegePlan.PFLEGEPLAN_EINTRAEGE.Select("IDUntertaegigeGruppe = '" + IDUntertaegigeGruppe.ToString() + "'", "Startdatum asc");
			foreach(dsPflegePlan.PflegePlanRow ru in ra)
			{
				if(!bFirst)
					sb.Append(", ");
				sb.Append(ru.StartDatum.ToString("HH:mm"));
				bFirst = false;
			}
			return sb.ToString();
		}

		// Bereitet die Informationen so auf dass diese f�r die Abfrage von Missing
		// genutzt werden k�nnen.
		// Es werden nur diejenigen geliefert welche auch zu beenden sind
		// im Tag ist der Text der Massnahme verspeichert
		// doppelte ID PflegePlan werden eleminiert
		public PflegeEintrag[] GetPflegeEintraegeFromASZML(ASZMLokalisiert[] aszml, DateTime dtEnd)
		{
			ArrayList al = new ArrayList();
			ArrayList alID = new ArrayList();

			foreach(ASZMLokalisiert l in aszml)
			{
				if(!l._bCanPPFinished)							// nur die zu beendenden verarbeiten
					continue;

				if(!(l._Gruppe == EintragGruppe.M.ToString()))	// macht nur bei Massnahmen sinn
					continue;

				// pr�fen ob schon vorhanden wenn ja dann nicht noch einen Eintrag generieren
				foreach(Guid g in alID)
					if(g == l._IDPflegePlan)
						continue;

				alID.Add(l._IDPflegePlan);						// verspeichern um doppelte zu vermeiden

				PflegeEintrag pe = new PflegeEintrag();
				pe.EintragsTyp	= PflegeEintragTyp.MASSNAHME;
				pe.IDPflegePlan	= l._IDPflegePlan;
				pe.Zeitpunkt	= dtEnd;
				pe._Tag			= l._Text;
				al.Add(pe);

				PflegeEintrag pe1	= new PflegeEintrag();
				pe1.EintragsTyp		= PflegeEintragTyp.EVALUIERUNG;
                pe1.PflegeplanText = "Evaluierung";
				pe1.IDPflegePlan	= l._IDPflegePlan;
				pe1.Zeitpunkt		= dtEnd;
				pe1._Tag			= l._Text;
				al.Add(pe1);

			}

			return (PflegeEintrag[])al.ToArray(typeof(PflegeEintrag));
		}

		// Beendet die �bergebenen PDx mit Grund und EndeDatum
		public void EndPDx(PDxLokalisiert[] rpdx, ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd)
		{
			_DBPflegePlan.EndIDPflegePlanFromASZML(raszm, sReason, dtEnd);
			EndDependedUntertaegigeGruppe(raszm, sReason, dtEnd);
			_DBPflegePlanPDx.EndPDx(raszm, sReason, dtEnd);			// Muss als zweiter gesetzt werden da sonst die Flags beim Ermitteln der zu entfernenenden Eintr�ge nicht passen.
			_DBAufenthaltPDx.EndPDx(rpdx, sReason, dtEnd);			// Zugeh�rigkeit Aufenthalt->PDx beenden
		}

		// Markiert in den Datasets alle Eintr�ge als beendet und markiert
		// das Array so dass nur die wirklich zu beendenden als zu beenden 
		// markiert werden
		public void EndASZM(ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd)
		{
			_DBPflegePlanPDx.EndASZM(raszm, sReason, dtEnd);				// Alle in dem DS sind nun als Erledigt markiert muss als erstes aufgerufen werden damit sp�ter gepr�ft werden kann wer aller tats�chlich zum entfernen ist
			
			foreach(ASZMLokalisiert ll  in raszm)							// nun alle durchgehen um Kennzeichen zu setzen
			{
				if(ll._IDPDx != Guid.Empty)									// Nicht zugeordnete immer l�schen
																			// Pr�fen obs in der PPPDX noch einen Eintrag gibt der offen ist wenn ja dann nicht l�schen
				{
					bool bFound = false;
					foreach(dsPflegePlanPDx.PflegePlanPDxRow r in _DBPflegePlanPDx.PFLEGEPLANPDX)
					{
						string sLokalisierung = "";
						string sLokalisierungSeite = "";

						if(r.ErledigtJN)
							continue;
						GetLokalisierung(r.IDAufenthaltPDx, out sLokalisierung, out sLokalisierungSeite);

						if(r.IDEintrag == ll._IDEintrag && ll._Lokalisierung.Trim() == sLokalisierung.Trim() && ll._LokalisierungSeite.Trim() == sLokalisierungSeite.Trim()) 
						{
							bFound = true;
							break;
						}
					}
					if(bFound)
						ll._bCanPPFinished = false;
				}
			}
			
			EndDependedUntertaegigeGruppe(raszm, sReason, dtEnd);
			
		}

		// Beendet alle den Untert�gigenGruppe zugeh�rigen PflegePlaneintr�ge eines aufbereiteten ASZMLokalisiert[]
		private void EndDependedUntertaegigeGruppe(ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd)
		{
			foreach(ASZMLokalisiert ll in raszm)										// Alle die zum beenden sind beenden
			{
				if(ll._bCanPPFinished) 
				{
					_DBPflegePlan.EndPflegePlanID(ll._IDPflegePlan, sReason, dtEnd);	// Alle die zur beendigung markiert sind beenden
					
					if(ll._IDUntertaegigGruppe != Guid.Empty)							// Untert�gige auf einmal beenden
					{
						ArrayList al = new ArrayList();
						foreach(dsPflegePlan.PflegePlanRow r in _DBPflegePlan.PFLEGEPLAN_EINTRAEGE)		// Gleiche Gruppen sammeln
							if(!r.IsIDUntertaegigeGruppeNull() && r.IDUntertaegigeGruppe == ll._IDUntertaegigGruppe)
								al.Add(r);
						foreach(dsPflegePlan.PflegePlanRow r in al)										// Mitglieder der gleichen Gruppe beenden
							if(!r.ErledigtJN)
								_DBPflegePlan.EndPflegePlanID(r.ID, sReason, dtEnd);
					}
				}
			}
		}


		/// F�gt einen neuen Eintrag in die DB ein
		public Guid InsertPPEntry(ASZMSelectionArgs args, Guid IDUser) 
		{
			Guid IDPP = Guid.Empty;

			// Nachschauen obs den Eintrag mit der Lokalisierung schon gibt (Gilt nur f�r Ma�nahmen)
			// Wenn nein dann
			// einen neuen Eintrag in PP und PPPDx. Wenn ja dann nur einen Eintrag in PPPDx
			bool bFound = false;	
			
		
			foreach(dsPflegePlan.PflegePlanRow r in _DBPflegePlan.PFLEGEPLAN_EINTRAEGE)
			{

				if(r.IsIDEintragNull())
					continue;

				// Ein Datensatz gilt als gefunden wenn es sich 1) um keinen einmaligen (diese k�nnen beliebig oft vorkommen)
				// 2) Es sich um einen Eintrag handelt der auf der mit derselben lokalisierung bereits vorhanden ist
				// Ein Eintrag darf immer stattfinden wenn es sich um einen Eintrag ohne PDXZuordnung handelt
				// Ein Eintrag darf auch dann Stattfinden wenn es sich um einen Eintrag derselben Untert�gigkeitsGruppe handelt
				if(	r.IDEintrag == args.IDEintrag && 
					r.Lokalisierung.Trim().ToUpper() == args.Lokalisierung.Trim().ToUpper() &&
					r.LokalisierungSeite.Trim().ToUpper() == args.LokalisierungSeite.Trim().ToUpper() 
					&& r.ErledigtJN == false && r.EinmaligJN == false && args.ISPDX)
				{
					if(r.UntertaegigeJN)	// Bei Untert�gigen darf nur dieselbe Gruppe vorkommen aber sonst keine andere
					{
						if(r.IDUntertaegigeGruppe != args.IDUntertaegigGruppe)
						{
							bFound = true;
							IDPP = r.ID;
							break;
						}
					}
					else 
					{
						bFound = true;
						IDPP = r.ID;
						break;
					}
				}
				
			}
		

			if(!bFound)
				IDPP = _DBPflegePlan.InsertPPEntry(args, IDUser);	

			if(args.ISPDX)																				// nur Eintragen wenn es als PDX Kombination Eingetragen wurde
			{	
				Guid IDAufenthaltPDx = _DBAufenthaltPDx.InsertPPEntry(args, IDUser, IDPP);	
				bool bInsertEver = false;
				if(!bFound && args.LokalisierungJN && args.IDUntertaegigGruppe == Guid.Empty)											// bei neuen lokalisierungen muss immer eingetragen werden
					bInsertEver = true;
				_DBPflegePlanPDx.InsertPPEntry(args, IDUser, IDPP, IDAufenthaltPDx, bInsertEver, _DBAufenthaltPDx.AUFENTHALTPDX);		// Eingetragen wird nur wenn es die Kombination IDEintrag / PDx noch nicht gibt die Referenz zum AufenthaltPDx wird verspeichert 
				
			}
			return IDPP;
		}

		public void Refresh() 
		{
			if(_IDAufenthalt == Guid.Empty)
				return;
			_DBPflegePlan.Read(_IDAufenthalt);
			_DBPflegePlanPDx.Read(_IDAufenthalt);
			_DBAufenthaltPDx.Read(_IDAufenthalt);
			
		}

        public void Refresh(PflegePlanModus modus)
        {
            if (_IDAufenthalt == Guid.Empty)
                return;
            _DBPflegePlan.Read(_IDAufenthalt, modus);
            _DBPflegePlanPDx.Read(_IDAufenthalt, modus);
            _DBAufenthaltPDx.Read(_IDAufenthalt, modus);

        }

		/// Liefert alle einem Aufenthalt zugeordneten Zuordnungen von PDx mit den Eintr�gen
		public dsPflegePlanPDx.PflegePlanPDxDataTable PFLEGEPLANPDX 
		{
			get 
			{
				return _DBPflegePlanPDx.PFLEGEPLANPDX;
			}
		}

		// Liefert alle einem Aufenthalt zugeordneten Zuordnungen von PDx 
		public dsAufenthaltPDx.AufenthaltPDxDataTable AUFENTHALTPDX
		{
			get 
			{
				return _DBAufenthaltPDx.AUFENTHALTPDX;
			}
		}

		// Liefert s�mtliche Pflegeplaneintr�ge eines Aufenthaltes
		public dsPflegePlan.PflegePlanDataTable PFLEGEPLAN_EINTRAEGE
		{
			get 
			{
				return _DBPflegePlan.PFLEGEPLAN_EINTRAEGE;
			}
		}

	    // Beendet einen �bergebenen Eintrag soferne noch nicht beendet 
		// die �nderungen werden erst nach einem Write geschrieben
		// die �nderungen sind auch sofort im assoziierten Dataset verf�gbar
		// Die ID muss auch im gelesenen Dataset vorhanden sein sonst wird eine 
		// Exception ausgel�st
		public void EndPflegePlanID(Guid IDPflegeplan, string sReason, DateTime dtEnd)
		{
			_DBPflegePlan.EndPflegePlanID(IDPflegeplan, sReason, dtEnd);
			dsPflegePlan.PflegePlanRow r = _DBPflegePlan.PFLEGEPLAN_EINTRAEGE.FindByID(IDPflegeplan);
			if(!r.IsPDXJNNull() && r.PDXJN == true) 
			{
				_DBPflegePlanPDx.EndPflegePlanPDx(r.ID, sReason, dtEnd);
			}

		}
        
		// Liefert true wenn zu diesem Pflegeplaneintrag der R�ckmeldetext optional ist false sonst
		public static bool IsRMOptional(Guid IDPflegeplan)
		{
			return DBPflegePlan.IsRMOptional(IDPflegeplan);
		}

        /// Liefert alle aktiven Ziele zum Aufenthalt
        public static dsPflegePlan GetAllZiele(Guid IDAufenthalt, bool wunde, bool alleZiele)
        {
            return DBPflegePlan.GetAllZiele(IDAufenthalt, wunde, alleZiele);
        }

        /// Liefert den letzte R�ckmeldeZeitpunktText einer M eines Aufenthaltes oder Noch nie R�ckgemeldet wenn nicht vorhanden
        public static string GetLastRMTimeText(Guid IDAufenthalt, Guid IDEintrag)
        {
            string sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("noch nie r�ckgemeldet");    
            DateTime dtlast = DBPflegePlan.GetLastRMTime(IDAufenthalt, IDEintrag);
            if (dtlast.Year == 1900)
                return sText;
            sText = dtlast.ToShortDateString() + " " + dtlast.ToShortTimeString();
            return sText;
        }

    }
}
