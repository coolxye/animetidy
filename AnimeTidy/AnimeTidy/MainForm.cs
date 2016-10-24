﻿using AnimeTidy.Cores;
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
					XPathNavigator xt = xpnavi.SelectSingleNode("Name");
					
					if (xt == null || String.IsNullOrEmpty(xt.Value))
						continue;

					txml.XatName = xt.Value;
					xt = xpnavi.SelectSingleNode("Path");

					if (xt == null || String.IsNullOrEmpty(xt.Value) || !File.Exists(xt.Value))
						continue;

					txml.XatPath = xt.Value;

					xt = xpnavi.SelectSingleNode("Total");
					txml.XatTotal = xt == null ? 0 : xt.ValueAsInt;

					xt = xpnavi.SelectSingleNode("Space");
					txml.XatSpace = xt == null ? 0 : xt.ValueAsLong;

					xt = xpnavi.SelectSingleNode("Uid");
					txml.XatUid = xt == null ? 0 : xt.ValueAsLong;

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
				xWriter.WriteElementString("Name", tx.XatName);
				xWriter.WriteElementString("Path", tx.XatPath);
				xWriter.WriteStartElement("Total");
				xWriter.WriteValue(tx.XatTotal);
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Space");
				xWriter.WriteValue(tx.XatSpace);
				xWriter.WriteEndElement();
				xWriter.WriteStartElement("Uid");
				xWriter.WriteValue(tx.XatUid);
				xWriter.WriteEndElement();
				xWriter.WriteEndElement();
			}

			xWriter.WriteEndElement();
			xWriter.WriteEndElement();
			xWriter.Flush();
			xWriter.Close();
		}

		private void InitTabs()
		{
			foreach (TidyXml tx in TidyXmlLst)
			{
				switch (tx.XatType)
				{
					case TidyType.Anime:
						InitTabAnime(tx);
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

		private void InitTabAnime(TidyXml tx)
		{
			AnimeInfo info = new AnimeInfo(this);
			info.Name = tx.XatName;
			info.Path = tx.XatPath;
			info.Total = tx.XatTotal;
			info.Space = tx.XatSpace;
			info.Uid = tx.XatUid;
			this.tabAnimes.AnimeInfo = info;
		}

		private void tsbtnNew_Click(object sender, EventArgs e)
		{
			this.tabAnimes.CreateAnimeInfo();
		}

		private void tsbtnOpen_Click(object sender, EventArgs e)
		{
			this.tabAnimes.OpenAnimeInfo();
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

		private void tsbtnMusicNew_Click(object sender, EventArgs e)
		{
			this.tabPageMusic.Text = "MusicNew";
			this.SetTidyXmlFile();
		}
	}
}
