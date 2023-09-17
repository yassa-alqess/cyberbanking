using FluentMigrator;
using Serenity.Extensions;

namespace cyberbanking.Migrations.DefaultDB
{
    [Migration(20230916_193000)]
    public class DefaultDB_20230916_193000_Transactions : AutoReversingMigration
    {
        public override void Up()
        {
            //Account Table
            Create.Table("Accounts")
               .WithColumn("AccountId").AsInt32().Identity()
                    .PrimaryKey().NotNullable()
               .WithColumn("Balance").AsDecimal().Nullable()
               .WithColumn("AccountType").AsInt32().NotNullable()
               .WithColumn("OpenDate").AsDateTime().NotNullable()
               .WithColumn("IsActive").AsBoolean().NotNullable()
               .WithColumn("CustomerId").AsInt32().NotNullable()
                   .ForeignKey("FK_AccountCustomerId", "Users", "UserId");

            //Customer-Account Table
           /* 
               Create.Table("CustomerAccount")
                 .WithColumn("CustomerAccountId").AsInt32().Identity()
                     .PrimaryKey().NotNullable()
                 .WithColumn("CustomerId").AsInt32().NotNullable()
                     .ForeignKey("FK_CustomerId", "Users", "UserId")
                 .WithColumn("AccountId").AsInt32().NotNullable()
                     .ForeignKey("FK_AccountId", "Accounts", "AccountId");
            */


            //Transaction Table
            Create.Table("Transactions")
                .WithColumn("TransactionId").AsInt32().Identity()
                    .PrimaryKey().NotNullable()
                .WithColumn("Amount").AsDecimal().NotNullable()
                .WithColumn("TransactionType").AsInt32().NotNullable()
                .WithColumn("TransactionDate").AsDateTime().NotNullable()
                .WithColumn("Description").AsString(200).Nullable()
                .WithColumn("SenderAccountId").AsInt32().NotNullable()
                    .ForeignKey("FK_SenderAccountId", "Accounts", "AccountId")
                .WithColumn("ReceiverAccountId").AsInt32().NotNullable()
                    .ForeignKey("FK_ReceiverAccountId", "Accounts", "AccountId");
        }

    }
}