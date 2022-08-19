using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Data;
using Courses_Api.ViewModel.Student;

namespace Courses_Api.Helpers.UserHelper
{
    public class UserHelper : IUserHelper
    {   
        private readonly EducationContext _context;
        public UserHelper(EducationContext context)
        {
            _context = context;
        }
        public int GetUserId()
        {
            return _context.Students.FirstOrDefault(x => x.IsLoggedIn).Id;
        }
 
        public StudentViewModel? LoggedInStudent()
        {
            var student = _context.Students.FirstOrDefault(x => x.IsLoggedIn);

            if (student is null)
                return null;

            var viewModel = new StudentViewModel
            {
                EmailAdress = student.EmailAdress,
                StudentName = student.Firstname
            };

            return viewModel;
        }
    }
}