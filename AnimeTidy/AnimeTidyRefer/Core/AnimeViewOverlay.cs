using AnimeTidyLib;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace AnimeTidy.Core
{
	public class AnimeViewOverlay : AbstractOverlay
	{
		public AnimeViewOverlay()
		{
			this.Transparency = 230;
		}

		public override void Draw(ObjectListView olv, Graphics g, Rectangle r)
		{
			if (olv.HotRowIndex < 0)
				return;

			Anime a = olv.GetModelObject(olv.HotRowIndex) as Anime;
			if (a == null)
				return;

			Rectangle rhrow = olv.GetItem(olv.HotRowIndex).Bounds;
			Rectangle rView = rhrow.Bottom + iSpacing * 2 + ih > r.Bottom ?
				new Rectangle(r.Right - iw - iSpacing, rhrow.Top - ih - iSpacing, iw, ih) :
				new Rectangle(r.Right - iw - iSpacing, rhrow.Bottom + iSpacing, iw, ih);

			//Rectangle rView;
			//if (olv.HotRowIndex - olv.TopItemIndex < 9)
			//	rView = new Rectangle(r.Right - iw - iSpacing, r.Bottom - ih - iSpacing, iw, ih);
			//else
			//	rView = new Rectangle(r.Right - iw - iSpacing, r.Top + iSpacing + 10, iw, ih);

			this.DrawAnimeView(g, rView, a);
		}

		private Pen BorderPen = Pens.DarkSalmon;
		private Brush BackBrush = Brushes.LemonChiffon;
		private Pen PicBorder = Pens.DarkGray;
		private Brush TitleBrush = Brushes.DodgerBlue;
		private Brush TextBrush = Brushes.DarkSlateGray;

		private const int iw = 240;
		private const int ih = 120;
		private const int iSpacing = 8;
		private const int iPicW = 80;

		private void DrawAnimeView(Graphics g, Rectangle r, Anime av)
		{
			//Rectangle rView = new Rectangle(r.Right - iw - iSpacing, r.Bottom - ih - iSpacing, iw, ih);
			Rectangle rView = r;

			// Allow a border around the card
			rView.Inflate(-1, -1);

			// Draw view background
			GraphicsPath path = new GraphicsPath();
			path.AddRectangle(rView);
			g.FillPath(this.BackBrush, path);
			g.DrawPath(this.BorderPen, path);
			g.Clip = new Region(rView);

			// Draw the pic 80*102
			Rectangle rPic = rView;
			rPic.Inflate(-8, -8);
			rPic.Width = iPicW;
			string strPic = String.Format(@".\Anime\{0:000}.png", av.ID);
			if (File.Exists(strPic))
			{
				Image img = Image.FromFile(strPic);
				//if (img.Width > rPic.Width)
				//	rPic.Height = (int)(img.Height * ((float)rPic.Width / img.Width));
				//else
				//	rPic.Height = img.Height;
				int imgW = img.Width;
				int imgH = img.Height;

				if (imgW > rPic.Width)
				{
					imgH = (int)(imgH * ((float)rPic.Width / imgW));
					imgW = rPic.Width;
				}

				if (imgH > rPic.Height)
				{
					imgW = (int)(imgW * ((float)rPic.Height / imgH));
					imgH = rPic.Height;
				}

				Rectangle destPic = new Rectangle();
				destPic.X = rPic.X + (rPic.Width - imgW) / 2;
				destPic.Y = rPic.Y + (rPic.Height - imgH) / 2;
				destPic.Width = imgW;
				destPic.Height = imgH;

				g.DrawImage(img, destPic);
			}
			else
				g.DrawRectangle(this.PicBorder, rPic);

			// Draw the text portion
			Rectangle rText = rPic;
			rText.X += (rPic.Width + 8);
			rText.Width = rView.Right - rText.X - 8;

			StringFormat fmt = new StringFormat();
			fmt.FormatFlags = StringFormatFlags.LineLimit;
			// 指定将文本修整成最接近的字符，并在被修整的行的末尾插入一个省略号
			fmt.Trimming = StringTrimming.EllipsisCharacter;
			// 水平对齐方式
			fmt.Alignment = StringAlignment.Center;
			// 垂直对齐方式
			fmt.LineAlignment = StringAlignment.Center;

			String txt = av.Name.Length == 0 ? av.Title : av.Name;

			using (Font ft = new Font("Tahoma", 9, FontStyle.Bold))
			{
				SizeF sf = g.MeasureString(txt, ft, rText.Width, fmt);
				rText.Height = (int)sf.Height;
				g.DrawString(txt, ft, this.TitleBrush, rText, fmt);

				rText.Y += rText.Height + 5;
			}

			fmt.Alignment = StringAlignment.Near;

			// Draw the other infos
			using (Font ft = new Font("Meiryo UI", 8, FontStyle.Regular))
			{
				txt = "Kana: " + av.Kana;
				SizeF sf = g.MeasureString(txt, ft, rText.Width, fmt);
				rText.Height = (int)sf.Height;
				g.DrawString(txt, ft, this.TextBrush, rText, fmt);
			}

			using (Font ft = new Font("Tahoma", 8))
			{
				rText.Y += rText.Height;
				txt = "Episode: " + av.Episode;
				SizeF sf = g.MeasureString(txt, ft, rText.Width, fmt);
				rText.Height = (int)sf.Height;
				g.DrawString(txt, ft, this.TextBrush, rText, fmt);

				rText.Y += rText.Height;
				txt = "Inc: " + av.Inc;
				sf = g.MeasureString(txt, ft, rText.Width, fmt);
				rText.Height = (int)sf.Height;
				g.DrawString(txt, ft, this.TextBrush, rText, fmt);
			}

			fmt.Alignment = StringAlignment.Far;

			using (Font ft = new Font("Tahoma", 7))
			{
				txt = "ID: "+ av.ID;
				SizeF sf = g.MeasureString(txt, ft, rText.Width, fmt);
				rText.Height = (int)sf.Height;
				rText.Y = rView.Bottom - rText.Height - 4;
				g.DrawString(txt, ft, this.TextBrush, rText, fmt);
			}
		}
	}
}
