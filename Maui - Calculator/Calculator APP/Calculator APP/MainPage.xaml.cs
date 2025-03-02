using System;
using Microsoft.Maui.Controls;

namespace SimpleCalculator
{
    public partial class MainPage : ContentPage
    {
        private string currentExpression = ""; 
        private double firstNumber;
        private string operation = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberSelection(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                currentExpression += button.Text; 
                result.Text = currentExpression; 
            }
        }

        private void OnOperatorSelection(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && !string.IsNullOrEmpty(currentExpression))
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    return; 
                }

                firstNumber = double.Parse(currentExpression); 
                operation = button.Text; 
                currentExpression += " " + operation + " "; 
                result.Text = currentExpression; 
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            string[] numbers = currentExpression.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 2)
            {
                if (!double.TryParse(numbers[1], out double secondNumber))
                {
                    return; 
                }

                if (operation == "/" && secondNumber == 0)
                {
                    result.Text = "Eroare"; 
                    return;
                }

                double finalResult = Calculate.DoCalculation(firstNumber, secondNumber, operation);
                result.Text = finalResult.ToString(); 
                currentExpression = finalResult.ToString(); 
                operation = "";
            }
        }

        private void OnSquareRoot(object sender, EventArgs e)
        {
            if (double.TryParse(currentExpression, out double number))
            {
                if (number >= 0)
                {
                    double sqrtResult = Math.Sqrt(number);
                    result.Text = sqrtResult.ToString();
                    currentExpression = sqrtResult.ToString();
                }
                else
                {
                    result.Text = "Err";
                    currentExpression = "";
                }
            }
        }


        private void OnClear(object sender, EventArgs e)
        {
            currentExpression = "";
            firstNumber = 0;
            operation = "";
            result.Text = "0"; // Resetează tot
        }
    }
}
