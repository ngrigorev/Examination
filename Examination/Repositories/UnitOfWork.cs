using Examination.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Services
{
    public class UnitOfWork
    {
        private static UnitOfWork _instance;
        public static UnitOfWork Instance
        {
            get
            {
                if (_instance == null) _instance = new UnitOfWork();
                return _instance;
            }
            
        }
        private LocalStorage context;
        public SubjectRepository SubjectRepository;
        public QuestionsRepository QuestionsRepository;

        private UnitOfWork()
        {
            context = LocalStorage.Instance;
            SubjectRepository = new SubjectRepository(context);
            QuestionsRepository = new QuestionsRepository(context);
        }
    }
}
