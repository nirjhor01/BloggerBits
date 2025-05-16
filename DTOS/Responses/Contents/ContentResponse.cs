using System;

namespace BloggerBits.DTOS.Responses.Contents;

public class ContentResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }

    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public bool HasPdf { get; set; }




}
