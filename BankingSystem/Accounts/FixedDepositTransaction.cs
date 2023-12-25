using BankingSystem.Helper;

namespace BankingSystem.Accounts
{
    internal class FixedDepositTransaction : IAccountTransaction
    {
        private readonly DateTime _maturityDate;

        public FixedDepositTransaction(DateTime maturityDate)
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

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");

            return balance;
        }

        public DateTime MaturityDate => _maturityDate;
    }
}
