using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class OperationManager
    {
        private int _first;
        private int _second;

        public OperationManager(int first, int second)
        {
            _first = first;
            _second = second;
        }

        private int Sum()
        {
            return _first + _second;
        }

        private int Subtract()
        {
            return _first - _second;
        }

        private int Multiply()
        {
            return _first * _second;
        }

        private int Divide()
        {
            return _first / _second;
        }

        public int Execute(Operation operation)
        {
            switch (operation)
            {
                case Operation.Addition:
                    return Sum();
                case Operation.Subtraction:
                    return Subtract();
                case Operation.Multiplication:
                    return Multiply();
                case Operation.Division:
                    return Divide();
                default:
                    return -1; //just to simulate
            }
        }
    }
}

public enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}
