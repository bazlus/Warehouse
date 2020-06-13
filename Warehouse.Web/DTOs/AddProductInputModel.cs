namespace Warehouse.Web.DTOs
{
    public class AddProductInputModel
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public int MinQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public long SupplierId { get; set; }
    }
}
