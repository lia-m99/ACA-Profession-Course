using BankingSystem.Helper;

namespace BankingSystem.Withdrawables
{
    public class Withdrawable : IWithdrawable
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
    }

}
