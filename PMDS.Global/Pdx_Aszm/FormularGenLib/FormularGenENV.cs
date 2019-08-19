using System;
using System.Collections.Specialized;

namespace FormularGen
{
	//--------------------------------------------------------------------------------
	/// <summary>
	/// Speichert globale Informationen für die Formularverarbeitung
	/// </summary>
	//--------------------------------------------------------------------------------
	public class FormularGenENV
	{

		private NameValueCollection			_nvc = new NameValueCollection();

		public FormularGenENV()
		{
			_nvc.Add("#SUM#", "0");
			_nvc.Add("#PAGENO#", "0");
		}


		public float	SUMPOINTS	{	get{return GetFloatValue("#SUM#");}			set {SetValue("#SUM#", value);}	}
		public int		PAGENO		{	get{return GetIntValue("#PAGENO#");}		set {SetValue("#PAGENO#", value);}	}

		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Einen Wert hinzufügen
		/// </summary>
		//--------------------------------------------------------------------------------
		public void AddSumPoints(float points) 
		{
			float f = GetFloatValue("#SUM#");
			f += points;
			SetValue("#SUM#", f);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Liefert einen durch die Werte im Environment ersetzten String
		/// </summary>
		//--------------------------------------------------------------------------------
		public string ReplaceStringElements(string s) 
		{
			string sRet = s;
			foreach(string skey in _nvc.Keys) 
			{
				if(sRet.IndexOf(skey) > -1)
					sRet = sRet.Replace(skey, GetStringValue(skey));
			}
			return sRet;
		}

		private bool HasKey(string sKey) 
		{
			foreach(string s in _nvc.Keys)
			{
				if(s.ToUpper() == sKey.ToUpper())
					return true;
			}

			return false;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Setzt einen Key für Formularlabels welche später ersetzt werden.
		/// Der key muss mit # beginnen und mit # aufhören (sonst fehler)
		/// Beispiel #PAGEHEADER#
		/// </summary>
		//--------------------------------------------------------------------------------
		public void SetExternalKey(string sKey, string sValue) 
		{
			if(! (sKey.StartsWith("#") && sKey.EndsWith("#")))
				throw new Exception("FormularGenENV::SetExternalKey() - Keys must begin with # and ends with #");

			if(HasKey(sKey))
				SetValue(sKey, sValue);
			else
				_nvc.Add(sKey, sValue);
		}

		#region Werte sezten / lesen

		private float GetFloatValue(string sKey)
		{
			float f = (float)Convert.ToDouble( _nvc[sKey]);
			return f;
		}

		private string GetStringValue(string sKey)
		{
			return _nvc[sKey];
		}

		private int GetIntValue(string sKey)
		{
			int i = (int)Convert.ToInt32( _nvc[sKey]);
			return i;
		}

		private void SetValue(string sKey, string sValue)
		{
			_nvc.Set(sKey, sValue);
		}

		private void SetValue(string sKey, float fValue)
		{
			_nvc.Set(sKey, fValue.ToString());
		}

		private void SetValue(string sKey, int iValue)
		{
			_nvc.Set(sKey, iValue.ToString());
		}
		#endregion
		
	}
}
