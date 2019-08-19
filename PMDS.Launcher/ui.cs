using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class ui
{
    

    public bool msgBox(string txt, string tit )
    {
        MessageBox.Show(txt, tit);
        return false;
    }

}

