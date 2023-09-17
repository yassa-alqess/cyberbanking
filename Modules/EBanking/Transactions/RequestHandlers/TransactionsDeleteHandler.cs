using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = cyberbanking.EBanking.TransactionsRow;

namespace cyberbanking.EBanking;

public interface ITransactionsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

public class TransactionsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ITransactionsDeleteHandler
{
    public TransactionsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}