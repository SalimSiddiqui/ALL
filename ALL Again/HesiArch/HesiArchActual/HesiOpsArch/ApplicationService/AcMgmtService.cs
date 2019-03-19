using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
namespace ApplicationService
{
    class AcMgmtService : IAcMgmtService
    {
        private readonly IExam _Exam;
        public AcMgmtService(IExam exam)
        {
            this._Exam = exam;
        }
        public void CreateOrUpdateProgram(string Examname)
        {

            _Exam.findExam(Examname);
        }

        
    }
}
