namespace TimeBox.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.PlannedTask;

    public interface IPlannedTasksService
    {
        Task CreateAsync(CreatePlannedTaskInputModel input, string userId);

        IEnumerable<PlannedTaskInListViewModel> GetAll(ApplicationUser user);

        PlannedTaskDetailsViewModel ById(ApplicationUser user, int id);
    }
}
