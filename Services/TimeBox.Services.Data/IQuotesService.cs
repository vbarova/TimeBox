namespace TimeBox.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.Quote;

    public interface IQuotesService
    {
        bool Exists(int id);

        Task CreateAsync(CreateQuoteInputModel input);

        IEnumerable<QuoteInListViewModel> GetAll();

        Task DeleteAsync(int id);
    }
}
