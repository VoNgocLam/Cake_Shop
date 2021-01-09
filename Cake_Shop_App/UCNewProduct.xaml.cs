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
    /// Interaction logic for UCNewProduct.xaml
    /// </summary>
    public partial class UCNewProduct : UserControl
    {
        public PRODUCT _product;
        List<CATEGORy> _cate;
        List<PRODUCT_IMAGES> _listImages = new List<PRODUCT_IMAGES>();
        BindingList<string> _imgs = new BindingList<string>();
        public UCNewProduct()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using ( var context = new cakeshopdatabaseEntities1())
            {
                _cate = context.CATEGORIES.ToList();
            }
            cbCategory.ItemsSource = _cate;
        }

        private void imgSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống");
            }

            else if (tbTitle.Text.Trim() == "")
            {
                MessageBox.Show("Tiêu đề không được bỏ trống");
            }

            else if (tbPrice.Text.Trim() == "")
            {
                MessageBox.Show("Giá tiền không được bỏ trống");
            }

            else if (tbCategory.Text.Trim() == "")
            {
                MessageBox.Show("Danh mục không được bỏ trống");
            }

            else if (lvlistImages.ItemsSource == null)
            {
                MessageBox.Show("Hình ảnh không được bỏ trống");
            }

            else
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                string folderImages = folder + $"Images\\";
                
                using (var context = new cakeshopdatabaseEntities1())
                {
                    _product = new PRODUCT();
                    bool flag = false;
                    foreach( var cate in _cate)
                    {
                        if ( cate.CategoryName == tbCategory.Text)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        var newCategory = new CATEGORy()
                        {
                            CategoryName = tbCategory.Text
                        };

                        context.CATEGORIES.Add(newCategory);
                        context.SaveChanges();

                        var cateID = (from c in context.CATEGORIES where c.CategoryName == tbCategory.Text select c).Single();
                        if( cateID != null)
                        {
                            _product.CategoryID = cateID.CategoryID;
                        }
                    }
                    else
                    {
                        var cateID = (from c in context.CATEGORIES where c.CategoryName == tbCategory.Text select c).Single();
                        if (cateID != null)
                        {
                            _product.CategoryID = cateID.CategoryID;
                        }
                    };

                    _product.ProductName = tbName.Text;
                    _product.productTitle = tbTitle.Text;
                    _product.ProductDescription = tbDescription.Text;
                    _product.Price = int.Parse(tbPrice.Text);

                    context.PRODUCTS.Add(_product);
                    context.SaveChanges();

                    var productIDQuery = (from s in context.PRODUCTS where s.ProductName == _product.ProductName select s).Single();
                    _product.ProductID = productIDQuery.ProductID;

                    foreach (var img in _imgs)
                    {
                        string nameImg = System.IO.Path.GetFileName(img);
                        var image = new PRODUCT_IMAGES()
                        {
                            ProductID = _product.ProductID,
                            ImagePath = nameImg
                        };
                        _listImages.Add(image);
                        string imgDirec = folderImages + "\\" + nameImg;
                        File.Copy(img, imgDirec, true);
                    }

                  
                    foreach ( var image in _listImages)
                    {
                        context.PRODUCT_IMAGES.Add(image);
                        context.SaveChanges();
                    }
                }
                
                MainWindow m = new MainWindow();
                m.Show();
                Window.GetWindow(this).Close();
            }

        }

        private void imgCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MainWindow m = new MainWindow();
                m.Show();
                Window.GetWindow(this).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbCategory.SelectedItem as CATEGORy;
            tbCategory.Text = item.CategoryName;
        }

        private void ListImagesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();
            if (result == true)
            {
                foreach (string item in open.FileNames)
                {
                    _imgs.Add(item);
                }
                lvlistImages.ItemsSource = _imgs;
            }
        }
    }
}
