using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BloggerBits.Entities;
[Table("Author")]
public class Author : BaseEntity
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    

    [NotMapped]
    public string slug
    {
        get
        {
            var name = Name.ToLowerInvariant();
            name = Regex.Replace(name, @"[^\p{L}\p{N}\s-]", "");
            name = Regex.Replace(name, @"\s+", " ").Trim();
            name = name.Replace(" ", "-");
            return name;
        }
    }
    ICollection<Content> Contents { get; set; } = new List<Content>();

}
