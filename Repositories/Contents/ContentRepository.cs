using System;
using BloggerBits.Database;
using BloggerBits.Entities;

namespace BloggerBits.Repositories.Contents;

public class ContentRepository : BaseRepository<Content>, IContentRepository
{
    public ContentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
