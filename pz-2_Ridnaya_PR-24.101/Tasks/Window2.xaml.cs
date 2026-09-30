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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[а-яА-ЯёЁ ]+$");
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = tbInput.Text.Trim();

            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Пожалуйста, введите строку с текстом!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] words = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                MessageBox.Show("Строка не содержит слов!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Array.Reverse(words);
            string result = string.Join(" ", words);

            tbOutput.Text = result;
        }

    }
}
