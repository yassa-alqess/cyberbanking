using cyberbanking.EBanking.Accounts;
using FluentMigrator;
using Serenity.Extensions;
using System;

namespace cyberbanking.Migrations.DefaultDB
{
    [Migration(20230917_150000)]
    public class DefaultDB_20230917_150000_SeedAccounts : AutoReversingMigration
    {
        public override void Up()
        {
            // seed dummy accounts
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 10000,
                AccountType = (int)AccountType.Savings,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 4,
            });
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 5000,
                AccountType = (int)AccountType.Checking,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 4,
            });
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 8000,
                AccountType = (int)AccountType.Savings,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 2,
            });
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 8000,
                AccountType = (int)AccountType.Savings,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 3,
            });
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 5000,
                AccountType = (int)AccountType.Checking,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 8,
            });
            Insert.IntoTable("Accounts").Row(new
            {
                Balance = 1000,
                AccountType = (int)AccountType.Savings,
                OpenDate = DateTime.Now,
                IsActive = 1, //suppose that
                CustomerId = 5,
            });
        }

    }
}