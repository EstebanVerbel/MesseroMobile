using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.ViewModels;
using Xamarin.Forms;

namespace WeEatNow.Views
{
    public partial class CheckoutPage : ContentPage
    {
        #region -- Members --

        private CheckoutViewModel ViewModel
        {
            get { return (BindingContext as CheckoutViewModel); }
        }

        #endregion

        #region -- Constructor --

        public CheckoutPage(Cart cart)
        {
            InitializeComponent();
            
            CheckoutViewModel viewModel = new ViewModels.CheckoutViewModel();
            viewModel.Cart = cart;

            // create and set order
            Order order = new Order();
            order.Cart = cart;

            // set date and time. Add at least 15 minutes for minimun time for order
            DateTime date = DateTime.Now.AddMinutes(15);
            TimeSpan time = date - date.Date;
            order.Date = date;
            order.Time = time;

            viewModel.Order = order;
            
            // set binding context view model
            BindingContext = viewModel;

            // populate menu items grid
            ViewModel.PopulateMenuItemsGrid(cartItemsGrid, cart.OrderMenuItems);

            // execute command to calculate total
            ViewModel.CalculateTotalCommand.Execute(null);
        }

        #endregion
        
    }
}
