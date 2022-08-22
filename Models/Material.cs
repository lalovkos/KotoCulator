using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace KotoCulator.Models
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

    public class Material : IMaterial
    {
        public string Name { get { return _name; } set { _name = value; } }
        private string _name;

        public float  Price { get { return _price; } set { _price = value; ChangePrice(); } }
        private float _price;

        public float Quantity { get { return _quantity; } set { _quantity = value; ChangePrice();  } }
        private float _quantity;

        public float PricePerOne { get { return _pricePerOne; } set { _pricePerOne = value;} }
        private float _pricePerOne;

        public Material(string name, float price, float quantity)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
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
    }
}