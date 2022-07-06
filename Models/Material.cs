using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace KotoCulator
{
    public class MaterialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Material)value).Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class Material : INotifyPropertyChanged
    {
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        private string _name;

        public float  Price { get { return _price; } set { _price = value; OnPropertyChanged("Price"); ChangePrice(); } }
        private float _price;

        public float Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged("Quantity"); ChangePrice();  } }
        private float _quantity;

        public float PricePerOne { get { return _pricePerOne; } set { _pricePerOne = value; OnPropertyChanged("PricePerOne"); } }
        private float _pricePerOne;

        public Material(string name, float price, float quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ChangePrice();
        }

        private void ChangePrice()
        {
            PricePerOne = Price / Quantity;
        }

        public override string ToString() 
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}