using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMaps.Servises;

namespace XamarinMaps
{
    public partial class App : Application
    {
        public static ToDoManager ToDoManager { get; set; }

        public App()
        {
            InitializeComponent();
            ToDoManager = new ToDoManager(new RestService());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
