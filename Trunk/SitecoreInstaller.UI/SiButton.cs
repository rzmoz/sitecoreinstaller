using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
    using System.Drawing;
    using System.Windows.Forms;

    public class SIButton : Button
    {
        private Color InitColor = Color.Chartreuse; //this color equeals not set - hope no one uses this color ever!

        public SIButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            TextImageRelation = TextImageRelation.ImageBeforeText;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextAlign = ContentAlignment.MiddleLeft;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            ForeColorNotSelected = InitColor;
            BackColorNotSelected = InitColor;

            ResumeLayout(false);
        }



        public void Activate()
        {
            if (BackColorNotSelected.Equals(InitColor))
                BackColorNotSelected = BackColor;

            BackColor = BackColorSelected;

            if (ForeColorNotSelected.Equals(InitColor))
                ForeColorNotSelected = ForeColor;
            
            ForeColor = ForeColorSelected;

            if (ImageNotSelected == null)
                ImageNotSelected = Image;

            if (ImageSelected != null)
                Image = ImageSelected;
        }
        public void DeActivate()
        {
            if (BackColorNotSelected.Equals(InitColor))
                BackColorNotSelected = BackColor;

            BackColor = BackColorNotSelected;

            if (ForeColorNotSelected.Equals(InitColor))
                ForeColorNotSelected = ForeColor;

            ForeColor = ForeColorNotSelected;

            if (ImageNotSelected == null)
                ImageNotSelected = Image;

            Image = ImageNotSelected;




        }

        public Color ForeColorSelected { get; set; }
        private Color ForeColorNotSelected { get; set; }

        public Color BackColorSelected { get; set; }
        private Color BackColorNotSelected { get; set; }

        public Image ImageSelected { get; set; }
        private Image ImageNotSelected { get; set; }
    }
}
