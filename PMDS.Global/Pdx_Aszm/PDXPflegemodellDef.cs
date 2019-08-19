//13.04.2007 MDA
using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public class PDXPflegemodellDef
    {
        private Guid _id;
        private Guid _idPDX;
        private Guid _idPflegemodelle;

        public PDXPflegemodellDef()
        {
        }

        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Guid IDPDX
        {
            get { return _idPDX; }
            set { _idPDX = value; }
        }

        public Guid IDPflegemodelle
        {
            get { return _idPflegemodelle; }
            set { _idPflegemodelle = value; }
        }
    }
}
