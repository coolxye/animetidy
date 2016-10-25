using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Cores
{
	public class TidyInfo
	{
		public String Path
		{ get; set; }

		public String Name
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

		public Int64 Space
		{ get; set; }

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

		public event EventHandler<PropertyChangedEventArgs> TotalChanged;
		public event EventHandler<PropertyChangedEventArgs> CreateStatusChanged;
		public event EventHandler<PropertyChangedEventArgs> SaveStatusChanged;

		protected virtual void OnPropertyChanged(EventHandler<PropertyChangedEventArgs> handler, PropertyChangedEventArgs e)
		{
			if (handler != null)
				handler(this, e);
		}

		private bool CheckSaveStatus()
		{
			if (this.IsSaved)
				return true;

			DialogResult dr;
			dr = MessageBox.Show(String.Format("Save current {0}?", Type.ToString()),
				"Save",	MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			if (dr == DialogResult.Yes)
				return CheckCreateStatus();
			else if (dr == DialogResult.No)
				return true;
			else
				return false;
		}

		private bool CheckCreateStatus()
		{
			if (this.IsCreated)
			{
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

				return true;
			}
			else
				return false;
		}

		public void CreateInfoList()
		{
			if (this.CheckSaveStatus())
			{
				this.IsCreated = false;
				this.IsSaved = false;
			}
		}

		public void OpenInfoList()
		{
			if (this.CheckSaveStatus())
				this.OpenDeal();
		}

		protected virtual void OpenDeal()
		{ }
	}
}
