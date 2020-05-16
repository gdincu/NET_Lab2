using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Models;

namespace Lab2.Domain.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public bool Important { get; set; }
    }
}
