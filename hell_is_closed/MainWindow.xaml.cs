using System.ComponentModel;
using System.IO.Packaging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace hell_is_closed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public _666Context context;
        HttpClient httpClient = new HttpClient();

        public event PropertyChangedEventHandler? PropertyChanged;

        public Devil Devil { get; set; }
        public Disposal Disposal { get; set; }
        public Rack Rack { get; set; }
        private List<Devil> devils;
        public List<Devil> Devils
        {
            get => devils;
            set
            {
                devils = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Devils)));
            }
        }

        private List<Disposal> disposals;
        public List<Disposal> Disposals
        {
            get => disposals;
            set
            {
                disposals = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disposals)));
            }
        }

        private List<Rack> racks;
        public List<Rack> Racks
        {
            get => racks;
            set
            {
                racks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Racks)));
            }
        }
        private DispatcherTimer timer = null;

        public MainWindow()
        {
            InitializeComponent();
            options = new JsonSerializerOptions { ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles, PropertyNameCaseInsensitive = true };
            httpClient.BaseAddress = new Uri("http://localhost:5223/api/");
            DataContext = this;
            GetDevils();
            GetDisposals();
            GetRacks();
            timerStart();
        }

        public void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e) //к таймеру относится 
        {
            Thread thread1 = new Thread(GetDevils);
            thread1.Start();
            Thread thread2 = new Thread(GetDisposals);
            thread2.Start();
            Thread thread3 = new Thread(GetRacks);
            thread3.Start();
        }

        public async void GetDevils()
        {
            var responce = await httpClient.PostAsync($"Devils/GetDevils", new StringContent("", Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("все плохо у дьявола");
                return;
            }
            else
            {
                var devils = await responce.Content.ReadFromJsonAsync<List<Devil>>();
                Devils = new List<Devil>(devils);
            }
        }

        public async void GetDisposals()
        {
            var responce = await httpClient.PostAsync($"Disposal/GetDisposals", new StringContent("", Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("все плохо у утили");
                return;
            }
            else
            {
                var disposals = await responce.Content.ReadFromJsonAsync<List<Disposal>>();
                Disposals = new List<Disposal>(disposals);
            }
        }
        JsonSerializerOptions options = new JsonSerializerOptions();


        public async void GetRacks()
        {
            var responce = await httpClient.PostAsync($"Racks/GetRacks", new StringContent("", Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("все плохо у оборудования");
                return;
            }
            else
            {
                var racks = await responce.Content.ReadFromJsonAsync<List<Rack>>(options);
                Racks = new List<Rack>(racks);
            }
        }

        private void AddDevil(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(new Rack(), new Devil());
            addAndEditWindow.Show();
        }

        private void EditDevilName(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(new Rack(), Devil);
            addAndEditWindow.Show();
        }

        private void UpdateDevilRank(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteDevil(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize(Devil);
            var responce = await httpClient.PostAsync($"Devils/DeleteDevil", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("ошибка");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("изгнан");
            }
        }

        private void AddRack(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(new Rack(), new Devil());
            addAndEditWindow.Show();
        }

        private void UpdateRack(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(Rack, new Devil());
            addAndEditWindow.Show();
        }

        private async void DeleteRack(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize((RackBl)Rack, options);
            var responce = await httpClient.PostAsync($"Disposal/DeleteRacks", 
                new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show(result);
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("перемещено в утиль");
            }
        }

    }
}
