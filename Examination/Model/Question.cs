using Examination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Model
{
    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(SimpleQuestion))]
    [System.Xml.Serialization.XmlInclude(typeof(TestQuestion))]
    public abstract class Question : Identity
    {
        public Question()
        {
            ID = (int)IDIncrementer.GetNextQuestionID();
        }
        public Question(string text, int complexity, Subject subj)
        {
            ID = (int)IDIncrementer.GetNextQuestionID();
            Text = text;
            Complexity = complexity;
            Subject = subj;
        }
        public string Text { get; set; }
        public int Complexity { get; set; }
        public Subject Subject { get; set; }
        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
