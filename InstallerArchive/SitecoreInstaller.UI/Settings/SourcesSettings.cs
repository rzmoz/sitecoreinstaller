using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Settings
{
    public partial class SourcesSettings : UserSettingsCtrl
    {
        public SourcesSettings()
        {
            InitializeComponent();
        }
        public override void Init()
        {
            Label = "Sources settings";
        }
    }
}
