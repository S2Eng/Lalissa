IF OBJECT_ID('[qs2].[tblSTAYAdditions]') IS NOT NULL
        DROP TABLE [qs2].[tblStayAdditions]
GO

IF OBJECT_ID('[qs2].[tblSTAY_VASCULAR_FollowUp]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_VASCULAR_FollowUp]
GO

IF OBJECT_ID('[qs2].[tblSTAY_VASCULAR_3]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_VASCULAR_3]
GO

IF OBJECT_ID('[qs2].[tblSTAY_VASCULAR_2]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_VASCULAR_2]
GO

IF OBJECT_ID('[qs2].[tblSTAY_VASCULAR_1]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_VASCULAR_1]
GO

IF OBJECT_ID('[qs2].[tblStay_NC_FUP1]') IS NOT NULL
        DROP TABLE [qs2].[tblStay_NC_FUP1]
GO

IF OBJECT_ID('[qs2].[tblSTAY_NC_1]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_NC_1]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_Z1_Z9]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_Z1_Z9]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_Valves]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_Valves]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_TAVI]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_TAVI]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_STS]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_STS]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_P1_Z]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_P1_Z]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_O_P]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_O_P]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_M_N2]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_M_N2]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_IC_L]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_IC_L]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_FrailtyIndex]') IS NOT NULL
        DROP TABLE [qs2].[tblStay_CARDIAC_FrailtyIndex]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_FollowUp]') IS NOT NULL
        DROP TABLE [qs2].[tblStay_CARDIAC_FollowUp]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_F_I]') IS NOT NULL
        DROP TABLE [qs2].[tblStay_CARDIAC_F_I]
GO

IF OBJECT_ID('[qs2].[tblSTAY_Cardiac_A_E]') IS NOT NULL
        DROP TABLE [qs2].[tblSTAY_Cardiac_A_E]
GO

IF OBJECT_ID('[qs2].[tblStatistics]') IS NOT NULL
        DROP TABLE [qs2].[tblStatistics]
GO

IF OBJECT_ID('[qs2].[tblSideLogic]') IS NOT NULL
        DROP TABLE [qs2].[tblSideLogic]
GO

IF OBJECT_ID('[qs2].[tblMedArchiv]') IS NOT NULL
        DROP TABLE [qs2].[tblMedArchiv]
GO

IF OBJECT_ID('[qs2].[tblCriteriaVascular]') IS NOT NULL
        DROP TABLE [qs2].[tblCriteriaVascular]
GO

IF OBJECT_ID('[qs2].[tblCriteriaOpt]') IS NOT NULL
        DROP TABLE [qs2].[tblCriteriaOpt]
GO

IF OBJECT_ID('[qs2].[tblAdjust]') IS NOT NULL
        DROP TABLE [qs2].[tblAdjust]
GO

IF OBJECT_ID('[qs2].[tblAddIns]') IS NOT NULL
        DROP TABLE [qs2].[tblAddIns]
GO

IF EXISTS (SELECT *
  FROM sys.foreign_keys where name = 'FK_tblStay_tblObject'
   AND parent_object_id = OBJECT_ID(N'qs2.tblStay')
)
ALTER TABLE [qs2].[tblStay] DROP CONSTRAINT [FK_tblStay_tblObject]
GO

IF EXISTS (SELECT *
  FROM sys.foreign_keys where name = 'FK_tblStay_tblStay'
   AND parent_object_id = OBJECT_ID(N'qs2.tblStay')
)
ALTER TABLE [qs2].[tblStay] DROP CONSTRAINT [FK_tblStay_tblStay]
GO

IF OBJECT_ID('qs2.CARDIAC_FOLLOWUPS', 'V') IS NOT NULL
    DROP VIEW qs2.CARDIAC_FOLLOWUPS;
GO

IF OBJECT_ID('qs2.CARDIAC_STAYS', 'V') IS NOT NULL
    DROP VIEW qs2.CARDIAC_STAYS;
GO

IF OBJECT_ID('qs2.CARDIAC_STAYS_FRAILTY', 'V') IS NOT NULL
    DROP VIEW qs2.CARDIAC_STAYS_FRAILTY;
GO

IF OBJECT_ID('qs2.CARDIAC_STAYS_VAC', 'V') IS NOT NULL
    DROP VIEW qs2.CARDIAC_STAYS_VAC;
GO

IF OBJECT_ID('qs2.vCARDIAC_AllValves_Int', 'V') IS NOT NULL
    DROP VIEW qs2.vCARDIAC_AllValves_Int;
GO

IF OBJECT_ID('qs2.vCARDIAC_AllValves', 'V') IS NOT NULL
    DROP VIEW qs2.vCARDIAC_AllValves;
GO

IF OBJECT_ID('qs2.vCARDIAC_UsedValves', 'V') IS NOT NULL
    DROP VIEW qs2.vCARDIAC_UsedValves;
GO

IF OBJECT_ID('qs2.vfncCARDIAC_AoValvesSizeReport', 'V') IS NOT NULL
    DROP VIEW qs2.vfncCARDIAC_AoValvesSizeReport;
GO

IF OBJECT_ID('qs2.vfncCARDIAC_FollowUpListTAVI', 'V') IS NOT NULL
    DROP VIEW qs2.vfncCARDIAC_FollowUpListTAVI;
GO

IF OBJECT_ID('qs2.vfncCARDIAC_DetailsPerSurgeonReport', 'V') IS NOT NULL
    DROP VIEW qs2.vfncCARDIAC_DetailsPerSurgeonReport;
GO

IF OBJECT_ID('qs2.vfncCARDIAC_ReportBasis', 'V') IS NOT NULL
    DROP VIEW qs2.vfncCARDIAC_ReportBasis;
GO

IF OBJECT_ID('qs2.vfncCARDIAC_ReportCardiological', 'V') IS NOT NULL
    DROP VIEW qs2.vfncCARDIAC_ReportCardiological;
GO

IF OBJECT_ID('qs2.vfncVASCULAR_AnnualReport', 'V') IS NOT NULL
    DROP VIEW qs2.vfncVASCULAR_AnnualReport;
GO

IF OBJECT_ID('qs2.vfncVASCULAR_KaplanMeier', 'V') IS NOT NULL
    DROP VIEW qs2.vfncVASCULAR_KaplanMeier;
GO

IF OBJECT_ID('qs2.vfncVASCULAR_ReportBasis', 'V') IS NOT NULL
    DROP VIEW qs2.vfncVASCULAR_ReportBasis;
GO

IF OBJECT_ID('qs2.vfncVASCULAR_ReportComplications', 'V') IS NOT NULL
    DROP VIEW qs2.vfncVASCULAR_ReportComplications;
GO

IF OBJECT_ID('qs2.vfncVASCULAR_StatistikAustria', 'V') IS NOT NULL
    DROP VIEW qs2.vfncVASCULAR_StatistikAustria;
GO

IF OBJECT_ID('qs2.VASCULAR_FOLLOWUPS', 'V') IS NOT NULL
    DROP VIEW qs2.VASCULAR_FOLLOWUPS;
GO

IF OBJECT_ID('qs2.VASCULAR_STAYS', 'V') IS NOT NULL
    DROP VIEW qs2.VASCULAR_STAYS;
GO

IF OBJECT_ID('qs2.vVASCULAR_Patienten', 'V') IS NOT NULL
    DROP VIEW qs2.vVASCULAR_Patienten;
GO

IF OBJECT_ID('qs2.getAllUsersWithRights', 'V') IS NOT NULL
    DROP VIEW qs2.getAllUsersWithRights;
GO

IF OBJECT_ID('qs2.getAllUsersWithRoles', 'V') IS NOT NULL
    DROP VIEW qs2.getAllUsersWithRoles;
GO

IF OBJECT_ID('qs2.getButtonsForUser', 'V') IS NOT NULL
    DROP VIEW qs2.getButtonsForUser;
GO

IF OBJECT_ID('qs2.getCriteriasForUser', 'V') IS NOT NULL
    DROP VIEW qs2.getCriteriasForUser;
GO

IF OBJECT_ID('qs2.getCriteriasUserForUser', 'V') IS NOT NULL
    DROP VIEW qs2.getCriteriasUserForUser;
GO

IF OBJECT_ID('qs2.vVASCULAR_GeneralReport', 'V') IS NOT NULL
    DROP VIEW qs2.vVASCULAR_GeneralReport;
GO

IF OBJECT_ID('qs2.vVASCULAR_OEGGCarotis', 'V') IS NOT NULL
    DROP VIEW qs2.vVASCULAR_OEGGCarotis;
GO

IF OBJECT_ID('qs2.qryMonths', 'V') IS NOT NULL
    DROP VIEW qs2.qryMonths;
GO

IF OBJECT_ID('qs2.vProtocol', 'V') IS NOT NULL
    DROP VIEW qs2.vProtocol;
GO

IF OBJECT_ID('qs2.AddCriteria', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddCriteria;
GO

IF OBJECT_ID('qs2.AddField', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddField;
GO

IF OBJECT_ID('qs2.AddRelation', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddRelation;
GO

IF OBJECT_ID('qs2.AddRessource', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddRessource;
GO

IF OBJECT_ID('qs2.AddSelListEntry', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddSelListEntry;
GO

IF OBJECT_ID('qs2.AddSelListEntry_ALL', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddSelListEntry_ALL;
GO

IF OBJECT_ID('qs2.AddSelListEntry_CARDIAC', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddSelListEntry_CARDIAC;
GO

IF OBJECT_ID('qs2.AddSelListEntry_WITHStringID_CARDIAC', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddSelListEntry_WITHStringID_CARDIAC;
GO

IF OBJECT_ID('qs2.AddSelListGroup', 'P') IS NOT NULL
    DROP PROCEDURE qs2.AddSelListGroup;
GO

IF OBJECT_ID('qs2.Crit2Chapter', 'P') IS NOT NULL
    DROP PROCEDURE qs2.Crit2Chapter;
GO

IF OBJECT_ID('qs2.DeleteDuplicatePatients', 'P') IS NOT NULL
    DROP PROCEDURE qs2.DeleteDuplicatePatients;
GO

IF OBJECT_ID('qs2.DeleteParticipantData', 'P') IS NOT NULL
    DROP PROCEDURE qs2.DeleteParticipantData;
GO

IF OBJECT_ID('qs2.GetDataFromQTH', 'P') IS NOT NULL
    DROP PROCEDURE qs2.GetDataFromQTH;
GO

IF OBJECT_ID('qs2.InsertSelListRes', 'P') IS NOT NULL
    DROP PROCEDURE qs2.InsertSelListRes;
GO

IF OBJECT_ID('qs2.JoinPatients', 'P') IS NOT NULL
    DROP PROCEDURE qs2.JoinPatients;
GO

IF OBJECT_ID('qs2.PatientDummy2', 'P') IS NOT NULL
    DROP PROCEDURE qs2.PatientDummy2;
GO

IF OBJECT_ID('qs2.ProcGroup2Chapter', 'P') IS NOT NULL
    DROP PROCEDURE qs2.ProcGroup2Chapter;
GO

IF OBJECT_ID('qs2.ProcToProcGroup', 'P') IS NOT NULL
    DROP PROCEDURE qs2.ProcToProcGroup;
GO

IF OBJECT_ID('qs2.ReplaceObjectInStay', 'P') IS NOT NULL
    DROP PROCEDURE qs2.ReplaceObjectInStay;
GO

IF OBJECT_ID('qs2.Set_ASGScore_VASCULAR', 'P') IS NOT NULL
    DROP PROCEDURE qs2.Set_ASGScore_VASCULAR;
GO

IF OBJECT_ID('qs2.Set_Complications_VASCULAR', 'P') IS NOT NULL
    DROP PROCEDURE qs2.Set_Complications_VASCULAR;
GO

IF OBJECT_ID('qs2.UpdateStaysToDummyPatient', 'P') IS NOT NULL
    DROP PROCEDURE qs2.UpdateStaysToDummyPatient;
GO

IF OBJECT_ID('qs2.fncCARDIAC_AoValvesSizeReport', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncCARDIAC_AoValvesSizeReport;
GO

IF OBJECT_ID('qs2.fncCARDIAC_DetailsPerSurgeonReport', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncCARDIAC_DetailsPerSurgeonReport;
GO

IF OBJECT_ID('qs2.fncCARDIAC_FollowUpListTAVI', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncCARDIAC_FollowUpListTAVI;
GO

IF OBJECT_ID('qs2.fncCARDIAC_ReportBasis', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncCARDIAC_ReportBasis;
GO

IF OBJECT_ID('qs2.fncCARDIAC_ReportCardiological', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncCARDIAC_ReportCardiological;
GO

IF OBJECT_ID('qs2.fncStatistikAustriaString', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncStatistikAustriaString;
GO

IF OBJECT_ID('qs2.fncVASCULAR_AnnualReport', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncVASCULAR_AnnualReport;
GO

IF OBJECT_ID('qs2.fncVASCULAR_KaplanMeier', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncVASCULAR_KaplanMeier;
GO

IF OBJECT_ID('qs2.fncVASCULAR_ReportBasis', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncVASCULAR_ReportBasis;
GO

IF OBJECT_ID('qs2.fncVASCULAR_ReportComplications', 'TF') IS NOT NULL
    DROP FUNCTION qs2.fncVASCULAR_ReportComplications;
GO

IF OBJECT_ID('qs2.fncVASCULAR_StatistikAustria', 'FN') IS NOT NULL
    DROP FUNCTION qs2.fncVASCULAR_StatistikAustria;
GO

IF OBJECT_ID('qs2.fncStatistikAustriaString', 'FN') IS NOT NULL
    DROP FUNCTION qs2.fncStatistikAustriaString;
GO

IF OBJECT_ID('qs2.GetBMIGroup', 'FN') IS NOT NULL
    DROP FUNCTION qs2.GetBMIGroup;
GO

IF OBJECT_ID('qs2.GetNextRecordID', 'FN') IS NOT NULL
    DROP FUNCTION qs2.GetNextRecordID;
GO

IF OBJECT_ID('qs2.GetVascularComplicationGroup', 'FN') IS NOT NULL
    DROP FUNCTION qs2.GetVascularComplicationGroup;
GO

IF OBJECT_ID('qs2.s2_GetValveName', 'FN') IS NOT NULL
    DROP FUNCTION qs2.s2_GetValveName;
GO

IF OBJECT_ID('qs2.GetGroupID', 'FN') IS NOT NULL
    DROP FUNCTION qs2.GetGroupID;
GO

IF OBJECT_ID('qs2.GetNewGroupID', 'FN') IS NOT NULL
    DROP FUNCTION qs2.GetNewGroupID;
GO


IF OBJECT_ID('[qs2].[tblStay]') IS NOT NULL
        DROP TABLE [qs2].[tblStay]
GO


DELETE FROM qs2.Ressourcen WHERE IDApplication = 'CARDIAC'
GO

DELETE FROM qs2.Ressourcen WHERE IDApplication = 'VASCULAR'
GO

DELETE FROM qs2.tblRelationship WHERE IDApplicationParent = 'CARDIAC'
GO

DELETE FROM qs2.tblRelationship WHERE IDApplicationChild = 'CARDIAC'
GO

DELETE FROM qs2.tblRelationship WHERE IDApplicationParent = 'VASCULAR'
GO

DELETE FROM qs2.tblRelationship WHERE IDApplicationChild = 'VASCULAR'
GO

DELETE FROM qs2.tblCriteria where IDApplication = 'CARDIAC'
GO

DELETE FROM qs2.tblCriteria where IDApplication = 'VASCULAR'
GO

DELETE FROM qs2.tblRelationship WHERE FldShortParent in (SELECT FldShortChild FROM qs2.tblCriteria WHERE IDApplication = 'ALL' AND (SourceTable = 'tblStay' or SourceTable = ''))
GO

DELETE FROM qs2.tblRelationship WHERE FldShortChild in (SELECT FldShortChild FROM qs2.tblCriteria WHERE IDApplication = 'ALL' AND (SourceTable = 'tblStay' or SourceTable = ''))
GO

DELETE FROM qs2.tblCriteria WHERE IDApplication = 'ALL' AND (SourceTable = 'tblStay' or SourceTable = '')
GO



SELECT 
    referencing_schema_name, referencing_entity_name, referencing_id, 
    referencing_class_desc, is_caller_dependent
FROM 
    sys.dm_sql_referencing_entities ('qs2.tblStay', 'OBJECT');
GO

select * from sysobjects where name = 's2_GetValveName'


/*
IF OBJECT_ID('[qs2].[tblRelationships]') IS NOT NULL
        DROP TABLE [qs2].[tblRelationship]
GO
*/

