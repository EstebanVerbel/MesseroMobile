

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeEatNow.Models;
using WeEatNow.ViewModels;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.Views
{
    public partial class RestaurantMenuPage : ContentPage
    {

        #region -- Members --

        private const float REST_IMG_PERCENTAGE_HEIGHT = 0.2f;
        private const float FOOD_IMG_PROPORTION_HEIGHT = 0.12f;
        
        #endregion

        #region -- Properties --

        public RestaurantMenuViewModel ViewModel
        {
            get { return BindingContext as RestaurantMenuViewModel; }
        }

        #endregion
        
        #region -- Constructor --

        public RestaurantMenuPage(IEnumerable<Models.MenuItem> restaurantMenuItems, Restaurant restaurant, Size screenSize)
        {
            InitializeComponent();
            
            RestaurantMenuViewModel viewModel = new RestaurantMenuViewModel();
            viewModel.MenuItems = new ObservableRangeCollection<Models.MenuItem>(restaurantMenuItems);
            viewModel.Restaurant = restaurant;
            viewModel.ScreenSize = screenSize;

            // get and set size of height of restaurant images (SCREEN_PERCENTAGE_HEIGHT % of height of device screen)
            float restaurantImageHeight;
            float foodImageHeight;
            if (screenSize != null)
            {
                restaurantImageHeight = (float)screenSize.Height * REST_IMG_PERCENTAGE_HEIGHT;
                foodImageHeight = (float)screenSize.Height * FOOD_IMG_PROPORTION_HEIGHT;
            }
            else
            {
                restaurantImageHeight = 120f; // ESTEBAN: change this value. dont like it hardcoded
                foodImageHeight = 60f;
            }
            
            // set heights
            viewModel.RestaurantImageHeight = restaurantImageHeight;
            viewModel.FoodImageHeight =  Convert.ToInt32(foodImageHeight);

            // set binding context
            BindingContext = viewModel;
            
            // set event handler for when an item in the menu is selected
            menuItemsListView.ItemSelected += MenuItemsListView_ItemSelected;
        }

        #endregion

        #region -- Event Handlers --

        private void MenuItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.MenuItem menuItem = (Models.MenuItem)e.SelectedItem;

            if (menuItem == null)
                return;
            
            // navigate to manu item page
            Navigation.PushAsync(new MenuItemPage(menuItem, ViewModel.ScreenSize));
            
            // set selected item to null
            menuItemsListView.SelectedItem = null;
        }
        
        private void CheckoutButton_Clicked(object sender, EventArgs e)
        {
            Cart cart = ViewModel.Cart;

            if (cart != null)
            {
                Navigation.PushAsync(new CheckoutPage(cart));
            }
            else
            {
                // display error page
            }

        }
        
        #endregion

    }
}
