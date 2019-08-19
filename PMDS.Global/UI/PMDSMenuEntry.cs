using System;
using System.Drawing;
using System.IO;
using System.Reflection;


namespace PMDS.Global
{
	public delegate void SiteMapDelegate(SiteEvents e, ref bool used);
	public delegate void MenuClickDelegate(PMDSMenuEntry sender);

	public class PMDSMenuEntry
	{
		private SiteGroups			_MenuGroup;
		private SiteEvents			_MenuEntry;
		private string				_GroupKey;
		private string				_EntryKey;
		private string				_GroupTxt;
		private string				_EntryTxt;
		private MenuClickDelegate	_Click;
		private Bitmap				_Icon;
		private object				_tag;
        private Bitmap              _bmp;



		public PMDSMenuEntry(SiteGroups Group, SiteEvents Entry, MenuClickDelegate ClickDelegate) 
			: this(Group, Entry, ClickDelegate, "")
		{
		}

		public PMDSMenuEntry(SiteGroups Group, SiteEvents Entry, string sEntry, MenuClickDelegate ClickDelegate) 
			: this(Group, Entry, ClickDelegate, "")
		{
			_EntryTxt = sEntry;
		}

        public PMDSMenuEntry(SiteGroups Group, SiteEvents Entry, string sEntry, MenuClickDelegate ClickDelegate, string ResourceImage)
            : this(Group, Entry, ClickDelegate, ResourceImage)
        {
            _EntryTxt = sEntry;
        }

		public PMDSMenuEntry(SiteGroups Group, string Entry, MenuClickDelegate ClickDelegate) 
			: this(Group.ToString(), Entry, ClickDelegate, "")
		{
			_MenuGroup = Group;
		}
		
		public PMDSMenuEntry(SiteGroups Group, SiteEvents Entry, MenuClickDelegate ClickDelegate, string ResourceImage) 
			: this(Group.ToString(), Entry.ToString(), ClickDelegate, ResourceImage)
		{
			_GroupTxt	= ENV.String("SiteGroups."+Group.ToString());
			_EntryTxt	= ENV.String("SiteEvents."+Entry.ToString());

			_MenuGroup	= Group;
			_MenuEntry	= Entry;
		}

		public PMDSMenuEntry(string Group, string Entry, MenuClickDelegate ClickDelegate) 
			: this(Group, Entry, ClickDelegate, "")
		{
		}

        public Bitmap  bmp 
        { get 
            { 
            return this._bmp; 
            } 
        set 
            {
            _bmp = value; 
            } 
        }


		public PMDSMenuEntry(string Group, string Entry, MenuClickDelegate ClickDelegate, string ResourceImage)
		{
			_GroupKey = Group;
			_GroupTxt = Group;
			_EntryKey = Entry;
			_EntryTxt = Entry;
			_Click = ClickDelegate;

			if(ResourceImage == null || ResourceImage.Length == 0)
                ResourceImage = "PMDS.Global.Resources.PfeilAufgabeKlein.ico";

			if(ResourceImage != null && ResourceImage != "") 
			{
				Stream imgStream = null;
				Assembly a = Assembly.GetExecutingAssembly();
				imgStream = a.GetManifestResourceStream(ResourceImage);
				if(imgStream != null)
					_Icon = (Bitmap) Bitmap.FromStream(imgStream);
			}

		}


		public SiteGroups			SiteGroup	{	get	{	return _MenuGroup;	}	}
		public SiteEvents			SiteEvent	{	get	{	return _MenuEntry;	}	}
		public string				GroupKey	{	get	{	return _GroupKey;	}	}
		public string				EntryKey	{	get	{	return _GroupKey + "." + _EntryKey;	}	}
		public string				GroupTxt	{	get	{	return _GroupTxt;	}	}
		public string				EntryTxt	{	get	{	return _EntryTxt;	}	}
		public MenuClickDelegate	Click		{	get	{	return _Click;		}	}
		public Bitmap				Icon		{	get	{	return _Icon;		}	}
		public object				Tag			{	get	{	return _tag;		}	set {_tag = value; }}
	}
}
