using EducationalProject.Repository.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EducationalProject.Repository.Entity.Dtos
{
    public class UserForRegisterDto : IDto
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
