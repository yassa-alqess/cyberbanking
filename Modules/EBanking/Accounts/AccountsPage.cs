using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace cyberbanking.EBanking.Pages;

[PageAuthorize(typeof(AccountsRow))]
public class AccountsPage : Controller
{
    [Route("EBanking/Accounts")]
    public ActionResult Index()
    {
        return this.GridPage("@/EBanking/Accounts/AccountsPage",
            AccountsRow.Fields.PageTitle());
    }
}