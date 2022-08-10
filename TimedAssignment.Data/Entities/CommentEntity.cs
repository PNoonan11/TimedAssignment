using System.ComponentModel.DataAnnotations;

namespace TimedAssignment.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Replies { get; set; }
        public string UserName { get; set; }
        
    }
}