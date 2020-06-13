using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Web.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public int MinQuantity { get; set; }
        public int OrderedQuantity { get; set; }
        public int DeliveredQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; }
        public long SupplierId { get; set; }
    }
}
