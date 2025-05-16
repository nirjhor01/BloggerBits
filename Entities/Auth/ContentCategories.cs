using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggerBits.Entities.Auth;

[Table("ContentCategories")]
public class ContentCategories: BaseEntity
{
    [ForeignKey("content")]
    public int ContentId { get; set; }
    [ForeignKey("category")]
    public int CategoryId { get; set; }

    public Content content;
    public Category category;

}
