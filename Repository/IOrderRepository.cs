using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        List<Order> GetOrdersByMemberId(string memberId);

        Order FindOrderById(int orderId);
        void CreateOrder(Order p);
        void UpdateOrder(Order p);
        void DeleteOrder(int id);
    }
}
