using LIBRARY.Entities;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY.data
{
    public class ApplicationDBcontext:DbContext
    {
        public ApplicationDBcontext(DbContextOptions op):base(op) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book_Type>().HasKey(d => d.Id_Type);
            modelBuilder.Entity<Book>().HasKey(d => d.Id_Book);
            modelBuilder.Entity<Book>().HasOne<Book_Type>()
                .WithMany().HasForeignKey(d => d.Id_Type);
        }
        public DbSet<Book_Type> BookTypes { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
