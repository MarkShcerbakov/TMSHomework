using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class CarCredit : CreditBase
    {
        public CarCredit(decimal requiredCredit, decimal firstPayment, decimal creditDuration, decimal interestRate)
            : base(requiredCredit, firstPayment, creditDuration, interestRate)
        {
        }

        public CarCredit(decimal interestRate) : base(interestRate)
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
            return $"\nАвтоКредит" + $"\nКредитование для покупки автомобилей" + $"\nДо {InterestRate}% годовых";
        }
    }
}
