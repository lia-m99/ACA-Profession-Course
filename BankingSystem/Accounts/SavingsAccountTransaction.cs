using BankingSystem.Helper;

namespace BankingSystem.Accounts
{
    public class SavingsAccountTransaction : IAccountTransaction
    {
        public decimal Withdraw(decimal balance, decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, New Balance: {balance}");
                return balance;
            }

            throw new Exception(ErrorTexts.Data[ErrorCode.InvalidWithdrawalAmount]);
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");

            return balance;
        }
    }
}
