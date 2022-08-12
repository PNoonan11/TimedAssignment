using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimedAssignment.Data.Entities
{
    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Text { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [ForeignKey("CommentEntity")]
        public int ReplyId { get; set; }
        public CommentEntity CommentEntity { get; set; }
    }
}