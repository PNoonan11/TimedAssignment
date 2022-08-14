using Microsoft.AspNetCore.Http;
using TimedAssignment.Models.Post;
using TimedAssignment.Services.Pagination;

namespace TimedAssignment.Services.Post
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreate request);
        Task<IEnumerable<PostListItem>> GetAllPostsAsync(PagedResponse _filter, HttpContext httpContext);
        Task<PostDetail> GetPostByIdAsync(int postId);
        Task<bool> UpdatePostAsync(PostUpdate request);
        Task<bool> DeletePostAsync(int postId);
    }
}