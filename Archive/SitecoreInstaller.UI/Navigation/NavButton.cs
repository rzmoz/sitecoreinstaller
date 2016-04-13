namespace SitecoreInstaller.UI.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using SitecoreInstaller.UI.Forms;

    public class NavButton : SIButtonWithActiveState
    {
        public NavButton(Control targetControl)
        {
            if (targetControl == null) { throw new ArgumentNullException("targetControl"); }
            this.TargetControl = targetControl;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleLeft;
        }

        public Control TargetControl { get; private set; }

        public override void Activate()
        {
            base.Activate();

            if (this.TargetControl != null)
                this.TargetControl.BringToFront();
        }

        #region tree methods

        public string Path
        {
            get { return this.GetPath(this); }
        }

        private string GetPath(NavButton button)
        {
            if (button == null)
                return string.Empty;

            var myPath = "/" + button.Text.ToLower().Replace(" ", string.Empty);

            if (button.IsRoot)
                return myPath;

            return button.GetPath(button.ParentButton) + myPath;
        }

        public IEnumerable<NavButton> GetAllDescendants()
        {
            return this.GetAllDescendants(this);
        }

        private IEnumerable<NavButton> GetAllDescendants(NavButton button)
        {
            return button.SubButtons.SelectMany(subButton => subButton.GetAllDescendants(subButton));
        }


        /// <summary>
        /// zero based
        /// </summary>
        public int Level
        {
            get { return this.GetLevel(this); }
        }

        private int GetLevel(NavButton button)
        {
            if (button.IsRoot || button.ParentButton.IsRoot)
                return 0;
            return 1 + this.GetLevel(this.ParentButton);
        }

        public IEnumerable<NavButton> SubButtons
        {
            get { return this.Controls.OfType<NavButton>(); }
        }

        public NavButton ParentButton
        {
            get { return this.Parent as NavButton; }
        }

        public bool IsRoot
        {
            get { return this.ParentButton == null; }
        }

        #endregion
    }
}