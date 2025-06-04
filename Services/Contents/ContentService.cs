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
            if (res == null)
            {
                throw new RecordAlreadyExistsException(UiMessage.DATA_NOT_FOUND);
            }
            var contentEntity = _mapper.Map<Content>(res);
            return _mapper.Map<ContentResponse>(contentEntity);

        }
        catch (Exception ex)
        {
            throw new OperationFailedException(UiMessage.OPERATION_FAILED, ex);
        }

    }
    public async Task<List<ContentResponse>> GetAllContentAsync()
    {
        try
        {
            var contentReferrence = await _contentRepository.GetAllAsync();
            if (contentReferrence is null)
            {
                Exception exception = new OperationFailedException("failed to retrive data");
                throw exception;
            }

            return _mapper.Map<List<ContentResponse>>(contentReferrence);
        }
        catch (Exception ex)
        {
            Exception exception = new OperationFailedException("Failed to retrive data");
            throw exception;
        }

    }

    public async Task<ContentResponse> UpdateContentAsync(int contentId, ContentRequest contentRequest)
    {
        try
        {
            var existed = await _contentRepository.RecordExistsAsync(item => item.Title == contentRequest.Title && item.Id != contentId);
            if (existed is true)
            {
                Exception exception = new RecordAlreadyExistsException(UiMessage.NAME_MUST_BE_UNIQUE);
                throw exception;
            }
            var contentReferrence = await _contentRepository.GetByIdAsync(contentId);
            var contentEntity = _mapper.Map<Content>(contentReferrence);
            await _contentRepository.UpdateAsync(contentEntity);
            return _mapper.Map<ContentResponse>(contentEntity);

        }
        catch (Exception ex)
        {
            Exception exception = new OperationFailedException("failed to update content", ex);
            throw exception;
        }
    }
    public async Task<ContentResponse> DeleteContentAsync(int id, bool status)
    {
        try
        {
            var resp = await _contentRepository.GetByIdAsync(id);
            await _contentRepository.UpdateAsync(resp);
            var contentReferrence = _mapper.Map<Content>(resp);
            resp.isActive = status;
            return _mapper.Map<ContentResponse>(contentReferrence);
        }
        catch (Exception ex)
        {
            Exception exception = new OperationFailedException(UiMessage.CONTENT_DELETION_FAILED, ex);
            throw exception;
        }
    }
}
