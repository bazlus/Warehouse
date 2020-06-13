using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Web.DTOs;
using Warehouse.Web.Models;

namespace Warehouse.Web.Services.Contracts
{
    public interface IWarehouseService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Supplier> GetAllSuppliers();
        IEnumerable<Product> GetFilteredProducts(Filter filter);
        Product GetProductById(long id);
        Task<bool> RemoveProduct(long id);
        Task<long> AddProduct(AddProductInputModel productInputModel);
    }
}
