using Examination.Controllers;
using Examination.Model;
using Examination.Services;
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
    public partial class Form1 : Form
    {
    
        ExaminationController controller = ExaminationController.Instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbSubjects.DataSource = controller.GetSubjects();
            //dgvQuestions.DataSource = controller.GetQuestions();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAddSubject();
            formAdd.ShowDialog();
            lbSubjects.DataSource = null;
            lbSubjects.DataSource = controller.GetSubjects();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var s = (Subject)lbSubjects.SelectedItem;
            if (s != null)
            {
                controller.RemoveSubject(s.ID);
                lbSubjects.DataSource = null;
                lbSubjects.DataSource = controller.GetSubjects();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null)
            {
                QuestionAddForm form = new QuestionAddForm(((Subject)lbSubjects.SelectedItem).ID);
                form.ShowDialog();
                int selected = ((Subject)lbSubjects.SelectedItem).ID;
                dgvQuestions.DataSource = null;
                dgvQuestions.DataSource = controller.GetQuestions(selected);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null)
            {
                int id = ((Question)dgvQuestions.SelectedCells[0].OwningRow.DataBoundItem).ID;
                controller.DeleteQuestion(id);
                int selected = ((Subject)lbSubjects.SelectedItem).ID;
                dgvQuestions.DataSource = null;
                dgvQuestions.DataSource = controller.GetQuestions(selected);
            }
        }

        private void lbSubjects_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null)
            {
                int selected = ((Subject)lbSubjects.SelectedItem).ID;
                dgvQuestions.DataSource = controller.GetQuestions(selected);
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null) {
                int selected = ((Subject)lbSubjects.SelectedItem).ID;
                FormPickExamOptions form = new FormPickExamOptions();
                form.ShowDialog();
                if (form.result == DialogResult.OK)
                {
                    controller.FormExam(selected, form.pCnt, form.qCnt, form.teacher, form.cafedral, form.course, form.semester, form.path);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null)
            {
                int selected = ((Subject)lbSubjects.SelectedItem).ID;
               
                    controller.FormTest(selected, "");
                
            }
        }

        private void dgvQuestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow != null)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow != null)
            {
                if (lbSubjects.SelectedItem != null)
                {
                    int selected = ((Subject)lbSubjects.SelectedItem).ID;
                    var q = (Question)dgvQuestions.CurrentRow.DataBoundItem;
                    QuestionAddForm form = new QuestionAddForm(selected, q, true);
                    form.ShowDialog();
                    dgvQuestions.DataSource = null;
                    dgvQuestions.DataSource = controller.GetQuestions(selected);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lbSubjects.SelectedItem != null)
            {
                var selected = (Subject)lbSubjects.SelectedItem;
                FormAddSubject form = new FormAddSubject(selected, true);
                form.ShowDialog();
                lbSubjects.DataSource = null;
                lbSubjects.DataSource = controller.GetSubjects();
            }
        }
    }
}
