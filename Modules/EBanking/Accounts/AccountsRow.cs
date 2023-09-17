using cyberbanking.Administration;
using cyberbanking.EBanking.Accounts;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace cyberbanking.EBanking;

[ConnectionKey("Default"), Module("EBanking"), TableName("Accounts")]
[DisplayName("Account"), InstanceName("Account")]
[ReadPermission(PermissionKeys.Accounts)]
[ModifyPermission(PermissionKeys.Accounts)]
[InsertPermission(PermissionKeys.Accounts)]
[Updatable(false)]
public sealed class AccountsRow : Row<AccountsRow.RowFields>, IIdRow
{
    const string jCustomer = nameof(jCustomer);

    [DisplayName("Account Id"), Identity, IdProperty]
    public int? AccountId
    {
        get => fields.AccountId[this];
        set => fields.AccountId[this] = value;
    }

    [DisplayName("Balance"), NotNull, Size(18), Scale(2)]
    public decimal? Balance
    {
        get => fields.Balance[this];
        set => fields.Balance[this] = value;
    }

    [DisplayName("Type"), NotNull]
    public AccountType? AccountType
    {
        get => fields.AccountType[this];
        set => fields.AccountType[this] = value;
    }

    [DisplayName("Open Date")]
    public DateTime? OpenDate
    {
        get => fields.OpenDate[this];
        set => fields.OpenDate[this] = value;
    }

    [DisplayName("Customer"), ForeignKey("Users", "UserId"), LeftJoin(jCustomer), TextualField(nameof(CustomerUsername))]
    [LookupEditor(typeof(UserRow))]
    public int? CustomerId
    {
        get => fields.CustomerId[this];
        set => fields.CustomerId[this] = value;
    }

    [DisplayName("Customer name"), Expression($"{jCustomer}.[Username]")]
    public string CustomerUsername
    {
        get => fields.CustomerUsername[this];
        set => fields.CustomerUsername[this] = value;
    }
    [DisplayName("Active"),DefaultValue(true)]
    public Boolean? IsActive
    {
        get => fields.IsActive[this];
        set => fields.IsActive[this] = value;
    }   
    public class RowFields : RowFieldsBase
    {
        public Int32Field AccountId;
        public DecimalField Balance;
        public EnumField<AccountType> AccountType;
        public DateTimeField OpenDate;
        public Int32Field CustomerId;

        public StringField CustomerUsername;
        public BooleanField IsActive;
    }
}