using ShopSystem.Data;
using ShopSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services
{
    internal class OrdersHistoryServiceAsync : IOrdersHistoryService
    {
        public void Create(Order newOrder)
        {
            DBContext.OrdersHistory.Add(newOrder);
        }

        public Order Read(int orderId)
        {
            Order order = DBContext.OrdersHistory.Find(x => x.Id == orderId);
            if (order == null) throw new Exception("Історії купівлі (замовлення) з таким індексом не знайдено");
            return order;
        }

        public List<Order> ReadAll()
        {
            return DBContext.OrdersHistory;
        }
    }
}
