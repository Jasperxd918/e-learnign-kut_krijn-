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
    public sealed partial class Lessen : Page
    {
        string _sAntwoord;
        string sNaam;
        int iScore = 0;
        int ivraag = 0;
        public Lessen(string naam)
        {
            sNaam = naam;
            this.InitializeComponent();
            tbNaam.Text = sNaam;
            tbaantalvraag.Text = ivraag.ToString();
            
        }

        private void btnWiskunde_Click(object sender, RoutedEventArgs e)
        {
           foreach(Grid g in grids.Children )
            {
                g.Visibility = Visibility.Collapsed;
            }
           ((Grid)grids.FindName(((Button)sender).Content.ToString())).Visibility = Visibility.Visible;
        }

        private async void btnrek1_Click(object sender, RoutedEventArgs e)
        {
            btnrek1.Visibility = Visibility.Collapsed;
            btnrek2.Visibility = Visibility.Collapsed;
            btnrek3.Visibility = Visibility.Collapsed;

            var ss = await WebRequest.Request(new Uri("http://localhost/elearning/e-learning.php"), new KeyValuePair<string, string>("somhalen", "true"));
            if (ss == null)
            {
                MessageBox.Show("Er is iets mis gegeaan, probeer opnieuw!");
            }
            else
            {
                string sSom = ss[0];
                 _sAntwoord = ss[1];
                string sOptie1 = ss[2];
                string sOptie2 = ss[3];
                string sOptie3 = ss[4];
                string sOptie4 = ss[5];


                tbsom.Visibility = Visibility.Visible;
                antwoord1.Visibility = Visibility.Visible;
                antwoord2.Visibility = Visibility.Visible;
                antwoord3.Visibility = Visibility.Visible;
                antwoord4.Visibility = Visibility.Visible;
                btnvolgende.Visibility = Visibility.Visible;
                tbaantalvraag.Visibility = Visibility.Visible;
                tbaantalvraag1.Visibility = Visibility.Visible;

                tbsom.Text = sSom;
                antwoord1.Content = sOptie1;
                antwoord2.Content = sOptie2;
                antwoord3.Content = sOptie3;
                antwoord4.Content = sOptie4;

            }
        }

        private async void btnvolgende_Click(object sender, RoutedEventArgs e)
        {


            if (ivraag == 10)
            {
                double icijfer;
                if (iScore == 10)
                {
                     icijfer = 10;
                }
                else
                {
                     icijfer = iScore * 0.8;
                }
                
                MessageBox.Show("je punt is "+icijfer.ToString());
                tbsom.Visibility = Visibility.Collapsed;
                antwoord1.Visibility = Visibility.Collapsed;
                antwoord2.Visibility = Visibility.Collapsed;
                antwoord3.Visibility = Visibility.Collapsed;
                antwoord4.Visibility = Visibility.Collapsed;
                btnvolgende.Visibility = Visibility.Collapsed;
                tbaantalvraag.Visibility = Visibility.Collapsed;
                tbaantalvraag1.Visibility = Visibility.Collapsed;

                btnrek1.Visibility = Visibility.Visible;
                btnrek2.Visibility = Visibility.Visible;
                btnrek3.Visibility = Visibility.Visible;
            }
            else
            {


                var checkedButton = radiobuttons.Children.OfType<RadioButton>().Where(a => a.IsChecked == true).FirstOrDefault();
                if (checkedButton.Content.ToString() == _sAntwoord)
                {
                    iScore++;
                    ivraag++;
                    var ss = await WebRequest.Request(new Uri("http://localhost/elearning/e-learning.php"), new KeyValuePair<string, string>("somhalen", "true"));
                    if (ss == null)
                    {
                        MessageBox.Show("Er is iets mis gegeaan, probeer opnieuw!");
                    }
                    else
                    {
                        string sSom = ss[0];
                        _sAntwoord = ss[1];
                        string sOptie1 = ss[2];
                        string sOptie2 = ss[3];
                        string sOptie3 = ss[4];
                        string sOptie4 = ss[5];

                        tbsom.Text = sSom;
                        antwoord1.Content = sOptie1;
                        antwoord2.Content = sOptie2;
                        antwoord3.Content = sOptie3;
                        antwoord4.Content = sOptie4;

                        antwoord1.IsChecked = false;
                        antwoord2.IsChecked = false;
                        antwoord3.IsChecked = false;
                        antwoord4.IsChecked = false;
                    }
                }
                else
                {
                    ivraag++;
                    var ss = await WebRequest.Request(new Uri("http://localhost/elearning/e-learning.php"), new KeyValuePair<string, string>("somhalen", "true"));
                    if (ss == null)
                    {
                        MessageBox.Show("Er is iets mis gegeaan, probeer opnieuw!");
                    }
                    else
                    {
                        string sSom = ss[0];
                        _sAntwoord = ss[1];
                        string sOptie1 = ss[2];
                        string sOptie2 = ss[3];
                        string sOptie3 = ss[4];
                        string sOptie4 = ss[5];

                        tbsom.Text = sSom;
                        antwoord1.Content = sOptie1;
                        antwoord2.Content = sOptie2;
                        antwoord3.Content = sOptie3;
                        antwoord4.Content = sOptie4;

                        antwoord1.IsChecked = false;
                        antwoord2.IsChecked = false;
                        antwoord3.IsChecked = false;
                        antwoord4.IsChecked = false;
                    }
                }
            }


        }


    }
}
