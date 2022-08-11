using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Services.Reply
{
    public interface IReplyService
    {
        public async Task<bool> CreateReplyAsync(ReplyCreate reply);
        public async Task<ReplyCreate> GetReplyByCommentId(int Id);
    }
}