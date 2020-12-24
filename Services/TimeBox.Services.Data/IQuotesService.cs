namespace TimeBox.Services.Data
{
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.Quote;

    public interface IQuotesService
    {
        Task CreateAsync(CreateQuoteInputModel input);
    }
}
