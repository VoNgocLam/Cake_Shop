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
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading;
using System.Globalization;

namespace Cake_Shop_App
{
    /// <summary>
    /// Interaction logic for UCEditProduct.xaml
    /// </summary>
    public partial class UCEditProduct : UserControl
    {
        public PRODUCT _product;
        List<PRODUCT> _products;
        public UCEditProduct(PRODUCT p)
        {
            InitializeComponent();
            _product = p;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _product;
            _products = new List<PRODUCT>();
            _products.Add(_product);
            listImages.ItemsSource = _products;
        }

        private void imgCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProductDetail(_product));
        }

        private void imgSave_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
