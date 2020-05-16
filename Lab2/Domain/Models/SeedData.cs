using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaskManager.Domain.Models;
using System.Threading.Tasks;
using Lab2.Persistence.Contexts;

namespace Lab2.Domain.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext  (
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                // Look for any movies.
                if (context.Sarcini.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Sarcini.AddRange(
                    new Sarcina
                    {
                        Id = 1,
                        Title = "A",
                        Description = "A",
                        Added = DateTime.Now,
                        Deadline = DateTime.Now,
                        Importance = Importance.Low,
                        Stare = Stare.InProgress
                    },

                    new Sarcina
                    {
                        Id = 2,
                        Title = "B",
                        Description = "B",
                        Added = DateTime.Now,
                        Deadline = DateTime.Now,
                        Importance = Importance.Low,
                        Stare = Stare.InProgress
                    },

                    new Sarcina
                    {
                        Id = 3,
                        Title = "C",
                        Description = "C",
                        Added = DateTime.Now,
                        Deadline = DateTime.Now,
                        Importance = Importance.Low,
                        Stare = Stare.InProgress
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}