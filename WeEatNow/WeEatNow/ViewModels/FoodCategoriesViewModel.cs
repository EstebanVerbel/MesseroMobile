using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.DataObjects;
using WeEatNow.Models.Entities;
using WeEatNow.Services;
using WeEatNow.Views;
using Xamarin.Forms;
using MvvmHelpers;
using Plugin.Connectivity;

namespace WeEatNow.ViewModels
{
    public class FoodCategoriesViewModel : CartViewModel
    {
        #region -- Properties --
        
        public ObservableRangeCollection<FoodCategory> FoodCategories { get; set; }
        public ObservableRangeCollection<Restaurant> Restaurants { get; set; }

        private Command _loadFoodCatCommand;
        public Command LoadFoodCategoriesCommand
        {
            get { return _loadFoodCatCommand ?? (_loadFoodCatCommand = new Command(async () => await ExecuteLoadFoodCatsCommand())); }
        }

        private Command _LoadRestaurantsCommand;
        public Command LoadRestaurantsCommand
        {
            get { return _LoadRestaurantsCommand ?? (_LoadRestaurantsCommand = new Command<FoodCategory>(async (FoodCategory fc) => await ExecuteLoadRestaurantsCommand(fc))); }
        }

        public Size ScreenSize { get; set; }

        #endregion

        #region -- Constructor --

        public FoodCategoriesViewModel()
        {
            FoodCategories = new ObservableRangeCollection<Models.FoodCategory>();
            IsBusy = false;
            Title = "Food Categories";


            bool isConnected = CrossConnectivity.Current.IsConnected;


            // make necessary subscriptions to messaging center
            MakeSubscriptionsToMessagingCenter();
        }

        #endregion

        #region -- Commands --

        private async Task ExecuteLoadRestaurantsCommand(FoodCategory foodCategory)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            bool isError = false;

            try
            {
                RestaurantServices restaurantServices = new RestaurantServices();

                // load the restaurants for this food category

                var loadedRestaurants = await restaurantServices.LoadRestaurants(); // ESTEBAN: load restaurants based on picked food category

                // ********************************* temp change this *********************************

                for (int i = 0; i < loadedRestaurants.Count; i++)
                    loadedRestaurants[i].FoodCategory = foodCategory;

                // ********************************* temp change this *********************************

                Restaurants = new ObservableRangeCollection<Restaurant>(loadedRestaurants);
                
                if (Restaurants == null || Restaurants.Count == 0)
                    isError = true;

                // calculate the distance of every loaded restaurant and the origin (user's location)
                GeographicLocation dummyGraphicLocation = new GeographicLocation();
                DistanceServices distanceServices = new DistanceServices();
                distanceServices.CalculateRestaurantsDistanceFromOrigin(Restaurants, dummyGraphicLocation);
                
                // sort restaurants by distance
                restaurantServices.SortRestaurantsByDistance(Restaurants);
            }
            catch 
            {
                isError = true;
            }

            if (isError)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load Restaurants", "OK");
            }
            
            IsBusy = false;
        }

        private async Task ExecuteLoadFoodCatsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            bool isError = false;

            try
            {
                FoodCategories.Clear();
                
                // load food categories
                var foodCategoriesService = new FoodCategoryService();
                var loadedFoodCategories = await foodCategoriesService.LoadFoodCategoryDirectory(); // ESTEBAN: make this async

                // display error message if couldn't load food groups
                if (loadedFoodCategories == null || loadedFoodCategories.Count == 0)
                    isError = true;

                // add food categories
                FoodCategories.AddRange(loadedFoodCategories);
            }
            catch
            {
                isError = true;
            }

            if (isError)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load Food Groups", "OK");
            }

            IsBusy = false;
        }

        #endregion

        #region -- Messaging Center Methods --

        private void MakeSubscriptionsToMessagingCenter()
        {
            // subcribe to update cart
            MessagingCenter.Subscribe<Cart>(this, "updateCart", (cart) =>
            {
                UpdateCart(cart);
            });
        }

        private void UpdateCart(Cart cart)
        {
            Cart = cart;
        }

        #endregion
    }
}
