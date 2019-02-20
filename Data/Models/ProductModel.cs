namespace Data.Models
{
    /// <summary>
    /// ProductModel class
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Get o set productId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Get or set product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set Bar code
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Get or set SalePrice
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Get or set BuyPrice
        /// </summary>
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// Get or set Stock
        /// </summary>
        public int Stock { get; set; }
        public decimal Tax { get; set; }
        public string MeasurementUnit { get; set; }
        public int GroupingId { get; set; }
        public int StatusId { get; set; }
    }
}
