using qs2.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabs;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTabControl;

using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.FormattedLinkLabel;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinProgressBar;

namespace qs2.design.auto.workflowAssist.autoForm
{
    public class ColorSchemas
    {
        public bool IsInitialized = false;

        public enum eTypeUIPanel
        {
            PanelStayProcGrp = 0,
            PanelStayChapter = 1,
            PanelStayTopLeft = 2,
            PanelStayButtons = 3,
            PanelStayTopRight = 4,
            PanelStayTop = 5,
            Default = 6
        }

        public enum eTypeUIPanelWin
        {
            Default = 0,
            PanelWinInChapters = 1,
            PanelQueries = 2
        }

        public enum eTypeUIStayTab
        {
            MainTab = 0,
            TabsInChapters = 1,
            ProcGrp = 2,
            Chapters = 3,
            Default = 4
        }
        public enum eTypeButton
        {
            MainTop = 0,
            StayBottom = 1,
            StayBottomNoProtocol = 2,
            StayBottomProtocol = 3,
            Default = 4
        }
        public enum eTypeUserControl
        {
            MainTop = 0,
            Chapter = 1
        }
        public enum eTypeLabel
        {
            Default = 0,
            StayTopLeftInfo = 1,
            StayTopLeft = 2
        }


        //Styles for Panels
        public static System.Drawing.Color pnl_Maintop_BackColor;
        public static System.Drawing.Color pnl_BackColor;
        public static System.Drawing.Color pnl_StayBackColor;
        public static System.Drawing.Color pnl_StayProcGroup_BackColor;
        public static System.Drawing.Color pnl_StayChapter_BackColor;
        public static System.Drawing.Color pnl_StayTopLeft_BackColor;
        public static System.Drawing.Color pnl_StayBottom_BackColor;

        //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown
        public static System.Drawing.Color lbl_BackColorActive; //= Backgroundcolor
        public static System.Drawing.Color lbl_ForeColorActive;
        public static System.Drawing.Color lbl_BackColorInActive;
        public static System.Drawing.Color lbl_ForeColorInactive;

        public static System.Drawing.Color input_BackColor_Active;
        public static System.Drawing.Color input_BackColor_Inactive;
        public static System.Drawing.Color input_ForeColor_Active;
        public static System.Drawing.Color input_ForeColor_Inactive;
        public static System.Drawing.Color input_BorderColor;

        //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown in InfoTop
        public static System.Drawing.Color lbl_Top_BackColorActive; //= Backgroundcolor
        public static System.Drawing.Color lbl_Top_ForeColorActive;
        public static System.Drawing.Color lbl_Top_BackColorInActive;
        public static System.Drawing.Color lbl_Top_ForeColorInActive;

        public static System.Drawing.Color input_Top_BackColor_Active;
        public static System.Drawing.Color input_Top_BackColor_Inactive;
        public static System.Drawing.Color input_Top_ForeColor_Active;
        public static System.Drawing.Color input_Top_ForeColor_Inactive;
        public static System.Drawing.Color input_Top_BorderColor;

        //Styles for Groupboxes
        public static System.Drawing.Color grp_Header_BackColor;
        public static System.Drawing.Color grp_Header_ForeColor;
        public static float grp_Header_FontSize;
        public static Infragistics.Win.Misc.GroupBoxBorderStyle grp_Content_BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
        public static System.Drawing.Color grp_Content_BackColor;


        //Styles for Tabs und TabPages
        //TabHeader
        public static System.Drawing.Color tab_TabHeader_BackColor;
        public static System.Drawing.Color tab_TabHeader_BorderColor;
        //Selected Tabs
        public static System.Drawing.Color tab_Selected_BackColor;
        public static System.Drawing.Color tab_Selected_BorderColor;
        public static System.Drawing.Color tab_Selected_ForeColor;
        //not selected Tabs 
        public static System.Drawing.Color tab_NotSelected_BackColor;
        public static System.Drawing.Color tab_NotSelected_BorderColor;
        public static System.Drawing.Color tab_NotSelected_ForeColor;
        //Client Area
        public static System.Drawing.Color tab_ClientArea_BackColor;
        public static System.Drawing.Color tab_ClientArea_BorderColor;

        ////Styles for Push-Buttons
        //public static System.Drawing.Color btn_BackColor_Active;
        //public static System.Drawing.Color btn_ForeColor_Active;
        //public static System.Drawing.Color btn_BorderColor_Active;

        //public static System.Drawing.Color btn_BackColor_InActive;
        //public static System.Drawing.Color btn_ForeColor_InActive;
        //public static System.Drawing.Color btn_BorderColor_InActive;

        //public static System.Drawing.Color btn_BackColor_Active_HotTrack;
        //public static System.Drawing.Color btn_ForeColor_Active_HotTrack;
        //public static System.Drawing.Color btn_BorderColor_Active_HotTrack;

        //public static System.Drawing.Color btn_BackColor_InActive_HotTrack;
        //public static System.Drawing.Color btn_ForeColor_InActive_HotTrack;
        //public static System.Drawing.Color btn_BorderColor_InActive_HotTrack;

        //Styles for Buttons on Stay
        public static System.Drawing.Color colButtonStayActiveBorder;
        public static System.Drawing.Color colButtonStayActiveForeground;
        public static System.Drawing.Color colButtonStayActiveBackground;

        public static System.Drawing.Color colButtonStayInactiveBorder;
        public static System.Drawing.Color colButtonStayInactiveForeground;
        public static System.Drawing.Color colButtonStayInactiveBackground;

        public static System.Drawing.Color colButtonStayActiveHotTrackBorder;
        public static System.Drawing.Color colButtonStayActiveHotTrackForeground;
        public static System.Drawing.Color colButtonStayActiveHotTrackBackground;

        public static System.Drawing.Color colButtonStayInactiveHotTrackBorder;
        public static System.Drawing.Color colButtonStayInactiveHotTrackForeground;
        public static System.Drawing.Color colButtonStayInactiveHotTrackBackground;

        //Buttons on MainPage
        //active
        public static System.Drawing.Color colButtonMainActiveBorder;
        public static System.Drawing.Color colButtonMainActiveForeground;
        public static System.Drawing.Color colButtonMainActiveBackground;
        //inactive
        public static System.Drawing.Color colButtonMainInactiveBorder;
        public static System.Drawing.Color colButtonMainInactiveForeground;
        public static System.Drawing.Color colButtonMainInactiveBackground;
        //HotTrack-Active
        public static System.Drawing.Color colButtonMainActiveHotTrackBorder;
        public static System.Drawing.Color colButtonMainActiveHotTrackForeground;
        public static System.Drawing.Color colButtonMainActiveHotTrackBackground;
        //HotTrack-Inactive
        public static System.Drawing.Color colButtonMainInactiveHotTrackBorder;
        public static System.Drawing.Color colButtonMainInactiveHotTrackForeground;
        public static System.Drawing.Color colButtonMainInactiveHotTrackBackground;

        //Buttons on Query-Page
        //active
        public static System.Drawing.Color colButtonQueryActiveBorder;
        public static System.Drawing.Color colButtonQueryActiveForeground;
        public static System.Drawing.Color colButtonQueryActiveBackground;
        //inactive
        public static System.Drawing.Color colButtonQueryInactiveBorder;
        public static System.Drawing.Color colButtonQueryInactiveForeground;
        public static System.Drawing.Color colButtonQueryInactiveBackground;
        //HotTrack-Active
        public static System.Drawing.Color colButtonQueryActiveHotTrackBorder;
        public static System.Drawing.Color colButtonQueryActiveHotTrackForeground;
        public static System.Drawing.Color colButtonQueryActiveHotTrackBackground;
        //HotTrack-Inactive
        public static System.Drawing.Color colButtonQueryInactiveHotTrackBorder;
        public static System.Drawing.Color colButtonQueryInactiveHotTrackForeground;
        public static System.Drawing.Color colButtonQueryInactiveHotTrackBackground;

        //Procedure-Buttons
        //active
        public static System.Drawing.Color colButtonProcedureActiveBorder;
        public static System.Drawing.Color colButtonProcedureActiveForeground;
        public static System.Drawing.Color colButtonProcedureActiveBackground;
        //inactive
        public static System.Drawing.Color colButtonProcedureInactiveBorder;
        public static System.Drawing.Color colButtonProcedureInactiveForeground;
        public static System.Drawing.Color colButtonProcedureInactiveBackground;
        //HotTrack-Active
        public static System.Drawing.Color colButtonProcedureActiveHotTrackBorder;
        public static System.Drawing.Color colButtonProcedureActiveHotTrackForeground;
        public static System.Drawing.Color colButtonProcedureActiveHotTrackBackground;
        //HotTrack-Inactive
        public static System.Drawing.Color colButtonProcedureInactiveHotTrackBorder;
        public static System.Drawing.Color colButtonProcedureInactiveHotTrackForeground;
        public static System.Drawing.Color colButtonProcedureInactiveHotTrackBackground;

        //Chapter-Buttons
        //active
        public static System.Drawing.Color colButtonChapterActiveBorder;
        public static System.Drawing.Color colButtonChapterActiveForeground;
        public static System.Drawing.Color colButtonChapterActiveBackground;
        //inactive
        public static System.Drawing.Color colButtonChapterInactiveBorder;
        public static System.Drawing.Color colButtonChapterInactiveForeground;
        public static System.Drawing.Color colButtonChapterInactiveBackground;
        //HotTrack-Active
        public static System.Drawing.Color colButtonChapterActiveHotTrackBorder;
        public static System.Drawing.Color colButtonChapterActiveHotTrackForeground;
        public static System.Drawing.Color colButtonChapterActiveHotTrackBackground;
        //HotTrack-Inactive
        public static System.Drawing.Color colButtonChapterInactiveHotTrackBorder;
        public static System.Drawing.Color colButtonChapterInactiveHotTrackForeground;
        public static System.Drawing.Color colButtonChapterInactiveHotTrackBackground;

        public static void initColorSchemas()
        {
            if (!qs2.core.ENV.UseAppStylingDefault)
            {

                if (qs2.core.ENV.ColorSchema == 1)
                {
                    //Styles for Panels
                    ColorSchemas.pnl_BackColor = System.Drawing.Color.FromArgb(237, 238, 241);
                    ColorSchemas.pnl_Maintop_BackColor = System.Drawing.Color.FromArgb(66, 88, 125);
                    ColorSchemas.pnl_StayBackColor = System.Drawing.Color.White;
                    ColorSchemas.pnl_StayTopLeft_BackColor = System.Drawing.Color.FromArgb(66,88,125);
                    ColorSchemas.pnl_StayProcGroup_BackColor = System.Drawing.Color.FromArgb(81,103,140);    
                    ColorSchemas.pnl_StayChapter_BackColor = System.Drawing.Color.FromArgb(237,238,241);
                    ColorSchemas.pnl_StayBottom_BackColor = System.Drawing.Color.FromArgb(232, 233, 234);

                    //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown
                    //                    ColorSchemas.lbl_BackColorActive = System.Drawing.Color.FromArgb(239, 243, 251); //= Backgroundcolor hellblau
                    ColorSchemas.lbl_BackColorActive = System.Drawing.Color.Transparent;
                    ColorSchemas.lbl_ForeColorActive = System.Drawing.Color.Black;
                    ColorSchemas.lbl_BackColorInActive = lbl_BackColorActive;
                    ColorSchemas.lbl_ForeColorInactive = lbl_ForeColorActive;

                    ColorSchemas.input_BackColor_Active = System.Drawing.Color.White;
                    ColorSchemas.input_BackColor_Inactive = System.Drawing.Color.White;
                    ColorSchemas.input_ForeColor_Active = System.Drawing.Color.Black;
                    ColorSchemas.input_ForeColor_Inactive = System.Drawing.Color.Black;

                    //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown in InfoTop
                    ColorSchemas.lbl_Top_BackColorActive = System.Drawing.Color.Transparent;
                    ColorSchemas.lbl_Top_ForeColorActive = System.Drawing.Color.White;
                    ColorSchemas.lbl_Top_BackColorInActive = lbl_Top_BackColorActive;
                    ColorSchemas.lbl_Top_ForeColorInActive = lbl_Top_ForeColorActive;

                    ColorSchemas.input_Top_BackColor_Active = input_BackColor_Active;
                    ColorSchemas.input_Top_BackColor_Inactive = input_BackColor_Inactive;
                    ColorSchemas.input_Top_ForeColor_Active = input_ForeColor_Active;
                    ColorSchemas.input_Top_ForeColor_Inactive = input_ForeColor_Inactive;

                    //Styles for Groupboxes
                    ColorSchemas.grp_Header_BackColor = ColorSchemas.pnl_StayProcGroup_BackColor;  
                    ColorSchemas.grp_Header_ForeColor = System.Drawing.Color.White;
                    ColorSchemas.grp_Header_FontSize = 9F;
                    ColorSchemas.grp_Content_BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
                    ColorSchemas.grp_Content_BackColor = System.Drawing.Color.Transparent;

                    //Styles for Tabs und TabPages (von Groupbox-Farben abgeleitet)
                    //TabHeader
                    ColorSchemas.tab_TabHeader_BackColor = System.Drawing.Color.Transparent;
                    ColorSchemas.tab_TabHeader_BorderColor = System.Drawing.Color.Transparent;
                    //Selected Tabs
                    ColorSchemas.tab_Selected_BackColor = grp_Header_BackColor;
                    ColorSchemas.tab_Selected_BorderColor = grp_Header_BackColor;
                    ColorSchemas.tab_Selected_ForeColor = System.Drawing.Color.Black;
                    //not selected Tabs 
                    ColorSchemas.tab_NotSelected_BackColor = lbl_BackColorActive;
                    ColorSchemas.tab_NotSelected_BorderColor = lbl_BackColorActive;
                    ColorSchemas.tab_NotSelected_ForeColor = lbl_ForeColorActive;
                    //Client Area
                    ColorSchemas.tab_ClientArea_BackColor = grp_Content_BackColor;
                    ColorSchemas.tab_ClientArea_BorderColor = grp_Content_BackColor;


                    //Styles for Push-Buttons
                    /*
                    ColorSchemas.btn_BackColor_Active = System.Drawing.Color.FromArgb(112, 125, 148);
                    ColorSchemas.btn_ForeColor_Active = System.Drawing.Color.White;
                    ColorSchemas.btn_BorderColor_Active = ColorSchemas.btn_BackColor_Active;

                    ColorSchemas.btn_BackColor_InActive = System.Drawing.Color.Transparent;
                    ColorSchemas.btn_ForeColor_InActive = System.Drawing.Color.Black;
                    ColorSchemas.btn_BorderColor_InActive = ColorSchemas.btn_BackColor_InActive;

                    ColorSchemas.btn_BackColor_Active_HotTrack = ColorSchemas.btn_BackColor_Active;
                    ColorSchemas.btn_ForeColor_Active_HotTrack = ColorSchemas.btn_ForeColor_Active;
                    ColorSchemas.btn_BorderColor_Active_HotTrack = System.Drawing.Color.White;

                    ColorSchemas.btn_BackColor_InActive_HotTrack = ColorSchemas.btn_BackColor_InActive;
                    ColorSchemas.btn_ForeColor_InActive_HotTrack = ColorSchemas.btn_ForeColor_InActive;
                    ColorSchemas.btn_BorderColor_InActive_HotTrack = System.Drawing.Color.White;
                    */

                    //Styles for Buttons in Stay-Window    
                    ColorSchemas.colButtonStayActiveBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveBackground = System.Drawing.Color.FromArgb(202, 203, 204);

                    ColorSchemas.colButtonStayInactiveBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayInactiveForeground = System.Drawing.Color.DimGray;
                    ColorSchemas.colButtonStayInactiveBackground = ColorSchemas.pnl_StayBottom_BackColor;

                    ColorSchemas.colButtonStayActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveHotTrackForeground = ColorSchemas.colButtonStayActiveForeground;
                    ColorSchemas.colButtonStayActiveHotTrackBackground = ColorSchemas.colButtonStayActiveBackground;

                    ColorSchemas.colButtonStayInactiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonStayInactiveHotTrackForeground = ColorSchemas.colButtonStayInactiveForeground;
                    ColorSchemas.colButtonStayInactiveHotTrackBackground = ColorSchemas.colButtonStayInactiveBackground;


                    //Buttons on MainPage
                    ColorSchemas.colButtonMainActiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonMainActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonMainActiveBackground = System.Drawing.Color.FromArgb(255, 189, 71);    //orange

                    ColorSchemas.colButtonMainInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonMainInactiveForeground = System.Drawing.Color.White;
                    ColorSchemas.colButtonMainInactiveBackground = System.Drawing.Color.Transparent;

                    ColorSchemas.colButtonMainActiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonMainActiveHotTrackForeground = ColorSchemas.colButtonMainActiveForeground;
                    ColorSchemas.colButtonMainActiveHotTrackBackground = ColorSchemas.colButtonMainActiveBackground;

                    ColorSchemas.colButtonMainInactiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonMainInactiveHotTrackForeground = ColorSchemas.colButtonMainInactiveForeground;
                    ColorSchemas.colButtonMainInactiveHotTrackBackground = ColorSchemas.colButtonMainInactiveBackground;

                    //Buttons on Query-Page
                    ColorSchemas.colButtonQueryActiveBorder = System.Drawing.Color.FromArgb(255, 189, 71);    //orange;
                    ColorSchemas.colButtonQueryActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryActiveBackground = System.Drawing.Color.FromArgb(255, 239, 210);

                    ColorSchemas.colButtonQueryInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonQueryInactiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryInactiveBackground = System.Drawing.Color.Transparent;

                    ColorSchemas.colButtonQueryActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryActiveHotTrackForeground = ColorSchemas.colButtonQueryActiveForeground;
                    ColorSchemas.colButtonQueryActiveHotTrackBackground = ColorSchemas.colButtonQueryActiveBackground;

                    ColorSchemas.colButtonQueryInactiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryInactiveHotTrackForeground = ColorSchemas.colButtonQueryInactiveForeground;
                    ColorSchemas.colButtonQueryInactiveHotTrackBackground = ColorSchemas.colButtonQueryInactiveBackground;

                    //ProcedureGroups
                    ColorSchemas.colButtonProcedureActiveBorder = System.Drawing.Color.FromArgb(255,189,71);
                    ColorSchemas.colButtonProcedureActiveForeground = System.Drawing.Color.White;
                    ColorSchemas.colButtonProcedureActiveBackground = System.Drawing.Color.FromArgb(66,88,125);  //dunkelblau

                    ColorSchemas.colButtonProcedureInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonProcedureInactiveForeground = System.Drawing.Color.FromArgb(191, 187, 219);   //inaktive Schriftfarbe
                    ColorSchemas.colButtonProcedureInactiveBackground = ColorSchemas.pnl_StayProcGroup_BackColor;  

                    ColorSchemas.colButtonProcedureActiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonProcedureActiveHotTrackForeground = System.Drawing.Color.White;
                    ColorSchemas.colButtonProcedureActiveHotTrackBackground = ColorSchemas.colButtonProcedureActiveBackground;

                    ColorSchemas.colButtonProcedureInactiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonProcedureInactiveHotTrackForeground = System.Drawing.Color.White;
                    ColorSchemas.colButtonProcedureInactiveHotTrackBackground = ColorSchemas.colButtonProcedureInactiveBackground;

                    //Chapters
                    ColorSchemas.colButtonChapterActiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonChapterActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterActiveBackground = System.Drawing.Color.FromArgb(255, 189,71);    //orange


                    ColorSchemas.colButtonChapterInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonChapterInactiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterInactiveBackground = ColorSchemas.pnl_StayChapter_BackColor;

                    ColorSchemas.colButtonChapterActiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonChapterActiveHotTrackForeground = ColorSchemas.colButtonChapterActiveForeground;
                    ColorSchemas.colButtonChapterActiveHotTrackBackground = ColorSchemas.colButtonChapterActiveBackground;

                    ColorSchemas.colButtonChapterInactiveHotTrackBorder = ColorSchemas.colButtonChapterActiveBackground;
                    ColorSchemas.colButtonChapterInactiveHotTrackForeground = ColorSchemas.colButtonChapterInactiveForeground;
                    ColorSchemas.colButtonChapterInactiveHotTrackBackground = ColorSchemas.colButtonChapterInactiveBackground;
                }
                else if (qs2.core.ENV.ColorSchema == 2)
                {
                    //Styles for Panels
                    ColorSchemas.pnl_Maintop_BackColor = System.Drawing.Color.FromArgb(224, 227, 231);
                    ColorSchemas.pnl_BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    ColorSchemas.pnl_StayBackColor = System.Drawing.Color.White;
                    ColorSchemas.pnl_StayTopLeft_BackColor = ColorSchemas.pnl_Maintop_BackColor;
                    ColorSchemas.pnl_StayProcGroup_BackColor = ColorSchemas.pnl_BackColor;
                    ColorSchemas.pnl_StayChapter_BackColor = ColorSchemas.pnl_StayProcGroup_BackColor;
                    ColorSchemas.pnl_StayBottom_BackColor = ColorSchemas.pnl_StayTopLeft_BackColor;

                    //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown
                    ColorSchemas.lbl_BackColorActive = System.Drawing.Color.Transparent;
                    ColorSchemas.lbl_ForeColorActive = System.Drawing.Color.Black;
                    ColorSchemas.lbl_BackColorInActive = lbl_BackColorActive;
                    ColorSchemas.lbl_ForeColorInactive = lbl_ForeColorActive;

                    ColorSchemas.input_BackColor_Active = System.Drawing.Color.White;
                    ColorSchemas.input_BackColor_Inactive = System.Drawing.Color.White;
                    ColorSchemas.input_ForeColor_Active = System.Drawing.Color.Black;
                    ColorSchemas.input_ForeColor_Inactive = System.Drawing.Color.Black;

                    //Styles for Text, Numeric, Integer, Date, DateTime, Time, DropDown in InfoTop
                    ColorSchemas.lbl_Top_BackColorActive = System.Drawing.Color.Transparent;
                    ColorSchemas.lbl_Top_ForeColorActive = System.Drawing.Color.Black;
                    ColorSchemas.lbl_Top_BackColorInActive = lbl_Top_BackColorActive;
                    ColorSchemas.lbl_Top_ForeColorInActive = lbl_Top_ForeColorActive;

                    ColorSchemas.input_Top_BackColor_Active = input_BackColor_Active;
                    ColorSchemas.input_Top_BackColor_Inactive = input_BackColor_Inactive;
                    ColorSchemas.input_Top_ForeColor_Active = input_ForeColor_Active;
                    ColorSchemas.input_Top_ForeColor_Inactive = input_ForeColor_Inactive;

                    //Styles for Groupboxes
                    ColorSchemas.grp_Header_BackColor = ColorSchemas.pnl_StayTopLeft_BackColor;
                    ColorSchemas.grp_Header_ForeColor = System.Drawing.Color.Black;
                    ColorSchemas.grp_Header_FontSize = 9F;
                    ColorSchemas.grp_Content_BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
                    ColorSchemas.grp_Content_BackColor = System.Drawing.Color.Transparent;

                    //Styles for Tabs und TabPages (von Groupbox-Farben abgeleitet)
                    //TabHeader
                    ColorSchemas.tab_TabHeader_BackColor = System.Drawing.Color.Transparent;
                    ColorSchemas.tab_TabHeader_BorderColor = System.Drawing.Color.Transparent;
                    //Selected Tabs
                    ColorSchemas.tab_Selected_BackColor = grp_Header_BackColor;
                    ColorSchemas.tab_Selected_BorderColor = grp_Header_BackColor;
                    ColorSchemas.tab_Selected_ForeColor = System.Drawing.Color.Black;
                    //not selected Tabs 
                    ColorSchemas.tab_NotSelected_BackColor = lbl_BackColorActive;
                    ColorSchemas.tab_NotSelected_BorderColor = lbl_BackColorActive;
                    ColorSchemas.tab_NotSelected_ForeColor = lbl_ForeColorActive;
                    //Client Area
                    ColorSchemas.tab_ClientArea_BackColor = grp_Content_BackColor;
                    ColorSchemas.tab_ClientArea_BorderColor = grp_Content_BackColor;

                    //Styles for Push-Buttons
                    //ColorSchemas.btn_BackColor_Active = System.Drawing.Color.FromArgb(112, 125, 148);
                    //ColorSchemas.btn_ForeColor_Active = System.Drawing.Color.White;
                    //ColorSchemas.btn_BorderColor_Active = ColorSchemas.btn_BackColor_Active;

                    //ColorSchemas.btn_BackColor_InActive = System.Drawing.Color.Transparent;
                    //ColorSchemas.btn_ForeColor_InActive = System.Drawing.Color.Black;
                    //ColorSchemas.btn_BorderColor_InActive = ColorSchemas.btn_BackColor_InActive;

                    //ColorSchemas.btn_BackColor_Active_HotTrack = ColorSchemas.btn_BackColor_Active;
                    //ColorSchemas.btn_ForeColor_Active_HotTrack = ColorSchemas.btn_ForeColor_Active;
                    //ColorSchemas.btn_BorderColor_Active_HotTrack = System.Drawing.Color.White;

                    //ColorSchemas.btn_BackColor_InActive_HotTrack = ColorSchemas.btn_BackColor_InActive;
                    //ColorSchemas.btn_ForeColor_InActive_HotTrack = ColorSchemas.btn_ForeColor_InActive;
                    //ColorSchemas.btn_BorderColor_InActive_HotTrack = System.Drawing.Color.White; ;

                    //Styles for Buttons in Stay-Window    
                    ColorSchemas.colButtonStayActiveBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveBackground = System.Drawing.Color.FromArgb(202, 203, 204);

                    ColorSchemas.colButtonStayInactiveBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayInactiveForeground = System.Drawing.Color.DimGray;
                    ColorSchemas.colButtonStayInactiveBackground = ColorSchemas.pnl_StayBottom_BackColor;

                    ColorSchemas.colButtonStayActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonStayActiveHotTrackForeground = ColorSchemas.colButtonStayActiveForeground;
                    ColorSchemas.colButtonStayActiveHotTrackBackground = ColorSchemas.colButtonStayActiveBackground;

                    ColorSchemas.colButtonStayInactiveHotTrackBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonStayInactiveHotTrackForeground = ColorSchemas.colButtonStayInactiveForeground;
                    ColorSchemas.colButtonStayInactiveHotTrackBackground = ColorSchemas.colButtonStayInactiveBackground;

                    //Buttons on MainPage
                    ColorSchemas.colButtonMainActiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonMainActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonMainActiveBackground = System.Drawing.Color.FromArgb(254, 189, 73);    //orange

                    ColorSchemas.colButtonMainInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonMainInactiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonMainInactiveBackground = ColorSchemas.pnl_Maintop_BackColor;

                    ColorSchemas.colButtonMainActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonMainActiveHotTrackForeground = ColorSchemas.colButtonMainActiveForeground;
                    ColorSchemas.colButtonMainActiveHotTrackBackground = ColorSchemas.colButtonMainActiveBackground;

                    ColorSchemas.colButtonMainInactiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonMainInactiveHotTrackForeground = ColorSchemas.colButtonMainActiveHotTrackForeground;
                    ColorSchemas.colButtonMainInactiveHotTrackBackground = ColorSchemas.colButtonMainActiveHotTrackBackground;

                    //Buttons on Query-Page
                    ColorSchemas.colButtonQueryActiveBorder = System.Drawing.Color.FromArgb(255, 189, 71);    //orange;
                    ColorSchemas.colButtonQueryActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryActiveBackground = System.Drawing.Color.FromArgb(255, 239, 210);

                    ColorSchemas.colButtonQueryInactiveBorder = System.Drawing.Color.White;
                    ColorSchemas.colButtonQueryInactiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryInactiveBackground = ColorSchemas.pnl_StayChapter_BackColor;

                    ColorSchemas.colButtonQueryActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryActiveHotTrackForeground = ColorSchemas.colButtonQueryActiveForeground;
                    ColorSchemas.colButtonQueryActiveHotTrackBackground = ColorSchemas.colButtonQueryActiveBackground;

                    ColorSchemas.colButtonQueryInactiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonQueryInactiveHotTrackForeground = ColorSchemas.colButtonQueryInactiveForeground;
                    ColorSchemas.colButtonQueryInactiveHotTrackBackground = ColorSchemas.colButtonQueryInactiveBackground;

                    //ProcedureGroups
                    ColorSchemas.colButtonProcedureActiveBorder = ColorSchemas.colButtonQueryActiveBorder;
                    ColorSchemas.colButtonProcedureActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonProcedureActiveBackground = System.Drawing.Color.FromArgb(255,239,210);  

                    ColorSchemas.colButtonProcedureInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonProcedureInactiveForeground = System.Drawing.Color.FromArgb(145,146,147);   //inaktive Schriftfarbe
                    ColorSchemas.colButtonProcedureInactiveBackground = ColorSchemas.pnl_StayChapter_BackColor;  

                    ColorSchemas.colButtonProcedureActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonProcedureActiveHotTrackForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonProcedureActiveHotTrackBackground = ColorSchemas.colButtonProcedureActiveBackground;

                    ColorSchemas.colButtonProcedureInactiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonProcedureInactiveHotTrackForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonProcedureInactiveHotTrackBackground = ColorSchemas.colButtonProcedureInactiveBackground;

                    //Chapters
                    ColorSchemas.colButtonChapterActiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonChapterActiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterActiveBackground = System.Drawing.Color.FromArgb(254,189,73);    //orange

                    ColorSchemas.colButtonChapterInactiveBorder = System.Drawing.Color.Transparent;
                    ColorSchemas.colButtonChapterInactiveForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterInactiveBackground = System.Drawing.Color.Transparent;

                    ColorSchemas.colButtonChapterActiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterActiveHotTrackForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterActiveHotTrackBackground = ColorSchemas.colButtonChapterActiveBackground;

                    ColorSchemas.colButtonChapterInactiveHotTrackBorder = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterInactiveHotTrackForeground = System.Drawing.Color.Black;
                    ColorSchemas.colButtonChapterInactiveHotTrackBackground = ColorSchemas.colButtonChapterInactiveBackground;
                }
            }
            else     //Default
            {               
                //Buttons on MainPage
                ColorSchemas.colButtonMainActiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonMainActiveForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonMainActiveBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonMainInactiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonMainInactiveForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonMainInactiveBackground = System.Drawing.Color.WhiteSmoke;

                ColorSchemas.colButtonMainActiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonMainActiveHotTrackForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonMainActiveHotTrackBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonMainInactiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonMainInactiveHotTrackForeground = System.Drawing.Color.Blue;
                ColorSchemas.colButtonMainInactiveHotTrackBackground = System.Drawing.Color.WhiteSmoke;

                //Buttons on Query-Page
                ColorSchemas.colButtonQueryActiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonQueryActiveForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonQueryActiveBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonQueryInactiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonQueryInactiveForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonQueryInactiveBackground = System.Drawing.Color.WhiteSmoke;

                ColorSchemas.colButtonQueryActiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonQueryActiveHotTrackForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonQueryActiveHotTrackBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonQueryInactiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonQueryInactiveHotTrackForeground = System.Drawing.Color.Blue;
                ColorSchemas.colButtonQueryInactiveHotTrackBackground = System.Drawing.Color.WhiteSmoke;

                //ProcedureGroups
                ColorSchemas.colButtonProcedureActiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonProcedureActiveForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonProcedureActiveBackground = System.Drawing.Color.DarkCyan;

                ColorSchemas.colButtonProcedureInactiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonProcedureInactiveForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonProcedureInactiveBackground = System.Drawing.Color.PowderBlue;

                ColorSchemas.colButtonProcedureActiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonProcedureActiveHotTrackForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonProcedureActiveHotTrackBackground = System.Drawing.Color.DarkCyan;

                ColorSchemas.colButtonProcedureInactiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonProcedureInactiveHotTrackForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonProcedureInactiveHotTrackBackground = System.Drawing.Color.PowderBlue;

                //Chapters
                ColorSchemas.colButtonChapterActiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonChapterActiveForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonChapterActiveBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonChapterInactiveBorder = System.Drawing.Color.Transparent;
                ColorSchemas.colButtonChapterInactiveForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonChapterInactiveBackground = System.Drawing.Color.Lavender;

                ColorSchemas.colButtonChapterActiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonChapterActiveHotTrackForeground = System.Drawing.Color.White;
                ColorSchemas.colButtonChapterActiveHotTrackBackground = System.Drawing.Color.SteelBlue;

                ColorSchemas.colButtonChapterInactiveHotTrackBorder = System.Drawing.Color.White;
                ColorSchemas.colButtonChapterInactiveHotTrackForeground = System.Drawing.Color.Black;
                ColorSchemas.colButtonChapterInactiveHotTrackBackground = System.Drawing.Color.Lavender;
            }

        }

        public void setAppearanceMC(qs2.design.auto.multiControl.ownMultiControl mc,
                                    qs2.design.auto.multiControl.ownGroupBox grp,
                                    qs2.design.auto.multiControl.ownTab tab,
                                    Enums.eControlType OwnControlType)
        {

            string exceptInfo = "";
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                eTypeLabel TypeLabel = eTypeLabel.Default;
                bool InfoTop = false;
                if (mc != null)
                {
                    InfoTop = mc.OwnInfoTop;
                    if (InfoTop)
                        TypeLabel = eTypeLabel.StayTopLeft;
                    exceptInfo = mc.OwnFldShort + "-" + mc.OwnControlType.ToString();
                }
                else if (grp != null)
                {
                    exceptInfo = grp.OwnFldShort + "-" + OwnControlType.ToString();
                }
                else if(tab != null)
                {
                    exceptInfo = tab.OwnFldShort + "-" + OwnControlType.ToString();
                }

                if (this.IsInitialized)
                {
                    return;
                }



                if (mc != null)
                {
                    this.setAppearanceLabel(mc.infragLabelLeft, TypeLabel);
                    this.setAppearanceLabel(mc.infragLabelRight, TypeLabel);
                }


                if (OwnControlType == Enums.eControlType.CheckBox || OwnControlType == Enums.eControlType.CheckBoxNoDb)
                {
                    this.setAppearanceCheckBox(mc.CheckBox, InfoTop);
                }
                else if (OwnControlType == Enums.eControlType.Numeric || OwnControlType == Enums.eControlType.NumericNoDb)
                {
                    this.setAppearanceNumeric(mc.Numeric, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Integer || OwnControlType == Enums.eControlType.IntegerNoDb)
                {
                    this.setAppearanceNumeric(mc.Numeric, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Textfield || OwnControlType == Enums.eControlType.TextfieldNoDb)
                {
                    this.setAppearanceTextfield(mc.Textfield, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.TextfieldMulti || OwnControlType == Enums.eControlType.TextfieldMultiNoDb)
                {
                    this.setAppearanceMultiTextfield(mc.TextfieldMulti, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.ComboBox || OwnControlType == Enums.eControlType.ComboBoxNoDb)
                {
                    this.setAppearanceComboBox(mc.ComboBox, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Date || OwnControlType == Enums.eControlType.DateNoDb)
                {
                    this.setAppearanceDateTime(mc.Date, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Time || OwnControlType == Enums.eControlType.TimeNoDb)
                {
                    this.setAppearanceDateTime(mc.Time, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.DateTime || OwnControlType == Enums.eControlType.DateTimeNoDb)
                {
                    this.setAppearanceDateTime(mc.DateTime, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Label)
                {
                    this.setAppearanceLabel(mc.infragLabelLeft, TypeLabel);

                }
                else if (OwnControlType == Enums.eControlType.ThreeStateCheckBox || OwnControlType == Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    this.setAppearanceCheckBox(mc.ThreeStateCheckBox, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.GroupBox)
                {
                    this.setAppearanceGroupBox(grp, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Tab)
                {
                    this.setAppearanceTab(tab, eTypeUIStayTab.TabsInChapters, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.Picture)
                {
                    this.setAppearancePicture(mc.Picture, InfoTop);

                }
                // only in Query-System
                else if (OwnControlType == Enums.eControlType.ComboBoxAsDropDown)
                {
                    this.setAppearanceComboBoxAsDropDown(mc.DropDown, InfoTop);

                }
                else if (OwnControlType == Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    this.setAppearanceComboBox(mc.ComboBox, InfoTop);

                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceMC: " + exceptInfo + "\r\n" + ex.ToString());
            }
        }

        public void setAppearanceCheckBox(UltraCheckEditor chk, bool InfoTop)
        {
            try
            {

                return; //os220609

                //if (qs2.core.ENV.UseAppStylingDefault == true)
                //    return;

                //chk.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                //chk.UseFlatMode = DefaultableBoolean.True;
                
                //if (InfoTop == false)
                //{
                //    chk.Appearance.BackColorDisabled = System.Drawing.Color.Transparent;
                //    chk.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                //    chk.Appearance.BackColor = System.Drawing.Color.Transparent;
                //    chk.Appearance.ForeColor = input_ForeColor_Active;
                //    chk.BackColor = System.Drawing.Color.Transparent;
                //}
                //else
                //{
                //    chk.Appearance.BackColorDisabled = System.Drawing.Color.Transparent;
                //    chk.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                //    chk.Appearance.BackColor = System.Drawing.Color.Transparent;
                //    chk.Appearance.ForeColor = input_ForeColor_Active;
                //    chk.BackColor = System.Drawing.Color.Transparent;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceCheckBox: " + ex.ToString());
            }
        }
        public void setAppearanceCheckBoxWin(CheckBox chk, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceCheckBoxWin: " + ex.ToString());
            }
        }
        public void setAppearanceNumeric(UltraNumericEditor num, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                num.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                num.UseOsThemes = DefaultableBoolean.False;
                num.BorderStyle = UIElementBorderStyle.Solid;
                num.UseFlatMode = DefaultableBoolean.True;

                if (InfoTop == false)
                {
                    num.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    num.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    num.Appearance.BackColor = input_BackColor_Active;
                    num.Appearance.ForeColor = input_ForeColor_Active;
                }
                else
                {
                    num.Appearance.BackColorDisabled = input_Top_BackColor_Inactive;
                    num.Appearance.ForeColorDisabled = input_Top_ForeColor_Inactive;
                    num.Appearance.BackColor = input_Top_BackColor_Active;
                    num.Appearance.ForeColor = input_Top_ForeColor_Active;
                    num.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceNumeric: " + ex.ToString());
            }
        }
        public void setAppearanceMultiTextfield(UltraFormattedTextEditor txt, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                txt.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                txt.UseOsThemes = DefaultableBoolean.False;
                txt.BorderStyle = UIElementBorderStyle.Solid;
                txt.UseFlatMode = DefaultableBoolean.True;

                if (InfoTop == false)
                {
                    txt.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    txt.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    txt.Appearance.BackColor = input_BackColor_Active;
                    txt.Appearance.ForeColor = input_ForeColor_Active;
                }
                else
                {
                    txt.Appearance.BackColorDisabled = input_Top_BackColor_Inactive;
                    txt.Appearance.ForeColorDisabled = input_Top_ForeColor_Inactive;
                    txt.Appearance.BackColor = input_Top_BackColor_Active;
                    txt.Appearance.ForeColor = input_Top_ForeColor_Active;
                    txt.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTextfield: " + ex.ToString());
            }
        }
        public void setAppearanceTextfield(UltraTextEditor txt, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                txt.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                txt.UseOsThemes = DefaultableBoolean.False;
                txt.BorderStyle = UIElementBorderStyle.Solid;
                txt.UseFlatMode = DefaultableBoolean.True;

                if (InfoTop == false)
                {
                    txt.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    txt.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    txt.Appearance.BackColor = input_BackColor_Active;
                    txt.Appearance.ForeColor = input_ForeColor_Active;
                }
                else
                {
                    txt.Appearance.BackColorDisabled = input_Top_BackColor_Inactive;
                    txt.Appearance.ForeColorDisabled = input_Top_ForeColor_Inactive;
                    txt.Appearance.BackColor = input_Top_BackColor_Active;
                    txt.Appearance.ForeColor = input_Top_ForeColor_Active;
                    txt.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTextfield: " + ex.ToString());
            }
        }
        public void setAppearanceRichTextBox(RichTextBox richTxt, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceRichTextBox: " + ex.ToString());
            }
        }
        public void setAppearanceComboBox(UltraComboEditor cbo, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                cbo.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                cbo.UseOsThemes = DefaultableBoolean.False;
                cbo.BorderStyle = UIElementBorderStyle.Solid;
                cbo.UseFlatMode = DefaultableBoolean.True;

                if (InfoTop == false)
                {
                    cbo.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    cbo.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    cbo.Appearance.BackColor = input_BackColor_Active;
                    cbo.Appearance.ForeColor = input_ForeColor_Active;
                }
                else
                {
                    cbo.Appearance.BackColorDisabled = input_Top_BackColor_Inactive;
                    cbo.Appearance.ForeColorDisabled = input_Top_ForeColor_Inactive;
                    cbo.Appearance.BackColor = input_Top_BackColor_Active;
                    cbo.Appearance.ForeColor = input_Top_ForeColor_Active;
                    cbo.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceComboBox: " + ex.ToString());
            }
        }
        public void setAppearanceCombo(UltraCombo cbo, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceCombo: " + ex.ToString());
            }
        }
        public void setAppearanceComboApplication(qs2.sitemap.comboApplication cboApp, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceComboApplication: " + ex.ToString());
            }
        }
        public void setAppearanceDateTime(UltraDateTimeEditor dat, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                dat.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                dat.UseOsThemes = DefaultableBoolean.False;            
                dat.BorderStyle = UIElementBorderStyle.Solid;
                dat.UseFlatMode = DefaultableBoolean.True;

                if (InfoTop == false)
                {
                    dat.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    dat.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    dat.Appearance.BackColor = input_BackColor_Active;
                    dat.Appearance.ForeColor = input_ForeColor_Active;
                }
                else
                {
                    dat.Appearance.BackColorDisabled = input_BackColor_Inactive;
                    dat.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                    dat.Appearance.BackColor = input_BackColor_Active;
                    dat.Appearance.ForeColor = input_ForeColor_Active;
                    dat.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceDateTime: " + ex.ToString());
            }
        }
        public void setAppearanceLabel(UltraLabel lbl, eTypeLabel TypeLabel)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                lbl.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                lbl.UseOsThemes = DefaultableBoolean.False;
                lbl.UseFlatMode = DefaultableBoolean.True;

                if (TypeLabel == eTypeLabel.Default)
                {
                    lbl.Appearance.BackColor = lbl_BackColorActive;
                    lbl.Appearance.ForeColor = lbl_ForeColorActive;
                    lbl.Appearance.ForeColorDisabled = lbl_BackColorInActive;
                    lbl.Appearance.ForeColorDisabled = lbl_ForeColorInactive;
                }
                else if (TypeLabel == eTypeLabel.StayTopLeft)
                {
                    lbl.Appearance.BackColor = lbl_Top_BackColorActive;
                    lbl.Appearance.ForeColor = lbl_Top_ForeColorActive;
                    lbl.Appearance.ForeColorDisabled = lbl_Top_BackColorInActive;
                    lbl.Appearance.ForeColorDisabled = lbl_Top_ForeColorInActive;
                }
                else if (TypeLabel == eTypeLabel.StayTopLeftInfo)
                {
                    lbl.Appearance.BackColor = lbl_Top_BackColorActive;
                    lbl.Appearance.ForeColor = lbl_Top_ForeColorActive;
                    lbl.Appearance.ForeColorDisabled = lbl_Top_BackColorInActive;
                    lbl.Appearance.ForeColorDisabled = lbl_Top_ForeColorInActive;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceLabel: " + ex.ToString());
            }
        }
        public void setAppearanceLabelWin(Label lbl, eTypeLabel TypeLabel)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceLabelWin: " + ex.ToString());
            }
        }
        public void setAppearanceFormattedLinkLabel(UltraFormattedLinkLabel linkLbl, eTypeLabel TypeLabel)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceFormattedLinkLabel: " + ex.ToString());
            }
        }
        public void setAppearanceGroupBox(UltraGroupBox grp, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                grp.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                grp.UseOsThemes = DefaultableBoolean.False;
                grp.BorderStyle = GroupBoxBorderStyle.None;
                grp.UseFlatMode = DefaultableBoolean.True;

                Infragistics.Win.Appearance appearanceGrp = new Infragistics.Win.Appearance();
                appearanceGrp.BackColor = grp_Content_BackColor;
                appearanceGrp.BackColorDisabled = grp_Content_BackColor;
                appearanceGrp.BackColorAlpha = Alpha.Default;
                grp.Appearance = appearanceGrp; 

                Infragistics.Win.Appearance appearanceHeader = new Infragistics.Win.Appearance();
                appearanceHeader.BackColor = grp_Header_BackColor;
                appearanceHeader.BackColorDisabled = grp_Header_BackColor;
                appearanceHeader.ForeColor = grp_Header_ForeColor;
                appearanceHeader.FontData.SizeInPoints = grp_Header_FontSize;
                grp.HeaderAppearance = appearanceHeader;

                Infragistics.Win.Appearance appearanceContent = new Infragistics.Win.Appearance();
                grp.BorderStyle = grp_Content_BorderStyle;
                appearanceContent.BackColor = pnl_BackColor;
                grp.ContentAreaAppearance = appearanceContent;
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceGroupBox: " + ex.ToString());
            }
        }
        public void setAppearanceTab(UltraTabControl tab, eTypeUIStayTab TypeUIStayTab, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                tab.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;

                if (TypeUIStayTab == eTypeUIStayTab.ProcGrp || TypeUIStayTab == eTypeUIStayTab.Chapters || TypeUIStayTab == eTypeUIStayTab.MainTab)
                {
                    tab.Style = UltraTabControlStyle.Wizard;
                }
                if (TypeUIStayTab == eTypeUIStayTab.TabsInChapters)
                {
                    tab.Style = UltraTabControlStyle.Flat;
                }

                if (qs2.core.ENV.UseAppStylingDefault == true)
                {
                    tab.ClientAreaAppearance.BackColor = System.Drawing.Color.Transparent;
                    tab.ClientAreaAppearance.BorderColor = System.Drawing.Color.Transparent;

                    tab.Appearance.BackColor = System.Drawing.Color.Transparent;
                    tab.Appearance.BorderColor = System.Drawing.Color.Transparent;

                    return;
                }

                
                tab.UseOsThemes = DefaultableBoolean.False;
                tab.UseFlatMode = DefaultableBoolean.True;

                tab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Default;

                tab.TabHeaderAreaAppearance.BackColor = tab_TabHeader_BackColor;
                tab.TabHeaderAreaAppearance.BorderColor = tab_TabHeader_BorderColor;

                tab.SelectedTabAppearance.BackColor = colButtonChapterActiveBackground;
                tab.SelectedTabAppearance.BorderColor = colButtonChapterActiveBackground;
                tab.SelectedTabAppearance.ForeColor = tab_Selected_ForeColor;

                //not selected Tabs
                tab.Appearance.BackColor = tab_NotSelected_BackColor;
                tab.Appearance.BorderColor = tab_NotSelected_BorderColor;
                tab.Appearance.ForeColor = tab_NotSelected_ForeColor;

                tab.ClientAreaAppearance.BackColor = tab_ClientArea_BackColor;
                tab.ClientAreaAppearance.BorderColor = tab_ClientArea_BorderColor;

                foreach (UltraTab tabPage in tab.Tabs)
                {
                    this.setAppearanceTabPage(tabPage, InfoTop);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTab: " + ex.ToString());
            }
        }
        public void setAppearanceTabPage(UltraTab tabPage, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                //tabPage.ClientAreaAppearance.BackColor = ColorSchemas.lbl_BackColorActive;
 
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTabPage: " + ex.ToString());
            }
        }
        public void setAppearanceTabPageControl(UltraTabPageControl tabPageCont, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTabPageControl: " + ex.ToString());
            }
        }
        public void setAppearanceTabSharedControlsPage(UltraTabSharedControlsPage SharedTabPage, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTabSharedControlsPage: " + ex.ToString());
            }
        }
        public void setAppearanceGrid(UltraGrid grid, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceGrid: " + ex.ToString());
            }
        }
        public void setAppearanceGridBag(UltraGridBagLayoutPanel gridBag, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;
                                

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceGridBag: " + ex.ToString());
            }
        }
        public void setAppearanceDropDownBase(UltraDropDownBase DropDownBase, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceDropDownBase: " + ex.ToString());
            }
        }
        public void setAppearanceMenüStrip(MenuStrip menüStrip, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceMenüStrip: " + ex.ToString());
            }
        }
        public void setAppearanceToolStrip(ToolStrip toolStrip, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceToolStrip: " + ex.ToString());
            }
        }
        public void setAppearanceStatusBar(UltraStatusBar statusBar, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceStatusBar: " + ex.ToString());
            }
        }
        public void setAppearancePicture(UltraPictureBox pic, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                pic.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearancePicture: " + ex.ToString());
            }
        }
        public void setAppearancePictureWin(PictureBox pic, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearancePictureWin: " + ex.ToString());
            }
        }
        public void setAppearanceProgressBar(UltraProgressBar progBar, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceProgressBar: " + ex.ToString());
            }
        }
        public void setAppearanceDropDown(UltraDropDown dropDown, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceDropDown: " + ex.ToString());
            }
        }
        public void setAppearanceDropDownApplication(qs2.sitemap.dropDownApplications dropDownApp, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceDropDownApplication: " + ex.ToString());
            }
        }
        public void setAppearanceComboBoxAsDropDown(UltraDropDownButton cboDropDown, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                cboDropDown.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                cboDropDown.Appearance.BackColorDisabled = input_BackColor_Inactive;
                cboDropDown.Appearance.ForeColorDisabled = input_ForeColor_Inactive;
                cboDropDown.Appearance.BackColor = input_BackColor_Active;
                cboDropDown.Appearance.ForeColor = input_ForeColor_Active;
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceComboBoxAsDropDown: " + ex.ToString());
            }
        }
        public void setAppearanceUltraOptionSet(UltraOptionSet optSet, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceUltraOptionSet: " + ex.ToString());
            }
        }
        public void setAppearanceButtonWin(Button btn, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceButtonWin: " + ex.ToString());
            }
        }
        public void setAppearanceButton(UltraButton btn, eTypeButton TypeButton, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                if ((btn.Tag?.ToString() ?? "").Equals("QS2", StringComparison.OrdinalIgnoreCase))
                        return;

                btn.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;

                btn.UseOsThemes = DefaultableBoolean.Default;
                btn.ButtonStyle = UIElementButtonStyle.Flat;
                btn.UseFlatMode = DefaultableBoolean.True;
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceComboBoxAsDropDown: " + ex.ToString());
            }
        }
        public void setAppearanceButtonToolbox(ToolBase btnToolbox)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceButtonToolbox: " + ex.ToString());
            }
        }
        public void setAppearancePanel(UltraPanel pnl, eTypeUIPanel TypeUIPanel, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


                pnl.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                pnl.UseFlatMode = DefaultableBoolean.True;
                pnl.UseOsThemes = DefaultableBoolean.False;
                pnl.BorderStyle = UIElementBorderStyle.None; 

                if (TypeUIPanel == eTypeUIPanel.PanelStayButtons)   //lower Panel
                    pnl.Appearance.BackColor = ColorSchemas.pnl_StayBottom_BackColor;

                else if (TypeUIPanel == eTypeUIPanel.PanelStayChapter)  //Center
                    pnl.Appearance.BackColor = pnl_StayChapter_BackColor;

                else if (TypeUIPanel == eTypeUIPanel.PanelStayProcGrp)  //top center
                    pnl.Appearance.BackColor = pnl_StayProcGroup_BackColor;

                else if (TypeUIPanel == eTypeUIPanel.PanelStayTop) //top 
                    pnl.Appearance.BackColor = pnl_StayProcGroup_BackColor;

                else if (TypeUIPanel == eTypeUIPanel.PanelStayTopLeft) //top left
                    pnl.Appearance.BackColor = pnl_StayTopLeft_BackColor;

                else if (TypeUIPanel == eTypeUIPanel.PanelStayTopRight)
                    pnl.Appearance.BackColor = pnl_StayProcGroup_BackColor;  //top right

                else if (TypeUIPanel == eTypeUIPanel.Default)
                    if (pnl.Tag != null && pnl.Tag.ToString().Equals("pnl_StayChapter_BackColor", StringComparison.InvariantCulture))
                    {
                        pnl.Appearance.BackColor = ColorSchemas.pnl_StayChapter_BackColor;
                    }
                    else if (pnl.Tag != null && pnl.Tag.ToString().Equals("pnl_StayBackColor", StringComparison.InvariantCulture))
                    {
                        pnl.Appearance.BackColor = ColorSchemas.pnl_StayBackColor;
                    }
                    else
                    {
                        pnl.Appearance.BackColor = ColorSchemas.pnl_BackColor;
                    }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearancePanel: " + ex.ToString());
            }
        }
        public void setAppearancePanelWin(Panel pnlWin, eTypeUIPanelWin TypeUIPanel, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                pnlWin.BorderStyle = BorderStyle.None;

                if (TypeUIPanel == eTypeUIPanelWin.PanelWinInChapters)
                {
                    pnlWin.BackColor = pnl_StayBackColor;
                }
                else if (TypeUIPanel == eTypeUIPanelWin.PanelQueries)
                {
                    pnlWin.BackColor = ColorSchemas.pnl_StayChapter_BackColor;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearancePanelWin: " + ex.ToString());
            }
        }
        public void setAppearanceUserControl(UserControl ctl, eTypeUserControl TypeUserControl, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                if (TypeUserControl == eTypeUserControl.Chapter)
                    ctl.BackColor = pnl_StayBackColor;
                else if (TypeUserControl == eTypeUserControl.MainTop)
                    ctl.BackColor = pnl_Maintop_BackColor;
            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceUserControl: " + ex.ToString());
            }
        }
        public void setAppearanceSplitter(UltraSplitter splitter, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceSplitter: " + ex.ToString());
            }
        }
        public void setAppearanceUltraToolbarsManager(UltraToolbarsManager toolBarManag, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;

                toolBarManag.UseAppStyling = false;
                toolBarManag.UseOsThemes = DefaultableBoolean.False;

                if ((toolBarManag.ToolbarSettings.Tag?.ToString() ?? "").Equals("Main", StringComparison.OrdinalIgnoreCase))
                {
                    toolBarManag.DockAreaAppearance.BackColor = ColorSchemas.pnl_Maintop_BackColor;
                    toolBarManag.ToolbarSettings.Appearance.BackColor = toolBarManag.DockAreaAppearance.BackColor;
                    toolBarManag.ToolbarSettings.ToolAppearance.BackColor = toolBarManag.DockAreaAppearance.BackColor;
                    toolBarManag.ToolbarSettings.ToolAppearance.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                    toolBarManag.ToolbarSettings.ToolDisplayStyle = ToolDisplayStyle.TextOnlyAlways;
                }
                else if ((toolBarManag.ToolbarSettings.Tag?.ToString() ?? "").Equals("Queries", StringComparison.OrdinalIgnoreCase))
                {
                    toolBarManag.DockAreaAppearance.BackColor = ColorSchemas.pnl_StayChapter_BackColor;
                    toolBarManag.ToolbarSettings.Appearance.BackColor = toolBarManag.DockAreaAppearance.BackColor;
                    toolBarManag.ToolbarSettings.ToolAppearance.BackColor = toolBarManag.DockAreaAppearance.BackColor;
                    toolBarManag.ToolbarSettings.ToolAppearance.ForeColor = ColorSchemas.colButtonChapterActiveForeground;
                    toolBarManag.ToolbarSettings.ToolDisplayStyle = ToolDisplayStyle.TextOnlyAlways;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceUltraToolbarsManager: " + ex.ToString());
            }
        }
        public void setAppearanceToolbarsDockArea(UltraToolbarsDockArea dockArea, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceToolbarsDockArea: " + ex.ToString());
            }
        }
        public void setAppearanceTextControl(TXTextControl.TextControl txtCont, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceTextControl: " + ex.ToString());
            }
        }
        public static void setButtonAktivElement(qs2.sitemap.workflowAssist.contListAssistentElem elem, qs2.core.ui.eButtonType ButtonType)
        {
            ColorSchemas.setButtonAktiv(elem.btnElement, ButtonType);
            ColorSchemas.setButtonAktiv(elem.btnOK, ButtonType);

            if (!qs2.core.ENV.UseAppStylingDefault)
            {
                elem.panelBottom.UseAppStyling = false;
                elem.panelBottom.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                elem.contListElementDropDown1.dropDownElementBottom.UseAppStyling = false;
                elem.contListElementDropDown1.dropDownElementBottom.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.dropDownElementBottom.Appearance.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                elem.contListElementDropDown1.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.contListElementDropDown_Fill_Panel.UseAppStyling = false;
                elem.contListElementDropDown1.contListElementDropDown_Fill_Panel.Appearance .BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
            }

        }
        public static void setButtonAktiv(UltraButton butt, qs2.core.ui.eButtonType ButtonType)
        {

            //ColorSchemas.setButtonStyle(butt);
            butt.UseAppStyling = false;
            butt.TabStop = false;
            butt.UseOsThemes = DefaultableBoolean.False;
            butt.UseFlatMode = DefaultableBoolean.False;
            butt.ButtonStyle = UIElementButtonStyle.Flat;
            butt.ShowFocusRect = false;

            switch (ButtonType)
            {
                case qs2.core.ui.eButtonType.Main:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonMainActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonMainActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonMainActiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonMainActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonMainActiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonMainActiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.Queries:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonQueryActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonQueryActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonQueryActiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonQueryActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonQueryActiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonQueryActiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.Procedure:
                    butt.Appearance.FontData.Bold = DefaultableBoolean.True;
                    butt.Appearance.BorderColor = ColorSchemas.colButtonProcedureActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonProcedureActiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonProcedureActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonProcedureActiveHotTrackForeground;
                    butt.HotTrackAppearance.FontData.Bold = DefaultableBoolean.True;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonProcedureActiveHotTrackBackground;
                    butt.PressedAppearance.BorderColor = ColorSchemas.colButtonChapterActiveBackground;
                    break;

                case qs2.core.ui.eButtonType.Chapter:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonChapterActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonChapterActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonChapterActiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonChapterActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonChapterActiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonChapterActiveHotTrackBackground;
                    butt.PressedAppearance.BorderColor = ColorSchemas.colButtonChapterActiveBackground;
                    break;

                case qs2.core.ui.eButtonType.QueryGroups:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonChapterActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonChapterActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonChapterActiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonChapterActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonChapterActiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonChapterActiveHotTrackBackground;
                    butt.PressedAppearance.BorderColor = ColorSchemas.colButtonChapterActiveBackground;
                    break;

                case qs2.core.ui.eButtonType.StayBottom:
                    //butt.UseOsThemes = DefaultableBoolean.Default;
                    //butt.UseFlatMode = DefaultableBoolean.Default;

                    butt.UseFlatMode = DefaultableBoolean.True;
                    butt.UseHotTracking = DefaultableBoolean.True;
                    butt.ShowFocusRect = true;
                    butt.ShowOutline = false;
                    butt.Cursor = Cursors.Hand;

                    butt.Appearance.BorderColor = ColorSchemas.colButtonStayActiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonStayActiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonStayActiveBackground;
                    
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonStayActiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonStayActiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonStayActiveHotTrackBackground;
                    break;
            }
        }
        public static void setButtonInaktivElement(qs2.sitemap.workflowAssist.contListAssistentElem elem, qs2.core.ui.eButtonType ButtonType)
        {
            ColorSchemas.setButtonInaktiv(elem.btnElement, ButtonType);
            ColorSchemas.setButtonInaktiv(elem.btnOK, ButtonType);

            if (!qs2.core.ENV.UseAppStylingDefault)
            {
                elem.panelBottom.UseAppStyling = false;
                elem.panelBottom.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                elem.contListElementDropDown1.dropDownElementBottom.UseAppStyling = false;
                elem.contListElementDropDown1.dropDownElementBottom.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.dropDownElementBottom.Appearance.ForeColor = ColorSchemas.colButtonProcedureActiveForeground;
                elem.contListElementDropDown1.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                elem.contListElementDropDown1.contListElementDropDown_Fill_Panel.UseAppStyling = false;
                elem.contListElementDropDown1.contListElementDropDown_Fill_Panel.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
            }

        }
        public static void setButtonInaktiv(UltraButton butt, qs2.core.ui.eButtonType ButtonType)
        {
            //ColorSchemas.setButtonStyle(butt);
            butt.UseAppStyling = false;
            butt.TabStop = false;
            butt.UseOsThemes = DefaultableBoolean.False;
            butt.UseFlatMode = DefaultableBoolean.False;
            butt.ButtonStyle = UIElementButtonStyle.Flat;
            butt.ShowFocusRect = false;

            switch (ButtonType)
            {
                case qs2.core.ui.eButtonType.Main:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonMainInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonMainInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonMainInactiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonMainInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonMainInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonMainInactiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.Queries:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonQueryInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonQueryInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonQueryInactiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonQueryInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonQueryInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonQueryInactiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.Procedure:
                    butt.Appearance.FontData.Bold = DefaultableBoolean.False;
                    butt.Appearance.BorderColor = ColorSchemas.colButtonProcedureInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonProcedureInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonProcedureInactiveBackground;
                    butt.HotTrackAppearance.FontData.Bold = DefaultableBoolean.False;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonProcedureInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonProcedureInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonProcedureInactiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.Chapter:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonChapterInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonChapterInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonChapterInactiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonChapterInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonChapterInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonChapterInactiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.QueryGroups:
                    butt.Appearance.BorderColor = ColorSchemas.colButtonChapterInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonChapterInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonChapterInactiveBackground;
                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonChapterInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonChapterInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonChapterInactiveHotTrackBackground;
                    break;

                case qs2.core.ui.eButtonType.StayBottom:
                    //                   butt.UseOsThemes = DefaultableBoolean.Default;
                    //                   butt.UseFlatMode = DefaultableBoolean.Default;

                    butt.UseFlatMode = DefaultableBoolean.True;
                    butt.UseHotTracking = DefaultableBoolean.True;
                    butt.ShowFocusRect = false;
                    butt.ShowOutline = false;
                    butt.Cursor = Cursors.Default;

                    butt.Appearance.BorderColor = ColorSchemas.colButtonStayInactiveBorder;
                    butt.Appearance.ForeColor = ColorSchemas.colButtonStayInactiveForeground;
                    butt.Appearance.BackColor = ColorSchemas.colButtonStayInactiveBackground;

                    butt.HotTrackAppearance.BorderColor = ColorSchemas.colButtonStayInactiveHotTrackBorder;
                    butt.HotTrackAppearance.ForeColor = ColorSchemas.colButtonStayInactiveHotTrackForeground;
                    butt.HotTrackAppearance.BackColor = ColorSchemas.colButtonStayInactiveHotTrackBackground;
                    break;
            }
            Application.DoEvents();
        }
        public static void setButtonStyle(UltraButton butt)
        {
            butt.UseOsThemes = DefaultableBoolean.False;
            butt.UseFlatMode = DefaultableBoolean.Default;
            butt.ShowFocusRect = false;
            butt.TabStop = false;
        }
        public void setAppearanceControl(Control cont, bool InfoTop)
        {
            try
            {
                if (qs2.core.ENV.UseAppStylingDefault == true)
                    return;


            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.setAppearanceControl: " + ex.ToString());
            }
        }

       

    }

}
