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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        
        public Page2()
        {
            InitializeComponent();
            Loaded += Page2_Loaded;
        }

        private void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            ShowTopology();
        }

        public int count = MainWindow.table1.correctedPath.Length;
        public int[][] path;
        public int[][] matrixPath;
        public int radius = 100;
        public PointCollection coordinates = new PointCollection();
        public List<int[]> coordNodeNames = new List<int[]>();
        public int tempNumberOfWavelength;

        public void FindCoordinates()
        {
            radius = (int)(MainCanvas.ActualHeight * 0.4);

            path = new int[count][];
            Array.Copy(MainWindow.table1.correctedPath, path, count);
            matrixPath = new int[count][];
            Array.Copy(MainWindow.table1.copyMatrix, matrixPath, count);

            int x, y;

            int xCentrе = (int)(MainCanvas.ActualWidth / 2);
            int yCentre = (int)(MainCanvas.ActualHeight / 2);
            for (int i = 0; i < count; i++)
            {
                x = (int)(xCentrе + (radius * Math.Cos(2 * i * Math.PI / count)));
                y = (int)(yCentre + (radius * Math.Sin(2 * i * Math.PI / count)));
                coordinates.Add(new Point(x, y));
                x -= 8;
                y -= 12;
                coordNodeNames.Add(new int[] { x, y });
            }
            
        }

        public void ShowTopology()
        {
            FindCoordinates();
            MakeAPolygon();
            MakeNodeNames();
        }

        private void btnApplyWavelength(object sender, RoutedEventArgs e)
        {
            if (TryToInt())
            {
                if (tempNumberOfWavelength > 0 && tempNumberOfWavelength < 80)
                {
                    MainWindow.numberOfWavelength = tempNumberOfWavelength;
                    MessageBox.Show("Применено");
                }
                else
                {
                    MessageBox.Show("Введите целое число от 1 до 80");
                }
            }

        }

        public void MakeAPolygon()
        {
            SolidColorBrush blackColor = new SolidColorBrush();
            blackColor.Color = Colors.Black;
            Polygon polygon1 = new Polygon();
            polygon1.StrokeThickness = 2;
            polygon1.Stroke = blackColor;

            PointCollection polygonPoints = new PointCollection();
            for (int i = 0; i < count; i++)
            {
                polygonPoints.Add(coordinates[i]);
            }
            polygon1.Points = polygonPoints;
            MainCanvas.Children.Add(polygon1);

        }

        public void MakeNodeNames()
        {
            SolidColorBrush blueColor = new SolidColorBrush();
            blueColor.Color = (Color)ColorConverter.ConvertFromString("#FFC4EBFF");
            for (int i = 0; i < count; i++)
            {
                Label temp = new Label() { Content = (i + 1), Background = blueColor};
                Canvas.SetLeft(temp, coordNodeNames[i][0]);
                Canvas.SetTop(temp, coordNodeNames[i][1]);
                MainCanvas.Children.Add(temp);
            }
        }

        private bool TryToInt()
        {
            try
            {
                tempNumberOfWavelength = int.Parse(tboxNumberOfWavelength.Text);
            }
            catch
            {
                MessageBox.Show("Введите целое число от 1 до 80");
                return false;
            }
            return true;
        }

        private void btnToPage3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());
        }
    }
}
