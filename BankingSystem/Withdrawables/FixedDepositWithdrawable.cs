using BankingSystem.Helper;

namespace BankingSystem.Withdrawables
{
    internal class FixedDepositWithdrawable : IWithdrawable
    {
        private readonly DateTime _maturityDate;

        public FixedDepositWithdrawable(DateTime maturityDate)
        {
            _maturityDate = maturityDate;
        }

        public decimal Withdraw(decimal balance, decimal amount)
        {

            if (DateTime.Now < _maturityDate)
            {
                throw new Exception(ErrorTexts.Data[ErrorCode.NonMatureWithdrawal]);
            }

            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, New Balance: {balance}");
                return balance;
            }

            throw new Exception(ErrorTexts.Data[ErrorCode.InvalidWithdrawalAmount]);

        }

        public DateTime MaturityDate => _maturityDate;

    }
}
