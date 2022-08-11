using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        [MaxLength (180)]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }


    }
}