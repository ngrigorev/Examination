using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Services
{
    public static class IDIncrementer
    {
        private static long SubjectID = 1;
        private static long QuestionID = 1;

        public static long GetNextSubjectID()
        {
            return SubjectID++;
        }
        public static void SetSubjectID(int id)
        {
            SubjectID = id;
        }
        public static void SetQuestionID(int id)
        {
            QuestionID = id;
        }
        public static long GetNextQuestionID()
        {
            return QuestionID++;
        }
    }
}
