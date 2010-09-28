using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Wp7BuildByExampleSample
{
    public partial class AnimalPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        private string _animalType;

        public AnimalPage()
        {
            DataContext = this;

            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AnimalType = NavigationContext.QueryString["AnimalType"];

            if (NavigationContext.QueryString.ContainsKey("AnimalCount"))
            {
                AnimalCount = Int32.Parse(NavigationContext.QueryString["AnimalCount"]);
            }

            if (NavigationContext.QueryString.ContainsKey("AnimalFed"))
            {
                AnimalFed = DateTime.Parse(NavigationContext.QueryString["AnimalFed"]);
            }
            
            if (NavigationContext.QueryString.ContainsKey("AnimalId"))
            {
                AnimalId = new Guid(NavigationContext.QueryString["AnimalId"]);
            }
        }

        public string AnimalType
        {
            get {
                return _animalType;
            }
            set {
                _animalType = value;
                NotifyPropertyChanged(AnimalType);
            }
        }

        private int _animalCount;
        public int AnimalCount
        {
            get { return _animalCount; }
            set 
            { 
                _animalCount = value; 
                NotifyPropertyChanged("AnimalCount");
            }
        }

        private DateTime _animalFed;
        public DateTime AnimalFed
        {
            get { return _animalFed; }
            set
            {
                _animalFed = value;
                NotifyPropertyChanged("AnimalFed");
            }
        }

        private Guid _animalId;
        public Guid AnimalId
        {
            get { return _animalId; }
            set
            {
                _animalId = value;
                NotifyPropertyChanged("AnimalId");
            }
        }
    }
}