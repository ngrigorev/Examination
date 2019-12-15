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
    public partial class FormPickExamOptions : Form
    {
        public int qCnt { get; set; }
        public int pCnt { get; set; }
        public string teacher { get; set; }
        public string cafedral { get; set; }
        public int course { get; set; }
        public int semester { get; set; }
        public string path { get; set; }
        public DialogResult result { get; set; }
        public FormPickExamOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pCnt = Int32.Parse(textBox1.Text);
            this.qCnt = Int32.Parse(textBox2.Text);
            this.teacher = tbEkz.Text;
            this.cafedral = tbCaf.Text;
            this.course = Int32.Parse(tbCourse.Text);
            this.semester = Int32.Parse(tbSemester.Text);
            result = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                this.path = path;
                label7.Text = path;
            }
        }

        private void FormPickExamOptions_Load(object sender, EventArgs e)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            label7.Text = path;
        }
    }
}
