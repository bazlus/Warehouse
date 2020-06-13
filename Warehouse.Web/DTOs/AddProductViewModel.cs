using System.Collections.Generic;
using Warehouse.Web.Models;

namespace Warehouse.Web.DTOs
{
    public class AddProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
