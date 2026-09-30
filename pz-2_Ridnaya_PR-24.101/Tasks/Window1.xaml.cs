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
using System.Windows.Shapes;
using System.Numerics;

namespace pz_2_Ridnaya_PR_24._101.Tasks
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbInput.Text, out int n))
            {
                MessageBox.Show("Пожалуйста, введите корректное целое число!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (n < 1 || n > 100)
            {
                MessageBox.Show("Число n должно быть натуральным и не превышать 100!", "Ошибка диапазона", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            BigInteger result = 2 * factorial;

            tbOutput.Text = result.ToString();
        }

    }
}
