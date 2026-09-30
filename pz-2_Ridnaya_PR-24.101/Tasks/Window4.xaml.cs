using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pz_2_Ridnaya_PR_24._101.Tasks
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbInput1.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введите корректный размер массива n!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(tbInput2.Text, out int b))
            {
                MessageBox.Show("Введите корректное число b!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int[] a = new int[n];
            a[0] = 1;
            a[n-1] = n;
            Random rand = new Random();
            for (int k = 1; k < n-1; k++)
            {
                a[k] = rand.Next(1, n);
            }

            string originalArrayStr = string.Join(", ", a);

            int i = 0;
            int j = n - 1;

            while (i <= j)
            {
                while (a[i] < b) i++;

                while (a[j] > b) j--;

                if (i <= j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;

                    i++;
                    j--;
                }
            }

            string resultArrayStr = string.Join(", ", a);

            tbOutput.Text = $"Исходный массив: [{originalArrayStr}]\nРезультат: [{resultArrayStr}]";
        }
    }
}
