using System;

namespace AnimeTidy.Models
{
	public class Metadata
	{
		// 标识，唯一性
		public Int64 ID
		{ get; set; }

		public String Title
		{ get; set; }

		public String Name
		{ get; set; }

		public Int32 Year
		{ get; set; }

		public Int32 Month
		{ get; set; }
	}
}
