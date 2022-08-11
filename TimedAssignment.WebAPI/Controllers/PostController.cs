using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Post;
using TimedAssignment.Services.Post;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> MakePost([FromBody] PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _postService.CreatePostAsync(post))
                return Ok("Your post has been added!");

            return BadRequest("Post could not be added.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);

        }



    }
}
