using BusinessObject.Model;
using System;
using System.Collections.Generic;

namespace BusinessObject.ModelsDTO
{
    public partial class OrderDTO
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string? CompanyName { get; set; }
        public int? totalItem { get; set; }
    }
}
