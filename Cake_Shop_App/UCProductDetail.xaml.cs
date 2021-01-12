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
    /// Interaction logic for UCProductDetail.xaml
    /// </summary>
    /// 

    public partial class UCProductDetail : UserControl
    {

        public PRODUCT _product;
        List<PRODUCT> _produts;
        List<CATEGORy> _cate;
        List<PRODUCT_IMAGES> _img;
        List<ORDER_PRODUCT> _orders;

        public UCProductDetail(PRODUCT p, ref List<ORDER_PRODUCT> o)
        {
            InitializeComponent();
            _product = p;
            _orders = o;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _product.listImages = new BindingList<string>();
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            using ( var context = new cakeshopdatabaseEntities1())
            {
                _cate = context.CATEGORIES.ToList();
                _img = context.PRODUCT_IMAGES.ToList();

                var query = from s in _cate where s.CategoryID == _product.CategoryID select s;
                _cate = query.ToList();
                foreach ( var cate in _cate)
                {
                    _product.CategoryName = cate.CategoryName;
                }

                var ImgPathQuery = from s in _img where s.ProductID == _product.ProductID select s;
                _img = ImgPathQuery.ToList();
                foreach ( var img in _img)
                {
                    _product.listImages.Add($"{folder}Images\\{img.ImagePath}");
                }
            }
            _produts = new List<PRODUCT>();
            _produts.Add(_product);
            this.DataContext = _product;
            PreviewPhoto.ItemsSource = _produts;
            Category.Content = _product.CategoryName;
        }    

        private void editProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCEditProduct(_product, ref _orders));
        }

        private void OrderButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool flag = true;

            foreach (var o in _orders)
            {
                if (o.ProductID == _product.ProductID)
                {
                    flag = false;
                    break;
                };
            };
            if(flag)
            {
                var order = new ORDER_PRODUCT()
                {
                    ProductID = _product.ProductID,
                    Quantity = 1
                };
                _orders.Add(order);
            }
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCCart(ref _orders));
           
        }
    }
}
