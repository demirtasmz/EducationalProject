using EducationalProject.Repository.Abstract;

namespace EducationalProject.Repository.Entity
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public short UnitsinStock { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
