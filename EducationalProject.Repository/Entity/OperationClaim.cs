using EducationalProject.Repository.Abstract;

namespace EducationalProject.Repository.Entity
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
