using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator
{
    public class Creation : INotifyPropertyChanged
    {
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        private string _name;
        public ObservableCollection<MaterialConsumption> Composition 
        {
            get 
            { 
                return _composition; 
            } 
            set 
            { 
                _composition = value; 
                OnPropertyChanged("Composition"); 
                ChangePrice();
            } 
        }
        private ObservableCollection<MaterialConsumption> _composition;
        public float Price 
        { 
            get 
            {
                return _price; 
            } 
            set 
            { 
                _price = value; 
                OnPropertyChanged("Price"); 
            } 
        }
        private float _price;

        public Creation(string name, ObservableCollection<MaterialConsumption> composition) 
        {
            Name = name;
            Composition = new ObservableCollection<MaterialConsumption>();
            foreach (var comp in composition) 
            {
                Composition.Add(comp.Copy());
            }
            ChangePrice();
        }

        public void ChangePrice() 
        {
            Price = 0;
            foreach (var item in Composition) 
            {
                Price += item.Material.PricePerOne * item.Quantity;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Creation Copy() 
        {
            return new Creation(Name, Composition);
        }

        internal void AddComposition(MaterialConsumption materialConsumption)
        {
            Composition.Add(materialConsumption);
            OnPropertyChanged(nameof(Composition));
        }

        internal void RemoveComposition(MaterialConsumption selectedItem)
        {
            Composition.Remove((MaterialConsumption)selectedItem);
            OnPropertyChanged(nameof(Composition));
        }


    }
}