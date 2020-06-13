using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class OrderDetails
    {
        [Key]
        public long OrderDetailsId { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
