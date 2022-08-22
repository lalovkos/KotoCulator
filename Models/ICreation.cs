using System.Collections.Generic;

namespace KotoCulator.Models
{
    public interface ICreation
    { 
        public string Name { get; set; }
        public float Price { get; set; }
        public IList<IMaterialConsumption> Consumption { get; set; }

        public void AddComposition(IMaterialConsumption materialConsumption);
        public void RemoveComposition(IMaterialConsumption materialConsumption);
        public ICreation Copy();
    }
}