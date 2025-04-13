using System;
using System.ComponentModel.DataAnnotations;
using BloggerBits.Entities;

namespace BloggerBits.Models.Request;

public class ContentRequest : BaseEntity
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public Author author { get; set; }

}
