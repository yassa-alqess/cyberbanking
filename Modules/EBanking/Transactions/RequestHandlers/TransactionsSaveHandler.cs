using Serenity;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.SaveRequest<cyberbanking.EBanking.TransactionsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = cyberbanking.EBanking.TransactionsRow;

namespace cyberbanking.EBanking;

public interface ITransactionsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class TransactionsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITransactionsSaveHandler
{
    public TransactionsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
    protected override void BeforeSave()
    {
        base.BeforeSave();
    }

}