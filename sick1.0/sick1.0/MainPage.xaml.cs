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
    

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sick1._0
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbUsername.Text=="" && passwordBox.Password=="")
            {
                btLogin.IsEnabled = false;
            }
            else
            {
                btLogin.IsEnabled = true;
            }
            var ss = await WebRequest.Request(new Uri("http://localhost/javascript/e-learning.php"), new KeyValuePair<string, string>("login", "true"), new KeyValuePair<string, string>("username", tbUsername.Text), new KeyValuePair<string, string>("password", passwordBox.Password));
            if (ss == null)
            {
                MessageBox.Show("Onjuiste inlog gegevens");
                passwordBox.Password = "";
            }
            else
            {
                string sNaam = ss[0];
                string sConsulent = ss[1];
                MainPage currentFrame = new MainPage();
                Lessen les = new Lessen();
                if (sConsulent == "1")
                {
                    this.Frame.Navigate(typeof(Consulenten));
                }
                else
                {
                    this.Frame.Navigate(typeof(Lessen));
                }
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void tbUsername_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                 btLogin_Click(sender, e);
            }
        }
    }
}
