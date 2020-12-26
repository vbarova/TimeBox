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

        // TODO: [Authorize(Roles = "Administrator")]
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateBlogPostInputModel();
            return this.View(viewModel);
        }

        // TODO: [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Authorize]
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

            // TODO: Redirect to all blogposts
            return this.RedirectToAction("/");
        }

        public IActionResult All()
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = this.blogPostsService.GetAll(),
            };

            return this.View(viewModel);
        }
    }
}
