using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }
        private void tbInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbInput1.Text, out int rows) || rows <= 0)
            {
                MessageBox.Show("Введите корректное число строк N!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(tbInput2.Text, out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректное число столбцов M!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            int[,] originalMatrix = new int[rows, cols];
            List<int> flatList = new List<int>();
            Random rand = new Random();

            int minVal = 11;
            int maxVal = -11;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int num = rand.Next(-10, 11);
                    originalMatrix[i, j] = num;
                    flatList.Add(num);

                    if (num < minVal) minVal = num;
                    if (num > maxVal) maxVal = num;
                }
            }

            tbMin.Text = minVal.ToString();
            tbMax.Text = maxVal.ToString();

            var ascList = flatList.OrderBy(x => x).ToList();
            var descList = flatList.OrderByDescending(x => x).ToList();

            dgOriginal.ItemsSource = CreateDataTable(originalMatrix, rows, cols).DefaultView;
            dgAscending.ItemsSource = CreateDataTableFromList(ascList, rows, cols).DefaultView;
            dgDescending.ItemsSource = CreateDataTableFromList(descList, rows, cols).DefaultView;
        }

        private DataTable CreateDataTable(int[,] matrix, int rows, int cols)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < cols; j++) dt.Columns.Add();

            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    dr[j] = matrix[i, j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable CreateDataTableFromList(List<int> list, int rows, int cols)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < cols; j++) dt.Columns.Add();

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    if (index < list.Count)
                    {
                        dr[j] = list[index++];
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
