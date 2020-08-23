using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace message_board.Models
{
    public class TodoMessage
    {
        public long id { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public string postedBy { get; set; }
        [Required]
        public DateTime modifiedDate { get; set; }
        [Required]
        public DateTime posteDate { get; set; }
    }
}
