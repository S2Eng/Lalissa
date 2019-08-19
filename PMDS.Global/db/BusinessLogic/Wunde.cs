using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;



namespace PMDS.BusinessLogic
{

    public class Wunde
    {
        private DBWunde _db = new DBWunde();



        public Wunde()
        {

        }


        public dsWunde ReadKopfPos(Guid IDAufenthaltPdx)
        {
            return _db.ReadKopfPos(IDAufenthaltPdx);
        }

        public dsWunde GetAllThumbs(Guid IDWundeKopf)
        {
            return _db.GetAllThumbs(IDWundeKopf);
        }

        //	Bilder lesen
        public void FillBilder(Guid IDWundePos, dsWunde ds)
        {
           _db.FillBilder(IDWundePos, ds);
        }

        public void Write(dsWunde ds)
        {
            _db.Write(ds);
        }

    }
}
