using ShopSystem.Data;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class ShowShopProductsController : IUserInterface
    {
        public void Action()
        {
            var products = new ShopProductsService().ReadAll();
            products = products.Where(x => x.Copies != 0).ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"{products.IndexOf(product) + 1}. {product.Name}");
                Console.WriteLine($"Id товару: {product.Id}");
                Console.WriteLine($"Ціна за одиницю: {product.Price} грн");
                Console.WriteLine($"Опис товару: {product.Description}");
                Console.WriteLine($"Кількість у наявності: {product.Copies}");
                Console.WriteLine("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*");
                Console.WriteLine();
            }

            Console.WriteLine("Додати до кошика певний товар - натисність 'Y/y'");
            Console.WriteLine("До меню - будь-яка клавіша");
            if (Console.ReadKey().Key != ConsoleKey.Y) return;
            Console.WriteLine("Укажіть номер товару (1,2,3...):");
            int number = int.Parse((Console.ReadKey().KeyChar.ToString()));

            DBContext.User.AddProductToCart()
        }

        public string Message()
        {
            return "Показати товари в наявності";
        }
    }
}
