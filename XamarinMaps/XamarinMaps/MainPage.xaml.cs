using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMaps.Model;
using XamarinMaps.Servises;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace XamarinMaps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource cts;
        Pin pin = new Pin();
        

        public MainPage()
        {
            InitializeComponent();
            var res = GetcurrLocation();
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var a = await App.ToDoManager.GetTodoItemModels(cityEnterEntry.Text);
            DateTime d = DateTime.Now;
            datetimelbl.Text = d.ToString();
            tempLbl.Text = "t" + " " + a.main.temp.ToString();
            feelLikeLbl.Text = "Ощущается как" + " " + a.main.feels_like.ToString();
            WindLbl.Text = "Направление ветра" + " " + a.wind.gust.ToString();
            HumidityLbl.Text = "Влажность" + " " + a.main.humidity.ToString();
            PressureLbl.Text = "Давление" + " " + a.main.pressure.ToString();
            Position position = new Position(a.coord.lat, a.coord.lon);

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(a.coord.lat, a.coord.lon), Distance.FromMiles(1)));
            pin.Position = new Position(a.coord.lat, a.coord.lon);
        }
        async Task<Location> GetcurrLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            if (location != null)
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude,
                        location.Longitude), Distance.FromKilometers(1)));
            }
            return location;
        }
    }
}
