using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Models.Comment;
using TimedAssignment.Data.Entities;
using TimedAssignment.Data;

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
            var entity = new CommentEntity
            {
                Text = model.Text,
                UserName = model.UserName
            };
            _context.Comments.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
            
        }
    }
}