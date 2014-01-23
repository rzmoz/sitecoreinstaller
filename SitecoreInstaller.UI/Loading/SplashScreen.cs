using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI.Loading
{
    public partial class SplashScreen : BasicsUserControl
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BackColor = Styles.Controls.BackColor;
            timer1.Start();
            timer1.Interval = 30;
            lblTitle.Width = Width;
            lblTitle.Height = Height;
        }

        public void Stop()
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if we reached right side, then we go back
            var rightProximity = Width - picLogo.Right;
            var leftProximity = picLogo.Left;

            if (rightProximity < 50 || leftProximity < 50)
                _movePicOffSet = _movePicOffSet * -1;

            picLogo.Left += _movePicOffSet;
        }

        private int _movePicOffSet = 3;
    }
}
