using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using WeEatNow.Models;
using WeEatNow.Models.Entities;
using WeEatNow.Services;
using WeEatNow.ViewModels;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.Views
{
    public partial class RestaurantsPage : ContentPage
    {

        #region -- Members --

        private const float SCREEN_PERCENTAGE_HEIGHT = 0.25f;

        private RestaurantsViewModel ViewModel
        {
            get { return BindingContext as RestaurantsViewModel; }
        }

        #endregion

        #region -- Constructor --

        public RestaurantsPage(IEnumerable<Restaurant> restaurants, Size screenSize)
        {
            InitializeComponent();

            // instanciate view model 
            RestaurantsViewModel viewModel = new RestaurantsViewModel();

            // get and set size of height of restaurant images (SCREEN_PERCENTAGE_HEIGHT % of height of device screen)
            float restaurantImageHeight;
            if (screenSize != null)
                restaurantImageHeight = (float)screenSize.Height * SCREEN_PERCENTAGE_HEIGHT;
            else
                restaurantImageHeight = 120f;

            // set image height
            viewModel.RestaurantImageHeight = restaurantImageHeight;
            viewModel.ScreenSize = screenSize;
            
            // set restaurants
            viewModel.Restaurants = new ObservableRangeCollection<Restaurant>(restaurants);
            
            // set binding context
            BindingContext = viewModel;
            
            // load restaurants
            restaurantsListView.ItemSelected += RestaurantsListView_ItemSelected;
        }

        #endregion

        #region -- Event Handlers --

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

        private void RestaurantsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Restaurant selectedRestaurant = (Restaurant)e.SelectedItem;

            if (selectedRestaurant == null)
                return;
            
            ViewModel.LoadMenuItemsCommand.Execute(selectedRestaurant);

            // navigate to next page if menu items were loaded
            if (ViewModel.RestaurantMenuItems != null && ViewModel.RestaurantMenuItems.Count > 0)
            {
                // navigate to restaurant menu items page
                Navigation.PushAsync(new RestaurantMenuPage(ViewModel.RestaurantMenuItems, selectedRestaurant, ViewModel.ScreenSize));
            }
            
            // set list view selection to null
            restaurantsListView.SelectedItem = null;
        }

        #endregion
        
    }
}
