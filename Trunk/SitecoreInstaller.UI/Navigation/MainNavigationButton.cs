using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.Navigation
{
    public class MainNavigationButton : SIButton
    {
        public MainNavigationButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Size = Styles.Navigation.Main.Size;
            Font = Styles.Navigation.Main.Font;
            BackColor = Styles.Navigation.Main.BackColor;
            BackColorSelected = Styles.Navigation.Main.BackColorSelected;
            ForeColor = Styles.Navigation.Main.ForeColor;
            ForeColorSelected = Styles.Navigation.Main.ForeColorSelected;

            FlatAppearance.MouseOverBackColor = Styles.Navigation.Main.BackColorMouseOver;
            FlatAppearance.MouseDownBackColor = Styles.Navigation.Main.BackColorClick;
            
            ResumeLayout(false);
        }
    }
}
