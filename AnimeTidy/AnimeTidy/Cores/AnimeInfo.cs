using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Cores
{
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

		public UInt64 Uid
		{ get; set; }

		public static TidyType Type
		{
			get
			{ return TidyType.Anime; }
		}

		/// <summary>
		/// Total Space Uid
		/// </summary>
		private static Int32 _infLength = 3;

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

		private List<Anime> _animeList;
		public List<Anime> AnimeList
		{
			get
			{ return this._animeList ?? (this._animeList = LoadAnimeList(this.Path)); }
		}

		private MainForm _mainForm;
		private MainForm Form
		{
			get
			{ return this._mainForm; }
		}

		public AnimeInfo(MainForm mainForm)
		{
			this._mainForm = mainForm;

			this._isNew = true;
			this._isSaved = true;
		}

		protected virtual void OnPropertyChanged(EventHandler<PropertyChangedEventArgs> handler, PropertyChangedEventArgs e)
		{
			if (handler != null)
				handler(this, e);
		}

		public List<Anime> LoadAnimeList(String path)
		{
			StreamReader sr = new StreamReader(path);
			string line = sr.ReadLine();

			if (String.IsNullOrEmpty(line))
			{
				sr.Close();

				return null;
			}

			string[] info = line.Split('\t');
			if (info.Length != _infLength)
			{
				sr.Close();

				return null;
			}

			int it;
			long lt;
			ulong ut;
			if (!Int32.TryParse(info[0], out it) ||
				!Int64.TryParse(info[1], out lt) ||
				!UInt64.TryParse(info[2], out ut))
			{
				MessageBox.Show("The line 1 is wrong.", "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				sr.Close();

				return null;
			}

			this.Total = it;
			this.Space = lt;
			this.Uid = ut;

			List<Anime> lstAnime = new List<Anime>();
			int iErr = 0;
			try
			{
				while (!String.IsNullOrEmpty(line = sr.ReadLine()))
				{
					iErr++;
					info = line.Split('\t');

					Anime ani = new Anime(UInt32.Parse(info[0]));
					ani.Title = info[1];
					ani.Name = info[2];
					ani.Year = Int32.Parse(info[3]);
					ani.Season = (AirSeason)Enum.Parse(typeof(AirSeason), info[4]);
					ani.Type = (MediaType)Enum.Parse(typeof(MediaType), info[5]);
					ani.Format = (MergeFormat)Enum.Parse(typeof(MergeFormat), info[6]);
					ani.SubTeam = info[7];
					ani.SubStyle = (SubStyle)Enum.Parse(typeof(SubStyle), info[8]);
					ani.Path = info[9];
					ani.Size = Int64.Parse(info[10]);
					ani.Store = Boolean.Parse(info[11]);
					ani.Enjoy = Boolean.Parse(info[12]);
					ani.Grade = Int32.Parse(info[13]);
					ani.CreateTime = DateTime.Parse(info[14]);
					ani.UpdateTime = DateTime.Parse(info[15]);
					ani.Kana = info[16];
					ani.Episode = info[17];
					ani.Inc = info[18];
					ani.Note = info[19];

					lstAnime.Add(ani);
				}
			}
			catch (Exception)
			{
				MessageBox.Show(String.Format("The line {0} is wrong.", iErr + 1), "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);

				lstAnime.Clear();
				lstAnime = null;

				return null;
			}
			finally
			{
				sr.Close();
			}

			this.IsNew = false;
			this.IsSaved = true;

			return lstAnime;
		}
	}
}
