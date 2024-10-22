using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
        List<OrderDetail> GetOrderDetailsByOrderId(int orderId);

        OrderDetail FindOrderDetailById(int orderId, int productId);
        void CreateOrderDetail(OrderDetail p);
        void UpdateOrderDetail(OrderDetail p);
        void DeleteOrderDetail(int oid, int pid);
    }
}
