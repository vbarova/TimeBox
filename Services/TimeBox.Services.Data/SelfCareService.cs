namespace TimeBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Services.Mapping;
    using TimeBox.Web.ViewModels.PlannedTask;
    using TimeBox.Web.ViewModels.SelfCare;

    public class SelfCareService : ISelfCareService
    {
        private readonly IDeletableEntityRepository<Quote> quotesRepository;
        private readonly IDeletableEntityRepository<PlannedTask> plannedTaskRepository;

        public SelfCareService(
            IDeletableEntityRepository<Quote> quotesRepository,
            IDeletableEntityRepository<PlannedTask> plannedTaskRepository)
        {
            this.quotesRepository = quotesRepository;
            this.plannedTaskRepository = plannedTaskRepository;
        }

        public RandomQuoteInSelfCareViewModel GetRandomQuote()
        {
            var randomQuote = this.quotesRepository
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new RandomQuoteInSelfCareViewModel
                {
                    Id = x.Id,
                    QuoteText = x.QuoteText,
                    QuoteAuthor = x.QuoteAuthor,
                })
                .ToList().FirstOrDefault();

            return randomQuote;
        }

        public IEnumerable<PlannedTasksMarkedAsDoneInSelfCareViewModel> GetAllMarkedAsDone(ApplicationUser user)
        {
            var plannedTasks = this.plannedTaskRepository.AllAsNoTracking()
    .Where(x => x.CreatedByUser == user)
    .Where(x => x.IsDone == true)
    .Where(x => x.Date == DateTime.Now.Date)
    .OrderBy(x => x.StartTime)
    .Select(x => new PlannedTasksMarkedAsDoneInSelfCareViewModel
    {
        Id = x.Id,
        Title = x.Title,
        Date = x.Date,
        IsDone = x.IsDone,
        CreatedByUserId = x.CreatedByUserId,
        CreatedByUser = x.CreatedByUser,
    })
    .ToList();
            return plannedTasks;
        }
    }
}
