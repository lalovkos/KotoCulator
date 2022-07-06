using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator
{
    public class MaterialConsumption : INotifyPropertyChanged
    {
        public Material Material 
        { 
            get 
            { 
                return _material; 
            } 
            set 
            { 
                _material = value; 
                OnPropertyChanged("Material");
            } 
        }

        private Material _material;
        public float Quantity 
        { 
            get 
            { 
                return _quantity; 
            } 
            set 
            { 
                _quantity = value; 
                OnPropertyChanged("Quantity");
            } 
        }
        private float _quantity;

        public MaterialConsumption(Material material, float quantity)
        {
            _material = material;
            _quantity = quantity;
        }

        public MaterialConsumption Copy() 
        {
            return new MaterialConsumption(_material, _quantity);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}