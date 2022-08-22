namespace KotoCulator.Models
{
    public interface IMaterialConsumption 
    {
        public IMaterial Material { get; set; }
        public float Quantity { get; set; }
        public IMaterialConsumption Copy();
    }
}