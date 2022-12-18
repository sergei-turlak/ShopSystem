using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class ReplenishmentController : IUserInterface
    {
        public void Action()
        {
            Console.WriteLine($"Зараз на рахунку {DBContext.User.Name}: {DBContext.User.Balance} грн");
            Console.WriteLine("Введіть суму поповнення:");
            int value = int.Parse(Console.ReadLine());
            DBContext.User.ReplenishBalance(value);
        }

        public string Message()
        {
            return "Поповнити рахунок";
        }
    }
}
