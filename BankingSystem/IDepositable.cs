namespace BankingSystem
{
    public interface IDepositable
    {
        decimal Deposit(decimal balance, decimal amount);
    }

}
