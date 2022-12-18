using ShopSystem.Data;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class HistoryController : IUserInterface
    {
        public void Action()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Історія замовлень користувача {DBContext.User.Name}\n");
            Console.ForegroundColor = ConsoleColor.White;

            OrdersHistoryService orders = new OrdersHistoryService();
            ShopProductsService products = new ShopProductsService();
            var history = orders.ReadAll();

            if (history.Count == 0)
            {
                Console.WriteLine("Поки жодних замовлень в історії!");
                Console.ReadKey();
                return;
            }
            foreach (var order in history)
            {
                Console.WriteLine($"Дата: {order.Date}");
                foreach(var element in order.Products)
                {
                    Console.WriteLine($"{products.Read(element.productId).Name} у кількості {element.copies}");
                }
                Console.WriteLine($"Загальна сума склало {order.TotalPrice} грн");
                Console.WriteLine("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public string Message()
        {
            return "Показати історію замовлень";
        }
    }
}
