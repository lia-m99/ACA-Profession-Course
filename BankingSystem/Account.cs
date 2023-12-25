namespace BankingSystem
{
    public class Account : IAccount
    {
        private decimal _balance;

        protected readonly IDepositable _depositable;
        protected readonly IWithdrawable _withdrawable;

        public Account(IDepositable depositable, IWithdrawable withdrawable)
        {
            _depositable = depositable;
            _withdrawable = withdrawable;
        }

        public void Deposit(decimal amount)
        {
            _balance = _depositable.Deposit(_balance, amount);
        }

        public void Withdraw(decimal amount)
        {
            _balance = _withdrawable.Withdraw(_balance, amount);
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
