using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MyRow = cyberbanking.Administration.UserRow;

namespace cyberbanking.Administration.Endpoints
{
    [Route("Services/Administration/User/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request, [FromServices] IUserSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request, [FromServices] IUserSaveHandler handler)
        {
            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request, [FromServices] IUserDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request, [FromServices] IUserRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, UserListRequest request, [FromServices] IUserListHandler handler)
        {
            return handler.List(connection, request);
        }


        public class GetUserByNameRequest : ServiceRequest
        {
            public string Username { get; set; }
        }

        public class GetUserByNameResponse : ServiceResponse
        {
            public int Id  { get; set; }
        }

        public GetUserByNameResponse GetByUserName(IDbConnection connection, GetUserByNameRequest requset)
        {
            //var request = new RetrieveRequest();
            //requset.EntityId = connection.List<MyRow>().FirstOrDefault(r => r.Username == (string)requset.EntityId).UserId;
            //return handler.Retrieve(connection, requset);
            var user = connection.List<MyRow>().FirstOrDefault(r => r.Username == requset.Username);
            if (user is null)
                throw new System.Exception("user not found");
            return new GetUserByNameResponse { Id = user.UserId.Value };
        }
    }
}
