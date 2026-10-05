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

namespace WpfAppppp
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
        
        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string haslo = PasswordBox.Password;
            string powtorzHaslo = RepeatPasswordBox.Password;

            if (!email.Contains("@"))
            {
                MessageTextBlock.Text = "Nieprawidłowy adres e-mail";
                MessageTextBlock.Foreground = Brushes.Red;
            }
            else if (haslo.Length < 6)
            {
                
                MessageTextBlock.Text =
                    "Hasło musi mieć co najmniej 6 znaków";
                MessageTextBlock.Foreground = Brushes.Red;
            }
            else if (haslo != powtorzHaslo)
            {
                MessageTextBlock.Text = "Hasła się różnią";
                MessageTextBlock.Foreground = Brushes.Red;
            }
            else
            {
                MessageTextBlock.Text = "Witaj " + email;
                MessageTextBlock.Foreground = Brushes.Green;

                PasswordBox.Clear();
                RepeatPasswordBox.Clear();
            }
            
        }
        
    }
}