using cyberbanking.EBanking.Accounts;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking.Forms;

[FormScript("EBanking.Accounts")]
[BasedOnRow(typeof(AccountsRow), CheckNames = true)]
public class AccountsForm
{
    [Hidden]
    public Boolean IsActive { get; set; }

    public decimal Balance { get; set; }


    public AccountType AccountType { get; set; }

    [HideOnInsert]
    public DateTime OpenDate { get; set; }

    [HideOnInsert]
    public int CustomerId { get; set; }
}