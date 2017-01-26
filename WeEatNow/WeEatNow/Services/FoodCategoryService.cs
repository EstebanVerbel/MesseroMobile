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
    public class FoodCategoryService
    {
        public async Task<ObservableCollection<FoodCategory>> LoadFoodCategoryDirectory()
        {
            ObservableCollection<FoodCategory> foodCategories = new ObservableCollection<FoodCategory>();

            await Task.Delay(3000); // THIS IS TO SIMULATE DELAY. DELETE AFTER !!!!!!!

            // load categories from database or api service here
            // for now create fake data
            Data mexicanImageData = new Data { IsSilhouette = false, Url = "https://pbs.twimg.com/profile_images/631872270923862016/zgdzUrDV.jpg" };
            Picture mexicanPicture = new Picture();
            mexicanPicture.Data = mexicanImageData;
            foodCategories.Add(new FoodCategory { Name = "Mexican", Image = mexicanPicture });

            Data chineseImageData = new Data { IsSilhouette = false, Url = "https://ontherocksjodhpur.files.wordpress.com/2016/09/chinese-food-in-jodhpur.jpg?w=256&h=256&crop=1" };
            Picture chinesePicture = new Picture();
            chinesePicture.Data = chineseImageData;
            foodCategories.Add(new FoodCategory { Name = "Chinese", Image = chinesePicture });

            Data japaneseImageData = new Data { IsSilhouette = false, Url = "http://wallpaper.sc/en/ipad/wp-content/uploads/2016/10/ipad-2048x2048-thumbnail_01884-256x256.jpg" };
            Picture japanesePicture = new Picture();
            japanesePicture.Data = japaneseImageData;
            foodCategories.Add(new FoodCategory { Name = "Japenese", Image = japanesePicture });

            Data barbecueImageData = new Data { IsSilhouette = false, Url = "https://s-media-cache-ak0.pinimg.com/736x/6d/59/19/6d591945b9a91ac1be23fa9c477f2046.jpg" };
            Picture barbecuePicture = new Picture();
            barbecuePicture.Data = barbecueImageData;
            foodCategories.Add(new FoodCategory { Name = "Barbecue", Image = barbecuePicture });

            Data indianImageData = new Data { IsSilhouette = false, Url = "https://bigoven-res.cloudinary.com/image/upload/t_recipe-256/crock-pot-chicken-tikka-masala-reci-2.jpg" };
            Picture indianPicture = new Picture();
            indianPicture.Data = indianImageData;
            foodCategories.Add(new FoodCategory { Name = "Indian", Image = indianPicture });

            Data colombianImageData = new Data { IsSilhouette = false, Url = "https://images.travelpod.com/tripwow/photos/ta-00bc-7d40-b839/bandeja-paisa-medellin-colombia+1152_12913231896-tpfil02aw-32072.jpg" };
            Picture colombianPicture = new Picture();
            colombianPicture.Data = colombianImageData;
            foodCategories.Add(new FoodCategory { Name = "Colombian", Image = colombianPicture });

            Data fastFoodImageData = new Data { IsSilhouette = false, Url = "http://images.bigoven.com/image/upload/t_recipe-256/cauliflowercrusthamburger.jpg" };
            Picture fastFoodPicture = new Picture();
            fastFoodPicture.Data = fastFoodImageData;
            foodCategories.Add(new FoodCategory { Name = "Fast Food", Image = fastFoodPicture });

            Data buffetImageData = new Data { IsSilhouette = false, Url = "http://www.winwickleisurecentre.co.uk/wp-content/uploads/2012/06/New-Buffet-Pic-256x256.jpg" };
            Picture buffetPicture = new Picture();
            buffetPicture.Data = buffetImageData;
            foodCategories.Add(new FoodCategory { Name = "Buffet", Image = buffetPicture } );

            Data fineDiningImageData = new Data { IsSilhouette = false, Url = "https://pbs.twimg.com/profile_images/3570135645/238d0fe2e4fb7368f4c78ee34bc7aa18.jpeg" };
            Picture fineDiningPicture = new Picture();
            fineDiningPicture.Data = fineDiningImageData;
            foodCategories.Add(new FoodCategory { Name = "Fine Dining", Image = fineDiningPicture });

            Data familyStyleImageData = new Data { IsSilhouette = false, Url = "http://cdn1.tmbi.com/TOH/Images/Photos/37/300x300/exps46077_UFZ133197D04_23_2b.jpg" };
            Picture familyStylePicture = new Picture();
            familyStylePicture.Data = familyStyleImageData;
            foodCategories.Add(new FoodCategory { Name = "Family Style", Image = familyStylePicture });

            return foodCategories;
        }

    }
}
