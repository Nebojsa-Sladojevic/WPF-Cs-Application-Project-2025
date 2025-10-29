using ClientApplication.CustomUI;
using ClientApplication.Panels;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApplication.Windows
{

    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        private NavigationPaneButton? _selectedTab = null;
        public MainWindow()
        {
            if (Instance != null)
                throw new System.Exception("Only one instance of MainWindow is allowed.");
            Instance = this;
            InitializeComponent();
        }

        public void SelectTab(object sender, RoutedEventArgs e)
        {
            NavigationPaneButton clickedTab = sender as NavigationPaneButton;
            if (clickedTab == _selectedTab)
                return;
            if (_selectedTab != null)
                _selectedTab.IsTogglePressed = false;
            _selectedTab = clickedTab;
            clickedTab.IsTogglePressed = true;
            UpdateTabContent(clickedTab.Tag as string);
        }

        private void UpdateTabContent(string? tabTag)
        {
            switch (tabTag)
            {
                case null:
                    TabContent.Content = new Grid();
                    break;
                case "DocumentsView":
                    TabContent.Content = new DocumentsPanel();
                    break;
                default:
                    //TODO: Unknown tab error
                    break;
            }
        }
    }
}