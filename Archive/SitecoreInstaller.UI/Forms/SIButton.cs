using System.Drawing;
using CSharp.Basics.Forms;

namespace SitecoreInstaller.UI.Forms
{
    using System.Windows.Forms;

    public class SIButton : Button
    {
        public SIButton()
        {
            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = Styles.Fonts.DarkBg.Colors.Text;
            Font = Styles.Fonts.LblRegular;
            ForeColor = Styles.Fonts.DarkBg.Colors.Text;
            BottomDividerColor = Styles.Theme.Dark.Controls.BackColor;
        }

        protected ToolTip ToolTip { get; private set; }

        public bool DrawBottomDivider { get; set; }
        public Color BottomDividerColor { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!DrawBottomDivider)
                return;
            var pen = new Pen(BottomDividerColor) { Width = 1 };
            e.Graphics.DrawLine(pen, 0, Height - 1, Width, Height - 1);
        }

        public void Init(ToolTip toolTip)
        {
            ToolTip = toolTip;
        }

        public void SetToolTip(string text)
        {
            this.CrossThreadSafe(() =>
            {
                if (ToolTip == null || text == null)
                    return;
                ToolTip.SetToolTip(this, text);
            });
        }
    }
}
