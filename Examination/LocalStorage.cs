using Examination.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Examination.Services
{
    
    public class LocalStorage
    {

        private static LocalStorage _instance;
        private LocalStorage() {
            subjects = LoadFromXml<List<Subject>>(sFilename);
            questions = LoadFromXml<List<Question>>(qFilename);
            if (questions != null)
            {
                if (questions.Count > 0)
                {
                    int qID = questions.Max(x => x.ID);
                    IDIncrementer.SetQuestionID(qID + 1);
                }
            }
            else
            {
                questions = new List<Question>();
            }
            if (subjects != null) { 
                if (subjects.Count > 0)
                {
                    int sID = subjects.Max(x => x.ID);
                    IDIncrementer.SetSubjectID(sID + 1);
                }
            }
            else
            {
                subjects = new List<Subject>();
            }

        }

        private void SaveToXml<T>(T obj, string filename)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings
                {
                    Encoding = Encoding.Unicode,
                    Indent = true
                }
                ))
                {
                    xsSubmit.Serialize(writer, obj);
                    xml = sww.ToString();
                    File.WriteAllText(filename, xml);
                }
            }
        }
        private T LoadFromXml<T>(string filename)
        {
            if (!File.Exists(filename))
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                var xml = "";
                var obj = Activator.CreateInstance<T>();
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings
                    {
                        Encoding = Encoding.Unicode,
                        Indent = true
                    }
                    ))
                    {
                        xsSubmit.Serialize(writer, obj);
                        xml = sww.ToString();
                        File.WriteAllText(filename, xml);
                    }
                }
            }

            using (StreamReader sr = new StreamReader(filename, true))
            {
                try
                {
                    
                    XDocument xdoc = XDocument.Load(sr);
                    XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                    
                    return (T)xsSubmit.Deserialize(xdoc.CreateReader());
                }
                catch
                {
                    return default(T);
                }
                
            }
        }
        public void Apply()
        {
            SaveToXml<List<Question>>(questions, qFilename);
            SaveToXml<List<Subject>>(subjects, sFilename);
        }

        public static LocalStorage Instance
        {
            get
            {
                if (_instance == null) _instance = new LocalStorage();
                return _instance;
            }
        }

        public List<Subject> subjects { get; set; }
        public List<Question> questions { get; set; }

        private string qFilename => @".\questions.xml";
        private string sFilename => @".\subjects.xml";
    }
}
