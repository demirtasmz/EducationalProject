using EducationalProject.Repository.Entity;
using System.Collections.Generic;

namespace EducationalProject.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
