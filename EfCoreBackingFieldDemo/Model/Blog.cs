namespace EfCoreBackingFieldDemo.Model;

public class Blog
{
    private List<Post> _posts = new();
    
    public Guid Id { get; set; }
    public IEnumerable<Post> Posts { get; set; }

    public void AddPost(Post post)
    {
        _posts.Add(post);
    }

    public void RemovePost(Post post)
    {
        _posts.Remove(post);
    }
}