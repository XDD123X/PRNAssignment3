using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    using BusinessObject.Model;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DataAccess
    {
        public class OrderDAO
        {
            public static List<Order> GetOrders()
            {
                var listOrders = new List<Order>();
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        listOrders = context.Orders
                            .Include(b => b.OrderDetails)
                            .ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return listOrders;
            }
            public static List<Order> GetOrdersByMemberId(string memberId)
            {
                var listOrders = new List<Order>();
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        listOrders = context.Orders
                            .Where(o => o.MemberId.Equals(memberId))
                            .Include(b => b.OrderDetails)
                            .ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return listOrders;
            }
            public static Order FindOrderById(int OrderId)
            {
                Order p = new Order();
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        p = context.Orders
                             .Include(b => b.OrderDetails)
                            .SingleOrDefault(x => x.OrderId == OrderId);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return p;
            }
            public static void CreateOrder(Order p)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        context.Orders.Add(p);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public static void UpdateOrder(Order p)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        context.Entry<Order>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public static void DeleteOrder(int id)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        var Order = context.Orders
                            .Include(b => b.OrderDetails)
                            .SingleOrDefault(x => x.OrderId == id);

                        if (Order != null)
                        {
                            if (Order.OrderDetails != null && Order.OrderDetails.Any())
                            {
                                context.OrderDetails.RemoveRange(Order.OrderDetails);
                            }
                            context.Orders.Remove(Order);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Order not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }

}
