using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastnumber, result;
        private SelectedOperator SelectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            AcBtn.Click += AcBtn_Click;
            NegativeBtn.Click += NegativeBtn_Click;
            PercentageBtn.Click += PercentageBtn_Click;
            EqualsBtn.Click += EqualsBtn_Click;
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            double newnumber;

            if (double.TryParse(ResultLabel.Content.ToString(), out newnumber))
            {
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastnumber, newnumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Min(lastnumber, newnumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multi(lastnumber, newnumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastnumber, newnumber);
                        break;
                }
            }
        }

        private void PercentageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastnumber))
            {
                lastnumber = lastnumber / 100;
                ResultLabel.Content = lastnumber.ToString();
            }
        }

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastnumber))
            {
                lastnumber = lastnumber * -1;
                ResultLabel.Content = lastnumber.ToString();
            }
        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)

        {

            Button button = (Button)sender;

            if (ResultLabel.Content.ToString() == "0")

            {

                ResultLabel.Content = button.Content;

            }

            else

            {

                ResultLabel.Content = $"{ResultLabel.Content}{button.Content}";

            }

        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastnumber))
            {
                ResultLabel.Content = "0";
            }

            if (sender == TimesBtn)
                SelectedOperator = SelectedOperator.Multiplication;
            if (sender == MinusBtn)
                SelectedOperator = SelectedOperator.Subtraction;
            if (sender == PlusBtn)
                SelectedOperator = SelectedOperator.Addition;
            if (sender == DivideBtn)
                SelectedOperator = SelectedOperator.Division;
        }


    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Min(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multi(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Div(double n1, double n2)
        {
            return n1 / n2;
        }
    }
}
