namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class PlannedTasksController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPlannedTasksService plannedTasksService;

        public PlannedTasksController(
            ICategoriesService categoriesService,
            IPlannedTasksService plannedTasksService)
        {
            this.categoriesService = categoriesService;
            this.plannedTasksService = plannedTasksService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreatePlannedTaskInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreatePlannedTaskInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.plannedTasksService.CreateAsync(input);

            // TODO: Redirect to planned task details page
            return this.Redirect("/");
        }
    }
}
