using Examination.Model;
using Examination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination.Controllers
{
    public class ExaminationController
    {
        private UnitOfWork unit = UnitOfWork.Instance;
        private static ExaminationController _instance;
        public static ExaminationController Instance
        {
            get
            {
                if (_instance == null) _instance = new ExaminationController();
                return _instance;
            }
        }
        private ExaminationController() { }

        public List<Subject> GetSubjects()
        {
            return unit.SubjectRepository.GetAll();
        }
        public void RemoveSubject(int id)
        {
            unit.QuestionsRepository.DeleteAll(id);
            unit.SubjectRepository.Delete(id);
        }
        public void AddSubject(string Name)
        {
            var s = new Subject()
            {
                Name = Name
            };
            unit.SubjectRepository.Create(s);
        }
        public List<Question> GetQuestions(int ID)
        {
            return unit.QuestionsRepository.GetAll().Where(x => x.Subject.ID == ID).ToList();
        }
        public void AddQuestion(Question q)
        {
            unit.QuestionsRepository.Create(q);
        }
        public void DeleteQuestion(int id)
        {
            unit.QuestionsRepository.Delete(id);
        }
        public void UpdateQuestion(Question q)
        {
            unit.QuestionsRepository.Update(q);
        }
        public void UpdateSubject(Subject s)
        {
            unit.SubjectRepository.Update(s);
        }
        public void FormExam(int ID, int PaperCount, int QuestionsCount, string Teacher, string Cafedral, int course, int semester, string path)
        {
            string Subject = unit.SubjectRepository.Get(ID).Name;
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            winword.ShowAnimation = false;
            winword.Visible = false;
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            for (int i = 0; i < PaperCount; i++)
            {
                var exam = new Model.Exam();
                exam.Title = "Билет №" + (i + 1).ToString();
                
                var papers = exam.BuildQuestionList(GetQuestions(ID), QuestionsCount);
                
                //Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                
                //document.Content.SetRange(0, 0);

                var wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 12;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Font.Bold = 1;
                wp.Range.Text = "МИНОБРНАУКИ РОССИИ";
                wp.Range.ParagraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 12;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Федеральное государственное бюджетное \r\n образовательное учреждение высшего образования";
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Font.Bold = 1;
                wp.Range.Text = "«Ухтинский государственный технический университет» \r\n (УГТУ)";
                wp.Range.ParagraphFormat.SpaceAfter = 12;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Кафедра вычислительной техники, информационных систем и технологий";
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Дисциплина " + "«" + Subject + "»";
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Направление подготовки 09.03.02";
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                var dt = DateTime.Now;
                string str = "";
                if (dt.Month <= 6)
                {
                    str = $"{dt.Year - 1} - {dt.Year} учебный год";
                }
                else
                {
                    str = $"{dt.Year} - {dt.Year + 1} учебный год";
                }
                wp.Range.Text = str;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Форма обучения дневная";
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Курс " + course;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = "Семестр " + semester;
                wp.Range.ParagraphFormat.SpaceAfter = 12;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wp.Range.InsertParagraphAfter();


                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Font.Bold = 1;
                wp.Range.Text = exam.Title;
                wp.Range.ParagraphFormat.SpaceAfter = 24;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                for (int j = 0; j < QuestionsCount; j++)
                {
                    wp.Range.Font.Size = 14;
                    wp.Range.Font.Name = "Times New Roman";
                    wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    wp.Range.ParagraphFormat.SpaceAfter = 0;
                    wp.Range.ParagraphFormat.Space15();
                    wp.Range.InsertBefore($"{j + 1}. {papers[j]} \r\n");
                }

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";  
                wp.Range.Text = $"Экзаменатор _____________ " + Teacher;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.ParagraphFormat.SpaceBefore = 24;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Space15();
                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = $"Зав. кафедрой _____________ " + Cafedral;
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.ParagraphFormat.SpaceBefore = 0;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.ParagraphFormat.Space15();

                wp.Range.InsertParagraphAfter();

                wp = document.Paragraphs.Add(Type.Missing);
                wp.Range.Font.Size = 14;
                wp.Range.Font.Name = "Times New Roman";
                wp.Range.Text = $"Утверждено на заседании кафедры протокол № ___ от ___________г";
                wp.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wp.Range.ParagraphFormat.Space15();
                wp.Range.ParagraphFormat.SpaceBefore = 0;
                wp.Range.ParagraphFormat.SpaceAfter = 0;
                wp.Range.InsertParagraphAfter();
                if (i != PaperCount - 1)
                    wp.Range.InsertBreak();
            }

            object filename = $"{path}\\{Subject} {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}.docx";
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
            MessageBox.Show("Экзамен успешно создан!");
        }


        public void FormTest(int ID, string path)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            
            excelApp.Visible = true;
            var book = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;
            Thread.Sleep(4000);
            var subject = unit.SubjectRepository.Get(ID).Name;
            List<Question> questions = GetQuestions(ID);
            sheet.Cells[1, 1] = subject;
            for (int i = 1; i <= questions.Count; i++)
            {
                sheet.Cells[i + 1, 1] = i;
                sheet.Cells[i + 1, 2] = questions[i - 1].ToString();
            } 
            MessageBox.Show("Тест успешно создан!");
        }
    }
}