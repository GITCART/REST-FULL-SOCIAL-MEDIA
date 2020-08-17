using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

            return Ok(postDtos);
        }

        [HttpGet("{idPost}")]
        public async Task<IActionResult> GetPost(int idPost)
        {
            var post = await _postRepository.GetPost(idPost);

            var postDto = _mapper.Map<PostDto>(post);

            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            // Replace [ApiController] when desactive in class Startup
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            var post = _mapper.Map<Post>(postDto);

            await _postRepository.InsertPost(post);

            return Ok(postDto);
        }
    }
}
