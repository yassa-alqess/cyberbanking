using Serenity.ComponentModel;
using System.ComponentModel;

namespace cyberbanking.EBanking
{
    [NestedPermissionKeys]
    [DisplayName("EBanking")]
    public class PermissionKeys
    {
        [Description("User, Role Management and Permissions")]
        public const string Security = "Administration:Security";

        [Description("Add & Manage Accounts")]
        public const string Accounts = "EBanking:Accounts";

        [Description("Add & Manage Transactions")]
        public const string Transactions = "EBanking:Transactions";
    }
}
