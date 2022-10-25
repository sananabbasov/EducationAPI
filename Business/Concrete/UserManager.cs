using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<List<UserListDTO>> GetAllUsers()
        {
            var users = _userDal.GetAllUsers();
            return new SuccessDataResult<List<UserListDTO>>(users);
        }

        public User GetUser(string email)
        {
            return _userDal.Get(x=>x.Email == email);
        }

        public IDataResult<UserListDTO> GetUserByEmail(string email)
        {
            var user = _userDal.Get(x => x.Email == email);

            if (user == null)
            {
                return new ErrorDataResult<UserListDTO>(Messages.UserNotFound);
            }

            UserListDTO result = new()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };

            return new SuccessDataResult<UserListDTO>(result);

        }

        public void RemoveUser(User user)
        {
           _userDal.Delete(user);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }
    }
}
