namespace TimeBox.Services.Data
{
    using System.Threading.Tasks;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.Quote;

    public class QuotesService : IQuotesService
    {
        private readonly IDeletableEntityRepository<Quote> quotesRepository;

        public QuotesService(IDeletableEntityRepository<Quote> quotesRepository)
        {
            this.quotesRepository = quotesRepository;
        }

        public async Task CreateAsync(CreateQuoteInputModel input)
        {
            var quote = new Quote
            {
                QuoteText = input.QuoteText,

                QuoteAuthor = input.QuoteAuthor,
            };

            await this.quotesRepository.AddAsync(quote);
            await this.quotesRepository.SaveChangesAsync();
        }
    }
}
