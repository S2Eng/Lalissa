using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using PMDS.db.Entities;
using PMDS.DB;
using static PMDS.Global.db.ERSystem.ERHelper;



namespace PMDS.Global.db.ERSystem
{

    public class BusinessClassesTests
    {


        public void run()
        {
            string FctName = "BusinessClassesTests.run";
            int FctNr = 29070001;
            try
            {


            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                PMDS.Global.AppException.throwException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, FctName), FctNr);
            }
            catch (Exception ex)
            {
                PMDS.Global.AppException.throwException(FctName + " " + ex.ToString(), FctNr);
            }
        }

    }

}
