using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel; 

namespace PMDS.Global
{

    public enum State
    {
        [Description("Einschalten!")] On = 1,
        [Description("Ausschalten!")] Off = 2,
        [Description("Bearbeiten!")] Update = 3
    }

    public enum Unterbringungsaktion
    {
        [Description("Beginn")]                             Beginn,
        [Description("Verlängerung")]                       Verlaengerung,
        [Description("Ende")]                               Ende,
        [Description("Unterbringungshistorie Anzeigen")]    Historie
    }

    public enum Angeordnetvon
    {
        [Description("ArztIn")]                         Arzt = 0,
        [Description("BewohnervertreterIn")]            Bewohnervertreter = 1,
        [Description("gesetzliche/r VertreterIn")]      gesetzlicheVertreter = 2,
        [Description("selbst Gewählte/r VertreterIn")]  selbstGewaehlteVertreter = 3,
        [Description("Vertrauensperson")]               Vertrauensperson = 4
    }

    public enum Voraussichtlichedauer
    {
        [Description("< 24 Stunden")]               Kuerzer24Stunden = 0,
        [Description("8 Tage bis 6 Monate")]        Von8TBis6M = 1,
        [Description("< 24 Stunden wiederholt")]    Kuerzer24StundenWiederholt = 2,
        [Description("1 - 7 Tage")]                 Von1Bis7T = 3,
        [Description("> 6 Monate")]                 Ueber6M = 4,
        [Description("< 48 Stunden")]               Kuerzer48Stunden = 5,
        [Description("3 - 7 Tage")]                 Von3TBis7T = 6

    }

    
}
