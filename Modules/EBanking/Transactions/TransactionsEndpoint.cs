using cyberbanking.EBanking.Transactions;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Transactions;
using MyRow = cyberbanking.EBanking.TransactionsRow;

namespace cyberbanking.EBanking.Endpoints;

[Route("Services/EBanking/Transactions/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class TransactionsEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ITransactionsSaveHandler handler)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            //connection.Open();  //better leave dapper handle those stuff
            var senderId = request.Entity.SenderAccountId;
            var receiverId = request.Entity.ReceiverAccountId;
            if (senderId == null)
                request.Entity.SenderAccountId = senderId = (Int32)User.GetIdentifier().TryParseID();
            if (receiverId == null)
                request.Entity.ReceiverAccountId = receiverId = (Int32)User.GetIdentifier().TryParseID();

            request.Entity.TransactionDate = DateTime.Now;


            //for the demo, I'm fetching the first account I encounter
            //maybe later I will utilize AccountType to add more features/logic to my app
            var SenderAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == senderId);
            var ReceiverAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == receiverId);
            var Amount = request.Entity.Amount;
            var transactionType = request.Entity.TransactionType;
            switch (transactionType)
            {
                case TransactionType.Deposit:
                     //SenderAccount.Balance += Amount;
                    HandleTransactionType(new DepositeHandler(), SenderAccount, ReceiverAccount, Amount);
                    uow.Connection.UpdateById(SenderAccount);
                    break;
                case TransactionType.Withdrawal:
                    if (Amount > SenderAccount.Balance)
                        throw new Exception("Insufficient Balance");
                    //SenderAccount.Balance -= Amount;
                    HandleTransactionType(new WithdrawalHandler(), SenderAccount, ReceiverAccount, Amount);
                    uow.Connection.UpdateById(SenderAccount);
                    break;
                case TransactionType.Transfer:
                    if (Amount > SenderAccount.Balance)
                        throw new Exception("Insufficient Balance");
                    //SenderAccount.Balance -= Amount;
                    //ReceiverAccount.Balance += Amount;
                    HandleTransactionType(new TransferHandler(), SenderAccount, ReceiverAccount, Amount);
                    uow.Connection.UpdateById(SenderAccount);
                    uow.Connection.UpdateById(ReceiverAccount);
                    break;
                default:
                    break;
            }
            //I know there is a Desgin issue above here,
            //but I don't have enough for refactorting right now, maybe later.


            //better leave dapper handle those stuff
            //connection.Dispose();
            //connection.Close();
            scope.Complete();
        }
        return handler.Create(uow, request);
    }
    private static void HandleTransactionType(ITransactionTypeHandler handler, AccountsRow sender, AccountsRow receiver, decimal? amount)
    {

        handler.HandleTransactionType(sender, receiver, amount);
    }

    /*
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ITransactionsSaveHandler handler)
        {
            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] ITransactionsDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }
    */

    [HttpPost]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ITransactionsRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ITransactionsListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ITransactionsListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.TransactionsColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "TransactionsList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
}