using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using Warehouse.Web.Models;
using Warehouse.Web.Services.Contracts;

namespace Warehouse.Web.Services
{
    public class ExcelGeneratorService : IExcelGeneratorService
    {
        public MemoryStream GenerateProductExportAndWriteToMemoryStream(Product product)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excel = new ExcelPackage();

            excel.Workbook.Properties.Title = product.Name + "Export";
            excel.Workbook.Properties.Created = DateTime.Now;

            var worksheet = excel.Workbook.Worksheets.Add($"{excel.Workbook.Properties.Title}");
            PopulateHeaders(product, worksheet);
            PopulateData(product, worksheet);
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            var stream = new MemoryStream();
            excel.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }

        private void PopulateData(Product product, ExcelWorksheet worksheet)
        {
            worksheet.Cells[2, 1].Value = product.ProductId;
            worksheet.Cells[2, 2].Value = product.Name;
            worksheet.Cells[2, 3].Value = product.Category.Name;
            worksheet.Cells[2, 4].Value = product.MinQuantity;
            worksheet.Cells[2, 5].Value = product.OrderedQuantity;
            worksheet.Cells[2, 6].Value = product.DeliveredQuantity;
            worksheet.Cells[2, 7].Value = product.AvailableQuantity;
            worksheet.Cells[2, 8].Value = product.Price;
            worksheet.Cells[2, 9].Value = product.Supplier.CompanyName;
        }

        private void PopulateHeaders(Product product, ExcelWorksheet worksheet)
        {
            var productProperties = product.GetType()
                            .GetProperties()
                            .Where(p => !p.Name.Contains("Id"))
                            .ToArray();

            worksheet.Cells[1, 1].Value = "#";
            worksheet.Cells[1, 1].Style.Font.Bold = true;

            for (int i = 2; i <= productProperties.Count() + 1; i++)
            {
                var currentProperty = productProperties[i - 2];

                worksheet.Cells[1, i].Value = currentProperty.Name;
                worksheet.Cells[1, i].Style.Font.Bold = true;
            }
        }
    }
}
