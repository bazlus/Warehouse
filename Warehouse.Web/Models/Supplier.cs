using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
