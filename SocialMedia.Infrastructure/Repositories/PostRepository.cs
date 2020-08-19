using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly SocialMediaApiContext _socialMediaApiContext;

        public PostRepository(SocialMediaApiContext socialMediaApiContext)
        {
            _socialMediaApiContext = socialMediaApiContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _socialMediaApiContext.Posts.ToListAsync();

            return posts;
        }

        public async Task<Post> GetPost(int idPost)
        {
            var posts = await _socialMediaApiContext.Posts.FirstOrDefaultAsync(
                    post => post.PostId == idPost
                );

            return posts;
        }

        public async Task InsertPost(Post post)
        {
            _socialMediaApiContext.Posts.Add(post);
            await _socialMediaApiContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

            int rows = await _socialMediaApiContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int idPost)
        {
            var currentPost = await GetPost(idPost);
            _socialMediaApiContext.Posts.Remove(currentPost);

            int rows = await _socialMediaApiContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
