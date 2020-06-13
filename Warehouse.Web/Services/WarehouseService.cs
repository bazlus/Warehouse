using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Web.Data;
using Warehouse.Web.DTOs;
using Warehouse.Web.Models;
using Warehouse.Web.Services.Contracts;

namespace Warehouse.Web.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly WarehouseDbContext db;

        public WarehouseService(WarehouseDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.db.Categories.ToList();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this.db.Suppliers.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.db.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .ToArray();
        }

        public IEnumerable<Product> GetFilteredProducts(Filter filter)
        {
            var query = this.db.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .AsQueryable();


            if (!string.IsNullOrEmpty(filter.SearchText))
                query = query.Where(p => p.Name.Contains(filter.SearchText));

            if (filter.CategoryId != 0)
                query = query.Where(p => p.CategoryId == filter.CategoryId);


            return query.ToList();
        }

        public Product GetProductById(long id)
        {
            return this.db.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
        }

        public async Task<bool> RemoveProduct(long id)
        {
            var product = this.db.Products.FirstOrDefault(p => p.ProductId == id);
            this.db.Products.Remove(product);

            var changedRows = await this.db.SaveChangesAsync();

            return changedRows > 0 ? true : false;
        }

        public async Task<long> AddProduct(AddProductInputModel productInputModel)
        {
            var newProduct = new Product()
            {
                AvailableQuantity = productInputModel.AvailableQuantity,
                CategoryId = productInputModel.CategoryId,
                MinQuantity = productInputModel.MinQuantity,
                Name = productInputModel.Name,
                Price = productInputModel.Price,
                SupplierId = productInputModel.SupplierId
            };

            this.db.Products.Add(newProduct);
            return await this.db.SaveChangesAsync();
        }
    }
}
