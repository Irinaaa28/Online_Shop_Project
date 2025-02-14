using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using static ProiectDAW.Models.ProductBookmarks;

namespace ProiectDAW.Data
{
    //PASUL 3: USERI SI ROLURI
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<ProductBookmark> ProductBookmarks { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // definirea relatiei many-to-many dintre Product si Bookmark

            base.OnModelCreating(modelBuilder);

            // definire primary key compus
            modelBuilder.Entity<ProductBookmark>()
                .HasKey(ab => new { ab.Id, ab.ProductId, ab.BookmarkId });

            // definire relatii cu modelele Bookmark si Product (FK)

            modelBuilder.Entity<ProductBookmark>()
                .HasOne(ab => ab.Product)
                .WithMany(ab => ab.ProductBookmarks)
                .HasForeignKey(ab => ab.ProductId);

            modelBuilder.Entity<ProductBookmark>()
                .HasOne(ab => ab.Bookmark)
                .WithMany(ab => ab.ProductBookmarks)
                .HasForeignKey(ab => ab.BookmarkId);
            //pentru a putea sterge un produs care a fost achizitionat anteriror
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
