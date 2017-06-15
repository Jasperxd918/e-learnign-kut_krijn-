using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace sick1._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CMS : Page
    {
        string naam;
        public CMS()
        {
            this.InitializeComponent();
            getData();
        }
        public async void getData()
        {
            var s1 = await WebRequest.Request(new Uri("http://localhost/javascript/e-learning.php"), new KeyValuePair<string, string>("gebruikers", "true"));
            
            foreach (var naam in s1)
            {
                Button b = new Button();
                b.Content = naam;
                b.Click += B_Click;
                listBox1.Items.Add(b);
            }
        }

        public void B_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            naam=b.Content.ToString();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            var s = await WebRequest.Request(new Uri("http://localhost/javascript/e-learning.php"), new KeyValuePair<string, string>("insert", "true"), new KeyValuePair<string, string>("username", tbNaam.Text), new KeyValuePair<string, string>("password", tbPassword.Text), new KeyValuePair<string, string>("consulent", tbconsulent.Text));
            if (tbconsulent.Text == "1")
            {
                MessageBox.Show("De Consulent is aangemaakt");
            }
            else
            {
                MessageBox.Show("De Leerling is aangemaakt");
            }
            this.Frame.Navigate(typeof(CMS));
        }

        private void btback_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Consulenten));
        }

        private void btsverwijderen_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Collapsed;
            Verwijder.Visibility = Visibility.Visible;

        }
        public async void Aanpasgegevensophalen()
        {
            var s = await WebRequest.Request(new Uri("http://localhost/javascript/e-learning.php"), new KeyValuePair<string, string>("aanpasgegevens", "true"), new KeyValuePair<string, string>("Name", naam));
            s[1] = tbnaam.Text;
            s[2] = psWachtwoord.Password;
            s[3] = tbtconsulent.Text;
        }

        private void btAanpassen_Click(object sender, RoutedEventArgs e)
        {
            Aanpassen.Visibility = Visibility.Visible;
            Aanpasgegevensophalen();
        }
    }
}
