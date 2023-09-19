using cyberbanking.EBanking.Accounts;
using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
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
    public SaveResponse DeactivateList(IUnitOfWork uow, DeactivateListRequest request, [FromServices] IAccountsSaveHandler handler)
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
}