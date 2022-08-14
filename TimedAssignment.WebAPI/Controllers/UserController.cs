using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Comment;
using TimedAssignment.Services.Comment;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommentService _service;
        public UserController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CommentCreate([FromBody] CommentCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentResult = await _service.CreateACommentAsync(model);
            if(commentResult)
            {
                return Ok("Comment was created.");
            }
            return BadRequest("Comment could not be created.");
        }

        [HttpGet("{commentId:int")]
        public async Task<IActionResult> GetById([FromRoute] int commentId)
        {
            var commentDetail = await _service.GetCommentByIdAsync(commentId);

            if(commentDetail is null)
            {
                return NotFound();
            }

            return Ok(commentDetail);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _service.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommentById([FromBody] CommentUpdate request)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _service.UpdateACommentAsync(request)
            ? Ok("Comment updated successfully.")
            : BadRequest("Comment could not be updated.");
        }

        [HttpDelete("{commentId:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            return await _service.DeleteACommentAsync(commentId)
            ? Ok($"Comment {commentId} was deleted successfully.")
            : BadRequest($"Comment {commentId} could not be deleted.");
        }
    }
}
