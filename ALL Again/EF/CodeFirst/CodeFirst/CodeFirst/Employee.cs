using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst
{
  public  class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int  Salary { get; set; }
        
        public int DepartmentId { get; set; }
        public string City { get; set; }
          [ForeignKey("DepartmentId")]
        public Department department { get; set; }
    }
}
