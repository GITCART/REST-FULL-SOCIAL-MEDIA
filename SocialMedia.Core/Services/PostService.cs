using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
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
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("sexo"))
            {
                throw new Exception("Content not allowed");
            }

            await _unitofWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
             await _unitofWork.PostRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int idPost)
        {
            await _unitofWork.PostRepository.Delete(idPost);
            return true;
        }

        public async Task<Post> GetPost(int idPost)
        {
           return await _unitofWork.PostRepository.GetById(idPost);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitofWork.PostRepository.GetAll();
        }
       
    }
}
