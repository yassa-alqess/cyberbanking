using Serenity.Data;
using Serenity;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<cyberbanking.EBanking.TransactionsRow>;
using MyRow = cyberbanking.EBanking.TransactionsRow;
using System.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

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
        if (User.Identity.Name != "admin")
        {

            //getting all accounts of the current user,
            //then getting all transactions of those accounts

            var CurrentUserId = (Int32)User.GetIdentifier().TryParseID();
            var fld = MyRow.Fields;
            var Accounts = Connection.List<AccountsRow>().Where(r => r.CustomerId == CurrentUserId && r.IsActive == true).ToList();
            
             query.Where(
                 fld.SenderAccountId.In(Accounts.Select(r => r.AccountId)) ||
                 fld.ReceiverAccountId.In(Accounts.Select(r => r.AccountId)));
            

              /*
                var acc = AccountsRow.Fields.As("acc");
                query.Where(Criteria.Exists(
                query.SubQuery()
                    .From(acc)
                    .Select("1")
                    .Where(
                        acc.CustomerId == CurrentUserId &&
                        (fld.SenderAccountId.In(Accounts.Select(r => r.AccountId)) ||
                        fld.ReceiverAccountId.In(Accounts.Select(r => r.AccountId))))
                    .ToString()));
              */
        }
    }
}