using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerBits.Entities;
[Table("Category")]
public class Category : BaseEntity
{
    public string Name { get; set; }
    // 🔁 Many-to-many navigation property
    public ICollection<Content> Contents { get; set; } = new List<Content>();

}
