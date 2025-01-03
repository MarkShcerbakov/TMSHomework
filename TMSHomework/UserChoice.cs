using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class UserChoice
    {
        public static bool GetChoice(string userChoice, out int choice)
        {
            if (!int.TryParse(userChoice, out choice))
            {
                return true;
            }
            if (choice == 0)
            {
                Console.WriteLine("Спасибо за работу в приложении!\nУдачного дня!");
                choice = 0;
                return false;
            }

            return true;
        }
    }
}
