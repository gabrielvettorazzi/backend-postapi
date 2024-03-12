namespace forumApi.Models;

public class PostItem
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public string? Title { get; set; }
  public required string Content { get; set; }
}