using System;

namespace qs2.core
{

    public class Enums
    {
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
            PictureEnabled = 6,
            Help = 8,
            None = 100,
            All = 101
        }

        public enum eTypeQuery
        {
            Admin = 0,
            User = 1
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
            QueryGroups  = 0
        }

        public enum eTypSubReport
        {
            MainReport = 0,
            SubReport = 1
        }

        public enum eConditionTyp
        {
            Visible = 0,
            Invisible = 1,
            SelList = 2,
            VisibleGroups = 8,
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
