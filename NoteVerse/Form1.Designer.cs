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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            voiceBtn = new Button();
            saveBtn = new Button();
            stopBtn = new Button();
            noteSpace = new RichTextBox();
            newBtn = new Button();
            notePanel1 = new Panel();
            deleteBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(81, 187, 147);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 1118);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(81, 187, 147);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(3, 241);
            button3.Name = "button3";
            button3.Padding = new Padding(16, 0, 0, 0);
            button3.Size = new Size(380, 97);
            button3.TabIndex = 3;
            button3.Text = "              Quizes";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(81, 187, 147);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 126);
            button2.Name = "button2";
            button2.Padding = new Padding(20, 0, 0, 0);
            button2.Size = new Size(383, 97);
            button2.TabIndex = 2;
            button2.Text = "              To-Do";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 23);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(383, 97);
            button1.TabIndex = 1;
            button1.Text = "              Note";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(deleteBtn);
            panel2.Controls.Add(voiceBtn);
            panel2.Controls.Add(saveBtn);
            panel2.Controls.Add(stopBtn);
            panel2.Controls.Add(noteSpace);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(898, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(884, 1118);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // voiceBtn
            // 
            voiceBtn.Image = (Image)resources.GetObject("voiceBtn.Image");
            voiceBtn.Location = new Point(765, 6);
            voiceBtn.Name = "voiceBtn";
            voiceBtn.Size = new Size(116, 86);
            voiceBtn.TabIndex = 0;
            voiceBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Image = (Image)resources.GetObject("saveBtn.Image");
            saveBtn.Location = new Point(3, 6);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(116, 86);
            saveBtn.TabIndex = 1;
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            stopBtn.Image = (Image)resources.GetObject("stopBtn.Image");
            stopBtn.Location = new Point(643, 6);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(116, 86);
            stopBtn.TabIndex = 2;
            stopBtn.UseVisualStyleBackColor = true;
            // 
            // noteSpace
            // 
            noteSpace.BorderStyle = BorderStyle.FixedSingle;
            noteSpace.Location = new Point(0, 98);
            noteSpace.Name = "noteSpace";
            noteSpace.Size = new Size(884, 1020);
            noteSpace.TabIndex = 2;
            noteSpace.Text = "";
            noteSpace.TextChanged += richTextBox1_TextChanged;
            // 
            // newBtn
            // 
            newBtn.BackColor = Color.Tomato;
            newBtn.Dock = DockStyle.Top;
            newBtn.ForeColor = SystemColors.ButtonHighlight;
            newBtn.Image = (Image)resources.GetObject("newBtn.Image");
            newBtn.Location = new Point(383, 0);
            newBtn.Name = "newBtn";
            newBtn.Size = new Size(515, 92);
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
            notePanel1.Location = new Point(383, 93);
            notePanel1.Name = "notePanel1";
            notePanel1.Size = new Size(515, 1025);
            notePanel1.TabIndex = 7;
            // 
            // deleteBtn
            // 
            deleteBtn.Image = (Image)resources.GetObject("deleteBtn.Image");
            deleteBtn.Location = new Point(125, 6);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(116, 86);
            deleteBtn.TabIndex = 3;
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1782, 1118);
            Controls.Add(newBtn);
            Controls.Add(notePanel1);
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
        private Button button1;
        private Button button2;
        private Button button3;
        private RichTextBox noteSpace;
        private Button voiceBtn;
        private Button saveBtn;
        private Button stopBtn;
        private Button newBtn;
        private Panel notePanel1;
        private Button deleteBtn;
    }
}
