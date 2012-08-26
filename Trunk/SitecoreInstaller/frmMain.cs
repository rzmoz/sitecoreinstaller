﻿using System;
using System.Windows.Forms;

namespace SitecoreInstaller
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.UI;
    using SitecoreInstaller.UI.Developer;
    using SitecoreInstaller.UI.Properties;
    using SitecoreInstaller.UI.Simple;
    using SitecoreInstaller.UI.UserSettingsDialogs;

    public partial class FrmMain : Form
    {
        private MainFormFunc _mainFormFunc;
        internal Panel PanelMain { get { return pnlMain; } }
        internal Logger Logger { get { return logger1; } }
        internal MainDeveloper MainDeveloper { get { return mainDeveloper1; } }
        internal MainSimple MainSimple { get { return mainSimple1; } }

        public FrmMain()
        {
            Services.Init();
            Services.BuildLibrary.Update();

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitMenuItems();

            InitPipelineWorker();
            InitPipelineProgress();
            InitStepWizard();
            InitLogger();

            InitMainDeveloper();
            InitMainSimple();

            InitMainFormFunc();
        }

        private void InitMenuItems()
        {
            useDeveloperLayoutToolStripMenuItem.Checked = UiUserSettings.Default.UseDeveloperMode;
        }

        private void InitStepWizard()
        {
            stepWizardDialog1.Dock = DockStyle.Fill;
            stepWizardDialog1.Init();
            stepWizardDialog1.Hide();

            if (UserSettings.Default.PromptForUserSettings)
            {
                stepWizardDialog1.Start();
            }
        }


        void PipelineWorker_WorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            FlashWindow.Flash(this, 3);

        }

        void PipelineWorker_PreconditionNotMet(object sender, GenericEventArgs<string> e)
        {
            this.CrossThreadSafe(() => Services.Dialogs.ModalDialog(MessageBoxIcon.Error, e.Arg, string.Empty));
        }

        private void InitLogger()
        {
            logger1.Init();
        }

        private void InitMainSimple()
        {
            mainSimple1.Dock = DockStyle.Fill;
            mainSimple1.Show();
            mainSimple1.Init();
        }

        private void InitMainDeveloper()
        {
            mainDeveloper1.Dock = DockStyle.Fill;
            mainDeveloper1.Init();
            mainDeveloper1.Hide();
        }

        private void InitPipelineProgress()
        {
            pipelineProgress1.Dock = DockStyle.Fill;
            pipelineProgress1.Hide();
            pipelineProgress1.Init();
        }

        private void InitPipelineWorker()
        {
            Services.PipelineWorker.AllStepsExecuting += PipelineWorkerOnAllStepsExecuting;
            Services.PipelineWorker.AllStepsExecuting += pipelineProgress1.Starting;
            Services.PipelineWorker.AllStepsExecuted += pipelineProgress1.Ended;
            Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
            Services.PipelineWorker.PreconditionNotMet += PipelineWorker_PreconditionNotMet;
        }

        private void PipelineWorkerOnAllStepsExecuting(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
            {
                pipelineProgress1.BringToFront();
                pipelineProgress1.Show();
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Services.PipelineWorker.IsBusy() == false)
                return;
            if (Services.Dialogs.UserAccept("A task is currently running. Do you want to wait while it finishes?") == false)
                return;
            e.Cancel = true;
            base.OnFormClosing(e);
        }

        private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services.Dialogs.OnlineHelp();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services.Dialogs.About();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ItAs.Clear();
        }

        private void InitMainFormFunc()
        {
            if (UiUserSettings.Default.UseDeveloperMode)
                _mainFormFunc = new MainFormDeveloperFunc(this);
            else
                _mainFormFunc = new MainFormSimpleFunc(this);
            _mainFormFunc.Resize(showLogToolStripMenuItem.Checked);
            MainDeveloper.SelectionsDeveloper.FocusProjectcName();
        }

        private void installSitecoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainFormFunc.Install(sender, e);
        }

        private void uninstallSitecoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainFormFunc.Uninstall(sender, e);
        }

        private void useDeveloperLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Services.PipelineWorker.IsBusy())
                return;

            useDeveloperLayoutToolStripMenuItem.Checked = !useDeveloperLayoutToolStripMenuItem.Checked;
            showLogToolStripMenuItem.Visible = !useDeveloperLayoutToolStripMenuItem.Checked;
            UiUserSettings.Default.UseDeveloperMode = useDeveloperLayoutToolStripMenuItem.Checked;
            UiUserSettings.Default.Save();
            InitMainFormFunc();
            Services.BuildLibrary.Update();
        }

        private void updateSelectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services.BuildLibrary.Update();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            _mainFormFunc.KeyUp(sender, e);
        }

        private void doNothingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetNoting());
        }

        private void openSitecoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainFormFunc.OpenSitecore(sender, e);
        }

        private void openFrontendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainFormFunc.OpenFrontend(sender, e);
        }

        private void sqlSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.Sql);
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.ProjectFolder);
        }

        private void sitecoreStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.Sitecore);
        }


        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.License);
        }

        private void settingsWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Start();
        }

        private void buildLibraryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.BuildLibraryFolder);
        }

        private void urlPostfixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepWizardDialog1.Show(UserSettingsStep.UrlPostfix);
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogToolStripMenuItem.Checked = !showLogToolStripMenuItem.Checked;
            _mainFormFunc.Resize(showLogToolStripMenuItem.Checked);
        }
    }
}
