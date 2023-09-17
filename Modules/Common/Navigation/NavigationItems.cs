using Serenity.Navigation;
using static cyberbanking.Texts.Db;
using EBankingPages = cyberbanking.EBanking.Pages;
using AdministrationPages = cyberbanking.Administration.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "fa-tachometer")]


[assembly: NavigationMenu(2000, "Administration", icon: "fa-wrench")]
[assembly: NavigationLink(2100, "Administration/Languages", typeof(AdministrationPages.LanguageController), icon: "fa-comments")]
[assembly: NavigationLink(2200, "Administration/Translations", typeof(AdministrationPages.TranslationController), icon: "fa-comment-o")]
[assembly: NavigationLink(2300, "Administration/Roles", typeof(AdministrationPages.RoleController), icon: "fa-lock")]
[assembly: NavigationLink(2400, "Administration/User Management", typeof(AdministrationPages.UserController), icon: "fa-users")]

[assembly: NavigationMenu(3000, "EBanking", icon: "fa fa-money")] //fa fa-university
[assembly: NavigationLink(3100, "EBanking/Accounts", typeof(EBankingPages.AccountsPage), icon: "fa fa-credit-card-alt")]
[assembly: NavigationLink(3200, "EBanking/Transactions", typeof(EBankingPages.TransactionsPage), icon: "fa fa-handshake-o")]
