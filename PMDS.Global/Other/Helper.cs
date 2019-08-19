using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinGrid;


namespace PMDS.Global
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// helperklasse um Guids und Texte in einem Objekt zu speichern.
    /// ToString() liefert den Text
    /// </summary>
    //----------------------------------------------------------------------------
    public class HelperIDText
    {
        private string _Text = "";
        private Guid _ID;
        public HelperIDText(string stext, Guid ID)
        {
            _Text = stext;
            _ID = ID;
        }

        public override string ToString()
        {
            return _Text;
        }

        public Guid ID
        {
            get
            {
                return _ID;
            }
        }
    }

    public class timehelper
    {
        public DateTime _from;
        public DateTime _to;
        public timehelper(DateTime dtfrom, DateTime dtto)
        {
            _from = dtfrom;
            _to = dtto;
        }
    }

    public class helper
    {
        public UltraGridColumn _c;
        public bool _groupby = false;
        public bool _desc = false;

        public helper(UltraGridColumn c, bool groupby, bool desc)
        {
            _c = c;
            _groupby = groupby;
            _desc = desc;
        }
    }
    public class SPNextHelper
    {
        public DateTime _next;          // wann es nächstesmal ausgeführt werden muss
        public string _MText;         // der Maßnahmentext

        public SPNextHelper(DateTime next, string MText)
        {
            _next = next;
            _MText = MText;
        }

        /// <summary>
        /// Liefert einen Formatierten String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {   
            return string.Format("{0}" + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist fällig am ") + "{1}" + QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ") + "{2}", _MText.Trim(), _next.ToShortDateString(), _next.ToShortTimeString());
        }
    }

    public enum ZeitbereichTyp
    {
        Zeitbereich = 0,
        ZeitbereichSerien
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// Hilfsklasse Zeitbereich - wird zum konvertieren innerhalb einer DatagridValuelist
    /// benötigt
    /// </summary>
    //----------------------------------------------------------------------------
    public class ZeitbereichHelper
    {
        public Guid _ID             = Guid.Empty;
        public ZeitbereichTyp _TYP  = ZeitbereichTyp.Zeitbereich;
        public ZeitbereichHelper(Guid ID, ZeitbereichTyp typ)
        {
            _ID = ID;
            _TYP = typ;
        }

        public ZeitbereichHelper(string s)
        {
            string[] sa = s.Split(';');
            if (sa.Length != 2)
                return;
            _TYP = sa[0] == "0" ? ZeitbereichTyp.Zeitbereich : ZeitbereichTyp.ZeitbereichSerien;
            _ID =  new Guid( sa[1]);
        }

        public override string ToString()
        {
            return ((int)_TYP).ToString() + ";" + _ID.ToString();
        }
    }
}
