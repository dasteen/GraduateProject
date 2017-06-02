using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalPart
{
    /// <summary>
    /// Логика взаимодействия для WindowTest.xaml
    /// </summary>
    public partial class WindowTest : Window
    {
        public WindowTest()
        {
            InitializeComponent();
        }
        
        public void MakeTable(int count)
        {

            Brush color1 = (Brush)(new BrushConverter()).ConvertFromString("#FFD2D9F1");
            Brush color2 = (Brush)(new BrushConverter()).ConvertFromString("#FF96AFF4");
            Brush color3 = (Brush)(new BrushConverter()).ConvertFromString("#FFF2EFFF");
            

            Label[] cellNames = new Label[count];
            TextBox[] cells = new TextBox[count * count];

            UniformGrid CellNamesCol = new UniformGrid() { Name = "CellNamesCol", Rows = count, Columns = 1 };
            CellNamesCol.SetValue(Grid.ColumnProperty, 0);
            CellNamesCol.SetValue(Grid.RowProperty, 1);

            UniformGrid CellNamesRow = new UniformGrid() { Name = "CellNamesRow", Rows = 1, Columns = count };
            CellNamesRow.SetValue(Grid.ColumnProperty, 1);
            CellNamesRow.SetValue(Grid.RowProperty, 0);

            UniformGrid Cells = new UniformGrid() { Name = "Cells", Rows = count, Columns = count };
            Cells.SetValue(Grid.ColumnProperty, 1);
            Cells.SetValue(Grid.RowProperty, 1);

            for (int i = 0; i < count; i++)
            {
                cellNames[i] = new Label()
                {
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderThickness = new Thickness(3),
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    BorderBrush = color1,
                    Background = color2
                };
                cellNames[i].Content = i + 1;
                CellNamesCol.Children.Add(cellNames[i]);
            }

            for (int i = 0; i < count; i++)
            {
                cellNames[i] = new Label()
                {
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderThickness = new Thickness(3),
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    BorderBrush = color1,
                    Background = color2
                };
                cellNames[i].Content = i + 1;
                CellNamesRow.Children.Add(cellNames[i]);
            }

            for (int i = 0; i < count*count; i++)
            {
                cells[i] = new TextBox()
                {
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderThickness = new Thickness(3),
                    FontWeight = FontWeights.Bold,
                    FontSize = 14,
                    Padding = new Thickness(0, 13, 0, 0),
                    TextAlignment = TextAlignment.Center,
                    BorderBrush = color1,
                    Background = color3
                };
                Cells.Children.Add(cells[i]);
            }





            MainGrid.Children.Add(CellNamesCol);
            MainGrid.Children.Add(CellNamesRow);
            MainGrid.Children.Add(Cells);
        }
    }
}
