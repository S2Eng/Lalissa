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

        public class cVariables
        {
            public string definition = "";
            public string value = "";
        }

        public enum cVariablesDefinition
        {
            ComboType = 0,
            IDOwnInt = 1,
            Visible = 2
        }

        public enum cVariablesValues
        {
            SelList = 245000,
            Roles = 245001,
            Sql = 245002,
            none = 245100
        }
    }
}
