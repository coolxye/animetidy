using System;

namespace AnimeTidy.Models
{
	public class XatXml
	{
		public TidyType XatType
		{ get; set; }

		public String XatName
		{ get; set; }

		public String XatPath
		{ get; set; }

		public XatXml() { }

		public XatXml(TidyType type, string name, string path)
		{
			this.XatType = type;
			this.XatName = name;
			this.XatPath = path;
		}
	}
}
