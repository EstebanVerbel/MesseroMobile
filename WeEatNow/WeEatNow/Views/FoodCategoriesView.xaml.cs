using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.DataObjects;
using WeEatNow.Services;
using WeEatNow.Services.Interfaces;
using WeEatNow.ViewModels;
using Xamarin.Forms;

namespace WeEatNow.Views
{
    public partial class FoodCategoriesView : ContentPage
    {

        #region -- Members --
        
        private GeographicLocation _location;

        private FoodCategoriesViewModel ViewModel
        {
            get { return BindingContext as FoodCategoriesViewModel; }
        }

        #endregion
        
        #region -- Constructor --

        public FoodCategoriesView(Size screenSize)
        {
            InitializeComponent();
            
            // get location tracker and start tracking location of user
            ILocationTracker locationTracker = DependencyService.Get<ILocationTracker>();

            locationTracker.LocationChanged += OnLocationTrackerLocationChanged;
            locationTracker.StartTracking();
            
            BindingContext = new FoodCategoriesViewModel();

            // set screen size
            ViewModel.ScreenSize = screenSize;

            // add event handdler for when an a food group is selected
            foodCategoriesListView.ItemSelected +=  FoodCategoriesListView_ItemSelected;
            
            // ******************* Degub *******************
            
            //Label label = new Label
            //{
            //    Text = "My Descriptiuon"
            //};

            //var image = new Image
            //{
            //    Source = "ttps://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2015/9/14/1442224176059/59bfc5b4-c00e-4a9d-bd4d-c16452704d73-2060x1236.jpeg?w=620&q=55&auto=format&usm=12&fit=max&s=837b2a9f63902df6a8779872321bb221",
            //    Aspect = Aspect.AspectFit,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            //Content = new ScrollView
            //{
            //    Padding = 20,
            //    Content = new StackLayout
            //    {
            //        Spacing = 10,
            //        VerticalOptions = LayoutOptions.FillAndExpand,
                    
            //        Children = { label, image }

            //    }
            //};


            // ******************* Degub *******************
        }

        #endregion

        #region -- Event Handler --

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

        private void OnLocationTrackerLocationChanged(object sender, GeographicLocation e)
        {
            locationLabel.Text = e.ToString();
            
            // Update dot on map.
           // location = e;
            //  UpdateLocationDot(e);
        }


        // ******************* ESTEBAN: this event handler needs to return a Task to be async

        private async void FoodCategoriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) 
        {
            FoodCategory foodCategory = (FoodCategory)e.SelectedItem;

            if (foodCategory == null)
                return;

            // execute command to load food groups
            ViewModel.LoadRestaurantsCommand.Execute(foodCategory);
            
            // navigate to the next page if the restaurants were loaded
            if (ViewModel.Restaurants != null && ViewModel.Restaurants.Count > 0)
            {
                // inflate restaurants page and navigate to it
                // ESTEBAN: eventually the restaurants will need to be loaded by location too ************
                await Navigation.PushAsync(new RestaurantsPage(ViewModel.Restaurants, ViewModel.ScreenSize));
            }
            
            foodCategoriesListView.SelectedItem = null;
        }

        #endregion

        #region -- Overrides --

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel == null || ViewModel.IsBusy || ViewModel.FoodCategories.Count > 0)
                return;

            // execute command to load food groups
            ViewModel.LoadFoodCategoriesCommand.Execute(null);
        }

        #endregion
        
    }
}
