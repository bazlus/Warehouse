using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}
