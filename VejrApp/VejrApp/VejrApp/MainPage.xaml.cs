using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace VejrApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnClick(object sender, System.EventArgs e)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            ((Button)sender).Text = $"Latitude: {location.Latitude} Longitude: {location.Longitude}";

        }
        void Change_page(object sender, EventArgs e)
        {
            App.Current.MainPage = new Page1();
        }
    }
}
