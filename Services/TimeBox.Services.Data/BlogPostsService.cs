namespace TimeBox.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;
    using TimeBox.Web.ViewModels.BlogPost;

    public class BlogPostsService : IBlogPostsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png" };
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
    }
}
