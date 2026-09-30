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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9\s-]+$");
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = tbInput.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Введите последовательность чисел!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                int[] nums = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (nums.Length == 0) return;

                List<int> bestSeq = new List<int> { nums[0] };
                List<int> currentSeq = new List<int> { nums[0] };

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] % nums[i - 1] == 0)
                    {
                        currentSeq.Add(nums[i]);
                    }
                    else
                    {
                        if (currentSeq.Count > bestSeq.Count)
                        {
                            bestSeq = new List<int>(currentSeq);
                        }
                        currentSeq = new List<int> { nums[i] };
                    }
                }

                if (currentSeq.Count > bestSeq.Count)
                {
                    bestSeq = new List<int>(currentSeq);
                }

                string sequenceString = string.Join(" ", bestSeq);
                tbOutput.Text = $"Подпоследовательность: {sequenceString} (Длина: {bestSeq.Count})";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при обработке чисел. Проверьте правильность ввода.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
