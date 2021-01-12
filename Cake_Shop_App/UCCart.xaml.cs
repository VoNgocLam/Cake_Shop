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
    /// Interaction logic for UCCart.xaml
    /// </summary>
    /// 
    public partial class UCCart : UserControl
    {
        ObservableCollection<PRODUCT> _products;
        List<ORDER_PRODUCT> _orders;
        int? _totalCash;
        double totalCash;
        
        public UCCart(ref List<ORDER_PRODUCT> o)
        {
            InitializeComponent();
            _orders = o;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _totalCash = 0;
            _products = new ObservableCollection<PRODUCT>();
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            using (var context = new cakeshopdatabaseEntities1())
            {

                for(int i = 0; i < _orders.Count; i++)
                {
                    var productID = _orders[i].ProductID;
                    var productQuery = (from s in context.PRODUCTS where s.ProductID == productID select s).Single();
                    var avatar = (from a in context.PRODUCT_IMAGES where a.ProductID == productID select a).Take(1).Single();
                    _products.Add(productQuery);
                    _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                    _products[i].Quantity = _orders[i].Quantity;
                    _totalCash += _products[i].Quantity * _products[i].Price;
                }               
            };

            if(_totalCash.HasValue)
            {
                totalCash = _totalCash.Value;
            }
            _total.Content = totalCash.ToString("N0").Replace(",",".") + " VNĐ";
            total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
            lbProductCount.Text = _orders.Count.ToString();
            dataListView.ItemsSource = _products;
        }

        private void Minus_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var item = (sender as FrameworkElement).DataContext;
            
            int index = dataListView.Items.IndexOf(item);

            --_products[index].Quantity;
            --_orders[index].Quantity;

            _totalCash -= _products[index].Price;

            if(_products[index].Quantity==0)
            {
                _products.RemoveAt(index);
                _orders.RemoveAt(index);
            }
            if (_totalCash.HasValue)
            {
                totalCash = _totalCash.Value;
            }
            _total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
            total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
            lbProductCount.Text = _orders.Count.ToString();
            dataListView.Items.Refresh();
        }       
      
        private void Plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;

            int index = dataListView.Items.IndexOf(item);

            ++_products[index].Quantity;
            ++_orders[index].Quantity;
            _totalCash += _products[index].Price;
            if (_totalCash.HasValue)
            {
                totalCash = _totalCash.Value;
            }
            _total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
            total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
            lbProductCount.Text = _orders.Count.ToString();
            dataListView.Items.Refresh();
        }
    }
}
