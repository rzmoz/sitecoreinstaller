namespace SitecoreInstaller.UI.Simple
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using SitecoreInstaller.App;

    public partial class MainSimple : UserControl
    {
        private readonly UninstallSimple _uninstallSimple;
        private readonly InstallSimple _installSimple;
        private readonly ReinstallSimple _reinstallSimple;
        private readonly OpenSimple _openSimple;
        

        public MainSimple()
        {
            _uninstallSimple = new UninstallSimple { Dock = DockStyle.Fill };
            _installSimple = new InstallSimple { Dock = DockStyle.Fill };
            _reinstallSimple = new ReinstallSimple { Dock = DockStyle.Fill };
            _openSimple = new OpenSimple { Dock = DockStyle.Fill };
            
            Controls.Add(_installSimple);
            Controls.Add(_uninstallSimple);
            Controls.Add(_reinstallSimple);
            Controls.Add(_openSimple);
            InitializeComponent();
        }

        public Panel PanelMain { get { return pnlMain; } }
        public UninstallSimple Uninstall { get { return _uninstallSimple; } }
        public InstallSimple Install { get { return _installSimple; } }
        public ReinstallSimple Reinstall { get { return _reinstallSimple  ; } }
        public OpenSimple Open { get { return _openSimple; } }

        public void Init()
        {
            pnlMain.Show();
            pnlMain.BringToFront();

            _uninstallSimple.Hide();
            _uninstallSimple.Init();
            _uninstallSimple.Cancelled += WizardStep_Cancelled;

            _installSimple.Hide();
            _installSimple.Init();
            _installSimple.Cancelled += WizardStep_Cancelled;


            _reinstallSimple.Hide();
            _reinstallSimple.Init();
            _reinstallSimple.Cancelled += WizardStep_Cancelled;

            _openSimple.Hide();
            _openSimple.Init(string.Empty);
            _openSimple.Cancelled += WizardStep_Cancelled;

            Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
        }

        void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WizardStep_Cancelled(sender, e);
        }

        void WizardStep_Cancelled(object sender, EventArgs e)
        {
            pnlMain.Show();
            pnlMain.BringToFront();
            _uninstallSimple.Hide();
            _installSimple.Hide();
            _reinstallSimple.Hide();
            _openSimple.Hide();
            
        }

        public void btnInstall_Click(object sender, EventArgs e)
        {
            _installSimple.Show();
            _installSimple.Init();
            _installSimple.BringToFront();
            _installSimple.Focus();
            pnlMain.Hide();
        }

        public void btnUninstall_Click(object sender, EventArgs e)
        {
            _uninstallSimple.Show();
            _uninstallSimple.Init();
            _uninstallSimple.BringToFront();
            pnlMain.Hide();
        }

        public void btnOpen_Click(object sender, EventArgs e)
        {
            _openSimple.Show();
            _openSimple.Init(Install.GetProjectSettings().ProjectName);
            _openSimple.BringToFront();
            pnlMain.Hide();
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            _reinstallSimple.Show();
            _reinstallSimple.Init();
            _reinstallSimple.BringToFront();
            pnlMain.Hide();
        }
    }
}
