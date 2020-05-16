using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Lab2.Domain.Models;

namespace Lab2.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<Sarcina> Sarcini { get; set; }
        public DbSet<Lab2.Domain.Models.Comment> Comment { get; set; }
    }
}
