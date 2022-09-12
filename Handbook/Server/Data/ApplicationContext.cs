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
        public DbSet<ActiveDirectoryLogin> ADLogins { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveDirectoryLogin>().HasData(
                new ActiveDirectoryLogin { Id = 1, Domain = "CompanyDomain", Login = "Вася Пупкин" },
                new ActiveDirectoryLogin { Id = 2, Domain = "CompanyDomain", Login = "Петя Петров" },
                new ActiveDirectoryLogin { Id = 3, Domain = "CompanyDomain", Login = "Иван Иванов" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Вася", Patronymic = "Васильевич", LastName = "Пупкин", Active = true, ActiveDirectoryLoginId = 1 },
                new User { Id = 2, FirstName = "Петя", Patronymic = "Петрович", LastName = "Петров", Active = true, ActiveDirectoryLoginId = 2 },
                new User { Id = 3, FirstName = "Иван", Patronymic = "Иванович", LastName = "Иванов", Active = true , ActiveDirectoryLoginId = 3 }
            );
        }
    }
}
