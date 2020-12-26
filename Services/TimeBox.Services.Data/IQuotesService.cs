namespace TimeBox.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.Quote;

    public interface IQuotesService
    {
        Task CreateAsync(CreateQuoteInputModel input);

        IEnumerable<QuoteInListViewModel> GetAll();
    }
}
