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
    public class FoodCategory : ObservableObject
    {

        string _name;
        public string Name { get { return _name;} set { _name = value; SetProperty(ref _name, value); } }

        string _description;
        public string Description { get { return _description; } set { _description = value;  SetProperty(ref _description, value); } }

        Picture _image;
        public Picture Image { get { return _image; } set { _image = value;  SetProperty(ref _image, value); } }

    }
}
