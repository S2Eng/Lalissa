using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public class PDxResource
    {
        public string _Klartext;
        public string _Resource;

        public PDxResource(string Klartext, string Resource)
        {
            _Klartext = Klartext;
            _Resource = Resource;
        }
    }
}
