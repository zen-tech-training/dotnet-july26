using Ops.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Ops.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string SKU { get; set; } = string.Empty;
}

//Traditional Approach
//using System.ComponentModel.DataAnnotations;
//using Ops.Domain.Common;
//namespace Ops.Domain.Entities;
//public class Product : BaseEntity
//{
//    [Required]
//    [MaxLength(100)]
//    public string Name { get; set; } = string.Empty;

//    [MaxLength(500)]
//    public string? Description { get; set; }

//    [Range(0.01, 1000000)]
//    public decimal Price { get; set; }

//    [Range(0, 100000)]
//    public int StockQuantity { get; set; }

//    [Required]
//    [MaxLength(50)]
//    public string SKU { get; set; } = string.Empty;

//    [Timestamp]
//    public byte[] RowVersion { get; set; }
//}