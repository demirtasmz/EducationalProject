using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authService)
        {
            _authBusiness = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authBusiness.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authBusiness.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authBusiness.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authBusiness.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authBusiness.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
