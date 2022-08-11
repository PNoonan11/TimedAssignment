using System.ComponentModel.DataAnnotations;

namespace TimedAssignment.Models.Post
{
    public class PostCreate
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(600), MinLength(2, ErrorMessage = "Must contain more than one character.")]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }

    }
}