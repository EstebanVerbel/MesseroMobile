using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.DataObjects;
using WeEatNow.Models.Entities;
using WeEatNow.Services;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.ViewModels
{
    public class RestaurantsViewModel : CartViewModel
    {
        #region -- Properties --
        
        private float _restaurantImageHeight;
        public float RestaurantImageHeight { get { return _restaurantImageHeight; } set { _restaurantImageHeight = value; OnPropertyChanged(); } }
        
        public Size ScreenSize { get; set; }

        public ObservableRangeCollection<Restaurant> Restaurants { get; set; }
        public List<Models.MenuItem> RestaurantMenuItems { get; set; }

        private Command _loadRestaurantMenuCommand;
        public Command LoadMenuItemsCommand
        {
            get { return _loadRestaurantMenuCommand ?? (_loadRestaurantMenuCommand = new Command<Restaurant>(async (Restaurant rest) => await ExecuteLoadRestaurantMenuCommand(rest))); }
        }    
        
        #endregion

        #region -- Constructor --

        public RestaurantsViewModel()
        {
            Restaurants = new ObservableRangeCollection<Models.Restaurant>();
            IsBusy = false;
            Title = "Restaurants";
            
            // make necessary subscriptions to messaging center
            MakeSubscriptionsToMessagingCenter();
        }

        #endregion

        #region -- Commands --
        
        private async Task ExecuteLoadRestaurantMenuCommand(Restaurant restaurant)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            bool isError = false;

            try
            {
                RestaurantServices restaurantServices = new RestaurantServices();

                // get menu items for selected restaurant
                var loadedRestaurantMenuItems = await restaurantServices.GetRestaurantMenu(restaurant);
                RestaurantMenuItems = new List<Models.MenuItem>(loadedRestaurantMenuItems);
                
                if (RestaurantMenuItems == null || RestaurantMenuItems.Count == 0)
                    isError = true;
            }
            catch 
            {
                isError = true;
            }

            if (isError)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load the menu for this Restaurant", "OK");
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
