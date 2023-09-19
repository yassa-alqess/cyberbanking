using cyberbanking.EBanking.Accounts;
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
            var currentUserId = (Int32)User.GetIdentifier().TryParseID();
            var Amount = request.Entity.Amount;
            var transactionType = request.Entity.TransactionType;
            var savingAccounts = uow.Connection.List<AccountsRow>()
                                                .Where(r =>  r.CustomerId == currentUserId &&
                                                             r.IsActive == true &&
                                                             r.AccountType == AccountType.Savings);
            if (savingAccounts is null)
                throw new Exception("Error processing current transactions, maybe user has no active account");
            var senderId = request.Entity.SenderAccountId;
            var receiverId = request.Entity.ReceiverAccountId;
            if (request.Entity.SenderAccountId is null)
            {
                senderId = savingAccounts.FirstOrDefault().AccountId.Value;
                if (transactionType != TransactionType.Deposit) //only withdraw from savings accounts.
                     senderId = savingAccounts.FirstOrDefault(r => r.Balance > Amount).AccountId.Value;
            }  
            if (request.Entity.ReceiverAccountId is null)
                receiverId = savingAccounts.FirstOrDefault().AccountId.Value;

            request.Entity.SenderAccountId = senderId;
            request.Entity.ReceiverAccountId = receiverId;
            request.Entity.TransactionDate = DateTime.Now;

            var SenderAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == senderId);
            var ReceiverAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == receiverId);
            if (SenderAccount is null || ReceiverAccount is null)
                throw new Exception("can't process that transfer as either sender or receiver may not has account");
            
            switch (transactionType)
            {
                case TransactionType.Deposit:
                    HandleTransactionType(new DepositeHandler(), SenderAccount, ReceiverAccount, Amount);
                    uow.Connection.UpdateById(SenderAccount);
                    break;
                case TransactionType.Withdrawal:
                    if (Amount > SenderAccount.Balance)
                        throw new Exception("Insufficient Balance");
                    HandleTransactionType(new WithdrawalHandler(), SenderAccount, ReceiverAccount, Amount);
                    uow.Connection.UpdateById(SenderAccount);
                    break;
                case TransactionType.Transfer:
                    if (Amount > SenderAccount.Balance)
                        throw new Exception("Insufficient Balance");
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