using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            var result = firstNumber + secondNumber;

            this.resultTextBox.Text = result.ToString();

            this.firstNumberText.Text = string.Empty;
            this.secondNumberText.Text = string.Empty;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            var result = firstNumber - secondNumber;

            this.resultTextBox.Text = result.ToString();

            this.firstNumberText.Text = string.Empty;
            this.secondNumberText.Text = string.Empty;
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            var result = firstNumber * secondNumber;

            this.resultTextBox.Text = result.ToString();

            this.firstNumberText.Text = string.Empty;
            this.secondNumberText.Text = string.Empty;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            if (secondNumber == 0)
            {
                this.errorLabel.ForeColor = Color.Red;
                this.errorLabel.Text = "Cannot divide by zero";
                return;
            }

            var result = firstNumber / secondNumber;

            this.resultTextBox.Text = result.ToString();

            this.firstNumberText.Text = string.Empty;
            this.secondNumberText.Text = string.Empty;
        }

        private void buttonSqrtFirst_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);

            var result = Math.Sqrt((double)firstNumber);

            this.firstNumberText.Text = result.ToString();
        }

        private void buttonSqrtSecond_Click(object sender, EventArgs e)
        {
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            var result = Math.Sqrt((double)secondNumber);

            this.secondNumberText.Text = result.ToString();
        }

        private void buttonLog2First_Click(object sender, EventArgs e)
        {
            var firstNumber = decimal.Parse(this.firstNumberText.Text);

            var result = Math.Log((double)firstNumber, 2);

            this.firstNumberText.Text = result.ToString();
        }

        private void buttonLog2Seccond_Click(object sender, EventArgs e)
        {
            var secondNumber = decimal.Parse(this.secondNumberText.Text);

            var result = Math.Log((double)secondNumber, 2);

            this.secondNumberText.Text = result.ToString();
        }
    }
}
