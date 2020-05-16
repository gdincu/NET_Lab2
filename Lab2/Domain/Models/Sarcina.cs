using Lab2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models
{

    public class Sarcina
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public DateTime Deadline { get; set; }
        public Importance Importance { get; set; }
        public Stare Stare { get; set; }
        public DateTime ClosedAt { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
