using Serenity.ComponentModel;
using System.ComponentModel;

namespace cyberbanking.EBanking.Transactions
{
    [EnumKey("EBanking.TransactionType")]
    public enum TransactionType
    {
        [Description("Deposit")]
        Deposit = 1,
        [Description("Withdrawal")]
        Withdrawal = 2,
        [Description("Transfer")]
        Transfer = 3,
    }
}
