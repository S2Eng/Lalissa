using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using qs2.core.language;
using S2Extensions;

namespace qs2.core.license
{
    public class doLicense
    {
        public enum eApp
        {
            PMDS = 4,
            ALL = 0
        }

        public static dsLicense.ParticipantRow rParticipant { get; set; }
        public static dsLicense dsLicenseAct { get; set; }
        public static dsLicense.ApplicationRow rApplication { get; set; }

        public void GetAppsLicensedForParticipant(dsLicense dsLic)
        {
            dsLic.Clear();
            var sApp = Enum.GetName(typeof(eApp), qs2.core.license.doLicense.eApp.PMDS);
            var translated = sqlLanguage.getRes(sApp);

            var rNewApp = (dsLicense.ApplicationsRow)dsLic.Applications.NewRow();
            rNewApp.ID = sApp;
            rNewApp.Name = string.IsNullOrWhiteSpace(translated) ? sApp : translated;

            dsLic.Applications.Rows.Add(rNewApp);
        }

        public void FillTableApplications(dsLicense dsLic)
        {
            dsLic.Clear();
            foreach (int val in Enum.GetValues(typeof(eApp)))
            {
                var sApp = Enum.GetName(typeof(eApp), val);
                var translated = sqlLanguage.getRes(sApp);

                var rNewApp = (dsLicense.ApplicationsRow) dsLic.Applications.NewRow();
                rNewApp.ID = sApp;
                rNewApp.Name = string.IsNullOrWhiteSpace(translated) ? sApp : translated;

                dsLic.Applications.Rows.Add(rNewApp);
            }
        }

        public static void SetLicensePMDS()
        {
            try
            {
                qs2.core.license.dsLicense dsParticipant = new core.license.dsLicense();
                qs2.core.license.dsLicense dsApplication = new core.license.dsLicense();

                qs2.core.license.doLicense.rParticipant = dsParticipant.Participant.NewParticipantRow();
                rParticipant.LicCustomer = "PMDS";
                rParticipant.IDParticipant = "ALL";

                qs2.core.license.doLicense.rApplication = dsApplication.Application.NewApplicationRow();
                rApplication.IDApplication = "PMDS";
                rApplication.IDParticipant = "ALL";

                dsLicense lic = new dsLicense();
                var r = lic.Participant.NewParticipantRow();
                r.LicCustomer = "PMDS";
                r.IDParticipant = "ALL";
                lic.Participant.AddParticipantRow(r);

                var l = lic.Application.NewApplicationRow();
                l.IDApplication = "PMDS";
                l.IDParticipant = "ALL";
                lic.Application.AddApplicationRow(l);

                doLicense.dsLicenseAct = lic;
            }
            catch (Exception ex)
            {
                throw new Exception("doLicense.AutoLoadParticipantAndApplication: " + ex);
            }
        }
    }
}