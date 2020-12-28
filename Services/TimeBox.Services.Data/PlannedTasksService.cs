namespace TimeBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class PlannedTasksService : IPlannedTasksService
    {
        private readonly IDeletableEntityRepository<PlannedTask> plannedTasksRepository;

        public PlannedTasksService(
            IDeletableEntityRepository<PlannedTask> plannedTasksRepository)
        {
            this.plannedTasksRepository = plannedTasksRepository;
        }

        public async Task CreateAsync(CreatePlannedTaskInputModel input, string userId)
        {
            var plannedTask = new PlannedTask
            {
                Title = input.Title,
                Date = input.Date,
                StartTime = input.StartTime,
                EndTime = input.EndTime,
                Description = input.Description,
                CategoryId = input.CategoryId,
                CreatedByUserId = userId,
            };

            await this.plannedTasksRepository.AddAsync(plannedTask);
            await this.plannedTasksRepository.SaveChangesAsync();
        }

        public IEnumerable<PlannedTaskInListViewModel> GetAll(ApplicationUser user)
        {
            var plannedTasks = this.plannedTasksRepository.AllAsNoTracking()
                .Where(x => x.CreatedByUser == user)
                .Where(x => x.IsDone == false)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.StartTime)
                .Select(x => new PlannedTaskInListViewModel
                {
                    Id = x.Id,
                    Title = x.Title.Substring(0, 12),
                    Date = x.Date,
                    StartTime = x.StartTime,
                })
                .ToList();
            return plannedTasks;
        }

        public PlannedTaskDetailsViewModel ById(ApplicationUser user, int id)
        {
            var plannedTask = this.plannedTasksRepository
               .AllAsNoTracking()
               .Where(x => x.CreatedByUser == user)
               .Where(x => x.Id == id)
               .Select(x => new PlannedTaskDetailsViewModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Date = x.Date,
                   StartTime = x.StartTime,
                   EndTime = x.EndTime,
                   Description = x.Description,
                   IsDone = x.IsDone,
                   CategoryId = x.CategoryId,
                   Category = x.Category,
               })
               .ToList()
               .FirstOrDefault();
            return plannedTask;
        }

        public EditPlannedTaskInputModel EditById(ApplicationUser user, int id)
        {
            var plannedTaskToEdit = this.plannedTasksRepository
               .AllAsNoTracking()
               .Where(x => x.CreatedByUser == user)
               .Where(x => x.Id == id)
               .Select(x => new EditPlannedTaskInputModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   Date = x.Date,
                   StartTime = x.StartTime,
                   EndTime = x.EndTime,
                   Description = x.Description,
                   IsDone = x.IsDone,
                   CategoryId = x.CategoryId,
               })
               .ToList()
               .FirstOrDefault();
            return plannedTaskToEdit;
        }

        public async Task UpdateAsync(int id, EditPlannedTaskInputModel input)
        {
            var plannedTasks = this.plannedTasksRepository.All().FirstOrDefault(x => x.Id == id);
            plannedTasks.Title = input.Title;
            plannedTasks.Date = input.Date;
            plannedTasks.StartTime = input.StartTime;
            plannedTasks.EndTime = input.EndTime;
            plannedTasks.CategoryId = input.CategoryId;
            plannedTasks.Description = input.Description;
            plannedTasks.IsDone = input.IsDone;
            await this.plannedTasksRepository.SaveChangesAsync();
        }
    }
}
