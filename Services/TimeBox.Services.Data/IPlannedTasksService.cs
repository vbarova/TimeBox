namespace TimeBox.Services.Data
{
    using System.Threading.Tasks;

    using TimeBox.Web.ViewModels.PlannedTask;

    public interface IPlannedTasksService
    {
        Task CreateAsync(CreatePlannedTaskInputModel input);
    }
}
