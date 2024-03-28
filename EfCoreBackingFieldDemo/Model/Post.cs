namespace EfCoreBackingFieldDemo.Model;

public class Post
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    
    public Blog Blog { get; set; }
}