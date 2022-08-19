using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.ViewModel.Student;

namespace Courses_Api.Helpers.UserHelper
{
    public interface IUserHelper
    {
        int GetUserId();
         StudentViewModel? LoggedInStudent();
    }
   
}