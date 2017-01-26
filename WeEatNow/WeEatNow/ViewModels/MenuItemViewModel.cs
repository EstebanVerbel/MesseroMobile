using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.Entities;
using WeEatNow.Views;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {

        private const float IMAGE_HEIGHT_SCREEN_PERCENTAGE = 0.3f;

        #region -- Properties --
        
        private Models.MenuItem _menuItem;
        public Models.MenuItem MenuItem
        {
            get { return _menuItem; }
            set { _menuItem = value; OnPropertyChanged(); }
        }

        private int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

        public Size ScreenSize { get; set; }

        public float FoodImageHeight
        {
            get { return ((float)ScreenSize.Height * IMAGE_HEIGHT_SCREEN_PERCENTAGE); }
        }


        #endregion

        #region -- Constructor --

        public MenuItemViewModel()
        {
            Title = "Dish";
        }

        #endregion

        #region -- Public Methods --

        public void AddOneItem()
        {
            _quantity++;
            
            Quantity = _quantity;
        }

        public void RemoveOneItem()
        {
            if (_quantity > 1)
                _quantity--;

            Quantity = _quantity;
        }
        
        public void AddIMenutemToCart(RestaurantMenuPage page)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Cart cart;
            
            // if a Cart already exists, get it, if not, create new one
            if (page.ViewModel.Cart != null)
            {
                cart = page.ViewModel.Cart;

                if (cart.Restaurant != MenuItem.Restaurant)
                {
                    // there is an existing Cart from another restaurant. Either cancel transaction or create new one
                    // ESTEBAN:
                    // return if user doesn't want to lose other Cart
                }
            }
            else
            {
                // create new cart
                cart = new Cart();
                //set screen size to take it to checkout page
                cart.ScreenSize = page.ViewModel.ScreenSize;
            }
           
            // need to pass: Product, quantity
            List<Models.MenuItem> orderMenuItems = new List<Models.MenuItem>();

            // for every item to add to Cart
            for (int i = 0; i < Quantity; i++)
            {
                if (i == 0)
                    orderMenuItems.Add(MenuItem);
                else
                {
                    // clone the MenuItem
                    Models.MenuItem clonedItem = MenuItem.Clone<Models.MenuItem>();
                    orderMenuItems.Add(clonedItem);
                }
            }

            // if OrderMenuItems is null. just set it, else, get items and add them to list, then set
            if (cart.OrderMenuItems == null)
                cart.OrderMenuItems = orderMenuItems;
            else
            {
                // copy existing items from menu
                foreach (Models.MenuItem item in cart.OrderMenuItems)
                    orderMenuItems.Add(item);

                // set new OrderMenuItems list
                cart.OrderMenuItems = orderMenuItems;
            }

            // set updated Cart in to all pages listeing
            MessagingCenter.Send(cart, "updateCart");

            IsBusy = false;
        }

        #endregion

    }
}
