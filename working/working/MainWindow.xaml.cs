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

namespace working
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

        private void BlueItem_Click(object sender, RoutedEventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Blue;
            StatusText.Text = "Цвет фона изменен на синий.";
        }

        private void GreenItem_Click(object sender, RoutedEventArgs e)
        {
            this.Background = System.Windows.Media.Brushes.Green;
            StatusText.Text = "Цвет фона изменен на зеленый.";
        }

        private void CloseItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RazrabItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: I'm me \nКонтакт: my email is my mail", "Информация о разработчике");
            StatusText.Text = "Вы открыли информацию о разработчике.";
        }
    }
}