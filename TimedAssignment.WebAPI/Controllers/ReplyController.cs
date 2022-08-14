using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Reply;
using TimedAssignment.Services.Reply;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _service;
        public ReplyController(IReplyService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CommentCreate([FromBody] ReplyCreate model, CommentEntity Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var replyResult = await _service.CreateReplyAsync(model, Id);
            if (replyResult)
            {
                return Ok("Reply was created.");
            }
            return BadRequest("Reply could not be created.");
        }

        [HttpGet("{replyId:int")]
        public async Task<IActionResult> GetById([FromRoute] int commentId)
        {
            var replyDetail = await _service.GetReplyByCommentId(commentId);

            if (replyDetail is null)
            {
                return NotFound();
            }

            return Ok(replyDetail);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReplies()
        {
            var replies = await _service.GetAllRepliesAsync();
            return Ok(replies);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReplyById([FromBody] ReplyUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _service.UpdateReplyAsync(request)
            ? Ok("Reply updated successfully.")
            : BadRequest("Reply could not be updated.");
        }

        [HttpDelete("{replyId:int}")]
        public async Task<IActionResult> DeleteAReplyById([FromRoute] int replyId)
        {
            return await _service.DeleteAReplyAsync(replyId)
            ? Ok($"Reply {replyId} was deleted successfully.")
            : BadRequest($"Reply {replyId} could not be deleted.");
        }

    }
}
