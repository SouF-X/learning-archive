using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Result = 0; // Stores the current result
        string Number = ""; // Stores the current input number as a string
        bool isFirstOperation = true; // Flag to check if it's the first operation
        enum enOperations { Sum, Sub, Mul, Div };
        enOperations OperationType = enOperations.Sum; // Default operation type

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResult.Text = "0"; // Initialize the result label
        }

        public void ChangeResultLabel(Button btn)
        {
            if (btn?.Tag != null) // Ensure the button has a valid tag
            {
                Number += btn.Tag.ToString(); // Append the button's tag to the Number
                lblResult.Text = Number; // Update the result label
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeResultLabel((Button)sender); // Handle number button clicks
        }

        private void Operations(ref int Result, string Number, enOperations OpType)
        {
            int parsedNumber = int.Parse(Number); // Convert the input string to an integer

            switch (OpType)
            {
                case enOperations.Sum:
                    Result += parsedNumber;
                    break;
                case enOperations.Sub:
                    Result -= parsedNumber;
                    break;
                case enOperations.Mul:
                    Result *= parsedNumber;
                    break;
                case enOperations.Div:
                    if (parsedNumber == 0) // Prevent division by zero
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Result /= parsedNumber;
                    break;
            }

            lblResult.Text = Result.ToString(); // Update the result label with the calculated result
        }

        private void Button_Operations_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Number)) // Ensure there's an input number
            {
                int parsedNumber;

                if (int.TryParse(Number, out parsedNumber)) // Safely parse the input number
                {
                    if (isFirstOperation)
                    {
                        Result = parsedNumber; // Set the initial result
                        isFirstOperation = false;
                    }
                    else
                    {
                        Operations(ref Result, Number, OperationType); // Perform the operation
                    }

                    Number = ""; // Reset the current number for the next input

                    Button clickedButton = sender as Button;

                    if (clickedButton != null)
                    {
                        string TagValue = clickedButton.Tag.ToString();

                        switch (TagValue)
                        {
                            case "+":
                                OperationType = enOperations.Sum;
                                lblResult.Text = $"{Result} +";
                                break;
                            case "-":
                                OperationType = enOperations.Sub;
                                lblResult.Text = $"{Result} -";

                                break;
                            case "x":
                                OperationType = enOperations.Mul;
                                lblResult.Text = $"{Result} x";

                                break;
                            case "/":
                                OperationType = enOperations.Div;
                                lblResult.Text = $"{Result} /";

                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            Result = 0;
            Number = "";
            isFirstOperation = true; // Reset the flag for a new calculation
            lblResult.Text = "0"; // Reset the result label
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Number)) // Ensure there's an input number
            {
                Operations(ref Result, Number, OperationType); // Perform the last operation
                Number = ""; // Reset the number
                isFirstOperation = true; // Reset the flag for a new calculation
            }
            else
            {
                MessageBox.Show("Enter a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}