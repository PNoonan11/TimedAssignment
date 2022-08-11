using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Models.Reply;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Services.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReplyAsync(ReplyCreate reply)
        {
            var replies = await _context.Comments.FirstOrDefaultAsync(r => r.Comments.Id);

            var replyPost = new ReplyEntity
            {
                Id = replyPost.Id,
                Text = replyPost.Text,
                Username = replyPost.Username,
                ReplyId = replyPost.ReplyId
            };

            _context.Replies.Add(replyPost);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<ReplyCreate> GetReplyByCommentId(int Id)
        {
            var replyPost = await _context.Comments.FindAsync(Id);
            if (replyPost is null)
            return null;

            var ReplyCreate = new ReplyCreate
            {
                Id = replyPost.Id,
                Text = replyPost.Text,
                Username = replyPost.Username,
                ReplyId = replyPost.ReplyId
            };

            return ReplyCreate;
        }
    }
}