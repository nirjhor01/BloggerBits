using System;
using BloggerBits.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloggerBits.Database;

public class ApplicationDbContext: DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Author> Authors { get; set; }
    

}
