using System.Data.Common;
using EfCoreBackingFieldDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBackingFieldDemo;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<BlogV2> BlogV2s { get; set; }
    public DbSet<PostV2> PostV2s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Blog>()
            .HasMany(p => p.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId);
        
        modelBuilder.Entity<Blog>()
            .Metadata
            .FindNavigation("Posts")
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        modelBuilder.Entity<Post>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<BlogV2>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<PostV2>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<BlogV2>()
            .HasMany(p => p.PostV2s)
            .WithOne(p => p.BlogV2)
            .HasForeignKey(p => p.BlogV2Id);
    }
}