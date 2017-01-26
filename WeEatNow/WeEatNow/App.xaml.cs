using FacebookLogin.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeEatNow.Models.DataObjects;
using WeEatNow.Views;
using Xamarin.Forms;

namespace WeEatNow
{
    public partial class App : Application
    {
        /// <summary>
        /// Holds Screen Size
        /// </summary>
        public static Size ScreenSize;
        
        public App()
        {
            InitializeComponent();
            
            // add conectivity alert
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                var page = new ContentPage();

                if (!args.IsConnected)
                    page.DisplayAlert("No Internet Found!", "You need to be connected to the internet to have access to all features", "OK");
            };
            
            // initialize and navigate to food categories. CHANGE FOR LOGIN IF NOT LOGGED IN
            MainPage = new NavigationPage(new FoodCategoriesView(ScreenSize));
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
