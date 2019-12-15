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
    public partial class FormAddSubject : Form
    {
        public ExaminationController controller = ExaminationController.Instance;
        private bool updateMode { get; set; }
        private Subject selectedSubject { get; set; }
        public FormAddSubject(Subject selectedSubject = null, bool updateMode = false)
        {
            this.updateMode = updateMode;
            this.selectedSubject = selectedSubject;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject s = new Subject();
            if (updateMode == true)
            {
                s.Name = tbName.Text;
                s.ID = selectedSubject.ID;
                controller.UpdateSubject(s);
            }
            else
            {
                controller.AddSubject(tbName.Text);
            }
            
            this.Close();
        }

        private void FormAddSubject_Load(object sender, EventArgs e)
        {
            if (updateMode == true)
            {
                tbName.Text = selectedSubject.Name;
                button1.Text = "Обновить";
            }
        }
    }
}
