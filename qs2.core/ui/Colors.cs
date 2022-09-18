namespace qs2.core
{


    public class Colors
    {
        public static System.Drawing.Color standardCol;
        public static System.Drawing.Color standardCol2;

 

        public static Infragistics.Win.UIElementButtonStyle styleButt;

        public static System.Drawing.Color BackColorFieldError;
        public static System.Drawing.Color ForeColorFieldError;

        public static System.Drawing.Color backColListPanelStay;

        public static System.Drawing.Color backColImportantFields;

        public static System.Windows.Media.Brush BackColorFieldErrorWpf;
        public static System.Windows.Media.Brush BackColorFieldNoErrorWpf;

        public static System.Drawing.Color BackColorFieldNoError;
        public static System.Drawing.Color ForeColorFieldNoError;


        public static void initColors(System.Drawing.Color standardCol, System.Drawing.Color standardCol2)
        {

            BackColorFieldErrorWpf = System.Windows.Media.Brushes.Orange;
            BackColorFieldNoErrorWpf = System.Windows.Media.Brushes.White;

            Colors.standardCol = new System.Drawing.Color();
            Colors.standardCol = standardCol;                  //System.Drawing.Color.FromArgb(210, 228, 255);

            standardCol2 = new System.Drawing.Color();
            Colors.standardCol2 = standardCol2;                //System.Drawing.Color.FromArgb(132, 178, 233);

            styleButt = new Infragistics.Win.UIElementButtonStyle();
            styleButt = Infragistics.Win.UIElementButtonStyle.Flat;

            BackColorFieldNoError = System.Drawing.Color.White;
            ForeColorFieldNoError = System.Drawing.Color.Black;


            BackColorFieldError = System.Drawing.Color.FromArgb(251, 230, 209);
            ForeColorFieldError = System.Drawing.Color.Black;

            backColListPanelStay = System.Drawing.Color.Gainsboro;

            backColImportantFields = System.Drawing.Color.FromArgb(236, 255, 229);
        }

    }
}
