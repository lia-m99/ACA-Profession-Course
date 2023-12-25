using BankingSystem;
using BankingSystem.Accounts;
using BankingSystem.Helper;
using CustomInterfaces;

namespace CustomInterfaces
{
    public class CustomTenPersentTransaction : IAccountTransaction
    {
        public decimal Withdraw(decimal balance, decimal amount)
        {
            decimal tenPercent = balance * 0.1m;

            if (amount <= tenPercent)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}, New Balance: {balance}");
                return balance;
            }

            throw new Exception(ErrorTexts.Data[ErrorCode.InvalidWithdrawalAmount]);
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");

            return balance;
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
            Account savingsAccount = new Account(new SavingsAccountTransaction());
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
            Account checkingAccount = new Account(new CheckingAccountTransaction(500));
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
            Account fixedDepositAccount = new Account(new FixedDepositTransaction(maturityDate));
            fixedDepositAccount.Deposit(500);
            fixedDepositAccount.Withdraw(500);
            // Non-Mature Withdrawal.
            fixedDepositAccount.Withdraw(600);
        });
    }

    static void TestShowcasingExtendability()
    {
        TestAccount("Ten Percent Withdrawal Account", () =>
        {
            Account tenPercentAccount = new Account(new CustomTenPersentTransaction());

            tenPercentAccount.Deposit(2000);
            tenPercentAccount.Withdraw(10);
            tenPercentAccount.DisplayAccountDetails();

            tenPercentAccount.Withdraw(500);
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
