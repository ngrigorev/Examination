using Examination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Model
{
    [Serializable]
    public class Subject : Identity
    {
        public string Name { get; set; }

        public Subject()
        {
            ID = (int)IDIncrementer.GetNextSubjectID();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
