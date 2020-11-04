using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.BAL.Main;
using System.Collections.Concurrent;

namespace WCFServicePMDS.BAL
{

    public class AuswahlListeBAL : IAuswahlListeBAL
    {

        [Serializable()]
        public class TypeSelList
        {
            public eTypeSelList eTypeSelList { get; set; }
            public string IDGruppe;
        }

        public enum eTypeSelList
        {
            AuswahlListe = 0,
            Klinik = 1
        }




        public AuswahlListeBAL()
        {

        }

        ///<summary>RAM-Function</summary>
        public static AuswahlListeDTO auswahlliste(string IDAuswahlListeGruppe, Guid Id)
        {
            ConcurrentBag<AuswahlListeDTO> lAuswahlListe = Lists.getFirstFromDictConcBag<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste);
            AuswahlListeDTO al = lAuswahlListe.Where(o => o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Id == Id).First();
            return al;
        }

        public static AuswahlListeDTO auswahlliste2(string IDAuswahlListeGruppe, string ELGA_Code, string ELGA_CodeSystem)
        {
            ConcurrentBag<AuswahlListeDTO> lAuswahlListe = Lists.getFirstFromDictConcBag<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste);
            AuswahlListeDTO al = lAuswahlListe.Where(o => o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.ElgaCode == ELGA_Code && o.ElgaCodeSystem == ELGA_CodeSystem).First();
            return al;
        }
        public static AuswahlListeDTO auswahllisteBez(string IDAuswahlListeGruppe, string Bezeichnung, bool doExeptIfNotExits = true)
        {
            ConcurrentBag<AuswahlListeDTO> lAuswahlListe = Lists.getFirstFromDictConcBag<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste);
            IEnumerable<AuswahlListeDTO> l = lAuswahlListe.Where(o => o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Bezeichnung == Bezeichnung.Trim());
            if (l.Count() == 1)
            {
                var r = l.First();
                return r;
            }
            else
            {
                if (doExeptIfNotExits)
                    throw new Exception("auswahllisteBez: AuswahlListe not found for IDAuswahlListeGruppe='" + IDAuswahlListeGruppe.ToString() + "' and Bezeichnung='" + Bezeichnung.Trim() + "'!");
                else
                    return null;
            }
        }
        public static AuswahlListeDTO auswahllisteBezOrEmpty(string IDAuswahlListeGruppe, string Bezeichnung)
        {
            ConcurrentBag<AuswahlListeDTO> lAuswahlListe = Lists.getFirstFromDictConcBag<AuswahlListeDTO>(StammdatenDTO.Stammdaten.lAuswahlliste);
            var r = lAuswahlListe.Where(o => o.IdauswahlListeGruppe == IDAuswahlListeGruppe && o.Bezeichnung == "").FirstOrDefault();
            return r;
        }
    }

}
