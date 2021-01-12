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

namespace Cake_Shop_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        List<ORDER_PRODUCT> _orders = new List<ORDER_PRODUCT>();
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var fore = (Brush)converter.ConvertFromString("white");
            var border = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = brush;
            ProductButton.Foreground = fore;
            ProductButton.BorderBrush = border;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProducts(ref _orders));
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var border = (Brush)converter.ConvertFromString("#e5e5e5");
            var white = (Brush)converter.ConvertFromString("white");
            var black = (Brush)converter.ConvertFromString("black");
            var transparent = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = brush;
            ProductButton.Foreground = white;
            ProductButton.BorderBrush = transparent;
            CreateButton.Background = transparent;
            CreateButton.Foreground = black;
            CreateButton.BorderBrush = border;
            StatisticalButton.Background = transparent;
            StatisticalButton.Foreground = black;
            StatisticalButton.BorderBrush = border;
            ListButton.Background = transparent;
            ListButton.Foreground = black;
            ListButton.BorderBrush = border;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProducts(ref _orders));
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var border = (Brush)converter.ConvertFromString("#e5e5e5");
            var white = (Brush)converter.ConvertFromString("white");
            var black = (Brush)converter.ConvertFromString("black");
            var transparent = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = transparent;
            ProductButton.Foreground = black;
            ProductButton.BorderBrush = border;
            CreateButton.Background = brush;
            CreateButton.Foreground = white;
            CreateButton.BorderBrush = transparent;
            StatisticalButton.Background = transparent;
            StatisticalButton.Foreground = black;
            StatisticalButton.BorderBrush = border;
            ListButton.Background = transparent;
            ListButton.Foreground = black;
            ListButton.BorderBrush = border;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCNewProduct());
        }

        private void StatisticalButton_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var border = (Brush)converter.ConvertFromString("#e5e5e5");
            var white = (Brush)converter.ConvertFromString("white");
            var black = (Brush)converter.ConvertFromString("black");
            var transparent = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = transparent;
            ProductButton.Foreground = black;
            ProductButton.BorderBrush = border;
            CreateButton.Background = transparent;
            CreateButton.Foreground = black;
            CreateButton.BorderBrush = border;
            StatisticalButton.Background = brush;
            StatisticalButton.Foreground = white;
            StatisticalButton.BorderBrush = transparent;
            ListButton.Background = transparent;
            ListButton.Foreground = black;
            ListButton.BorderBrush = border;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCStatisTical());
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var border = (Brush)converter.ConvertFromString("#e5e5e5");
            var white = (Brush)converter.ConvertFromString("white");
            var black = (Brush)converter.ConvertFromString("black");
            var transparent = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = transparent;
            ProductButton.Foreground = black;
            ProductButton.BorderBrush = border;
            CreateButton.Background = transparent;
            CreateButton.Foreground = black;
            CreateButton.BorderBrush = border;
            StatisticalButton.Background = transparent;
            StatisticalButton.Foreground = black;
            StatisticalButton.BorderBrush = border;
            ListButton.Background = brush;
            ListButton.Foreground = white;
            ListButton.BorderBrush = transparent;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCListOrders());
        }

        private void CartButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#2188fb");
            var border = (Brush)converter.ConvertFromString("#e5e5e5");
            var white = (Brush)converter.ConvertFromString("white");
            var black = (Brush)converter.ConvertFromString("black");
            var transparent = (Brush)converter.ConvertFromString("Transparent");
            ProductButton.Background = brush;
            ProductButton.Foreground = white;
            ProductButton.BorderBrush = transparent;
            CreateButton.Background = transparent;
            CreateButton.Foreground = black;
            CreateButton.BorderBrush = border;
            StatisticalButton.Background = transparent;
            StatisticalButton.Foreground = black;
            StatisticalButton.BorderBrush = border;
            ListButton.Background = transparent;
            ListButton.Foreground = black;
            ListButton.BorderBrush = border;
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCCart(ref _orders));

        }
    }


}
