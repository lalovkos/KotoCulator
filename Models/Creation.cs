using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator.Models
{

    public class Creation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MaterialConsumption> Consumption { get; set; }
        public float Price { get; set; }
    }
}