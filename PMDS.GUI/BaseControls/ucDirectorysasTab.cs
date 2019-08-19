//----------------------------------------------------------------------------
/// <summary>
///	ucDirectorysasTab.cs
/// Erstellt am:	21.11.2007
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinTabControl;

namespace PMDS.GUI
{
    //----------------------------------------------------------------------------
    /// <summary>
    ///	Usercontrol für die Darstellung von Verzeichnissen als tab
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class ucDirectorysasTab : QS2.Desktop.ControlManagment.BaseControl
    {
        private QS2.Desktop.ControlManagment.BaseTabControl _tab = null;
        private string _RootDirectory = "";
        private int _MinTabWidth = 150;
        private string _CurrentSelectedDir = "";

        public event DirectoryTabClickedDelegate TabClicked;        // Wird ausgelöst wenn ein Tab vom Benutzer ausgewählt wird

        public ucDirectorysasTab()
        {
            InitializeComponent();
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        ///	Legt die mindestbreite des Tabs fest
        /// </summary>
        //----------------------------------------------------------------------------
        public int MinTabWidth
        {
            get { return _MinTabWidth; }
            set { _MinTabWidth = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Root von dem aus die Verzeichnisse dargestellt werden sollen.
        /// Nicht rekursiv
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RootDirectory
        {
            get { return _RootDirectory; }
            set { _RootDirectory = value; RefreshTabsinControl(); }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	Der aktuell ausgewöhlte Pfad
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentSelectedPath
        {
            get 
            {
                return _CurrentSelectedDir;
            }

            set
            {
                if (_tab == null) return ;
                foreach (UltraTab t in _tab.Tabs)
                {
                    if (t.Key == value)
                    {
                        _tab.SelectedTab = t;
                        _CurrentSelectedDir = value;
                        break;
                    }
                }
                
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	anzeige aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshTabsinControl()
        {
            this.Controls.Clear();
            if (RootDirectory.Length == 0)
                return;
            InsertNew(RootDirectory);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Directories darstellen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertNew(string sDir)
        {
            _tab = new QS2.Desktop.ControlManagment.BaseTabControl();
            _tab.Dock = DockStyle.Top;
            _tab.Height = 24;
            _tab.MinTabWidth = this.MinTabWidth;
            _tab.ActiveTabChanging += new ActiveTabChangingEventHandler(_tab_ActiveTabChanging);
            _tab.ActiveTabChanged += new ActiveTabChangedEventHandler(_tab_ActiveTabChanged);


            _tab.Appearance.BackColor = System.Drawing.Color.Transparent;
            _tab.TabHeaderAreaAppearance.BackColor = System.Drawing.Color.Transparent ;
            _tab.Style = UltraTabControlStyle.Office2007Ribbon;
            _tab.Appearance.BorderColor = System.Drawing.Color.Transparent;

            this.BorderStyle = BorderStyle.None ;


            string[] sa = Directory.GetDirectories(RootDirectory);
            Array.Sort(sa);
            foreach (string s in sa)
                _tab.Tabs.Add(s, Path.GetFileName(s));
            this.Controls.Add(_tab);
            if (_tab.Tabs.Count > 0)
                _tab.SelectedTab = _tab.Tabs[0];

            RefreshCurrentDir();
            ResizeThis();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Directorie aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshCurrentDir()
        {
            _CurrentSelectedDir = "";
            if (_tab.SelectedTab == null)
                return;
            _CurrentSelectedDir = _tab.SelectedTab.Key.ToString();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Tab wechsel verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        void _tab_ActiveTabChanged(object sender, ActiveTabChangedEventArgs e)
        {
            if (TabClicked == null)
                return;

            _CurrentSelectedDir = e.Tab.Key.ToString();
            DirectoryTabEventArgs arg = new DirectoryTabEventArgs(_CurrentSelectedDir);
            TabClicked(arg);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	handler für die Klick Aktion
        /// </summary>
        //----------------------------------------------------------------------------
        void _tab_ActiveTabChanging(object sender, ActiveTabChangingEventArgs e)
        {
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Größe automatisch anpassen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ResizeThis()
        {
            this.Height = this.Controls.Count * 24;
        }

        private void ucDirectorysasTab_Load(object sender, EventArgs e)
        {

        }
    }

    public delegate void DirectoryTabClickedDelegate(DirectoryTabEventArgs args);

    //----------------------------------------------------------------------------
    /// <summary>
    ///	Klasse für Event
    /// </summary>
    //----------------------------------------------------------------------------
    public class DirectoryTabEventArgs
    {
        private string _AbsolutePath = "";

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Der ausgewählte Pfad
        /// </summary>
        //----------------------------------------------------------------------------
        public string AbsolutePath
        {
            get { return _AbsolutePath; }
            set { _AbsolutePath = value; }
        }
        private bool _Cancel = false;

        public bool Cancel
        {
            get { return _Cancel; }
            set { _Cancel = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public DirectoryTabEventArgs(string AbsolutePath)
        {
            _AbsolutePath = AbsolutePath;
        }
    }
}
