namespace BankingSystem.Helper
{
    public class ErrorTexts
    {
        public static readonly IReadOnlyDictionary<ErrorCode, string> Data = new Dictionary<ErrorCode, string>
        {
            [ErrorCode.InvalidWithdrawalAmount] = "Invalid withdrawal amount or insufficient funds for withdrawal.",
            [ErrorCode.NonMatureWithdrawal] = "Withdrawal not allowed until maturity date.",
            [ErrorCode.ExceedOverdraftLimit] = "Withdrawal exceeds overdraft limit."
        };
    }
}
