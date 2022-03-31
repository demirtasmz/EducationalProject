using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Entity.Dtos;
using EducationalProject.Utilities.Logging;
using EducationalProject.Utilities.Results;
using EducationalProject.Utilities.Security.Hashing;
using EducationalProject.Utilities.Security.Jwt;

namespace EducationalProject.Business.Concrete
{
    public class AuthBusiness : IAuthBusiness
    {
        private IUserBusiness _userBusiness;
        private ITokenHelper _tokenHelper;

        public AuthBusiness(IUserBusiness userService, ITokenHelper tokenHelper)
        {
            _userBusiness = userService;
            _tokenHelper = tokenHelper;
        }
        [Log]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userBusiness.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı başarıyla eklendi");
        }
        [Log]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userBusiness.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Girdiğiniz şifre hatalı");
            }

            return new SuccessDataResult<User>(userToCheck,"Giriş başarıyla sağlandı");
        }
        [Log]
        public IResult UserExists(string email)
        {
            if (_userBusiness.GetByMail(email) != null)
            {
                return new ErrorResult("Bu email zaten kullanılıyor");
            }
            return new SuccessResult();
        }
        [Log]
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userBusiness.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Oluşturuldu");
        }
    }
}
