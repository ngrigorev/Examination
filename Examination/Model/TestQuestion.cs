using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Model
{
    public class TestQuestion : Question
    {
        public List<string> options { get; set; }
        public TestQuestion():base() { }
        public TestQuestion(List<string> opts, string text, int complexity, Subject subj) : base( text,  complexity,  subj) {
            options = opts;
        }
        public override string ToString()
        {
            string answersText = "";
            int i = 1;
            foreach (var option in options)
            {
                if (i != options.Count())
                    answersText += $"    {i}) {option}; \n";
                else
                    answersText += $"    {i}) {option}.";
                i++;
            }
            return $"{base.ToString()} \nВарианты ответов:\n{answersText}";
        }

    }
}
