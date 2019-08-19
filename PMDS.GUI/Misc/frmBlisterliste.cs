using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using PMDS.Global;
using System.Data.Common;
using System.Data.SqlClient;

using Syncfusion.Pdf;
using System.IO;
using PMDS.db.Entities;

namespace PMDS.GUI.Misc
{
    public partial class frmBlisterliste : Form
    {
        public frmBlisterliste()
        {
            InitializeComponent();
        }

        private void btnCreateBlisterliste_Click_1(object sender, EventArgs e)
        {
            /*
             * 
             * Grundfunktion des Service
             * 
             *Wichtig:  Der Funktionslauf muss entweder ganz oder gar nicht erfolgen. Bei Fehler darf kein DB-Update erfolgen.
             * 
                Hole Liste der langfristig vorzubereitenden Medikamente, die geändert wurden (DatumGeaendert > ZeitpunktBlisterliste): 
                    SQL-Funktion verwenden: select * from s2_Blisterliste('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000')
                Für jeden Klienten genau ein Crystal Reports erstellen (Blisterliste) und als PDF speichern (Crystal Reports)
                Alle Blisterliste-PDFs in ein einziges PDF zusammenfassen   (Syncfusion)
                PDF als ZIP speichern und mit Passwort verschlüsseln        (Chilkat)
                ZIP als Anhang als eMail schicken                           (eMail)
                Wenn erfolgreich (auch wenn kein PDF erstellt wurde, wei lnichts geändert wurde)
                    In jedem Medikament, das auf der Blisterliste ist, den Zeitpunkt der Blisterliste updaten
                    QS2-Protokolleintrag als Plaintext (Inhalt, was wurde gesendet) schreiben   
                    eMail an Admin mit Erfolgsmeldung (ev. Inhalt als Plaintext) zur Kontrolle
                    Update eines neuen Systemfeldes ZeitpunktBisterliste. 
                    eMail an Admin mit Fehlermeldung

            Weitere Funktionen (nicht im Service, sondern im PMDS)
                Anzeige Feld ZeitpunktBlisterliste für Admins in der Statusleiste PMDS. Wenn mehr als x Stunden seit akt. Zeitpunkt -> rot anzeigen!
                Wenn nicht erfolgreich
                Ansicht / Ausdruck Blisterlisten von - bis
                Erneutes Senden Blisterlisten von - bis
                Ansicht und Drucken QS2-Protokoll Blisterlisten von - bis 
                Service neu starten / Service beenden für Admins
            */

            try
            {
                DateTime dtStart = DateTime.Now;
                string tmpPDF = Guid.NewGuid().ToString();
                string tmpPDFDir = System.IO.Path.Combine(@"C:\Temp", tmpPDF);
                string finalDir = System.IO.Path.Combine(@"C:\Temp", "Blisterlisten");
                string finalFileName = dtStart.ToString("yyyyMMddHHmmss");
                int iCountAufenthalte = 0;

                string strSQl = "SELECT DISTINCT IDKlient FROM dbo.s2_Blisterliste(@IDKlinik, @IDAbteilung, @IDKlient)";
                DbParameter[] pars = new DbParameter[]
                {
                    new SqlParameter {ParameterName="IDKlinik", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDKlinik"},
                    new SqlParameter {ParameterName="IDAbteilung", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDAbteilung"},
                    new SqlParameter {ParameterName="IDKlient", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDKlient"}
                };

                IEnumerable<Guid> kl = null;
                using (PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness())
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        kl = db.Database.SqlQuery<Guid>(strSQl, pars);
                        foreach (Guid IDKlient in kl)           //Ändern, wenn ER erweitert ist. Durch alle Rezepteinträge iterieren und wenn sich IDKlient ändert -> Liste drucken
                        {
                            //PDFs erstellen
                            PMDS.Print.ReportManager.PrintBlisterliste(System.IO.Path.Combine(ENV.ReportPath, "Blisterliste.rpt"), Guid.Empty, Guid.Empty, IDKlient, tmpPDFDir, false, IDKlient.ToString());
                            iCountAufenthalte++;
                            lbliCount.Text = iCountAufenthalte.ToString() + " / " + IDKlient.ToString();
                            Application.DoEvents();
                        }
                    }
                }

                // Erstellen eines pdf/A-Files pro Anforderung und löschen der temp. PDFs
                List<string> lstSourceFiles = new List<string>();  //Array mit PDFs, die zusammenzufassen sind

                // Alle pdfs des temporären Verzeichnisses 
                DirectoryInfo di1 = new DirectoryInfo(tmpPDFDir);
                FileInfo[] pdfList1 = di1.GetFiles("*.pdf", SearchOption.AllDirectories);
                foreach (FileInfo fi in pdfList1)
                {
                    string tmpFileName = System.IO.Path.Combine(fi.Directory.ToString(), fi.Name);
                    lstSourceFiles.Add(tmpFileName);
                    iCountAufenthalte++;
                }
                using (Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument(PdfConformanceLevel.Pdf_A1B))
                {
                    finalDoc.Compression = PdfCompressionLevel.Best;
                    Syncfusion.Pdf.PdfDocument.Merge(finalDoc, lstSourceFiles.ToArray());
                    finalDoc.Save(System.IO.Path.Combine(finalDir, finalFileName + ".PDF"));
                }

                //Zippen
                using (Chilkat.Zip zip = new Chilkat.Zip())
                {
                    zip.UnlockComponent("S2ENGINEERZIP_SBV9zXKx4T55");
                    zip.NewZip(Path.Combine(finalDir, "Blisterliste_" + finalFileName + ".zip"));
                    zip.AppendFiles(Path.Combine(finalDir, finalFileName + ".PDF"), false);
                    zip.PasswordProtect = true;
                    zip.SetPassword("MZ_oD1732!");
                    zip.WriteZip();
                    zip.CloseZip();
                    Directory.Delete(tmpPDFDir, true);
                }

                //Send per eMail (hl)

                //QS2-Protokoll schreiben (aus kl)

                //Erfolgsmeldung an Admin per eMail

                //Update Rezepteinträge (dtStart = Update für alle Rezepteinträge aus kl)


            }
            catch (Exception ex)
            {
                //Fehlermeldung an Admin per eMail
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                lbliCount.Text = "";
            }

        }
    }
}
