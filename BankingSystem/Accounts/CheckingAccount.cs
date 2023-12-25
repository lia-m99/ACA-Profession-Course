using BankingSystem.Depositables;
using BankingSystem.Withdrawables;

namespace BankingSystem.Accounts
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(decimal overdraftLimit) : 
            base(new Depositable(), new OverdraftWithdrawable(overdraftLimit))
        {
        }

        public override void DisplayAccountDetails()
        {
            base.DisplayAccountDetails();
            Console.WriteLine($"Overdraf tLimit: {((OverdraftWithdrawable)_withdrawable!).OverdraftLimit}");
        }
    }
}
