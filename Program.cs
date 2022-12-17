using ShopSystem.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneralController UIController = new GeneralController();
            UIController.Run();
        }
    }
}
