using System;
using System.IO;
using System.Text;

namespace AnimeTidy.Models
{
	public class Anime : Metadata
	{
		public AirSeason Season
		{
			get
			{
				return (Month <= 3 ? AirSeason.Winter :
					(Month <= 6 ? AirSeason.Spring :
					(Month <= 9 ? AirSeason.Summer :
					AirSeason.Fall)));
			}
			// todo del
			set
			{
				this.Month = (value == AirSeason.Winter ? 1 :
					(value == AirSeason.Spring ? 4 :
					(value == AirSeason.Summer ? 7 : 10)));
			}
		}

		/// <summary>
		/// Airdate: Year + Season
		/// </summary>
		public String Airdate
		{
			get
			{
				return String.Format("{0} {1}", Year, Season);
			}
		}

		public MediaType Type
		{ get; set; }

		public MergeFormat Format
		{ get; set; }

		public String SubTeam
		{ get; set; }

		public SubStyle SubStyle
		{ get; set; }

		public String Path
		{ get; set; }

		/// <summary>
		/// Preview of same files in Path
		/// </summary>
		public String Preview
		{
			get
			{
				return GetPreview(Path);
			}
		}

		public Int64 Size
		{ get; set; }

		public Boolean Store
		{ get; set; }

		public Boolean Enjoy
		{ get; set; }

		public Int32 Grade
		{ get; set; }

		public DateTime CreateTime
		{ get; set; }

		public DateTime UpdateTime
		{ get; set; }

		public String Kana
		{ get; set; }

		/// <summary>
		/// 动漫话数
		/// </summary>
		public String Episode
		{ get; set; }

		public String Inc
		{ get; set; }

		public String Note
		{ get; set; }

		public String Remark
		{
			get
			{
				return String.Format("Creation Time: {0}, Update Time: {1}\n\n{2}", CreateTime, UpdateTime, Note.Replace('\u0002', '\n'));
			}
		}

		public override string ToString()
		{		
			return String.Join("\t", 
				this.ID, this.Title, this.Name, this.Year, this.Season, this.Type, this.Format,
				this.SubTeam, this.SubStyle, this.Path, this.Size, this.Store,
				this.Enjoy, this.Grade, this.CreateTime, this.UpdateTime, this.Kana,
				this.Episode, this.Inc, this.Note);
		}

		public Anime() { }

		public Anime(Int64 id)
		{
			this.ID = id;
		}

		public Anime(Anime copy)
		{
			this.RevertSelf(copy);
		}

		public Anime(Anime copy, Int64 id)
		{
			this.RevertSelf(copy, id, DateTime.Now, DateTime.Now);
		}

		public void RevertSelf(Anime copy)
		{
			this.RevertSelf(copy, copy.ID, copy.CreateTime, copy.UpdateTime);
		}

		public void RevertSelf(Anime copy, Int64 id, DateTime createTime, DateTime updateTime)
		{
			this.ID = id;
			this.Title = copy.Title;
			this.Name = copy.Name;
			this.Year = copy.Year;
			this.Season = copy.Season;
			this.Type = copy.Type;
			this.Format = copy.Format;
			this.SubTeam = copy.SubTeam;
			this.SubStyle = copy.SubStyle;
			this.Path = copy.Path;
			this.Size = copy.Size;
			this.Store = copy.Store;
			this.Enjoy = copy.Enjoy;
			this.Grade = copy.Grade;
			this.CreateTime = createTime;
			this.UpdateTime = updateTime;
			this.Kana = copy.Kana;
			this.Episode = copy.Episode;
			this.Inc = copy.Inc;
			this.Note = copy.Note;
		}

		public static String GetPreview(String path)
		{
			if (!Directory.Exists(path))
				return path;

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(path);
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			FileInfo[] fi = dirInfo.GetFiles();
			int il = fi.Length;

			if (il == 0)
				return sb.ToString();

			sb.AppendLine();

			int uCnt = 0;
			for (; uCnt < il; uCnt++)
			{
				if (uCnt >= 10)
					break;

				sb.AppendLine(fi[uCnt].Name);
			}

			if (uCnt == 10)
				sb.Append("...");

			return sb.ToString();
		}

		public static Int64 GetSize(String path)
		{
			if (!Directory.Exists(path))
				return 0L;

			long lSpace = 0L;
			DirectoryInfo dirInfo = new DirectoryInfo(path);

			foreach (FileInfo fInfo in dirInfo.GetFiles())
			{
				lSpace += fInfo.Length;
			}

			DirectoryInfo[] dirInfos = dirInfo.GetDirectories();

			if (dirInfos.Length > 0)
				for (int i = 0; i < dirInfos.Length; i++)
					lSpace += GetSize(dirInfos[i].FullName);

			return lSpace;
		}
	}
}
