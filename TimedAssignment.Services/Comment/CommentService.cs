using TimedAssignment.Data;
using TimedAssignment.Models.Comment;
using TimedAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TimedAssignment.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateACommentAsync(CommentCreate model)
        {
            if (await GettCommentByUsername(model.UserName) != null)
            return false;
            var entity = new CommentEntity
            {
                Id = model.Id,
                Text = model.Text,
                UserName = model.UserName,
                
            };
            _context.Comments.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
            
        }

        private async Task<CommentEntity> GettCommentByUsername(string UserName)
        {
            return await _context.Comments.FirstOrDefaultAsync(Comment => Comment.UserName.ToLower() == UserName.ToLower());
        }

        public async Task<CommentDetail> GetCommentbyIdAsync(int commentId)
        {
            var entity = await _context.Comments.FindAsync(commentId);
            if(entity is null)
            return null;

            var commentDetail = new CommentDetail
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Text = entity.Text,
                CommentId = entity.CommentId
            };

            return commentDetail;
        }

        public async Task<IEnumerable<CommentListItem>> GetAllCommentsAsync()
        {
            var comments = await _context.Comments
                    .Select(entity => new CommentListItem
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Username = entity.UserName,
                    })
                    .ToListAsync();

                    return comments;

        }

        public async Task<bool> UpdateCommentAsync(CommentUpdate request)
        {
            var commentEntity = await _context.Comments.FindAsync(request.Id);

            commentEntity.Id = request.Id;
            commentEntity.Text = request.Text;
            commentEntity.UserName = request.UserName;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;

        }

        public async Task<bool> DeleteACommentAsync(int commentId)
        {
            var commentEntity = await _context.Comments.FindAsync(commentId);

            _context.Comments.Remove(commentEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<CommentDetail> GetCommentByIdAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateACommentAsync(CommentUpdate request)
        {
            throw new NotImplementedException();
        }
    }
}