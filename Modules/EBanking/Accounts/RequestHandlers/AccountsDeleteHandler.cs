using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = cyberbanking.EBanking.AccountsRow;

namespace cyberbanking.EBanking;

public interface IAccountsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

public class AccountsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IAccountsDeleteHandler
{
    public AccountsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}