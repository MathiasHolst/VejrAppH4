using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using VejrApp;
using Newtonsoft.Json;

namespace VejrApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            var location = Geolocation.GetLastKnownLocationAsync();
            var json = new WebClient().DownloadString($"https://api.openweathermap.org/data/2.5/weather?lat={location.Result.Latitude}&lon={location.Result.Longitude}&appid=41bfac970ccb62f946ceb789cef8bb08&units=metric");
            var rootJson = JsonConvert.DeserializeObject<Root>(json);
            degrees.Text = $"Degrees: {rootJson.main.temp}";
            humidity.Text = $"Humidity: {rootJson.main.humidity}";
            desc.Text = $"Description: {rootJson.weather[0].description}";
            Header.Text = rootJson.name;
            
        }
        void Front_page(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}