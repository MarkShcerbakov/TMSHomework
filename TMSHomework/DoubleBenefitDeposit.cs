using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class DoubleBenefitDeposit : DepositBase
    {
        public DoubleBenefitDeposit(decimal firstPayment, decimal depositDuration, decimal interestRate) : base(firstPayment, depositDuration, interestRate)
        {
        }

        public DoubleBenefitDeposit(decimal interestRate) : base(interestRate)
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
            return $"\nВклад - Двойная выгода" + $"\nВклад с максимальной ставкой" + $"\nДо {InterestRate}% годовых";
        }
    }
}
