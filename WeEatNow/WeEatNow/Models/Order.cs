using MvvmHelpers;
using System;

namespace WeEatNow.Models
{
    public class Order : ObservableObject
    {
        private Cart _cart;

        public Cart Cart
        {
            get { return _cart; }
            set { _cart = value; OnPropertyChanged(); }
        }
        
        private float _subtotal;
        public float Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; OnPropertyChanged(); }
        }

        private float _tax;
        public float Tax
        {
            get { return _tax; }
            set { _tax = value; OnPropertyChanged(); }
        }

        private float _purchaseFee;
        public float PurchaseFee
        {
            get { return _purchaseFee; }
            set { _purchaseFee = value; OnPropertyChanged(); }
        }

        private float _total;
        public float Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(); }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                // don't allow order dates before "today"
                if (value < DateTime.Now)
                    value = DateTime.Now;

                // don't allow orders for today to have a time before now + 15 minutes
                TimeSpan minimunTime = DateTime.Now.AddMinutes(15) - DateTime.Now.Date;
                if ((value.Date == DateTime.Now.Date) && (Time < minimunTime))
                    Time = minimunTime;
                
                _date = value;
                OnPropertyChanged();
            }
        }
        
        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                // minimun time for today orders
                TimeSpan minimunTime = DateTime.Now.AddMinutes(15) - DateTime.Now.Date;
                // don't allow orders for today to have a time before now + 15 minutes
                if ((Date.Date == DateTime.Now.Date) && (value < minimunTime))
                    value = minimunTime;

                _time = value;
                OnPropertyChanged();
            }
        }

        private bool _isApproved;
        public bool IsApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; OnPropertyChanged(); }
        }

    }
}
