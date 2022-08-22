namespace KotoCulator.Models
{
    public interface ICreation
    { 
        public string Name { get; set; }
        public float Price { get; set; }
        public void AddComposition(IMaterialConsumption materialConsumption);
        public void RemoveComposition(IMaterialConsumption selectedItem);
        public ICreation Copy();
    }
}