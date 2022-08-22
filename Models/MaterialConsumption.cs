using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator.Models
{

    public class MaterialConsumption : IMaterialConsumption
    {
        public IMaterial Material { get { return _material; } set  {  _material = value; } }

        private IMaterial _material;

        public float Quantity { get { return _quantity; } set { _quantity = value; } }
        private float _quantity;

        public MaterialConsumption(IMaterial material, float quantity)
        {
            _material = material;
            _quantity = quantity;
        }

        public IMaterialConsumption Copy() 
        {
            return new MaterialConsumption(_material, _quantity);
        }
    }
}