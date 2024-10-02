namespace InventoryMobile.Models.Response
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Storaged { get; set; }
        public string CodeBar { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Price { get; set; }
        public DateTime Update { get; set; }
    }
}
