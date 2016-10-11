using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		public Anime(UInt64 id)
		{
			this.ID = id;
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
