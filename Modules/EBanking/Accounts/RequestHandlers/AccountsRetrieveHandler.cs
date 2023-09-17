using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<cyberbanking.EBanking.AccountsRow>;
using MyRow = cyberbanking.EBanking.AccountsRow;

namespace cyberbanking.EBanking;

public interface IAccountsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

public class AccountsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IAccountsRetrieveHandler
{
    public AccountsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}