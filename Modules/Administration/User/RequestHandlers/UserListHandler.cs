using Serenity.Services;
using MyRequest = cyberbanking.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<cyberbanking.Administration.UserRow>;
using MyRow = cyberbanking.Administration.UserRow;

namespace cyberbanking.Administration
{
    public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
    {
        public UserListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}