using System;

namespace qs2.ui.Logging
{
    public class Log
    {
        public static void doLog(string ex, string title)
        {
            try
            {
                string IDApplicationTmp = "";
                if (qs2.core.license.doLicense.rApplication != null)
                {
                    IDApplicationTmp = qs2.core.license.doLicense.rApplication.IDApplication.Trim();
                }
                string IDParticipantTmp = "";
                if (qs2.core.license.doLicense.rParticipant != null)
                {
                    IDParticipantTmp = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim();
                }

                bool doGermanTxt = false;
                if (qs2.core.ENV.language == core.language.sqlLanguage.eLanguage.English.ToString())
                {
                    doGermanTxt = false;
                }
                else if (qs2.core.ENV.language == core.language.sqlLanguage.eLanguage.German.ToString())
                {
                    doGermanTxt = true;
                }
                else if (qs2.core.ENV.language == core.language.sqlLanguage.eLanguage.LangUser.ToString())
                {
                    doGermanTxt = false;
                }
                else
                {
                    doGermanTxt = false;
                }

                QS2.Logging.Settings.init(qs2.core.ENV.path_log, true, qs2.core.ENV.adminSecure);
                QS2.Logging.Settings.doLog(ex.ToString(), title, "QS2-System", doGermanTxt);
            }
            catch (Exception ex1)
            {
                throw new Exception("qs2.ui. Log.cs: " + ex1.ToString());
            }
        }
    }
}   