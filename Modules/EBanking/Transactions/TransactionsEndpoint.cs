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
            //var accounts = uow.Connection.List<AccountsRow>()
            //                                    .Where(r =>  r.CustomerId == currentUserId &&
            //                                                && r.AccountType == request.Entity
            //                                                 r.IsActive == true);
            //if (accounts is null || accounts.Count() == 0)
                //throw new Exception("Error processing current transactions, maybe user has no active account");
            var senderId = request.Entity.SenderAccountId;
            var receiverId = request.Entity.ReceiverAccountId;
            AccountsRow sender = null;
            AccountsRow receiver = null;
            if (request.Entity.SenderAccountId is null)
                senderId = currentUserId;
            
            sender = uow.Connection.List<AccountsRow>().FirstOrDefault(r =>
                                                                       r.CustomerId == senderId &&
                                                                       r.AccountType == request.Entity.SenderAccountType &&
                                                                       r.IsActive == true);

             
             if (transactionType != TransactionType.Deposit && sender.Balance < Amount) //check for balance.
                   throw new Exception("Insufficient Balance");

             //if (sender == null)
             //   throw new Exception("Error processing current transactions, maybe user has no active account");

            if (request.Entity.ReceiverAccountId is null)
            {
                receiverId = currentUserId;
                request.Entity.ReceiverAccountType = request.Entity.SenderAccountType; //same if no receiver account type provided
                if (transactionType == TransactionType.Transfer)
                    throw new Exception("Error processing current transactions, maybe user has no active account");
            }
            receiver = uow.Connection.List<AccountsRow>().FirstOrDefault(r =>
                                                                            r.CustomerId == receiverId &&
                                                                            r.AccountType == request.Entity.ReceiverAccountType &&
                                                                            r.IsActive == true);


            request.Entity.SenderAccountId = sender.AccountId.Value;
            request.Entity.ReceiverAccountId = receiver.AccountId.Value;
            request.Entity.TransactionDate = DateTime.Now;

            //var SenderAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == senderId);
            //var ReceiverAccount = uow.Connection.List<AccountsRow>().FirstOrDefault(a => a.AccountId == receiverId);
            if (sender is null || receiver is null)
                throw new Exception("can't process that transfer as either sender or receiver may not has account");
            
            switch (transactionType)
            {
                case TransactionType.Deposit:
                    HandleTransactionType(new DepositeHandler(), sender, receiver, Amount);
                    uow.Connection.UpdateById(sender);
                    break;
                case TransactionType.Withdrawal:
                    if (Amount > sender.Balance)
                        throw new Exception("Insufficient Balance");
                    HandleTransactionType(new WithdrawalHandler(), sender, receiver, Amount);
                    uow.Connection.UpdateById(sender);
                    break;
                case TransactionType.Transfer:
                    if (Amount > sender.Balance)
                        throw new Exception("Insufficient Balance");
                    HandleTransactionType(new TransferHandler(), sender, receiver, Amount);
                    uow.Connection.UpdateById(sender);
                    uow.Connection.UpdateById(receiver);
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