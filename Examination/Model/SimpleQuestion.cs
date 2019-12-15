using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Model
{

    public class SimpleQuestion : Question
    {
        public SimpleQuestion():base() { }
        public SimpleQuestion(string text, int complexity, Subject subj) :base( text,  complexity, subj) { }
    }
}
