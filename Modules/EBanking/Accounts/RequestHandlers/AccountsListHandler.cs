using Serenity.Data;
using Serenity;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<cyberbanking.EBanking.AccountsRow>;
using MyRow = cyberbanking.EBanking.AccountsRow;

namespace cyberbanking.EBanking;

public interface IAccountsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

public class AccountsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IAccountsListHandler
{
    public AccountsListHandler(IRequestContext context)
            : base(context)
    {
    }
    protected override void ApplyFilters(SqlQuery query)
    {
        base.ApplyFilters(query);
        if (User.Identity.Name != "admin")
        {
            var CurrentUserId = (Int32)User.GetIdentifier().TryParseID();
            query.Where(MyRow.Fields.CustomerId == CurrentUserId);
        }
    }
}