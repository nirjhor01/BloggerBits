using BloggerBits.DTOS.Requests;

namespace BloggerBits.Services.Contents;

public interface IContenService
{
      Task<Content> AddAsync(ContentRequest contentRequest);

}
