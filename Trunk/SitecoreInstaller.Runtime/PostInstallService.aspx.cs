using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitecoreInstaller.Runtime
{
    public class PostInstallService : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCleanAdminWallpaper();
        }
        public void SetCleanAdminWallpaper()
        {
            var admin = Sitecore.Security.Accounts.User.FromName(@"sitecore\admin", true);
            var profile = admin.Profile;
            profile["WallPaper"] = string.Empty;
            profile.Save();
        }
    }
}