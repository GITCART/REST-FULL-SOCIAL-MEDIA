using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostMongoRepository : IPostRepository
    {
        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Publicacion
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
    }
}
