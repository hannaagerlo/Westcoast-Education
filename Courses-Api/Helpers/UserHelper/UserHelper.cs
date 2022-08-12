using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Data;

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
    }
}