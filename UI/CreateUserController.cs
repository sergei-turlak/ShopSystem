using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class CreateUserController : IUserInterface
    {
        public void Action()
        {
            if (DBContext.User != null) return;
            Console.WriteLine("Введіть ваше ім'я:");
            string name = Console.ReadLine();
            if (name.Length < 4 || name[0] == ' ')
            {
                Console.WriteLine("Ім'я занадто коротке");
                Action();
                return;
            }
            DBContext.User = new User(new UserDTO { Name = name, Balance = 0 });
        }

        public string Message()
        {
            if (DBContext.User == null)
                return "Налаштування інформації про користувача";
            else
                return $"Ви увійшли як {DBContext.User.Name}. На рахунку {DBContext.User.Balance} гривень";
        }
    }
}
