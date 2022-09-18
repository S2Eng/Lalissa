using System;
using System.Collections.Generic;



namespace qs2.core
{

    public class Enums
    {

        public enum eStartTypeStayUI
        {
            Single = 132401,
            Thread = 132402,
            Process = 132403
        }

        public enum eLoadObjectFrom
        {
            ID = 10200,
            Dataset = 10201,
            Workflow = 10202
        }
        
        public enum eOPTyp
        {
            Surgery = 0,
            Complication = 1,
            ReOp = 2
        }
        public enum eStayTyp
        {
            Stay = 0,
            FollowUp = 1,
            All = 2
        }
        public enum eTypList
        {
            PROCGRP = 10100,
            CHAPTERS = 10101
        }

        public enum eTreeState
        {
            unknown = -1,
            no = 0,
            yes = 1
        }
        public enum eRights
        {
            //Must fit to SelList rights.Schlüsselzeichen
            rightQueries = 10,
            rightSetCompleted = 15,
            rightQueryReportOthers = 14,
            rightEditStay = 5,
            rightAddStay = 4,
            rightDeleteStay = 6,
            rightManageUsers = 16,
            rightReports = 11,
            rightQueryReportOwn = 12,
            rightEditFollowUp = 8,
            rightAddFollowUp = 7,
            rightDeleteFollowUp = 9,
            rightEditPatient = 2,
            rightAddPatient = 1,
            rightDeletePatient = 3,

            rightLoginNewUser = 108,
            rightChangePassword = 109,
            rightLockApplication = 110,
            rightLogManager = 111,
            rightTextEditor = 113,
            rigthProtocoll = 123,
            rightInformationSQLColumns = 114,
            rightManageRelationships = 115,
            rightManageCriterias = 116,
            rightManageResources = 117,
            rightManageQueries = 118,
            rightSelectLists = 119,
            rightServicesAndInterfaces = 120,
            rightLicenseInformation = 121,
            rightSettings = 122,
            rightExternalQueries = 100,

            
            rightResetSentStatusBatch = 101,
            rightSetRecordsCompletedBatch = 102,
            rightRecalculateBatch = 103,
            rightUploadAKHWien = 104,
            rightUploadKAV = 105,
            rightSendSTS = 106,
            rightSendEACTS = 107,
            rightQueryReportOwnPlusAssistenz = 124,
            rightManageKeyValues = 125,

            rightEditDocuments = 126,
            rightPrintDocuments = 127,

            rightNone = -100,
        }

        public enum eControlType
        {
            Textfield = 0,
            TextfieldMulti = 1,
            Numeric = 2,
            Integer = 17,
            ComboBox = 3,
            DateTime = 4,
            Date = 5,
            Time = 6,
            CheckBox = 7,
            ThreeStateCheckBox = 8,
            Label = 9,
            Picture = 10,
            GroupBox = 11,
            Tab = 13,
            TabPage = 14,
            AddButton = 15,
            GridMultiSelect = 16,
            ComboBoxCheckThreeStateBox = 18,

            TextfieldNoDb = 40,
            TextfieldMultiNoDb = 41,
            NumericNoDb = 42,
            IntegerNoDb = 43,
            ComboBoxNoDb = 44,
            DateTimeNoDb = 45,
            DateNoDb = 46,
            TimeNoDb = 47,
            CheckBoxNoDb = 48,
            ThreeStateCheckBoxNoDb = 49,
            ComboBoxAsDropDown = 50

        }
        public enum eTypeSub
        {
            User = 0,
            Supervisor = 1,
            None = 2

        }
        public enum ePrefix
        {
            auto = 0
        }
        public enum eResourceType
        {
            Label = 0,
            LabelRight = 1,
            LabelQuery = 10,
            ToolTip = 2,
            ErrorMessage = 3,
            ExportText = 4,

            PictureDisabled = 5,
            PictureEnabled = 6,
            PictureMouseOver = 7,

            Help = 8,

            ImageEnum = 9,

            None = 100,
            All = 101
        }

        public enum eTypeQuery
        {
            Admin = 0,
            User = 1
        }

        public enum eTypeReport
        {
            CrystalReport = 0,
            Pdf = 1,
            Table = 2
        }

        public enum eTypQueryDef
        {
            SelectFields = 0,
            InputParameters = 1,
            WhereConditions = 2,
            Joins = 3
        }
        public enum eSpecialDefinitionsMinValue
        {
            Today = 0,
            TodayMinus6Months = 1,
            BeginningOfTheYear = 2,
            BeginningOfTheMonth = 3,
            BeginningOfThePreviousYear = 5,
            DateToToday30DaysAgo = 6,
        }
        public enum eSpecialDefinitionsMaxValue
        {
            Today = 0,
            EndOfTheYear = 1,
            EndOfThePreviousYear = 2,
            EndOfTheMonth = 3,
            EndOfThePreviousMonth = 4,
            TodayMinus30Days = 5
        }
        public enum eSize
        {
            small = 0,
            big = 1
        }
        public enum eTypRunQuery
        {
            QueryGroups  = 0,
            ReportGroups = 1,
            DocumentGroups = 2
        }
        public enum eTypSubReport
        {
            MainReport = 0,
            SubReport = 1
        }
        public class cDoProdukt
        {
            public bool bOK = false;
            public bool bAbort = false;


            public System.Collections.Generic.List<cActionAfterSave> lstActionAfterSave = new List<cActionAfterSave>();
            public class cActionAfterSave
            {
                public eActionAfterSave ActionAfterSave = eActionAfterSave.None;
                public qs2.core.Enums.cDoProdukt.eMode Mode = eMode.Set;
            }
            public enum eActionAfterSave
            {
                AKHPrepareUpload = 0,
                KAVPrepareUpload = 1,
                print = 2,
                None = 100
            }
            public enum eVariablesPrint
            {
                StayReport_Caption = 0,
                StayReport_vidiert = 1,
                ActDate = 2,
                StayReport_HeadReplacement = 3,

                StayReport_HeadOrganisation = 10,
                StayReport_HeadOrganisation2 = 12058,
                StayReport_HeadHospital = 11,
                StayReport_HeadUnit = 12,
                StayReport_HeadChief = 13,
                StayReport_HeadZIP = 14,
                StayReport_HeadCity = 15,
                StayReport_HeadStreet = 16,
                StayReport_HeadTelephone = 17,
                StayReport_HeadFax = 18,

                eMail = 20,
                StayReport_HeadeMail = 21,
                StatusMedArchiv = 24,

                PatientName = 32,
                LastName = 33,
                Title = 34,
                FirstName = 35,
                DOB = 36,
                DOBDate = 37,
                Gender = 38,
                MedRecN = 39,
                MedRecNValue = 12057,
                
                Grouping = 49,
                Fields = 50,
                TitleSystemUser = 51,
                FirstNameSystemUser = 52,
                LastNameSystemUser = 53,
                StayReport_vidiertam = 54,

                StayReport_FootLeft = 80,
                Site = 85,

                StayReport_DocID = 92,
                DocID = 93,
                Document_Version = 94,
                Print2 = 95,
                DateTimeNow = 96,

                StayReport_HeadHospitalEng = 100,
                StayReport_HeadOrganisationEng = 101,
                StayReport_HeadUnitEng= 102,

                PNr = 103
            }

            public enum eMode
            {
                Set = 10400,
                Reset = 10401,
                None = 10499
            }

            public cDoProdukt()
            {
                this.bOK = false;
                this.bAbort = false;
                this.lstActionAfterSave.Clear();
            }
        }

        public enum eConditionTyp
        {
            Visible = 0,
            Invisible = 1,
            SelList = 2,
            ProcGroup = 3,
            CalcField = 4,
            LeaveField = 5,
            EditField = 6,
            Pictures = 7,
            VisibleGroups = 8,
            VisibleGroupsSetDefaultValue = 9
        }

        public enum eDoProduktMode
        {
            Save = 10300,
            Relation = 10301,
            Open = 10302
        }

        public enum eApplicationAutoStart
        {
            SearchPatient = 10500,
            UserDefinedQueries = 10501
        }

        public enum eTypCmdArg
        {
            log = 0,
            sys = 1,
            lic = 3,
            qs2 = 4,
            Supervisor = 5,
            Admin = 6,
            stay = 7,
            SimulatePMDS = 8,

            ConfigPath = 100,
            ConfigFile = 101,
            typ = 102,
            developerModus = 103,
            URIGuid = 104,
            DbConnStr = 105,
            SrvNr = 106,
            URIGuidSrv = 107,

            newStay = 109,
            IDGuidStay = 110,
            SaveWasClicked = 111,
            ShowAllStayTypes = 112,
            IDApplication = 113,
            StayTyp = 114,
            UserIDGuid = 115,
            PartID = 116,
            ProcessID = 117,
            LogPath = 118,

            MedRecN = 119,
            Participant = 120,
            Application = 121,
            UseStartupArgs = 122
        }

        public enum eTypeCallIpc
        {
            RefreshStayList = 0
        }

        public enum eSearchType
        {
            Simple = 0,
            STS = 1,
            EACTS = 2,
            KAV = 3,
            AKH = 4,
            Recalculate = 5,
            SetCompleted = 6,
            ResetSentStatus = 7,
            STSIncorrectlyStaysFromServer = 8,
            STSAndSTSIncorrectlyStaysFromServer = 9,
            ResetCompleted = 10

        }

        public enum eSearchInSubtables
        {
            CPBNumber = 0,
            IsCongenital = 1,
            IsAquired = 2,
            UnsentMedArchiv = 3
        }

        public enum eCalcMode
        {
            None = 0,
            Bulk = 1,
            Single = 2
        }

        public enum eLicense
        {
            LIC_CONGENITAL = 1,
            LIC_TAVI = 2,
            LIC_ARTAP = 3,
            LIC_FRAILTY_INDEX = 4,
            LIC_VALVES_EXTENSION = 5,
            LIC_CARDIO_TECH = 6,
            LIC_VAC = 7,
            LIC_AMBLER_SCORE = 8,
            LIC_FOLLOW_UPS = 9,
            LIC_AKH_INTERFACE = 10,         //Upload PDF, CDA, HL7
            LIC_KAV_INTERFACE = 11,         //MedArchiv und PatAuskunft
            LIC_HL7_BULK = 12,              //Bulk Import
            LIC_HL7_SOCKET = 13,            //Single Call by MedRecN
            LIC_STS = 14,
            LIC_IsMasterVersion = 15,
            LIC_VALID_DATE = 16,
            LIC_VASCULAR = 17,
            LIC_QUERYFROMMASTER = 18,
            LIC_QUERYFROMMASTER_DATE = 19,
            LIC_VASCULAR2 =20,
            LIC_KAV_MEDARCHIV = 21,          //MedArchiv
            LIC_KAV_PATAUSKUNFT = 22,       //PatAuskunft
            LIC_OLAP = 23,
            LIC_DOCUMENTS = 24,
            LIC_OLAP_VALID_DATE = 25,
            LIC_DOCUMENTS_VALID_DATE = 26,
            LIC_DEATH_STATUS_MODE_XLSX = 27,
        }

        public enum eLicenseType
        {
            typeBool = 1,
            typeInt = 2,
            typeString = 3,
            TypeDateTime = 4
        }

        public class cLicense
        {
            public eLicense License { get; set; }
            public string Name { get; set; }
            public qs2.core.Enums.eLicenseType LicenseType { get; set; }
            public bool bValue { get; set; }
            public int iValue { get; set; }
            public string sValue { get; set; }
            public DateTime dValue { get; set; }

            public override string ToString()
            {
                return string.Format("[{1} - {2} - {3} - {4}]", License, Name, LicenseType, bValue);
            }
        }


        public enum eClassifications
        {
            Logic = 0
        }



        public class cVariables
        {
            public string definition = "";
            public string value = "";
        }
        public enum cVariablesDefinition
        {
            ComboType = 0,
            IDOwnInt = 1,
            Visible = 2,
            DeputyCriteria = 3
        }
        public enum cVariablesValues
        {
            SelList = 245000,
            Roles = 245001,
            Sql = 245002,
            none = 245100
        }

        public enum iEuroSCOREVersion
        {
            AddEuroSCORE = 1,
            LogEuroSCORE = 2,
            EuroSCOREII = 3
        }

        public enum iSurgeonRole
        {
            Surgeon = 1,
            Cardiologist = 9,
            None = -2,
            SurgeonAndCardiologist = -3
        }

        public enum iCheckSurgeonRole
        {
            Surgeon = 1,
            All = 2
        }

        public enum eCompareMode
        {
            Equals = 1,
            StartsWith = 2,
            Contains = 3,
            EndsWith = 4
        }

    }
}
