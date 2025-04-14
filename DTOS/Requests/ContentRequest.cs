using System;

namespace BloggerBits.DTOS.Requests;

public class ContentRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public List<int> CategoryIds { get; set; } = new();

}
