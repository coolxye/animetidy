using AnimeTidy.Cores;
using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace AnimeTidy
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			// AnimeTidy.xml
			InitTidyXmlFile();
			// Anime, Music, Other..
			InitTabAnime();
		}

		private static List<TidyXml> TidyXmlLst
		{ get; set; }

		private static String TidyXmlPath
		{
			get
			{ return @".\AnimeTidy.xml"; }
		}

		private void InitTidyXmlFile()
		{
			if (!File.Exists(TidyXmlPath))
				return;

			TidyXmlLst = new List<TidyXml>();
			XPathDocument xptdoc = new XPathDocument(TidyXmlPath);
			XPathNavigator xptnavi = xptdoc.CreateNavigator();
			XPathNodeIterator xpnode = xptnavi.Select("/AnimeTidy/Settings/Xat");

			if (xpnode == null)
				return;

			while (xpnode.MoveNext())
			{
				XPathNavigator xpnavi = xpnode.Current;
				String type = xpnavi.GetAttribute("Type", String.Empty);

				if (!String.IsNullOrEmpty(type))
				{
					TidyXml txml = new TidyXml();
					txml.XatType = (TidyType)Enum.Parse(typeof(TidyType), type);
					XPathNavigator xt = xpnavi.SelectSingleNode("LastAccessName");
					
					if (xt == null || String.IsNullOrEmpty(xt.Value))
						continue;

					txml.XatName = xt.Value;
					xt = xpnavi.SelectSingleNode("LastAccessPath");

					if (xt == null || String.IsNullOrEmpty(xt.Value) || !File.Exists(xt.Value))
						continue;

					txml.XatPath = xt.Value;

					TidyXmlLst.Add(txml);
				}
			}
		}

		private void SetTidyXmlFile()
		{
			XmlWriterSettings xwSet = new XmlWriterSettings();
			xwSet.Indent = true;
			xwSet.IndentChars = "\t";

			XmlWriter xWriter = XmlWriter.Create(TidyXmlPath, xwSet);
			xWriter.WriteStartElement("AnimeTidy");
			xWriter.WriteStartElement("Settings");

			foreach (TidyXml tx in TidyXmlLst)
			{
				xWriter.WriteStartElement("Xat");
				xWriter.WriteAttributeString("Type", tx.XatType.ToString());
				xWriter.WriteElementString("LastAccessName", tx.XatName);
				xWriter.WriteElementString("LastAccessPath", tx.XatPath);
				xWriter.WriteEndElement();
			}

			xWriter.WriteEndElement();
			xWriter.WriteEndElement();
			xWriter.Flush();
			xWriter.Close();
		}

		private void InitTabAnime()
		{
			AnimeInfo info = new AnimeInfo(this);

			foreach (TidyXml tx in TidyXmlLst)
				if (tx.XatType == TidyType.Anime)
				{
					info.Name = tx.XatName;
					info.Path = tx.XatPath;

					break;
				}

			this.tabAnimes.AnimeInfo = info;
		}
	}
}
