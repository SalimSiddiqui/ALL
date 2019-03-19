using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst
{
  public  class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

     public   List<Employee> employees { get; set; }    
    }
}
