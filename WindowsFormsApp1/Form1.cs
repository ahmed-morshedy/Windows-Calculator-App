using System;
using System.Data;  // For evaluating expressions
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int x = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Display the value of memory `x`
        private void MemoryReturn_Click(object sender, EventArgs e)
        {
            textBox1.Text = x.ToString();
        }

        // Save the current value to memory
        private void MemorySave_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out x))
            {
                textBox1.Text = x.ToString();
            }
        }

        // Add current value to memory
        private void MemoryPlus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                x += value;
                textBox1.Text = x.ToString();
            }
        }

        // Clear memory
        private void MemoryClear_Click(object sender, EventArgs e)
        {
            x = 0;
            textBox1.Text = "0";
        }

        // Digit buttons
        private void Zero_Click(object sender, EventArgs e) { AppendText("0"); }
        private void One_Click(object sender, EventArgs e) { AppendText("1"); }
        private void Two_Click(object sender, EventArgs e) { AppendText("2"); }
        private void Three_Click(object sender, EventArgs e) { AppendText("3"); }
        private void Four_Click(object sender, EventArgs e) { AppendText("4"); }
        private void Five_Click(object sender, EventArgs e) { AppendText("5"); }
        private void Six_Click(object sender, EventArgs e) { AppendText("6"); }
        private void Seven_Click(object sender, EventArgs e) { AppendText("7"); }
        private void Eight_Click_1(object sender, EventArgs e) { AppendText("8"); }
        private void Nine_Click(object sender, EventArgs e) { AppendText("9"); }

        // Operator buttons
        private void Plus_Click(object sender, EventArgs e) { AppendText("+"); }
        private void Minus_Click(object sender, EventArgs e) { AppendText("-"); }
        private void Multiple_Click(object sender, EventArgs e) { AppendText("*"); }
        private void Devide_Click(object sender, EventArgs e) { AppendText("/"); }

        // Clear text box
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // Backspace functionality
        private void Backspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                if (string.IsNullOrEmpty(textBox1.Text)) textBox1.Text = "0";
            }
        }

        // Evaluate expression when "Equal" button is clicked
        private void Equal_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(textBox1.Text, null);
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";  // Reset display on error
            }
        }

        // Helper method to handle appending text in the text box
        private void AppendText(string value)
        {
            if (textBox1.Text == "0" && value != ".")
                textBox1.Text = value;
            else
                textBox1.Text += value;
        }

        // Event handler for textBox1_TextChanged - currently empty
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Optional: Any real-time validation or formatting can be done here
        }
    }
}
