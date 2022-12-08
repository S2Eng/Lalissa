using System.Windows.Forms;

namespace Launcher
{
    public class ui
    {
    

        public bool msgBox(string txt, string tit )
        {
            MessageBox.Show(txt, tit);
            return false;
        }

    }
}

