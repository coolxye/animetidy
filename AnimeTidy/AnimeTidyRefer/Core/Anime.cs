using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AnimeTidy.Core
{
	public enum MediaType
	{
		BDRip, DVDRip, BDRAW, DVDRAW, BDMV, TVRip
	}

	public enum MergeFormat
	{
		MKV, MP4, AVI, WMV, M2TS
	}

	public enum SubStyles
	{
		External, Sealed, Embedded
	}

	public enum PlaySeason
	{
		Winter, Spring, Summer, Fall
	}

	public class Anime
	{
		// 标识，唯一性
		public UInt32 ID
		{ get; set; }

		public String Title
		{ get; set; }

		public String Name
		{ get; set; }

		public UInt32 Year
		{ get; set; }

		public PlaySeason Season
		{ get; set; }

		/// <summary>
		/// Schedule
		/// </summary>
		public String Schedule
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

		public SubStyles SubStyle
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

		// 作为固定形式时类中适合，以后更新时框架中方法适合
		//private const String _format =
		//	"Creation Time: {0}, Update Time: {1}\n\n{2}";

		//private const String _picfmt =
		//	"Original Name: {0}\nEpisode: {1}\n";

		public String Remark
		{
			get
			{
				return String.Format("Creation Time: {0}, Update Time: {1}\n\n{2}", CreateTime, UpdateTime, Note.Replace('\u0002', '\n'));
			}
		}

		//public String PicRmks()
		//{
		//	return String.Format(_picfmt, Kana, Episode);
		//}

		public Anime()
		{ }

		public Anime(UInt32 id)
		{
			this.ID = id;
		}

		public Anime(UInt32 id, String title, String name, UInt32 year, PlaySeason season, MediaType type,
			MergeFormat format, String subTeam, SubStyles subStyle, String path,
			Int64 size, Boolean store, Boolean enjoy, Int32 grade, DateTime createTime,
			DateTime updateTime, String kana, String episode, String inc, String note)
		{
			this.ID = id;
			this.Title = title;
			this.Name = name;
			this.Year = year;
			this.Season = season;
			this.Type = type;
			this.Format = format;
			this.SubTeam = subTeam;
			this.SubStyle = subStyle;
			this.Path = path;
			this.Size = size;
			this.Store = store;
			this.Enjoy = enjoy;
			this.Grade = grade;
			this.CreateTime = createTime;
			this.UpdateTime = updateTime;
			this.Kana = kana;
			this.Episode = episode;
			this.Inc = inc;
			this.Note = note;
		}

		public Anime(Anime other, UInt32 id)
		{
			this.ID = id;
			this.Title = other.Title;
			this.Name = other.Name;
			this.Year = other.Year;
			this.Season = other.Season;
			this.Type = other.Type;
			this.Format = other.Format;
			this.SubTeam = other.SubTeam;
			this.SubStyle = other.SubStyle;
			this.Path = other.Path;
			this.Size = other.Size;
			this.Store = other.Store;
			this.Enjoy = other.Enjoy;
			this.Grade = other.Grade;
			this.CreateTime = other.CreateTime;
			this.UpdateTime = other.UpdateTime;
			this.Kana = other.Kana;
			this.Episode = other.Episode;
			this.Inc = other.Inc;
			this.Note = other.Note;
		}

		#region unused EditCopy
		//public void EditCopy(Anime edit)
		//{
		//	this.Title = edit.Title;
		//	this.Year = edit.Year;
		//	this.Season = edit.Season;
		//	this.Path = edit.Path;
		//	this.Size = edit.Size;
		//	this.UpdateTime = edit.UpdateTime;
		//	this.Kana = edit.Kana;
		//	this.Episode = edit.Episode;
		//	this.Inc = edit.Inc;
		//	this.Note = edit.Note;
		//}
		#endregion

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

		public static Boolean IsMatchTitle(String title)
		{
			return (title != String.Empty);
		}

		public static Boolean IsMatchYear(String year)
		{
			return Regex.IsMatch(year, "^(?!0000)[0-9]{4}$");
		}

		public static Boolean IsMatchPath(String path)
		{
			return (path == String.Empty ||
				Regex.IsMatch(path, @"^[a-zA-Z]:(\\(?![\s\.])[^\\/:\*\?\x22<>\|]*[^\s\.\\/:\*\?\x22<>\|])+$"));
		}
	}
}
