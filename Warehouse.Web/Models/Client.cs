using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class Client
    {
        [Key]
        public long ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string PCP { get; set; } // Prison Candidate Person. (МОЛ)
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
