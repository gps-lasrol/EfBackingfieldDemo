namespace EfCoreBackingFieldDemo.Model;

public class PostV2
{
    public Guid Id { get; set; }
    public BlogV2 BlogV2 { get; set; }
    public Guid BlogV2Id { get; set; }
}