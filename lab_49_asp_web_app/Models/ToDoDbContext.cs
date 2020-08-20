using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_49_asp_web_app.Models
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // relationships - one user can have many ToDos.
            builder.Entity<User>()
                .HasMany(user => user.ToDos)
                .WithOne(user => user.User);

            // username is required
            builder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            // seed data 
            builder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Alex"},
                new User { UserId = 2, UserName = "John"},
                new User { UserId = 3, UserName = "Jemma"},
                new User { UserId = 4, UserName = "James"},
                new User { UserId = 5, UserName = "Daniel"},
                new User { UserId = 6, UserName = "Hannah"}
            );

            builder.Entity<ToDo>().HasData(
                new ToDo { ToDoId = 1, ToDoName = "Important ToDo", UserId = 2},
                new ToDo { ToDoId = 2, ToDoName = "Do something userful", UserId = 2},
                new ToDo { ToDoId = 3, ToDoName = "Not essential task", UserId = 2},
                new ToDo { ToDoId = 4, ToDoName = "A fourth ToDo", UserId = 2}
            );
        }
    }
}
