using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Reply;

namespace TimedAssignment.Services.Reply
{
    public interface IReplyService
    {
        Task<bool> CreateReplyAsync(ReplyCreate reply, CommentEntity Id);
        Task<ReplyCreate> GetReplyByCommentId(int Id);
        Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync();
        Task<bool> UpdateReplyAsync(ReplyUpdate request);
        Task<bool> DeleteAReplyAsync(int replyId);
    }
}