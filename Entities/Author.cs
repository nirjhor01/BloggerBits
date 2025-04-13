using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BloggerBits.Entities;
public class Author: BaseEntity
{
    public string Title{get;set;}
    [NotMapped]
    public string Route
    {
        get
        {
            var title = Title.ToLowerInvariant();

            // Replace any character that is not a letter, number, space, or dash.
            // This regex is modified to allow Unicode letters (for Bengali and other scripts).
            title = Regex.Replace(title, @"[^\p{L}\p{N}\s-]", "");

            // Replace multiple spaces with a single space
            title = Regex.Replace(title, @"\s+", " ").Trim();

            // Replace spaces with dashes
            title = title.Replace(" ", "-");

            return title;
        }
    }

}
