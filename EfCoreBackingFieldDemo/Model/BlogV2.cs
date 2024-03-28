namespace EfCoreBackingFieldDemo.Model;

public class BlogV2
{
    public Guid Id { get; set; }
    public List<PostV2> PostV2s { get; set; } = new();
}