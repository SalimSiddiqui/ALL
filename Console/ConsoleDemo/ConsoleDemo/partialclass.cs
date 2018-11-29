using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
   partial class partialclass
    {
        partial  void print();
      
        public void print1()
        {

        }
    }
    partial class partialclass
    {
       partial void print()
        {

        }
    }
    // showing error (can use partial method within same partial classs ,not in other class)
    //partial class anothercalss
    //{
    //    partial void print()
    //    {

    //    }
    //}
}
