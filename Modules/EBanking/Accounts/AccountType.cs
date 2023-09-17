using Serenity.ComponentModel;
using System.ComponentModel;

namespace cyberbanking.EBanking.Accounts
{
    [EnumKey("EBanking.AccountType")]
    public enum AccountType
    {
        [Description("Savings")]
        Savings,
        [Description("Checking")]
        Checking,
        [Description("Credit Card")]
        CreditCard,
        [Description("Loan")]
        Loan,

    }
}
