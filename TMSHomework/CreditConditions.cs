using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class CreditConditions
    {
        public decimal RequiredCredit { get; set; }

        public decimal TotalPayment { get; set; }

        public decimal PaymentPerMonth { get; set; }

        public decimal FirstPayment { get; set; }

        public int CreditDuration { get; set; }

        public decimal InterestRate { get; set; }

        public DateTime ProductStartDate { get; set; }

        public CreditConditions(decimal requiredCredit, decimal firstPayment, int creditDuration, decimal interestRate, DateTime productStartDate)
        {
            RequiredCredit = requiredCredit;
            FirstPayment = firstPayment;
            CreditDuration = creditDuration;
            InterestRate = interestRate;
            TotalPayment = SetCreditConditions();
            PaymentPerMonth = TotalPayment / 12;
            ProductStartDate = productStartDate;
        }

        public decimal SetCreditConditions()
        {
            return RequiredCredit - FirstPayment + (RequiredCredit - FirstPayment) * (InterestRate * CreditDuration / 12) / 100;
        }

        public decimal GetRemainingPayment()
        {
            return GetRemainingDuration() * PaymentPerMonth;
        }

        public decimal GetRemainingDuration()
        {
            return (DateTime.Now - ProductStartDate).Days / 365m * 12;
        }
    }
}
