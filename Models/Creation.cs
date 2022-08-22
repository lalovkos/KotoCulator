using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator.Models
{

    public class Creation : ICreation
    {
        public string Name { get { return _name; } set { _name = value; } }
        private string _name;

        private IList<IMaterialConsumption> _composition;

        public float Price { get {return _price; } set {  _price = value; } }
        private float _price;

        public Creation(string name, IList<IMaterialConsumption> composition) 
        {
            _name = name;
            _composition = new List<IMaterialConsumption>();

            foreach (var comp in composition) 
            {
                _composition.Add(comp.Copy());
            }
            ChangePrice();
        }

        private void ChangePrice() 
        {
            Price = 0;
            foreach (var item in _composition) 
            {
                Price += item.Material.PricePerOne * item.Quantity;
            }
        }

        public ICreation Copy() 
        {
            return new Creation(Name, _composition);
        }

        public void AddComposition(IMaterialConsumption materialConsumption)
        {
            _composition.Add(materialConsumption);
            ChangePrice();
        }

        public void RemoveComposition(IMaterialConsumption selectedItem)
        {
            _composition.Remove(selectedItem);
            ChangePrice();
        }


    }
}