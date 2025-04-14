using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BloggerBits.Entities;
using Unidecode.NET;
[Table("Content")]
public class Content : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public bool HasPdf { get; set; }

    // Navigation property to Category

    [NotMapped]
    public string slug
    {
        get
        {
            var transliterated = Title?.Unidecode() ?? string.Empty;
            transliterated = transliterated.ToLowerInvariant();
            transliterated = Regex.Replace(transliterated, @"[^\p{L}\p{N}\s-]", ""); // remove punctuation
            transliterated = Regex.Replace(transliterated, @"\s+", " ").Trim();     // normalize space
            return transliterated.Replace(" ", "-");
        }
    }
    public Author Author { get; set; }  // One Content can belong to one Author
    //many to many
    ICollection<Category> Categories { get; set; } = new List<Category>();
    public void Publish() => (IsPublished, PublishedAt) = (true, DateTime.UtcNow);
    public void Unpublish() => (IsPublished, PublishedAt) = (false, null);
    public void Update() => UpdatedAt = DateTime.UtcNow;
    public void MarkAsHavingPdf() => HasPdf = true;
    public void RemovePdf() => HasPdf = false;
}
