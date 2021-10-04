using EducationalProject.Repository.DataAccess;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Interface;

namespace EducationalProject.Repository.Repository
{
    public class CategoryRepository : EntityRepositoryBase<Category, NorthWindContext>, ICategoryRepository
    {

    }
}
