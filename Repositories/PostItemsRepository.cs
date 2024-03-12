
using forumApi.Models;
using Microsoft.EntityFrameworkCore;

public interface IPostItemsRepository
{
  Task<List<PostItem>> GetPostItem();
}

public class PostItemsRepository : IPostItemsRepository
{
  private readonly ApplicationDbContext _dbContext;

  public PostItemsRepository(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<List<PostItem>> GetPostItem()
  {
    return _dbContext.PostItem.ToListAsync();
  }
}