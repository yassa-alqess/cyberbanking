using Serenity.ComponentModel;
using System.ComponentModel;

namespace cyberbanking.EBanking.Transactions
{
    [EnumKey("EBanking.TransactionType")]
    public enum TransactionType
    {
        [Description("Deposit")]
        Deposit,
        [Description("Withdrawal")]
        Withdrawal,
        [Description("Transfer")]
        Transfer,
    }
}
