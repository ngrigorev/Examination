using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Services;
namespace Examination.Model
{
    public class Exam : Paper
    {
        public List<Question> BuildQuestionList(List<Question> Questions, int QuestionsCount)
        {
            int avg = (int)Math.Round(Questions.Average(x => x.Complexity) * QuestionsCount);
            int appSum = 0;
            List<Question> result = new List<Question>();
            Questions.Shuffle();
            for (int i = 0; i <= Questions.Count - QuestionsCount; i++)
            {
                int sum = Questions.Skip(i).Take(QuestionsCount).Sum(x => x.Complexity);
                int eta = Math.Abs(avg - appSum);
                int newEta = Math.Abs(avg - sum);
                if (newEta <= eta)
                {
                    appSum = sum;
                    result = Questions.Skip(i).Take(QuestionsCount).ToList();
                }                
            }
           
            return result;
        }
    }
}
