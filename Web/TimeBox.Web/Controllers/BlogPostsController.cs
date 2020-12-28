namespace TimeBox.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TimeBox.Data;
    using TimeBox.Data.Models;
    using TimeBox.Services.Data;
    using TimeBox.Web.ViewModels.BlogPost;

    public class BlogPostsController : Controller
    {
        private readonly IBlogPostsService blogPostsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public BlogPostsController(
            IBlogPostsService blogPostsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.blogPostsService = blogPostsService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var viewModel = new CreateBlogPostInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CreateBlogPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.blogPostsService.CreateBlogPostAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = this.blogPostsService.GetAll(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ByIdAsync(int id)
        {
            var blogPost = this.blogPostsService.GetById(id);
            return this.View(blogPost);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var inputModel = this.blogPostsService.EditById(user, id);
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, EditBlogPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.blogPostsService.UpdateAsync(id, input);
            return this.Redirect("/BlogPosts/All");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Delete(int id)
        {
            await this.blogPostsService.DeleteAsync(id);
            return this.Redirect("/BlogPosts/All");
        }
    }
}
