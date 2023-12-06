using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;


namespace NoteVerse
{
    public partial class Form1 : Form
    {
        private TextBox noteName;
        private TextBox noteNameTextBox;
        private string connectionString = "Server=localhost;Database=NoteDatabase;Uid=root;Pwd=evan12345;";

        public Form1()
        {
            InitializeComponent();

            noteName = new TextBox();
            noteNameTextBox = new TextBox();


            // Wire up the saveBtn Click event
            saveBtn.Click += saveBtn_Click;
            newBtn.Click += newBtn_Click;

            DisplayNoteNames();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            // Prompt the user to enter a new note name
            string newNoteName = Interaction.InputBox("Enter the new note name:", "New Note Name", "");

            if (!string.IsNullOrEmpty(newNoteName))
            {
                // Set the new note name to the noteSpace RichTextBox or any other control you are using
                noteSpace.Text = newNoteName;
                // Optionally, clear the existing noteSpace content
                noteSpace.Text = "";

                // Optionally, save the new note to the database with an empty noteText
                SaveToDatabase(newNoteName, "");
                DisplayNoteNames();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedNoteName = noteNameTextBox.Text;

                // Save the text from noteSpace under the name of the selected noteName
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

                // Check if the noteName already exists in the database
                bool noteExists = NoteExistsInDatabase(noteName, connection);

                if (noteExists)
                {
                    // Update the existing note
                    using (MySqlCommand updateCmd = new MySqlCommand("UPDATE Notes SET NoteText = @NoteText WHERE NoteName = @NoteName", connection))
                    {
                        updateCmd.Parameters.AddWithValue("@NoteName", noteName);
                        updateCmd.Parameters.AddWithValue("@NoteText", noteText);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Insert a new note if it doesn't exist
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
            // Implement this method to retrieve note names from the database
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
            // Implement this method to retrieve note text from the database
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
            notePanel.Location = new Point(6, 23); // Adjust the location based on your layout
            notePanel.Size = new Size(500, 400); // Adjust the size based on your layout
            notePanel.Name = "notePanel";
            panel2.Controls.Add(notePanel);

            int buttonTop = 0; // Adjust the top position based on your layout

            foreach (string noteName in noteNames)
            {
                Button noteButton = new Button();
                noteButton.BackColor = SystemColors.Control;
                noteButton.Location = new Point(6, buttonTop);
                noteButton.Name = "dynamicNoteButton";
                noteButton.Size = new Size(500, 103);
                noteButton.TabIndex = 0;
                noteButton.Text = noteName;
                noteButton.UseVisualStyleBackColor = false;
                noteButton.Click += DynamicNoteButton_Click;

                Button deleteButton = new Button();
                deleteButton.BackColor = SystemColors.ControlLight;
                deleteButton.Location = new Point(400, buttonTop);
                deleteButton.Name = "dynamicDeleteButton";
                deleteButton.Size = new Size(100, 103);
                deleteButton.TabIndex = 1;
                deleteButton.Text = "Delete";
                deleteButton.UseVisualStyleBackColor = false;
                deleteButton.Click += (sender, e) => DeleteNoteButton_Click(noteName);

                // Add the button to your panel (Assuming you have a panel named panel2)
                notePanel1.Controls.Add(noteButton);
                notePanel.Controls.Add(deleteButton);

                // Adjust the top position for the next button
                buttonTop += noteButton.Height + 8; // Add some spacing between buttons
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
            Button clickedButton = (Button)sender;
            string selectedNoteName = clickedButton.Text;
            string noteText = GetNoteTextFromDatabase(selectedNoteName);

            // Set the selected note name to the TextBox
            noteNameTextBox.Text = selectedNoteName;

            // Assuming you have RichTextBoxes named noteName and noteSpace
            noteSpace.Text = noteText;
        }

        private void ClearNoteButtons()
        {
            // Clear existing note buttons from the panel
            foreach (Control control in panel2.Controls)
            {
                if (control.Name == "dynamicNoteButton")
                {
                    panel2.Controls.Remove(control);
                }
            }
        }

        private void DeleteNoteButton_Click(string noteName)
        {
            try
            {
                // Delete the note from the database
                DeleteFromDatabase(noteName);

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


        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayNoteNames();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Code for button2 click event goes here
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Code for button3 click event goes here
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
    }
}
