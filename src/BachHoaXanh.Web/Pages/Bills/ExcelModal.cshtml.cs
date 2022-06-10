using BachHoaXanh.Bills;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages.Bills
{
    public class ExcelModalModel : BachHoaXanhPageModel
    {
        private readonly IBillAppService _billAppService;

        public ExcelModalModel(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }
        /*public async Task<FileResult> OnGetAsync()
        {
            var bills = await _billAppService.GetListBillAsync();
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Bills");
                worksheet.Cell(2, 2).Value = "Customer";
                worksheet.Cell(2, 3).Value = "Product";
                worksheet.Cell(2, 4).Value = "Quantity";
                worksheet.Cell(2, 5).Value = "Unit price";

                IXLRange range = worksheet.Range(worksheet.Cell(2, 2).Address, worksheet.Cell(2, 5).Address);
                range.Style.Fill.SetBackgroundColor(XLColor.Almond);

                int index = 2;
                foreach (var item in bills)
                {
                    index++;
                    worksheet.Cell(index, 2).Value = item.CustomerName;
                    *//*worksheet.Cell(index, 3).Value = item.ProductName;
                    worksheet.Cell(index, 4).Value = item.Quantity;
                    worksheet.Cell(index, 5).Value = item.UnitPrice;*//*
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    var strDate = DateTime.Now.ToString("yyyyMMdd");
                    string filename = string.Format($"Bills_{strDate}.xlsx");

                    return File(content, contentType, filename);
                }
            }
        }*/
    }
}
