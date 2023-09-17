using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking.Columns;

[ColumnsScript("EBanking.Transactions")]
[BasedOnRow(typeof(TransactionsRow), CheckNames = true)]
public class TransactionsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId")]
    public int TransactionId { get; set; }


    [Width(150), QuickFilter]
    public int TransactionType { get; set; }

    [Width(150)]
    public decimal Amount { get; set; }

    [QuickFilter] //only shown for admin
    [TransactionListFormatter]
    public int SenderAccountId { get; set; }

    [Width(150), QuickFilter]
    [TransactionListFormatter]

    public int ReceiverAccountId { get; set; }

    [Width(150)]
    public DateTime TransactionDate { get; set; }

    [EditLink, Width(250)]
    public string Description { get; set; }

}