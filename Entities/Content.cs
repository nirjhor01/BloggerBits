using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BloggerBits.Entities;

public class Content : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    // Foreign key
    public int AuthorId { get; set; }

    // Navigation property

    [NotMapped]
    public string Route
    {
        get
        {
            var title = Title.ToLowerInvariant();
            title = Regex.Replace(title, @"[^\p{L}\p{N}\s-]", "");
            title = Regex.Replace(title, @"\s+", " ").Trim();
            title = title.Replace(" ", "-");
            return title;
        }
    }
}
