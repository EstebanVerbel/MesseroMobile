using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models.DataObjects;
using WeEatNow.Models.Entities;
using static WeEatNow.Models.DataObjects.RestaurantPriceRange;
using MvvmHelpers;

namespace WeEatNow.Models
{
    public class Restaurant : ObservableObject, IComparable<Restaurant>
    {

        private string _name;
        public string Name { get { return _name; } set { _name = value; SetProperty(ref _name, value); } }

        private string _address;
        public string Address { get { return _address; } set { _address = value; SetProperty(ref _address, value); } }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; SetProperty(ref _phoneNumber, value); }
        }

        private double _latitude;
        public double Latitude { get { return _latitude; } set { _latitude = value; SetProperty(ref _latitude, value); } }

        private double _longitude;
        public double Longitude { get { return _longitude; } set { _longitude = value; SetProperty(ref _longitude, value); } }
        
        private float _distanceFromOrigin;
        public float DistanceFromOrigin
        {
            get { return _distanceFromOrigin; }
            set { _distanceFromOrigin = value; SetProperty(ref _distanceFromOrigin, value); }
        }
        
        private PriceRange _priceRange;
        public PriceRange PriceRange
        {
            get { return _priceRange; }
            set { _priceRange = value; SetProperty(ref _priceRange, value); }
        }

        private Picture _picture;
        public Picture Picture { get { return _picture; } set { _picture = value; SetProperty(ref _picture, value); } }

        // ESTEBAN: might need a different class from here to button

        private string _city;
        public string City { get { return _city; } set { _city = value; SetProperty(ref _city, value); } }

        private string _state;
        public string State { get { return _state; } set { _state = value; SetProperty(ref _state, value); } }
        

        // ESTEBAN: add menu id and food category.


        public int CompareTo(Restaurant other)
        {
            return this.DistanceFromOrigin.CompareTo(other.DistanceFromOrigin);
        }
        
    }
}
