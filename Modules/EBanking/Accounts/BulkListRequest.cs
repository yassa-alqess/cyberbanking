using Serenity.Services;
using System.Collections.Generic;

namespace cyberbanking.EBanking.Accounts
{
    public class BulkListRequest : ServiceRequest
    {
        public List<string> AccountIds { get; set; }
    }
}