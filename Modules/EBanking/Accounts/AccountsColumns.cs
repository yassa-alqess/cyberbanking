using cyberbanking.EBanking.Accounts;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking.Columns;

[ColumnsScript("EBanking.Accounts")]
[BasedOnRow(typeof(AccountsRow), CheckNames = true)]
public class AccountsColumns
{
    [Width(100)]
    public Boolean IsActive { get; set; }

    [EditLink, DisplayName("Db.Shared.RecordId")]
    public int AccountId { get; set; }

    [Width(150), QuickFilter]
    public AccountType AccountType { get; set; }

    [Width(150)]
    public decimal Balance { get; set; }

    [Width(150)]
    public DateTime OpenDate { get; set; }

    [Hidden, QuickFilter] //only shown for admin, and filtiring is also for admin
    public string CustomerUsername { get; set; }
}