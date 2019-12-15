using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.Model;
namespace Examination.Services.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private LocalStorage context;
        public SubjectRepository(LocalStorage context)
        {
            this.context = context;
        }
        public void Create(Subject item)
        {
            context.subjects.Add(item);
            context.Apply();
        }

        public void Delete(int id)
        {
            var subj = context.subjects.First(x => x.ID == id);
            context.subjects.Remove(subj);
            context.Apply();
        }
       

        public Subject Get(int id)
        {
            return context.subjects.First(x => x.ID == id);
        }

        public List<Subject> GetAll()
        {
            return context.subjects;
        }

        public void Update(Subject item)
        {
            var subj = context.subjects.RemoveAll(x => x.ID == item.ID);
            context.subjects.Add(item);
            context.subjects = context.subjects.OrderBy(x => x.ID).ToList();
            context.Apply();
        }
    }
}
