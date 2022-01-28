using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool TrueFalse { get; set; }
        int count_command, count_plus, count_negative, count_multi, count_divide, count_minus, count_sqrt; //определение типов данных в логике
        private double X { get; set; }
        private double Resultcopy { get; set; }
        private double Y { get; set; }
        private string Symbol { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)  // результат текста
        {
            if (result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
                btn_percent.IsEnabled = true;
            }
            if (TrueFalse)
            {
                result.Text = null;
            }
            if (sender is Button btn)
            {
                if (result.Text == "0" || result.Text == "-0") result.Text = btn.Content.ToString();
                else
                {
                    result.Text += btn.Content;
                }
            }
            if (TrueFalse) Y = Convert.ToDouble(result.Text);
            TrueFalse = false;
        }
        private void btn_comman_Click(object sender, RoutedEventArgs e) // запись после точки
        {
            if (count_command == 0)
            {
                result.Text += ".";
                ++count_command;
            }
        }
        private void btn_removeall_Click(object sender, RoutedEventArgs e) //сброс
        {
            if (result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
                btn_percent.IsEnabled = true;
            }
            result.Text = null;
            count_command = 0;
            count_negative = 0;
        }
        private void btn_removeall1_Click(object sender, RoutedEventArgs e) //сброс
        {
            if (result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
                btn_percent.IsEnabled = true;
            }
            result.Text = null;
            count_command = 0;
            count_negative = 0;
        }
        private void btn_deleteone_Click(object sender, RoutedEventArgs e) //убирание последних цифр, забой
        {
            if (result.Text.Length == 1)
            {
                result.Text = "0";
            }
            else
            {
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);

                if (result.Text[result.Text.Length - 1] == '.')
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1, 1);
                    count_command = 0;

                }
                if (result.Text[result.Text.Length - 1] == '-')
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1, 1);
                    count_negative = 0;
                }
            }
        }
        private void btn_negative_Click(object sender, RoutedEventArgs e) //+- перед числом
        {
            if (count_negative == 0)
            {
                result.Text = result.Text.Insert(0, "-");
                ++count_negative;
            }
            else if (count_negative == 1)
            {
                result.Text = result.Text.Remove(0, 1);
                count_negative = 0;
            }
        }
        private void btn_operation_Click(object sender, RoutedEventArgs e) //действия первой итерации.
        {
            if (sender is Button btn)
            {
                if (btn.Content.ToString() == "+")
                {
                    Resultcopy = Convert.ToDouble(result.Text);
                    Symbol = "+";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_plus = 0;
                }
                else if (btn.Content.ToString() == "-")
                {
                    Resultcopy = Convert.ToDouble(result.Text);
                    Symbol = "-";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_minus = 0;
                }
                else if (btn.Content.ToString() == "*")
                {
                    Resultcopy = Convert.ToDouble(result.Text);
                    Symbol = "*";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_multi = 0;
                }
                else if (btn.Content.ToString() == "/")
                {
                    Resultcopy = Convert.ToDouble(result.Text);
                    Symbol = "/";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    count_divide = 0;
                }
                else if (btn.Content.ToString() == "%")
                {
                    Symbol = "%";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    Resultcopy = Convert.ToDouble(result.Text);

                    result.Text = (Resultcopy * 0.01).ToString();
                }
                else if (btn.Content.ToString() == "x²")
                {
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    Resultcopy = Convert.ToDouble(result.Text);

                    result.Text = (Resultcopy * Resultcopy).ToString();
                }
                else if (btn.Content.ToString() == "⅟×")
                {
                    Symbol = "⅟×";
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    Resultcopy = Convert.ToDouble(result.Text);
                    if (Resultcopy == 0)
                    {
                        result.Text = "Invalid input";
                        btn_divide.IsEnabled = false;
                        btn_minus.IsEnabled = false;
                        btn_multi.IsEnabled = false;
                        btn_sqrt.IsEnabled = false;
                        btn_operation.IsEnabled = false;
                        btn_comman.IsEnabled = false;
                        btn_negative.IsEnabled = false;
                        btn_doublemulti.IsEnabled = false;
                        btn_fraction.IsEnabled = false;
                        btn_percent.IsEnabled = false;
                    }
                    else
                    {
                        result.Text = (1 / Resultcopy).ToString();
                    }
                }
                else if (btn.Content.ToString() == "√x")
                {
                    TrueFalse = true;
                    count_command = 0;
                    count_negative = 0;
                    Resultcopy = Convert.ToDouble(result.Text);
                    if (Resultcopy > 0)
                    {
                        result.Text = Math.Sqrt(Resultcopy).ToString();
                    }
                    else if (Resultcopy < 0)
                    {
                        result.Text = "Invalid input";
                        btn_divide.IsEnabled = false;
                        btn_minus.IsEnabled = false;
                        btn_multi.IsEnabled = false;
                        btn_sqrt.IsEnabled = false;
                        btn_operation.IsEnabled = false;
                        btn_comman.IsEnabled = false;
                        btn_negative.IsEnabled = false;
                        btn_doublemulti.IsEnabled = false;
                        btn_fraction.IsEnabled = false;
                        btn_percent.IsEnabled = false;
                    }
                }
            }
        }
        private void Result_Click(object sender, RoutedEventArgs e) // окончание действий
        {
            if (result.Text == "Invalid input")
            {
                btn_divide.IsEnabled = true;
                btn_minus.IsEnabled = true;
                btn_multi.IsEnabled = true;
                btn_sqrt.IsEnabled = true;
                btn_operation.IsEnabled = true;
                btn_comman.IsEnabled = true;
                btn_negative.IsEnabled = true;
                btn_doublemulti.IsEnabled = true;
                btn_fraction.IsEnabled = true;
                btn_percent.IsEnabled = true;
                result.Text = "0";
            }
            ++count_plus;
            ++count_minus;
            ++count_multi;
            ++count_divide;
            ++count_sqrt;

            X = Convert.ToDouble(result.Text);
            if (Symbol == "+")
            {
                if (count_plus == 1)
                {
                    result.Text = (Resultcopy + X).ToString();
                }
                else if (count_plus != 1)
                {
                    result.Text = (Y + X).ToString();
                }
            }
            else if (Symbol == "-")
            {
                if (count_minus == 1)
                {
                    result.Text = (Resultcopy - X).ToString();
                }
                else if (count_minus != 1)
                {
                    result.Text = (X - Y).ToString();
                }
            }
            else if (Symbol == "*")
            {
                if (count_multi == 1)
                {
                    result.Text = (Resultcopy * X).ToString();
                }
                else if (count_multi != 1)
                {
                    result.Text = (X * Y).ToString();
                }
            }
            else if (Symbol == "/")
            {
                if (count_divide == 1)
                {
                    if (X == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else result.Text = (Resultcopy / X).ToString();
                }
                else if (count_divide != 1)
                {
                    if (Y == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else result.Text = (X / Y).ToString();
                }
            }
        }
    }
}

