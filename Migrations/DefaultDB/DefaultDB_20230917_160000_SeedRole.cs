using cyberbanking.EBanking.Accounts;
using FluentMigrator;
using Serenity.Extensions;
using System;

namespace cyberbanking.Migrations.DefaultDB
{
    [Migration(20230917_160000)]
    public class DefaultDB_20230917_160000_SeedRole : Migration
    {
        public override void Up()
        {
            //seed Customer_role permissions
            Insert.IntoTable("RolePermissions").Row(new
            {
                RoleId = 1,
                PermissionKey = "EBanking:Accounts"
            });
            Insert.IntoTable("RolePermissions").Row(new
            {
                RoleId = 1,
                PermissionKey = "EBanking:Transactions"
            });

            // seed role to all users
            Execute.Sql(
              @"INSERT INTO dbo.UserRoles (UserId, RoleId) 
                    SELECT T0.UserId, 1
                    FROM dbo.Users T0
                    WHERE T0.UserId IS NOT NULL AND T0.UserId <> 1");
        }
        public override void Down()
        {
        }
    }
}