namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class PlannedTasksController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPlannedTasksService plannedTasksService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public PlannedTasksController(
            ICategoriesService categoriesService,
            IPlannedTasksService plannedTasksService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            this.categoriesService = categoriesService;
            this.plannedTasksService = plannedTasksService;
            this.userManager = userManager;
            this.db = db;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePlannedTaskInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePlannedTaskInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.plannedTasksService.CreateAsync(input, user.Id);

            return this.Redirect("/PlannedTasks/Schedule");
        }

        public async Task<IActionResult> ScheduleAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var plannedTasks = new PlannedTasksListViewModel
            {
                PlannedTasks = this.plannedTasksService.GetAll(user),
            };

            return this.View(plannedTasks);
        }

        public async Task<IActionResult> ByIdAsync(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var plannedTask = this.plannedTasksService.ById(user, id);
            return this.View(plannedTask);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var inputModel = this.plannedTasksService.EditById(user, id);
            inputModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditPlannedTaskInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.plannedTasksService.UpdateAsync(id, input);
            return this.Redirect("/PlannedTasks/Schedule");
        }
    }
}
