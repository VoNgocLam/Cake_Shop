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
    /// Interaction logic for UCProducts.xaml
    /// </summary>
    /// 
   
    public class dataProduct
    {
        public string Name { get; set; }
    }
    public class tvCategoryProduct
    {
        public ObservableCollection<dataProduct> dataProducts { get; set; }
        public tvCategoryProduct()
        {
            this.dataProducts = new ObservableCollection<dataProduct>();
        }
        public string Name { get; set; }

    }
    public partial class UCProducts : UserControl
    {
        List<PRODUCT> _product;
        List<PRODUCT> _products;
        List<CATEGORy> _cate;
        List<ORDER_PRODUCT> _orders;


        List<PRODUCT_IMAGES> _images;
        PagingInfo pageno = new PagingInfo();

        public UCProducts(ref List<ORDER_PRODUCT> o)
        {
            InitializeComponent();
            _orders = o;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            List<tvCategoryProduct> cate = new List<tvCategoryProduct>(); 
                      
            tvCategoryProduct cate1 = new tvCategoryProduct() { Name = "Tất cả sản phẩm" };


            using (var context = new cakeshopdatabaseEntities1())
            {
                _products = context.PRODUCTS.ToList();
                _cate = context.CATEGORIES.ToList();
                _images = context.PRODUCT_IMAGES.ToList();
                for (int i=0; i< _products.Count;i++)
                {
                    var avatar = (from s in _images where s.ProductID == _products[i].ProductID select s).Take(1).Single();
                    _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                    cate1.dataProducts.Add(new dataProduct() { Name = _products[i].ProductName });
                }
                
                foreach (var category in _cate)
                {
                    tvCategoryProduct cates = new tvCategoryProduct() { Name = category.CategoryName };
                    cates.Name = category.CategoryName;
                    var query = from s in _products where s.CategoryID == category.CategoryID select s;
                    _product = query.ToList();
                    foreach ( var product in _product)
                    {
                        cates.dataProducts.Add(new dataProduct() { Name = product.ProductName });
                    }
                    cate.Add(cates);
                } 
            };
        
            List<tvCategoryProduct> dTreeView = new List<tvCategoryProduct>();

            dTreeView.Add(cate1);

            foreach ( var cateName in cate)
            {
                dTreeView.Add(cateName);
            }
            
            dataTreeview.ItemsSource = dTreeView;

            pageno.CurrentPage = 1;
            pageno.RowsPerPage = 10;
            pageno.Count = _products.Count;
            pageno.TotalPage = (pageno.Count / pageno.RowsPerPage) +
               (pageno.Count % pageno.RowsPerPage == 0 ? 0 : 1);
            if(_products.Count > 10)
            {
                NextButton.Visibility = Visibility.Visible;
                PrevButton.Visibility = Visibility.Hidden;
            }

            Thread thread = new Thread(delegate ()
           {
               Dispatcher.Invoke(() =>
               {
                   dataListView.ItemsSource = _products.Take(pageno.RowsPerPage);
               });
           });

            thread.Start();
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
          
            if (pageno.CurrentPage <= pageno.TotalPage)
            {
                pageno.CurrentPage--;
                if (pageno.CurrentPage == 1)
                {
                    PrevButton.Visibility = Visibility.Hidden;
                    NextButton.Visibility = Visibility.Visible;
                }
                if (pageno.CurrentPage > 1 && pageno.CurrentPage < pageno.TotalPage)
                {
                    PrevButton.Visibility = Visibility.Visible;
                    NextButton.Visibility = Visibility.Visible;
                }
                if (pageno.CurrentPage == pageno.TotalPage)
                {
                    NextButton.Visibility = Visibility.Hidden;
                    PrevButton.Visibility = Visibility.Visible;
                }
                dataListView.ItemsSource =
                _products
                    .Skip((pageno.CurrentPage - 1) * pageno.RowsPerPage)
                    .Take(pageno.RowsPerPage);
                if (pageno.CurrentPage <= 1)
                {
                    pageno.CurrentPage = 1;
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (pageno.CurrentPage < pageno.TotalPage)
            {
                pageno.CurrentPage++;
                if (pageno.CurrentPage == 1)
                {
                    PrevButton.Visibility = Visibility.Hidden;
                    NextButton.Visibility = Visibility.Visible;
                }                            
                if (pageno.CurrentPage > 1 && pageno.CurrentPage < pageno.TotalPage)
                {
                    PrevButton.Visibility = Visibility.Visible;
                    NextButton.Visibility = Visibility.Visible;
                }
                if (pageno.CurrentPage == pageno.TotalPage)
                {
                    NextButton.Visibility = Visibility.Hidden;
                    PrevButton.Visibility = Visibility.Visible;
                }
                dataListView.ItemsSource = _products
                .Skip((pageno.CurrentPage - 1) * pageno.RowsPerPage)
                .Take(pageno.RowsPerPage);
            }
           
        }

        private void dataTreeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ObservableCollection<PRODUCT> product;
            var item = (sender as TreeView).SelectedItem as tvCategoryProduct;
            if(item != null)
            {
                if (item.Name == "Tất cả sản phẩm")
                {
                    _products.Clear();
                    string folder = AppDomain.CurrentDomain.BaseDirectory;
                    using (var context = new cakeshopdatabaseEntities1())
                    {
                        _products = context.PRODUCTS.ToList();
                        _images = context.PRODUCT_IMAGES.ToList();
                        for (int i = 0; i < _products.Count; i++)
                        {
                            var avatar = (from s in _images where s.ProductID == _products[i].ProductID select s).Take(1).Single();
                            _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                        }
                    }
                }
                else
                {
                    _products.Clear();
                    string folder = AppDomain.CurrentDomain.BaseDirectory;
                    using (var context = new cakeshopdatabaseEntities1())
                   {
                        var queryCate = (from c in _cate where c.CategoryName == item.Name select c).Single();
                        var queryProduct = from s in context.PRODUCTS where s.CategoryID == queryCate.CategoryID select s;
                        _products = queryProduct.ToList();
                        _images = context.PRODUCT_IMAGES.ToList();
                        for (int i =0; i< _products.Count(); i++)
                        {
                            var avatar = (from s in _images where s.ProductID == _products[i].ProductID select s).Take(1).Single();
                            _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                        }
                    }
                   
                }              

                pageno.CurrentPage = 1;
                pageno.RowsPerPage = 10;
                pageno.Count = _products.Count;
                pageno.TotalPage = (pageno.Count / pageno.RowsPerPage) +
                   (pageno.Count % pageno.RowsPerPage == 0 ? 0 : 1);

                if (_products.Count > 10)
                {
                    NextButton.Visibility = Visibility.Visible;
                    PrevButton.Visibility = Visibility.Hidden;
                }
                if (_products.Count < 10)
                {
                    NextButton.Visibility = Visibility.Hidden;
                    PrevButton.Visibility = Visibility.Hidden;
                }
                dataListView.ItemsSource = _products.Take(pageno.RowsPerPage);              
            }
            else
            {
                _products.Clear();
                product = new ObservableCollection<PRODUCT>();
                string folder = AppDomain.CurrentDomain.BaseDirectory;

                using (var context = new cakeshopdatabaseEntities1())
                {
                    _products = context.PRODUCTS.ToList();
                    _images = context.PRODUCT_IMAGES.ToList();
                    for (int i = 0; i < _products.Count; i++)
                    {
                        var avatar = (from s in _images where s.ProductID == _products[i].ProductID select s).Take(1).Single();
                        _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                    }
                }
                var prod = (sender as TreeView).SelectedItem as dataProduct;
                foreach (var p in _products)
                {
                    if (p.ProductName == prod.Name)
                    {
                        product.Add(p);
                        break;
                    }
                }

                NextButton.Visibility = Visibility.Hidden;
                PrevButton.Visibility = Visibility.Hidden;
                dataListView.ItemsSource = product;
            }
        }      

        private void dataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as PRODUCT;
            if (item != null)
            {
                WorkScreen.Children.Clear();
                WorkScreen.Children.Add(new UCProductDetail(item, ref _orders));
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            var item = (sender as FrameworkElement).DataContext;

            int index = dataListView.Items.IndexOf(item);

            bool flag = true;
            var product = item as PRODUCT;
            foreach (var o in _orders)
            {
                if (product.ProductID == o.ProductID)
                {
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                var order = new ORDER_PRODUCT()
                {
                    ProductID = product.ProductID,
                    Quantity = 1
                };
                _orders.Add(order);
            }
            dataListView.Items.Refresh();
        }


    }
}
