using Azure.Core;
using cyberbanking.Administration;
using cyberbanking.EBanking.Accounts;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using MyRow = cyberbanking.EBanking.AccountsRow;

namespace cyberbanking.EBanking.Endpoints;

[Route("Services/EBanking/Accounts/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class AccountsEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAccountsSaveHandler handler)
    {
        var accountType = request.Entity.AccountType;
        if (uow.Connection.List<MyRow>().Any(r => r.AccountType == accountType))
            throw new Exception($"already has Account {accountType}");
        return handler.Create(uow, request);
    }
/*
    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IAccountsSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IAccountsDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }
*/
    [HttpPost]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IAccountsRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] IAccountsListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, JsonRequest]
    public SaveResponse DeactivateList(IUnitOfWork uow, BulkListRequest request, [FromServices] IAccountsSaveHandler handler)
    {

        foreach (var accountId in request.AccountIds)
        {
            var row = uow.Connection.List<MyRow>().FirstOrDefault(w => w.AccountId == accountId.TryParseID32());
            if (row != null && row.IsActive == true)
            {
                row.IsActive = false;
                uow.Connection.UpdateById(row);
                //handler.Update(uow, new SaveRequest<MyRow>{ EntityId = row.AccountId });
            }
        }
        return new SaveResponse();
    }

    [HttpPost, JsonRequest]
    public SaveResponse ActivateList(IUnitOfWork uow, BulkListRequest request, [FromServices] IAccountsSaveHandler handler)
    {

        foreach (var accountId in request.AccountIds)
        {
            var row = uow.Connection.List<MyRow>().FirstOrDefault(w => w.AccountId == accountId.TryParseID32());
            if (row != null && row.IsActive == false)
            {
                row.IsActive = true;
                uow.Connection.UpdateById(row);
                //handler.Update(uow, new SaveRequest<MyRow>{ EntityId = row.AccountId });
            }
        }
        return new SaveResponse();
    }


    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IAccountsListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.AccountsColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "AccountsList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
    
    [HttpPost, AuthorizeList(typeof(MyRow))]
    public IEnumerable<MyRow> ListAll(IDbConnection connection)
    {
            return connection.List<MyRow>();
            //return handler.List(connection, request);
    }

    //[HttpPost, AuthorizeList(typeof(MyRow))]
    //public ListResponse<MyRow> ListById(IDbConnection connection, ListRequest request, [FromServices] IAccountsListHandler handler)
    //{
    //        return connection.List<MyRow>().Where( r => r.CustomerId == (Int32)EntityId) as ListResponse<MyRow>;
    //    return handler.List(connection, request);
    //}


    public class ListByUsernameRequest : ServiceRequest
    {
        public string Username { get; set; }
    }

    public class ListByUsernameResponse : ServiceResponse
    {
        public MyRow[] Entities { get; set; }
    }

    public ListByUsernameResponse ListByUsername(IDbConnection connection, ListByUsernameRequest requset)
    {
        //var request = new RetrieveRequest();
        //requset.EntityId = connection.List<MyRow>().FirstOrDefault(r => r.Username == (string)requset.EntityId).UserId;
        //return handler.Retrieve(connection, requset);
        var userr = connection.List<UserRow>().FirstOrDefault(r => r.Username == requset.Username);
        if (userr is null)
            throw new System.Exception("user not found");
        var accounts = connection.List<MyRow>().Where(r => r.CustomerId == userr.UserId).ToArray();
        return new ListByUsernameResponse { Entities = accounts as MyRow[]  };
    }

    public class ListByIdRequest : ServiceRequest
    {
        public int Id { get; set; }
    }

    public class ListByIdResponse : ServiceResponse
    {
        public MyRow[] Entities { get; set; }
    }

    public ListByIdResponse ListById(IDbConnection connection, ListByIdRequest requset)
    {
        //var request = new RetrieveRequest();
        //requset.EntityId = connection.List<MyRow>().FirstOrDefault(r => r.Username == (string)requset.EntityId).UserId;
        //return handler.Retrieve(connection, requset);
        var userr = connection.List<UserRow>().FirstOrDefault(r => r.UserId == (Int32)requset.Id);
        //if (userr is null)
        //    throw new System.Exception("user not found");
        var accounts = connection.List<MyRow>().Where(r => r.CustomerId == userr.UserId).ToArray();
        return new ListByIdResponse { Entities = accounts as MyRow[] };
    }

}