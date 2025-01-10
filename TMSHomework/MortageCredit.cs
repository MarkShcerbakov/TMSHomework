using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class MortageCredit : CreditBase
    {
        public MortageCredit(decimal requiredCredit, decimal firstPayment, decimal creditDuration, decimal interestRate)
            : base(requiredCredit, firstPayment, creditDuration, interestRate)
        {
        }

        public MortageCredit(decimal interestRate) : base(interestRate)
        {
            
        }

        public override decimal SetCreditConditions()
        {
            return RequiredCredit - FirstPayment + (RequiredCredit - FirstPayment) * (InterestRate * CreditDuration / 12) / 100;
        }

        public override string GetProductInfo()
        {
            return GetShortProductInfo() + base.GetProductInfo();
        }

        public override string GetShortProductInfo()
        {
            return $"\nИпотечный кредит" + $"\nКредитование для покупки жилья" + $"\nДо {InterestRate}% годовых";
        }
    }
}
