using cyberbanking.Administration;
using cyberbanking.EBanking.Transactions;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking;

[ConnectionKey("Default"), Module("EBanking"), TableName("Transactions")]
[DisplayName("Transaction History"), InstanceName("Transaction")]
[ReadPermission(PermissionKeys.Transactions)]
[ModifyPermission(PermissionKeys.Transactions)]
[InsertPermission(PermissionKeys.Transactions)]
[Updatable(false)]
public sealed class TransactionsRow : Row<TransactionsRow.RowFields>, IIdRow, INameRow
{
    const string jSenderAccount = nameof(jSenderAccount);
    const string jReceiverAccount = nameof(jReceiverAccount);

    [DisplayName("Transaction Id"), Identity, IdProperty]
    public int? TransactionId
    {
        get => fields.TransactionId[this];
        set => fields.TransactionId[this] = value;
    }

    [DisplayName("Amount"), Size(18), Scale(2), NotNull, QuickSearch(SearchType.Equals, numericOnly: 1)]
    public decimal? Amount
    {
        get => fields.Amount[this];
        set => fields.Amount[this] = value;
    }

    [DisplayName("Type"), NotNull]
    public TransactionType? TransactionType
    {
        get => fields.TransactionType[this];
        set => fields.TransactionType[this] = value;
    }

    [DisplayName("Date")]
    public DateTime? TransactionDate
    {
        get => fields.TransactionDate[this];
        set => fields.TransactionDate[this] = value;
    }

    [DisplayName("Description"), Size(200), QuickSearch, NameProperty]
    public string Description
    {
        get => fields.Description[this];
        set => fields.Description[this] = value;
    }

    [DisplayName("From"), ForeignKey("Accounts", "AccountId"), LeftJoin(jSenderAccount)]
    [LookupEditor(typeof(UserRow))]

    public int? SenderAccountId
    {
        get => fields.SenderAccountId[this];
        set => fields.SenderAccountId[this] = value;
    }

    /*  
      [DisplayName("From"), NotMapped]
      public string SenderUsername
      {
          get => fields.SenderUsername[this];
          set => fields.SenderUsername[this] = value;
      }

      */
    [DisplayName("To"), ForeignKey("Accounts", "AccountId"), LeftJoin(jReceiverAccount)]
    [LookupEditor(typeof(UserRow))]

    public int? ReceiverAccountId
    {
        get => fields.ReceiverAccountId[this];
        set => fields.ReceiverAccountId[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field TransactionId;
        public DecimalField Amount;
        public EnumField<TransactionType> TransactionType;
        public DateTimeField TransactionDate;
        public StringField Description;
        public Int32Field SenderAccountId;
        public Int32Field ReceiverAccountId;
    }
}