namespace BankingSystem
{
    public interface IWithdrawable
    {
        decimal Withdraw(decimal balance, decimal amount);
    }
}
