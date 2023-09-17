using Serenity.Data;
using Serenity;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<cyberbanking.EBanking.TransactionsRow>;
using MyRow = cyberbanking.EBanking.TransactionsRow;

namespace cyberbanking.EBanking;

public interface ITransactionsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

public class TransactionsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITransactionsListHandler
{
    public TransactionsListHandler(IRequestContext context)
            : base(context)
    {
    }
    protected override void ApplyFilters(SqlQuery query)
    {
        base.ApplyFilters(query);
        //if (Permissions.HasPermission(PermissionKeys.Security) == false)
        if (User.Identity.Name != "admin")
        {
            var CurrentUserId = (Int32)User.GetIdentifier().TryParseID();
            query.Where(MyRow.Fields.SenderAccountId == AccountsRow.Fields.AccountId);
        }
    }

}