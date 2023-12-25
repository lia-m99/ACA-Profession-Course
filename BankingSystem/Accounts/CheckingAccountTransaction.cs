using BankingSystem.Helper;

namespace BankingSystem.Accounts
{
    public class CheckingAccountTransaction : IAccountTransaction
    {
        private readonly decimal _overdraftLimit;

        public CheckingAccountTransaction(decimal overdraftLimit)
        {
            _overdraftLimit = overdraftLimit;
        }

        public decimal Withdraw(decimal balance, decimal amount)
        {
            if (amount > 0)
            {
                decimal potentialBalance = balance - amount;

                if (potentialBalance >= -_overdraftLimit)
                {
                    Console.WriteLine($"Withdrawn: {amount}, New Balance: {potentialBalance}");
                    return potentialBalance;

                }

                throw new Exception(ErrorTexts.Data[ErrorCode.ExceedOverdraftLimit]);
            }

            throw new Exception(ErrorTexts.Data[ErrorCode.InvalidWithdrawalAmount]);
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");

            return balance;
        }

        public decimal OverdraftLimit => _overdraftLimit;
    }
}
