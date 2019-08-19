using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EDIFact
{

    public class strucEDIFACT
    {

        public System.Collections.Generic.List<Segmente> lstSegmente = new List<Segmente>();




        public void initStructure()
        {
            try
            {
                Segmente newSeg = new Segmente ();
                newSeg.Segment = eSegmente.UNA;
                newSeg.Title = "Initialisierungsangaben";
                lstSegmente.Add(newSeg);
                
                newSeg = new Segmente ();
                newSeg.Segment = eSegmente.UNB;
                newSeg.Title = "Nachrichtenbeginn";
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.UNH;
                newSeg.Title = "Befundbeginn";
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.BGM;
                newSeg.Title = "Befundidentifikation";
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.FTX;
                newSeg.Semgent2 = "FTX+BFD";
                newSeg.Title = "Befundtext";
                newSeg.manyRows = true;
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.FTX;
                newSeg.Semgent2 = "FTX+ERG";
                newSeg.Title = "Ergebnis";
                newSeg.manyRows = true;
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.NAD;
                newSeg.Title = "Patientendaten";
                newSeg.Semgent2 = "NAD+PAT";
                lstSegmente.Add(newSeg);

                newSeg = new Segmente();
                newSeg.Segment = eSegmente.UNT;
                newSeg.Title = "Befundende";
                lstSegmente.Add(newSeg);
                
                newSeg = new Segmente();
                newSeg.Segment = eSegmente.UNZ;
                newSeg.Title = "Nachrichtenende";
                lstSegmente.Add(newSeg);

            }
            catch (Exception ex)
            {
                throw new Exception("strucEDIFACT.initStructure: " + ex.ToString());
            }
        }
        
        public enum eSegmente
        {
            UNA = 0,
            UNB = 1,
            UNH = 2,
            BGM = 3,
            FTX = 4,
            NAD = 5,
            UNT = 6,
            UNZ = 7,
            none = -100
        }
        public class Segmente
        {
            public eSegmente Segment = eSegmente.none;
            public string Title = "";
            public string Semgent2 = "";
            public System.Collections.Generic.List<string> lstText = new List<string>();
            public System.Collections.Generic.List<string> lstText2 = new List<string>();
            public bool manyRows = false;
        }

    }
    
}
