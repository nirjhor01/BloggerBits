using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BloggerBits.Entities;
using BloggerBits.Entities.Auth;
using Unidecode.NET;
[Table("Content")]
public class Content : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public required string Title { get; set; }
    public required string Description { get; set; }
    
    [ForeignKey(nameof(Author))]
    [Required]
    public required int AuthorId { get; set; }

    public Author Author { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public bool HasPdf { get; set; }

    // Navigation property to Category

    [NotMapped]
    public string Slug
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
    // One Content can belong to one Author
    public void Publish() => (IsPublished, PublishedAt) = (true, DateTime.UtcNow);
    public void Unpublish() => (IsPublished, PublishedAt) = (false, null);
    public void Update() => UpdatedAt = DateTime.UtcNow;
    public void MarkAsHavingPdf() => HasPdf = true;
    public void RemovePdf() => HasPdf = false;
    //many to many
    public virtual ICollection<ContentCategories> ContentCategories { get; set; }
}
