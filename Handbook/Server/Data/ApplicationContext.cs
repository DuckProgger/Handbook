using Handbook.Shared;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Server.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Вася", Patronymic = "Васильевич", LastName = "Пупкин", Active = true },
                new User { Id = 2, FirstName = "Петя", Patronymic = "Петрович", LastName = "Петров", Active = true },
                new User { Id = 3, FirstName = "Иван", Patronymic = "Иванович", LastName = "Иванов", Active = true }
            );
        }
    }
}
