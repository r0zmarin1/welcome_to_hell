using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hell_is_closed
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditWindow.xaml
    /// </summary>
    public partial class AddAndEditWindow : Window, INotifyPropertyChanged
    {
        public _666Context context;
        HttpClient httpClient = new HttpClient();
        JsonSerializerOptions options = new JsonSerializerOptions();

        public event PropertyChangedEventHandler? PropertyChanged;
        private Devil devil;
        public Devil Devil
        {
            get => devil;
            set
            {
                devil = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Devil)));
            }
        }

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

        public AddAndEditWindow(Rack rack, Devil devil)
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("http://localhost:5223/api/");
            DataContext = this;
            options = new JsonSerializerOptions { ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles, PropertyNameCaseInsensitive = true };
            Rack = rack;
            Devil = devil;
            GetDevils();
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
                Devil = Devils.FirstOrDefault(s => s.Id == Rack.IdDevil);
            }
        }

        private async void SaveRack(object sender, RoutedEventArgs e)
        {
            Rack.IdDevil = Devil.Id;
            Rack.IdDevilNavigation = Devil;
            if (Rack.Id == 0)
            {
                string arg = JsonSerializer.Serialize((RackBl)Rack, options);
                var responce = await httpClient.PostAsync($"Racks/CreateRack", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("ошибка");
                    return;
                }
                else
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("добавлено новое оборудование");
                    Close();
                }
            }
            else
            {
                string arg = JsonSerializer.Serialize((RackBl)Rack);
                var responce = await httpClient.PostAsync($"Racks/UpdateRack", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("ошибка");
                    return;
                }
                else
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("ответственный раб изменен");
                    Close();
                }
            }
        }

        private async void SavedEVIL(object sender, RoutedEventArgs e)
        {
            if (Devil.Id == 0)
            {
                string arg = JsonSerializer.Serialize(Devil);
                var responce = await httpClient.PostAsync($"Devils/CreateDevil", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("ошибка");
                    return;
                }
                else
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("дьявол прибыл на службу");
                    Close();
                }
            }
            else
            {
                string arg = JsonSerializer.Serialize(Devil);
                var responce = await httpClient.PostAsync($"Devils/EditDevil", new StringContent(arg, Encoding.UTF8, "application/json"));
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("ошибка");
                    return;
                }
                else
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    MessageBox.Show("дьявол поменял пол на ламинат");
                    Close();
                }
            }
        }

        private async void SavedEVILRank(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize(Devil);
            var responce = await httpClient.PostAsync($"Devils/UpdateDevil", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("ошибка");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                MessageBox.Show("дьявол обновил ранг!");
                Close();
            }
        }
    }
}
