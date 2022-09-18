using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;
using qs2.ui.pint;




namespace qs2.ui.print
{



    public class infoQry
    {
        
        public string Application = "";
        public string Participant = "";

        public dsAdmin.tblSelListEntriesRow rSelListQry;
        public dsAdmin.tblSelListEntriesObjRow rSelListQryObj;
        public dsAdmin.tblSelListEntriesRow rSelListReport;
          
        public qs2.core.vb.dsAdmin dsFieldsUI = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsConditionsUI = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsParFctUI = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsInputFieldsUI = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsJoinsUI = new qs2.core.vb.dsAdmin();

        public qs2.core.vb.dsAdmin dsFieldsForQuery = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsConditionsForQuery = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsParFctForQuery = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsInputFieldsForQuery  = new qs2.core.vb.dsAdmin();
        public qs2.core.vb.dsAdmin dsJoinsForQuery = new qs2.core.vb.dsAdmin();

        public string Sql = "";
        public string WhereClauselForSimpleFunctions = "";
        public string sqlForAdmin = "";

        public System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
        public System.Data.DataSet dsQryResult = new System.Data.DataSet();

        public qs2.core.Enums.eTypSubReport typSubreport;

        public bool isSubQuery = false;
        public System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunParSub = new System.Collections.Generic.List<qs2.ui.print.infoQry>();   

        public bool IsVLAD = false;

        public System.Guid IDQueryGroup = System.Guid.NewGuid();

        public string SqlWhereInfo = "";
        public string SqlWhereFromSql = "";
        public string SqlWhereAdmin = "";

        public bool abortSql = false;

        public bool isStayReport = false;
        public Nullable<Guid> IDGuid = null;







        public infoQry()
        {
        }

        public void NewDssCopy()
        {
            try
            {
                this.dsFieldsForQuery = new qs2.core.vb.dsAdmin();
                this.dsConditionsForQuery = new qs2.core.vb.dsAdmin();
                this.dsParFctForQuery = new qs2.core.vb.dsAdmin();
                this.dsInputFieldsForQuery = new qs2.core.vb.dsAdmin();
                this.dsJoinsForQuery = new qs2.core.vb.dsAdmin();
            }
            catch (Exception ex)
            {
                throw new Exception("NewDssCopy:" + ex.ToString());
            }
        }
        public void CopyDSs()
        {
            try
            {
                this.dsFieldsForQuery = (qs2.core.vb.dsAdmin)this.dsFieldsUI.Copy();
                this.dsConditionsForQuery = (qs2.core.vb.dsAdmin)this.dsConditionsUI.Copy();
                this.dsParFctForQuery = (qs2.core.vb.dsAdmin)this.dsParFctUI.Copy();
                this.dsInputFieldsForQuery = (qs2.core.vb.dsAdmin)this.dsInputFieldsUI.Copy();
                this.dsJoinsForQuery = (qs2.core.vb.dsAdmin)this.dsJoinsUI.Copy();
            }
            catch(Exception ex)
            {
                throw new Exception("CopyDSs:" + ex.ToString());
            }
        }

        public void clearAll()
        {
            try
            {
                this.IsVLAD = false;
                this.Application = "";
                this.Participant = "";

                this.rSelListQry = null;
                this.rSelListQryObj = null;
                this.rSelListReport = null;

                this.clearDatasets();

                this.Sql = "";
                this.SqlWhereInfo = "";
                this.SqlWhereFromSql = "";

                this.WhereClauselForSimpleFunctions = "";
                this.parametersSql.Clear();
                this.dsQryResult.Clear();
                this.sqlForAdmin = "";

                this.typSubreport = core.Enums.eTypSubReport.MainReport;

                this.isSubQuery = false;
                this.lstInfoQryRunParSub.Clear();

                this.clearDatasets();
                this.abortSql = false;

            }
            catch (Exception ex)
            {
                throw new Exception("infoQry.clearAll:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void clearDatasets()
        {
            try
            {
                this.dsFieldsUI.Clear();
                this.dsConditionsUI.Clear();
                this.dsParFctUI.Clear();
                this.dsInputFieldsUI.Clear();
                this.dsJoinsUI.Clear();

                this.dsFieldsForQuery.Clear();
                this.dsConditionsForQuery.Clear();
                this.dsParFctForQuery.Clear();
                this.dsInputFieldsForQuery.Clear();
                this.dsJoinsForQuery.Clear();

                this.NewDssCopy();

                //this.dsFields = new qs2.core.vb.dsAdmin();
                //this.dsConditions = new qs2.core.vb.dsAdmin();
                //this.dsParFct = new qs2.core.vb.dsAdmin();
                //this.dsInputFields = new qs2.core.vb.dsAdmin();
                //this.dsJoins = new qs2.core.vb.dsAdmin();
                //this.tQryPar = new dsAdmin.tblQueriesDefDataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("infoQry.clearDatasets:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void newRun()
        {
            try
            {
                this.Sql = "";
                this.SqlWhereInfo = "";
                this.SqlWhereFromSql = "";

                this.parametersSql = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
                this.dsQryResult = new System.Data.DataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("infoQry.newRun:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
    }

}
