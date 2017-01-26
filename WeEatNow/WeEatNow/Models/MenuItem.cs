using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeEatNow.Models.DataObjects;
using WeEatNow.Models.Entities;
using MvvmHelpers;

namespace WeEatNow.Models
{
    public class MenuItem : ObservableObject, IDeepClone
    {

        private string _name;
        public string Name { get { return _name; } set { _name = value; SetProperty(ref _name, value); } }
        
        private string _description;
        public string Description { get { return _description; } set { _description = value; SetProperty(ref _description, value); } }
        
        private float _price;
        public float Price { get { return _price; } set { _price = value; SetProperty(ref _price, value); } }
        
        private TimeSpan _preparationTime;
        public TimeSpan PreparationTime { get { return _preparationTime; } set { _preparationTime = value; SetProperty(ref _preparationTime, value); } }
        
        private Picture _picture;
        public Picture Picture { get { return _picture; } set { _picture = value; SetProperty(ref _picture, value); } }
        
        private bool _isSoldOut;
        public bool IsSoldOut { get { return _isSoldOut; } set { _isSoldOut = value; SetProperty(ref _isSoldOut, value); } }

        private Restaurant _restaurant;
        public Restaurant Restaurant { get { return _restaurant; } set { _restaurant = value; } }


        #region -- IDeepClone Interface --

        public T Clone<T>()
        {
            MenuItem clonedObject = new MenuItem
            {
                Name = this.Name,
                Description = this.Description,
                Price = this.Price,
                PreparationTime = this.PreparationTime,
                Picture = this.Picture,
                IsSoldOut = this.IsSoldOut,
                Restaurant = this.Restaurant
            };

            return (T)Convert.ChangeType(clonedObject, typeof(T));
        }

        #endregion



        // ESTEBAN: how to manage add ons


    }
}
