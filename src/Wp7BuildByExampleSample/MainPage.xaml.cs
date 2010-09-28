using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BuildByExample;
using Microsoft.Phone.Controls;

namespace Wp7BuildByExampleSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void VisitSheep_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = UriByExample.GetXamlUri("Wp7BuildByExampleSample",
                                                  () => new AnimalPage() {AnimalType = "Goat"});
            NavigationService.Navigate(uri);
        }

        private void VisitFiveDogs_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = UriByExample.GetXamlUri("Wp7BuildByExampleSample",
                                              () => new AnimalPage()
                                                        {
                                                            AnimalType = "Goat",
                                                            AnimalCount = 5,
                                                            AnimalFed = DateTime.Now,
                                                            AnimalId = Guid.NewGuid()
                                                        });
            NavigationService.Navigate(uri);
        }
    }
}