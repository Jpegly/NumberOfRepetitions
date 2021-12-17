using Microsoft.Win32;
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

namespace NumberOfRepetitions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CalculationViewModel();
            btnCalculate.IsEnabled = false;
        }

        /// <summary>
        /// Открытие файла
        /// </summary>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "Файлы|*.xml;*.json", Multiselect = true };
            if (ofd.ShowDialog() == true)
            {
                ((CalculationViewModel)DataContext).Paths.Clear();

                foreach (var item in ofd.FileNames)
                {
                    ((CalculationViewModel)DataContext).Paths.Add(item);

                }
                btnCalculate.IsEnabled = true;
            }
        }

        /// <summary>
        /// Вычисление количества повторяемого символа
        /// </summary>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
             try
             {
                 ((CalculationViewModel)DataContext).Calculation();
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
    }
}
