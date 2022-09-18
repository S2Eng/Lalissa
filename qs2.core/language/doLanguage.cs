using System;





namespace qs2.core.language
{


    public class doLanguage
    {



        public bool doAuto(qs2.core.language.dsLanguage dsResAdded,
                                    qs2.core.language.dsLanguage dsResModified,
                                    qs2.core.language.dsLanguage dsResDeleted,
                                    string Application, string Participant,
                                    bool loadAllResNew, bool IsSupervisor,
                                    bool SearchWithparticipantAllEmpty)
        {
            try
            {
                sqlLanguage sqlLanguage1 = new sqlLanguage();
                dsLanguage dsLanguage1 = new dsLanguage();
                sqlLanguage1.initControl();

                bool resChanged = false;
                if (dsResAdded.Ressourcen.Rows.Count > 0)
                {
                    dsLanguage1.Ressourcen.Clear();
                    // get empty Ds for add
                    sqlLanguage1.getLanguage(System.Guid.NewGuid().ToString(), dsLanguage1, sqlLanguage.eTypSelLang.IDRes, Enums.eResourceType.Label, Application);
                    foreach (dsLanguage.RessourcenRow rResToAdd in dsResAdded.Ressourcen)
                    {
                        dsLanguage.RessourcenRow rNewRes = (dsLanguage.RessourcenRow)dsLanguage1.Ressourcen.NewRow();
                        rNewRes.ItemArray = rResToAdd.ItemArray;
                        if (!IsSupervisor)
                        {
                            rNewRes.IDParticipant = Participant.Trim();
                        }
                        if (SearchWithparticipantAllEmpty && rNewRes.IDParticipant.Trim() == "")
                        {
                            rNewRes.IDParticipant = "ALL";
                        }
                        dsLanguage1.Ressourcen.Rows.Add(rNewRes);
                        resChanged = true;
                    }
                    sqlLanguage1.daLanguage.Update(dsLanguage1.Ressourcen);
                }

                if (dsResModified.Ressourcen.Rows.Count > 0)
                {
                    foreach (dsLanguage.RessourcenRow rResUpdate in dsResModified.Ressourcen)
                    {
                        dsLanguage1.Ressourcen.Clear();
                        string IDParticipantTmp = rResUpdate.IDParticipant.Trim();
                        if (SearchWithparticipantAllEmpty && rResUpdate.IDParticipant.Trim() == "")
                        {
                            IDParticipantTmp = "ALL";
                        }
                        sqlLanguage1.getLanguageRow(rResUpdate.IDRes, dsLanguage1, rResUpdate.IDApplication, IDParticipantTmp, rResUpdate.Type, Enums.eTypeSub.User, rResUpdate.IDLanguageUser, false, true);
                        if (dsLanguage1.Ressourcen.Rows.Count == 0)
                        {
                            sqlLanguage1.getLanguageRow(rResUpdate.IDRes, dsLanguage1, rResUpdate.IDApplication, "ALL", rResUpdate.Type, Enums.eTypeSub.User, rResUpdate.IDLanguageUser, false, true);
                        }
                        foreach (dsLanguage.RessourcenRow rResToModify in dsLanguage1.Ressourcen)
                        {
                            rResToModify.English = rResUpdate.English;
                            rResToModify.German = rResToModify.English;
                            rResToModify.User = rResToModify.English;
                            rResToModify.Created = rResUpdate.Created;
                            rResToModify.CreatedUser = rResUpdate.CreatedUser;
                            resChanged = true;
                        }
                        sqlLanguage1.daLanguage.Update(dsLanguage1.Ressourcen);
                    }
                }

                if (dsResDeleted.Ressourcen.Rows.Count > 0)
                {
                    foreach (dsLanguage.RessourcenRow rResToDelete in dsResDeleted.Ressourcen)
                    {
                        dsLanguage1.Ressourcen.Clear();
                        string IDParticipantTmp = rResToDelete.IDParticipant.Trim();
                        if (SearchWithparticipantAllEmpty)
                        {
                            IDParticipantTmp = "ALL";
                        }
                        sqlLanguage1.getLanguageRow(rResToDelete.IDRes, dsLanguage1, rResToDelete.IDApplication, IDParticipantTmp, rResToDelete.Type, Enums.eTypeSub.User, rResToDelete.IDLanguageUser, false, true);
                        foreach (dsLanguage.RessourcenRow rResToModify in dsLanguage1.Ressourcen)
                        {
                            rResToModify.Delete();
                            resChanged = true;
                        }

                        sqlLanguage1.daLanguage.Update(dsLanguage1.Ressourcen);
                        //sqlLanguage1.deleteRessource(rResToDelete.IDRes, rResToDelete.IDApplication, rResToDelete.IDParticipant, rResToDelete.Type, rResToDelete.IDLanguageUser);
                    }
                }

                if (loadAllResNew && resChanged)
                {
                    sqlLanguage1.loadAllRessources();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("doLanguage.doAuto:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return false;
            }
        }
        public static string translateText(ref string txtToTranslate, string IDApplication, string IDParticipant,
                                            ref System.Collections.Generic.List<string> lstIDResFound,
                                            Enums.eResourceType ResourceType)
        {
            try
            {
                return qs2.core.language.doLanguage.translateText(ref txtToTranslate, 0, IDApplication, IDParticipant, ref lstIDResFound,
                                                                    ResourceType);
            }
            catch (Exception ex)
            {
                throw new Exception("doLanguage.translateText:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return "";
            }
        }
        public static string translateText(ref string txtToTranslate, int searchFrom, string IDApplication, string IDParticipant, 
                                            ref System.Collections.Generic.List<string> lstIDResFound,
                                            Enums.eResourceType ResourceType)
        {
            try
            {
                //if (IDResToSearch == "PatWeight")
                //{
                //    string gxyxyxy = "";
                //}

                int posOpenClamp = txtToTranslate.IndexOf("[", searchFrom);
                if (posOpenClamp != -1)
                {
                    //qs2.core.language.doLanguage.translateText(ref txtToTranslate, posOpenClamp + 1, IDApplication, IDParticipant, ref lstIDResFound);

                    int posCloseClamp = txtToTranslate.IndexOf("]", posOpenClamp);
                    if (posCloseClamp != -1)
                    {
                        string IDToTranslate = txtToTranslate.Substring(posOpenClamp + 1, posCloseClamp - posOpenClamp - 1);
                        lstIDResFound.Add(IDToTranslate);
                        dsLanguage.RessourcenRow rLangFoundReturn = null;
                        string translatedTxt = qs2.core.language.sqlLanguage.getRes(IDToTranslate, ResourceType, IDParticipant, IDApplication, ref rLangFoundReturn);
                        if (!translatedTxt.Trim().Equals(""))
                        {
                            txtToTranslate = txtToTranslate.Replace("[" + IDToTranslate + "]", translatedTxt);
                        }
                        else
                        {
                            string xy = "";
                        }
                    }
                }
                return txtToTranslate;
            }
            catch (Exception ex)
            {
                throw new Exception("doLanguage.translateText:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return "";
            }
        }
    }
}
