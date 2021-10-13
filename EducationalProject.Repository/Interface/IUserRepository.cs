using EducationalProject.Repository.DataAccess;
using EducationalProject.Repository.Entity;
using System.Collections.Generic;

namespace EducationalProject.Repository.Interface
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
