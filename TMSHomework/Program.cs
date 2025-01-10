namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson7-Task1-BankEmulator");
            Console.WriteLine("Приложение осуществляет эмуляцию работы банка с использованием ООП\n");

            var creditCarBank = new CarCredit(InterestRateRoster.InterestRateCar);
            var creditMortageBank = new MortageCredit(InterestRateRoster.InterestRate);
            var creditConsumerBank = new ConsumerCredit(InterestRateRoster.InterestRateConsumer);
            var depositSavingAccountBank = new SavingAccountDeposit(InterestRateRoster.InterestRateCar);
            var doubleBenefitDepositBank = new DoubleBenefitDeposit(InterestRateRoster.InterestRateCar);
            IProduct[] bankProducts = { creditCarBank, creditMortageBank, creditConsumerBank, depositSavingAccountBank, doubleBenefitDepositBank };

            var creditCar = new CarCredit(1_500_000, 300_000, 18, InterestRateRoster.InterestRateCar);
            var creditMortage = new MortageCredit(5_500_000, 300_000, 120, InterestRateRoster.InterestRate);
            var creditConsumer = new ConsumerCredit(400_000, 0, 24, InterestRateRoster.InterestRateConsumer);
            var depositSavingAccount = new SavingAccountDeposit(100_000, 24, 10);
            var doubleBenefitDeposit = new DoubleBenefitDeposit(300_000, 16, 10);
            IProduct[] clientsProducts = { creditCar, creditMortage, creditConsumer, depositSavingAccount, doubleBenefitDeposit };

            creditCar.SetProductStartDate(new DateTime(2024, 1, 9));
            creditMortage.SetProductStartDate(new DateTime(2024, 1, 9));
            creditConsumer.SetProductStartDate(new DateTime(2024, 1, 9));
            depositSavingAccount.SetProductStartDate(new DateTime(2024, 1, 9));
            doubleBenefitDeposit.SetProductStartDate(new DateTime(2024, 1, 9));

            Client clientOne = new(111111111, "Vasili", "Pupkin", 1_500_000, clientsProducts[1..4].ToList());
            Client clientTwo = new(222222222, "Ivan", "Ivanov", 2_500_000, clientsProducts[3..].ToList());
            Client clientThree = new(333333333, "Petr", "Petrov", 3_500_000, clientsProducts[2..4].ToList());
            Client[] clients = new[] { clientOne, clientTwo, clientThree };

            Bank bank = new("Test-Bank", bankProducts, clients);
            bank.Run();
        }
    }
}
