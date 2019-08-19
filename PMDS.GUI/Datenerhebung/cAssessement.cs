using PMDS.DB;
using PMDS.Print.CR;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global.db.ERSystem;





namespace PMDS.GUI.Datenerhebung
{
    

    public class cAssessement
    {

        public enum eTypeAttribute
        {
            Formularname = 0,
            PageNr = 1,
            Field = 2
        }
        public enum eParNamesReport
        {
            CheckFormulare = 0,
            IDAbteilung_current = 1,
            IDAufenthalt_current = 2,
            IDBereich_current = 3,
            IDKlient_current = 4,
            IDKlinik_current =5,
            IDUser_current = 6,
            Von = 7,
            Bis = 8,
            IDAbteilung = 11,
            IDKlient = 14,
            IDKlinik = 15
        }










        public bool checkNameParameter(ref List<BerichtParameter> list, string ReportFile, string ParNameToCheck)
        {
            try
            {
                bool parFound = false;
                foreach (BerichtParameter par in list)
                {
                    if (par.Name.Trim().ToLower().Equals(ParNameToCheck.Trim().ToLower()))
                    {
                        parFound = true;
                    }
                }

                return parFound;
            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.checkNameParameter: " + ex.ToString());
            }
        }



        public PMDS.Global.db.ERSystem.UISitemaps.cParFormular doReport(ref List<BerichtParameter> list, string ReportFile)
        {
            try
            {
                PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular = new PMDS.Global.db.ERSystem.UISitemaps.cParFormular();
                cParFormular.ReportFile = ReportFile.Trim();

                bool anyParFound = false;
                foreach (BerichtParameter par in list)
                {
                    if (par.Value != null)
                    {
                        string strParName = par.Name.Trim();
                        StringComparison sc = StringComparison.CurrentCultureIgnoreCase;

                        if (strParName.Equals(eParNamesReport.CheckFormulare.ToString().Trim(), sc))
                        {
                            string FormularName = par.Value.ToString().Trim();
                            anyParFound = true;
                            if (FormularName.Trim().Contains(";"))
                            {
                                cParFormular.lstFormularNames = qs2.core.generic.readStrVariables(FormularName.Trim());
                            }
                            else
                            {
                                if (FormularName.Trim() != "")
                                {
                                    cParFormular.lstFormularNames.Add(FormularName);
                                }
                            }
                        }

                        //--Parameter aus DynReports (Patientenansicht)
                        else if (strParName.Equals(eParNamesReport.IDAbteilung_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDAbteilung_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDAufenthalt_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDAufenthalt_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDBereich_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDBereich_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDKlient_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDKlient_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDKlinik_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDKlinik_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }

                        //--Parameter aus DynReportsExtras (Bereichsansicht)
                        else if (strParName.Equals(eParNamesReport.IDKlinik.ToString().Trim(), sc))
                        {
                            cParFormular.IDKlinik_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDAbteilung.ToString().Trim(), sc))
                        {
                            cParFormular.IDAbteilung_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.IDKlient.ToString().Trim(), sc))
                        {
                            cParFormular.IDKlient_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }

                        //Parameter aus DynReports UND DynReportsExtra
                        else if (strParName.Equals(eParNamesReport.IDUser_current.ToString().Trim(), sc))
                        {
                            cParFormular.IDUser_current = new Guid(par.Value.ToString().Trim());
                            anyParFound = true;
                        }

                        //individualle Parameter
                        else if (strParName.Equals(eParNamesReport.Von.ToString().Trim(), sc))
                        {
                            cParFormular.f_DatumErstelltVon = System.Convert.ToDateTime(par.Value);
                            anyParFound = true;
                        }
                        else if (strParName.Equals(eParNamesReport.Bis.ToString().Trim(), sc))
                        {
                            cParFormular.f_DatumErstelltBis = System.Convert.ToDateTime(par.Value);
                            anyParFound = true;
                        }
                    }
                }
                
                if (!anyParFound)
                {
                    throw new Exception("cAssessement.doReport: !anyParFound not allowed!");
                }

                string ProtocolListAttribute = "";
                this.doReport(ref cParFormular, ref ProtocolListAttribute);
                int iCounter = cParFormular.dsFormularAssessment.FormularData.Rows.Count;
                return cParFormular;

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.doReport: " + ex.ToString());
            }
        }
        public void doReport(ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref string ProtocolListAttribute)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.Global.db.ERSystem.dsKlientenliste dsFormularData = new dsKlientenliste();
                    PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new sqlManange();
                    sqlManange1.initControl();
                    sqlManange1.getFormularData(cParFormular, ref dsFormularData, 0);
                    foreach (PMDS.Global.db.ERSystem.dsKlientenliste.FormularDataRow rFormularData in dsFormularData.FormularData)
                    {
                        this.genDatasetFromFormular(rFormularData.IDFormular, false, ref cParFormular, ref ProtocolListAttribute);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.doReport: " + ex.ToString());
            }
        }

        public bool genDatasetFromFormular(Guid IDFormularData, bool SaveDataSet, ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref string ProtocolListAttribute)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.FormularDaten> tFormularDaten = db.FormularDaten.Where(o => o.ID == IDFormularData);
                    PMDS.db.Entities.FormularDaten rFormularDaten = tFormularDaten.First();
                    System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = db.Formular.Where(o => o.Name == rFormularDaten.FormularName.Trim());
                    PMDS.db.Entities.Formular rFormular = tFormular.First();

                    string xmlDataFormula = rFormularDaten.BLOP.Trim();
                    this.getXml(IDFormularData, SaveDataSet, ref xmlDataFormula, ref cParFormular, ref ProtocolListAttribute, rFormularDaten.FormularName.Trim(), rFormularDaten.IDREF);
                    
                    if (SaveDataSet)
                    {
                        return this.saveDataSetAsFile(ref IDFormularData, SaveDataSet, ref cParFormular);
                    }
                    else
                    {
                        return true;
                    }

                    //return true;           
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.genDatasetFromFormular: " + ex.ToString());
            }
        }
        public void addFormularInfo2(Guid IDFormularData, bool SaveDataSet, ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref dsFormular.FormularDataRow rFormularInfo)
        {
            try
            {
                rFormularInfo.f_IDFormular = IDFormularData;
                foreach (string FormularName in cParFormular.lstFormularNames)
                {
                    rFormularInfo.f_FormularName += FormularName.Trim() + ";";
                }
                if (cParFormular.IDAbteilung_current != null)
                {
                    rFormularInfo.IDAbteilung_current = cParFormular.IDAbteilung_current.Value;
                }
                if (cParFormular.IDAufenthalt_current != null)
                {
                    rFormularInfo.IDAufenthalt_current = cParFormular.IDAufenthalt_current.Value;
                }
                if (cParFormular.IDBereich_current != null)
                {
                    rFormularInfo.IDBereich_current = cParFormular.IDBereich_current.Value;
                }
                if (cParFormular.IDKlient_current != null)
                {
                    rFormularInfo.IDKlient_current = cParFormular.IDKlient_current.Value;
                }
                if (cParFormular.IDKlinik_current != null)
                {
                    rFormularInfo.IDKlinik_current = cParFormular.IDKlinik_current.Value;
                }
                if (cParFormular.IDUser_current != null)
                {
                    rFormularInfo.IDUser_current = cParFormular.IDUser_current.Value;
                }
                if (cParFormular.f_DatumErstelltVon != null)
                {
                    rFormularInfo.f_DatumErstelltVon = cParFormular.f_DatumErstelltVon.Value;
                }
                if (cParFormular.f_DatumErstelltBis != null)
                {
                    rFormularInfo.f_DatumErstelltBis = cParFormular.f_DatumErstelltBis.Value;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.addFormularInfo: " + ex.ToString());
            }
        }

        public void getXml(Guid IDFormularData, bool SaveDataSet, ref string xmlDefFormula,
                            ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref string ProtocolListAttribute, 
                            string FormularName, Guid IDKlient)
        {
            try
            {
                Chilkat.Xml chili_First = new Chilkat.Xml();
                chili_First.LoadXml(xmlDefFormula);
                string PageNr = "";
                this.getXml_rek(IDFormularData, SaveDataSet, ref chili_First, ref cParFormular, ref ProtocolListAttribute, ref PageNr, ref FormularName, ref IDKlient);

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.getXml: " + ex.ToString());
            }
        }
        public void getXml_rek(Guid IDFormularData, bool SaveDataSet, ref Chilkat.Xml chili_Parent,
                               ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref string ProtocolListAttribute, ref string PageNr, 
                               ref string FormularName, ref Guid IDKlient)
        {
            try
            {
                if (chili_Parent.NumChildren > 0)
                {
                    for (int nNrChild = 0; nNrChild <= (chili_Parent.NumChildren -1 ); nNrChild++)
                    {
                        Chilkat.Xml chili_Child = chili_Parent.GetChild(nNrChild);
                        string sTag = chili_Child.Tag.Trim();
                        if (sTag.Trim().ToLower().Equals(("FORMULARDATA").Trim().ToLower()) ||
                            sTag.Trim().ToLower().Equals(("PAGE").Trim().ToLower()) ||
                            sTag.Trim().ToLower().Equals(("VALUE").Trim().ToLower()))
                        {
                            this.getAttributesXml(IDFormularData, SaveDataSet, ref chili_Child, ref cParFormular, ref ProtocolListAttribute, ref sTag, ref PageNr, ref FormularName, ref IDKlient);
                            this.getXml_rek(IDFormularData, SaveDataSet, ref chili_Child, ref cParFormular, ref ProtocolListAttribute, ref PageNr, ref FormularName, ref IDKlient);
                        }
                        else
                        {
                            string other = sTag;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.getXml_rek: " + ex.ToString());
            }
        }

        public void getAttributesXml(Guid IDFormularData, bool SaveDataSet, ref Chilkat.Xml chiliNode,
                                       ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular, ref string ProtocolListAttribute, ref string XmlType, ref string PageNr,
                                       ref string FormularName, ref Guid IDKlient)
        {
            try
            {
                if (chiliNode.NumAttributes > 0)
                {
                    for (int nNrAttr = 0; nNrAttr <= (chiliNode.NumAttributes - 1); nNrAttr++)
                    {
                        if (chiliNode.GetAttributeName(nNrAttr) != null)
                        {
                            string AttributeIDTmp = chiliNode.GetAttributeName(nNrAttr);
                            if (XmlType.Trim().ToLower().Equals(("FORMULARDATA").Trim().ToLower()))
                            {
                                bool bForm = true;
                            }
                            else if (XmlType.Trim().ToLower().Equals(("PAGE").Trim().ToLower()))
                            {
                                if (AttributeIDTmp.Trim().ToLower().Equals(("Pagenumber").Trim().ToLower()))
                                {
                                    if (chiliNode.GetAttributeValue(nNrAttr) != null)
                                    {
                                        PageNr = chiliNode.GetAttributeValue(nNrAttr).Trim();
                                    }
                                }
                            }
                            else if (XmlType.Trim().ToLower().Equals(("VALUE").Trim().ToLower()))
                            {
                                if (AttributeIDTmp.Trim().ToLower().Equals(("FIELDNAME").Trim().ToLower()))
                                {
                                    if (chiliNode.Content != null && chiliNode.Content.Trim() != "")
                                    {
                                        dsFormular.FormularDataRow rFormularData = this.newRowFormularData(ref cParFormular.dsFormularAssessment);
                                        this.addFormularInfo2(IDFormularData, SaveDataSet, ref cParFormular, ref rFormularData);
                                        if (FormularName.Trim() == "")
                                        {
                                            throw new Exception("getAttributesXml: FormularName='' not allowed for IDFormulaData '" + IDFormularData.ToString() + "'!");
                                        }
                                        rFormularData.f_FormularName = FormularName.Trim();
                                        rFormularData.PageNr = PageNr.Trim();
                                        rFormularData.Field = chiliNode.GetAttributeValue(nNrAttr).Trim();
                                        rFormularData.Value = chiliNode.Content.Trim();
                                        rFormularData.f_IDKlient = IDKlient;
                                    }
                                }
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.getAttributesXml: " + ex.ToString());
            }
        }

        public bool saveDataSetAsFile(ref Guid IDFormularData, bool SaveDataSet, ref PMDS.Global.db.ERSystem.UISitemaps.cParFormular cParFormular)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "xml-file (*.xml)|*.xml";
                saveFileDialog1.FileName = "";
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                System.Windows.Forms.DialogResult res = saveFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string fileSelected = saveFileDialog1.FileName;
                    string xsdFile = fileSelected.Trim().Substring(0, fileSelected.Length - 3) + ".xsd";
                    cParFormular.dsFormularAssessment.WriteXml(fileSelected.Trim(), XmlWriteMode.WriteSchema);
                    cParFormular.dsFormularAssessment.WriteXmlSchema(xsdFile.Trim());
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.saveDataSetAsFile: " + ex.ToString());
            }
        }


        public dsFormular.FormularDataRow newRowFormularData(ref dsFormular ds)
        {
            try
            {
                dsFormular.FormularDataRow rNew = (dsFormular.FormularDataRow)ds.FormularData.NewRow();
                rNew.ID = System.Guid.NewGuid();
                rNew.Field = "";
                rNew.PageNr = "";
                rNew.Value = "";
                rNew.f_IDFormular = System.Guid.NewGuid();
                
                rNew.f_FormularName = "";
                rNew.Setf_DatumErstelltVonNull();
                rNew.Setf_DatumErstelltBisNull();
                rNew.Setf_IDKlientNull();
                rNew.Setf_IDBenutzerNull();
                rNew.SetIDAbteilung_currentNull();
                rNew.SetIDAufenthalt_currentNull();
                rNew.SetIDBereich_currentNull();
                rNew.SetIDKlient_currentNull();
                rNew.SetIDKlinik_currentNull();
                rNew.SetIDUser_currentNull();

                ds.FormularData.Rows.Add(rNew);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("cAssessement.newRowFormularData: " + ex.ToString());
            }
        }


    }

}
