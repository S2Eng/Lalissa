//----------------------------------------------------------------------------------------------
//	ENV.cs
//  Klasse für globalen Zugriff auf die Farben
//  Erstellt am:	13.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.ComponentModel;



namespace PMDS.Global
{
	public static class ENVCOLOR 
	{
		private static Color _ErrorBackColor;
		private static Color _ErrorForeColor;

		private static Color _AColor;
		private static Color _SColor;
		private static Color _ZColor;
		private static Color _MColor;

		private static Color _ColorRequired;
		private static Color _TerminUnexMassnahmeColor;
		private static Color _TerminUeberfaelligColor;

		private static Color _EintragEndedForeColor;
		private static Color _EintragEndedBackColor;
		private static Color _EintragCurrentForeColor;
		private static Color _EintragCurrentBackColor;
		private static Color _EintragDeletedForeColor;
		private static Color _EintragDeletedBackColor;
		private static Color _EintragCurrentNotOriginalForeColor;
		private static Color _EintragCurrentNotOriginalBackColor;

	    private static Color _cDefault;


		static ENVCOLOR() 
		{
			ResetColors();
		}

		public static void ResetColors()
		{
            _ErrorBackColor = Color.LightSalmon;
            _ErrorForeColor = Color.Red;

			_AColor 							= Color.Blue;
			_SColor 							= Color.GreenYellow;
			_ZColor 							= Color.Violet;
			_MColor 							= Color.Red;

            Color col = new Color();
            col = System.Drawing.Color.FromArgb(235, 224, 187);
            _ColorRequired = Color.Red;
         
			_TerminUnexMassnahmeColor			= Color.LightYellow;
			_TerminUeberfaelligColor			= Color.LightSalmon;

			_EintragEndedForeColor				= Color.Green;
			_EintragEndedBackColor				= Color.White;
			_EintragCurrentForeColor			= Color.Black;
			_EintragCurrentBackColor			= Color.White;
			_EintragDeletedForeColor			= Color.Gray;
			_EintragDeletedBackColor			= Color.White;
			_EintragCurrentNotOriginalForeColor = Color.Red;
			_EintragCurrentNotOriginalBackColor	= Color.White;

			_cDefault							= Color.WhiteSmoke;
		}

		
		public static Color A_COLOR				{get {return _AColor;} 			set {_AColor = value;} }
		public static Color S_COLOR				{get {return _SColor;} 			set {_SColor = value;} }
		public static Color Z_COLOR				{get {return _ZColor;} 			set {_ZColor = value;} }
		public static Color M_COLOR				{get {return _MColor;} 			set {_MColor = value;} }

        public static Color COLOR_REQUIRED { get { return System.Drawing.Color.MistyRose;} set { _ColorRequired = value; } }
	
		public static Color EINTRAG_ENDED_BACK_COLOR	{get {return _EintragEndedBackColor;}	set {_EintragEndedBackColor = value;} } 
		public static Color EINTRAG_ENDED_FORE_COLOR	{get {return _EintragEndedForeColor;}	set {_EintragEndedForeColor = value;} }
		public static Color EINTRAG_CURRENT_BACK_COLOR	{get {return _EintragCurrentBackColor;}	set {_EintragCurrentBackColor = value;} } 
		public static Color EINTRAG_CURRENT_FORE_COLOR	{get {return _EintragCurrentForeColor;}	set {_EintragCurrentForeColor = value;} }
		public static Color EINTRAG_DELETED_BACK_COLOR	{get {return _EintragDeletedBackColor;}	set {_EintragDeletedBackColor = value;} } 
		public static Color EINTRAG_DELETED_FORE_COLOR	{get {return _EintragDeletedForeColor;}	set {_EintragDeletedForeColor = value;} }
		public static Color EINTRAG_CURRENT_NOT_ORIGINAL_FORE_COLOR	{get {return _EintragCurrentNotOriginalForeColor;}	set {_EintragCurrentNotOriginalForeColor = value;} } 
		public static Color EINTRAG_CURRENT_NOT_ORIGINAL_BACK_COLOR	{get {return _EintragCurrentNotOriginalBackColor;}	set {_EintragCurrentNotOriginalBackColor = value;} }
		public static Color ERROR_BACK_COLOR	{get {return _ErrorBackColor;}	set {_ErrorBackColor = value;} } 
		public static Color ERROR_FORE_COLOR	{get {return _ErrorForeColor;}	set {_ErrorForeColor = value;} }

		public static Color GetColorForGroup(char chGroup) 
		{
			switch(chGroup) 
			{
				case 'A':
					return A_COLOR;
				case 'S':
					return S_COLOR;
				case 'Z':
					return Z_COLOR;
				case 'M':
					return M_COLOR;
				default:
					return Color.Black;
			}
		}

		//Colors for UI-Buttons
		public static System.Drawing.Color activeBackCol = System.Drawing.Color.NavajoWhite;
		public static System.Drawing.Color activeForeCol = System.Drawing.Color.Black;
		public static System.Drawing.Color activeFrameCol = System.Drawing.Color.DarkGray;

		public static System.Drawing.Color inactiveBackCol = System.Drawing.Color.Transparent;
		public static System.Drawing.Color inactiveForeCol = System.Drawing.Color.DarkBlue;
		public static System.Drawing.Color inactiveFrameCol = System.Drawing.Color.Transparent;

		public static System.Drawing.Color hoverBackCol = System.Drawing.Color.PapayaWhip;
		public static System.Drawing.Color hoverForeCol = System.Drawing.Color.Black;
		public static System.Drawing.Color hoverFrameCol = System.Drawing.Color.DarkGray;
	}
}
