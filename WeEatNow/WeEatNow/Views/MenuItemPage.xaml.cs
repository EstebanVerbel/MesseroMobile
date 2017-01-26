using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models.Entities;
using WeEatNow.ViewModels;
using Xamarin.Forms;

namespace WeEatNow.Views
{
    public partial class MenuItemPage : ContentPage, IFindPageInstance
    {
        #region -- Members --

        private MenuItemViewModel VIewModel
        {
            get { return BindingContext as MenuItemViewModel; }
        }

        #endregion

        #region -- Constructor --

        public MenuItemPage(Models.MenuItem menuItem, Size screenSize)
        {
            InitializeComponent();

            // this page needs to have all the add ons to this plate, in addition to a text box for entering details
            // about the order (no salt for example). 
            MenuItemViewModel viewModel = new MenuItemViewModel();
            viewModel.ScreenSize = screenSize;
            viewModel.MenuItem = menuItem;

            // set binding context
            BindingContext = viewModel;
        }

        #endregion

        #region -- Event Handlers --

        private void AddToCartButton_Clicked(object sender, EventArgs e)
        {
            ContentPage page = FindPageInstance<RestaurantMenuPage>();
            
            if (page != null)
            {    
                // add menu item to Cart in RestaurantMenuPage
                VIewModel.AddIMenutemToCart(page as RestaurantMenuPage);
                
                // navigate back to restaurants page
                Navigation.PopAsync();
            }
            else
            {
                // Display error page
            }
        }

        private void AddOneItem_Clicked(object sender, EventArgs e)
        {
            VIewModel.AddOneItem();
        }

        private void RemoveOneItem_Clicked(object sender, EventArgs e)
        {
            VIewModel.RemoveOneItem();
        }

        #endregion

        #region -- IFindPageInstance Interface --

        public ContentPage FindPageInstance<T>()
        {
            foreach (var page in Navigation.NavigationStack)
            {
                if (page is T)
                    return (page as ContentPage);
            }

            return null;
        }

        #endregion

    }
}
