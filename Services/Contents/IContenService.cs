using System;
using BloggerBits.Entities;
using BloggerBits.Models.Request;

namespace BloggerBits.Services.Contents;

public interface IContenService
{
      Task<Content> AddAsync(ContentRequest contentRequest);

}
