using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                new ReplenishmentController(),
                new OrderController(),
                new CartController(),
                new HistoryController(),
                new InfoController(),
                new EscapeController(),
            };
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }

        private void ShowOptions()
        {
            foreach (var ui in UIs)
                Console.WriteLine($"{UIs.IndexOf(ui) + 1}. {ui.Message()}");
        }

        private void Action()
        {
            int option = int.Parse((Console.ReadKey().KeyChar).ToString());
            Console.Clear();
            UIs[option - 1].Action();
        }

        public void Run()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введіть ваше ім'я:");
                string name = Console.ReadLine();
                if (name.Length < 4 || name[0] == ' ')
                    throw new Exception();
                DBContext.User = new User(new UserDTO { Name = name, Balance = 0 });
            }
            catch
            {
                Run();
                return;
            }
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@"МАГАЗИН ""КАВА З ІМБИРОМ""");
                    Console.WriteLine($"\nВи увійшли як {DBContext.User.Name}. На рахунку {DBContext.User.Balance} гривень\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    ShowOptions();
                    Action();
                }
                catch (ExitException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
            }
        }
    }
}
