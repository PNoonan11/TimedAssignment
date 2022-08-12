using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReplyEntity> Replies { get; set; }



    }
}