using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class ExpressionCalculator
    {
        private const string _operatorsPriority = "^*/%+-";

        public static string Compute(string expression)
        {
            expression = Regex.Replace(expression, @"\s", "");
            if (BracersValidator(string.Concat(expression.Where("()".Contains))))
            {
                return "Некорректное выражение!";
            }
            if (double.TryParse(expression, out double _))
            {
                return expression;
            }
            if (Regex.IsMatch(expression, @"\(.+?\)"))
            {
                return Compute(UpdateExpressionInBracers(expression));
            }
            else
            {
                return Compute(UpdateExpression(expression));
            }
        }

        private static string UpdateExpression(string expression)
        {
            var match = _operatorsPriority.Select(op => Regex.Match(expression, $@"(?<=[\+\-\*\/\^\%\(]|\A)((-?)(\d?\,?\d+))(\{op})((-?)(\d?\,?\d+))")).First(m => m.Success);
            var calc = Calculate(match.Groups[1].Value, match.Groups[5].Value, match.Groups[4].Value);
            var updateExpression = expression.Replace(match.Value, $"{calc}");
            return updateExpression;
        }

        private static string UpdateExpressionInBracers(string expression)
        {
            var match = Regex.Match(expression, @"\(.+?\)");
            var calc = Compute(match.Value[1..^1]);
            var updateExpression = expression.Replace(match.Value, $"{calc}"); ;
            return updateExpression;
        }

        private static double Calculate(string a, string b, string op) => op switch
        {
            "+" => double.Parse(a) + double.Parse(b),
            "-" => double.Parse(a) - double.Parse(b),
            "*" => double.Parse(a) * double.Parse(b),
            "/" => b == "0"
                ? throw new DivideByZeroException("Деление на ноль!")
                : double.Parse(a) / double.Parse(b),
            "^" => a[0] == '-' && b == "0,5"
                ? throw new ArithmeticException("Корень из отрицательного числа!")
                : Math.Pow(double.Parse(a), double.Parse(b)),
            "%" => double.Parse(a) % double.Parse(b),
            _ => throw new ArithmeticException()
        };

        private static bool BracersValidator(string expression) => expression.Aggregate(expression, (cur, _) => Regex.Replace(cur, @"\(\)", "")).Any();
    }
}
