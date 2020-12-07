namespace TimeBox.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class PlannedTasksService : IPlannedTasksService
    {
        private readonly IRepository<PlannedTask> plannedTasksRepository;

        public PlannedTasksService(IRepository<PlannedTask> plannedTasksRepository)
        {
            this.plannedTasksRepository = plannedTasksRepository;
        }

        public async Task CreateAsync(CreatePlannedTaskInputModel input)
        {
            var plannedTask = new PlannedTask
            {
                Title = input.Title,
                Date = input.Date,
                StartTime = input.StartTime,
                EndTime = input.EndTime,
                Description = input.Description,
                CategoryId = input.CategoryId,
            };

            await this.plannedTasksRepository.AddAsync(plannedTask);
            await this.plannedTasksRepository.SaveChangesAsync();
        }
    }
}
