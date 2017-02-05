using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.Entities;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.ViewModels
{
    public class RestaurantMenuViewModel : CartViewModel
    {

        #region -- Properties --
        
        private Restaurant _restaurant;
        public Restaurant Restaurant { get { return _restaurant; } set { _restaurant = value; OnPropertyChanged(); } }

        private float _restaurantImageHeight;
        public float RestaurantImageHeight
        {
            get { return _restaurantImageHeight; }
            set { _restaurantImageHeight = value; OnPropertyChanged(); }
        }

        private float _foodImageHeight;
        public float FoodImageHeight
        {
            get { return _foodImageHeight; }
            set { _foodImageHeight = value; OnPropertyChanged(); }
        }
        
        public FormattedString AveragePrice
        {
            get
            {
                return new FormattedString
                {
                    Spans =
                    {
                        new Span { Text = "$", ForegroundColor=Color.Black },
                        new Span { Text = "$", ForegroundColor=Color.Gray },
                        new Span { Text = "$", ForegroundColor=Color.Gray },
                        new Span { Text = "$", ForegroundColor=Color.Gray }
                    }
                };
            }
        }
        
        public Size ScreenSize { get; set; }

        public ObservableRangeCollection<Models.MenuItem> MenuItems { get; set; }

        #endregion

        #region -- Constructor --

        public RestaurantMenuViewModel()
        {
            MenuItems = new ObservableRangeCollection<Models.MenuItem>();
            IsBusy = false;
            Title = "Menu";
            
            MakeSubscriptionsToMessagingCenter();
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
