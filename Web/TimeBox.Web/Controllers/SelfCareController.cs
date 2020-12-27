namespace TimeBox.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.SelfCare;

    public class SelfCareController : Controller
    {
        private readonly ISelfCareService selfCareService;

        public SelfCareController(ISelfCareService selfCareService)
        {
            this.selfCareService = selfCareService;
        }

        public IActionResult SelfCare()
        {
            var viewModel = new SelfCareViewModel
            {
                RandomQuote = this.selfCareService.GetRandomQuote(),
            };

            return this.View(viewModel);
        }
    }
}
