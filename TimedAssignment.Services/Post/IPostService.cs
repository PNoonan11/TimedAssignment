using TimedAssignment.Models.Post;

namespace TimedAssignment.Services.Post
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(PostCreate request);
        Task<IEnumerable<PostListItem>> GetAllPostsAsync();
        Task<PostDetail> GetPostByIdAsync(int postId);
        Task<bool> UpdatePostAsync(PostUpdate request);
        Task<bool> DeletePostAsync(int postId);
    }
}