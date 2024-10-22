using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listOrderDetails = context.OrderDetails
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }
        public static List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listOrderDetails = context.OrderDetails
                        .Where (x => x.OrderId == orderId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }
        public static OrderDetail FindOrderDetailById(int oid, int pid)
        {
            OrderDetail p = new OrderDetail();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    p = context.OrderDetails
                        .SingleOrDefault(x => x.OrderId == oid && x.ProductId == pid);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static void CreateOrderDetail(OrderDetail p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.OrderDetails.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static   void UpdateOrderDetail(OrderDetail p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Entry<OrderDetail>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrderDetail(int oid, int pid)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    var OrderDetail = context.OrderDetails
                        .SingleOrDefault(x => x.OrderId == oid && x.ProductId == pid);

                    if (OrderDetail != null)
                    {
                        context.OrderDetails.Remove(OrderDetail);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("OrderDetail not found.");
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
