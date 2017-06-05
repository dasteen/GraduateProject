using FinalPart;
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

namespace FinalPart
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        public int countOfNodes;

        

        private void btnShowTable(object sender, RoutedEventArgs e)
        {
            MainWindow.table1.ShowTable();
            //MainWindow.table1.ShowCopyTable();
        }
        

        private void btnHandFilling(object sender, RoutedEventArgs e)
        {
            if(TryToInt())
            {
                if(countOfNodes > 0)
                {
                    MainWindow.table1 = new Table(countOfNodes);

                    //FillingTableWindow fillingTableWindow1 = new FillingTableWindow();
                    //fillingTableWindow1.ShowDialog();

                    WindowTest windowTest1 = new WindowTest();
                    windowTest1.MakeTable(countOfNodes);
                    windowTest1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Введите целое число больше нуля");
                }
            }
            
        }

        private bool TryToInt()
        {
            try
            {
                countOfNodes = int.Parse(tboxCountOfNodes.Text);
            }
            catch
            {
                MessageBox.Show("Введите целое число от 0 до 80");
                return false;
            }
            return true;
        }

        private void btnReduce(object sender, RoutedEventArgs e)
        {
            MainWindow.table1.FindPath();
        }

        private void btnCalculate(object sender, RoutedEventArgs e)
        {
            if (tboxCountOfNodes.Text == "")
            {
                MainWindow.table1 = new Table();
                MainWindow.table1.FindPath();
                this.NavigationService.Navigate(new Page2());
            }
            else
            {
                MessageBox.Show("вычисление :)");
            }

        }
    }
}
