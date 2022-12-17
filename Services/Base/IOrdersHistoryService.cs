using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services.Base
{
    internal interface IOrdersHistoryService
    {
        void Create(Order newOrder);
        Order Read(int orderId);
        List<Order> ReadAll();
    }
}
