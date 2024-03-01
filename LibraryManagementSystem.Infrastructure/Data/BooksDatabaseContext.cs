using LibraryManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class BooksDatabaseContext : DbContext
    {
        public BooksDatabaseContext(DbContextOptions<BooksDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Id)
                .UseIdentityColumn();
        }

        public DbSet<Book> Products { get; set; }
    }
}
