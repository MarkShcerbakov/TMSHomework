using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class CheatCalculator
    {
        public string Expression;

        public CheatCalculator(string exprassion)
        {
            Expression = exprassion;
        }

        public string Compute() => new DataTable().Compute(Expression, "").ToString();
    }
}
