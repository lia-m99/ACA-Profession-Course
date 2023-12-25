namespace BankingSystem.Depositables
{
    public class Depositable : IDepositable
    {
        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");

            return balance;
        }
    }
}
