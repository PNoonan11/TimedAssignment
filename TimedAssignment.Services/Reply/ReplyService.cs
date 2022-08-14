using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Models.Reply;
using TimedAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TimedAssignment.Services.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _context;
        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReplyAsync(ReplyCreate reply, CommentEntity Id)
        {
            var replies = (Convert.ToInt32(_context.Comments.FindAsync(Id)));

            var replyPost = new ReplyEntity
            {
                Text = reply.Text,
                Username = reply.UserName,
                ReplyId = replies


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

                Text = replyPost.Text,
                UserName = replyPost.UserName,

            };

            return ReplyCreate;
        }
        public async Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync()
        {
            var replies = await _context.Replies
                    .Select(entity => new ReplyListItem
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Username = entity.Username,
                        ReplyId = entity.ReplyId
                    })
                    .ToListAsync();

            return replies;

        }

        public async Task<bool> UpdateReplyAsync(ReplyUpdate request)
        {
            var replyEntity = await _context.Replies.FindAsync(request.Id);

            replyEntity.Id = request.Id;
            replyEntity.Text = request.Text;
            replyEntity.Username = request.UserName;
            replyEntity.ReplyId = request.ReplyId;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;

        }
        public async Task<bool> DeleteAReplyAsync(int replyId)
        {
            var replyEntity = await _context.Replies.FindAsync(replyId);

            _context.Replies.Remove(replyEntity);
            return await _context.SaveChangesAsync() == 1;
        }




    }
}