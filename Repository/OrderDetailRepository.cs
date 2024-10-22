using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void CreateOrderDetail(OrderDetail p) => OrderDetailDAO.CreateOrderDetail(p);

        public void DeleteOrderDetail(int oid, int pid) => OrderDetailDAO.DeleteOrderDetail(oid, pid);
        public OrderDetail FindOrderDetailById(int orderId, int productId) => OrderDetailDAO.FindOrderDetailById(orderId, productId);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.GetOrderDetailsByOrderId(orderId);

        public void UpdateOrderDetail(OrderDetail p) => OrderDetailDAO.UpdateOrderDetail(p);
    }
}
