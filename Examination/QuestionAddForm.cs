using Examination.Controllers;
using Examination.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination
{
    public partial class QuestionAddForm : Form
    {
        ExaminationController controller = ExaminationController.Instance;
        int selectedSubject = 0;
        Question q { get; set; }
        bool updateMode { get; set; }
        
        public QuestionAddForm(int selectedSubject = 0, Question q = null, bool updateMode = false)
        {
            this.selectedSubject = selectedSubject;
            this.updateMode = updateMode;
            this.q = q;
            InitializeComponent();     
        }

        private void QuestionAddForm_Load(object sender, EventArgs e)
        {
            cbSubjects.DataSource = controller.GetSubjects();
            cbSubjects.SelectedItem = controller.GetSubjects().Where(x => x.ID == selectedSubject).First();
            if (q != null)
            {
                tbText.Text = q.Text;
                rbVeryEz.Checked = q.Complexity == 1;
                rbEz.Checked = q.Complexity == 2;
                rbMiddle.Checked = q.Complexity == 3;
                rbHard.Checked = q.Complexity == 4;
                rbHardcore.Checked = q.Complexity == 5;
                if (q is TestQuestion)
                {
                    foreach(var i in (q as TestQuestion).options)
                    {
                        lbOptions.Items.Add(i);
                    }
                }
                if (updateMode)
                {
                    bAdd.Text = "Обновить";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOptionForm form = new AddOptionForm();
            form.ShowDialog();
            if (form.optionName != null)
                lbOptions.Items.Add(form.optionName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbOptions.Items.Remove(lbOptions.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = tbText.Text;
            Subject subj = cbSubjects.SelectedItem as Subject;
            int complexity = rbVeryEz.Checked ? 1 : rbEz.Checked ? 2 : rbMiddle.Checked ? 3 : rbHard.Checked ? 4 : rbHardcore.Checked ? 5 : 0;
            Question q;
            if (lbOptions.Items.Count > 0)
            {
                List<string> strings = new List<string>();
                foreach (var t in lbOptions.Items)
                {
                    strings.Add(t.ToString());
                }
                q = new TestQuestion(strings, text, complexity, subj);
            }
            else
            {
                q = new SimpleQuestion(text, complexity, subj);
            }
            if (updateMode == false)
                controller.AddQuestion(q);
            else
            {
                q.ID = this.q.ID;
                controller.UpdateQuestion(q);
            }
                
            Close();
        }
    }
}
