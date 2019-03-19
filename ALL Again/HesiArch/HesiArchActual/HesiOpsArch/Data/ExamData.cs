using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;


namespace Data
{
    public class ExamData : IExam
    {
        public IEnumerable<Exam> findExam(string ExamName)
        {
            SampleEntities db = new SampleEntities();
            return db.Exams.Where(a => a.Name.Equals(ExamName));
        }

        
    }
}
