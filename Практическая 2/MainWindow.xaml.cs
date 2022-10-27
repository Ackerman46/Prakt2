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
using Libmas;
using Lib_12;
using Microsoft.Win32;

namespace Prakt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] arr;
        public MainWindow()
        {
            InitializeComponent();
            arrLenght.Focus();
        }

        private void TaskApp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Агеев ИСП-31\nВариант 12\nЗадание: Ввести n целых чисел. Найти сумму чисел > 15. Результат вывести на экран.");
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void arrLenght_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(arrLenght.Text, out int len);
            arr = new int[len];
            LibTask.FillArr(ref arr, 100);
            AppNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
        }

        private void UploadArr_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openArr = new OpenFileDialog();
            openArr.Filter = "Текстовые файлы | *.txt";
            openArr.FilterIndex = 1;
            if (openArr.ShowDialog() == true)
            {
                LibTask.UploadArr(ref arr, openArr.FileName);
                AppNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void SaveArr_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveArr = new SaveFileDialog();
            saveArr.Filter = "Текстовые файлы | *.txt";
            saveArr.FilterIndex = 1;
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if (saveArr.ShowDialog() == true)
            {
                LibTask.SaveArr(arr, saveArr.FileName);
            }
        }

        private void ClearArr_Click(object sender, RoutedEventArgs e)
        {
            arrLenght.Clear();
            LibTask.ClearArr(ref arr);
            ResultBox.Clear();
			arrLenght.Focus();
            AppNums.ItemsSource = null;
        }

        private void GotResult_Click(object sender, RoutedEventArgs e)
        {
            if (arr != null)
            {
                ResultBox.Text = $"{LibArr.SumOfElem(arr)}";
            }
            else
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
        }
    }
}
