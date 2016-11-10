using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Cores
{
	public class TidyInfo
	{
		public String Name
		{ get; set; }

		public String Path
		{ get; set; }

		private Int32 _total;
		public Int32 Total
		{
			get
			{ return _total; }
			set
			{
				if (value != _total)
				{
					_total = value;

					OnPropertyChanged(TotalChanged, new PropertyChangedEventArgs("Total"));
				}
			}
		}

		private Int64 _space;
		public Int64 Space
		{
			get
			{ return _space; }
			set
			{
				if (value != _space)
				{
					_space = value;

					OnPropertyChanged(SpaceChanged, new PropertyChangedEventArgs("Space"));
				}
			}
		}

		public Int64 Uid
		{ get; set; }

		public virtual TidyType Type
		{
			get
			{ return TidyType.Invalid; }
		}
		
		private Boolean _isCreated;
		public Boolean IsCreated
		{
			get
			{ return _isCreated; }
			set
			{
				if (value != _isCreated)
				{
					_isCreated = value;

					OnPropertyChanged(CreateStatusChanged, new PropertyChangedEventArgs("IsCreated"));
				}
			}
		}

		private Boolean _isSaved;
		public Boolean IsSaved
		{
			get
			{ return _isSaved; }
			set
			{
				if (value != _isSaved)
				{
					_isSaved = value;

					OnPropertyChanged(SaveStatusChanged, new PropertyChangedEventArgs("IsSaved"));
				}
			}
		}

		public TidyInfo()
		{
			this._isCreated = false;
			this._isSaved = true;
		}

		public event EventHandler<PropertyChangedEventArgs> TotalChanged;
		public event EventHandler<PropertyChangedEventArgs> SpaceChanged;
		public event EventHandler<PropertyChangedEventArgs> CreateStatusChanged;
		public event EventHandler<PropertyChangedEventArgs> SaveStatusChanged;

		protected virtual void OnPropertyChanged(EventHandler<PropertyChangedEventArgs> handler, PropertyChangedEventArgs e)
		{
			if (handler != null)
				handler(this, e);
		}

		private bool CheckSaveStatus(ObjectListView olv)
		{
			if (this.IsSaved)
				return true;

			DialogResult dr;
			dr = MessageBox.Show(String.Format("Save current {0}?", Type.ToString()),
				"Save",	MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			if (dr == DialogResult.Yes)
				return CheckCreateStatus(olv);
			else if (dr == DialogResult.No)
				return true;
			else
				return false;
		}

		private bool CheckCreateStatus(ObjectListView olv)
		{
			if (this.IsCreated)
			{
				this.SaveDeal(olv);
				//UpdateAnimeDoc();
				//_ai.IsSaved = true;

				return true;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = TidyConst.Filter;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				//_ai.Path = sfd.FileName;
				//_ai.Name = Path.GetFileName(_ai.Path);
				//_ai.IsNew = false;
				//_ai.IsSaved = true;

				//UpdateAnimeDoc();

				this.Name = sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1);
				this.Path = sfd.FileName;

				this.SaveDeal(olv);

				return true;
			}
			else
				return false;
		}

		protected virtual void SaveDeal(ObjectListView olv) { }

		public void CreateInfoList(ObjectListView olv)
		{
			if (this.CheckSaveStatus(olv))
			{
				this.IsCreated = false;
				//this.IsSaved = false;
			}
		}

		public void OpenInfoList(ObjectListView olv)
		{
			if (this.CheckSaveStatus(olv))
				this.OpenDeal();
		}

		protected virtual void OpenDeal() { }

		public void SaveInfoList(ObjectListView olv)
		{
			this.CheckCreateStatus(olv);
		}

		public virtual void AddInfo(ObjectListView olv)
		{
			// Add Fin
			this.IsSaved = false;
			this.Uid++;
		}

		public virtual void ModifyInfo(ObjectListView olv)
		{
			// Modify Fin
			this.IsSaved = false;
		}

		public virtual void DuplicateInfo(ObjectListView olv)
		{
			// Duplicate Fin
			this.IsSaved = false;
		}

		public virtual void DeleteInfo(ObjectListView olv)
		{
			// Delete Fin
			this.IsSaved = false;
		}

		public virtual void UndoInfo(ObjectListView olv)
		{
			// Duplicate Fin
			///this.IsSaved = false;
		}

		public virtual void RefreshInfo(ObjectListView olv)
		{
			this.IsSaved = false;
		}

		public virtual void FindInfo(ObjectListView olv)
		{
			FindForm ff = FindForm.GetInstance(olv);
			if (!ff.Created || !ff.Visible)
				ff.Show();
			else
				ff.Activate();
		}

		public virtual void GroupInfo(ObjectListView olv)
		{
			olv.ShowGroups = !olv.ShowGroups;
			olv.BuildList();
		}

		public virtual void OverlayInfo(ObjectListView olv)
		{
			olv.UseOverlays = !olv.UseOverlays;
			olv.HotItemStyle = olv.HotItemStyle;
		}

		public virtual void BackupInfo(ObjectListView olv) { }

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
