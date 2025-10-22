using ClientApplication.Panels;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button _selectedTab = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectTab(object sender, RoutedEventArgs e)
        {
            Button clickedTab = sender as Button;
            if (clickedTab == _selectedTab)
                return;
            _selectedTab = clickedTab;
            UpdateTabContent(clickedTab.Tag as string);
        }

        private void UpdateTabContent(string tabTag)
        {
            switch (tabTag)
            {
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