using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller
{
    using System.Threading;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.UI;
    using SitecoreInstaller.UI.Developer;
    using SitecoreInstaller.UI.Properties;
    using SitecoreInstaller.UI.Simple;
    using SitecoreInstaller.UI.UserSettingsDialogs;

    public partial class FrmMain : Form
    {
        private FrmUserSettings FrmUserSettings { get; set; }

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
            InitPipelineResult();

            InitPipelineWorker();
            InitPipelineStatus();
            InitUserSettings();//must be initialized before logger
            InitLogger();

            InitMainDeveloper();
            InitMainSimple();

            InitMainFormFunc();
        }

        private void InitPipelineResult()
        {
            pipelineResult1.Dock=DockStyle.Fill;
            pipelineResult1.Hide();
            pipelineResult1.SendToBack();
        }

        private void InitMenuItems()
        {
            useDeveloperLayoutToolStripMenuItem.Checked = UiUserSettings.Default.UseDeveloperMode;
        }

        private void InitUserSettings()
        {
            FrmUserSettings = new FrmUserSettings();
            FrmUserSettings.Init();
            Log.It.EntryLogged += FrmUserSettings.PipelineProgress.UpdateInfo;
            Services.PipelineWorker.StepExecuting += FrmUserSettings.PipelineProgress.UpdateStatus;
            Services.PipelineWorker.AllStepsExecuting += FrmUserSettings.PipelineWorkerOnAllStepsExecuting;
            Services.PipelineWorker.AllStepsExecuted += FrmUserSettings.PipelineWorkerOnAllStepsExecuted;

            if (UserSettings.Default.PromptForUserSettings)
            {
                FrmUserSettings.StepWizard.Start();
                FrmUserSettings.ShowDialog();
            }
            else
                FrmUserSettings.Hide();
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

        private void InitPipelineStatus()
        {
            pipelineStatus1.Dock = DockStyle.Fill;
            pipelineStatus1.BringToFront();
            pipelineStatus1.Hide();
            pipelineStatus1.Init();
        }

        private void InitPipelineWorker()
        {
            Services.PipelineWorker.AllStepsExecuting += PipelineWorkerOnAllStepsExecuting;
            Services.PipelineWorker.AllStepsExecuted += PipelineWorkerOnAllStepsExecuted;
            Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
        }

        void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorkerOnAllStepsExecuted;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                pipelineStatus1.Hide();
            }
        }

        private void PipelineWorkerOnAllStepsExecuted(object sender, PipelineEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorkerOnAllStepsExecuted;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                Services.BuildLibrary.Update();
                pipelineResult1.Result(e);
                pipelineResult1.Show();
                pipelineResult1.BringToFront();
                pipelineResult1.Ok.Focus();
            }
        }

        private void PipelineWorkerOnAllStepsExecuting(object sender, PipelineEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorkerOnAllStepsExecuting;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                pipelineStatus1.BringToFront();
                pipelineStatus1.Show();
            }
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
            Log.It.Clear();
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
            FrmUserSettings.StepWizard.Show(UserSettingsStep.Sql);
            FrmUserSettings.ShowDialog();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Show(UserSettingsStep.ProjectFolder);
            FrmUserSettings.ShowDialog();
        }

        private void sitecoreStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Show(UserSettingsStep.Sitecore);
            FrmUserSettings.ShowDialog();
        }


        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Show(UserSettingsStep.License);
            FrmUserSettings.ShowDialog();
        }

        private void settingsWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Start();
            FrmUserSettings.ShowDialog();
        }

        private void buildLibraryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Show(UserSettingsStep.BuildLibraryFolder);
            FrmUserSettings.ShowDialog();
        }

        private void urlPostfixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserSettings.StepWizard.Show(UserSettingsStep.UrlPostfix);
            FrmUserSettings.ShowDialog();
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogToolStripMenuItem.Checked = !showLogToolStripMenuItem.Checked;
            _mainFormFunc.Resize(showLogToolStripMenuItem.Checked);
        }
    }
}
