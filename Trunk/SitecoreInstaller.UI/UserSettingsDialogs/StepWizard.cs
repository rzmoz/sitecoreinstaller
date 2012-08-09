using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    using System.Collections;

    public class StepWizard : IEnumerable<UserSettingsDialog>
    {
        private readonly UserSettingsDialog _firstStep;
        private readonly IDictionary<UserSettingsStep, UserSettingsDialog> _stepIndex;

        public StepWizard()
        {
            var firstRunWelcome = new FirstRunWelcome();
            var sqlDialog = new SqlSettingsDialog();
            var projectFolderDialog = new ProjectFolderDialog();
            var buildLibraryFolderDialog = new BuildLibraryFolderDialog();
            var firstRunFinish = new FirstRunFinish();

            _firstStep = firstRunWelcome;
            firstRunWelcome.Next = sqlDialog;
            sqlDialog.Previous = firstRunWelcome;
            sqlDialog.Next = projectFolderDialog;
            projectFolderDialog.Previous = sqlDialog;
            projectFolderDialog.Next = buildLibraryFolderDialog;
            buildLibraryFolderDialog.Previous = projectFolderDialog;
            buildLibraryFolderDialog.Next = firstRunFinish;
            firstRunFinish.Previous = buildLibraryFolderDialog;

            _stepIndex = new Dictionary<UserSettingsStep, UserSettingsDialog>
                {
                    { UserSettingsStep.FirstRunWelcome, firstRunWelcome },
                    { UserSettingsStep.Sitecore, new SitecoreDialog()},
                    { UserSettingsStep.License, new LicenseFileDialog()},
                    { UserSettingsStep.Sql, sqlDialog },
                    { UserSettingsStep.ProjectFolder, projectFolderDialog },
                    { UserSettingsStep.BuildLibraryFolder, buildLibraryFolderDialog },
                    { UserSettingsStep.UrlPostfix, new UrlPostfixDialog()},
                    { UserSettingsStep.FirstRunFinish, firstRunFinish}
                };
        }

        public void Init()
        {
            foreach (var step in this)
            {
                step.UserSettingsMode = UserSettingsMode.Single;
                step.Init();
                step.Hide();
            }
        }

        public void Start()
        {
            foreach (var step in this)
            {
                step.Hide();
                step.UserSettingsMode = UserSettingsMode.StepWizard;
            }

            _firstStep.Show();
        }

        public IEnumerator<UserSettingsDialog> GetEnumerator()
        {
            return _stepIndex.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Show(UserSettingsStep step)
        {
            foreach (var userStep in this)
                userStep.Hide();

            _stepIndex[step].UserSettingsMode = UserSettingsMode.Single;
            _stepIndex[step].Show();
            _stepIndex[step].Init();
        }
    }
}
