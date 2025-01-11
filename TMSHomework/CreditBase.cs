using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace TMSHomework
{
    internal class CreditBase : IProduct
    {
        private DateTime ProductStartDate { get; set; }
        private decimal TotalPayment { get; set; }

        private decimal PaymentPerMonth { get; set; }

        [Description("Требуемый кредит")]
        public decimal RequiredCredit { get; set; }

        [Description("Первый взнос")]
        public decimal FirstPayment { get; set; }

        [Description("Срок действия кредита")]
        public decimal CreditDuration { get; set; }

        [Description("Процентная ставка")]
        public decimal InterestRate { get; set; }

        public CreditBase(decimal requiredCredit, decimal firstPayment, decimal creditDuration, decimal interestRate)
        {
            ProductStartDate = DateTime.Now;
            RequiredCredit = requiredCredit;
            FirstPayment = firstPayment;
            CreditDuration = creditDuration;
            InterestRate = interestRate;
            TotalPayment = SetCreditConditions();
            PaymentPerMonth = TotalPayment / CreditDuration;
        }

        public CreditBase(decimal interestRate)
        {
            InterestRate = interestRate;
        }

        public virtual decimal SetCreditConditions()
        {
            return RequiredCredit - FirstPayment + (RequiredCredit - FirstPayment) * (InterestRate * CreditDuration / 12) / 100;
        }

        public decimal GetRemainingPayment()
        {
            return GetRemainingDuration() * PaymentPerMonth;
        }

        public decimal GetRemainingDuration()
        {
            return CreditDuration - (DateTime.Now - ProductStartDate).Days / 365m * 12;
        }

        public void SetProductStartDate(DateTime date)
        {
            ProductStartDate = date;
        }

        public virtual string GetProductInfo()
        {
            return $"\nКредит оформлен: {ProductStartDate}" +
                   $"\nОбщая сумма кредита: {TotalPayment,0:N2}" +
                   $"\nСрок выплаты кредита: {CreditDuration,0:N0} мес." +
                   $"\nПроцентная ставка по кредиту: {InterestRate} %" +
                   $"\nЕжемесячный платеж: {PaymentPerMonth,0:N2}" +
                   $"\nОстаточный срок выплаты кредита: {GetRemainingDuration(),0:N2} мес." +
                   $"\nОстаточная сумма кредита: {GetRemainingPayment(),0:N2}";
        }

        public virtual string GetShortProductInfo()
        {
            return "Кредит поможет вам сделать мечту реальностью уже сейчас!";
        }
    }
}
