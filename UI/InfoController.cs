using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class InfoController : IUserInterface
    {
        public void Action()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"МАГАЗИН ""КАВА З ІМБИРОМ""" +
                $"\nФінальна робота. Реалізація системи інтернет-магазину за принципами ООП"
                + "\nТР-15 Ткаченко Майя");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public string Message()
        {
            return "Інформація про застосунок";
        }
    }
}
