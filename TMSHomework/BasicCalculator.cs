using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class BasicCalculator
    {
        public int NumA;
        public int NumB;
        public char Operation;

        public BasicCalculator(int numA, int numB, char operation)
        {
            NumA = numA;
            NumB = numB;
            Operation = operation;
        }

        public int Addition() => NumA + NumB;

        public int Substraction() => NumA - NumB;

        public int Multiplication() => NumA * NumB;

        public int Division() => NumA / NumB; // Проверить деление на ноль!!!

        public int Mod() => NumA % NumB;

        public int Pow() => (int)Math.Pow(NumA, NumB);

        public int Compute()
        {

            return 0;
        }
    }
}
