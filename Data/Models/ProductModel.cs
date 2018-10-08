using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProductModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int Stock { get; set; }
        public decimal Tax { get; set; }
        public string MeasurementUnit { get; set; }
        public int GroupingId { get; set; }
        public int StatusId { get; set; }
    }
}
