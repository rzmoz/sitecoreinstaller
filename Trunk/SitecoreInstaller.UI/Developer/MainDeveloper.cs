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
            
            _selectAppPoolSettings1.Init();
            _selectionsDeveloper1.Init(_selectAppPoolSettings1.GetAppPoolSettings);
            _pipelineLists1.Init(_selectionsDeveloper1.GetAppSettings);
        }
    }
}
