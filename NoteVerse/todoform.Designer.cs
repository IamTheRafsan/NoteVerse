namespace NoteVerse
{
    partial class todoform
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
            toDoPanel = new Panel();
            panel2 = new Panel();
            toDoCreate = new Button();
            toDoTime = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            toDoDate = new DateTimePicker();
            toDoName = new TextBox();
            jj = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toDoPanel
            // 
            toDoPanel.BackColor = Color.FromArgb(204, 230, 255);
            toDoPanel.ForeColor = Color.White;
            toDoPanel.Location = new Point(3, 0);
            toDoPanel.Name = "toDoPanel";
            toDoPanel.Size = new Size(547, 1118);
            toDoPanel.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(toDoCreate);
            panel2.Controls.Add(toDoTime);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(toDoDate);
            panel2.Controls.Add(toDoName);
            panel2.Controls.Add(jj);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(556, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(843, 1118);
            panel2.TabIndex = 1;
            // 
            // toDoCreate
            // 
            toDoCreate.BackColor = Color.FromArgb(204, 230, 255);
            toDoCreate.ForeColor = Color.Black;
            toDoCreate.Location = new Point(200, 571);
            toDoCreate.Name = "toDoCreate";
            toDoCreate.Size = new Size(458, 74);
            toDoCreate.TabIndex = 6;
            toDoCreate.Text = "Create";
            toDoCreate.UseVisualStyleBackColor = false;
            // 
            // toDoTime
            // 
            toDoTime.Format = DateTimePickerFormat.Time;
            toDoTime.Location = new Point(265, 474);
            toDoTime.Name = "toDoTime";
            toDoTime.Size = new Size(393, 39);
            toDoTime.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 481);
            label2.Name = "label2";
            label2.Size = new Size(67, 32);
            label2.TabIndex = 4;
            label2.Text = "Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 403);
            label1.Name = "label1";
            label1.Size = new Size(64, 32);
            label1.TabIndex = 3;
            label1.Text = "Date";
            // 
            // toDoDate
            // 
            toDoDate.Format = DateTimePickerFormat.Short;
            toDoDate.Location = new Point(265, 396);
            toDoDate.Name = "toDoDate";
            toDoDate.Size = new Size(393, 39);
            toDoDate.TabIndex = 2;
            // 
            // toDoName
            // 
            toDoName.Location = new Point(265, 321);
            toDoName.Name = "toDoName";
            toDoName.Size = new Size(393, 39);
            toDoName.TabIndex = 1;
            // 
            // jj
            // 
            jj.AutoSize = true;
            jj.Location = new Point(181, 328);
            jj.Name = "jj";
            jj.Size = new Size(78, 32);
            jj.TabIndex = 0;
            jj.Text = "Name";
            jj.Click += label1_Click;
            // 
            // todoform
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(toDoPanel);
            Name = "todoform";
            Size = new Size(1399, 1118);
            Load += todoform_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label jj;
        private TextBox toDoName;
        private DateTimePicker toDoTime;
        private Label label2;
        private Label label1;
        private DateTimePicker toDoDate;
        private Button toDoCreate;
        private Label test;
        private Panel toDoPanel;
    }
}
