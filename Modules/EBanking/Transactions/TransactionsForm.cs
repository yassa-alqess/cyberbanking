using cyberbanking.EBanking.Accounts;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking.Forms;

[FormScript("EBanking.Transactions")]
[BasedOnRow(typeof(TransactionsRow), CheckNames = true)]
[ReadOnly(true)]
public class TransactionsForm
{
    public decimal Amount { get; set; }

    public int TransactionType { get; set; }

    [Hidden]
    public DateTime TransactionDate { get; set; }

    [TextAreaEditor(Rows = 5)]
    public string Description { get; set; }

    [HideOnInsert, HideOnUpdate]
    public int SenderAccountId { get; set; }

    public AccountType SenderAccountType { get; set; }

    public int ReceiverAccountId { get; set; }
    public AccountType ReceiverAccountType { get; set; }
}