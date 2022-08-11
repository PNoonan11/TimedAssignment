using System.ComponentModel.DataAnnotations;

namespace TimedAssignment.Models.Post
{
    public class PostUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}