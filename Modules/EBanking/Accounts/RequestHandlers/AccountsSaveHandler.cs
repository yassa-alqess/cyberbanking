using Serenity;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.SaveRequest<cyberbanking.EBanking.AccountsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = cyberbanking.EBanking.AccountsRow;

namespace cyberbanking.EBanking;

public interface IAccountsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

public class AccountsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IAccountsSaveHandler
{
    public AccountsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
    protected override void BeforeSave()
    {
        base.BeforeSave();
        if (Row.CustomerId == null)
            Row.CustomerId = (Int32)User.GetIdentifier().TryParseID();
        Row.OpenDate = (DateTime.Now);
    }
}