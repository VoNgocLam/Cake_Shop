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
using LiveCharts;
using LiveCharts.Wpf;

namespace Cake_Shop_App
{
    /// <summary>
    /// Interaction logic for UCStatisTical.xaml
    /// </summary>
    public partial class UCStatisTical : UserControl
    {
        public UCStatisTical()
        {
            InitializeComponent();
            cbYear.ItemsSource = new string[] { "2020", "2021" };
        }
        public class ArchiveEntry
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public string MonthName
            {
                get
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.Month);
                }
            }
            public int Total { get; set; }
        }
        public string[] Labels { get; set; }
        public SeriesCollection Data1 { get; set; }
        public SeriesCollection Data2 { get; set; }

        List<int> RevenuePerMonth;
        List<ORDER_PRODUCT> _listDetailOrders;
        int iYear;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RevenuePerMonth = new List<int>();
            _listDetailOrders = new List<ORDER_PRODUCT>();
            iYear = 2021;
            using (var context = new cakeshopdatabaseEntities1())
            {
                for (int i = 1; i <= 12; i++)
                {
                    var queryOrder = (from s in context.ORDERS where s.Date.Value.Month == i && s.Date.Value.Year == iYear select s).ToList();
                    int? totalCash = 0;
                    foreach (var Order in queryOrder)
                    {
                        var queryDetailOrder = (from s in context.ORDER_PRODUCT where s.OrderID == Order.OrderID select s).ToList();
                        foreach (var detailOrder in queryDetailOrder)
                        {
                            totalCash += detailOrder.Quantity * detailOrder.SinglePrice;
                        }
                    }
                    RevenuePerMonth.Add(totalCash.Value);                  
                }
                var queryOrders = (from s in context.ORDERS where s.Date.Value.Year == iYear select s).ToList();
                foreach (var Order in queryOrders)
                {
                    var queryDetailOrder = (from s in context.ORDER_PRODUCT where s.OrderID == Order.OrderID select s).ToList();
                    foreach (var detailOrder in queryDetailOrder)
                    {
                        _listDetailOrders.Add(detailOrder);
                    }
                }
                var queryBasedOnCategory = (from s in _listDetailOrders group s by new { s.ProductID, s.SinglePrice } into g orderby g.Key.ProductID select new { productID = g.Key.ProductID, Revenue = g.Sum(s => s.Quantity)*g.Key.SinglePrice}).ToList();
                
                Data2 = new SeriesCollection() { };
                
                foreach (var category in queryBasedOnCategory)
                {
                    var productName = (from s in context.PRODUCTS where s.ProductID == category.productID select s).Single();
                    PieSeries Pie = new PieSeries()
                    {
                        Title = $"{productName.ProductName}",
                        Values = new ChartValues<int> { category.Revenue.Value }
                    };
                    Data2.Add(Pie);
                }
            }

            ColumnSeries c = new ColumnSeries()
            {
                Title = "",
                Values = new ChartValues<int> { }
            };
            foreach (var revenue in RevenuePerMonth)
            {
                c.Values.Add(revenue);
            }
            Data1 = new SeriesCollection() { };
            Data1.Add(c);
            Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            tbYear.Text = "2021";
            tbYears.Text = "2021";
            DataContext = this;
        }

        private void cbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data2 = new SeriesCollection() { };
            _listDetailOrders = new List<ORDER_PRODUCT>();
            tbYear.Text = cbYear.SelectedItem as String;
            tbYears.Text = cbYear.SelectedItem as String;
            iYear = int.Parse(cbYear.SelectedItem as String);
            RevenuePerMonth = new List<int>();
            using (var context = new cakeshopdatabaseEntities1())
            {
                for (int i = 1; i <= 12; i++)
                {
                    var queryOrder = (from s in context.ORDERS where s.Date.Value.Month == i && s.Date.Value.Year == iYear select s).ToList();
                    int? totalCash = 0;
                    foreach (var Order in queryOrder)
                    {
                        var queryDetailOrder = (from s in context.ORDER_PRODUCT where s.OrderID == Order.OrderID select s).ToList();
                        foreach (var detailOrder in queryDetailOrder)
                        {
                            totalCash += detailOrder.Quantity * detailOrder.SinglePrice;
                        }
                    }
                    RevenuePerMonth.Add(totalCash.Value);
                }
                var queryOrders = (from s in context.ORDERS where s.Date.Value.Year == iYear select s).ToList();
                foreach (var Order in queryOrders)
                {
                    var queryDetailOrder = (from s in context.ORDER_PRODUCT where s.OrderID == Order.OrderID select s).ToList();
                    foreach (var detailOrder in queryDetailOrder)
                    {
                        _listDetailOrders.Add(detailOrder);
                    }
                }
                var queryBasedOnCategory = (from s in _listDetailOrders group s by new { s.ProductID, s.SinglePrice } into g orderby g.Key.ProductID select new { productID = g.Key.ProductID, Revenue = g.Sum(s => s.Quantity) * g.Key.SinglePrice }).ToList();

                foreach (var category in queryBasedOnCategory)
                {
                    var productName = (from s in context.PRODUCTS where s.ProductID == category.productID select s).Single();
                    PieSeries Pie = new PieSeries()
                    {
                        Title = $"{productName.ProductName}",
                        Values = new ChartValues<int> { category.Revenue.Value }
                    };
                    Data2.Add(Pie);
                }
            }

            ColumnSeries c = new ColumnSeries()
            {
                Title = "",
                Values = new ChartValues<int> { }
            };

            foreach (var revenue in RevenuePerMonth)
            {
                c.Values.Add(revenue);
            }

            Data1 = new SeriesCollection() { };
            Data1.Add(c);

            Thread thread = new Thread(delegate ()
            {
                // Đưa lên UI
                Dispatcher.Invoke(() =>
                {
                    _CartesianChart.Series = Data1;
                    _pieChart.Series = Data2;
                });
            });
            thread.Start();
        }
    }
                
}
