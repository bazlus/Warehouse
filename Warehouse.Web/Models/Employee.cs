using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
