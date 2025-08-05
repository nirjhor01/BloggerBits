using System;
using BloggerBits.Database;
using BloggerBits.Entities;

namespace BloggerBits.Repositories.Categories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
  public CategoryRepository(ApplicationDbContext context) : base(context)
  {
  }
}
