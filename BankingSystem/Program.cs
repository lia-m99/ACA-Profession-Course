using BankingSystem.Accounts;
using BankingSystem.Depositables;
using BankingSystem.Interfaces;
using BankingSystem.Withdrawables;

namespace BankingSystem.Interfaces
{
    public interface IInterestBearing
    {
        decimal CalculateInterest();
    }
}

namespace BankingSystem.Accounts
{
    public class BasicInterest : IInterestBearing
    {
        public decimal CalculateInterest()
        {
            return 0.02M; // 2% interest rate
        }
    }

    public class HighInterestSavingsAccount : Account
    {
        private readonly IInterestBearing _interestBearing;

        public HighInterestSavingsAccount(IDepositable depositable, IWithdrawable withdrawable, IInterestBearing interestBearing)
            : base(depositable, withdrawable)
        {
            _interestBearing = interestBearing;
        }

        public override void DisplayAccountDetails()
        {
            base.DisplayAccountDetails();
            Console.WriteLine($"Interest Earned: {_interestBearing.CalculateInterest()}");
        }
    }
}

class Program
{
    static void Main()
    {
        TestSavingsAccount();
        TestCheckingAccount();
        TestFixedDepositAccount();
        TestShowcasingExtendability();
    }

    static void TestSavingsAccount()
    {
        TestAccount("Savings Account", () =>
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.Deposit(1000);
            savingsAccount.Withdraw(500);
            // Insufficient funds.
            savingsAccount.Withdraw(600);
        });
    }

    static void TestCheckingAccount()
    {
        TestAccount("Checking Account", () =>
        {
            CheckingAccount checkingAccount = new CheckingAccount(500);
            checkingAccount.Deposit(500);
            checkingAccount.Withdraw(500); // 0 on the balance.
            // Overdraft Limit Exceeded.
            checkingAccount.Withdraw(600);
        });
    }

    static void TestFixedDepositAccount()
    {
        TestAccount("Fixed Deposit Account", () =>
        {
            DateTime maturityDate = DateTime.Now.AddYears(1);
            FixedDepositAccount fixedDepositAccount = new FixedDepositAccount(maturityDate);
            fixedDepositAccount.Deposit(500);
            fixedDepositAccount.Withdraw(500);
            // Non-Mature Withdrawal.
            fixedDepositAccount.Withdraw(600);
        });
    }

    static void TestShowcasingExtendability()
    {
        TestAccount("High-Interest Savings Account", () =>
        {
            HighInterestSavingsAccount highInterestSavingsAccount = new HighInterestSavingsAccount(
                new Depositable(), new Withdrawable(), new BasicInterest());

            highInterestSavingsAccount.Deposit(2000);
            highInterestSavingsAccount.Withdraw(500);

            highInterestSavingsAccount.DisplayAccountDetails();
        });
    }

    static void TestAccount(string accountType, Action testAction)
    {
        Console.WriteLine($"Testing {accountType}:");

        try
        {
            testAction.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in {accountType} test: {ex.Message}");
        }

        Console.WriteLine();
    }
}
