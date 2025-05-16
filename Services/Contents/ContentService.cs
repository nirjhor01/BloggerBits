using System;
using System.Text;
using System.Text.Json;
using AutoMapper;
using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Responses.Contents;
using BloggerBits.Entities;
using BloggerBits.Exceptions;
using BloggerBits.Helper;
using BloggerBits.Repositories.Contents;

namespace BloggerBits.Services.Contents;

public class ContentService : IContenService
{
    private readonly IContentRepository _contentRepository;
    private readonly IMapper _mapper;
    public ContentService(IContentRepository contentRepository, IMapper mapper)
    {
        _contentRepository = contentRepository;
        _mapper = mapper;
    }

    public async Task<ContentResponse> AddContentAsync(ContentRequest contentRequest)
    {
        try
        {
            var recordExists = await _contentRepository.RecordExistsAsync(x => x.Title == contentRequest.Title
            && x.AuthorId == contentRequest.AuthorId);
            if (recordExists == true)
            {
                throw new RecordAlreadyExistsException(UiMessage.RECORD_EXISTS);
            }
            var contentEntity = _mapper.Map<Content>(contentRequest);
            contentEntity.CreatedAt = DateTime.UtcNow;
            contentEntity.Update();
            contentEntity.MarkAsHavingPdf();
            contentEntity.Publish();
            await _contentRepository.AddAsync(contentEntity);
            await _contentRepository.SaveChangesAsync();
            var res = _mapper.Map<ContentResponse>(contentEntity);
            return res;
        }
        catch (Exception ex)
        {
            throw new OperationFailedException(UiMessage.DATA_SAVED_FAILED, ex);
        }
    }
    public async Task<ContentResponse> GetContentByIdAsync(int contentId)
    {
        try
        {
            var res = await _contentRepository.GetByIdAsync(contentId);
            if(res == null)
            {
                throw new RecordAlreadyExistsException(UiMessage.DATA_NOT_FOUND);
            }
            StringBuilder fixedStr = new();

            var contentEntity = _mapper.Map<Content>(res);
            //var cleaned = contentEntity.Description.Replace("\\\"", "\"");
            //contentEntity.Description = cleaned;
            //var json = JsonSerializer.Serialize(contentEntity.Description);
            //var original = JsonSerializer.Deserialize<string>(json);
            //string sanitizedData = original.Replace("\\", "");
            Console.WriteLine(contentEntity.Description);



            
            



            return _mapper.Map<ContentResponse>(contentEntity);

        }
        catch(Exception ex)
        {
            throw new OperationFailedException(UiMessage.OPERATION_FAILED, ex);
        }
        
    }
    public Task<List<ContentResponse>> GetAllContentAsync(ContentRequest contentRequest)
    {
        return null;

    }

    public async Task<ContentResponse> UpdateContentAsync(ContentRequest contentRequest)
    {
        return null;
    }

    public Task<ContentResponse> DeleteContentAsync(ContentRequest contentRequest)
    {
        throw new NotImplementedException();
    }





}
