using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models.Entities;
using MvvmHelpers;
using Xamarin.Forms;

namespace WeEatNow.Models
{
    public class Cart : ObservableObject
    {
        private Restaurant _restaurant;
        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; SetProperty(ref _restaurant, value); }
        }

        private List<Models.MenuItem> _orderMenuItems;
        public List<Models.MenuItem> OrderMenuItems
        {
            get { return _orderMenuItems; }
            set { _orderMenuItems = value; OnPropertyChanged(); }
        }






        private Size _screenSize; // get rid of this if find a better solution
        public Size ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = value; }
        }
    }
}
