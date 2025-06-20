using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace BMI_Calculator
{
    public partial class MainWindow : Window
    {
        private const string FilePath = "bmi_results.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBMI_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AgeInput.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Please enter a valid age between 1 and 120.");
                return;
            }

            if (!double.TryParse(WeightInput.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Please enter a valid weight in kilograms.");
                return;
            }

            if (!double.TryParse(HeightInput.Text, out double height) || height <= 0.5 || height > 3)
            {
                MessageBox.Show("Please enter a valid height in meters.");
                return;
            }

            double bmi = weight / (height * height);
            string interpretation = InterpretBMI(bmi);
            string advice = GetAgeBasedAdvice(age);

            ResultText.Text = $"Your BMI is {bmi:F2}. {interpretation}";
            AdviceText.Text = advice;

            ColorizeResult(interpretation);
            SaveToFile(age, weight, height, bmi, interpretation, advice);
        }

        private string InterpretBMI(double bmi)
        {
            if (bmi < 18.5) return "You are underweight.";
            if (bmi < 24.9) return "You have a normal weight.";
            if (bmi < 29.9) return "You are overweight.";
            return "You are obese.";
        }

        private string GetAgeBasedAdvice(int age)
        {
            if (age < 18)
                return "BMI values may not be accurate for children. Consult a pediatrician.";
            else if (age >= 65)
                return "BMI may not fully reflect health for seniors. Please consult a healthcare provider.";
            else
                return "Standard adult BMI interpretation applies.";
        }

        private void ColorizeResult(string category)
        {
            if (category.Contains("underweight"))
                ResultText.Foreground = Brushes.CadetBlue;
            else if (category.Contains("normal"))
                ResultText.Foreground = Brushes.Green;
            else if (category.Contains("overweight"))
                ResultText.Foreground = Brushes.Orange;
            else
                ResultText.Foreground = Brushes.Red;
        }

        private void SaveToFile(int age, double weight, double height, double bmi, string interpretation, string advice)
        {
            string entry = $"Date: {DateTime.Now}\nAge: {age}\nWeight: {weight} kg\nHeight: {height} m\n" +
                           $"BMI: {bmi:F2}\nResult: {interpretation}\nAdvice: {advice}\n----------------------\n";

            try
            {
                File.AppendAllText(FilePath, entry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save result: {ex.Message}");
            }
        }

        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FilePath))
            {
                HistoryText.Text = "No BMI history found.";
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                StringBuilder history = new StringBuilder();
                double totalBMI = 0;
                int count = 0;

                foreach (string line in lines)
                {
                    history.AppendLine(line);

                    if (line.StartsWith("BMI:"))
                    {
                        string bmiStr = line.Substring(5);
                        if (double.TryParse(bmiStr, out double bmi))
                        {
                            totalBMI += bmi;
                            count++;
                        }
                    }
                }

                if (count > 0)
                {
                    double avg = totalBMI / count;
                    history.AppendLine($"\n📊 Total entries: {count}");
                    history.AppendLine($"📈 Average BMI: {avg:F2}");
                }

                HistoryText.Text = history.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to read history: {ex.Message}");
            }
        }
    }
}
