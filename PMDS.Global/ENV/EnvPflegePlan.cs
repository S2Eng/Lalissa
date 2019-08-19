using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public static class EnvPflegePlan
    {
        private static Guid _CurrentKlientenAbteilung;
        public static event EnvPflegePlanKlientenAbteilungChangedDelegate EnvPflegePlanKlientenAbteilungChanged;

        public static Guid CurrentKlientenAbteilung
        {
            get { return EnvPflegePlan._CurrentKlientenAbteilung; }
            set 
            { 
                EnvPflegePlan._CurrentKlientenAbteilung = value;
                if (EnvPflegePlanKlientenAbteilungChanged != null)
                    EnvPflegePlanKlientenAbteilungChanged();
            }
        }
    }
}
