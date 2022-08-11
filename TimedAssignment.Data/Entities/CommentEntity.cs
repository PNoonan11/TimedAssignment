using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimedAssignment.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Text { get; set; }
        public List<ReplyEntity> Replies { get; set; }
        [Required]
        public string UserName { get; set; }
        [ForeignKey("PostEntity")]
        public int CommentId { get; set; }

    }
}