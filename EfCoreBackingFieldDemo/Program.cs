// See https://aka.ms/new-console-template for more information

using EfCoreBackingFieldDemo;
using EfCoreBackingFieldDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var services = new ServiceCollection();

services.AddDbContext<DemoDbContext>(cfg =>
{
    cfg.UseSqlServer(config.GetConnectionString("db"));
});

var provider = services.BuildServiceProvider();

// Setup DB
Request.Run(provider, (sp) =>
{
    var context = sp.GetRequiredService<DemoDbContext>();
    Console.WriteLine("Deleting old database");
    context.Database.EnsureDeleted();
    Console.WriteLine("Creating and migrating new database");
    context.Database.Migrate();
});

RunBlogRequests(provider);
RunBlogV2Requests(provider);

void RunBlogRequests(ServiceProvider serviceProvider)
{
    // 1 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Adding new blog, with 1 post");
        var blog = new Blog();
        blog.AddPost(new Post());
    
        context.Add(blog);
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 2 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Adding 1 post");
        var blog = context.Blogs
            .Include(p => p.Posts)
            .First();
    
        foreach (var post in blog.Posts)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }
    
        blog.AddPost(new Post());
    
        context.Update(blog);
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 3 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Fetching the blog, with 2 posts. Removing the first post");
        var blog = context.Blogs
            .Include(p => p.Posts)
            .First();
    
        foreach (var post in blog.Posts)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }

        if(blog.Posts.Any()) {
            Console.WriteLine("Removing first post");
            blog.RemovePost(blog.Posts.ElementAt(0));
            context.Update(blog);
        }
        else
        {
            Console.WriteLine("No post found");
        }
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 4 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Fetching the blog, with 1 post.");
        var blog = context.Blogs
            .Include(p => p.Posts)
            .First();

        foreach (var post in blog.Posts)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });
}
void RunBlogV2Requests(ServiceProvider serviceProvider)
{
    // 1 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Adding new blogV2, with 1 postV2");
        var blog = new BlogV2();
        blog.PostV2s.Add(new PostV2());
    
        context.Add(blog);
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 2 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Adding 1 post");
        var blog = context.BlogV2s
            .Include(p => p.PostV2s)
            .First();
    
        foreach (var post in blog.PostV2s)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }
    
        blog.PostV2s.Add(new PostV2());
    
        context.Update(blog);
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 3 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Fetching the blog, with 2 posts. Removing the first post");
        var blog = context.BlogV2s
            .Include(p => p.PostV2s)
            .First();
    
        foreach (var post in blog.PostV2s)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }

        if(blog.PostV2s.Any()) {
            Console.WriteLine("Removing first post");
            blog.PostV2s.Remove(blog.PostV2s[0]);
            context.Update(blog);
        }
        else
        {
            Console.WriteLine("No post found");
        }
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });

// 4 request
    Request.Run(serviceProvider, sp =>
    {
        var context = sp.GetRequiredService<DemoDbContext>();
        Console.WriteLine("Fetching the blog, with 1 post.");
        var blog = context.BlogV2s
            .Include(p => p.PostV2s)
            .First();

        foreach (var post in blog.PostV2s)
        {
            Console.WriteLine("Found post with id: {0}", post.Id); 
        }
    
        if(context.ChangeTracker.HasChanges())
            Console.WriteLine("Has changes to apply");
    
        context.SaveChanges();
    });
}