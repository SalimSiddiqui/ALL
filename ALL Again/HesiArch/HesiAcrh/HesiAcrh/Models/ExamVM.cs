using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HesiAcrh.Models
{
    public class ExamVM
    {
        public class Exam
        {

            public int Id
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public string Description
            {
                get;
                set;
            }
        }
    }
}