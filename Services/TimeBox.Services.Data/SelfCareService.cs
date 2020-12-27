namespace TimeBox.Services.Data
{
    using System;
    using System.Linq;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Services.Mapping;
    using TimeBox.Web.ViewModels.SelfCare;

    public class SelfCareService : ISelfCareService
    {
        private readonly IDeletableEntityRepository<Quote> quotesRepository;

        public SelfCareService(IDeletableEntityRepository<Quote> quotesRepository)
        {
            this.quotesRepository = quotesRepository;
        }

        public RandomQuoteInSelfCareViewModel GetRandomQuote()
        {
            var randomQuote = this.quotesRepository
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new RandomQuoteInSelfCareViewModel
                {
                    QuoteText = x.QuoteText,
                    QuoteAuthor = x.QuoteAuthor,
                })
                .ToList().FirstOrDefault();

            return randomQuote;

        }
    }
}
