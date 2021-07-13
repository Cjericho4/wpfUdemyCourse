using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp_WPFCourse.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherApp_WPFCourse.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string APIKEY = "GxXtl7FrPpKzGA4GLXlsTGnBqWuq8pZG";
        public const string BASEURL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new();

            string url = BASEURL + string.Format(AUTOCOMPLETE_ENDPOINT, APIKEY, query);

            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentWeatherConditions> GetCurrentConditions(string cityKey)
        {
            CurrentWeatherConditions currentConditions = new();

            string url = $"{BASEURL}{string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, APIKEY)}";

            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<List<CurrentWeatherConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
           
        }
    }
}
