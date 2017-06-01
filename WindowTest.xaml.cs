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
        
        public void MakeTable()
        {
            this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });
            this.MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            this.MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Star) });
            this.MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            Brush color1 = (Brush)(new BrushConverter()).ConvertFromString("#FFD2D9F1");
            Brush color2 = (Brush)(new BrushConverter()).ConvertFromString("#FF96AFF4");
            Brush color3 = (Brush)(new BrushConverter()).ConvertFromString("#FFF2EFFF");

            Label _0x0 = new Label() { BorderThickness = new Thickness(3), BorderBrush = color1, Background = color1, Foreground = Brushes.White, FontWeight = FontWeights.Bold };

            //вставить в таблицу

        }
    }
}
