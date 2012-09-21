namespace SitecoreInstaller.UI.Developer
{
    using System.Windows.Forms;

    public partial class MainDeveloper : UserControl
    {
        public MainDeveloper()
        {
            InitializeComponent();
        }

        public Panel PanelAdvanced { get { return pnlAdvanced; } }
        public SelectionsDeveloper SelectionsDeveloper { get { return _selectionsDeveloper1; } }

        public void Init()
        {
            advancedSettings1.Init();
            _selectionsDeveloper1.Init(advancedSettings1.GetIisSettings, advancedSettings1.GetInstallType);
            _pipelineLists1.Init(_selectionsDeveloper1.GetProjectSettings);
        }
    }
}
