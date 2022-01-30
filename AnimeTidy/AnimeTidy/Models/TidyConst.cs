using System;
using System.Collections.Generic;

namespace AnimeTidy.Models
{
	public static class TidyConst
	{
		/// <summary>
		/// Xml file's path
		/// </summary>
		public const String XmlPath = @".\AnimeTidy.xml";

		/// <summary>
		/// open/save file's filter
		/// </summary>
		public const String Filter = "AnimeTidy Files|*.xat";

		/// <summary>
		/// Total Space Uid
		/// </summary>
		public const Int32 AnimeKeyLen = 3;

		/// <summary>
		/// TabAnime Page's Name
		/// </summary>
		public const String TabAnimeName = "Anime";

		/// <summary>
		/// RefreshType
		/// </summary>
		public enum RefreshType
		{
			AnySelected,
			All
		}

		/// <summary>
		/// Storage Disk
		/// </summary>
		public static readonly List<String> VolumnLabels = new List<String>(3)
		{
			"StorageA",
			"StorageB",
			"StorageC"
		};

		/// <summary>
		/// DPI Ratio
		/// </summary>
		public const Double DpiRatio = 1.2;
	}
}
