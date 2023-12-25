using BankingSystem.Depositables;
using BankingSystem.Withdrawables;

namespace BankingSystem.Accounts
{
    public class FixedDepositAccount : Account
    {
        public FixedDepositAccount(DateTime maturityDate) : 
            base(new Depositable(), new FixedDepositWithdrawable(maturityDate))
        {
        }

        public override void DisplayAccountDetails()
        {
            base.DisplayAccountDetails();
            Console.WriteLine($"Maturity Date: {((FixedDepositWithdrawable)_withdrawable!).MaturityDate.ToShortDateString()}");
        }
    }
}
