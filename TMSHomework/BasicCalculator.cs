using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class BasicCalculator
    {
        public double NumA;
        public double NumB;
        public string Operation;

        public BasicCalculator(double numA, double numB, string operation)
        {
            NumA = numA;
            NumB = numB;
            Operation = operation;
        }

        public double Addition() => NumA + NumB;

        public double Substraction() => NumA - NumB;

        public double Multiplication() => NumA * NumB;

        public double Division() => NumB == 0 ? throw new DivideByZeroException("Деление на ноль!") : NumA / NumB;

        public double Percent() => NumA / 100 * NumB;

        public double Pow() => NumA < 0 && NumB == 0.5 ? throw new ArithmeticException("Корень из отрицательного числа!") : Math.Pow(NumA, NumB);

        public double Compute() => Operation switch
        {
            "+" => Addition(),
            "-" => Substraction(),
            "*" => Multiplication(),
            "/" => Division(),
            "^" => Pow(),
            "%" => Percent(),
            _ => throw new ArithmeticException()
        };
    }
}
