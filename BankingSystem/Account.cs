namespace BankingSystem
{
    public class Account : IAccount
    {
        private decimal _balance;

        private readonly IAccountTransaction _transaction;

        public Account(IAccountTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Deposit(decimal amount)
        {
            _balance = _transaction.Deposit(_balance, amount);
        }

        public void Withdraw(decimal amount)
        {
            _balance = _transaction.Withdraw(_balance, amount);
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void DisplayAccountDetails()
        {
            Console.WriteLine($"Balance: {_balance}");
        }
    }
}
