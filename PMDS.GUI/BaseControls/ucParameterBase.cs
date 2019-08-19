//----------------------------------------------------------------------------
/// <summary>
/// Erstellt von RBU
/// Basisklasse für alle GuiBerichtparameter
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public class ucParameterBase : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler ValueChanged;

        protected virtual void SignalValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Standardmäßig ignorieren muss dort wo es benötigt wird überschrieben werden
        /// </summary>
        public virtual void AnotherValueChanged(PMDS.Print.CR.BerichtParameter p)
        {
        }

        public bool IsDependedParameter(PMDS.Print.CR.BerichtParameter p, string sql)
        {
            if (sql.Contains("{{{" + p.Name + "."))
                return true;
            return false;
        }
    }
}
