using BusinessObject.Model;
using DataAccess;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order p) => OrderDAO.CreateOrder(p);

        public void DeleteOrder(int id) => OrderDAO.DeleteOrder(id);

        public Order FindOrderById(int orderId) => OrderDAO.FindOrderById(orderId);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public List<Order> GetOrdersByMemberId(string memberId) => OrderDAO.GetOrdersByMemberId(memberId);
        public void UpdateOrder(Order p) => OrderDAO.UpdateOrder(p);
    }
}
