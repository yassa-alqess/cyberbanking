using cyberbanking.EBanking.Accounts;
using FluentMigrator;
using Serenity.Extensions;
using System;

namespace cyberbanking.Migrations.DefaultDB
{
    [Migration(20230917_142300)]
    public class DefaultDB_20230917_142300_SeedUsers : AutoReversingMigration
    {
        public override void Up()
        {
            
            // seed dummy users/customers
            Insert.IntoTable("Users").Row(new
            {
                Username = "mariam",
                DisplayName = "mariam",
                Email = "mariam@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "sarah",
                DisplayName = "sarah",
                Email = "sarah@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "ali",
                DisplayName = "ali",
                Email = "ali@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "mark",
                DisplayName = "mark",
                Email = "mark@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "ahmed",
                DisplayName = "ahmed",
                Email = "ahmed@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "semo",
                DisplayName = "semo",
                Email = "semo@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "kareem",
                DisplayName = "kareem",
                Email = "kareem@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "george",
                DisplayName = "george",
                Email = "george@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });
            Insert.IntoTable("Users").Row(new
            {
                Username = "tomas",
                DisplayName = "tomas",
                Email = "tomas@domain" + Serenity.IO.TemporaryFileHelper.RandomFileCode() + ".com",
                Source = "site",
                PasswordHash = "rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ",
                PasswordSalt = "hJf_F",
                InsertDate = DateTime.Now,
                InsertUserId = 1,
                IsActive = 1
            });

            //seed Customer role
            Insert.IntoTable("Roles").Row(new
            {
                RoleName = "Customer"
            });

        }
    }
}