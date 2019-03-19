using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst
{
   public class EmployeeRepository 
    {
       public List<Department> GetDepartment()
       {
           EmployeeContext db = new EmployeeContext();
           return db.departments.Include("employees").ToList();
       }
    }
}
