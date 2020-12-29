namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.PlannedTask;
    using TimeBox.Web.ViewModels.SelfCare;

    public class SelfCareController : Controller
    {
        private readonly ISelfCareService selfCareService;
        private readonly UserManager<ApplicationUser> userManager;

        public SelfCareController(
            ISelfCareService selfCareService,
            UserManager<ApplicationUser> userManager)
        {
            this.selfCareService = selfCareService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> SelfCareAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = new SelfCareViewModel
            {
                RandomQuote = this.selfCareService.GetRandomQuote(),
                PlannedTasksMarkedAsDone = this.selfCareService.GetAllMarkedAsDone(user),
            };

            return this.View(viewModel);
        }
    }
}
