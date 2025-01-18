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
        private static readonly string _loginPattern = @"^\w{3,19}$";
        private static readonly string _passwordPattern = @"^(?=.*(\d)).{6,19}$";

        public static bool IsCorrectInput(string login, string password, string confirmPassword)
        {
            try
            {
                ValidateLogin(login);
                ValidatePassword(password, confirmPassword);
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

        public static void ValidateLogin(string input)
        {
            if (input is null || !Regex.IsMatch(input, _loginPattern))
            {
                throw new WrongLoginException("Некорректное имя пользователя!");
            }
        }

        public static void ValidatePassword(string input, string confirmPassword)
        {
            if (input is null || confirmPassword is null || !Regex.IsMatch(input, _passwordPattern) || input != confirmPassword)
            {
                throw new WrongPasswordException("Некорректный пароль!");
            }
        }
    }
}
