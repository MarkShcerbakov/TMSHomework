using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class SavingAccountDeposit : DepositBase
    {
        public SavingAccountDeposit(decimal firstPayment, decimal depositDuration, decimal interestRate) : base(firstPayment, depositDuration, interestRate)
        {
        }

        public SavingAccountDeposit(decimal interestRate) : base(interestRate)
        {
            
        }

        public override decimal SetDepositConditions()
        {
            return FirstPayment + FirstPayment * InterestRate * DepositDuration / 12 / 100;
        }

        public override string GetProductInfo()
        {
            return GetShortProductInfo() + base.GetProductInfo();
        }

        public override string GetShortProductInfo()
        {
            return $"\nНакопительный счет" + $"\nНачисление процентов на минимальный остаток средств на счете за месяц" + $"\nДо {InterestRate}% годовых";
        }
    }
}
