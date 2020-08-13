using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
