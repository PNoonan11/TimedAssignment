using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Post;
using TimedAssignment.Services.Pagination;

namespace TimedAssignment.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public PostService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        // CRUD Methods

        //Create a new post.
        public async Task<bool> CreatePostAsync(PostCreate newPost)
        {
            var postEntity = _mapper.Map<PostCreate, PostEntity>(newPost);
            _dbContext.Posts.Add(postEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;

        }
        //Gets all posts from the database.
        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync(PagedResponse _filter, HttpContext httpContext)
        {
            var posts = _dbContext.Posts.Select(entity => _mapper.Map<PostListItem>(entity));

            var paginationMetadata = new PageMetadata(posts.Count(), _filter.PageNumber, _filter.PageSize);
            httpContext.Response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationMetadata));

            var items = await posts.Skip((_filter.PageNumber - 1) * _filter.PageSize)
                .Take(_filter.PageSize)
                .ToListAsync();

            return items;

        }
        //Gets post from database using the ID. 
        public async Task<PostDetail> GetPostByIdAsync(int postId)
        {
            var postEntity = await _dbContext.Posts
                                .FirstOrDefaultAsync(e => e.Id == postId);
            return postEntity is null ? null : _mapper.Map<PostDetail>(postEntity);
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