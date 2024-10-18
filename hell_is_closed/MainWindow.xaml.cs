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

namespace hell_is_closed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDevil(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow();
            addAndEditWindow.Show();
        }

        private void EditDevilName(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow();
            addAndEditWindow.Show();
        }

        private void UpdateDevilRank(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteDevil(object sender, RoutedEventArgs e)
        {

        }

        private void AddRack(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow();
            addAndEditWindow.Show();
        }

        private void UpdateRack(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow();
            addAndEditWindow.Show();
        }

        private void DeleteRack(object sender, RoutedEventArgs e)
        {

        }
    }
}