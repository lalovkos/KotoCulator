namespace KotoCulator.Models
{
    public interface IMaterial 
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }
        public float PricePerOne { get; set; }

    }
}