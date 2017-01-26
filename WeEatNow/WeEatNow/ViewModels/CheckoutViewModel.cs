using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.Entities;
using Xamarin.Forms;
using MvvmHelpers;

namespace WeEatNow.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
    {

        #region -- Members --

        private const float SCREEN_HEIGHT_PERCENTAGE = 0.5f;

        private const float DIVIDERS_WIDTH_PERCENTAGE = 0.4f;

        #endregion

        #region -- Properties --

        private Cart _cart;
        public Cart Cart { get { return _cart; } set { _cart = value; SetProperty(ref _cart, value); } }
        
        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }
        
        public float Subtotal
        {
            get { return Order.Subtotal; }
            set { Order.Subtotal = value; OnPropertyChanged(); }
        }
        
        public float Tax
        {
            get { return Order.Tax; }
            set { Order.Tax = value; OnPropertyChanged(); }
        }
        
        public float PurchaseFee
        {
            get { return Order.PurchaseFee; }
            set { Order.PurchaseFee = value; OnPropertyChanged(); }
        }
        
        public float Total
        {
            get { return Order.Total; }
            set { Order.Total = value; OnPropertyChanged(); }
        }
        
        public double ItemsListViewHeight
        {
            get { return (_cart.ScreenSize.Height * SCREEN_HEIGHT_PERCENTAGE);}
        }
        
        public double DividersWidth
        {
            get { return (_cart.ScreenSize.Width * DIVIDERS_WIDTH_PERCENTAGE); }
        }
        
        private Command _calculateTotalCommand;
        public Command CalculateTotalCommand
        {
             get { return _calculateTotalCommand ?? (_calculateTotalCommand = new Command(async () => await ExecuteCalculateTotalCommand())); }
        }
        
        #endregion

        #region -- Constructor --

        public CheckoutViewModel()
        {
            Title = "Checkout";
        }

        #endregion

        #region -- Commands --

        private async Task ExecuteCalculateTotalCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            bool isError = false;
            
            try
            {
                float subtotal = 0;

                foreach (Models.MenuItem menuItem in Cart.OrderMenuItems)
                    subtotal += menuItem.Price;
                
                float tax = subtotal * 0.13f; // ESTEBAN: calculate taxes propertly
                float purchaceFee = subtotal * 0.1f;
                float total = subtotal + tax + purchaceFee;

                Subtotal = subtotal;
                Tax = tax;
                PurchaseFee = purchaceFee;
                Total = total;
            }
            catch
            {
                isError = true;
            }

            if (isError)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to calculate the Bill Total", "OK");
            }

            IsBusy = false;
        }

        #endregion

        #region -- Public Methods --

        public void PopulateMenuItemsGrid(Grid menuItemsGrid, IEnumerable<Models.MenuItem> menuItems)
        {
            int rowIndex = 0;

            // for each plate in cart
            foreach (Models.MenuItem menuItem in menuItems)
            {
                // add name of plate
                menuItemsGrid.Children.Add(new Label
                {
                    Text = menuItem.Name
                }, 0, rowIndex);
                
                string price = $"${menuItem.Price}";

                // add price of plate
                menuItemsGrid.Children.Add(new Label
                {
                    Text = price
                }, 1, rowIndex);

                rowIndex++;
            }
        }

        #endregion
        
    }
}
