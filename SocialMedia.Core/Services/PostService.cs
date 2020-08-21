using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IUnitofWork _unitofWork;
        //private readonly IRepository<User> _userRepository;

        public PostService(IUnitofWork unitofWork)// IRepository<User> userRepository
        {
            _unitofWork = unitofWork;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitofWork.UserRepository.GetById(post.UserId);

            if (user == null)
            {
                throw new BusnissException("User doesn't exist");
            }

            var userPost = await _unitofWork.PostRepository.GetPostsByUser(post.UserId);

            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(post => post.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusnissException("You are not able to publish the post");
                }
            }


            if (post.Description.Contains("sexo"))
            {
                throw new BusnissException("Content not allowed");
            }

            await _unitofWork.PostRepository.Add(post);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
              _unitofWork.PostRepository.Update(post);
            await _unitofWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePost(int idPost)
        {
            await _unitofWork.PostRepository.Delete(idPost);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<Post> GetPost(int idPost)
        {
           return await _unitofWork.PostRepository.GetById(idPost);
        }

        public IEnumerable<Post> GetPosts()
        {
            return  _unitofWork.PostRepository.GetAll();
        }
       
    }
}
