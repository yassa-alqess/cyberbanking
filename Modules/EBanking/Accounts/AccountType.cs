using Serenity.ComponentModel;
using System.ComponentModel;

namespace cyberbanking.EBanking.Accounts
{
    [EnumKey("EBanking.AccountType")]
    public enum AccountType
    {
        [Description("Savings")]
        Savings = 1,
        [Description("Checking")]
        Checking = 2,
        [Description("Credit Card")]
        CreditCard = 3,
        [Description("Loan")]
        Loan = 4,

    }
}
