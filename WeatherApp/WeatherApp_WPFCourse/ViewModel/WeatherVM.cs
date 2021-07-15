using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_WPFCourse.Model;
using WeatherApp_WPFCourse.ViewModel.Commands;
using WeatherApp_WPFCourse.ViewModel.Helpers;

namespace WeatherApp_WPFCourse.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        public string Query
        {
            get{ return query; }
            set
            {
                query = value;
                OnPropertyChanged(query);
            }
        }

        public ObservableCollection<City> Cities { get; set; }
        public SearchCommand SearchCommand { get; set; }

        private CurrentWeatherConditions currentConditions;

        public CurrentWeatherConditions CurrentConditions
        {
            get { return currentConditions; }
            set { currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentConditions();
            }
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        //Event for when any properties change
        public event PropertyChangedEventHandler PropertyChanged;

        public async void MakeQuery()
        {
            List<City> cities = await AccuWeatherHelper.GetCities(Query);
            //Clear old list of Cities.
            Cities.Clear();
            //Add new list of cities for viewing
            foreach(City i in cities)
            {
                Cities.Add(i);
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public WeatherVM()
        {
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) { 
                SelectedCity = new City()
                {
                    LocalizedName = "Orem"
                };
                CurrentConditions = new CurrentWeatherConditions()
                {
                    WeatherText = "Sunny",
                    Temperature = new Temperature
                    {
                        Imperial = new Units
                        {
                            Value = 92
                        }
                    }
                };
            }
            SearchCommand = new(this);
            //Instantiate Cities only once.
            Cities = new();
        }
    }

}
