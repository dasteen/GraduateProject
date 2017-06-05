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
        }

        public int count = MainWindow.table1.correctedPath.Length;
        public int[][] path;
        public int[][] matrixPath;
        public int radius = 100;
        public PointCollection coordinates = new PointCollection();

        public void FindCoordinates()
        {
            path = new int[count][];
            Array.Copy(MainWindow.table1.correctedPath, path, count);
            matrixPath = new int[count][];
            Array.Copy(MainWindow.table1.copyMatrix, matrixPath, count);

            int x, y;

            int xCentrе = (int)(MainCanvas.ActualWidth / 2);
            int yCentre = (int)(MainCanvas.ActualHeight / 2);
            for (int i = 0; i < count; i++)
            {
                x = Convert.ToInt32(xCentrе + (radius * Math.Cos(2 * i * Math.PI / count)));
                y = Convert.ToInt32(xCentrе + (radius * Math.Sin(2 * i * Math.PI / count)));
                coordinates.Add(new Point(x, y));
            }
        }

        public void ShowTopology()
        {
            FindCoordinates();
            MakeAPolygon();
        }

        private void btnShowTopology(object sender, RoutedEventArgs e)
        {
            ShowTopology();
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
    }
}
