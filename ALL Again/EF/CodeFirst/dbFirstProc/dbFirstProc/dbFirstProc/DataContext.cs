using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace dbFirstProc
{
   public class DataContext :DbContext
    {
       public DataContext()
           : base("SampledataEntities")
       {

       }
     public  DbSet<Employee> employeesdbset { get; set; }

     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         modelBuilder.Entity<Employee>().HasKey(p => p.Id);
         base.OnModelCreating(modelBuilder);
     }
    }
}
