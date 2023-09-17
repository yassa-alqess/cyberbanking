using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace cyberbanking.EBanking.Pages;

[PageAuthorize(typeof(TransactionsRow))]
public class TransactionsPage : Controller
{
    [Route("EBanking/Transactions")]
    public ActionResult Index()
    {
        return this.GridPage("@/EBanking/Transactions/TransactionsPage",
            TransactionsRow.Fields.PageTitle());
    }
}