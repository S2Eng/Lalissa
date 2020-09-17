using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Security;

using System.Linq;


namespace PMDS.Global
{
    public static class Tools
    {    
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüft ob der übergebene Wochentag mit der Bitcodierten Struktur (MO-SO)
        /// gültig ist
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool IsAllowedWeekDay(DateTime time, int wochenTage)
        {
            // Berücksichtigung Wochentage
            int weekBit = ((int)time.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            int weekBitVal = (1 << weekBit);
            return ((wochenTage & weekBitVal) != 0);
        }

        public static PasswordScore CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length >= 4)
                score++;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"([0-9])", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"([a-z])", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"([A-Z])", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"(.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)])", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        public static bool ComparePasswords (string password1, string password2, int CompareLength)
        {

            if (CompareLength >= password1.Length)
            {
                return true;
            }

            for (int i = 0; i < password1.Length - CompareLength; i++)
            {
                string needle = password1.Substring(i, CompareLength);
                if (password2.Contains(needle))
                    return false;
            }
            
            return true;
        }

        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)

            System.IO.FileStream fs = null;
            try
            {
                fs = System.IO.File.OpenRead(fullFilePath);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

        }

        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }

        public static long GetTickCount()
        {
            return Environment.TickCount;
        }

        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }

        public enum AssocF
        { 
          ASSOCF_NONE                  = 0x00000000,
          ASSOCF_INIT_NOREMAPCLSID     = 0x00000001,
          ASSOCF_INIT_BYEXENAME        = 0x00000002,
          ASSOCF_OPEN_BYEXENAME        = 0x00000002,
          ASSOCF_INIT_DEFAULTTOSTAR    = 0x00000004,
          ASSOCF_INIT_DEFAULTTOFOLDER  = 0x00000008,
          ASSOCF_NOUSERSETTINGS        = 0x00000010,
          ASSOCF_NOTRUNCATE            = 0x00000020,
          ASSOCF_VERIFY                = 0x00000040,
          ASSOCF_REMAPRUNDLL           = 0x00000080,
          ASSOCF_NOFIXUPS              = 0x00000100,
          ASSOCF_IGNOREBASECLASS       = 0x00000200,
          ASSOCF_INIT_IGNOREUNKNOWN    = 0x00000400,
          ASSOCF_INIT_FIXED_PROGID     = 0x00000800,
          ASSOCF_IS_PROTOCOL           = 0x00001000,
          ASSOCF_INIT_FOR_FILE         = 0x00002000
        };

        public enum AssocStr
        { 
          ASSOCSTR_COMMAND = 1,
          ASSOCSTR_EXECUTABLE,
          ASSOCSTR_FRIENDLYDOCNAME,
          ASSOCSTR_FRIENDLYAPPNAME,
          ASSOCSTR_NOOPEN,
          ASSOCSTR_SHELLNEWVALUE,
          ASSOCSTR_DDECOMMAND,
          ASSOCSTR_DDEIFEXEC,
          ASSOCSTR_DDEAPPLICATION,
          ASSOCSTR_DDETOPIC,
          ASSOCSTR_INFOTIP,
          ASSOCSTR_QUICKTIP,
          ASSOCSTR_TILEINFO,
          ASSOCSTR_CONTENTTYPE,
          ASSOCSTR_DEFAULTICON,
          ASSOCSTR_SHELLEXTENSION,
          ASSOCSTR_DROPTARGET,
          ASSOCSTR_DELEGATEEXECUTE,
          ASSOCSTR_SUPPORTED_URI_PROTOCOLS,
          ASSOCSTR_MAX
        };

        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, ref uint pcchOut);

        public static string AssocQueryString(AssocStr association, string extension)
        {
            const int S_OK = 0;
            const int S_FALSE = 1;

            uint length = 0;
            uint ret = AssocQueryString(AssocF.ASSOCF_NONE, association, extension, null, null, ref length);
            if (ret != S_FALSE)
            {
                throw new InvalidOperationException("Keine Verknüpfung gefunden für " + extension);
            }

            var sb = new StringBuilder((int)length); // (length-1) will probably work too as the marshaller adds null termination
            ret = AssocQueryString(AssocF.ASSOCF_NONE, association, extension, null, sb, ref length);
            if (ret != S_OK)
            {
                throw new InvalidOperationException("Keine Verknüpfung gefunden für " + extension); 
            }

            return sb.ToString();
        }

        public static Boolean IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
             try
            {
                //Don't change FileAccess to ReadWrite, 
                //because if a file is in readOnly, it fails.
                stream = file.Open
                (
                    FileMode.Open, 
                    FileAccess.Read, 
                    FileShare.None
                );
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
 
            //file is not locked
            return false;
        }

        public static void InitiateSSLTrust()
        {
            try
            {
                //Change SSL checks so that all checks pass
                ServicePointManager.ServerCertificateValidationCallback =
                   new RemoteCertificateValidationCallback(
                        delegate
                        { return true; }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("generic.InitiateSSLTrust: " + ex);
            }
        }

        public static System.Collections.Generic.List<Guid> GetWichtigFuerDefaults(string setBereich)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.AuswahlListe> tAuswahlliste = db.AuswahlListe.Where(o => o.Bezeichnung == setBereich);
                    foreach (PMDS.db.Entities.AuswahlListe rAuswahlListe in tAuswahlliste)
                    {
                        string[] arrIDWichtig = rAuswahlListe.Beschreibung.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string IDWichtig in arrIDWichtig)
                        {
                            lstGuid.Add(new Guid(IDWichtig));
                        }

                        //Wenn in der Auswahlliste nichts angegeben ist, prüfen, ob in StrgDefaults in der Config was drinnen steht
                        if (lstGuid.Count == 0 && !String.IsNullOrWhiteSpace(ENV.StrgDefaults))
                        {
                            char[] charSeparators = new char[] { ',' };
                            string[] objs = ENV.StrgDefaults.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string obj in objs)
                            {
                                string[] settings = obj.Split('=');
                                string Bereich = settings[0];
                                string defaultSettings = settings[1];

                                if (
                                    (Bereich == "DekursMVB" && Bereich == setBereich) ||
                                    (Bereich == "DekursIntervention" && Bereich == setBereich) ||
                                    (Bereich == "DekursMedDiag" && Bereich == setBereich) ||
                                    (Bereich == "DekursÜbergabe" && Bereich == setBereich) ||
                                    (Bereich == "Einzelfallmedikation" && Bereich == setBereich) ||
                                    (Bereich == "Intervention" && Bereich == setBereich) ||
                                    (Bereich == "UngeplanteMaßnahme" && Bereich == setBereich) ||
                                    (Bereich == "Medikation" && Bereich == setBereich) ||
                                    (Bereich == "NeueWunde" && Bereich == setBereich) ||
                                    (Bereich == "NeueWundtherapie" && Bereich == setBereich) ||
                                    (Bereich == "NeuerWundeintrag" && Bereich == setBereich) ||
                                    (Bereich == "NeuesAssessment" && Bereich == setBereich)
                                    )
                                {
                                    string[] defaultSetting = defaultSettings.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                    string GegenzeichnenJN = defaultSetting[0];   //0 = nein, 1 = ja //this.Eintrag.AbzeichnenJN = GegenzeichnenJN == "1" ? true : false;

                                    string[] WichtgFuer = defaultSetting[1].Split(';');
                                    foreach (string wf in WichtgFuer)
                                    {
                                        lstGuid.Add(new Guid(wf));
                                    }
                                }
                            }                           
                        }
                    }
                }
                return lstGuid;
            }

            catch (Exception ex)
            {
                throw new Exception("GetWichtigFuerDefaults: " + ex.ToString());
            }
        }


    }
}
