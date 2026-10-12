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

namespace WpfAppkk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string haslo = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        /*****************************************************
nazwa funkcji: GenerujHaslo
opis funkcji: Generuje losowe hasło o określonej długości,
              zawierające wybrane rodzaje znaków.
parametry: brak
zwracany typ i opis: string – wygenerowane hasło
autor: Erwin Wawer
*****************************************************/
        private void GenerujHaslo_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtDlugosc.Text, out int dlugosc)
                || dlugosc < 4 || dlugosc > 30)
            {
                MessageBox.Show("Podaj liczbę znaków od 4 do 30");
                return;
            }

            string male = "abcdefghijklmnopqrstuvwxyz";
            string wielkie = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string specjalne = "!@#$%^&*()_+-=";

            string znaki = male;

            if (chkLitery.IsChecked == true)
                znaki += wielkie;
            if (chkCyfry.IsChecked == true)
                znaki += cyfry;
            if (chkSpecjalne.IsChecked == true)
                znaki += specjalne;

            Random losuj = new Random();
            StringBuilder wynik = new StringBuilder();

            for (int i = 0; i < dlugosc; i++)
            {
                int indeks = losuj.Next(znaki.Length);
                wynik.Append(znaki[indeks]);
            }

            haslo = wynik.ToString();

            MessageBox.Show(haslo, "Wygenerowane hasło");
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Najpierw hasło");
                return;
            }

            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string stanowisko = (cmbStanowisko.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            string komunikat = $"Dane pracownika : {imie} {nazwisko} {stanowisko} Hasło: {haslo}";

            MessageBox.Show(komunikat, "Dane pracownika");
        }
    }
}