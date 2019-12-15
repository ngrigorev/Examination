namespace Examination
{
    partial class QuestionAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.rbVeryEz = new System.Windows.Forms.RadioButton();
            this.rbEz = new System.Windows.Forms.RadioButton();
            this.rbMiddle = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbHardcore = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbOptions = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(111, 19);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(436, 106);
            this.tbText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Текст вопроса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дисциплина";
            // 
            // cbSubjects
            // 
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Location = new System.Drawing.Point(111, 152);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(246, 21);
            this.cbSubjects.TabIndex = 5;
            // 
            // rbVeryEz
            // 
            this.rbVeryEz.AutoSize = true;
            this.rbVeryEz.Location = new System.Drawing.Point(111, 204);
            this.rbVeryEz.Name = "rbVeryEz";
            this.rbVeryEz.Size = new System.Drawing.Size(88, 17);
            this.rbVeryEz.TabIndex = 0;
            this.rbVeryEz.TabStop = true;
            this.rbVeryEz.Text = "Очень легко";
            this.rbVeryEz.UseVisualStyleBackColor = true;
            // 
            // rbEz
            // 
            this.rbEz.AutoSize = true;
            this.rbEz.Location = new System.Drawing.Point(202, 204);
            this.rbEz.Name = "rbEz";
            this.rbEz.Size = new System.Drawing.Size(56, 17);
            this.rbEz.TabIndex = 1;
            this.rbEz.TabStop = true;
            this.rbEz.Text = "Легко";
            this.rbEz.UseVisualStyleBackColor = true;
            // 
            // rbMiddle
            // 
            this.rbMiddle.AutoSize = true;
            this.rbMiddle.Location = new System.Drawing.Point(264, 204);
            this.rbMiddle.Name = "rbMiddle";
            this.rbMiddle.Size = new System.Drawing.Size(62, 17);
            this.rbMiddle.TabIndex = 2;
            this.rbMiddle.TabStop = true;
            this.rbMiddle.Text = "Средне";
            this.rbMiddle.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(332, 204);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(64, 17);
            this.rbHard.TabIndex = 3;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "Сложно";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbHardcore
            // 
            this.rbHardcore.AutoSize = true;
            this.rbHardcore.Location = new System.Drawing.Point(402, 204);
            this.rbHardcore.Name = "rbHardcore";
            this.rbHardcore.Size = new System.Drawing.Size(97, 17);
            this.rbHardcore.TabIndex = 4;
            this.rbHardcore.TabStop = true;
            this.rbHardcore.Text = "Очень сложно";
            this.rbHardcore.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сложность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Варианты ответов (оставьте пустым если нету)";
            // 
            // lbOptions
            // 
            this.lbOptions.Location = new System.Drawing.Point(276, 252);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(120, 134);
            this.lbOptions.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(402, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Crimson;
            this.button2.Location = new System.Drawing.Point(402, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 43);
            this.button2.TabIndex = 10;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(244, 440);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(113, 41);
            this.bAdd.TabIndex = 11;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.button3_Click);
            // 
            // QuestionAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 503);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbOptions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbHardcore);
            this.Controls.Add(this.rbHard);
            this.Controls.Add(this.rbMiddle);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.rbEz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbVeryEz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbText);
            this.Name = "QuestionAddForm";
            this.Text = "QuestionAddForm";
            this.Load += new System.EventHandler(this.QuestionAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubjects;
        private System.Windows.Forms.RadioButton rbVeryEz;
        private System.Windows.Forms.RadioButton rbEz;
        private System.Windows.Forms.RadioButton rbMiddle;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbHardcore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bAdd;
    }
}