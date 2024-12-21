using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class AdvancedCalculator
    {
        public string Expression;
        public readonly string Operators = "()^*/%+-";
        public readonly string[] OperatorsPriority = new[] { "()", "^", "*/%", "+-" }; // Приоритетность по убыванию

        public AdvancedCalculator(string expression)
        {
            Expression = expression;
        }

        public string Compute()
        {
            var rpn = BuildRPN();
            if (rpn.Count > 0)
            {
                while (rpn.Count >= 3)
                {
                    var idx = Array.FindIndex(rpn.ToArray(), Operators.Contains);
                    var tmp = Calculate(rpn[idx - 2], rpn[idx - 1], rpn[idx]);
                    rpn[idx - 2] = $"{tmp}";
                    rpn.RemoveAt(idx);
                    rpn.RemoveAt(idx - 1);
                }

                return rpn[0];
            }
            else
            {
                return "Введено некорректное выражение!";
            }
        }

        public List<string> BuildRPN()
        {
            if (!IsCorrectExpression())
            {
                return new List<string>();
            }

            var tmp = "";
            var output = new List<string>();
            var stack = new Stack<string>();

            for (int pos = 0; pos < Expression.Length; pos++)
            {
                var item = Expression[pos];
                if (Operators.Contains(item))
                {
                    if (tmp.Length > 0)
                    {
                        output.Add(tmp);
                        tmp = "";
                    }
                    if (stack.Count == 0)
                    {
                        stack.Push($"{item}");
                    }
                    else
                    {
                        if (item == ')')
                        {
                            if (stack.Contains("("))
                            {
                                while (stack.First() != "(")
                                {
                                    output.Add(stack.Pop());
                                }

                                stack.Pop();
                            }
                            else
                            {
                                return new List<string>();
                            }
                        }
                        else
                        {
                            var priorityStackOperator = FindPriority(stack.First());
                            var priorityExpressionOperator = FindPriority($"{item}");
                            while (stack.First() != "(" && priorityStackOperator <= priorityExpressionOperator)
                            {
                                output.Add(stack.Pop());
                                if (stack.Count > 0)
                                {
                                    priorityStackOperator = FindPriority(stack.First());
                                }
                                else
                                {
                                    break;
                                }
                            }

                            stack.Push($"{item}");
                        }
                    }
                }
                else
                {
                    tmp += item;
                }
            }

            if (tmp.Length > 0)
            {
                output.Add(tmp);
            }

            if (stack.All(Operators.Contains))
            {
                while (stack.Count > 0)
                {
                    output.Add(stack.Pop());
                }
            }
            else
            {
                return new List<string>();
            }

            return output;
        }

        public double Calculate(string a, string b, string op) => op switch
        {
            "+" => double.Parse(a) + double.Parse(b),
            "-" => double.Parse(a) - double.Parse(b),
            "*" => double.Parse(a) * double.Parse(b),
            "/" => b == "0" ? throw new DivideByZeroException("Деление на ноль!") : double.Parse(a) / double.Parse(b), // Деление на 0!
            "^" => a[0] == '-' && b == "0,5" ? throw new ArithmeticException("Корень из отрицательного числа!") : Math.Pow(double.Parse(a), double.Parse(b)),
            "%" => double.Parse(a) % double.Parse(b),
            _ => throw new ArithmeticException()
        };

        private bool IsCorrectExpression() => Regex.IsMatch(Expression, @"^[0-9\,\(\)\%\^\+\-\/\*]+$");

        private int FindPriority(string op) => Array.FindIndex(OperatorsPriority, m => m.Contains(op));
    }
}
