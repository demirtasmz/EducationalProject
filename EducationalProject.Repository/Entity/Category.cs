using EducationalProject.Repository.Abstract;

namespace EducationalProject.Repository.Entity
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
