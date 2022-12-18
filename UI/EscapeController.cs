using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.UI
{
    internal class EscapeController : IUserInterface
    {
        public void Action()
        {
            throw new ExitException();
        }

        public string Message()
        {
            return "Вихід";
        }
    }

    class ExitException : Exception { }
}
