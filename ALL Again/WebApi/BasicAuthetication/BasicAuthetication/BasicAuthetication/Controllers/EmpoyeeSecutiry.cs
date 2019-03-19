using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace BasicAuthetication.Controllers
{
    public class EmpoyeeSecutiry
    {
        
        public static bool CheckLogin(string username, string password)
        {
            SampleEntities db = new SampleEntities();
        return    db.Users.Any(x => x.UserName == username && x.Password == password);

            
        }
    }
}