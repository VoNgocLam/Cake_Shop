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
        List<PRODUCT> _products;
        List<PRODUCT> _cakeproducts;
        List<PRODUCT> _breadproducts;
        List<PRODUCT> _bangelproducts;
        List<PRODUCT> _cupcakeproducts;
        List<CATEGORy> _cate;
        List<PRODUCT_IMAGES> _images;
        PagingInfo pageno = new PagingInfo();

        public UCProducts()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            tvCategoryProduct cate1 = new tvCategoryProduct() { Name = "Bánh Kem" };
            tvCategoryProduct cate2 = new tvCategoryProduct() { Name = "Bánh Mì" };
            tvCategoryProduct cate3 = new tvCategoryProduct() { Name = "Bánh Mì Vòng" };
            tvCategoryProduct cate4 = new tvCategoryProduct() { Name = "Bánh Nướng Nhỏ" };
            tvCategoryProduct cate5 = new tvCategoryProduct() { Name = "Tất cả sản phẩm" };

            using (var context = new cakeshopdatabaseEntities1())
            {
                _products = context.PRODUCTS.ToList();
                _cate = context.CATEGORIES.ToList();
                _images = context.PRODUCT_IMAGES.ToList();
                for (int i=0; i< _products.Count;i++)
                {
                    var avatar = (from s in _images where s.ProductID == _products[i].ProductID select s).Take(1).Single();
                    _products[i].ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                    cate5.dataProducts.Add(new dataProduct() { Name = _products[i].ProductName });
                }
                
                foreach (var category in _cate)
                {
                    if (category.CategoryName == "Bánh Kem")
                    {
                        var query = from s in _products where s.CategoryID == category.CategoryID select s;
                        _cakeproducts = query.ToList();
                        foreach (var product in _cakeproducts)
                        {
                            cate1.dataProducts.Add(new dataProduct() { Name = product.ProductName });
                        }
                    }
                    if (category.CategoryName == "Bánh Mì")
                    {
                        var query = from s in _products where s.CategoryID == category.CategoryID select s;
                        _breadproducts = query.ToList();
                        foreach (var product in _breadproducts)
                        {
                            cate2.dataProducts.Add(new dataProduct() { Name = product.ProductName });
                        }
                    }
                    if (category.CategoryName == "Bánh Mì Vòng")
                    {
                        var query = from s in _products where s.CategoryID == category.CategoryID select s;
                        _bangelproducts = query.ToList();
                        foreach (var product in _bangelproducts)
                        {
                            cate3.dataProducts.Add(new dataProduct() { Name = product.ProductName });
                        }
                    }
                    if (category.CategoryName == "Bánh Nướng Nhỏ")
                    {
                        var query = from s in _products where s.CategoryID == category.CategoryID select s;
                        _cupcakeproducts = query.ToList();
                        foreach (var product in _cupcakeproducts)
                        {
                            cate4.dataProducts.Add(new dataProduct() { Name = product.ProductName });
                        }
                    }
                };
            };
            List<tvCategoryProduct> dTreeView = new List<tvCategoryProduct>();

            dTreeView.Add(cate5);
            dTreeView.Add(cate1);
            dTreeView.Add(cate2);
            dTreeView.Add(cate3);
            dTreeView.Add(cate4);

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
                    if (item.Name == "Bánh Kem")
                    {
                        _products = _cakeproducts.ToList();
                    }
                    if (item.Name == "Bánh Mì")
                    {
                        _products = _breadproducts.ToList();
                    }
                    if (item.Name == "Bánh Mì Vòng")
                    {
                        _products = _bangelproducts.ToList();
                    }
                    if (item.Name == "Bánh Nướng Nhỏ")
                    {
                        _products = _cupcakeproducts.ToList();
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

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
              

        private void dataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as PRODUCT;
            if (item != null)
            {
                WorkScreen.Children.Clear();
                WorkScreen.Children.Add(new UCProductDetail(item));
            }
        }
    }
}
