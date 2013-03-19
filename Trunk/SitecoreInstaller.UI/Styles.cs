using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
  using System.Drawing;
  using System.Drawing.Text;
  using System.Windows.Forms;

  public static class Styles
  {
    public static readonly FontFamily FontFamily = new FontFamily("Segoe UI", new InstalledFontCollection());

    public static class Fonts
    {
      public static readonly Font LblRegular = new Font(FontFamily, 8F, FontStyle.Regular);
      public static readonly Font PBold = new Font(FontFamily, 8F, FontStyle.Regular);
      public static readonly Font H2 = new Font(FontFamily, 10F, FontStyle.Bold);
      public static readonly Font H1 = new Font(FontFamily, 12F, FontStyle.Bold);

      public static class Colors
      {
        public static readonly Color Text = Color.FromArgb(176, 176, 176);
        public static readonly Color H1 = Color.FromArgb(0, 150, 250);
      }
    }

    public static class ProgressBar
    {
      public static readonly Color ProgressColor = Color.FromArgb(0, 150, 250);
    }

    public static class MainCtrl
    {
      public static readonly Color BackColor = Color.FromArgb(43, 43, 46);
    }

    public static class Navigation
    {
      public static class Main
      {
        public static readonly Size Size = new Size(200, 50);
        public static readonly Color ForeColor = Color.White;
        public static readonly Color ForeColorSelected = Color.FromArgb(58, 67, 77);
        public static readonly Color BackColor = Color.FromArgb(113, 177, 209);
        public static readonly Color BackColorSelected = Color.White;
        public static readonly Color BackColorMouseOver = Color.FromArgb(124, 193, 222);
        public static readonly Color BackColorClick = Color.FromArgb(81, 155, 189);
        public static readonly Color BackColorActive = BackColorMouseOver;
      }
    }

    public static class ListBoxes
    {
      public static readonly FlatStyle FlatStyle = FlatStyle.Flat;
      public static readonly Color BackColor = Color.FromArgb(113, 177, 209);
      public static readonly Color ForeColor = Color.FromArgb(255, 255, 255);
    }
  }
}
