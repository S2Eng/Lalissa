using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace VirtualKeyboard
{
    public partial class ucVKey : QS2.Desktop.ControlManagment.BaseControl
    {
        private string[]            _SpecialCharList = {"+", "^", "%", "~", "(", ")", "{", "}", "[", "]"};
        private Color               _BackColorPressed   = Color.Black;
        private Color               _ForeColorPressed   = Color.White;
        private Color               _ForeColorDisabled = Color.Gray;
        private string              _CharNormal          = "*";
        private string              _CharShift;
        private string              _CharControl;
        private string              _CharAlt;
        private bool                _ActionKey = false;                     // Signalisiert dass es sich um einen Action Key handelt wie Alt, Strg etc.....
        private VirtualKeyboardMode _mode = VirtualKeyboardMode.Normal;
        private bool                _toogle = false;
        private VirtualSpecialKey   _SpecialKey = VirtualSpecialKey.None;
        private static  SoundPlayer _soundplayer;
        private static  bool        _errorPlayer = false;

        

        public event EventHandler KeyToogle;
        

        public Color BackColorPressed       { get { return _BackColorPressed; } set { _BackColorPressed = value; } }
        public Color ForeColorPressed       { get { return _ForeColorPressed; } set { _ForeColorPressed = value; } }
        public string CharNormal            { get { return _CharNormal; }       set { _CharNormal = value; } }
        public string CharShift             { get { return _CharShift; }        set { _CharShift = value; } }
        public string CharControl           { get { return _CharControl; }      set { _CharControl = value; } }
        public string CharAlt               { get { return _CharAlt; }          set { _CharAlt = value; } }
        public bool   ActionKey             { get { return _ActionKey; }        set { _ActionKey = value; } } 
        public bool   TOOGLE                { get { return _toogle; }           set { _toogle = value; RepaintAfterToogle();} }
        public VirtualKeyboardMode MODE     { get { return _mode; }             set { _mode = value; if (!_ActionKey) this.Refresh(); } }
        public VirtualSpecialKey SpecialKey { get { return _SpecialKey; }       set { _SpecialKey = value; PrepareForSpecialKey(); } }

           
        

        public ucVKey()
        {
            InitializeComponent();
            
            
        }

        public static void PlayKlick()
        {
            if (_errorPlayer)
                return;

            if (_soundplayer == null)
            {
                try
                {
                    string sFile = Path.Combine(PMDS.Global.ENV.pathConfig, "vkSound.wav");
                    if (File.Exists(sFile))
                    {
                        _soundplayer = new SoundPlayer(sFile);
                        _soundplayer.Play();
                    }
                    else
                    {
                        _errorPlayer = true;
                    }
                }
                catch
                {
                    _errorPlayer = true;
                }
            }
            else
            {
                _soundplayer.Play();
            }

        }

        private void PrepareForSpecialKey()
        {
            if (DesignMode)
                return;
            if (_SpecialKey == VirtualSpecialKey.None)
                return;
            Font = new Font("Symbol", Font.Size);
            string sChar="";
            switch (_SpecialKey)
            {
                case VirtualSpecialKey.None:
                    break;
                case VirtualSpecialKey.Up:
                    sChar = new string((char)173, 1);
                    break;
                case VirtualSpecialKey.Down:
                    sChar = new string((char)175, 1);
                    break;
                case VirtualSpecialKey.Left:
                    sChar = new string((char)172, 1);
                    break;
                case VirtualSpecialKey.Right:
                    sChar = new string((char)174, 1);
                    break;
                case VirtualSpecialKey.PageUp:
                    sChar = new string((char)173, 1) + new string((char)173, 1);
                    break;
                case VirtualSpecialKey.PageDown:
                    sChar = new string((char)175, 1) + new string((char)175, 1);
                    break;
                case VirtualSpecialKey.Entf:
                    Font = new Font("Arial", Font.Size);
                    sChar = "Entf";
                    break;
                case VirtualSpecialKey.Back:
                    sChar = new string((char)172, 1);
                    break;
                case VirtualSpecialKey.Pos1:
                    Font = new Font("Arial", Font.Size);
                    sChar = "Pos1";
                    break;
                case VirtualSpecialKey.Ende:
                    Font = new Font("Arial", Font.Size);
                    sChar = "Ende";                             //-IntVers=NoTranslation
                    break;
                case VirtualSpecialKey.Return:
                    Font = new Font("Arial", Font.Size);
                    sChar = "Eingabe";                          //-IntVers=NoTranslation
                    break;
                default:
                    break;
            }

            CharNormal = sChar;
            MyPaint(null, false);
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {
            MyPaint(e.Graphics, false);
        }

        private void MyPaint(Graphics g, bool bPressed)
        {
            bool gcreated = false;
            if (g == null)
            {
                g = this.CreateGraphics();
                gcreated = true;
            }

            g.Clear(bPressed ? BackColorPressed : BackColor);

            DrawString(g, GetCharToDraw(false), bPressed);

            if (gcreated)
                g.Dispose();
        }

        private string GetCharToDraw(bool bCheckSpecialChars)
        {
            string s = GetCharFromMode();
            if (bCheckSpecialChars)
            {
                foreach (string ss in _SpecialCharList)
                    if (s == ss)
                        return "{" + s + "}";
            }
            return s;
        }

        private string GetCharFromMode()
        {
            if (_ActionKey)
                return CharNormal;

            switch (_mode)
            {
                case VirtualKeyboardMode.Normal:
                    return (CharNormal);
                case VirtualKeyboardMode.Shift:
                    return (CharShift);
                case VirtualKeyboardMode.Control:
                    return (CharControl);
                case VirtualKeyboardMode.Alt:
                    return (CharAlt);
            }
            return "*";
        }

        private void DrawString(Graphics g, string charToDraw, bool bPressed)
        {
           SolidBrush b = new SolidBrush(bPressed ? ForeColorPressed : this.Enabled ? ForeColor : _ForeColorDisabled);
           SizeF sf = g.MeasureString(charToDraw, Font);
           
           g.DrawString(charToDraw, Font, b, this.Width / 2 - sf.Width / 2 , this.Height / 2 - sf.Height / 2);
           b.Dispose();
        }


        protected override void OnGotFocus(EventArgs e)
        {
               // Do Nothing
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            ProcessMouseClick(true);
        }

        private void ProcessMouseClick(bool bSendMessage)
        {
            if (!_ActionKey)
            {
                if (_SpecialKey != VirtualSpecialKey.None)
                {
                    SendSpecialKey();
                    return;
                }
                MySendkeys(GetCharToDraw(true));
                return;
            }

            _toogle = !_toogle;
            MyPaint(null, _toogle);

            if (KeyToogle != null && bSendMessage)
                KeyToogle(this, EventArgs.Empty);
        }

        private void MySendkeys(string s)
        {
            SendKeys.Send(s);
            PlayKlick();
            
        }

        private void SendSpecialKey()
        {
            switch (_SpecialKey)
            {
                case VirtualSpecialKey.None:
                    break;
                case VirtualSpecialKey.Up:
                    MySendkeys("{UP}");
                    break;
                case VirtualSpecialKey.Down:
                    MySendkeys("{DOWN}");
                    break;
                case VirtualSpecialKey.Left:
                    MySendkeys("{LEFT}");
                    break;
                case VirtualSpecialKey.Right:
                    MySendkeys("{RIGHT}");
                    break;
                case VirtualSpecialKey.PageUp:
                    MySendkeys("{PGUP}");
                    break;
                case VirtualSpecialKey.PageDown:
                    MySendkeys("{PGDN}");
                    break;
                case VirtualSpecialKey.Entf:
                    MySendkeys("{DEL}");
                    break;
                case VirtualSpecialKey.Back:
                    MySendkeys("{BS}");
                    break;
                case VirtualSpecialKey.Pos1:
                    MySendkeys("{HOME}");
                    break;
                case VirtualSpecialKey.Ende:
                    MySendkeys("{END}");
                    break;
                case VirtualSpecialKey.Return:
                    MySendkeys("{ENTER}");
                    break;
                default:
                    break;
            }
        }

        private void RepaintAfterToogle()
        {
            MyPaint(null, _toogle);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_ActionKey) 
                MyPaint(null, true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!_ActionKey) 
                MyPaint(null, false);
        }

        private void ucVKey_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_ActionKey) 
                MyPaint(null, false);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            MyPaint(null, false);
        }
        
        
    }

    public enum VirtualSpecialKey
    {
        None,
        Up,
        Down,
        Left,
        Right,
        PageUp,
        PageDown,
        Back,
        Entf,
        Pos1,
        Ende,
        Return
    }

    public enum VirtualKeyboardMode
    {
        Normal,
        Shift,
        Control,
        Alt
    }
}
