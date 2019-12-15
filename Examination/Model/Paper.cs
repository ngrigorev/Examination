using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Model
{
    public abstract class Paper
    {
        public List<Question> Questions { get; set; }
        public string Title { get; set; }
    }
}
