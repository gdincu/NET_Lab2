using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Models;

namespace Lab2.Domain.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Author { get; set; }
        [MinLength(5, ErrorMessage = "Content to be longer than 5 characters")]
        public string Content { get; set; }
        public bool Important { get; set; }
        [Required]
        public int SarcinaId { get; set; }
        
    }
}
