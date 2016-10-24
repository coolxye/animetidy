using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimeTidy.Models
{
	public class TidyXml
	{
		public TidyType XatType
		{ get; set; }

		public String XatName
		{ get; set; }

		public String XatPath
		{ get; set; }

		public Int32 XatTotal
		{ get; set; }

		public Int64 XatSpace
		{ get; set; }

		public Int64 XatUid
		{ get; set; }
	}
}
