using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace CodeFirst
{
    public class EmployeeDBContextSeeder : DropCreateDatabaseIfModelChanges<EmployeeContext>
    {
      protected override void Seed(EmployeeContext context)
      {
          Employee em = new Employee
          {
              FirstName = "sasa",
              LastName = "lala",
              Gender = "male",
              DepartmentId = 1,
              Salary = 500,
              City = "ksksk"
          };
          context.employees.Add(em);
         base.Seed(context);
      }
    }
}
