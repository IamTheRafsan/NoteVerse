using System;
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
    public partial class quizForm : UserControl
    {
        private string connectionString = "Server=localhost;Database=NoteDatabase;Uid=root;Pwd=evan12345;";

        public quizForm()
        {
            InitializeComponent();
            this.connectionString = connectionString;

        }
      

        private void SaveToDatabase(string question, string option1, string option2, string option3, string option4, string correct)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Quizzes (Question, Option1, Option2, Option3, Option4, Correct) VALUES (@Question, @Option1, @Option2, @Option3, @Option4, @Correct)", connection))
                    {
                        {
                            insertCmd.Parameters.AddWithValue("@Question", question);
                            insertCmd.Parameters.AddWithValue("@Option1", option1);
                            insertCmd.Parameters.AddWithValue("@Option2", option2);
                            insertCmd.Parameters.AddWithValue("@Option3", option3);
                            insertCmd.Parameters.AddWithValue("@Option4", option4);
                            insertCmd.Parameters.AddWithValue("@Correct", correct);

                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Quiz Created Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void creatBtn_Click_1(object sender, EventArgs e)
        {


            try
            {
                // Get values from textboxes
                string question = questionText.Text;
                string option1 = option1Text.Text;
                string option2 = option2Text.Text;
                string option3 = option3Text.Text;
                string option4 = option4Text.Text;
                string correct = correctText.Text;

                // Check if any of the text fields is empty
                if (string.IsNullOrWhiteSpace(question) ||
                    string.IsNullOrWhiteSpace(option1) ||
                    string.IsNullOrWhiteSpace(option2) ||
                    string.IsNullOrWhiteSpace(option3) ||
                    string.IsNullOrWhiteSpace(option4) ||
                    string.IsNullOrWhiteSpace(correct))
                {
                    MessageBox.Show("All fields must be filled in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method without saving to the database
                }

                // Save to the database
                SaveToDatabase(question, option1, option2, option3, option4, correct);

               
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
