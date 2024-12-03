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

namespace apitimezonedb
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

        private async void FetchTimeButton_Click(object sender, RoutedEventArgs e)
        {
            string city = CityTextBox.Text.Trim();
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Proszę wpisać nazwę miasta.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var time = await ApiService.FetchTimeByTimeZone(city);
                if (!string.IsNullOrEmpty(time))
                {
                    TimeLstBox.Items.Clear();
                    TimeLstBox.Items.Add($"Czas w {city}: {time}");
                }
                else
                {
                    MessageBox.Show("Nie znaleziono danych dla tego miasta.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}