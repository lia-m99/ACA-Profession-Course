namespace BankingSystem
{
    public interface IAccountTransaction
    {
        decimal Deposit(decimal balance, decimal amount);

        decimal Withdraw(decimal balance, decimal amount);
    }
}
