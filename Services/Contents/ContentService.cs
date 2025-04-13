using System;
using AutoMapper;
using BloggerBits.Entities;
using BloggerBits.Models.Request;
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

    public async Task<Content> AddAsync(ContentRequest contentRequest)
    {
         var contentEntity = _mapper.Map<Content>(contentRequest);
        
          await _contentRepository.AddAsync(contentEntity);
          await _contentRepository.SaveChangesAsync();
          return contentEntity;
    }
        
}
