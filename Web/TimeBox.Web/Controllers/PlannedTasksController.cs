namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.PlannedTask;

    public class PlannedTasksController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPlannedTasksService plannedTasksService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlannedTasksController(
            ICategoriesService categoriesService,
            IPlannedTasksService plannedTasksService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.plannedTasksService = plannedTasksService;
            this.userManager = userManager;
        }

        // TODO: [Authorize(Roles = "User")]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreatePlannedTaskInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        // TODO: [Authorize(Roles = "User")]
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

            // TODO: Redirect to planned task details page
            return this.Redirect("/");
        }
    }
}
