using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Student;
using Courses_Api.ViewModel.Users;

namespace Courses_Api.Helpers.UserHelper
{
    public interface IUserHelper
    {
        string GetUserEmail();
        UserViewModel? LoggedInUser();
         StudentViewModel? LoggedInStudent();
    }
   
}