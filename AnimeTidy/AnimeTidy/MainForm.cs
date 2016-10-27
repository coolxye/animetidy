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
			InitTabs();
		}

		private List<TidyXml> _tidyXmlLst = new List<TidyXml>();
		private List<TidyXml> TidyXmlLst
		{
			get { return this._tidyXmlLst; }
		}

		private void InitTidyXmlFile()
		{
			if (!File.Exists(TidyConst.XmlPath))
				return;

			XPathDocument xptdoc = new XPathDocument(TidyConst.XmlPath);
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
					XPathNavigator xt = xpnavi.SelectSingleNode("Name");

					if (xt == null || String.IsNullOrEmpty(xt.Value))
						continue;

					txml.XatName = xt.Value;
					xt = xpnavi.SelectSingleNode("Path");

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

			XmlWriter xWriter = XmlWriter.Create(TidyConst.XmlPath, xwSet);
			xWriter.WriteStartElement("AnimeTidy");
			xWriter.WriteStartElement("Settings");

			foreach (TidyXml tx in TidyXmlLst)
			{
				xWriter.WriteStartElement("Xat");
				xWriter.WriteAttributeString("Type", tx.XatType.ToString());
				xWriter.WriteElementString("Name", tx.XatName);
				xWriter.WriteElementString("Path", tx.XatPath);
				xWriter.WriteEndElement();
			}

			xWriter.WriteEndElement();
			xWriter.WriteEndElement();
			xWriter.Flush();
			xWriter.Close();
		}

		private void InitTabs()
		{
			// Anime, Music, Other Info todo
			AnimeInfo info = new AnimeInfo(this);
			this.tabAnimes.AnimeInfo = info;

			foreach (TidyXml tx in TidyXmlLst)
			{
				switch (tx.XatType)
				{
					case TidyType.Anime:
						this.tabAnimes.InitAnimeInfo(tx);
						break;

					case TidyType.Music:
						break;

					case TidyType.Other:
						break;

					default:
						break;
				}
			}
		}

		private void tabControlMain_Deselected(object sender, TabControlEventArgs e)
		{
			switch (this.tabControlMain.SelectedIndex)
			{
				case 0:
					//this.tsbtnNew.Visible = false;
					this.tsbtnNew.Click -= this.tsbtnNew_Click;
					break;

				case 1:
					this.tsbtnNew.Click -= this.tsbtnMusicNew_Click;
					break;

				default:
					break;
			}
		}

		private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.tabControlMain.SelectedIndex)
			{
				case 0:
					//this.tsbtnNew.Visible = true;
					this.tsbtnNew.Click += tsbtnNew_Click;
					break;

				case 1:
					this.tsbtnNew.Click += this.tsbtnMusicNew_Click;
					break;

				default:
					break;
			}
		}

		private void tsbtnNew_Click(object sender, EventArgs e)
		{
			this.tabAnimes.CreateAnimeInfo();
		}

		private void tsbtnMusicNew_Click(object sender, EventArgs e)
		{
			this.tabPageMusic.Text = "MusicNew";
			//this.SetTidyXmlFile();
		}

		private void tsbtnOpen_Click(object sender, EventArgs e)
		{
			this.tabAnimes.OpenAnimeInfo();
		}

		private void tsbtnSave_Click(object sender, EventArgs e)
		{
			this.tabAnimes.SaveAnimeInfo();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			this.tabAnimes.AddAnime();
		}

		private void tsbtnModify_Click(object sender, EventArgs e)
		{
			this.tabAnimes.ModifyAnime();
		}

		private void tsbtnDuplicate_Click(object sender, EventArgs e)
		{
			this.tabAnimes.DuplicateAnime();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			this.tabAnimes.DeleteAnime();
		}

		private void tsbtnUndo_Click(object sender, EventArgs e)
		{
			this.tabAnimes.UndoAnime();
		}
	}
}
