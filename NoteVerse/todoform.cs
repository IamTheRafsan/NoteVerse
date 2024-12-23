﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace NoteVerse
{
    public partial class todoform : UserControl
    {
        private string connectionString = "Server=localhost;Database=NoteDatabase;Uid=root;Pwd=evan12345;";
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Timer todoTimer;
        public todoform()
        {
            InitializeComponent();

            toDoCreate.Click += toDoCreate_Click;
           


            dateTimePicker = new System.Windows.Forms.DateTimePicker();
            dateTimePicker.ValueChanged += dateTimePicker1_ValueChanged;





            toDoPanel.AutoScroll = true;
            

           

            
        }


        private void toDoCreate_Click(object sender, EventArgs e)
        {
            string todoName = toDoName.Text;
            DateTime toDoDate = dateTimePicker.Value;
            DateTime toDoTime = dateTimePicker.Value;


            try
            {
                
                SaveTodoToDatabase(todoName, toDoTime, toDoDate);

                
                DisplayTodoData();

              
                dateTimePicker.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void SaveTodoToDatabase(string todoName, DateTime toDoTime, DateTime toDoDate)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Todo (Name, Time, Date) VALUES (@toDoName, @toDoTime, @toDoDate)", connection))
                    {
                        insertCmd.Parameters.AddWithValue("@toDoName", todoName);
                        insertCmd.Parameters.AddWithValue("@toDoTime", toDoTime.TimeOfDay);
                        insertCmd.Parameters.AddWithValue("@toDoDate", toDoDate);
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("To Do created successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTodoData()
        {
            
            toDoPanel.Controls.Clear();

            try
            {
                
                List<TodoItem> todoItems = GetTodoItemsFromDatabase();


                
                int buttonTop = 0;
                foreach (TodoItem todoItem in todoItems)
                {
                    
                    Button todoButton = new Button();
                    todoButton.BackColor = SystemColors.Control;
                    todoButton.Location = new Point(6, buttonTop);
                    todoButton.Size = new Size(538, 100);
                    todoButton.TabIndex = 0;
                    todoButton.BackColor = Color.FromArgb(155, 207, 255);
                    todoButton.ForeColor = Color.Black;
                    todoButton.Text = $"{todoItem.Name} - {todoItem.Date.ToShortDateString()} {todoItem.Time.ToString(@"hh\:mm")}";
                    todoButton.UseVisualStyleBackColor = false;
                    toDoPanel.Controls.Add(todoButton);

                    
                    buttonTop += todoButton.Height + 8; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying ToDo data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private List<TodoItem> GetTodoItemsFromDatabase()
        {
            List<TodoItem> todoItems = new List<TodoItem>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT Name, Time, Date FROM ToDo", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            TimeSpan time = (TimeSpan)reader["Time"];
                            DateTime date = (DateTime)reader["Date"];

                            todoItems.Add(new TodoItem { Name = name, Time = time, Date = date });
                        }
                    }
                }
            }

            return todoItems;
        }



        public class TodoItem
        {
            public string Name { get; set; }
            public TimeSpan Time { get; set; }
            public DateTime Date { get; set; }
            public bool Notified { get; set; } 

            public TodoItem()
            {
                Notified = false; 
            }
        }



        private void todoform_Load(object sender, EventArgs e)
        {
            DisplayTodoData();

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void test_Click(object sender, EventArgs e)
        {

        }
    }
}
