using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Speech.Recognition;

namespace NoteVerse
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine speechRecognizer;
        private TextBox noteName;
        private TextBox noteNameTextBox;
        private string connectionString = "Server=localhost;Database=NoteDatabase;Uid=root;Pwd=evan12345;";

        public Form1()
        {
            InitializeComponent();

            noteName = new System.Windows.Forms.TextBox();
            noteNameTextBox = new System.Windows.Forms.TextBox();




            saveBtn.Click += saveBtn_Click;
            newBtn.Click += newBtn_Click;
            deleteBtn.Click += deleteBtn_Click;
            voiceBtn.Click += voiceBtn_Click;
            stopBtn.Click += stopBtn_Click;

            toDoBtn.Click += toDoBtn_Click;



            DisplayNoteNames();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {

            string newNoteName = Interaction.InputBox("Enter the new note name:", "New Note Name", "");

            if (!string.IsNullOrEmpty(newNoteName))
            {

                noteSpace.Text = newNoteName;

                noteSpace.Text = "";


                SaveToDatabase(newNoteName, "");
                DisplayNoteNames();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedNoteName = noteNameTextBox.Text;

                SaveToDatabase(selectedNoteName, noteSpace.Text);

                MessageBox.Show("Note saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayNoteNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToDatabase(string noteName, string noteText)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                bool noteExists = NoteExistsInDatabase(noteName, connection);

                if (noteExists)
                {
                    
                    using (MySqlCommand updateCmd = new MySqlCommand("UPDATE Notes SET NoteText = @NoteText WHERE NoteName = @NoteName", connection))
                    {
                        updateCmd.Parameters.AddWithValue("@NoteName", noteName);
                        updateCmd.Parameters.AddWithValue("@NoteText", noteText);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                   
                    using (MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Notes (NoteName, NoteText) VALUES (@NoteName, @NoteText)", connection))
                    {
                        insertCmd.Parameters.AddWithValue("@NoteName", noteName);
                        insertCmd.Parameters.AddWithValue("@NoteText", noteText);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }


        private List<string> GetNoteNamesFromDatabase()
        {
            
            List<string> noteNames = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT NoteName FROM Notes", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            noteNames.Add(reader["NoteName"].ToString());
                        }
                    }
                }
            }

            return noteNames;
        }

        private string GetNoteTextFromDatabase(string noteName)
        {
            
            string noteText = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT NoteText FROM Notes WHERE NoteName = @NoteName", connection))
                {
                    cmd.Parameters.AddWithValue("@NoteName", noteName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            noteText = reader["NoteText"].ToString();
                        }
                    }
                }
            }

            return noteText;
        }

        private void DisplayNoteNames()
        {

            ClearNoteButtons();

            List<string> noteNames = GetNoteNamesFromDatabase();

            Panel notePanel = new Panel();
            notePanel.AutoScroll = true;
            notePanel.Location = new Point(6, 23); 
            notePanel.Size = new Size(500, 400); 
            notePanel.Name = "notePanel";
            panel2.Controls.Add(notePanel);

            int buttonTop = 0;

            foreach (string noteName in noteNames)
            {
                System.Windows.Forms.Button noteButton = new System.Windows.Forms.Button();

                noteButton.BackColor = SystemColors.Control;
                noteButton.Location = new Point(6, buttonTop);
                noteButton.Name = "dynamicNoteButton";
                noteButton.Size = new Size(500, 103);
                noteButton.TabIndex = 0;
                noteButton.Text = noteName;
                noteButton.UseVisualStyleBackColor = false;
                noteButton.Click += DynamicNoteButton_Click;



                
                notePanel1.Controls.Add(noteButton);

                
                buttonTop += noteButton.Height + 8; 
            }
        }

        private bool NoteExistsInDatabase(string noteName, MySqlConnection connection)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Notes WHERE NoteName = @NoteName", connection))
            {
                cmd.Parameters.AddWithValue("@NoteName", noteName);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void DynamicNoteButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;

            string selectedNoteName = clickedButton.Text;
            string noteText = GetNoteTextFromDatabase(selectedNoteName);

            
            noteNameTextBox.Text = selectedNoteName;

            noteSpace.Text = noteText;
        }

        private void ClearNoteButtons()
        {
            foreach (Control control in panel2.Controls)
            {
                if (control.Name == "dynamicNoteButton")
                {
                    panel2.Controls.Remove(control);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedNoteName = noteNameTextBox.Text;

                DeleteFromDatabase(selectedNoteName);

                MessageBox.Show("Note deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayNoteNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFromDatabase(string noteName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Notes WHERE NoteName = @NoteName", connection))
                {
                    cmd.Parameters.AddWithValue("@NoteName", noteName);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void InitializeSpeechRecognition()
        {
            speechRecognizer = new SpeechRecognitionEngine();
            System.Speech.Recognition.GrammarBuilder grammarBuilder = new System.Speech.Recognition.GrammarBuilder(); // Fully qualify GrammarBuilder
            grammarBuilder.AppendDictation();
            System.Speech.Recognition.Grammar grammar = new System.Speech.Recognition.Grammar(grammarBuilder); // Fully qualify Grammar
            speechRecognizer.LoadGrammar(grammar);
            speechRecognizer.SpeechRecognized += SpeechRecognizer_SpeechRecognized;
            speechRecognizer.SetInputToDefaultAudioDevice();
            speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }




        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;
            noteSpace.AppendText(recognizedText + " ");
        }

        private void voiceBtn_Click(object sender, EventArgs e)
        {
            InitializeSpeechRecognition();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
   
            speechRecognizer.RecognizeAsyncStop();
        }


        
        private void toDoBtn_Click(object sender, EventArgs e)
        {
            todoform toDoForm = new todoform();

            toDoForm.Parent = this;
            toDoForm.Dock = DockStyle.Fill;

           
            panel2.Controls.Clear();

            panel2.Controls.Add(toDoForm);

            toDoForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            quizForm QuizForm = new quizForm();
            

            QuizForm.Parent = this;
            QuizForm.Dock = DockStyle.Fill;

            panel2.Controls.Clear();

            panel2.Controls.Add(QuizForm);

            QuizForm.Show();
        }










        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayNoteNames();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Code for button2 click event goes here
        }

        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Code for panel3 paint event goes here
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Code for richTextBox1 text changed event goes here
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void newBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void stopBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
