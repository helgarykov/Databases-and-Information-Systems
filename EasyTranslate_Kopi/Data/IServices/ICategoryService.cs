using Data.Models;

namespace Data.IServices;

public interface ICategoryService
{
    public IEnumerable<Category> DetCategoryViaDapper();
}