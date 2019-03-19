using System.Collections.Generic;
using Core;



namespace Service
{
    public interface IExamInterface
    {
        void SaveExamData();        
        List<Exam> DisplayExamData();

    }
}
