//----------------------------------------------------------------------------
/// <summary>
/// Erstellt von RBU 
/// Helper Klasse f�r die Berichtsparameter (gemeinsam benutzte Bereiche)
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public static class ParameterHelper
    {
        public static event BerichtParameterReplaceDelegate ReplaceString;

        public static string ReplacePlaceHolder(string sIN, out bool bOk)
        {
            bOk = true;
            if(ReplaceString == null)           // niemand da der das �bernimmt ? ==> schade
            {
                return sIN;
            }

            sIN = ReplaceString(sIN);
            if (sIN.Contains("{{{"))
            {
                System.Windows.Forms.MessageBox.Show(QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei der Kontrolle der Berichtsparameter wurde ein m�glicher Fehler erkannt.\n\r\n\rSofern Sie alle erforderlichen Berichtsparameter vollst�ndig ausgef�llt haben, notieren Sie sich den Bericht, den Sie �ffnen wollten und kontaktieren Sie S2-Engineering GmbH unter 07252 / 22080.\n\rAndernfalls f�llen Sie bitte alle erforderlichen Parameter aus und versuchen Sie es noch einmal."));
                bOk = false;
            }
            return sIN;
        }
    }

    public delegate string BerichtParameterReplaceDelegate(string StringToReplace);
}
