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
        int? urserID;
        int? orderID;
        double totalCash;
        List<USER> _users;
        public UCCart(ref List<ORDER_PRODUCT> o)
        {
            InitializeComponent();
            _orders = o;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(_orders.Count == 0)
            {
                Suspend.Visibility = Visibility.Visible;
                Active.Visibility = Visibility.Collapsed;
            }
            else
            {
                Suspend.Visibility = Visibility.Collapsed;
                Active.Visibility = Visibility.Visible;
                _totalCash = 0;
                _products = new ObservableCollection<PRODUCT>();
                string folder = AppDomain.CurrentDomain.BaseDirectory;
                if (_orders.Count > 0)
                {
                    InfoUser.Visibility = Visibility.Visible;
                }

                using (var context = new cakeshopdatabaseEntities1())
                {

                    for (int i = 0; i < _orders.Count; i++)
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

                if (_totalCash.HasValue)
                {
                    totalCash = _totalCash.Value;
                }
                _total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
                total.Content = totalCash.ToString("N0").Replace(",", ".") + " VNĐ";
                lbProductCount.Text = _orders.Count.ToString();
                dataListView.ItemsSource = _products;
            }
           
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
            if (_orders.Count == 0)
            {
                Suspend.Visibility = Visibility.Visible;
                Active.Visibility = Visibility.Collapsed;
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

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProducts(ref _orders));
        }

        private void OrderButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbUserName.Text == "")
            {
                MessageBox.Show("Họ tên khách hàng không được bỏ trống");
            }
            else if (tbUserPhone.Text=="")
            {
                MessageBox.Show("Số diện thoại không được bỏ trống");
            }
            else
            {
                DateTime localDate = DateTime.Now;
                using ( var context = new cakeshopdatabaseEntities1())
                {
                    _users = context.USERS.ToList();
                    bool flag = true;
                   
                    foreach ( var user in _users)
                    {
                        if (user.UserPhone == tbUserPhone.Text)
                        {
                            flag = false;
                            urserID = user.UserID;
                            break;
                        }
                    }

                    if(flag)
                    {
                        var newUser = new USER()
                        {
                            UserName = tbUserName.Text,
                            UserPhone = tbUserPhone.Text
                        };
                        context.USERS.Add(newUser);
                        context.SaveChanges();
                        var user = (from s in context.USERS where s.UserPhone == tbUserPhone.Text select s).Single();
                        urserID = user.UserID;
                    }

                    if(urserID.HasValue)
                    {
                        var newOrder = new ORDER()
                        {
                            UserID = urserID,
                            Date = localDate
                        };
                        context.ORDERS.Add(newOrder);
                        context.SaveChanges();
                       // var order = (from s in context.ORDERS where s.Date == newOrder.Date select s).Single();
                        orderID = order.OrderID;
                    }
                   
                    if(orderID.HasValue)
                    {
                        foreach (var detailOrder in _orders)
                        {
                            detailOrder.OrderID = orderID.Value;
                            context.ORDER_PRODUCT.Add(detailOrder);
                            context.SaveChanges();
                        }
                    }

                }
            }
        }

     
    }
}
