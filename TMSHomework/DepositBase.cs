using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class DepositBase : IProduct
    {
        private DateTime ProductStartDate { get; set; }
        private decimal DepositEarning { get; set; }

        [Description("Первый платеж")]
        public decimal FirstPayment { get; set; }

        [Description("Срок депозита")]
        public decimal DepositDuration { get; set; }

        [Description("Процентная ставка")]
        public decimal InterestRate { get; set; }

        public DepositBase(decimal firstPayment, decimal depositDuration, decimal interestRate)
        {
            ProductStartDate = DateTime.Now;
            FirstPayment = firstPayment;
            DepositDuration = depositDuration;
            InterestRate = interestRate;
            DepositEarning = SetDepositConditions();
        }

        public DepositBase(decimal interestRate)
        {
            InterestRate = interestRate;
        }

        public virtual decimal SetDepositConditions()
        {
            return FirstPayment + FirstPayment * InterestRate * DepositDuration / 12 / 100;
        }

        public decimal GetRemainingDuration()
        {
            return DepositDuration - (DateTime.Now - ProductStartDate).Days / 365m * 12;
        }

        public decimal GetCurrentDeposit()
        {
            return (DateTime.Now - ProductStartDate).Days / 365m * 12 * FirstPayment * InterestRate / 12 / 100;
        }

        public void SetProductStartDate(DateTime date)
        {
            ProductStartDate = date;
        }

        public virtual string GetProductInfo()
        {
            return $"\nДепозит оформлен: {ProductStartDate}" +
                   $"\nОбщая сумма депозита: {DepositEarning,0:N2}" +
                   $"\nСрок депозита: {DepositDuration,0:N0} мес." +
                   $"\nПроцентная ставка по депозиту: {InterestRate} %" +
                   $"\nНа текущий момент заработано: {GetCurrentDeposit(),0:N2}";
        }

        public virtual string GetShortProductInfo()
        {
            return "\nДепозиты сохранят ваши деньги и принесут проценты!";
        }
    }
}
