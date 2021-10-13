using EducationalProject.Repository.DataAccess;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace EducationalProject.Repository.Repository
{
    public class UserRepository : EntityRepositoryBase<User, NorthWindContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthWindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
