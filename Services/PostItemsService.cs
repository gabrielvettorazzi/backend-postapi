using forumApi.Models;
using Microsoft.EntityFrameworkCore;

public interface IPostItemsService
{
  Task<List<PostItemResponse>> GetPostItem();
}


public class PostItemsService : IPostItemsService
{
  private readonly IPostItemsRepository _postItemsRepository;

  public PostItemsService(IPostItemsRepository postItemsRepository)
  {
    _postItemsRepository = postItemsRepository;
  }

  public async Task<List<PostItemResponse>> GetPostItem()
  {
    var result = new List<PostItemResponse>();

    var postItens = await _postItemsRepository.GetPostItem();

    foreach (var item in postItens)
    {
      result.Add(new PostItemResponse()
      {
        Id = item.Id,
        Nome = item.Name,
        Titulo = item.Title ?? "Nao tem titulo",
        Conteudo = item.Content
      });
    }

    return result;
  }
}