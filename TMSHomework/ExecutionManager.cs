using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class ExecutionManager
    {
        private int _first;
        private int _second;
        private Dictionary<Operation, Func<int>> FuncExecute { get; set; }

        public ExecutionManager(int first, int second)
        {
            _first = first;
            _second = second;
            FuncExecute = new()
            {
                [Operation.Addition] = Addition,
                [Operation.Subtraction] = Substraction,
                [Operation.Multiplication] = Multiply,
                [Operation.Division] = Division
            };
        }

        public int Execute(Operation operation) => FuncExecute[operation]();

        private int Addition() => _first + _second;

        private int Substraction() => _first - _second;

        private int Multiply() => _first * _second;

        private int Division() => _first / _second;
    }
}
