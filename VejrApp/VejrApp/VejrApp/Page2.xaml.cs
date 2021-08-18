﻿using System;
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
    public partial class Page2 : ContentPage
    {
        public Page2(string city)
        {
            InitializeComponent();
            var json = new WebClient().DownloadString($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=41bfac970ccb62f946ceb789cef8bb08&units=metric");
            var rootJson = JsonConvert.DeserializeObject<Root>(json);
            degrees.Text = $"Degrees: " + rootJson.main.temp.ToString();
            humidity.Text = $"Humidity: " + rootJson.main.humidity.ToString();
            desc.Text = $"Description: " + rootJson.weather[0].description;
            Header.Text = rootJson.name;


        }
        void Front_page(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}