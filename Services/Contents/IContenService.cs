using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Responses.Contents;

namespace BloggerBits.Services.Contents;

public interface IContenService
{
      Task<ContentResponse> AddContentAsync(ContentRequest contentRequest);
      Task<ContentResponse> GetContentByIdAsync(int contentId);
      Task<List<ContentResponse>> GetAllContentAsync();
      Task<ContentResponse> UpdateContentAsync(int id, ContentRequest contentRequest);
      Task<ContentResponse> DeleteContentAsync(int id, bool status);

}
