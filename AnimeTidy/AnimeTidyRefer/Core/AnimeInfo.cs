using System;
using System.ComponentModel;
using System.IO;

namespace AnimeTidy.Core
{
	//public struct AnimeInfo
	//{
	//	public String Path
	//	{ get; set; }

	//	public String Name
	//	{ get; set; }

	//	public Int32 Total
	//	{ get; set; }

	//	public Int64 Space
	//	{ get; set; }

	//	public UInt32 Uid
	//	{ get; set; }

	//	public Boolean IsNew
	//	{ get; set; }

	//	public Boolean IsSaved
	//	{ get; set; }
	//}

	public class AnimeInfo
	{
		public String Path
		{ get; set; }

		public String Name
		{ get; set; }

		public Int32 Total
		{ get; set; }

		public Int64 Space
		{ get; set; }

		public UInt32 Uid
		{ get; set; }

		private String lastPath;
		private String lastName;
		private Int32 lastTotal;
		private Int64 lastSpace;
		private UInt32 lastUid;

		public event EventHandler<PropertyChangedEventArgs> NewStatusChanged;

		private Boolean _isNew;

		public Boolean IsNew
		{
			get
			{
				return _isNew;
			}
			set
			{
				if (value != _isNew)
				{
					_isNew = value;

					PropertyChangedEventArgs e = new PropertyChangedEventArgs("IsNew");
					OnPropertyChanged(NewStatusChanged, e);
				}
			}
		}

		public event EventHandler<PropertyChangedEventArgs> SaveStatusChanged;

		private Boolean _isSaved;

		public Boolean IsSaved
		{
			get
			{
				return _isSaved;
			}
			set
			{
				if (value != _isSaved)
				{
					_isSaved = value;

					PropertyChangedEventArgs e = new PropertyChangedEventArgs("IsSaved");
					OnPropertyChanged(SaveStatusChanged, e);
				}
			}
		}

		protected virtual void OnPropertyChanged(EventHandler<PropertyChangedEventArgs> handler, PropertyChangedEventArgs e)
		{
			if (handler != null)
				handler(this, e);
		}

		public AnimeInfo()
		{
			this._isNew = true;
			this._isSaved = true;

			this.Clear();
		}

		public void Restore()
		{
			this.Path = this.lastPath;
			this.Name = this.lastName;
			this.Total = this.lastTotal;
			this.Space = this.lastSpace;
			this.Uid = this.lastUid;
		}

		public void Backup()
		{
			this.lastPath = this.Path;
			this.lastName = this.Name;
			this.lastTotal = this.Total;
			this.lastSpace = this.Space;
			this.lastUid = this.Uid;
		}

		public void Clear()
		{
			this.Path = null;
			this.Name = null;
			this.Total = 0;
			this.Space = 0L;
			this.Uid = 0U;
			this.lastPath = null;
			this.lastName = null;
			this.lastTotal = 0;
			this.lastSpace = 0L;
			this.lastUid = 0U;
		}

		public static Boolean IsStorageReady()
		{
			bool br = false;
			DriveInfo[] allDrives = DriveInfo.GetDrives();

			foreach (DriveInfo dr in allDrives)
				if (dr.IsReady)
					if ((dr.VolumeLabel == "Anime" || dr.VolumeLabel == "Favs") &&
						(dr.DriveType == DriveType.Fixed || dr.DriveType == DriveType.Removable))
					{
						br = true;
						break;
					}

			return br;
		}
	}
}
