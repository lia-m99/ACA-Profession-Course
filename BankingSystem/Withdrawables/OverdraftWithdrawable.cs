using BankingSystem.Helper;

namespace BankingSystem.Withdrawables
{
    public class OverdraftWithdrawable : IWithdrawable
    {
        private readonly decimal _overdraftLimit;

        public OverdraftWithdrawable(decimal overdraftLimit)
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

        public decimal OverdraftLimit => _overdraftLimit;
    }
}
