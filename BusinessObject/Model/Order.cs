using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string MemberId { get; set; }      
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }

        public ApplicationUser Member { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
