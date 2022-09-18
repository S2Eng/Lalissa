using System;
using System.ComponentModel;




namespace qs2.core.language
{


    public partial class sqlLanguage : Component
    {
        
        public enum eLanguage
        {
            English = 0,
            German = 1,
            LangUser = 2,
            NoText = 3
        }
        public enum eTypSelLang
        {
            IDRes = 100,
            search = 101,
            all = 102,
            ResourceType = 103,
            IDParticipant = 104
        }

        public static string daLanguageSelCmd { get; set; }
        public static dsLanguage dsLanguageAll { get; set; }
        public static bool allRessourcesLoaded  { get; set; }
        public static string IDResRoleLoggedInUser  { get; set; }

        static sqlLanguage()
        {
            dsLanguageAll = new dsLanguage();
            daLanguageSelCmd = "";
            allRessourcesLoaded = false;
            IDResRoleLoggedInUser = "";
        }
        
        public sqlLanguage()
        {
            InitializeComponent();
        }

        public sqlLanguage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void initControl()
        {
            //language.sqlLanguage.allRessourcesLoaded = false;
            sqlLanguage.daLanguageSelCmd = this.daLanguage.SelectCommand.CommandText;
        }
        public void loadAllRessources()
        {
            language.sqlLanguage.allRessourcesLoaded = false;
            qs2.core.language.sqlLanguage.dsLanguageAll.Clear();
            this.getLanguage("", language.sqlLanguage.dsLanguageAll, eTypSelLang.all, Enums.eResourceType.All, license.doLicense.eApp.ALL.ToString());
            language.sqlLanguage.allRessourcesLoaded = true;
        }
        
        public static System.Drawing.Image getPicture(string IDRessource, core.Enums.eResourceType ResourceType, string IDParticipant, string IDApplication)
        {
            try
            {
                qs2.core.language.dsLanguage.RessourcenRow rRes = qs2.core.language.sqlLanguage.getResRow(IDRessource, ResourceType, IDParticipant, IDApplication);
                if (rRes != null)
                {
                    if (!rRes.IsfileBytesNull())
                    {
                        System.IO.MemoryStream memStream = new System.IO.MemoryStream(rRes.fileBytes);
                        return System.Drawing.Image.FromStream(memStream);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("sqlLanguage.getPicture:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static string getRes(string IDRes, bool checkComma = true, bool CheckLabelForQuery = false)
        {
            if (checkComma)
                IDRes = language.sqlLanguage.checkComma(IDRes);

            string IDParticipant = "";
            if (license.doLicense.rParticipant != null)
                IDParticipant = license.doLicense.rParticipant.IDParticipant;
            else
                IDParticipant = license.doLicense.eApp.ALL.ToString();

            language.sqlLanguage.checkParticipant(ref IDParticipant);

            string IDApplication = "";
            if (license.doLicense.rApplication != null)
                IDApplication = license.doLicense.rApplication.IDApplication;
            else
                IDApplication = license.doLicense.eApp.ALL.ToString();

            if (CheckLabelForQuery)
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                string sTranslatedTxtFound = language.sqlLanguage.getRes(IDRes, Enums.eResourceType.LabelQuery, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
                if (!String.IsNullOrWhiteSpace(sTranslatedTxtFound))
                {
                    return sTranslatedTxtFound.Trim();
                }
                else
                {
                    rLangFoundReturn = null;
                    return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
                }
            }
            else
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
            }
        }

        public static string getRes(string IDRes, eLanguage Language, bool checkComma = true)
        {
            if (checkComma)
                IDRes = language.sqlLanguage.checkComma(IDRes);

            string IDParticipant = "";
            if (license.doLicense.rParticipant != null)
                IDParticipant = license.doLicense.rParticipant.IDParticipant;
            else
                IDParticipant = license.doLicense.eApp.ALL.ToString();

            language.sqlLanguage.checkParticipant(ref IDParticipant);

            string IDApplication = "";
            if (license.doLicense.rApplication != null)
                IDApplication = license.doLicense.rApplication.IDApplication;
            else
                IDApplication = license.doLicense.eApp.ALL.ToString();
            dsLanguage.RessourcenRow rLangFoundReturn = null;
            return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma, true, Language);

        }
        public static string getRes(string IDRes, string IDParticipant, string IDApplication, bool checkComma = true, bool CheckLabelForQuery = false)
        {
            if (checkComma)
                IDRes = language.sqlLanguage.checkComma(IDRes);

            language.sqlLanguage.checkParticipant(ref IDParticipant);

            if (CheckLabelForQuery)
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                string sTranslatedTxtFound = language.sqlLanguage.getRes(IDRes, Enums.eResourceType.LabelQuery, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
                if (sTranslatedTxtFound.Trim() != "")
                {
                    return sTranslatedTxtFound.Trim();
                }
                else
                {
                    rLangFoundReturn = null;
                    return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref  rLangFoundReturn, checkComma);
                }
            }
            else
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref  rLangFoundReturn, checkComma);
            }
        }

        public static string getRes(string IDRes, string IDParticipant, string IDApplication, string sDefault, bool checkComma = true, bool CheckLabelForQuery = false)
        {
            if (checkComma)
                IDRes = language.sqlLanguage.checkComma(IDRes);

            language.sqlLanguage.checkParticipant(ref IDParticipant);

            if (CheckLabelForQuery)
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                string sTranslatedTxtFound = language.sqlLanguage.getRes(IDRes, Enums.eResourceType.LabelQuery, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
                if (!String.IsNullOrWhiteSpace(sTranslatedTxtFound))
                {
                    return sTranslatedTxtFound.Trim();
                }
                else
                {
                    rLangFoundReturn = null;
                    return sDefault;
                }
            }
            else
            {
                dsLanguage.RessourcenRow rLangFoundReturn = null;
                return language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, IDApplication, ref rLangFoundReturn, checkComma);
            }
        }


        public static string checkComma(string IDResToCheck)
        {
            string IDResToReturn = IDResToCheck;
            if (IDResToCheck.Contains("."))
            {
                int posStart = IDResToCheck.IndexOf(".");
                IDResToReturn = IDResToCheck.Substring(posStart + 1, IDResToCheck.Length - posStart - 1);
            }
            return IDResToReturn;
        }

        public static string getResAllProdukts(string IDRes, string IDParticipant, string firstIDApplication, bool returnEmptyRes, bool checkComma = true)
        {
            dsLanguage.RessourcenRow rLangFoundReturn = null;
            string IDResFound = language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, firstIDApplication, ref rLangFoundReturn);

            if (IDResFound.Trim().Equals(""))
            {
                foreach (int val in Enum.GetValues(typeof(license.doLicense.eApp)))
                {
                    string sResTyp = Enum.GetName(typeof(license.doLicense.eApp), val);
                    if (sResTyp != firstIDApplication)
                    {
                        dsLanguage.RessourcenRow rLangFoundReturn2 = null;
                        IDResFound = language.sqlLanguage.getRes(IDRes, Enums.eResourceType.Label, IDParticipant, sResTyp, ref rLangFoundReturn2, checkComma, true, eLanguage.NoText, true);
                        if (!IDResFound.Trim().Equals(""))
                            return IDResFound;
                    }
                }
            }
            else if (!IDResFound.Trim().Equals(""))
            {
                return IDResFound;
            }

            // No Ressource found
            if (returnEmptyRes)
                return "";
            else
                return IDRes;
        }

        public static string getRes(string IDRes, Enums.eResourceType typ, string IDParticipant, string IDApplication,
                                    ref dsLanguage.RessourcenRow rLangFoundReturn,
                                    bool checkComma = true, bool DoProtocollWhenNotFound = true, eLanguage Language = eLanguage.NoText,
                                    bool CheckLabelForQuery = false)
        {
            //qs2.core.ui.addWatch(IDRes + "getRes start", true);
            if (checkComma)
                IDRes = language.sqlLanguage.checkComma(IDRes);

            language.sqlLanguage.checkParticipant(ref IDParticipant);
            
            if (qs2.core.ENV.language == eLanguage.NoText.ToString())
            {
                return "";
            }
            else
            {
                dsLanguage dsLangResult = getLanguageRows(IDRes, eTypSelLang.IDRes);
                if (dsLangResult == null)
                {
                    sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                    return IDRes + " / Err2 / " + IDApplication + "/" + typ.ToString();
                }
                else if (dsLangResult.Ressourcen.Rows.Count == 0)
                {
                    if (DoProtocollWhenNotFound)
                        sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                    return "";
                }
                else
                {
                    if (CheckLabelForQuery)
                    {
                        string xy = "";
                    }
                    dsLanguage.RessourcenRow rLangFound = null;
                    sqlLanguage.searchLangRow2(IDRes, typ, IDParticipant, IDApplication, ref rLangFound, ref dsLangResult, CheckLabelForQuery, checkComma, 
                                                DoProtocollWhenNotFound, Language);
                    rLangFoundReturn = rLangFound;
                    if (rLangFound == null)
                    {
                        if (CheckLabelForQuery)
                        {
                            sqlLanguage.searchLangRow2(IDRes, typ, IDParticipant, IDApplication, ref rLangFound, ref dsLangResult, false, checkComma,
                                                        DoProtocollWhenNotFound, Language);
                            rLangFoundReturn = rLangFound;
                            if (rLangFound == null)
                            {
                                if (DoProtocollWhenNotFound)
                                    sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return "";
                            }
                        }
                    }
                    
                    if (rLangFound != null)
                    {
                        if (Language == eLanguage.NoText)
                        {
                            if (qs2.core.ENV.language == eLanguage.English.ToString())
                                return rLangFound.English;
                            else if (qs2.core.ENV.language == eLanguage.German.ToString())
                                return rLangFound.German;
                            else if (qs2.core.ENV.language == eLanguage.LangUser.ToString())
                                return rLangFound.User;
                            else
                            {
                                if (DoProtocollWhenNotFound)
                                    sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return "";
                            }
                        }
                        else
                        {
                            if (Language == eLanguage.English)
                            {
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return rLangFound.English;
                            }
                            else if (Language == eLanguage.German)
                            {
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return rLangFound.German;
                            }
                            else if (Language == eLanguage.LangUser)
                            {
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return rLangFound.User;
                            }
                                
                            else
                            {
                                if (DoProtocollWhenNotFound)
                                    sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                                //qs2.core.ui.addWatch(IDRes + "getRes end", true);
                                return "";
                            }
                        }      
                    }
                }
            }
            //qs2.core.ui.addWatch(IDRes + "getRes end", true);
            return "";
            
        }

        public static void searchLangRow2(string IDRes, Enums.eResourceType typ, string IDParticipant, string IDApplication,
                                    ref dsLanguage.RessourcenRow rLangFound, ref dsLanguage dsLangResult, bool CheckLabelForQuery, 
                                    bool checkComma = true, bool DoProtocollWhenNotFound = true, eLanguage Language = eLanguage.NoText)
        {
            try
            {
                if (sqlLanguage.IDResRoleLoggedInUser.Trim() != "")
                {
                    rLangFound = language.sqlLanguage.searchLangRowxy(dsLangResult, typ, IDParticipant, IDApplication, IDRes.Trim() + sqlLanguage.IDResRoleLoggedInUser.Trim(), CheckLabelForQuery);
                    if (rLangFound == null)
                    {
                        rLangFound = language.sqlLanguage.searchLangRowxy(dsLangResult, typ, IDParticipant, IDApplication, IDRes, CheckLabelForQuery);
                        if (rLangFound == null)
                        {
                            if (DoProtocollWhenNotFound)
                                sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                        }
                    }
                }
                else
                {
                    rLangFound = language.sqlLanguage.searchLangRowxy(dsLangResult, typ, IDParticipant, IDApplication, IDRes, CheckLabelForQuery);
                    if (rLangFound == null)
                    {
                        if (DoProtocollWhenNotFound)
                            sqlLanguage.doProtNoTranslationFound(IDRes, IDApplication, typ);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("searchLangRow2:" + ex.ToString());
            }
        }

        public static void doProtNoTranslationFound(string IDRes, string IDApplication, Enums.eResourceType typ)
        {
            //if (!Protocol.alwaysShowExceptionMulticontrol)
            //{
                if (qs2.core.ENV.protocolAllTranslationErrors)
                {
                    if (IDRes.Trim() != "")
                    {
                        if (IDRes.Trim().ToLower() == ("Prozeduren").Trim().ToLower())
                        {
                            string xy = "";
                        }
                        
                        qs2.core.Protocol.doExcept("No translation found for IDRessource '" + IDRes + "' [Type " + typ.ToString () + "]!", "sqlLanguage.getRes", "", false, true, "", false, qs2.core.Protocol.eTypeError.Info);

                    }
                }
            //}
        }
        public static dsLanguage.RessourcenRow getResRow(string IDRes, Enums.eResourceType typ, string IDParticipant, string IDApplication)
        {
            language.sqlLanguage.checkParticipant(ref IDParticipant);
            if (qs2.core.ENV.language == eLanguage.NoText.ToString())
            {
                return null;
            }
            else
            {
                //sqlLanguage sql1 = new sqlLanguage();
                dsLanguage dsLangResult = sqlLanguage.getLanguageRows(IDRes, eTypSelLang.IDRes);
                if (dsLangResult == null)
                    return null;
                else if (dsLangResult.Ressourcen.Rows.Count == 0)
                    return null;
                else
                {
                    if (IDParticipant == "")
                        IDParticipant = license.doLicense.eApp.ALL.ToString();
                    if (IDApplication == "")
                        IDApplication = license.doLicense.eApp.ALL.ToString();

                    //dsLanguage.RessourcenRow rLangFound = language.sqlLanguage.searchLangRow(dsLangResult, typ, IDParticipant, IDApplication, IDRes);
                    dsLanguage.RessourcenRow rLangFound = null;
                    sqlLanguage.searchLangRow2(IDRes, typ, IDParticipant, IDApplication, ref rLangFound, ref dsLangResult, false);
                    if (rLangFound == null)
                        return null;
                    else
                    {
                        return rLangFound;
                    }
                }
            }
            return null;
        }
        private static dsLanguage.RessourcenRow searchLangRowxy(dsLanguage ds, Enums.eResourceType ResourceType, 
                                                            string IDParticipant, string IDApplication,
                                                            string IDRes, bool CheckLabelForQuery)
        {
            IDRes = IDRes.Trim();

            string selTyp = "";
            if (!CheckLabelForQuery)
            {
                selTyp = sqlTxt.and + ds.Ressourcen.TypeColumn.ColumnName + "='" + ResourceType.ToString() + "'";
            }
            else
            {
                selTyp = sqlTxt.and + ds.Ressourcen.TypeColumn.ColumnName + "='" + Enums.eResourceType.LabelQuery.ToString() + "'";
            }

            IDRes = IDRes.Replace("'", "''");
            string selIDRes = sqlTxt.and + ds.Ressourcen.IDResColumn.ColumnName + "='" + IDRes + "'";
            
            dsLanguage.RessourcenRow rLangFound;
            if (IDParticipant == "" || IDApplication == "")
                throw new Exception("searchLangRow: IDParticipant or IDApplication is null!");      //return null;  //(dsLanguage.RessourcenRow)ds.Ressourcen.Rows[0];
            else
            {
                dsLanguage.RessourcenRow[] arrLang = (dsLanguage.RessourcenRow[])ds.Ressourcen.Select(ds.Ressourcen.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'" + sqlTxt.and + ds.Ressourcen.IDApplicationColumn.ColumnName + "='" + IDApplication + "'" + selTyp + selIDRes);
                if (arrLang.Length > 0)
                    return arrLang[0];
                else
                {
                    arrLang = (dsLanguage.RessourcenRow[])ds.Ressourcen.Select(ds.Ressourcen.IDParticipantColumn.ColumnName + "='" + IDParticipant + "'" + sqlTxt.and + ds.Ressourcen.IDApplicationColumn.ColumnName + "='" + license.doLicense.eApp.ALL + "'" + selTyp + selIDRes);
                    if (arrLang.Length > 0)
                        return arrLang[0];
                    else
                    {
                        arrLang = (dsLanguage.RessourcenRow[])ds.Ressourcen.Select(ds.Ressourcen.IDParticipantColumn.ColumnName + "='" + license.doLicense.eApp.ALL + "'" + sqlTxt.and + ds.Ressourcen.IDApplicationColumn.ColumnName + "='" + IDApplication + "'" + selTyp + selIDRes);
                        if (arrLang.Length > 0)
                            return arrLang[0];
                        else
                        {
                            arrLang = (dsLanguage.RessourcenRow[])ds.Ressourcen.Select(ds.Ressourcen.IDParticipantColumn.ColumnName + "='" + license.doLicense.eApp.ALL + "'" + sqlTxt.and + ds.Ressourcen.IDApplicationColumn.ColumnName + "='" + license.doLicense.eApp.ALL + "'" + selTyp + selIDRes);
                            if (arrLang.Length > 0)
                                return arrLang[0];
                            else
                            {
                                arrLang = (dsLanguage.RessourcenRow[])ds.Ressourcen.Select(ds.Ressourcen.IDParticipantColumn.ColumnName + "=''" + sqlTxt.and + ds.Ressourcen.IDApplicationColumn.ColumnName + "='" + license.doLicense.eApp.ALL + "'" + selTyp + selIDRes);
                                if (arrLang.Length > 0)
                                    return arrLang[0];
                                else
                                {
                                    return null;
                                }
                            }   
                        }
                    }
                }
            }
            return null;
        }
        public static void checkParticipant(ref string IDParticipant)
        {
            if (IDParticipant.Trim().ToLower().Equals(license.doLicense.eApp.ALL.ToString().Trim().ToLower()) || IDParticipant.Trim() == "")
            {
                if (license.doLicense.rParticipant != null)
                {
                    IDParticipant = license.doLicense.rParticipant.IDParticipant;
                }
                else
                {
                    IDParticipant = license.doLicense.eApp.ALL.ToString();
                }  
            }
        }
        private static dsLanguage getLanguageRows(string IDRes, eTypSelLang typSel)
        {
            if (!language.sqlLanguage.allRessourcesLoaded)
            {
                sqlLanguage sqlLanguage1 = new sqlLanguage();
                dsLanguage dsLanguage = new dsLanguage();
                sqlLanguage1.getLanguage(IDRes, dsLanguage, eTypSelLang.IDRes, Enums.eResourceType.All, license.doLicense.eApp.ALL.ToString());
                if (dsLanguage.Ressourcen.Rows.Count >= 1)
                {
                    return dsLanguage;
                }
                else
                {
                    return null;
                    //throw new Exception("getLanguageRow: More than one Row for IDRes '" + IDRes  +  "' found!");
                }
            }
            else
            {
                //arrLang = (dsLanguage.RessourcenRow[])language.sqlLanguage.dsLanguageAll.Ressourcen.Select(language.sqlLanguage.dsLanguageAll.Ressourcen.IDResColumn.ColumnName + "='" + IDRes + "'" );
                return language.sqlLanguage.dsLanguageAll;
            }
        }

        public void getLanguage(string IDRes, dsLanguage ds, eTypSelLang typSel, Enums.eResourceType ResourceType, string Application)
        {
            try
            {
                getLanguage(IDRes, ds, typSel, ResourceType, Application, "");  //Methode für PMDS unverändert lassen
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void getLanguage(string IDRes, dsLanguage ds, eTypSelLang typSel, Enums.eResourceType ResourceType, string Application, string IDParticipant)
        {
            try
            {
                //if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                //{
                //    System.Windows.Forms.MessageBox.Show(IDRes);
                //}
                //else
                //{
                //    string x = "";
                //}     

                this.daLanguage.SelectCommand.CommandText = sqlLanguage.daLanguageSelCmd;
                qs2.core.dbBase.setConnection(ref this.daLanguage);
                this.daLanguage.SelectCommand.Parameters.Clear();

                if (typSel == eTypSelLang.IDRes)
                {
                    this.daLanguage.SelectCommand.CommandText += sqlTxt.where + sqlTxt.getColWhere(ds.Ressourcen.IDResColumn.ColumnName);
                    this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.IDResColumn.ColumnName, IDRes);
                }
                else if (typSel == eTypSelLang.IDParticipant)
                {
                    this.daLanguage.SelectCommand.CommandText += " where IDParticipant<>'ALL' and IDParticipant='" + IDParticipant.Trim() + "' ";
                }
                //else if (typSel == eTypSelLang.all)
                //{
                //    //this.daLanguage.SelectCommand.CommandText += sqlTxt.orderBy + ds.Ressourcen.IDResColumn.ColumnName + sqlTxt.asc;
                //}
                else if (typSel == eTypSelLang.ResourceType)
                {
                    this.daLanguage.SelectCommand.CommandText += sqlTxt.where + ds.Ressourcen.TypeColumn.ColumnName + "='" + ResourceType.ToString() + "' ";
                    this.daLanguage.SelectCommand.CommandText += sqlTxt.orderBy + ds.Ressourcen.IDResColumn.ColumnName + sqlTxt.asc;
                }
                else if (typSel == eTypSelLang.search)
                {
                    string sWhereSearch = "";
                    if (IDRes != "")
                    {
                        sWhereSearch = ds.Ressourcen.IDResColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd + sqlTxt.or + ds.Ressourcen.EnglishColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd + sqlTxt.or +
                                        ds.Ressourcen.UserColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd + sqlTxt.or + ds.Ressourcen.TypeColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd + sqlTxt.or +
                                        ds.Ressourcen.GermanColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd + sqlTxt.or + ds.Ressourcen.DescriptionColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd;
                        //ds.Ressourcen.IDApplicationColumn.ColumnName + sqlTxt.likePerc + IDRes + sqlTxt.likePercEnd;
                        this.daLanguage.SelectCommand.CommandText += sqlTxt.where + " ( " + sWhereSearch + " ) ";
                    }
                    if (Application != license.doLicense.eApp.ALL.ToString())
                    {
                        this.daLanguage.SelectCommand.CommandText += (this.daLanguage.SelectCommand.CommandText.Contains(sqlTxt.where) ? sqlTxt.and : sqlTxt.where) + sqlTxt.getColWhere(ds.Ressourcen.IDApplicationColumn.ColumnName);
                        this.daLanguage.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.Ressourcen.IDApplicationColumn.ColumnName), Application);
                    }
                    if (ResourceType != Enums.eResourceType.All)
                    {
                        this.daLanguage.SelectCommand.CommandText += (this.daLanguage.SelectCommand.CommandText.Contains(sqlTxt.where) ? sqlTxt.and : sqlTxt.where) + sqlTxt.getColWhere(ds.Ressourcen.TypeColumn.ColumnName);
                        if (!ResourceType.ToString().Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()))
                        {
                            this.daLanguage.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.Ressourcen.TypeColumn.ColumnName), ResourceType.ToString());
                        }
                    }
                    this.daLanguage.SelectCommand.CommandText += sqlTxt.orderBy + ds.Ressourcen.IDResColumn.ColumnName + sqlTxt.asc;
                }

                this.daLanguage.Fill(ds.Ressourcen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public dsLanguage.RessourcenRow getLanguageRow(string IDRes, dsLanguage ds, string Application,
                                                        string Participant, string Type, qs2.core.Enums.eTypeSub TypeSub, string IDLanguageUser, 
                                                        bool doExceptionMordeThanOne, bool doTypeSub)
        {
            try
            {
                this.daLanguage.SelectCommand.CommandText = sqlLanguage.daLanguageSelCmd;
                qs2.core.dbBase.setConnection(ref this.daLanguage);
                this.daLanguage.SelectCommand.Parameters.Clear();

                string sqlWehre = sqlTxt.where +
                                    sqlTxt.getColWhere(ds.Ressourcen.IDResColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.Ressourcen.IDApplicationColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.Ressourcen.IDParticipantColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.Ressourcen.TypeColumn.ColumnName) + sqlTxt.and +
                                    sqlTxt.getColWhere(ds.Ressourcen.IDLanguageUserColumn.ColumnName);

                if (doTypeSub)
                {
                    sqlWehre += sqlTxt.and + sqlTxt.getColWhere(ds.Ressourcen.TypeSubColumn.ColumnName);
                }
                this.daLanguage.SelectCommand.CommandText += sqlWehre;

                this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.IDResColumn.ColumnName, IDRes);
                this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.IDApplicationColumn.ColumnName, Application);
                this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.IDParticipantColumn.ColumnName, Participant);
                this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.TypeColumn.ColumnName, Type);
                this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.IDLanguageUserColumn.ColumnName, IDLanguageUser);
                if (doTypeSub)
                {
                    this.daLanguage.SelectCommand.Parameters.AddWithValue(ds.Ressourcen.TypeSubColumn.ColumnName, TypeSub.ToString());
                }

                this.daLanguage.Fill(ds.Ressourcen);

                if (ds.Ressourcen.Rows.Count > 1 || ds.Ressourcen.Rows.Count == 0)
                {
                    if (doExceptionMordeThanOne)
                        throw new Exception("getLanguage: No Row or more than 1 Row found for IDRes '" + IDRes + "'");
                    return null;
                }
                else
                {
                    return (dsLanguage.RessourcenRow)ds.Ressourcen.Rows[0];
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("sqlLanguage.getLanguageRow:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return null;
            }
        }

        public bool deleteRessourcexy(string IDRes, string Application, string Participant, string Type, string IDLanguageUser)
        {
            dsLanguage.RessourcenDataTable tRessourcen = new dsLanguage.RessourcenDataTable();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + tRessourcen.TableName +
                                sqlTxt.where + sqlTxt.getColWhere(tRessourcen.IDResColumn.ColumnName) +
                                sqlTxt.where + sqlTxt.getColWhere(tRessourcen.IDApplicationColumn.ColumnName) +
                                sqlTxt.where + sqlTxt.getColWhere(tRessourcen.IDParticipantColumn.ColumnName) +
                                sqlTxt.where + sqlTxt.getColWhere(tRessourcen.TypeColumn.ColumnName) +
                                sqlTxt.where + sqlTxt.getColWhere(tRessourcen.IDLanguageUserColumn.ColumnName);

            cmd.Connection = qs2.core.dbBase.dbConn;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(tRessourcen.IDResColumn.ColumnName), System.Data.SqlDbType.NVarChar)).Value = IDRes;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(tRessourcen.IDApplicationColumn.ColumnName), System.Data.SqlDbType.NVarChar)).Value = Application;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(tRessourcen.IDParticipantColumn.ColumnName), System.Data.SqlDbType.NVarChar)).Value = Participant;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(tRessourcen.TypeColumn.ColumnName), System.Data.SqlDbType.NVarChar)).Value = Type;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(tRessourcen.IDLanguageUserColumn.ColumnName), System.Data.SqlDbType.NVarChar)).Value = IDLanguageUser;

            cmd.ExecuteNonQuery();
            return true;
        }
        public bool deleteRessource(string sWhere)
        {
            dsLanguage.RessourcenDataTable tRessourcen = new dsLanguage.RessourcenDataTable();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + tRessourcen.TableName + " where " + sWhere;
            cmd.Connection = qs2.core.dbBase.dbConn;
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool sys_deleteAllRessource()
        {
            dsLanguage.RessourcenDataTable tRessourcen = new dsLanguage.RessourcenDataTable();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + tRessourcen.TableName;
            cmd.Connection = qs2.core.dbBase.dbConn;
            cmd.ExecuteNonQuery();

            return true;
        }

        public bool sys_SaveAllRessourcesToDatabase(dsLanguage ds)
        {
            try
            {
                if (ds.Ressourcen.Rows.Count > 0)
                {
                    dsLanguage dsToSave = new dsLanguage();
                    foreach (dsLanguage.RessourcenRow rRes in ds.Ressourcen)
                    {
                        dsLanguage.RessourcenRow rNewRes = (dsLanguage.RessourcenRow)dsToSave.Ressourcen.NewRow();
                        rNewRes.ItemArray = rRes.ItemArray;

                        dsToSave.Ressourcen.Rows.Add(rNewRes);
                    }
                    this.daLanguage.Update(dsToSave.Ressourcen);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("sys_SaveAllRessourcesToDatabase: " + ex.ToString());
                return false;
            }
        }


        public dsLanguage.RessourcenRow newRowLanguage(ref dsLanguage dsLanguage1, string txt, string IDRes, string usrName, 
                                                            string Application, string Participant, 
                                                            qs2.core.Enums.eResourceType Type,
                                                            qs2.core.Enums.eTypeSub TypeSub, 
                                                            string IDLanguageUser)
        {
            dsLanguage.RessourcenRow rNew = (dsLanguage.RessourcenRow)dsLanguage1.Ressourcen.NewRow();

            rNew.IDRes = IDRes;
            rNew.English = txt;
            rNew.German = txt;
            rNew.User = txt;
            rNew.IDLanguageUser = IDLanguageUser;

            rNew.Type = Type.ToString();
            rNew.TypeSub = TypeSub == Enums.eTypeSub.None ? "" : TypeSub.ToString();

            rNew.IDApplication = Application;
            rNew.IDParticipant = Participant;

            rNew.SetfileBytesNull();
            rNew.fileType = "";
                       
            rNew.Description = "";

            System.DateTime dNow = System.DateTime.Now;
            rNew.Created = dNow;
            rNew.CreatedUser = usrName;
            rNew.IDGuid = System.Guid.NewGuid();

            rNew.Image = "";
            rNew.ImageHeigth = -1;
            rNew.ImageWidth = -1;

            rNew.Classification = "";
            rNew.LastChange = dNow;
            rNew.ResGroup = "";

            dsLanguage1.Ressourcen.Rows.Add(rNew);
            return rNew;
        }

    }
}
