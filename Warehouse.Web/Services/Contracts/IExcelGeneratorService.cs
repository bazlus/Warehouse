using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Web.Models;

namespace Warehouse.Web.Services.Contracts
{
    public interface IExcelGeneratorService
    {
        MemoryStream GenerateProductExportAndWriteToMemoryStream(Product product);
    }
}
