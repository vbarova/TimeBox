namespace TimeBox.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.BlogPost;

    public class BlogPostsService : IBlogPostsService
    {
        private readonly string[] allowedExtensions = new[] { "JPG", "jpg", "PNG", "png" };
        private readonly IDeletableEntityRepository<BlogPost> blogPostsRepository;

        public BlogPostsService(IDeletableEntityRepository<BlogPost> blogPostsRepository)
        {
            this.blogPostsRepository = blogPostsRepository;
        }

        public async Task CreateBlogPostAsync(CreateBlogPostInputModel input, string userId, string imagePath)
        {
            var blogPost = new BlogPost
            {
                Title = input.Title,
                BlogText = input.BlogText,
                CreatedByUserId = userId,
            };

            Directory.CreateDirectory($"{imagePath}/blogposts/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Невалиден формат на снимка: {extension}");
                }

                var dbImage = new Image
                {
                    BlogPostId = blogPost.Id,
                    Extension = extension,
                };
                blogPost.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/blogposts/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.blogPostsRepository.AddAsync(blogPost);
            await this.blogPostsRepository.SaveChangesAsync();
        }

        public IEnumerable<BlogPostInListViewModel> GetAll()
        {
            var blogPosts = this.blogPostsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new BlogPostInListViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    BlogText = x.BlogText.Substring(0, 50),
                    CreatedByUserName = x.CreatedByUser.Name,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();
            return blogPosts;
        }

        public BlogPostDetailsViewModel GetById(int id)
        {
            var blogPost = this.blogPostsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new BlogPostDetailsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    BlogText = x.BlogText,
                    Image = x.Images.FirstOrDefault(),
                    CreatedByUserId = x.CreatedByUser.Id,
                    CreatedByUser = x.CreatedByUser,
                    CreatedOn = x.CreatedOn,
                })
                .ToList()
                .FirstOrDefault();
            return blogPost;
        }

        public EditBlogPostInputModel EditById(ApplicationUser user, int id)
        {
            var blogPostToEdit = this.blogPostsRepository
               .AllAsNoTracking()
               .Where(x => x.CreatedByUser == user)
               .Where(x => x.Id == id)
               .Select(x => new EditBlogPostInputModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   BlogText = x.BlogText,
               })
               .ToList()
               .FirstOrDefault();
            return blogPostToEdit;
        }

        public async Task UpdateAsync(int id, EditBlogPostInputModel input)
        {
            var blogPost = this.blogPostsRepository.All().FirstOrDefault(x => x.Id == id);
            blogPost.Title = input.Title;
            blogPost.BlogText = input.BlogText;
            await this.blogPostsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blogPost = this.blogPostsRepository.All().FirstOrDefault(x => x.Id == id);
            this.blogPostsRepository.Delete(blogPost);
            await this.blogPostsRepository.SaveChangesAsync();
        }
    }
}
