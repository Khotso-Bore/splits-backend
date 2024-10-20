using Microsoft.EntityFrameworkCore;
using SplitsAPI.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Domian.Data
{
    public class SplitsDbContext : DbContext
    {
        public SplitsDbContext(DbContextOptions<SplitsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>()
                .HasOne(x => x.UserContact)
                .WithMany(u => u.Contacts)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Contact>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<Transaction>()
                .HasOne(t => t.DebtorUser)
                .WithMany(u => u.DebtTransactions)
                .HasForeignKey(t => t.DebtorId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Transaction>()
                .HasOne(t => t.CreditorUser)
                .WithMany(u => u.CreditTransactions)
                .HasForeignKey(t => t.CreditorId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Transaction>()
                .Property(p => p.Amount)
                .HasPrecision(18,4);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contatcs {get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
