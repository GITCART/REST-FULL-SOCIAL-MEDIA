using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;

            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();

            /*var postDtos = posts.Select(post => new PostDto{
                Date = post.Date,
                Description = post.Description
            });
             // Remplace with _mapper : AutoMapper
             */

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            var response = new ApiResponse<IEnumerable<PostDto>>(postDtos);

            return Ok(response);
        }

        [HttpGet("{idPost}")]
        public async Task<IActionResult> GetPost(int idPost)
        {
            var post = await _postRepository.GetPost(idPost);

            var postDto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            // Replace [ApiController] when desactive in class Startup:::: moved to ValidationFilter class
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            var post = _mapper.Map<Post>(postDto);

            await _postRepository.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int idPost, PostDto postDto) {

            var post = _mapper.Map<Post>(postDto);
            post.PostId = idPost;

            var result = await _postRepository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{idPost}")]
        public async Task<IActionResult> DeletePost(int idPost) {
            var result = await _postRepository.DeletePost(idPost);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
