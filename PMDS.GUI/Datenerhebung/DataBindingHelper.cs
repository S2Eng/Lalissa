using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public class DataBindingHelper
    {
        private Control _control;
        private string _propertyName;
        private string _dataMember;

        public DataBindingHelper(Control Control, string PropertyName, string DataMember)
        {
            _control = Control;
            _propertyName = PropertyName;
            _dataMember = DataMember;
        }

        public Control Control
        {
            get { return _control; }
            //set { _control = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            //set { _propertyName = value; }
        }

        public string DataMember
        {
            get { return _dataMember; }
            //set { _dataMember = value; }
        }
    }
}
