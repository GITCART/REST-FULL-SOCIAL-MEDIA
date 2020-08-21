using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{

    //class is no longer used
    public class PostMongoRepository //: IPostRepository
    {
        public Task<bool> DeletePost(int idPost)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(int idPost)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                /*PostId = x,
                Description = $"Description{x}",
                Date = DateTime.Now,
                Image = $"https://images.com/{x}",
                UserId = x * 2*/
            });

            await Task.Delay(10);

            return posts;
        }

        public Task InsertPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
