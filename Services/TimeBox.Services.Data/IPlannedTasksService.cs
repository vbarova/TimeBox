namespace TimeBox.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.PlannedTask;

    public interface IPlannedTasksService
    {
        bool Exists(int id);

        Task CreateAsync(CreatePlannedTaskInputModel input, string userId);

        IEnumerable<PlannedTaskInListViewModel> GetAll(ApplicationUser user);

        PlannedTaskDetailsViewModel ById(ApplicationUser user, int id);

        EditPlannedTaskInputModel EditById(ApplicationUser user, int id);

        Task UpdateAsync(int id, EditPlannedTaskInputModel input);

        Task DeleteAsync(int id);
    }
}
