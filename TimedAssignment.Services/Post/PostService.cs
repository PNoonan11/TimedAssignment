using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Post;

namespace TimedAssignment.Services.Post
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;
        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // CRUD Methods
        public async Task<bool> CreatePostAsync(PostCreate request)
        {
            var postEntity = new PostEntity
            {
                Title = request.Title,
                Text = request.Text,
                UserName = request.UserName
            };
            _dbContext.Posts.Add(postEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        public async Task<IEnumerable<PostListItem>> GetAllNotesAsync()
        {
            var posts = _dbContext.Posts.ToListAsync();



            return posts;
        }
        //Gets post from database using the ID. 
        public async Task<PostDetail> GetPostByIdAsync(int postId)
        {
            var postEntity = await _dbContext.Posts
                                .FirstOrDefaultAsync(e => e.Id == postId);
            return postEntity is null ? null : new PostDetail
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Text = postEntity.Text,
                UserName = postEntity.UserName
            };
        }

        public async Task<bool> UpdatePostAsync(PostUpdate request)
        {
            // Find the note by id. 
            var postEntity = await _dbContext.Posts.FindAsync(request.Id);

            // update the entities properties
            postEntity.Title = request.Title;
            postEntity.Text = request.Text;
            postEntity.UserName = request.UserName;

            //Save the changes to the database and see how many rows were added.
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            // numberOfChanges is stated to be equal to 1 because only one row is updated
            return numberOfChanges == 1;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            //Find the post by  Id
            var postEntity = await _dbContext.Posts.FindAsync(postId);


            //Remove the note from DbContext
            _dbContext.Posts.Remove(postEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }












    } //Class
}//namespace