using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Web.DTOs;
using Warehouse.Web.Models;
using Warehouse.Web.Services.Contracts;

namespace Warehouse.Web.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService warehouseService;
        private readonly IExcelGeneratorService excelGenerator;

        public WarehouseController(IWarehouseService warehouseService, IExcelGeneratorService excelGenerator)
        {
            this.warehouseService = warehouseService;
            this.excelGenerator = excelGenerator;
        }

        public IActionResult Search(Filter filter)
        {
            IEnumerable<Product> products;

            if (filter.CategoryId == 0 && string.IsNullOrEmpty(filter.SearchText))
                products = warehouseService.GetAllProducts();
            else
                products = warehouseService.GetFilteredProducts(filter);

            var model = new SearchViewModel()
            {
                Products = products,
                Categories = warehouseService.GetAllCategories(),
                Filter = filter
            };

            return View(model);
        }

        public async Task<IActionResult> ExportProduct(long id)
        {
            var product = warehouseService.GetProductById(id);
            var exportExcel = excelGenerator.GenerateProductExportAndWriteToMemoryStream(product);
            var isRemoved = await warehouseService.RemoveProduct(id);

            if (isRemoved)
                return File(exportExcel,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "report.xlsx");
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var viewModel = new AddProductViewModel()
            {
                Categories = warehouseService.GetAllCategories(),
                Suppliers = warehouseService.GetAllSuppliers()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductInputModel product)
        {
            try
            {
                var productId = await this.warehouseService.AddProduct(product);
                return RedirectToAction(nameof(Search));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
