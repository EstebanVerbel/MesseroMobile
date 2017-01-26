using MvvmHelpers;
using Xamarin.Forms;

namespace WeEatNow.Models.Entities
{
    public class CartViewModel : BaseViewModel
    {
        private bool _cartExists;
        public bool CartExists
        {
            get { return _cartExists; }
            set
            {
                _cartExists = value;
                OnPropertyChanged();
            }
        }

        private Cart _cart;
        public Cart Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;

                // this is to hind check out button if cart is set to null
                CartExists = (value != null) ? true : false;
                ItemsInCart = (CartExists == false) ? 0 : Cart.OrderMenuItems.Count;

                OnPropertyChanged();
            }
        }

        private int _itemsInCart;
        public int ItemsInCart { get { return _itemsInCart; } set { _itemsInCart = value; OnPropertyChanged(); } }
        
        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; OnPropertyChanged(); }
        }
        
    }
}
