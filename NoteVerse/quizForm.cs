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

// ... (Your existing using statements)

namespace NoteVerse
{
    public partial class quizForm : UserControl
    {
        private string connectionString = "Server=localhost;Database=NoteDatabase;Uid=root;Pwd=evan12345;";
        private Panel quizPanel2; // Declare quizPanel2 as a class-level variable


        private void label1_Click(object sender, EventArgs e)
        {
            // Implement the logic for label1_Click event
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Implement the logic for label2_Click event
        }

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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void goToQuiz_Click(object sender, EventArgs e)
        {
            // Hide quizPanel1
            quizPanel1.Hide();

            // Create quizPanel2
            InitializeQuizPanel2();

            // Show quizPanel2
            quizPanel2.Show();
        }

        private void InitializeQuizPanel2()
        {
            // Create quizPanel2
            quizPanel2 = new Panel();
            quizPanel2.Dock = DockStyle.Fill;

            // Retrieve data from the Quizzes table
            List<QuizQuestion> quizQuestions = GetQuizQuestionsFromDatabase();

            // Create UI elements dynamically for each quiz question
            int yOffset = 20;
            foreach (var question in quizQuestions)
            {
                // Label for each question
                Label questionLabel = new Label();
                questionLabel.Text = $"Question: {question.Question}";
                questionLabel.Location = new Point(10, yOffset);
                questionLabel.Size = new Size(1000, 50);
                quizPanel2.Controls.Add(questionLabel);

                // Radio buttons for options
                int optionOffset = 40;
                for (int i = 1; i <= 4; i++)
                {
                    CheckBox optionRadioButton = new CheckBox();
                    string optionPropertyName = $"Option{i}";
                    optionRadioButton.Text = $"{question.GetType().GetProperty(optionPropertyName).GetValue(question)}";
                    optionRadioButton.Location = new Point(40 + (i - 1) * 350, yOffset + optionOffset);
                    optionRadioButton.Size = new Size(350, 50);
                    quizPanel2.Controls.Add(optionRadioButton);
                }

                yOffset += 100; // Adjust the vertical space between questions
            }

            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new Point(10, yOffset);
            submitButton.Click += SubmitButton_Click;
            submitButton.Size = new Size(200, 50);
            quizPanel2.Controls.Add(submitButton);

            // Add quizPanel2 to the form's controls
            Controls.Add(quizPanel2);

            // Hide quizPanel2 initially
            quizPanel2.Hide();
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Initialize counters for correct and incorrect answers
            int correctCount = 0;
            int incorrectCount = 0;

            // Loop through the controls in quizPanel2 to find the selected options
            foreach (Control control in quizPanel2.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    // Get the selected option text
                    string selectedOption = checkBox.Text;

                    // Find the corresponding question in the database
                    QuizQuestion question = GetQuizQuestionByText(selectedOption);

                    // Check if the selected option is correct
                    if (question != null)
                    {
                        if (checkBox.Checked)
                        {
                            if (selectedOption == question.Correct)
                            {
                                correctCount++;
                            }
                            else
                            {
                                // Only count as incorrect if the checkbox is checked and it's not the correct answer
                                incorrectCount++;
                            }
                        }
                    }
                }
            }

            // Display the result in a message box
            MessageBox.Show($"You answered {correctCount} questions correctly.", "Quiz Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private QuizQuestion GetQuizQuestionByText(string selectedOption)
        {
           
            return GetQuizQuestionsFromDatabase().FirstOrDefault(q => q.Correct == selectedOption);
        }


        private List<QuizQuestion> GetQuizQuestionsFromDatabase()
        {
            List<QuizQuestion> quizQuestions = new List<QuizQuestion>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand selectCmd = new MySqlCommand("SELECT * FROM Quizzes", connection))
                    {
                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                QuizQuestion question = new QuizQuestion
                                {
                                    Question = reader["Question"].ToString(),
                                    Option1 = reader["Option1"].ToString(),
                                    Option2 = reader["Option2"].ToString(),
                                    Option3 = reader["Option3"].ToString(),
                                    Option4 = reader["Option4"].ToString(),
                                    Correct = reader["Correct"].ToString()
                                };

                                quizQuestions.Add(question);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching quiz questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return quizQuestions;
        }

        // Sample QuizQuestion class (replace it with your actual implementation)
        public class QuizQuestion
        {
            public string Question { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string Correct { get; set; }
        }
    }
}