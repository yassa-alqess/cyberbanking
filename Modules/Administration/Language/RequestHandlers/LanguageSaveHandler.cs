using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<cyberbanking.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = cyberbanking.Administration.LanguageRow;


namespace cyberbanking.Administration
{
    public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
    public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
    {
        public LanguageSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}