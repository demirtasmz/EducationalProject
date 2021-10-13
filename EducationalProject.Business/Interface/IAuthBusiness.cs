using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Entity.Dtos;
using EducationalProject.Utilities.Results;
using EducationalProject.Utilities.Security.Jwt;

namespace EducationalProject.Business.Interface
{
    public interface IAuthBusiness
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
