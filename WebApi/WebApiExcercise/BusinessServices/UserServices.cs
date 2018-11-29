using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessServices
{
    public class UserServices : IUserServices
    {
        WebApiDbEntities db = new WebApiDbEntities();
        //  private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        //public UserServices(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string userName, string password)
        {
            User user = db.Users.Where(a => a.UserName.Equals(userName) && a.Password.Equals(password)).SingleOrDefault();
            if (user != null)
            {
                return user.UserId;
            }
            return 0;
        }
    }
}
