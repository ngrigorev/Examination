using Examination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Services.Repositories
{
    public class QuestionsRepository : IRepository<Question>
    {
        private LocalStorage context;

        public QuestionsRepository(LocalStorage context)
        {
            this.context = context;
        }

        public void Create(Question item)
        {
            this.context.questions.Add(item);
            context.Apply();
        }

        public void Delete(int id)
        {
            var item = this.context.questions.First(x => x.ID == id);
            context.questions.Remove(item);
            context.Apply();
        }
        public void DeleteAll(int ID)
        {
            context.questions.RemoveAll(x => x.Subject.ID == ID);
            context.Apply();
        }
        public Question Get(int id)
        {
            return this.context.questions.First(x => x.ID == id);
        }

        public List<Question> GetAll()
        {
            return this.context.questions;
        }

        public void Update(Question item)
        {
            var subj = context.questions.RemoveAll(x => x.ID == item.ID);
            context.questions.Add(item);
            context.questions = context.questions.OrderBy(x => x.ID).ToList();
            
            context.Apply();
        }
    }
}
