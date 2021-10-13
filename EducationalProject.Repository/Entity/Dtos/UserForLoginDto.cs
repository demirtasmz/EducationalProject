using EducationalProject.Repository.Abstract;

namespace EducationalProject.Repository.Entity.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
