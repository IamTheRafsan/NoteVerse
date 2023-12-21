namespace NoteVerse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            quizBtn = new Button();
            toDoBtn = new Button();
            noteBtn = new Button();
            panel2 = new Panel();
            newBtn = new Button();
            notePanel1 = new Panel();
            deleteBtn = new Button();
            voiceBtn = new Button();
            saveBtn = new Button();
            stopBtn = new Button();
            noteSpace = new RichTextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(81, 187, 147);
            panel1.Controls.Add(quizBtn);
            panel1.Controls.Add(toDoBtn);
            panel1.Controls.Add(noteBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 1118);
            panel1.TabIndex = 0;
            // 
            // quizBtn
            // 
            quizBtn.BackColor = Color.FromArgb(81, 187, 147);
            quizBtn.FlatAppearance.BorderSize = 0;
            quizBtn.FlatStyle = FlatStyle.Flat;
            quizBtn.ForeColor = SystemColors.ButtonHighlight;
            quizBtn.Image = (Image)resources.GetObject("quizBtn.Image");
            quizBtn.ImageAlign = ContentAlignment.MiddleLeft;
            quizBtn.Location = new Point(3, 241);
            quizBtn.Name = "quizBtn";
            quizBtn.Padding = new Padding(16, 0, 0, 0);
            quizBtn.Size = new Size(380, 97);
            quizBtn.TabIndex = 3;
            quizBtn.Text = "              Quizes";
            quizBtn.TextAlign = ContentAlignment.MiddleLeft;
            quizBtn.UseVisualStyleBackColor = false;
            quizBtn.Click += button3_Click;
            // 
            // toDoBtn
            // 
            toDoBtn.BackColor = Color.FromArgb(81, 187, 147);
            toDoBtn.FlatAppearance.BorderSize = 0;
            toDoBtn.FlatStyle = FlatStyle.Flat;
            toDoBtn.ForeColor = SystemColors.ButtonHighlight;
            toDoBtn.Image = (Image)resources.GetObject("toDoBtn.Image");
            toDoBtn.ImageAlign = ContentAlignment.MiddleLeft;
            toDoBtn.Location = new Point(0, 126);
            toDoBtn.Name = "toDoBtn";
            toDoBtn.Padding = new Padding(20, 0, 0, 0);
            toDoBtn.Size = new Size(383, 97);
            toDoBtn.TabIndex = 2;
            toDoBtn.Text = "              To-Do";
            toDoBtn.TextAlign = ContentAlignment.MiddleLeft;
            toDoBtn.UseVisualStyleBackColor = false;
            toDoBtn.Click += button2_Click;
            // 
            // noteBtn
            // 
            noteBtn.FlatAppearance.BorderSize = 0;
            noteBtn.FlatStyle = FlatStyle.Flat;
            noteBtn.ForeColor = SystemColors.ButtonHighlight;
            noteBtn.Image = (Image)resources.GetObject("noteBtn.Image");
            noteBtn.ImageAlign = ContentAlignment.MiddleLeft;
            noteBtn.Location = new Point(0, 23);
            noteBtn.Name = "noteBtn";
            noteBtn.Padding = new Padding(20, 0, 0, 0);
            noteBtn.Size = new Size(383, 97);
            noteBtn.TabIndex = 1;
            noteBtn.Text = "              Note";
            noteBtn.TextAlign = ContentAlignment.MiddleLeft;
            noteBtn.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(newBtn);
            panel2.Controls.Add(notePanel1);
            panel2.Controls.Add(deleteBtn);
            panel2.Controls.Add(voiceBtn);
            panel2.Controls.Add(saveBtn);
            panel2.Controls.Add(stopBtn);
            panel2.Controls.Add(noteSpace);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(383, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1399, 1118);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // newBtn
            // 
            newBtn.BackColor = Color.Tomato;
            newBtn.ForeColor = SystemColors.ButtonHighlight;
            newBtn.Image = (Image)resources.GetObject("newBtn.Image");
            newBtn.Location = new Point(3, 3);
            newBtn.Name = "newBtn";
            newBtn.Size = new Size(518, 92);
            newBtn.TabIndex = 6;
            newBtn.Text = "New";
            newBtn.TextAlign = ContentAlignment.MiddleRight;
            newBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            newBtn.UseVisualStyleBackColor = false;
            newBtn.Click += newBtn_Click_1;
            // 
            // notePanel1
            // 
            notePanel1.AutoScroll = true;
            notePanel1.BackColor = SystemColors.Control;
            notePanel1.Location = new Point(6, 98);
            notePanel1.Name = "notePanel1";
            notePanel1.Size = new Size(515, 1017);
            notePanel1.TabIndex = 7;
            // 
            // deleteBtn
            // 
            deleteBtn.Image = (Image)resources.GetObject("deleteBtn.Image");
            deleteBtn.Location = new Point(649, 6);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(116, 86);
            deleteBtn.TabIndex = 3;
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // voiceBtn
            // 
            voiceBtn.Image = (Image)resources.GetObject("voiceBtn.Image");
            voiceBtn.Location = new Point(1274, 6);
            voiceBtn.Name = "voiceBtn";
            voiceBtn.Size = new Size(116, 86);
            voiceBtn.TabIndex = 0;
            voiceBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Image = (Image)resources.GetObject("saveBtn.Image");
            saveBtn.Location = new Point(527, 6);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(116, 86);
            saveBtn.TabIndex = 1;
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            stopBtn.Image = (Image)resources.GetObject("stopBtn.Image");
            stopBtn.Location = new Point(1152, 6);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(116, 86);
            stopBtn.TabIndex = 2;
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click_1;
            // 
            // noteSpace
            // 
            noteSpace.BorderStyle = BorderStyle.FixedSingle;
            noteSpace.Location = new Point(524, 98);
            noteSpace.Name = "noteSpace";
            noteSpace.Size = new Size(872, 1020);
            noteSpace.TabIndex = 2;
            noteSpace.Text = "";
            noteSpace.TextChanged += richTextBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1782, 1118);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button noteBtn;
        private Button toDoBtn;
        private Button quizBtn;
        private RichTextBox noteSpace;
        private Button voiceBtn;
        private Button saveBtn;
        private Button stopBtn;
        private Button newBtn;
        private Panel notePanel1;
        private Button deleteBtn;
    }
}
