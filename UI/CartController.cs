using ShopSystem.Data;
using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class CartController : IUserInterface
    {
        public void Action()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Зміст кошика:\n");
            Console.ForegroundColor = ConsoleColor.White;

            ShopProductsService products = new ShopProductsService();
            var elements = DBContext.User.ProductsCart;

            if (elements.Count == 0)
            {
                Console.WriteLine("Поки жодних товарів у кошику замовлень!");
                Console.ReadKey();
                return;
            }
            foreach(var element in elements)
            {
                Console.WriteLine($"{products.Read(element.productId).Name}");
                Console.WriteLine($"Кількість: {element.copies}");
                Console.WriteLine($"Вартість: {products.Read(element.productId).Price} * {element.copies} = {products.Read(element.productId).Price * element.copies} грн");
                Console.WriteLine("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\t*");
                Console.WriteLine();
            }
            Console.WriteLine($"Загальна сума замовлення товарів у кошику: {elements.TotalPrice} грн\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Здійснити купівлю усіх товарів у кошику замовлень?!");
            Console.WriteLine("Підтвердити - натисність 'Y/y'");
            Console.WriteLine("Скасувати операцію - будь-яка клавіша");
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.ReadKey().Key != ConsoleKey.Y) return;
            DBContext.User.BuyProductsInCart();

        }

        public string Message()
        {
            return "Переглянути зміст кошика товарів та оформлення замовлення";
        }
    }
}
