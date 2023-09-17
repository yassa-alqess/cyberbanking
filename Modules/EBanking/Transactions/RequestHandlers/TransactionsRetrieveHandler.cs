using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<cyberbanking.EBanking.TransactionsRow>;
using MyRow = cyberbanking.EBanking.TransactionsRow;

namespace cyberbanking.EBanking;

public interface ITransactionsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

public class TransactionsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITransactionsRetrieveHandler
{
    public TransactionsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}