using EducationalProject.Repository.Entity;
using EducationalProject.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalProject.Business.Interface
{
    public interface IUserBusiness
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByMail(string email);
    }
}
