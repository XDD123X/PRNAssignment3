using System;
using System.Collections.Generic;

namespace BusinessObject.ModelsDTO
{
    public partial class ProductDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public double? Weight { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string? CategoryName { get; set; }
    }
}
