using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;

namespace Cake_Shop_App
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private Random _rng = new Random();
        ObservableCollection<Product> _products;
        ObservableCollection<Product> _product;

        DispatcherTimer dTimer = new DispatcherTimer();
        string sFile = "";
        string sBackground = "";
        bool flag = true;

        public SplashScreen()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            sFile = $"{folder}Check.txt";
            var data = File.ReadAllText(sFile);
            InitializeComponent();
            if (data == "checked")
            {
                MainWindow m = new MainWindow();
                m.Show();
                this.Close();
            }
            else
            {
                dTimer.Tick += new EventHandler(dTimer_Tick);
                dTimer.Interval = new TimeSpan(0, 0, 60);
                dTimer.Start();
            }
        }
        private void dTimer_Tick(object sender, EventArgs e)
        {
            if (flag == true)
            {
                MainWindow m = new MainWindow();
                m.Show();
                dTimer.Stop();
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var BgFile = $"{folder}Background\\";
            var direcFile = $"{folder}Cakes.txt";
            int lineCount = File.ReadLines(direcFile).Count();
            var database = File.ReadAllLines(direcFile);
            int count = lineCount / 3;
            _products = new ObservableCollection<Product>();
            for (int i = 0; i < count; i++)
            {
                var line1 = database[i * 3];
                var line2 = database[i * 3 + 1];
                var line3 = database[i * 3 + 2];
                var product = new Product()
                {
                    Name = line1,
                    Avatar = line2,
                    Description = line3
                };
                _products.Add(product);
            }
            var k = _rng.Next(_products.Count);
            var t = _rng.Next(3);
            _product = new ObservableCollection<Product>();
            _product.Add(_products[k]);
            sFile = $"{folder}Images\\{_products[k].Avatar}";
            sBackground = $"{BgFile}background_{t}.jpg";
            BackgoundProductImg.ImageSource = new BitmapImage(new Uri(sFile));
            BackgroundImg.ImageSource = new BitmapImage(new Uri(sBackground));
            CakeIntroduce.ItemsSource = _product;
        }
        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            sFile = $"{folder}Check.txt";
            File.Create(sFile).Close();
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            sFile = $"{folder}Check.txt";
            File.AppendAllText(sFile, "checked");
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
