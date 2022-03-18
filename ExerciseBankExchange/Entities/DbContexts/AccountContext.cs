using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExerciseBankExchange.Entities.Models;

namespace ExerciseBankExchange.Entities.DbContextss
{
    public class AccountContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AccountContext()
        {
        }

        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .HasData(
                    new User() { Id = 1, Name = "John" },
                    new User() { Id = 2, Name = "Eryk" },
                    new User() { Id = 3, Name = "Martin" }
                );


            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Account>()
                .HasData(
                    new Account() { Id = 1, UserId = 1, SaldoPl = 1000f },
                    new Account() { Id = 2, UserId = 2, SaldoPl = 500 },
                    new Account() { Id = 3, UserId = 3, SaldoPl = 1200f }

                );
        }
    }
}
