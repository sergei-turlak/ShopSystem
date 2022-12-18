using ShopSystem.Data;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class OrderController : IUserInterface
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Додати до кошика певний товар - натисність 'Y/y'");
            Console.WriteLine("До меню - будь-яка клавіша");
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.ReadKey().Key != ConsoleKey.Y) return;
            Console.WriteLine("\nУкажіть номер товару (1,2,3...):");
            int number = int.Parse((Console.ReadKey().KeyChar.ToString()));
            Console.WriteLine($"\nЯку кількість екземплярів {products[number-1].Name} додати до кошика?");
            int copies = int.Parse(Console.ReadLine());
            Console.WriteLine($"Додати до кошика {products[number-1].Name} у кількості {copies} екземплярів вартістю {products[number-1].Price} * {copies} = {products[number - 1].Price* copies} грн?!");
            Console.WriteLine("Підтвердити - натисність 'Y/y'");
            Console.WriteLine("Скасувати операцію - будь-яка клавіша");
            if (Console.ReadKey().Key != ConsoleKey.Y) return;
            DBContext.User.AddProductToCart(products[number - 1].Id, copies);
        }

        public string Message()
        {
            return "Показати товари в наявності та замовити";
        }
    }
}
