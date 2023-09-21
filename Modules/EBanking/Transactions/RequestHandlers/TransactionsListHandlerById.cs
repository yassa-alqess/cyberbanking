//using Serenity.Data;
//using Serenity;
//using Serenity.Services;
//using System;
//using MyRequest = Serenity.Services.ListRequest;
//using MyResponse = Serenity.Services.ListResponse<cyberbanking.EBanking.TransactionsRow>;
//using MyRow = cyberbanking.EBanking.TransactionsRow;
//using System.Linq;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

//namespace cyberbanking.EBanking;

//public interface ITransactionsListHandlerById : IListHandler<MyRow, MyRequest, MyResponse> {}

//public class TransactionsListHandlerById : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITransactionsListHandlerById
//{
//    public TransactionsListHandlerById(IRequestContext context)
//            : base(context)
//    {
//    }
//    protected override void ApplyFilters(SqlQuery query)
//    {
//        base.ApplyFilters(query);

//    }
//}