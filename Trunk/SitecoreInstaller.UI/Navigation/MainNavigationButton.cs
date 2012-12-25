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
            this.SuspendLayout();
            // 
            // MainNavigationButton
            // 
            this.Name = "MainNavigationButton";
            this.Size = Styles.Navigation.Main.Size;
            Font = Styles.Navigation.Main.Font;
            BackColor = Styles.Navigation.Main.BackColor;
            ForeColor = Styles.Navigation.Main.ForeColor;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleLeft;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Styles.Navigation.Main.BackColor_MouseOver;
            FlatAppearance.MouseDownBackColor = Styles.Navigation.Main.BackColor_Click;
            Click += MainNavigationButton_Click;
            this.ResumeLayout(false);
        }

        void MainNavigationButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
