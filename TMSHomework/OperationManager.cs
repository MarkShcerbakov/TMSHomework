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
        private ExecutionManager _executionManager;

        public OperationManager(int first, int second)
        {
            _first = first;
            _second = second;
            _executionManager = new(this);
            _executionManager.PrepareExecution();
        }

        public int Addition()
        {
            return _first + _second;
        }

        public int Subtraction()
        {
            return _first - _second;
        }

        public int Multiplycation()
        {
            return _first * _second;
        }

        public int Division()
        {
            return _first / _second;
        }

        public int Execute(Operation operation)
        {
            return _executionManager.FuncExecute[operation]();
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
