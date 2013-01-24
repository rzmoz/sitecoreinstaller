using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.Navigation
{
    using System.Drawing;
    using System.Windows.Forms;

    public class MainNavigationButton : Button
    {
        public MainNavigationButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "MainNavigationButton";
            Size = Styles.Navigation.Main.Size;
            Font = Styles.Navigation.Main.Font;
            BackColor = Styles.Navigation.Main.BackColor;
            ForeColor = Styles.Navigation.Main.ForeColor;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleLeft;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Styles.Navigation.Main.BackColorMouseOver;
            FlatAppearance.MouseDownBackColor = Styles.Navigation.Main.BackColorClick;
            ResumeLayout(false);
        }
    }
}
