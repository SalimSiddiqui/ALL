using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Service;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ExamData : IExamInterface
    {
        public List<Exam> DisplayExamData()
        {
            
            List<Exam> list = new List<Exam>();
            list.Add(new Exam { Id = 1, Name = "Intermediate", Description = "Intermediate" });
            list.Add(new Exam { Id = 2, Name = "Intermediate", Description = "Intermediate" });
            return list;
            //DB.GetDA("select * from Hoa_Exam");
        }

        public void SaveExamData()
        {
            throw new NotImplementedException();
        }
    }
}
