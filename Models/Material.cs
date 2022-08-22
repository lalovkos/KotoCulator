using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace KotoCulator.Models
{

    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float  Price { get; set; }

        public float Quantity { get; set; }

        public float PricePerOne { get; set; }

    }
}