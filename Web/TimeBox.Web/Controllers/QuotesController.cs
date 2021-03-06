﻿namespace TimeBox.Web.Controllers
{
    using System;
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

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var viewModel = new CreateQuoteInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CreateQuoteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.quotesService.CreateAsync(input);

            try
            {
                await this.quotesService.CreateAsync(input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            var viewModel = new QuotesListViewModel
            {
                Quotes = this.quotesService.GetAll(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Delete(int id)
        {
            if (!this.quotesService.Exists(id))
            {
                return this.RedirectToAction("NotFoundError", "Error");
            }

            await this.quotesService.DeleteAsync(id);
            return this.Redirect("/Quotes/All");
        }
    }
}
