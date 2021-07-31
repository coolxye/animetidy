using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

		private List<String> _storeDrive;
		public List<String> StoreDrive
		{
			get
			{ return this.GetStorageDrive(); }
		}

		public TidyInfo()
		{
			this._isCreated = false;
			this._isSaved = true;
			this._storeDrive = new List<string>();
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
			dr = MessageBox.Show(String.Format("Save current {0}?", Type),
				"Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

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
				return true;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = TidyConst.Filter;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				this.Name = sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1);
				this.Path = sfd.FileName;
				this.IsCreated = true;

				this.UpdateXmlDeal();
				this.SaveDeal(olv);

				return true;
			}
			else
				return false;
		}

		protected virtual void SaveDeal(ObjectListView olv) { }

		protected virtual void UpdateXmlDeal() { }

		public void CreateInfoList(ObjectListView olv)
		{
			if (this.CheckSaveStatus(olv))
				this.IsCreated = false;
		}

		public void OpenInfoList(ObjectListView olv)
		{
			if (this.CheckSaveStatus(olv))
				this.OpenDeal();
		}

		protected virtual void OpenDeal() { }

		public void SaveInfoList(ObjectListView olv)
		{
			if (this.CheckCreateStatus(olv))
				this.IsSaved = true;
		}

		public virtual void AddInfo(ObjectListView olv)
		{
			// Add Fin
			this.IsSaved = false;
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
			// Undo Fin
			this.IsSaved = true;
		}

		public virtual void RefreshInfo(ObjectListView olv)
		{
			this.IsSaved = false;
		}

		public virtual void RefreshInfo(ObjectListView olv, TidyConst.RefreshType key)
		{
			this.RefreshInfo(olv);
		}

		public virtual void FindInfo(ObjectListView olv, Form ffm)
		{
			FilterForm ff = FilterForm.GetInstance(olv, ffm);
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

		public virtual bool CanClose(ObjectListView olv)
		{
			return this.CheckSaveStatus(olv);
		}

		private List<String> GetStorageDrive()
		{
			if (this._storeDrive.Capacity != 0)
				this._storeDrive.Clear();

			DriveInfo[] allDrives = DriveInfo.GetDrives();

			foreach (DriveInfo dr in allDrives)
				if (dr.IsReady && dr.DriveType == DriveType.Fixed)
					if (TidyConst.VolumnLabels.Exists(x => x == dr.VolumeLabel))
						this._storeDrive.Add(dr.Name);

			return this._storeDrive;
		}
	}
}
