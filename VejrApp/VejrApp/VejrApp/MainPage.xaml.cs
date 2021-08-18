using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace VejrApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var orientation = mainDisplayInfo.Orientation;
            if (orientation == DisplayOrientation.Landscape)
            {
                test.Text = "Landscape";
            }
            else
            {
                test.Text = "Portrait";
            }

        }
        void searchCity(object sender, EventArgs e)
        {
            string city = cityName.Text;
            App.Current.MainPage = new Page2(city);

        }
        void Get_Ori(object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var orientation = mainDisplayInfo.Orientation;
            if (orientation == DisplayOrientation.Landscape)
            {
                OriButton.BackgroundColor = Color.Aquamarine;
                test.Text = "Landscape";
            }
            else
            {
                OriButton.BackgroundColor = Color.Default;
                test.Text = "Portrait";
            }
        }
        void Change_page(object sender, EventArgs e)
        {
            App.Current.MainPage = new Page1();
        }

        void ApiCall(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("https://api.openweathermap.org/data/2.5/weather?q=berlin&appid=41bfac970ccb62f946ceb789cef8bb08&units=metric");
            var rootJson = JsonConvert.DeserializeObject<Root>(json);
        }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }


}

