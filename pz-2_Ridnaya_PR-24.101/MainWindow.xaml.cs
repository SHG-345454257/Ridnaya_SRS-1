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
using pz_2_Ridnaya_PR_24._101.Tasks;

namespace pz_2_Ridnaya_PR_24._101
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            changes.Content = "Этот текст это новые изменения";
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                string targetWindow = btn.Tag.ToString();
                Window WindowToOpen = null;

                switch (targetWindow)
                {
                    case "1": WindowToOpen = new Window1(); break;
                    case "2": WindowToOpen = new Window2(); break;
                    case "3": WindowToOpen = new Window3(); break;
                    case "4": WindowToOpen = new Window4(); break;
                    case "5": WindowToOpen = new Window5(); break;
                }

                if (WindowToOpen != null)
                {
                    WindowToOpen.Show();
                }
            }
        }

    }
}
