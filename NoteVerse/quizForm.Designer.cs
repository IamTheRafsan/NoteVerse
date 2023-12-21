namespace NoteVerse
{
    partial class quizForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            quizPanel1 = new Panel();
            goToQuiz = new Button();
            correctText = new TextBox();
            option4Text = new TextBox();
            option1Text = new TextBox();
            option3Text = new TextBox();
            option2Text = new TextBox();
            questionText = new TextBox();
            creatBtn = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            quizPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // quizPanel1
            // 
            quizPanel1.Controls.Add(goToQuiz);
            quizPanel1.Controls.Add(correctText);
            quizPanel1.Controls.Add(option4Text);
            quizPanel1.Controls.Add(option1Text);
            quizPanel1.Controls.Add(option3Text);
            quizPanel1.Controls.Add(option2Text);
            quizPanel1.Controls.Add(questionText);
            quizPanel1.Controls.Add(creatBtn);
            quizPanel1.Controls.Add(label7);
            quizPanel1.Controls.Add(label6);
            quizPanel1.Controls.Add(label5);
            quizPanel1.Controls.Add(label4);
            quizPanel1.Controls.Add(label3);
            quizPanel1.Controls.Add(label1);
            quizPanel1.Controls.Add(label2);
            quizPanel1.Dock = DockStyle.Fill;
            quizPanel1.Font = new Font("Segoe UI", 19F);
            quizPanel1.Location = new Point(0, 0);
            quizPanel1.Name = "quizPanel1";
            quizPanel1.Size = new Size(1399, 1118);
            quizPanel1.TabIndex = 0;
            // 
            // goToQuiz
            // 
            goToQuiz.BackColor = Color.FromArgb(0, 87, 255);
            goToQuiz.Font = new Font("Segoe UI", 10F);
            goToQuiz.ForeColor = SystemColors.ButtonHighlight;
            goToQuiz.Location = new Point(-3, 1037);
            goToQuiz.Name = "goToQuiz";
            goToQuiz.Size = new Size(1399, 78);
            goToQuiz.TabIndex = 15;
            goToQuiz.Text = "Go To Quizzes";
            goToQuiz.UseVisualStyleBackColor = false;
            goToQuiz.Click += goToQuiz_Click;
            // 
            // correctText
            // 
            correctText.Font = new Font("Segoe UI", 12F);
            correctText.Location = new Point(238, 680);
            correctText.Name = "correctText";
            correctText.Size = new Size(1112, 50);
            correctText.TabIndex = 14;
            // 
            // option4Text
            // 
            option4Text.Font = new Font("Segoe UI", 12F);
            option4Text.Location = new Point(238, 579);
            option4Text.Name = "option4Text";
            option4Text.Size = new Size(1112, 50);
            option4Text.TabIndex = 13;
            // 
            // option1Text
            // 
            option1Text.Font = new Font("Segoe UI", 12F);
            option1Text.Location = new Point(238, 278);
            option1Text.Name = "option1Text";
            option1Text.Size = new Size(1112, 50);
            option1Text.TabIndex = 12;
            // 
            // option3Text
            // 
            option3Text.Font = new Font("Segoe UI", 12F);
            option3Text.Location = new Point(238, 480);
            option3Text.Name = "option3Text";
            option3Text.Size = new Size(1112, 50);
            option3Text.TabIndex = 11;
            // 
            // option2Text
            // 
            option2Text.Font = new Font("Segoe UI", 12F);
            option2Text.Location = new Point(238, 380);
            option2Text.Name = "option2Text";
            option2Text.Size = new Size(1112, 50);
            option2Text.TabIndex = 10;
            // 
            // questionText
            // 
            questionText.Font = new Font("Segoe UI", 12F);
            questionText.Location = new Point(238, 179);
            questionText.Name = "questionText";
            questionText.Size = new Size(1112, 50);
            questionText.TabIndex = 9;
            // 
            // creatBtn
            // 
            creatBtn.BackColor = Color.FromArgb(204, 230, 255);
            creatBtn.Font = new Font("Segoe UI", 10F);
            creatBtn.ForeColor = SystemColors.ActiveCaptionText;
            creatBtn.Location = new Point(574, 810);
            creatBtn.Name = "creatBtn";
            creatBtn.Size = new Size(269, 69);
            creatBtn.TabIndex = 8;
            creatBtn.Text = "Create Quiz";
            creatBtn.UseVisualStyleBackColor = false;
            creatBtn.Click += creatBtn_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(23, 693);
            label7.Name = "label7";
            label7.Size = new Size(209, 37);
            label7.TabIndex = 7;
            label7.Text = "Correct Answer :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(41, 592);
            label6.Name = "label6";
            label6.Size = new Size(128, 37);
            label6.TabIndex = 6;
            label6.Text = "Option 4:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(43, 493);
            label5.Name = "label5";
            label5.Size = new Size(128, 37);
            label5.TabIndex = 5;
            label5.Text = "Option 3:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(41, 291);
            label4.Name = "label4";
            label4.Size = new Size(135, 37);
            label4.TabIndex = 4;
            label4.Text = "Option 1: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(43, 393);
            label3.Name = "label3";
            label3.Size = new Size(128, 37);
            label3.TabIndex = 3;
            label3.Text = "Option 2:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(41, 188);
            label1.Name = "label1";
            label1.Size = new Size(137, 37);
            label1.TabIndex = 2;
            label1.Text = "Question: ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(541, 40);
            label2.Name = "label2";
            label2.Size = new Size(328, 82);
            label2.TabIndex = 1;
            label2.Text = "  Make Quiz";
            label2.Click += label2_Click;
            // 
            // quizForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(quizPanel1);
            Name = "quizForm";
            Size = new Size(1399, 1118);
            quizPanel1.ResumeLayout(false);
            quizPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel quizPanel1;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button creatBtn;
        private Label label7;
        private TextBox questionText;
        private TextBox correctText;
        private TextBox option4Text;
        private TextBox option1Text;
        private TextBox option3Text;
        private TextBox option2Text;
        private Button goToQuiz;
    }
}
