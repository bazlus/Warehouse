using Warehouse.Web.Models;

namespace Warehouse.Web.DTOs
{
    public class Filter
    {
        public long CategoryId{ get; set; }
        public string SearchText { get; set; }
    }
}
