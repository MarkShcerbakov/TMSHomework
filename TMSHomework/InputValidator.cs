using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class InputValidator
    {
        public static readonly string LoginPattern = @"^\w{3,20}$";
        public static readonly string PasswordPattern = @"^(?=.*(\d)).{6,20}$";

        public static bool IsCorrectInput(string login, string password, string confirmPassword)
        {
            try
            {
                ValidateLogin(login, LoginPattern);
                ValidatePassword(password, confirmPassword, PasswordPattern);
            }
            catch (WrongLoginException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public static void ValidateLogin(string input, string pattern)
        {
            if (!Regex.IsMatch(input, pattern))
            {
                throw new WrongLoginException("Некорректное имя пользователя!");
            }
        }

        public static void ValidatePassword(string input, string confirmPassword, string pattern)
        {
            if (!Regex.IsMatch(input, pattern) || input != confirmPassword)
            {
                throw new WrongPasswordException("Некорректный пароль!");
            }
        }
    }
}
