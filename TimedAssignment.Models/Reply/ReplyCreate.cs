using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Reply
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(128)]
        public string Text { get; set; }

        [Required]
        public string Username { get; set; }
    }
}