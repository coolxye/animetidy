using AnimeTidy.Cores;
using AnimeTidy.Models;
using AnimeTidyLib;
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
		public List<TidyXml> TidyXmlLst
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

		private void WriteToTidyXmlFile(TidyXml tx)
		{
			XmlDocument xdoc = new XmlDocument();
			xdoc.Load(TidyConst.XmlPath);
			XmlNodeList xnlst = xdoc.SelectSingleNode("/AnimeTidy/Settings").ChildNodes;

			foreach (XmlNode xn in xnlst)
			{
				XmlElement xe = xn as XmlElement;
				if (xe.GetAttribute("Type") == tx.XatType.ToString())
				{
					xe.SelectSingleNode("Name").InnerText = tx.XatName;
					xe.SelectSingleNode("Path").InnerText = tx.XatPath;

					break;
				}
			}

			// upgrade tab
			xdoc.Save(TidyConst.XmlPath);
		}

		private void InitTabs()
		{
			if (ObjectListView.IsVistaOrLater)
				this.Font = new Font("Segoe UI", 8);	// Microsoft YaHei

			this.tabPageAnime.Tag = this.tabAnimes;

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

		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case (Keys.S | Keys.Control):
					this.tsbtnSave_Click(this.tsbtnSave, EventArgs.Empty);
					return true;

				case (Keys.I | Keys.Control):
					this.tsbtnAdd_Click(this.tsbtnAdd, EventArgs.Empty);
					return true;

				case (Keys.E | Keys.Control):
					this.tsbtnModify_Click(this.tsbtnModify, EventArgs.Empty);
					return true;

				case (Keys.D | Keys.Control):
					this.tsbtnDuplicate_Click(this.tsbtnDuplicate, EventArgs.Empty);
					return true;

				case (Keys.F | Keys.Control):
					this.tsbtnFind_Click(this.tsbtnFind, EventArgs.Empty);
					return true;

				default:
					return base.ProcessDialogKey(keyData);
			}
		}

		private void tabControlMain_Deselected(object sender, TabControlEventArgs e)
		{
			switch (this.tabControlMain.SelectedIndex)
			{
				case 0:
					//this.tsbtnNew.Visible = false;
					break;

				case 1:
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
					break;

				case 1:
					break;

				default:
					break;
			}
		}

		private void tsbtnNew_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleNew();
		}

		private void tsbtnOpen_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleOpen();
		}

		private void tsbtnSave_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleSave();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleAdd();
		}

		private void tsbtnModify_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleModify();
		}

		private void tsbtnDuplicate_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleDuplicate();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleDelete();
		}

		private void tsbtnUndo_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleUndo();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleRefresh();
		}

		private void tsbtnFind_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleFind();
		}

		private void tsbtnGroup_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleGroup();
		}

		private void tsbtnOverlay_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleOverlay();
		}

		private void tabtnBackup_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleBackup();
		}

		public void UpdateTidyXmlFile(TidyXml tx)
		{
			TidyXml ck = TidyXmlLst.Find(txml => txml.XatType == TidyType.Anime);
			if (ck != null)
			{
				ck.XatName = tx.XatName;
				ck.XatPath = tx.XatPath;
			}
			else
			{
				TidyXmlLst.Add(tx);
			}

			WriteToTidyXmlFile(tx);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach (TabPage tab in this.tabControlMain.TabPages)
			{
				if (tab.Tag != null && !((ComTab)tab.Tag).PerformClosing())
				{
					e.Cancel = true;
					break;
				}
			}
		}
	}
}
