using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class GeneralController
    {
        private List<IUserInterface> UIs;

        public GeneralController()
        {
            UIs = new List<IUserInterface>
            {
                new BalanceReplenishmentController(),

            };
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }

        private void ShowOptions()
        {
            foreach (var ui in UIs)
                Console.WriteLine($"{UIs.IndexOf(ui)+1}. {ui.Message()}");
        }

        private void Action()
        {
            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            UIs[option - 1].Action();
        }

        private void ShowTitle()
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"МАГАЗИН ""КАВА З ІМБИРОМ""");
            Console.WriteLine();
            Console.ForegroundColor = def;
        }

        private void CreateUser()
        {
            ShowTitle();
            CreateUserController create = new CreateUserController();
            Console.WriteLine(create.Message());
            create.Action();
            UIs.Insert(0, create);
        }

        public void Run()
        {
            CreateUser();
            while (true)
            {
                Console.Clear();
                ShowTitle();
                ShowOptions();
                Action();
            }
        }
    }
}
