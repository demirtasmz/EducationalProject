using EducationalProject.Repository.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EducationalProject.Repository.Entity.Dtos
{
    public class UserForLoginDto : IDto
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
