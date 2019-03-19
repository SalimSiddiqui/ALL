using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace CodeFirst
{
    public class EmployeeContext :DbContext

    {
     public   DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
