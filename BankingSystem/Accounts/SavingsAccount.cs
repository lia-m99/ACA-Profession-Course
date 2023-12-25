using BankingSystem.Depositables;
using BankingSystem.Withdrawables;

namespace BankingSystem.Accounts
{
    public class SavingsAccount : Account
    {
        public SavingsAccount() : 
            base(new Depositable(), new Withdrawable())
        {
        }
    }
}
