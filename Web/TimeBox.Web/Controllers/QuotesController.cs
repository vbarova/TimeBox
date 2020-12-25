namespace TimeBox.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.Quote;

    public class QuotesController : Controller
    {
        private readonly IQuotesService quotesService;

        public QuotesController(IQuotesService quotesService)
        {
            this.quotesService = quotesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateQuoteInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateQuoteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.quotesService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
