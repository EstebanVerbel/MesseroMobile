using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models;
using WeEatNow.Models.DataObjects;

namespace WeEatNow.Services
{
    public class DistanceServices
    {
        
        public void CalculateRestaurantsDistanceFromOrigin(IEnumerable<Restaurant> restaurants, GeographicLocation originLocation)
        {
            // ESTEBAN: this method needs to make a call to the Google Maps Distance Matrix AP to get the distance between the 
            // user's location and all restaurants 

            // ESTEBAN: this is a temporary implementation creating randon numbers for the distance
            Random random = new Random();
            foreach (Restaurant restaurant in restaurants)
            {
                double randomValue = random.NextDouble() * 10;
                float distance = (float)Math.Round(randomValue, 1);
                restaurant.DistanceFromOrigin = distance;
            }
        }
        
    }
}
