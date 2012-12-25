using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
    using System.Drawing;
    using System.Drawing.Text;

    public static class Styles
    {
        public static readonly FontFamily FontFamily = new FontFamily("Segoe UI", new InstalledFontCollection());

        public static class Navigation
        {
            public static class Main
            {
                public static readonly Font Font = new Font(FontFamily, 10F, FontStyle.Bold);
                public static readonly Size Size = new Size(200, 50);
                public static readonly Color ForeColor = Color.White;
                public static readonly Color BackColor = Color.FromArgb(113, 177, 209);
                public static readonly Color BackColor_MouseOver = Color.FromArgb(124, 193, 222);
                public static readonly Color BackColor_Click = Color.FromArgb(81, 155, 189);
            }
        }
    }
}
