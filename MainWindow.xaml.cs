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

namespace cieploZimnoKolory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int r = 0;
        int g = 0;
        int b = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void wylosujKolor_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            SolidColorBrush kolor = new SolidColorBrush();

            r = random.Next(0, 256);
            g = random.Next(0, 256);
            b = random.Next(0, 256);

            //Title = $"R: {r}, G: {g}, B: {b}";

            kolor.Color = Color.FromRgb((byte)r,(byte)g,(byte)b);

            wylosowanyKolorProstokat.Fill = kolor;
        }

        private void sprawdzJakBlisko_Click(object sender, RoutedEventArgs e)
        {
            int podanyCzerw = 0;
            int podanyZiel = 0;
            int podanyNieb = 0;

            bool czyPoprawnyCzerw = int.TryParse(skladCzerw.Text.ToString(), out podanyCzerw);
            bool czyPoprawnyZiel = int.TryParse(skladZiel.Text.ToString(), out podanyZiel);
            bool czyPoprawnyNieb = int.TryParse(skladNieb.Text.ToString(), out podanyNieb);

            if(czyPoprawnyCzerw && czyPoprawnyZiel && czyPoprawnyNieb)
            {

                SolidColorBrush wybranyKolor = new SolidColorBrush();
                wybranyKolor.Color = Color.FromRgb((byte)podanyCzerw, (byte)podanyZiel, (byte)podanyNieb);
                czyPoprawnyKolorProstokat.Fill = wybranyKolor;

                if(podanyCzerw == r)
                {
                    jakBliskoCzerw.Text = "=";
                }
                else if(podanyCzerw < r)
                {
                    jakBliskoCzerw.Text = "<";
                }
                else
                {
                    jakBliskoCzerw.Text = ">";
                }

                if(podanyZiel == g)
                {
                    jakBliskoZiel.Text = "=";
                }
                else if(podanyZiel < g)
                {
                    jakBliskoZiel.Text = "<";
                }
                else
                {
                    jakBliskoZiel.Text = ">";
                }

                if(podanyNieb == b)
                {
                    jakBliskoNieb.Text = "=";
                }
                else if(podanyNieb < b)
                {
                    jakBliskoNieb.Text = "<";
                }
                else
                {
                    jakBliskoNieb.Text = ">";
                }
            }
            else
            {
                MessageBox.Show("Wartosci nie sa poprawne!");
            }
        }
    }
}