using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BloggerBits.Entities.Auth;

namespace BloggerBits.Entities;
[Table("Category")]
public class Category : BaseEntity
{

    [Required]
    [MaxLength(64)]
    public required string Name { get; set; }
    // 🔁 Many-to-many navigation property
    public virtual ICollection<ContentCategories> ContentCategories { get; set; }

}
