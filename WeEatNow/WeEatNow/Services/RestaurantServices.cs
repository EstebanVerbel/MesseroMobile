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
    public class RestaurantServices
    {

        public async Task<List<Restaurant>> LoadRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            // await Task.Delay(3000); // THIS IS TO SIMULATE DELAY. DELETE AFTER !!!!!!!

            // ESTEBAN: load restaurants from database here
            // add dummy data to collection
            Data montanasImageData = new Data { IsSilhouette = false, Url = "https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2015/9/14/1442224176059/59bfc5b4-c00e-4a9d-bd4d-c16452704d73-2060x1236.jpeg?w=620&q=55&auto=format&usm=12&fit=max&s=837b2a9f63902df6a8779872321bb221~" };
            Picture montanasPicture = new Picture();
            montanasPicture.Data = montanasImageData;
            restaurants.Add(new Restaurant { Name = "Montanas", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.ModeratelyExpensive, Picture = montanasPicture });

            Data colombiaMiaImageData = new Data { IsSilhouette = false, Url = "http://www.uberpromocodetoronto.ca/wp-content/uploads/2016/06/Grand-Electric-Toronto-UberEats.jpg" };
            Picture colombiaMiaPicture = new Picture();
            colombiaMiaPicture.Data = colombiaMiaImageData;
            restaurants.Add(new Restaurant { Name = "Colombia Mia", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.ModeratelyExpensive, Picture = colombiaMiaPicture });

            Data moxisImageData = new Data { IsSilhouette = false, Url = "http://ottawamagazine.com/wp-content/uploads/2016/04/Fauna_banner-1200x560.jpg" };
            Picture moxisPicture = new Picture();
            moxisPicture.Data = moxisImageData;
            restaurants.Add(new Restaurant { Name = "Moxis'", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Expensive, Picture = moxisPicture });

            Data shawarmaImageData = new Data { IsSilhouette = false, Url = "https://cdn.picodi.com/za/files/1My_folder/ZA_UberEATS_1.png" };
            Picture shawarmaPicture = new Picture();
            shawarmaPicture.Data = shawarmaImageData;
            restaurants.Add(new Restaurant { Name = "Shawarma", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Inexpensive, Picture = shawarmaPicture });

            Data thaiExpressImageData = new Data { IsSilhouette = false, Url = "http://md1.libe.com/photo/963811-ubereat-900x500.jpg?modified_at=1478799638&width=960" };
            Picture thaiExpressPicture = new Picture();
            thaiExpressPicture.Data = thaiExpressImageData;
            restaurants.Add(new Restaurant { Name = "Thai Express", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Inexpensive, Picture = thaiExpressPicture });

            Data redDragonImageData = new Data { IsSilhouette = false, Url = "https://newsroom.uber.com/us-new-york/wp-content/uploads/sites/295/2016/07/KingsCountyImperial_Hero_4-2-copy_blog_960x540.jpg" };
            Picture redDragonPicture = new Picture();
            redDragonPicture.Data = redDragonImageData;
            restaurants.Add(new Restaurant { Name = "Red Dragon", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.VeryExpensive, Picture = redDragonPicture });

            Data xiaoWeiImageData = new Data { IsSilhouette = false, Url = "http://d3lp4xedbqa8a5.cloudfront.net/s3/digital-cougar-assets/HarpersBazaar/2016/07/25/157215/cover.jpg?Width=940&MaxWidth=940&Constrain=true&Class=upsize&Mode=Crop" };
            Picture xiaoWeiPicture = new Picture();
            xiaoWeiPicture.Data = xiaoWeiImageData;
            restaurants.Add(new Restaurant { Name = "Xiao Wei", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.ModeratelyExpensive, Picture = xiaoWeiPicture });

            Data mandarinImageData = new Data { IsSilhouette = false, Url = "http://luxodeals.com/wp-content/uploads/2016/06/London-UberEats-Restaurants-Promotion.jpg" };
            Picture mandarinPicture = new Picture();
            mandarinPicture.Data = mandarinImageData;
            restaurants.Add(new Restaurant { Name = "Mandarin", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Expensive, Picture = mandarinPicture });

            Data blueHouseImageData = new Data { IsSilhouette = false, Url = "https://2q72xc49mze8bkcog2f01nlh-wpengine.netdna-ssl.com/australia/wp-content/uploads/sites/272/2016/07/Butter_2880x1920-13.jpg" };
            Picture blueHousePicture = new Picture();
            blueHousePicture.Data = blueHouseImageData;
            restaurants.Add(new Restaurant { Name = "Blue House", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Expensive, Picture = blueHousePicture });

            Data lakeViewImageData = new Data { IsSilhouette = false, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxol6YKLISAtLVA6sRdb7HQeRtt_FNwaZvKfk7fhVh9aw-FeWT" };
            Picture lakeViewPicture = new Picture();
            lakeViewPicture.Data = lakeViewImageData;
            restaurants.Add(new Restaurant { Name = "Lake View", City = "Kitchener", PriceRange = RestaurantPriceRange.PriceRange.Expensive, Picture = lakeViewPicture });

            return restaurants;
        }
        
        public void SortRestaurantsByDistance(ObservableCollection<Restaurant> restaurants)
        {
            // this users the icomparable implementation of the restaurant object to compare by distance
            List<Restaurant> sorted = restaurants.OrderBy(x => x).ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                restaurants.Move(restaurants.IndexOf(sorted[i]), i);
            }

            // this is the generic implementation
            //    public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
            //{
            //    List<T> sorted = collection.OrderBy(x => x).ToList();
            //    for (int i = 0; i < sorted.Count(); i++)
            //        collection.Move(collection.IndexOf(sorted[i]), i);
            //}
        }
        
        public async Task<IEnumerable<MenuItem>> GetRestaurantMenu(Restaurant restaurant)
        {
            ObservableCollection<MenuItem> restaurantMenuItems = new ObservableCollection<MenuItem>();

            // add dummy menu items for now
            restaurantMenuItems.Add(new MenuItem { Name = "Teriyaki Chicken", Price = 10.0f, PreparationTime = new TimeSpan(10000000000), Restaurant = restaurant, Description="Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Tai Dop Voy", Price = 15.0f, PreparationTime = new TimeSpan(20000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Chow Mein", Price = 16.0f, PreparationTime = new TimeSpan(22000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Hunan Chicken", Price = 17.0f, PreparationTime = new TimeSpan(18000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Hunan Beef", Price = 20.0f, PreparationTime = new TimeSpan(14000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Chow Shan Pan", Price = 16.0f, PreparationTime = new TimeSpan(19000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Kung Pao", Price = 23.0f, PreparationTime = new TimeSpan(13000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            restaurantMenuItems.Add(new MenuItem { Name = "Mongolian Shrimp", Price = 17.0f, PreparationTime = new TimeSpan(10000000000), Restaurant = restaurant, Description = "Fresh ground, 100% pure lean beef", Picture = restaurant.Picture });
            
            return restaurantMenuItems;
        }
        
    }
}
