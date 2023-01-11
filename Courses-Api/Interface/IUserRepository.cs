using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Courses_Api.ViewModel.Users;

namespace Courses_Api.Interface
{
    public interface IUserRepository
    {
        public Task<bool> AddUserAsync(User user);
         public Task<List<UserViewModel>> ListAllAdminsAsync();
        //public Task SetRoleAsync(User user, string role);
        //public Task<string> CreateJwtToken(User user);

    }
}