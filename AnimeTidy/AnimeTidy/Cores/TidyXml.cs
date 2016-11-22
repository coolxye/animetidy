using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace AnimeTidy.Cores
{
	public class TidyXml
	{
		private List<XatXml> _xatLst;
		public List<XatXml> XatLst
		{
			get { return this._xatLst ?? (this._xatLst = new List<XatXml>()); }
		}

		public TidyXml()
		{
			InitFromFile();
		}

		private void InitFromFile()
		{
			if (!File.Exists(TidyConst.XmlPath))
				return;

			this._xatLst = new List<XatXml>();

			XPathDocument xptdoc = new XPathDocument(TidyConst.XmlPath);
			XPathNavigator xptnavi = xptdoc.CreateNavigator();
			XPathNodeIterator xpnode = xptnavi.Select("/AnimeTidy/Settings/Xat");

			if (xpnode == null)
			{
				WriteToFile();
				return;
			}

			while (xpnode.MoveNext())
			{
				XPathNavigator xpnavi = xpnode.Current;
				String type = xpnavi.GetAttribute("Type", String.Empty);

				if (!String.IsNullOrEmpty(type))
				{
					XatXml txml = new XatXml();
					txml.XatType = (TidyType)Enum.Parse(typeof(TidyType), type);
					XPathNavigator xt = xpnavi.SelectSingleNode("Name");

					if (xt == null || String.IsNullOrEmpty(xt.Value))
						continue;

					txml.XatName = xt.Value;
					xt = xpnavi.SelectSingleNode("Path");

					if (xt == null || String.IsNullOrEmpty(xt.Value) || !File.Exists(xt.Value))
						continue;

					txml.XatPath = xt.Value;

					this._xatLst.Add(txml);
				}
			}
		}

		private void WriteToFile()
		{
			XmlWriterSettings xwSet = new XmlWriterSettings();
			xwSet.Indent = true;
			xwSet.IndentChars = "\t";

			XmlWriter xWriter = XmlWriter.Create(TidyConst.XmlPath, xwSet);
			xWriter.WriteStartElement("AnimeTidy");
			xWriter.WriteStartElement("Settings");

			foreach (XatXml xx in this._xatLst)
			{
				xWriter.WriteStartElement("Xat");
				xWriter.WriteAttributeString("Type", xx.XatType.ToString());
				xWriter.WriteElementString("Name", xx.XatName);
				xWriter.WriteElementString("Path", xx.XatPath);
				xWriter.WriteEndElement();
			}

			xWriter.WriteEndElement();
			xWriter.WriteEndElement();
			xWriter.Flush();
			xWriter.Close();
		}

		// check ok
		private void EditToFile(XatXml xx)
		{
			if (!File.Exists(TidyConst.XmlPath))
			{
				WriteToFile();
				return;
			}

			XmlDocument xdoc = new XmlDocument();
			xdoc.Load(TidyConst.XmlPath);
			XmlNode xn = xdoc.SelectSingleNode("/AnimeTidy/Settings");
			XmlNodeList xnlst = xn.SelectNodes(String.Format("Xat[@Type='{0}']", xx.XatType));

			for (int i = 1; i < xnlst.Count; i++)
				xn.RemoveChild(xnlst[i]);

			xnlst[0].SelectSingleNode("Name").InnerText = xx.XatName;
			xnlst[0].SelectSingleNode("Path").InnerText = xx.XatPath;

			// upgrade tab '\t'
			xdoc.Save(TidyConst.XmlPath);
		}

		// check ok
		private void AddToFile(XatXml xx)
		{
			if (!File.Exists(TidyConst.XmlPath))
			{
				WriteToFile();
				return;
			}

			XmlDocument xdoc = new XmlDocument();
			xdoc.Load(TidyConst.XmlPath);
			XmlNode xn = xdoc.SelectSingleNode("/AnimeTidy/Settings");

			XmlElement xe = xdoc.CreateElement("Xat");
			xe.SetAttribute("Type", xx.XatType.ToString());

			XmlElement xes = xdoc.CreateElement("Name");
			xes.InnerText = xx.XatName;
			xe.AppendChild(xes);

			xes = xdoc.CreateElement("Path");
			xes.InnerText = xx.XatPath;
			xe.AppendChild(xes);

			xn.AppendChild(xe);

			// upgrade tab '\t'
			xdoc.Save(TidyConst.XmlPath);
		}

		public void UpdateXmlFile(XatXml xx)
		{
			XatXml ck = this._xatLst.Find(txml => txml.XatType == xx.XatType);
			if (ck != null)
			{
				ck.XatName = xx.XatName;
				ck.XatPath = xx.XatPath;

				EditToFile(ck);
			}
			else
			{
				this._xatLst.Add(xx);

				AddToFile(xx);
			}
		}

		public void UpdateXmlFile(TidyType type, string name, string path)
		{
			UpdateXmlFile(new XatXml(type, name, path));
		}
	}
}
