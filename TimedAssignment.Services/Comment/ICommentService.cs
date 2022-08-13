using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Comment;


namespace TimedAssignment.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateACommentAsync(CommentCreate model);
        Task<CommentDetail> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<CommentListItem>> GetAllCommentsAsync();
        Task<bool> UpdateACommentAsync(CommentUpdate request);
        Task<bool> DeleteACommentAsync(int commentId);

    }
}