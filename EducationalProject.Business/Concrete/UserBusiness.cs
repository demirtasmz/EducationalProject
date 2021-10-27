using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Interface;
using EducationalProject.Utilities.Results;
using System;
using System.Collections.Generic;

namespace EducationalProject.Business.Concrete
{
    public class UserBusiness : IUserBusiness
    {
        IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }
         
        public IResult Add(User user)
        {
            try
            {
                _userRepository.Add(user);
                return new SuccessResult("Kullanıcı Eklendi");
            }
            catch (Exception)
            {
                return new ErrorResult("Kullanıcı Eklenmedi");
            }
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }
    }
}
