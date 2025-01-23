using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class ExecutionManager
    {
        public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
        private OperationManager _operationManager;

        public ExecutionManager(OperationManager operationManager)
        {
            _operationManager = operationManager;
            FuncExecute = new();
        }

        public void PopulateFunctions(Operation operation, Func<int> func)
        {
            FuncExecute.Add(operation, func);
        }

        public void PrepareExecution()
        {
            PopulateFunctions(Operation.Addition, _operationManager.Addition);
            PopulateFunctions(Operation.Subtraction, _operationManager.Subtraction);
            PopulateFunctions(Operation.Multiplication, _operationManager.Multiplycation);
            PopulateFunctions(Operation.Division, _operationManager.Division);
        }
    }
}
