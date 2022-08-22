using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KotoCulator.Models
{
    public class MaterialConsumption
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public float Quantity { get; set; }
    }
}