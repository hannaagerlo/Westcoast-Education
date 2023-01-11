using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Data;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.Users;

namespace Courses_Api.Helpers.UserHelper
{
    public class UserHelper : IUserHelper
    {   
        private readonly EducationContext _context;
        public UserHelper(EducationContext context)
        {
            _context = context;
        }
        public string GetUserEmail()
        {
            return _context.Users.FirstOrDefault(x => x.IsLoggedIn).Email;
        }

          public StudentViewModel? LoggedInStudent()
        {
            var student = _context.Students.FirstOrDefault(x => x.IsLoggedIn);

            if (student is null)
                return null;

            var viewModel = new StudentViewModel
            {
                StudentId = student.Id,
                Email = student.Email
            };

            return viewModel;
        }
 
        public UserViewModel? LoggedInUser()
        {
            var user = _context.Users.FirstOrDefault(x => x.IsLoggedIn);

            if (user is null)
                return null;

            var viewModel = new UserViewModel
            {
                UserId = user.Id,
                Email = user.Email
            };

            return viewModel;
        }
    }
}