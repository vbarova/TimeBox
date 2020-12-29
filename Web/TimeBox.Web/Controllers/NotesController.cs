namespace TimeBox.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.Note;

    public class NotesController : Controller
    {
        private readonly INotesService notesService;
        private readonly UserManager<ApplicationUser> userManager;

        public NotesController(
            INotesService notesService,
            UserManager<ApplicationUser> userManager)
        {
            this.notesService = notesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateNoteInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateNoteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.notesService.CreateAsync(input, user.Id);

            try
            {
                await this.notesService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.Redirect("/notes/all");
        }

        public async Task<IActionResult> AllAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new NotesListViewModel
            {
                Notes = this.notesService.GetAll(user),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!this.notesService.Exists(id))
            {
                return this.RedirectToAction("NotFoundError", "Error");
            }

            await this.notesService.DeleteAsync(id);
            return this.Redirect("/Notes/All");
        }
    }
}
