using System;
using BloggerBits.Entities;
using BloggerBits.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BloggerBits.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ContentCategories> ContentCategories {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                Name = "DefaultName",
                Username = "admin",
                Email = "admin@bloggerbits.com",
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                isActive = true
            }
        );
        // Many-to-many relationship between Content and Category
        // modelBuilder.Entity<Content>()
        //     .HasMany(c => c.Categories)
        //     .WithMany(c => c.Contents)
        //     .UsingEntity(j => j.ToTable("ContentCategories"));

        //One-to-many
        modelBuilder.Entity<Content>()
            .HasOne(c => c.Author)
            .WithMany(c => c.Contents)
            .HasForeignKey(c=>c.AuthorId);

    }





}
