using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Post;
using TimedAssignment.Services.Pagination;
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
        public async Task<IActionResult> GetAllPosts([FromQuery] PagedResponse filter)
        {
            var postsToUser = await _postService.GetAllPostsAsync(filter, HttpContext);
            return Ok(postsToUser);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            var postsToUser = await _postService.GetPostByIdAsync(id);
            return postsToUser is not null ? Ok(postsToUser) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostById([FromBody] PostUpdate postToUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _postService.UpdatePostAsync(postToUpdate) ? Ok("Your post has been updated!") : BadRequest("Your post could not be updated. ");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            return await _postService.DeletePostAsync(id) ? Ok($"The post with id:{id} has been deleted successfully.") : BadRequest($"The post with the id:{id} could not be deleted.");
        }


    }
}
