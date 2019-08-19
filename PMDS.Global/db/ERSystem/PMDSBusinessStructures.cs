using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;
using PMDS.Global.db.ERSystem;
using Patagames.Pdf.Net;
using Patagames.Pdf.Enums;
using System.Threading;
using PMDS.DB;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;


namespace PMDS.DB
{

    public class PMDSBusinessStructures
    {


        public class cPatients
        {
            public Nullable<Guid> IDPatient { get; set; }
            public string PatientNachname { get; set; }
            public string PatientVorname { get; set; }

            public Nullable<Guid> IDAbteilung { get; set; }
            public Nullable<Guid> IDBereich { get; set; }

        }
        public class cPatientsAll
        {
            public Nullable<Guid> IDPatient { get; set; }
            public string PatientNachname { get; set; }
            public string PatientVorname { get; set; }
            public Nullable<Guid> IDAufenthalt { get; set; }
            public Nullable<DateTime> Entlassungszeitpunkt { get; set; }
            public Nullable<Guid> IDAbteilung { get; set; }
            public Nullable<Guid> IDBereich { get; set; }

        }


    }

}
