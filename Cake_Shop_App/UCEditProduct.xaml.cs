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
using Microsoft.Win32;
using System.Reflection;


namespace Cake_Shop_App
{
    /// <summary>
    /// Interaction logic for UCEditProduct.xaml
    /// </summary>
    public partial class UCEditProduct : UserControl
    {
        public PRODUCT _product;
        ObservableCollection<PRODUCT> _products;
        List<PRODUCT> _resultProducts;
        List<CATEGORy> _cate;
        List<PRODUCT_IMAGES> _listImages = new List<PRODUCT_IMAGES>();
        List<String> imagesDeleted = new List<String>();
        List<PRODUCT_IMAGES> _img;
        List<PRODUCT_IMAGES> _flag;

        public UCEditProduct(PRODUCT p)
        {
            InitializeComponent();
            _product = p;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _product;
            _products = new ObservableCollection<PRODUCT>();
            _products.Add(_product);
            using ( var context= new cakeshopdatabaseEntities1())
            {
                _cate = context.CATEGORIES.ToList();
                _img = context.PRODUCT_IMAGES.ToList();
            };
            cbCategory.ItemsSource = _cate;
            icListImages.ItemsSource = _products;
        }

        private void imgCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProductDetail(_product));
        }
             
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var item = cbCategory.SelectedItem as CATEGORy;
            tbCategory.Text = item.CategoryName;
        }
       
        private void ListImagesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();
            if (result == true)
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                string folderImages = folder + $"Images\\";
                var item = open.FileNames;
                string nameImg = System.IO.Path.GetFileName(item[0]);
                var flag = from s in _img where s.ImagePath == nameImg select s;
                _flag = flag.ToList();
                if (_flag.Count() == 0)
                {
                    var _image = new PRODUCT_IMAGES()
                    {
                        ProductID = _product.ProductID,
                        ImagePath = nameImg
                    };                        
                    _listImages.Add(_image);
                    _products[0].listImages.Add(folderImages + nameImg);
                    string imgDirec = folderImages + "\\" + nameImg;
                    File.Copy(item[0], imgDirec, true);
                }
                else
                {
                    MessageBox.Show(string.Format("Hình ảnh " + nameImg + " đã xuất hiện trong sản phẩm khác"));
                }
                
            }
        }
        private void buttonDeleteImages_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            string nameImg = System.IO.Path.GetFileName(item.ToString());
            imagesDeleted.Add(nameImg);
            int index = _products[0].listImages.IndexOf(item.ToString());
            _products[0].listImages.RemoveAt(index);          
        }

        private void imgSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống");
            }

            if (tbTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tiêu đề không được bỏ trống");
            }

            if (tbPrice.Text.Trim() == "")
            {
                MessageBox.Show("Giá tiền không được bỏ trống");
            }

            if (tbCategory.Text.Trim() == "")
            {
                MessageBox.Show("Danh mục không được bỏ trống");
            }
            if (_products[0].listImages.Count == 0)
            {
                MessageBox.Show("Hình ảnh không được bỏ trống");
            }

            if (tbName.Text.Trim() != "" && tbTitle.Text.Trim() != "" && tbPrice.Text.Trim() != "" && tbCategory.Text.Trim() != null && _products[0].listImages.Count != 0)
            {
                using ( var context = new cakeshopdatabaseEntities1())
                {
                    var folder = AppDomain.CurrentDomain.BaseDirectory;
                    var updateProduct = (from p in context.PRODUCTS where p.ProductID == _product.ProductID select p).Single();
                    var queryCategory = (from c in _cate where c.CategoryName == tbCategory.Text select c).Single();
                    
                    if (updateProduct != null)
                    {
                        updateProduct.ProductName = tbName.Text;
                        updateProduct.productTitle = tbTitle.Text;
                        updateProduct.ProductDescription = tbDescription.Text;
                        updateProduct.Price = int.Parse(tbPrice.Text);
                        updateProduct.CategoryID = queryCategory.CategoryID;
                        context.SaveChanges();
                    }
                    
                    foreach( var imgs in _listImages)
                    {
                        context.PRODUCT_IMAGES.Add(imgs);
                        context.SaveChanges();
                    }
                    
                    foreach ( var imgs in imagesDeleted)
                    {
                        var deleteQuery = (from i in context.PRODUCT_IMAGES where i.ImagePath == imgs select i).Single();
                        context.PRODUCT_IMAGES.Remove(deleteQuery);
                        context.SaveChanges();
                    }

                    var query = from s in context.PRODUCTS where s.ProductID == _product.ProductID select s;
                    var avatar = (from s in context.PRODUCT_IMAGES where s.ProductID == _product.ProductID select s).Take(1).Single();

                    _resultProducts = query.ToList();
                    _product = _resultProducts[0];
                    _product.ProductAvatar = $"{folder}Images\\{avatar.ImagePath}";
                }
            }
            WorkScreen.Children.Clear();
            WorkScreen.Children.Add(new UCProductDetail(_product));
        }
    }             
}
