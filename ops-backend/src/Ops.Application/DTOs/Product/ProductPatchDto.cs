using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.DTOs.Product
{
    public class ProductPatchDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public string? SKU { get; set; }
    }
}
